using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using Microsoft.SharePoint.Client;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.Service.Base;
using Pe.Stracon.SGC.Cross.Core.Exception;

namespace Pe.Stracon.SGC.Aplicacion.Service.Contractual
{
    /// <summary>
    /// Clase para Interacción con un servidor SharePoint Online
    /// </summary>
    public class SharePointService : GenericService, ISharePointService
    {
        /// <summary>
        /// Interfaz de comunicación con parámetro de políticas.
        /// </summary>
        public IPoliticaService politicaService { get; set; }

        /// <summary>
        /// Retorna las credenciales de acceso al SharePoint
        /// </summary>
        /// <returns>Credenciales de acceso a sharepoint</returns>
        public SharePointOnlineCredentials RetornaCredencialesServer()
        {
            string userShp = string.Empty, passWord = string.Empty, dominio = string.Empty;

            var crdSharePoint = politicaService.ListarCredencialesAccesoDinamico();
            userShp = crdSharePoint.Result[0].Atributo3;
            passWord = crdSharePoint.Result[0].Atributo4;
            dominio = crdSharePoint.Result[0].Atributo5;

            var securepassword = new SecureString();

            foreach (char c in passWord)
            {
                securepassword.AppendChar(c);
            }

            return new SharePointOnlineCredentials(userShp, securepassword);
        }
        /// <summary>
        /// Retorna el Site del Servidor SharePoint configurado
        /// </summary>
        /// <returns>Url Sharepoint</returns>
        public string RetornaSiteUrlSharePoint()
        {
            string lsUrlServerSHP = "", lsSite = "", siteURL = "";
            var cfgSharePoint = politicaService.ListarConfiguracionSharePoint(null, "3");
            if (cfgSharePoint != null && cfgSharePoint.Result.Count > 1)
            {
                lsUrlServerSHP = cfgSharePoint.Result[0].Valor.ToString();
                lsSite = cfgSharePoint.Result[1].Valor.ToString();
            }
            siteURL = string.Format("{0}{1}", lsUrlServerSHP, lsSite);
            return siteURL;
        }
        /// <summary>
        /// Retorna el arreglo de bytes del documento SharePoint
        /// </summary>
        /// <param name="hayError">Cadena para ver si hay errores al retornar el documento.</param>
        /// <param name="idItem">Código del Archivo en el SharePoint</param>
        /// <param name="listName">Lista de biblioteca.</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> DescargaArchivoPorId(ref string hayError, long idItem, string listName)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            hayError = string.Empty;
            MemoryStream memorySt = null;
            string siteUrl = string.Empty;
            siteUrl = RetornaSiteUrlSharePoint();

            try
            {
                using (ClientContext context = new ClientContext(siteUrl))
                {
                    context.Credentials = RetornaCredencialesServer();

                    CamlQuery query = new CamlQuery();
                    query.ViewXml = string.Format(@"
                                                    <View Scope='Recursive'>
                                                        <Query>
                                                            <Where>
                                                                <Eq><FieldRef Name='ID'/><Value Type='Number'>{0}</Value></Eq>
                                                            </Where>
                                                            <RowLimit>1</RowLimit>
                                                        </Query>                                                                    
                                                    </View>", idItem);

                    List list = context.Web.Lists.GetByTitle(listName);
                    ListItemCollection listItems = list.GetItems(query);
                    context.Load(listItems);
                    context.ExecuteQuery();

                    if (listItems.Count == 1)
                    {
                        ListItem item = listItems.First();
                        Microsoft.SharePoint.Client.File file = item.File;
                        ClientResult<Stream> data = file.OpenBinaryStream();
                        
                        context.Load(file);
                        context.ExecuteQuery();
                        if (data != null)
                        {
                            using (memorySt = new MemoryStream())
                            {
                                data.Value.CopyTo(memorySt);
                            }
                        }
                    }
                    else
                    {
                        memorySt = null;
                    }
                    resultado.Result = memorySt.ToArray();
                }
            }
            catch (Exception ex)
            {
                hayError = ex.Message;
                RegistrarLogErrores(siteUrl, "SGC - Descargar Archivo", ex.Message);
                resultado.Result = null;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<SharePointService>(ex);
            }
            return resultado;
        }
        /// <summary>
        /// Registra un nuevo archivo en el servidor de SharePoint
        /// </summary>        
        /// <param name="hayError">variable que contiene el mensaje de error al registrar</param>
        /// <param name="listName">biblioteca de donde se encontrará el archivo</param>
        /// <param name="folderName">nombre de carpeta del archivo</param>
        /// <param name="fileName">nombre del archivo</param>
        /// <param name="myFile">stream del archivo</param>
        /// <param name="prmSiteURL">URL del servidor SharePoint</param>
        /// <param name="prmCredenciales">Credenciales de acceso al servidor SharePoint</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistraArchivoSharePoint(ref string hayError, string listName, string folderName, string fileName, MemoryStream myFile, string prmSiteURL = null, SharePointOnlineCredentials prmCredenciales = null)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            string siteUrl = string.Empty;
            if (string.IsNullOrEmpty(prmSiteURL))
            {
                siteUrl = RetornaSiteUrlSharePoint();
            }
            else
            {
                siteUrl = prmSiteURL;
            }
                
            try
            {
                using (ClientContext clientContext = new ClientContext(siteUrl))
                {
                    Web webSite = clientContext.Web;
                    
                    if (prmCredenciales == null)
                    {
                        clientContext.Credentials = RetornaCredencialesServer();
                    }
                    else
                    {
                        clientContext.Credentials = prmCredenciales;
                    }
                    
                    #region CreacionListaPrincipal en caso no exista
                    
                    List existeLista = null;
                    ListCollection lstCollection = clientContext.Web.Lists;
                    IEnumerable<List> misLitas = clientContext.LoadQuery(lstCollection.Include(list => list.Title));
                    clientContext.ExecuteQuery();

                    existeLista = misLitas.FirstOrDefault(lista => lista.Title.ToLower() == listName.ToLower());
                    if (existeLista == null)
                    {
                        ListCreationInformation creationInfo = new ListCreationInformation();
                        creationInfo.Title = listName;
                        creationInfo.TemplateType = (int)ListTemplateType.DocumentLibrary;
                        List listGeneral = webSite.Lists.Add(creationInfo);
                        listGeneral.Description = Pe.Stracon.SGC.Infraestructura.Core.Context.DatosConstantes.ArchivosContrato.DescripcionBibliotecaSHP;
                        listGeneral.Update();
                        clientContext.ExecuteQuery();
                    }

                    #endregion

                    #region crearDirectorio

                    var folder = CreateCarpeta(clientContext.Web, listName, folderName);

                    #endregion

                    #region listaDirectorio

                    List listaSitio = clientContext.Web.Lists.GetByTitle(listName);

                    clientContext.Load(listaSitio);
                    clientContext.Load(listaSitio.RootFolder);
                    clientContext.ExecuteQuery();
                    var serverRelativeURLFile = listaSitio.RootFolder.ServerRelativeUrl.ToString() + (string.IsNullOrEmpty(folderName) ? "" : "/" + folderName)
                                                + "/" + fileName;

                    #endregion

                    #region GenerarBytesSHP

                    Stream stmMyFile;
                    byte[] newFile = myFile.ToArray();
                    stmMyFile = new MemoryStream(newFile);

                    #endregion

                    #region CopiarStreamArchivo

                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext, serverRelativeURLFile, stmMyFile, true);

                    #endregion

                    #region Leer Nuevo Archivo

                    clientContext.Load(webSite);
                    clientContext.ExecuteQuery();
                    
                    Microsoft.SharePoint.Client.File getNewFile = webSite.GetFileByServerRelativeUrl(serverRelativeURLFile);
                    clientContext.Load(getNewFile);

                    #endregion

                    #region Cargar Datos

                    ListItem myItem = getNewFile.ListItemAllFields;

                    clientContext.Load(myItem);
                    clientContext.Load(myItem.File);
                    clientContext.ExecuteQuery();

                    resultado.Result = myItem.Id;

                    #endregion
                }
            }
            catch (Exception ex)
            {
                hayError = ex.Message;
                RegistrarLogErrores(siteUrl, "SGC - Registrar Archivo", ex.Message);
                resultado.Result = -1;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<SharePointService>(ex);

            }
            return resultado;
        }

        /// <summary>
        /// Método para eliminar los archivos del repositorio SharePoint.
        /// </summary>
        /// <param name="lstArchivosSHP">lista que contiene los ID de los archivos</param>
        /// <param name="listName">nombre del directorio dentro del cual se buscan los archivos</param>
        /// <param name="hayError">parámetro para capturar los errores del procedimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> EliminaArchivoSharePoint(List<int> lstArchivosSHP, string listName, ref string hayError)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            string siteUrl = string.Empty;
            siteUrl = RetornaSiteUrlSharePoint();

            try
            {
                Dictionary<string, string> termsArray = new Dictionary<string, string>();
                using (ClientContext clientContext = new ClientContext(siteUrl))
                {
                    clientContext.Credentials = RetornaCredencialesServer();
                    
                    foreach (int idFile in lstArchivosSHP)
                    {
                        CamlQuery query = new CamlQuery();
                        query.ViewXml = string.Format(@"
                                                    <View Scope='Recursive'>
                                                        <Query>
                                                            <Where>
                                                                <Eq><FieldRef Name='ID'/><Value Type='Number'>{0}</Value></Eq>
                                                            </Where>
                                                            <RowLimit>1</RowLimit>
                                                        </Query>
                                                    </View>", idFile);

                        List list = clientContext.Web.Lists.GetByTitle(listName);
                        ListItemCollection listItems = list.GetItems(query);
                        clientContext.Load(listItems);
                        clientContext.ExecuteQuery();
                        if (listItems.Count > 0)
                        {
                            ListItem item = listItems[0];
                            item.DeleteObject();
                        }
                    }
                    clientContext.ExecuteQuery();
                }
                resultado.Result = 1;
            }
            catch (Exception ex)
            {
                hayError = ex.Message;
                RegistrarLogErrores(siteUrl, "SGC - Eliminar Archivo", ex.Message);
                resultado.Result = -1;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<SharePointService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Crear una carpeta dentro de un directorio SharePoint.
        /// </summary>
        /// <param name="web">contexto cliente web sharepoint</param>
        /// <param name="listTitle">titutlo de la carpeta</param>
        /// <param name="fullFolderUrl">ruta del directorio a crear la carpeta</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        private Folder CreateCarpeta(Web web, string listTitle, string fullFolderUrl)
        {
            if (string.IsNullOrEmpty(fullFolderUrl))
            {
                throw new ArgumentNullException("fullFolderUrl");
            }
            List list = web.Lists.GetByTitle(listTitle);
            return CreateCarpetaInterna(web, list.RootFolder, fullFolderUrl);
        }

        /// <summary>
        /// Crear una carpeta dentro de un directorio SharePoint.
        /// </summary>
        /// <param name="web">contexto cliente web sharepoint</param>
        /// <param name="parentFolder">carpeta padrea que contendra carpeta actual</param>
        /// <param name="fullFolderUrl">ruta del directorio a crear la carpeta</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        private Folder CreateCarpetaInterna(Web web, Folder parentFolder, string fullFolderUrl)
        {
            string[] folderUrls = fullFolderUrl.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string folderUrl = folderUrls[0];
            Folder curFolder = parentFolder.Folders.Add(folderUrl);
            web.Context.Load(curFolder);
            web.Context.ExecuteQuery();

            if (folderUrls.Length > 1)
            {
                string subFolderUrl = string.Join("/", folderUrls, 1, folderUrls.Length - 1);
                return CreateCarpetaInterna(web, curFolder, subFolderUrl);
            }
            return curFolder;
        }

        /// <summary>
        /// Permite registrar los errores al interactura con SharePoint
        /// </summary>
        /// <param name="siteUrl"></param>
        /// <param name="opcion"></param>
        /// <param name="mensajeError"></param>
        private void RegistrarLogErrores(string siteUrl, string opcion, string mensajeError)
        {
            using (ClientContext clientContext = new ClientContext(siteUrl))
            {
                Web webSite = clientContext.Web;
                clientContext.Credentials = RetornaCredencialesServer();

                List list = clientContext.Web.Lists.GetByTitle("LogErrores");

                ListItemCreationInformation itemCreateInfo = new ListItemCreationInformation();

                ListItem listItem = list.AddItem(itemCreateInfo);
                listItem["Title"] = opcion + " : " + mensajeError;
                listItem.Update();

                clientContext.Web.Context.ExecuteQuery();
            }
        }
    }
}

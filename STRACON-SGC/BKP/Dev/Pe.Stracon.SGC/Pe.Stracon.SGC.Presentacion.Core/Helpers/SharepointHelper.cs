using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using Microsoft.SharePoint.Client;

namespace Pe.Stracon.SGC.Presentacion.Core.Helpers
{
    /// <summary>
    /// Clase para Interacción con un servidor SharePoint Online
    /// </summary>
    public class SharepointHelper
    {
        private SharePointOnlineCredentials credentialsSHP;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nameUser"></param>
        /// <param name="namePassword"></param>
        /// <param name="nameDomain"></param>
        public SharepointHelper(string nameUser, string namePassword, string nameDomain)
        {
            var securepassword = new SecureString();

            foreach (char c in namePassword)
            {
                securepassword.AppendChar(c);
            }

            credentialsSHP = new SharePointOnlineCredentials(nameUser, securepassword);
        }

        /// <summary>
        /// Permite registrar archivos en SharePoint
        /// </summary>
        /// <param name="fileSHP"></param>
        /// <param name="asError"></param>
        /// <returns></returns>
        public int RegistraFileSharePointSGC(SharepointEN fileSHP, ref string asError)
        {
            int NumberNewFile = -1;
            asError = string.Empty;
            try
            {
                using (ClientContext clientContext = new ClientContext(fileSHP.siteUrlParam))
                {
                    Web webSite = clientContext.Web;
                    clientContext.Credentials = credentialsSHP;

                    #region CreacionListaPrincipal en caso no Exista
                    
                    List existeLista = null;
                    ListCollection lstCollection = clientContext.Web.Lists;
                    IEnumerable<List> misLitas = clientContext.LoadQuery(lstCollection.Include(list => list.Title));
                    clientContext.ExecuteQuery();

                    existeLista = misLitas.FirstOrDefault(lista => lista.Title.ToLower() == fileSHP.listName.ToLower());

                    if (existeLista == null)
                    {
                        ListCreationInformation creationInfo = new ListCreationInformation();
                        creationInfo.Title = fileSHP.listName;
                        creationInfo.TemplateType = (int)ListTemplateType.DocumentLibrary;
                        List listGeneral = webSite.Lists.Add(creationInfo);
                        listGeneral.Description = Pe.Stracon.SGC.Infraestructura.Core.Context.DatosConstantes.ArchivosContrato.DescripcionBibliotecaSHP;
                        listGeneral.Update();
                        clientContext.ExecuteQuery();
                    }

                    #endregion

                    #region listaDirectorio

                    #region crearDirectorio

                    var folder = CreateCarpeta(clientContext.Web, fileSHP.listName, fileSHP.folderName);

                    #endregion

                    List listaSitio = clientContext.Web.Lists.GetByTitle(fileSHP.listName);

                    clientContext.Load(listaSitio);
                    clientContext.Load(listaSitio.RootFolder);
                    clientContext.ExecuteQuery();
                    var serverRelativeURLFile = listaSitio.RootFolder.ServerRelativeUrl.ToString() + (string.IsNullOrEmpty(fileSHP.folderName) ? "" : "/" + fileSHP.folderName)
                                                + "/" + fileSHP.fileName;

                    #endregion

                    #region GenerarBytesSHP

                    Stream stmMyFile;
                    byte[] newFile = fileSHP.msfile.ToArray();
                    stmMyFile = new MemoryStream(newFile);

                    #endregion

                    #region Copiar Stream Archivo

                    Microsoft.SharePoint.Client.File.SaveBinaryDirect(clientContext, serverRelativeURLFile, stmMyFile, true);

                    #endregion

                    #region Leer Nuevo Archivo

                    clientContext.Load(webSite);
                    clientContext.ExecuteQuery();
                    
                    Microsoft.SharePoint.Client.File getNewFile = webSite.GetFileByServerRelativeUrl(serverRelativeURLFile);
                    clientContext.Load(getNewFile);

                    #endregion

                    #region CargarDatos

                    ListItem myItem = getNewFile.ListItemAllFields;

                    clientContext.Load(myItem);
                    clientContext.Load(myItem.File);
                    clientContext.ExecuteQuery();

                    NumberNewFile = myItem.Id;

                    #endregion
                }
            }
            catch (Exception ex)
            {
                RegistrarLogErrores(fileSHP.siteUrlParam, "SGC - Registrar Archivos", ex.Message);
                asError = ex.Message;
            }
            return NumberNewFile;
        }

        /// <summary>
        /// Permite descargar un archivo
        /// </summary>
        /// <param name="hayError"></param>
        /// <param name="idItem"></param>
        /// <param name="siteUrl"></param>
        /// <param name="listName"></param>
        /// <returns></returns>
        public MemoryStream DownloadFileById(ref string hayError, long idItem, string siteUrl, string listName)
        {
            hayError = string.Empty;
            MemoryStream memorySt = null;
            string lsRetorno = string.Empty;
            try
            {
                using (ClientContext context = new ClientContext(siteUrl))
                {
                    context.Credentials = credentialsSHP;

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
                }
            }
            catch (Exception ex)
            {
                RegistrarLogErrores(siteUrl, "SGC - Descargar Archivos", ex.Message);
                hayError = ex.Message;
            }
            return memorySt;
        }

        /// <summary>
        /// Permite eliminar archivos
        /// </summary>
        /// <param name="archivos"></param>
        /// <param name="hayError"></param>
        public void DeleteListFiles(List<SharepointEN> archivos, ref string hayError)
        {
            try
            {
                Dictionary<string, string> termsArray = new Dictionary<string, string>();
                using (ClientContext clientContext = new ClientContext(archivos.First().siteUrlParam))
                {
                    clientContext.Credentials = credentialsSHP;

                    foreach (SharepointEN _sharepointEN in archivos)
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
                        </View>", _sharepointEN.idItem);

                        List list = clientContext.Web.Lists.GetByTitle(_sharepointEN.listName);
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
            }
            catch (Exception ex)
            {
                RegistrarLogErrores(archivos.First().siteUrlParam, "SGC - Eliminar Archivos", ex.Message);
                hayError = ex.Message;
            }
        }

        /// <summary>
        /// Crear carpeta en Biblioteca
        /// </summary>
        /// <param name="web"></param>
        /// <param name="listTitle"></param>
        /// <param name="fullFolderUrl"></param>
        /// <returns></returns>
        public static Folder CreateCarpeta(Web web, string listTitle, string fullFolderUrl)
        {
            if (string.IsNullOrEmpty(fullFolderUrl))
            {
                throw new ArgumentNullException("fullFolderUrl");
            }
            List list = web.Lists.GetByTitle(listTitle);
            return CreateCarpetaInterna(web, list.RootFolder, fullFolderUrl);
        }

        /// <summary>
        /// Crear una carpeta interna dentro de otra carpeta
        /// </summary>
        /// <param name="web"></param>
        /// <param name="parentFolder"></param>
        /// <param name="fullFolderUrl"></param>
        /// <returns></returns>
        private static Folder CreateCarpetaInterna(Web web, Folder parentFolder, string fullFolderUrl)
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
                clientContext.Credentials = credentialsSHP;

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

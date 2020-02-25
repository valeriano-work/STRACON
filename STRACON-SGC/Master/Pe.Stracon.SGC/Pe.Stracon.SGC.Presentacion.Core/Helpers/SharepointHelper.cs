using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.SharePoint.Client;

namespace Pe.Stracon.SGC.Presentacion.Core.Helpers
{
    /// <summary>
    /// Clase para Interacción con un servidor SharePoint
    /// GRC: 15-05-2015
    /// </summary>
    public class SharepointHelper
    {

        private NetworkCredential credentialsSHP;

        //Constructor
        public SharepointHelper(string nameUser, string namePassword, string nameDomain)
        {
            /*Obtener credenciales*/
            credentialsSHP = new NetworkCredential(nameUser, namePassword, nameDomain);
        }

        public int RegistraFileSharePointSCC(SharepointEN fileSHP, ref string asError)
        {
            int NumberNewFile = -1;
            asError = string.Empty;
            try
            {
                using (ClientContext clientContext = new ClientContext(fileSHP.siteUrlParam))
                {
                    Web webSite = clientContext.Web;
                    #region Logeo
                    clientContext.Credentials = credentialsSHP;
                    #endregion

                    #region CreacionListaPrincipal
                    /*-------------------Verificamos si la Lista ya existe.GRC.---------------------*/
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

                    #region LeerNuevoArchivo
                    clientContext.Load(webSite);
                    clientContext.ExecuteQuery();
                    // cargamos el archivo guardado
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
                asError = ex.Message;
            }
            return NumberNewFile;
        }

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
                                <Eq><FieldRef Name='ID'/><Value Type='Number'>" + idItem + @"</Value></Eq>
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
                        ////Load the Stream data for the file
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
                hayError = ex.Message;
            }
            return memorySt;
        }

        public void DeleteListFiles(List<SharepointEN> archivos, ref string hayError)
        {
            try
            {
                Dictionary<string, string> termsArray = new Dictionary<string, string>();
                using (ClientContext clientContext = new ClientContext(archivos.First().siteUrlParam))
                {
                    #region Logueo
                    clientContext.Credentials = credentialsSHP;
                    #endregion
                    foreach (SharepointEN _sharepointEN in archivos)
                    {
                        CamlQuery query = new CamlQuery();
                        query.ViewXml = string.Format(@"
                        <View Scope='Recursive'>
                            <Query>
                                <Where>
                                    <Eq><FieldRef Name='ID'/><Value Type='Number'>" + _sharepointEN.idItem + @"</Value></Eq>
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
                hayError = ex.Message;
            }
        }

        public static Folder CreateCarpeta(Web web, string listTitle, string fullFolderUrl)
        {
            if (string.IsNullOrEmpty(fullFolderUrl))
            {
                throw new ArgumentNullException("fullFolderUrl");
            }
            List list = web.Lists.GetByTitle(listTitle);
            return CreateCarpetaInterna(web, list.RootFolder, fullFolderUrl);
        }

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

        public static Folder GetFolder(Web web, string fullFolderUrl)
        {
            if (string.IsNullOrEmpty(fullFolderUrl))
            {
                throw new ArgumentNullException("fullFolderUrl");
            }

            if (!web.IsPropertyAvailable("ServerRelativeUrl"))
            {
                web.Context.Load(web, w => w.ServerRelativeUrl);
                web.Context.ExecuteQuery();
            }
            var folder = web.GetFolderByServerRelativeUrl(web.ServerRelativeUrl + fullFolderUrl);
            web.Context.Load(folder);
            web.Context.ExecuteQuery();
            return folder;
        }

    }

    public class SharepointEN
    {
        public int idItem { get; set; }
        public string listName { get; set; }
        public MemoryStream msfile { get; set; }
        public string fileName { get; set; }
        public string fileNameNew { get; set; }
        public string urlContentFile { get; set; }
        public string siteUrlParam { get; set; }

        public string siteBiblioteca { get; set; }
        public string folderName { get; set; }
        public string version { get; set; }
        public string serverRelativeURLFile { get; set; }
        public bool replace { get; set; }
    }
}

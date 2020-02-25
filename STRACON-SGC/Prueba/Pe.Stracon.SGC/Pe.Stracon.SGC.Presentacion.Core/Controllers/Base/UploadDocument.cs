using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Web;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Json;
using System.Web.Configuration;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Base
{
    public class UploadDocument : GenericController
    {
        public void UploadDocuments()
        {
            CargarArchivoViewModel ObjCargarArchivo = new CargarArchivoViewModel();
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase item = Request.Files[i];

                ObjCargarArchivo.NombreArchivo = System.IO.Path.GetFileName(item.FileName);
                ObjCargarArchivo.Extension = System.IO.Path.GetExtension(item.FileName);
                ObjCargarArchivo.Tamaño = item.ContentLength;
                byte[] fileData = null;
                using (var binaryReader = new BinaryReader(Request.Files[i].InputStream))
                {
                    fileData = binaryReader.ReadBytes(Request.Files[i].ContentLength);
                }
                ObjCargarArchivo.ArchivoBase64 = Convert.ToBase64String(fileData);
            }
            Response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(ObjCargarArchivo));
        }

        public void ProcessRequest(HttpContext context)
        {

            try
            {
                string strFileNameMoment = string.Empty;
                //object objPath = string.Empty;
                //string rutaLectura = string.Empty;
                string pathTemp = string.Empty;

                List<string> listaExtencionValida = new List<string>();

                pathTemp = WebConfigurationManager.AppSettings["CarpetaAdjuntosFileServer"];
                pathTemp = Server.MapPath(pathTemp);

                if (!Directory.Exists(pathTemp))
                    Directory.CreateDirectory(pathTemp);

                bool okExtensionDoc = true;
                string strExtension = Path.GetExtension(context.Request.Files[0].FileName).ToLower();

                if (!okExtensionDoc)
                {
                    string mensajeExtensionValida = string.Empty;
                    if (listaExtencionValida != null && listaExtencionValida.Count > 0)
                    {
                        mensajeExtensionValida = " (Tipos de documentos validos: ";
                        foreach (var extencion in listaExtencionValida)
                        {
                            mensajeExtensionValida += extencion + ", ";
                        }
                        mensajeExtensionValida = mensajeExtensionValida.Substring(0, mensajeExtensionValida.Length - 2);
                        mensajeExtensionValida += ")";
                    }
                    string mensaje = string.Format("No se permite la extensión del archivo que se desea adjuntar{0}.", mensajeExtensionValida);
                    throw new Exception(mensaje);
                }
                string nameFile = Path.GetFileNameWithoutExtension(context.Request.Files[0].FileName) + strExtension;

                string strSaveLocation = string.Format("{0}{1}", pathTemp, strFileNameMoment);


                var objPath = new
                {
                    pathFile = strSaveLocation,
                    nameFile = nameFile,
                    nameFileMoment = strFileNameMoment,
                    estado = true
                };
                System.IO.FileInfo item = new System.IO.FileInfo(strSaveLocation);
                if (!item.Exists)
                    context.Request.Files[0].SaveAs(strSaveLocation);

                context.Response.ContentType = "text/plain";
                context.Response.Write(JsonSerializer.ToJson(objPath));
            }
            catch (Exception ex)
            {
                var objPath = new
                {
                    pathFile = string.Empty,
                    nameFile = string.Empty,
                    message = ex.Message,
                    estado = false
                };
                context.Response.ContentType = "text/plain";
                context.Response.Write(JsonSerializer.ToJson(objPath));
            }


        }
    }

}

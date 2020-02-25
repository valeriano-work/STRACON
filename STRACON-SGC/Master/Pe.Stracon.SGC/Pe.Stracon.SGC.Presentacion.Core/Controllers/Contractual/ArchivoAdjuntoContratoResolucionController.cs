using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ArchivoAdjuntoContratoResolucion;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System;
using System.IO;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.GyM.Security.Web.Filters;
using Pe.Stracon.SGC.Cross.Core.Util;
using Pe.GyM.Security.Web.Session;
using Pe.GyM.Security.Account.Model;
using Pe.Stracon.SGC.Aplicacion.Core.Base;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Base
{
    /// <summary>
    /// Controladora de Carga de Archivo adjunto
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150318
    /// Modificación:
    /// </remarks>
    public class ArchivoAdjuntoContratoResolucionController : GenericController
    {
        /// <summary>
        /// Servicio de manejo de contrato
        /// </summary>
        public IContratoService contratoService { get; set; }

        /// <summary>
        /// Interface para obtener el entorno de la aplicación.
        /// </summary>
        public IEntornoActualAplicacion entornoAplicacion { get; set; }

        #region Vistas Parciales
        /// <summary>
        /// Muestra la vista de carga de documentos adjuntos
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Vista de Formulario de carga de adjuntos</returns>
        public ActionResult FormularioCargaAdjuntoResolucion(ListadoContratoRequest request, Control controles)
        {
            ArchivoAdjuntoContratoResolucionFormulario modelo = new ArchivoAdjuntoContratoResolucionFormulario();
            modelo.Contrato = contratoService.BuscarListadoContrato(request).Result.FirstOrDefault();
            modelo.UsuarioSession = entornoAplicacion.UsuarioSession;
            modelo.ControlPermisos = controles;
            return PartialView(modelo);
        }
        #endregion
        #region Json
        /// <summary>
        /// Permite buscar archivos adjuntos al contrato
        /// </summary>
        /// <returns>Vista de Formulario de carga</returns>
        public JsonResult BuscarArchivoAdjuntoResolucion(ContratoDocumentoAdjuntoResolucionRequest request)
        {
            var resultado = contratoService.BuscarContratoDocumentoAdjuntoResolucion(request);
            return Json(resultado);
        }
        /// <summary>
        /// Muestra el contenido del Contrato, dependiendo de su versión.
        /// </summary>
        /// <param name="CodigoDeContrato">Código del Contrato</param>
        /// <returns>Contenido del Contrato</returns>
        public ActionResult DescargarArchivoAdjuntoResolucion(ContratoDocumentoAdjuntoResolucionRequest request)
        {
            //string NombreFile = string.Empty;
            var FileContrato = contratoService.ObtenerArchivoAdjuntoResolucion(request);
            MemoryStream memorySt = null;
            if (FileContrato.Result != null)
            {
                memorySt = new MemoryStream((byte[])FileContrato.Result.ContenidoArchivo);
            }

            if (memorySt != null)
            {
                byte[] byteArchivo = memorySt.ToArray();
                Response.Clear();
                Response.AddHeader("Content-Disposition", string.Format("attachement; filename={0}", FileContrato.Result.NombreArchivo));
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(byteArchivo);
                Response.End();
            }
            else
            {
                return null;
            }
            return RedirectToAction("Reporte");
        }
        /// <summary>
        /// Registra archivos adjuntos al contrato
        /// </summary>
        /// <returns>Vista de Formulario de carga</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarArchivoAdjuntoResolucion()
        {
            HttpPostedFileBase file = Request.Files.Count > 0 ? Request.Files[0] : null;

            var codigoContrato = new Guid(Request["CodigoContrato"].ToString());
            var nombreArchivo = Request["NombreArchivo"].ToString();
            var cadena = Request["FechaResolucionString"].ToString();
            //var fechita = Convert.ToDateTime(cadena);
           
            //DateTime fechaResolucion = Convert.ToDateTime(Request["FechaResolucion"]);
            int ValidacionResolucion = Convert.ToInt32(Request["ValidacionResolucion"]);

            var request = new ContratoDocumentoAdjuntoResolucionRequest();
            request.ValidacionResolucion = ValidacionResolucion;
            request.FechaResolucionString = cadena;
            request.FechaFinVigenciaString = Request["FechaFinVigenciaString"].ToString();
            request.CodigoContrato = codigoContrato;
            request.CodigoUnidadOperativa = contratoService.BuscarListadoContrato(new ListadoContratoRequest()
            {
                CodigoContrato = request.CodigoContrato.ToString()
            }).Result.FirstOrDefault().CodigoUnidadOperativa;
            request.NombreArchivo = nombreArchivo;

            using (MemoryStream ms = new MemoryStream())
            {
                file.InputStream.CopyTo(ms);
                request.ArchivoAdjunto = ms.ToArray();
            }

            var resultado = contratoService.RegistrarContratoDocumentoAdjuntoResolucion(request);
            return Json(resultado);
        }
        /// <summary>
        /// Elimina archivos adjuntos al contrato
        /// </summary>
        /// <returns>Vista de Formulario de carga</returns>
        [AuthorizeEliminarFilter]
        public JsonResult EliminarArchivoAdjuntoResolucion(ContratoDocumentoAdjuntoResolucionRequest request)
        {
            var resultado = contratoService.EliminarContratoDocumentoAdjuntoResolucion(request);
            return Json(resultado);
        }
        #endregion
    }
}

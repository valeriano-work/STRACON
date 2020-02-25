using System;
using System.Web.Mvc;
using System.IO;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.SolicitudRevisionContrato;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ArchivoAdjuntoContrato;
using Pe.Stracon.SGC.Presentacion.Core.Helpers;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    public class SolicitudRevisionContratoController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Servicio de Contratos
        /// </summary>
        public IContratoService contratoService { get; set; }
        /// <summary>
        /// Servicio de unidad operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }
        /// <summary>
        /// Servicio de gestión de archivos en SharePoint
        /// </summary>
        public ISharePointService sharePointService { get; set; }
        #endregion

        #region Vistas
        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var listaUOs = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa()
            {
                Nivel = DatosConstantes.Nivel.Proyecto
            }
                ).Result;

            SolicitudRevisionContratoBusqueda modelo = new SolicitudRevisionContratoBusqueda(listaUOs);
            return View(modelo);
        }

        #endregion

        #region Vistas Parciales
        
        /// <summary>
        /// Muestra la vista de carga de documentos adjuntos
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Vista de Formulario de carga de adjuntos</returns>
        public ActionResult FormularioSolicitudRevisionContratoAdjuntos(ListadoContratoRequest request)
        {
            ArchivoAdjuntoContratoFormulario modelo = new ArchivoAdjuntoContratoFormulario();
            modelo.Contrato = contratoService.BuscarListadoContrato(request).Result.FirstOrDefault();
            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra la vista Formulario Solicitud de Revisión de Contrato Aprobar
        /// </summary>
        /// <returns>Vista Parcial Formulario Solicitud Revisión Contrato Aprobar</returns>
        public ActionResult FormularioSolicitudRevisionContratoAprobar(Guid codigoContrato)
        {
            ViewBag.CodigoContrato = codigoContrato;        

            var datoContrato = contratoService.BuscarListadoContrato(new ListadoContratoRequest()
            {
                CodigoContrato = codigoContrato.ToString()
            }).Result.FirstOrDefault();

            var dcTosContrato = contratoService.DocumentosPorContrato(codigoContrato);
         
            ViewBag.RutaPrimerFile = dcTosContrato.Result[0].Contenido;

            if (dcTosContrato.Result.Count > 1)
            {
                ViewBag.RutaSegundoFile = dcTosContrato.Result[1].Contenido;
            }
            else
            {
                ViewBag.RutaSegundoFile = string.Empty;
            }

            ViewBag.MotivoSolicitud = datoContrato.ComentarioModificacion;

            return PartialView();
        }

        /// <summary>
        /// Muestra el popup de para ingresar el motivo del rechazo de revisión
        /// </summary>
        /// <returns>Vista Parcial</returns>
        public ActionResult FormularioRevisionRechazar(Guid codigoContrato)
        {
            ViewBag.codigoContrato = codigoContrato;
            return PartialView();
        }


        #endregion


        #region Json
        /// <summary>
        /// Buscar Bandeja de Solicitud de Revisión de Contrato
        /// </summary>
        /// <returns>Lista con el resultado de la operación</returns>
        public JsonResult BuscarBandejaSolicitudRevisionContrato(ContratoRequest objRqst)
        {
            var resultado = contratoService.ListaBandejaRevisionContratos(objRqst);
            return Json(resultado);
        }
        /// <summary>
        /// Registrar Respuesta de Contrato por Solicitud
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        public JsonResult RegistrarRespuestaContrato(ContratoRequest objRqst)
        {
            var result = contratoService.RegistraRespuestaContrato(objRqst);
            return Json(result);
        }

        /// <summary>
        /// Permite buscar archivos adjuntos al contrato
        /// </summary>
        /// <returns>Vista de Formulario de carga</returns>
        public JsonResult BuscarArchivoAdjunto(ContratoDocumentoAdjuntoRequest request)
        {
            var resultado = contratoService.BuscarContratoDocumentoAdjunto(request);
            return Json(resultado);
        }

        #endregion

        /// <summary>
        /// Muestra el contenido del Contrato, dependiendo de su versión.
        /// </summary>
        /// <param name="request">Datos del Contrato</param>
        /// <returns>Contenido del Contrato</returns>
        public ActionResult DescargarArchivoAdjunto(ContratoDocumentoAdjuntoRequest request)
        {
            var FileContrato = contratoService.ObtenerArchivoAdjunto(request);
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
    }
}

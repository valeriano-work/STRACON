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
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.SolicitudModificacionContrato;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ArchivoAdjuntoContrato;
using Pe.Stracon.SGC.Presentacion.Core.Helpers;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    public class SolicitudModificacionContratoController : GenericController
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
            var listaUOs = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { 
                Nivel=DatosConstantes.Nivel.Proyecto }
                ).Result;
            SolicitudModificacionContratoBusqueda modelo = new SolicitudModificacionContratoBusqueda(listaUOs);
            return View(modelo);
        }
        
        #endregion

        #region Vistas Parciales
        /// <summary>
        /// Muestra la vista Formulario Solicitud de Modificacion de Contrato Autorizar
        /// </summary>
        /// <returns>Vista Parcial Formulario Solicitud de Modificación de Contrato Autorizar</returns>
        public ActionResult FormularioSolicitudModificacionContratoAutorizar(Guid codigoDeContrato)
        {
            string comentario, respuesta, contenido = string.Empty;
            var resultado = contratoService.ObtieneContratoPorID(codigoDeContrato);
            var doctos = contratoService.DocumentosPorContrato(codigoDeContrato);
            if (resultado.Result != null)
            {
                comentario = resultado.Result.ComentarioModificacion;
                respuesta = resultado.Result.RespuestaModificacion;
                if (doctos.Result != null && doctos.Result.Count>0)
                {
                    contenido = doctos.Result[0].Contenido;
                }
            }
            else
            {
                comentario = string.Empty;
                respuesta = string.Empty;
            }
            ViewBag.CodigoContrato = codigoDeContrato;
            ViewBag.Comentario = comentario;
            ViewBag.Respuesta = respuesta;
            ViewBag.ContenidoContrato = contenido;
            return PartialView();
        }
        /// <summary>
        /// Muestra la vista Formulario Solicitud de Modificacion de Contrato Aprobar
        /// </summary>
        /// <returns>Vista Parcial Formulario Solicitud Modificación Contrato Aprobar</returns>
        public ActionResult FormularioSolicitudModificacionContratoAprobar(Guid codigoDeContrato)
        {
            ViewBag.CodigoContrato = codigoDeContrato;
            //string rutaPrimerFile = string.Empty, rutaSegundoFile = string.Empty;

            var datoContrato = contratoService.BuscarListadoContrato(new ListadoContratoRequest()
            {
                CodigoContrato = codigoDeContrato.ToString()
            }).Result.FirstOrDefault();

            var dcTosContrato = contratoService.DocumentosPorContrato(codigoDeContrato);
            //if (dcTosContrato.Result != null && dcTosContrato.Result.Count>0)
            //{
            //    rutaPrimerFile = dcTosContrato.Result[0].Contenido;
            //    if (dcTosContrato.Result.Count > 1)
            //    {
            //        rutaSegundoFile = dcTosContrato.Result[1].Contenido;
            //    }
            //}
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
        /// Muestra el popup de para ingresar el motivo de eliminación del contrato
        /// </summary>
        /// <returns>Vista Parcial</returns>
        public ActionResult FormularioContratoRechazar(Guid codigoContrato)
        {
            ViewBag.codigoContrato = codigoContrato;
            return PartialView();
        }


        /// <summary>
        /// Muestra la vista de carga de documentos adjuntos
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Vista de Formulario de carga de adjuntos</returns>
        public ActionResult FormularioSolicitudModificacionContratoAdjuntos(ListadoContratoRequest request)
        {
            ArchivoAdjuntoContratoFormulario modelo = new ArchivoAdjuntoContratoFormulario();
            modelo.Contrato = contratoService.BuscarListadoContrato(request).Result.FirstOrDefault();
            return PartialView(modelo);
        }

        #endregion

        #region Json
        /// <summary>
        /// Busca Bandeja Plantilla Contrato
        /// </summary>
        /// <returns>Lista con el resultado de la operación</returns>
        public JsonResult BuscarBandejaSolicitudModificacionContrato(ContratoRequest objRqst)
        {
            var resultado = contratoService.ListaBandejaSolicitudContratos(objRqst);
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
        /// Busca Bandeja Plantilla Contrato Parrafo
        /// </summary>
        /// <returns>Lista con el resultado de la operación</returns>
        JsonResult BuscarBandejaPlantillaContratoParrafo()
        {
            return null;
        }
        /// <summary>
        /// Registrar Plantilla Contrato Parrafo
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        JsonResult RegistrarPlantillaContratoParrafo()
        {
            return null;
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

        #region FilesSharePoint
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodigoArchivo"></param>
        /// <param name="NombreLista"></param>
        /// <param name="NombreArchivo"></param>
        /// <returns></returns>
        public ActionResult DescargarArchivoSharePoint(int CodigoArchivo, string NombreLista, string NombreArchivo)
        {
            string userShp = "", passWord = "", dominio = "", lsUrlServerSHP = "", lsSite = "", siteURL = "";
            string hayError = "";

            #region DireccionServidorSharePoint
            var cfgSharePoint = politicaService.ListarConfiguracionSharePoint(null, "3");
            lsUrlServerSHP = cfgSharePoint.Result[0].Valor.ToString();
            lsSite = cfgSharePoint.Result[1].Valor.ToString();
            siteURL = string.Format("{0}{1}", lsUrlServerSHP, lsSite);
            #endregion

            var crdSharePoint = politicaService.ListarCredencialesAccesoDinamico();

            userShp = crdSharePoint.Result[0].Atributo3;
            passWord = crdSharePoint.Result[0].Atributo4;
            dominio = crdSharePoint.Result[0].Atributo5;

            SharepointHelper shp = new SharepointHelper(userShp, passWord, dominio);
            MemoryStream msFile = shp.DownloadFileById(ref hayError, CodigoArchivo, siteURL, NombreLista);

            /*Ruta para grabar el archivo*/
            string rutaTemp = Path.GetTempPath();

            System.IO.File.WriteAllBytes(rutaTemp, msFile.ToArray() );

            //if (msFile != null)
            //{
            //    byte[] byteArchivo = msFile.ToArray();
            //    Response.Clear();
            //    Response.AddHeader("Content-Disposition", "attachement; filename=" + NombreArchivo);
            //    Response.ContentType = "application/octet-stream";
            //    Response.BinaryWrite(byteArchivo);
            //    Response.End();
            //}
            //else
            //{
            //    return null;
            //}
            return RedirectToAction("Reporte");
        }


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

        #endregion
    }
}
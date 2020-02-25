using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteContratoPorEstadio;
using System.Web.Mvc;
using System.Linq;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Contractual;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Reporte de Contrato por Estadio
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150630 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ReporteContratoPorEstadioController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Servicio de manejo de Unidad Operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }
        /// <summary>
        /// Servicio Flujo Aprobacion
        /// </summary>
        public IFlujoAprobacionService flujoAprobacionService { get; set; }
        /// <summary>
        /// Interfaz para el manejo de auditoría
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }
        #endregion

        #region Vistas
        /// <summary>
        /// Muestra la vista Index 
        /// </summary> 
        /// <returns>Vista Index</returns>
        public ActionResult Index(ReporteContratoPorEstadioRequest filtro)
        {
            if (filtro != null)
            {
                TempData["DataReport"] = CrearModelo(filtro);
            }

            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto });
            var tipoServicio = politicaService.ListarTipoContrato();
            var tipoRequerimiento = politicaService.ListarTipoServicio();
            var formaEdicion = politicaService.ListarFormaContrato();

            var modelo = new ReporteContratoPorEstadioBusqueda(unidadOperativa.Result, tipoServicio.Result, tipoRequerimiento.Result, formaEdicion.Result);
            return View(modelo);
        }
        #endregion

        /// <summary>
        /// Asigna los parámetros necesarios para el reporte
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda para el reporte</param>
        /// <returns>Modelo con parámetros para el reporte</returns>
        private ReporteViewModel CrearModelo(ReporteContratoPorEstadioRequest filtro)
        {
            var reporteModel = new ReporteViewModel();
            reporteModel.RutaReporte += DatosConstantes.ReporteNombreArchivo.ReporteContratoPorEstadio;

            reporteModel.AgregarParametro("CODIGO_LENGUAJE", DatosConstantes.Iternacionalizacion.ES_PE);
            reporteModel.AgregarParametro("USUARIO", entornoActualAplicacion.UsuarioSession);
            reporteModel.AgregarParametro("NOMBRE_REPORTE", ReporteContratoPorEstadioResource.EtiquetaTitulo.ToUpper());
            reporteModel.AgregarParametro("FORMATO_FECHA_CORTA", DatosConstantes.Formato.FormatoFecha);
            reporteModel.AgregarParametro("FORMATO_HORA_CORTA", DatosConstantes.Formato.FormatoHora);
            reporteModel.AgregarParametro("FORMATO_NUMERO_ENTERO", DatosConstantes.Formato.FormatoNumeroEntero);
            reporteModel.AgregarParametro("FORMATO_NUMERO_DECIMAL", DatosConstantes.Formato.FormatoNumeroDecimal);
            reporteModel.AgregarParametro("PIE_REPORTE", string.Format(GenericoResource.EtiquetaFinReporte, ReporteContratoPorEstadioResource.EtiquetaTitulo.ToUpper()));
            reporteModel.AgregarParametro("FECHA_INICIO", filtro.GeneradosDesdeString);
            reporteModel.AgregarParametro("FECHA_FIN", filtro.GeneradosHastaString);
            reporteModel.AgregarParametro("CODIGO_FLUJO_APROBACION_ESTADIO", filtro.CodigoFlujoAprobacionEstadio);
            reporteModel.AgregarParametro("NOMBRE_UNIDAD_OPERATIVA", filtro.NombreUnidadOperativa);
            reporteModel.AgregarParametro("DESCRIPCION_TIPO_SERVICIO", filtro.DescripcionTipoServicio);
            reporteModel.AgregarParametro("DESCRIPCION_TIPO_REQUERIMIENTO", filtro.DescripcionTipoRequerimiento);
            reporteModel.AgregarParametro("INDICADOR_MONTO_MINIMO", filtro.IndicadorMontoMinimo);
            reporteModel.AgregarParametro("DESCRIPCION_ESTADIO", filtro.DescripcionFlujoAprobacionEstadio);

            return reporteModel;
        }

        #region Json
        /// <summary>
        /// Obtiene el Flujo de Aprobación Estadio
        /// </summary>
        /// <param name="data">Filtro de Búsqueda</param>
        /// <returns>Registro con el Flujo de Aprobación de Estadio</returns>
        public JsonResult BuscarEstadio(FlujoAprobacionRequest data)
        {
            var flujoAprobacion = flujoAprobacionService.BuscarBandejaFlujoAprobacion(data);
            if (flujoAprobacion != null && flujoAprobacion.Result.Count > 0)
            {
                var estadio = flujoAprobacionService.BuscarBandejaFlujoAprobacionEstadio(null, flujoAprobacion.Result.FirstOrDefault().CodigoFlujoAprobacion);
                return Json(estadio);
            }
            else
            {
                return Json(null);
            }
        }
        #endregion
    }
}

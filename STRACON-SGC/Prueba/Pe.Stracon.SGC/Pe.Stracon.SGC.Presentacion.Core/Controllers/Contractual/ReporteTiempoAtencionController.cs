using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteTiempoAtencion;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Contractual;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Reporte de Tiempo de Atención
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150624    </br>
    /// Modificación:                   </br>
    /// </remarks>
    public class ReporteTiempoAtencionController : GenericController
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
        /// Interfaz para el manejo de auditoría
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }
        #endregion

        #region Vistas
        /// <summary>
        /// Muestra la vista Index
        /// </summary> 
        /// <returns>Vista Index</returns>
        public ActionResult Index(ReporteTiempoAtencionRequest filtro)
        {
            if (filtro != null)
            {
                TempData["DataReport"] = CrearModelo(filtro);
            }

            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto });
            var reporteTiempoAtencion = new ReporteTiempoAtencionResponse();
            reporteTiempoAtencion.CodigoUnidadOperativa = filtro.CodigoUnidadOperativa;
            reporteTiempoAtencion.FechaConsultaDesdeString = filtro.FechaConsultaDesdeString;
            reporteTiempoAtencion.FechaConsultaHastaString = filtro.FechaConsultaHastaString;
            reporteTiempoAtencion.NumeroContrato = filtro.NumeroContrato;

            var modelo = new ReporteTiempoAtencionBusqueda(unidadOperativa.Result, reporteTiempoAtencion);
            return View(modelo);
        }
        #endregion

        /// <summary>
        /// Asigna los parámetros necesarios para el reporte
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda para el reporte</param>
        /// <returns>Modelo con parámetros para el reporte</returns>
        private ReporteViewModel CrearModelo(ReporteTiempoAtencionRequest filtro)
        {
            var reporteModel = new ReporteViewModel();
            reporteModel.RutaReporte += DatosConstantes.ReporteNombreArchivo.ReporteTiempoAtencion;

            reporteModel.AgregarParametro("CODIGO_LENGUAJE", DatosConstantes.Iternacionalizacion.ES_PE);
            reporteModel.AgregarParametro("USUARIO", entornoActualAplicacion.UsuarioSession);
            reporteModel.AgregarParametro("NOMBRE_REPORTE", ReporteTiempoAtencionResource.EtiquetaTitulo.ToUpper());
            reporteModel.AgregarParametro("FORMATO_FECHA_CORTA", DatosConstantes.Formato.FormatoFecha);
            reporteModel.AgregarParametro("FORMATO_HORA_CORTA", DatosConstantes.Formato.FormatoHora);
            reporteModel.AgregarParametro("FORMATO_NUMERO_ENTERO", DatosConstantes.Formato.FormatoNumeroEntero);
            reporteModel.AgregarParametro("FORMATO_NUMERO_DECIMAL", DatosConstantes.Formato.FormatoNumeroDecimal);
            reporteModel.AgregarParametro("PIE_REPORTE", string.Format(GenericoResource.EtiquetaFinReporte, ReporteTiempoAtencionResource.EtiquetaTitulo.ToUpper()));
            reporteModel.AgregarParametro("CODIGO_UNIDAD_OPERATIVA", filtro.CodigoUnidadOperativa);
            reporteModel.AgregarParametro("NOMBRE_UNIDAD_OPERATIVA", filtro.NombreUnidadOperativa);
            reporteModel.AgregarParametro("FECHA_INICIO", filtro.FechaConsultaDesdeString);
            reporteModel.AgregarParametro("FECHA_FIN", filtro.FechaConsultaHastaString);
            reporteModel.AgregarParametro("NUMERO_CONTRATO", filtro.NumeroContrato);

            return reporteModel;
        }
    }
}

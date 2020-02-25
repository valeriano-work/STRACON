using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteHojaRuta;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Contractual;
using System.Web.Mvc;


namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Reporte de Hoja de Ruta
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150630    </br>
    /// Modificación:                   </br>
    /// </remarks>
    public class ReporteHojaRutaController : GenericController
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
        /// <summary>
        /// Servicio de manejo de Flujo de Aprobación
        /// </summary>
        public IFlujoAprobacionService flujoAprobacionService { get; set; }
        #endregion

        #region Vistas
        /// <summary>
        /// Muestra la vista Index
        /// </summary>
        /// <returns>Vista Index</returns>
        public ActionResult Index(ReporteHojaRutaRequest filtro)
        {
            if (filtro != null)
            {
                TempData["DataReport"] = CrearModelo(filtro);
            }

            var reporteHojaRuta = new ReporteHojaRutaResponse();
            reporteHojaRuta.CodigoUnidadOperativa = filtro.CodigoUnidadOperativa;
            reporteHojaRuta.CodigoTipoServicio = filtro.CodigoTipoServicio;
            reporteHojaRuta.CodigoTipoRequerimiento = filtro.CodigoTipoRequerimiento;
            reporteHojaRuta.IndicadorMontoMinimo = filtro.DescripcionIndicadorMontoMinimo;
            reporteHojaRuta.GeneradosDesdeString = filtro.GeneradosDesdeString;
            reporteHojaRuta.GeneradosHastaString = filtro.GeneradosHastaString;
            reporteHojaRuta.NumeroContrato = filtro.NumeroContrato;

            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto });
            var tipoServicio = politicaService.ListarTipoContrato();
            var tipoRequerimiento = politicaService.ListarTipoServicio();

            var modelo = new ReporteHojaRutaBusqueda(unidadOperativa.Result, tipoServicio.Result, tipoRequerimiento.Result, reporteHojaRuta);
            return View(modelo);
        }
        #endregion

        /// <summary>
        /// Asigna los parámetros necesarios para el reporte
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda para el reporte</param>
        /// <returns>Modelo con parámetros para el reporte</returns>
        private ReporteViewModel CrearModelo(ReporteHojaRutaRequest filtro)
        {
            var reporteModel = new ReporteViewModel();
            reporteModel.RutaReporte += DatosConstantes.ReporteNombreArchivo.ReporteHojaRuta;

            reporteModel.AgregarParametro("CODIGO_LENGUAJE", DatosConstantes.Iternacionalizacion.ES_PE);
            reporteModel.AgregarParametro("USUARIO", entornoActualAplicacion.UsuarioSession);
            reporteModel.AgregarParametro("NOMBRE_REPORTE", ReporteHojaRutaResource.EtiquetaTitulo.ToUpper());
            reporteModel.AgregarParametro("FORMATO_FECHA_CORTA", DatosConstantes.Formato.FormatoFecha);
            reporteModel.AgregarParametro("FORMATO_HORA_CORTA", DatosConstantes.Formato.FormatoHora);
            reporteModel.AgregarParametro("FORMATO_NUMERO_ENTERO", DatosConstantes.Formato.FormatoNumeroEntero);
            reporteModel.AgregarParametro("FORMATO_NUMERO_DECIMAL", DatosConstantes.Formato.FormatoNumeroDecimal);
            reporteModel.AgregarParametro("PIE_REPORTE", string.Format(GenericoResource.EtiquetaFinReporte, ReporteHojaRutaResource.EtiquetaTitulo.ToUpper()));
            reporteModel.AgregarParametro("NOMBRE_UNIDAD_OPERATIVA", filtro.NombreUnidadOperativa);
            reporteModel.AgregarParametro("CODIGO_UNIDAD_OPERATIVA", filtro.CodigoUnidadOperativa);
            reporteModel.AgregarParametro("CODIGO_TIPO_SERVICIO", filtro.CodigoTipoServicio);
            reporteModel.AgregarParametro("DESCRIPCION_TIPO_SERVICIO", filtro.DescripcionTipoServicio);
            reporteModel.AgregarParametro("CODIGO_TIPO_REQUERIMIENTO", filtro.DescripcionTipoServicio);
            reporteModel.AgregarParametro("DESCRIPCION_TIPO_REQUERIMIENTO", filtro.DescripcionTipoRequerimiento);
            reporteModel.AgregarParametro("DESCRIPCION_FORMA_EDICION", string.Empty);
            reporteModel.AgregarParametro("FECHA_INICIO", filtro.GeneradosDesdeString);
            reporteModel.AgregarParametro("FECHA_FIN", filtro.GeneradosHastaString);
            reporteModel.AgregarParametro("NUMERO_CONTRATO", filtro.NumeroContrato);

            return reporteModel;
        }

        #region Json
        /// <summary>
        /// Obtiene el Flujo de Aprobación
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Resultado de Flujo de Aprobación</returns>
        //public JsonResult BuscarFlujoAprobacion(FlujoAprobacionRequest filtro)
        //{
        //    var resultado = flujoAprobacionService.BuscarBandejaFlujoAprobacion(filtro);
        //    return Json(resultado);
        //}
        #endregion
    }
}

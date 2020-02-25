using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteContratoPorVencer;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Contractual;
using System.Web.Mvc;
using System.Linq;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Reporte de Contrato por Vencer
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150630 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ReporteContratoPorVencerController : GenericController
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
        public ActionResult Index(ReporteContratoPorVencerRequest filtro)
        {
            var alertaVencimientoContrato = politicaService.ListarAlertaVencimientoContratoDinamico().Result;
            if (alertaVencimientoContrato != null)
            {
                if (alertaVencimientoContrato.Where(i => i.Atributo1 == DatosConstantes.AlertaVencimientoContrato.Rojo).Count() > 0)
                {
                    filtro.NumeroDiaRojo = alertaVencimientoContrato.Where(i => i.Atributo1 == DatosConstantes.AlertaVencimientoContrato.Rojo).FirstOrDefault().Atributo3.ToString();
                }
                if (alertaVencimientoContrato.Where(i => i.Atributo1 == DatosConstantes.AlertaVencimientoContrato.Ambar).Count() > 0)
                {
                    filtro.NumeroDiaAmbar = alertaVencimientoContrato.Where(i => i.Atributo1 == DatosConstantes.AlertaVencimientoContrato.Ambar).FirstOrDefault().Atributo3.ToString();
                }
            }

            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto });
            var estadoContrato = politicaService.ListarEstadoContrato();

            var modelo = new ReporteContratoPorVencerBusqueda(unidadOperativa.Result, estadoContrato.Result, filtro.VencimientoDesdeString, filtro.VencimientoHastaString);

            if (modelo.FechaVencimientoDesdeString !=null)
            {
                filtro.VencimientoDesdeString = modelo.FechaVencimientoDesdeString;
            }

            if (modelo.FechaVencimientoHastaString != null)
            {
                filtro.VencimientoHastaString = modelo.FechaVencimientoHastaString;
            }

            if (filtro != null)
            {
                TempData["DataReport"] = CrearModelo(filtro);
            }

            return View(modelo);
        }
        #endregion

        /// <summary>
        /// Asigna los parámetros necesarios para el reporte
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda para el reporte</param>
        /// <returns>Modelo con parámetros para el reporte</returns>
        private ReporteViewModel CrearModelo(ReporteContratoPorVencerRequest filtro)
        {
            var reporteModel = new ReporteViewModel();
            reporteModel.RutaReporte += DatosConstantes.ReporteNombreArchivo.ReporteContratoPorVencer;

            reporteModel.AgregarParametro("CODIGO_LENGUAJE", DatosConstantes.Iternacionalizacion.ES_PE);
            reporteModel.AgregarParametro("USUARIO", entornoActualAplicacion.UsuarioSession);
            reporteModel.AgregarParametro("NOMBRE_REPORTE", ReporteContratoPorVencerResource.EtiquetaTitulo.ToUpper());
            reporteModel.AgregarParametro("FORMATO_FECHA_CORTA", DatosConstantes.Formato.FormatoFecha);
            reporteModel.AgregarParametro("FORMATO_HORA_CORTA", DatosConstantes.Formato.FormatoHora);
            reporteModel.AgregarParametro("FORMATO_NUMERO_ENTERO", DatosConstantes.Formato.FormatoNumeroEntero);
            reporteModel.AgregarParametro("FORMATO_NUMERO_DECIMAL", DatosConstantes.Formato.FormatoNumeroDecimal);
            reporteModel.AgregarParametro("PIE_REPORTE", string.Format(GenericoResource.EtiquetaFinReporte, ReporteContratoPorVencerResource.EtiquetaTitulo.ToUpper()));
            reporteModel.AgregarParametro("CODIGO_UNIDAD_OPERATIVA", filtro.CodigoUnidadOperativa);

            var array_fecha_desde = filtro.VencimientoDesdeString.Split('/');
            filtro.VencimientoDesdeString = array_fecha_desde[2] + array_fecha_desde[1] + array_fecha_desde[0];

            var array_fecha_hasta = filtro.VencimientoHastaString.Split('/');
            filtro.VencimientoHastaString = array_fecha_hasta[2] + array_fecha_hasta[1] + array_fecha_hasta[0];

            reporteModel.AgregarParametro("FECHA_INICIO", filtro.VencimientoDesdeString);
            reporteModel.AgregarParametro("FECHA_FIN", filtro.VencimientoHastaString);
            reporteModel.AgregarParametro("ESTADO", DatosConstantes.EstadoContrato.Vigente);
            reporteModel.AgregarParametro("NUMDIAS_ROJO", filtro.NumeroDiaRojo);
            reporteModel.AgregarParametro("NUMDIAS_AMBAR", filtro.NumeroDiaAmbar);
            reporteModel.AgregarParametro("NOMBRE_UNIDAD_OPERATIVA", filtro.NombreUnidadOperativa);
            reporteModel.AgregarParametro("DESCRIPCION_ESTADO_CONTRATO", "Vigente");

            return reporteModel;
        }
    }
}

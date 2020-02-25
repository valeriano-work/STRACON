using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteContratoPorFinalizar;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Reporte de Contrato por Finalizar
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20160623 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ReporteContratoPorFinalizarController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de Políticas
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Servicio de manejo de Unidad Operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }
        /// <summary>
        /// Interfaz para el manejo de Auditoría
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }
        #endregion

        #region Vistas
        /// <summary>
        /// Muestra la vista Index 
        /// </summary> 
        /// <returns>Vista Index</returns>
        public ActionResult Index(ReporteContratoPorFinalizarRequest filtro)
        {
            if (filtro != null)
            {
                TempData["DataReport"] = CrearModelo(filtro);
            }

            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto });
            var listaTipoContrato = politicaService.ListarTipoContrato();
            var listaTipoServicio = politicaService.ListarTipoServicio().Result.OrderBy(x => x.Valor).ToList();

            var reporteContratoPorFinalizar = new ReporteContratoPorFinalizarResponse();
            reporteContratoPorFinalizar.IndicadorUltimoEstadioAprobado = filtro.IndicadorUltimoEstadioAprobado;

            var modelo = new ReporteContratoPorFinalizarBusqueda(unidadOperativa.Result, listaTipoContrato.Result, listaTipoServicio, reporteContratoPorFinalizar);

            return View(modelo);
        }

        /// <summary>
        /// Asigna los parámetros necesarios para el reporte
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda para el reporte</param>
        /// <returns>Modelo con parámetros para el reporte</returns>
        private ReporteViewModel CrearModelo(ReporteContratoPorFinalizarRequest filtro)
        {
            var reporteModel = new ReporteViewModel();
            reporteModel.RutaReporte += DatosConstantes.ReporteNombreArchivo.ReporteContratoPorFinalizar;

            reporteModel.AgregarParametro("CODIGO_LENGUAJE", DatosConstantes.Iternacionalizacion.ES_PE);
            reporteModel.AgregarParametro("USUARIO", entornoActualAplicacion.UsuarioSession);
            reporteModel.AgregarParametro("NOMBRE_REPORTE", ReporteContratoPorFinalizarResource.EtiquetaTitulo.ToUpper());
            reporteModel.AgregarParametro("FORMATO_FECHA_CORTA", DatosConstantes.Formato.FormatoFecha);
            reporteModel.AgregarParametro("FORMATO_HORA_CORTA", DatosConstantes.Formato.FormatoHora);
            reporteModel.AgregarParametro("FORMATO_NUMERO_ENTERO", DatosConstantes.Formato.FormatoNumeroEntero);
            reporteModel.AgregarParametro("FORMATO_NUMERO_DECIMAL", DatosConstantes.Formato.FormatoNumeroDecimal);
            reporteModel.AgregarParametro("PIE_REPORTE", string.Format(GenericoResource.EtiquetaFinReporte, ReporteContratoPorFinalizarResource.EtiquetaTitulo.ToUpper()));
            reporteModel.AgregarParametro("CODIGO_UNIDAD_OPERATIVA", filtro.CodigoUnidadOperativa);
            reporteModel.AgregarParametro("CODIGO_TIPO_CONTRATO", filtro.CodigoTipoContrato);
            reporteModel.AgregarParametro("CODIGO_TIPO_SERVICIO", filtro.CodigoTipoServicio);
            reporteModel.AgregarParametro("NUMERO_CONTRATO", filtro.NumeroContrato);
            reporteModel.AgregarParametro("INDICADOR_ULTIMO_ESTADIO_APROBADO", filtro.IndicadorUltimoEstadioAprobado);
            reporteModel.AgregarParametro("NOMBRE_UNIDAD_OPERATIVA", filtro.NombreUnidadOperativa);
            reporteModel.AgregarParametro("DESCRIPCION_TIPO_CONTRATO", filtro.DescripcionTipoContrato);
            reporteModel.AgregarParametro("DESCRIPCION_TIPO_SERVICIO", filtro.DescripcionTipoServicio);
            reporteModel.AgregarParametro("DESCRIPCION_INDICADOR_ULTIMO_ESTADIO_APROBADO", filtro.DescripcionIndicadorUltimoEstadioAprobado);

            return reporteModel;
        }
        #endregion
    }
}

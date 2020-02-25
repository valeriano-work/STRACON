using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteContratoPendienteElaborar;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Contractual;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Reporte de Contrato Pendiente de Elaborar
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150630    </br>
    /// Modificación:                   </br>
    /// </remarks>
    public class ReporteContratoPendienteElaborarController : GenericController
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
        public ActionResult Index(ReporteContratoPendienteElaborarRequest filtro)
        {
            if (filtro != null)
            {
                TempData["DataReport"] = CrearModelo(filtro);
            }

            var tipoOrden = politicaService.ListarTipoOrden();
            var moneda = politicaService.ListarMoneda();
            var modelo = new ReporteContratoPendienteElaborarBusqueda(tipoOrden.Result, moneda.Result);
            return View(modelo);
        }
        #endregion

        /// <summary>
        /// Asigna los parámetros necesarios para el reporte
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda para el reporte</param>
        /// <returns>Modelo con parámetros para el reporte</returns>
        private ReporteViewModel CrearModelo(ReporteContratoPendienteElaborarRequest filtro)
        {
            var reporteModel = new ReporteViewModel();
            reporteModel.RutaReporte += DatosConstantes.ReporteNombreArchivo.ReporteContratoPendienteElaborar;

            reporteModel.AgregarParametro("CODIGO_LENGUAJE", DatosConstantes.Iternacionalizacion.ES_PE);
            reporteModel.AgregarParametro("USUARIO", entornoActualAplicacion.UsuarioSession);
            reporteModel.AgregarParametro("NOMBRE_REPORTE", ReporteContratoPendienteElaborarResource.EtiquetaTitulo.ToUpper());
            reporteModel.AgregarParametro("FORMATO_FECHA_CORTA", DatosConstantes.Formato.FormatoFecha);
            reporteModel.AgregarParametro("FORMATO_HORA_CORTA", DatosConstantes.Formato.FormatoHora);
            reporteModel.AgregarParametro("FORMATO_NUMERO_ENTERO", DatosConstantes.Formato.FormatoNumeroEntero);
            reporteModel.AgregarParametro("FORMATO_NUMERO_DECIMAL", DatosConstantes.Formato.FormatoNumeroDecimal);
            reporteModel.AgregarParametro("PIE_REPORTE", string.Format(GenericoResource.EtiquetaFinReporte, ReporteContratoPendienteElaborarResource.EtiquetaTitulo.ToUpper()));
            reporteModel.AgregarParametro("RUC_PROVEEDOR", filtro.RucProveedor);
            reporteModel.AgregarParametro("NOMBRE_PROVEEDOR", filtro.NombreProveedor);
            reporteModel.AgregarParametro("TIPO_ORDEN", filtro.CodigoTipoOrden);
            reporteModel.AgregarParametro("DESCRIPCION_TIPO_ORDEN", filtro.DescripcionTipoOrden);
            reporteModel.AgregarParametro("PERIODO_ANIO", filtro.Anio);
            reporteModel.AgregarParametro("PERIODO_MES", filtro.Mes);
            reporteModel.AgregarParametro("NOMBRE_MES", filtro.NombreMes);
            reporteModel.AgregarParametro("MONEDA", filtro.CodigoMoneda);
            reporteModel.AgregarParametro("DESCRIPCION_MONEDA", filtro.DescripcionMoneda);

            return reporteModel;
        }
    }
}

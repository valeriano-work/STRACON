using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteListadoContratoRegularizado;
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
    /// Controladora de Reporte de Tiempo de Atención
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150624
    /// Modificación:
    /// </remarks>
    public class ReporteListadoContratoRegularizadoController : GenericController
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
        /// Servicio de manejo de trabajador
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }
        /// <summary>
        /// Servicio de manejo de flujo de aprobación
        /// </summary>
        public IFlujoAprobacionService flujoAprobacionService { get; set; }
        #endregion

        #region Vistas
        /// <summary>
        /// Muestra la vista Index
        /// </summary> 
        /// <returns>Vista Index</returns>
        public ActionResult Index(ReporteListadoContratoRegularizadoRequest filtro)
        {
            if (filtro != null)
            {
                TempData["DataReport"] = CrearModelo(filtro);
            }

            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto });
            var reporteListadoContrato = new ReporteListadoContratoRegularizadoResponse();
            reporteListadoContrato.CodigoUnidadOperativa = filtro.CodigoUnidadOperativa; 
            reporteListadoContrato.NumeroContrato = filtro.NumeroContrato;
            reporteListadoContrato.Descripcion = filtro.Descripcion; 
            reporteListadoContrato.TipoServicio = filtro.CodigoTipoServicio;
            reporteListadoContrato.TipoRequerimiento = filtro.CodigoTipoRequerimiento;
            reporteListadoContrato.TipoDocumento = filtro.CodigoTipoDocumento;
            reporteListadoContrato.EstadoContrato = filtro.CodigoEstadoContrato;
            reporteListadoContrato.NumeroDocumento = filtro.NumeroDocumentoProveedor;
            reporteListadoContrato.RazonSocial = filtro.RazonSocial;
            reporteListadoContrato.FechaConsultaDesdeString = filtro.FechaConsultaDesdeString;
            reporteListadoContrato.FechaConsultaHastaString = filtro.FechaConsultaHastaString;
            reporteListadoContrato.ContenidoContrato = filtro.ContenidoContrato;
            reporteListadoContrato.CodigoTrabajadorResponsable = filtro.CodigoTrabajadorResponsable;
            reporteListadoContrato.NombreTrabajadorResponsable = filtro.NombreTrabajadorResponsable;
            reporteListadoContrato.NombreEstadio = filtro.NombreEstadio;
            reporteListadoContrato.IndicadorFinalizarAprobacion = filtro.IndicadorFinalizarAprobacion;

            var tipoServicio = politicaService.ListarTipoContrato().Result.OrderBy(x => x.Valor).ToList();
            var tipoRequerimiento = politicaService.ListarTipoServicio().Result.OrderBy(x => x.Valor).ToList();
            var tipoDocumento = politicaService.ListarTipoDocumentoContrato().Result.OrderBy(x => x.Valor).ToList();
            var estadoContrato = politicaService.ListarEstadoContrato().Result.OrderBy(x => x.Valor).ToList();

            var modelo = new ReporteListadoContratoRegularizadoBusqueda(unidadOperativa.Result, tipoServicio, tipoRequerimiento, tipoDocumento, estadoContrato, reporteListadoContrato);
            modelo.ListaEstadio.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaTodos, Selected = false });
            modelo.ListaEstadio.AddRange(flujoAprobacionService.BuscarFlujoAprobacionEstadioDescripcion(new FlujoAprobacionEstadioRequest()).Result.Where(p => p.Orden != 1 || p.Descripcion != "Edición").Select(x => new SelectListItem()
            {
                Text = x.Descripcion,
                Value = x.Descripcion,
                Selected = x.Descripcion == filtro.NombreEstadio
            }).ToList());

            var moneda = politicaService.ListarMoneda().Result.OrderBy(x => x.Valor).ToList();
            modelo.Moneda.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });
            modelo.Moneda.AddRange(moneda.Select(item => new SelectListItem() { Text = item.Valor.ToString(), Value = item.Codigo.ToString() }).ToList());

            return View(modelo);
        }
        #endregion

        /// <summary>
        /// Asigna los parámetros necesarios para el reporte
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda para el reporte</param>
        /// <returns>Modelo con parámetros para el reporte</returns>
        private ReporteViewModel CrearModelo(ReporteListadoContratoRegularizadoRequest filtro)
        {
            var reporteModel = new ReporteViewModel();
            reporteModel.RutaReporte += DatosConstantes.ReporteNombreArchivo.ReporteListadoContrato;

            reporteModel.AgregarParametro("CODIGO_LENGUAJE", DatosConstantes.Iternacionalizacion.ES_PE);
            reporteModel.AgregarParametro("USUARIO", entornoActualAplicacion.UsuarioSession);
            reporteModel.AgregarParametro("NOMBRE_REPORTE", ReporteListadoContratoResource.EtiquetaTitulo.ToUpper());
            reporteModel.AgregarParametro("FORMATO_FECHA_CORTA", DatosConstantes.Formato.FormatoFecha);
            reporteModel.AgregarParametro("FORMATO_HORA_CORTA", DatosConstantes.Formato.FormatoHora);
            reporteModel.AgregarParametro("FORMATO_NUMERO_ENTERO", DatosConstantes.Formato.FormatoNumeroEntero);
            reporteModel.AgregarParametro("FORMATO_NUMERO_DECIMAL", DatosConstantes.Formato.FormatoNumeroDecimal);
            reporteModel.AgregarParametro("PIE_REPORTE", string.Format(GenericoResource.EtiquetaFinReporte, ReporteTiempoAtencionResource.EtiquetaTitulo.ToUpper()));
            reporteModel.AgregarParametro("DESCRIPCION", filtro.Descripcion);
            reporteModel.AgregarParametro("CODIGO_UNIDAD_OPERATIVA", filtro.CodigoUnidadOperativa);
            reporteModel.AgregarParametro("NOMBRE_UNIDAD_OPERATIVA", filtro.NombreUnidadOperativa);
            reporteModel.AgregarParametro("CODIGO_TIPO_SERVICIO", filtro.CodigoTipoServicio);
            reporteModel.AgregarParametro("NOMBRE_TIPO_SERVICIO", filtro.NombreTipoServicio);
            reporteModel.AgregarParametro("CODIGO_TIPO_REQUERIMIENTO", filtro.CodigoTipoRequerimiento);
            reporteModel.AgregarParametro("NOMBRE_TIPO_REQUERIMIENTO", filtro.NombreTipoRequerimiento);
            reporteModel.AgregarParametro("CODIGO_TIPO_DOCUMENTO", filtro.CodigoTipoDocumento);
            reporteModel.AgregarParametro("NOMBRE_TIPO_DOCUMENTO", filtro.NombreTipoDocumento);
            reporteModel.AgregarParametro("CODIGO_ESTADO", filtro.CodigoEstadoContrato);
            reporteModel.AgregarParametro("NOMBRE_ESTADO", filtro.NombreEstadoContrato);
            reporteModel.AgregarParametro("NUMERO_CONTRATO", filtro.NumeroContrato);
            reporteModel.AgregarParametro("NUMERO_DOCUMENTO_PROVEEDOR", filtro.NumeroDocumentoProveedor);
            reporteModel.AgregarParametro("NOMBRE_COMERCIAL_PROVEEDOR", filtro.RazonSocial);
            reporteModel.AgregarParametro("FECHA_INICIO_VIGENCIA", filtro.FechaConsultaDesdeString);
            reporteModel.AgregarParametro("FECHA_FIN_VIGENCIA", filtro.FechaConsultaHastaString);
            reporteModel.AgregarParametro("CONTENIDO_CONTRATO", filtro.ContenidoContrato);
            reporteModel.AgregarParametro("CODIGO_TRABAJADOR_RESPONSABLE", filtro.CodigoTrabajadorResponsable);
            reporteModel.AgregarParametro("NOMBRE_ESTADIO", filtro.NombreEstadio);
            reporteModel.AgregarParametro("INDICADOR_FINALIZAR_APROBACION", filtro.IndicadorFinalizarAprobacion);
            reporteModel.AgregarParametro("MONTO_INICIO", filtro.MontoAcumuladoInicio);
            reporteModel.AgregarParametro("MONTO_FIN", filtro.MontoAcumuladoFin);
            //reporteModel.AgregarParametro("MONTO_INICIO", filtro.MontoAcumuladoInicio.ToString());
            //reporteModel.AgregarParametro("MONTO_FIN", filtro.MontoAcumuladoFin.ToString());
            reporteModel.AgregarParametro("CODIGO_MONEDA", filtro.CodigoMoneda);

            return reporteModel;
        }

        #region Json
        /// <summary>
        /// Permite la búsqueda de Trabajadores
        /// </summary>
        /// <param name="nombreTrabajador">Nombre de Trabajador</param>
        /// <returns>Lista con el resultado de la operación</returns>
        public JsonResult BuscarTrabajador(string nombreTrabajador)
        {
            TrabajadorRequest filtro = new TrabajadorRequest();
            filtro.NombreCompleto = nombreTrabajador;
            Pe.Stracon.Politicas.Aplicacion.Core.Base.ProcessResult<List<TrabajadorDatoMinimoResponse>> resultado = trabajadorService.BuscarTrabajadorDatoMinimo(filtro);
            return Json(resultado.Result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

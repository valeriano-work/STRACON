using log4net;
using Microsoft.Reporting.WebForms;
using Pe.GyM.Security.Web.Session;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Cross.Core.Util;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.LogError;
using Pe.Stracon.SGC.Presentacion.Core.Reporte;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteContratoObservadoAprobado;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// 
    /// </summary>
    public class ReporteContratoObservadoAprobadoController : GenericController
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ReporteContratoObservadoAprobadoController).Name);

        #region Parámetros
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary> 
        public IPoliticaService politicaService { get; set; }

        /// <summary>
        /// Servicio de manejo de unidad operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }

        /// <summary>
        /// Interfaz para el manejo de auditoría
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }
        /// <summary>
        /// Servicio de manejo de contrato
        /// </summary>
        public IContratoService contratoService { get; set; }
        #endregion

        #region Vistas
        /// <summary>
        /// Muestra la vista Index
        /// </summary>
        /// <returns>Vista Index</returns>
        public ActionResult Index(ReporteContratoObservadoAprobadoRequest filtro)
        {
            if (filtro != null)
            {
                if (filtro.NumeroContrato != null)
                    filtro.NumeroContrato = filtro.NumeroContrato.Trim();
            }

            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto });

            var listaTipoAccion = new List<SelectListItem>();
            listaTipoAccion.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaTodos });
            listaTipoAccion.Add(new SelectListItem() { Value = "1", Text = "Observados" });
            listaTipoAccion.Add(new SelectListItem() { Value = "2", Text = "Aprobados" });

            var reporteListadoContrato = new ReporteContratoObservadoAprobadoResponse();

            reporteListadoContrato.CodigoUnidadOperativa = filtro.CodigoUnidadOperativa;
            reporteListadoContrato.NumeroContrato = filtro.NumeroContrato;
            reporteListadoContrato.FechaConsultaDesde = filtro.FechaConsultaDesde;
            reporteListadoContrato.FechaConsultaHasta = filtro.FechaConsultaHasta;

            var modelo = new ReporteContratoObservadoAprobadoBusqueda(unidadOperativa.Result, listaTipoAccion, reporteListadoContrato);

            return View(modelo);
        }

        #endregion

        #region Json
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroContrato"></param>
        /// <param name="codigoUnidadOperativa"></param>
        /// <returns></returns>
        public JsonResult BuscarNumeroContrato(string numeroContrato)
        {
            ReporteContratoObservadoAprobadoRequest filtro = new ReporteContratoObservadoAprobadoRequest();

            filtro.NumeroContrato = numeroContrato;

            var resultado = contratoService.BuscarNumeroContrato(filtro);

            return Json(resultado.Result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult BuscarContratoObservadoAprobado(ReporteContratoObservadoAprobadoRequest filtro)
        {
            var resultado = contratoService.BuscarContratoObservadoAprobado(filtro);

            return Json(resultado);
        }

        /// <summary>
        /// Exporta en Formato Excel
        /// </summary>
        /// <param name="filtroReporte"></param>
        /// <returns></returns>
        public ActionResult ExportarReporte(ReporteContratoObservadoAprobadoRequest filtroReporte)
        {
            ProcessResult<byte[]> resultado = new ProcessResult<byte[]>();

            //var formato = ConfigurationManager.AppSettings["FormatoFecha"];

            //string strFromDate = "";
            //string strToDate   = "";

            try
            {
                var tipoAccion = "";

                if (filtroReporte.TipoAccionContrato == "1")
                {
                     tipoAccion = "Observados";
                }
                else if (filtroReporte.TipoAccionContrato == "2")
                {
                     tipoAccion = "Aprobados";
                }
                else
                {
                    tipoAccion = "(TODOS)";
                }

                #region Parametros
                var UsuarioSesion   = HttpGyMSessionContext.CurrentAccount();
                var reporteName     = DatosConstantes.ReporteNombreArchivo.ReporteContratoObservadoAprobado;
                var target          = ConfigurationManager.AppSettings["SrvReportingSGCWorkspace"].ToString();
                var reportingUrl    = ConfigurationManager.AppSettings["SrvReportingUrl"].ToString();
                var nameDataBase    = ConfigurationManager.AppSettings["NombreBaseDatosPoliticas"].ToString();
             

                //DateTime paramFromDate = Convert.ToDateTime(filtroReporte.FechaConsultaDesdeString);
                //string dtFrom = paramFromDate.ToString();

                //DateTime paramToDate = Convert.ToDateTime(filtroReporte.FechaConsultaHastaString);
                //string dtTo = paramToDate.ToString();

                //strFromDate = paramFromDate.ToString(formato, CultureInfo.InvariantCulture);

                //strToDate = paramToDate.ToString(formato, CultureInfo.InvariantCulture);

                var reporteModel = new ReporteViewModel();

                reporteModel.AgregarParametro("CODIGO_UNIDAD_OPERATIVA", filtroReporte.CodigoUnidadOperativa.ToString());
                reporteModel.AgregarParametro("CODIGO_CONTRATO", filtroReporte.CodigoContrato.ToString());
                reporteModel.AgregarParametro("TIPO_ACCION_CONTRATO", filtroReporte.TipoAccionContrato);
                reporteModel.AgregarParametro("FECHA_INICIO", filtroReporte.FechaConsultaDesdeString);
                reporteModel.AgregarParametro("FECHA_FIN", filtroReporte.FechaConsultaHastaString);

                //reporteModel.AgregarParametro("FECHA_INICIO", strFromDate);
                //reporteModel.AgregarParametro("FECHA_FIN", strToDate);

                reporteModel.AgregarParametro("NAME_DATABASE", nameDataBase);
                reporteModel.AgregarParametro("PageNo", "0");
                reporteModel.AgregarParametro("PageSize", "1000");
                reporteModel.AgregarParametro("USUARIO", UsuarioSesion.Alias);
                reporteModel.AgregarParametro("NUMERO_CONTRATO", filtroReporte.NumeroContrato);
                reporteModel.AgregarParametro("TIPO_ACCION", tipoAccion);
                reporteModel.AgregarParametro("UNIDAD_OPERATIVA", filtroReporte.NombreUnidadOperativa);
                reporteModel.AgregarParametro("FINICIO", filtroReporte.FechaConsultaDesdeString);
                reporteModel.AgregarParametro("FFIN", filtroReporte.FechaConsultaHastaString);
                #endregion

                resultado.Result = Utilitario.GeneraArchivoDesdeReporting(reportingUrl, target, reporteName, "EXCELOPENXML", reporteModel.Parametros);

                MemoryStream stream = new MemoryStream(resultado.Result);

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", string.Concat("Reporte_ObservadosAprobados", ".xlsx"));
            }
            catch (Exception ex)
            {
                LogEN.grabarLogError(ex, filtroReporte.FechaConsultaDesdeString);
                return null;
            }
            
        }
        #endregion
    }
}

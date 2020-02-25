using Pe.Stracon.SGC.Presentacion.Core.Reporte;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pe.Stracon.SGC.Presentacion.Areas.Base.Views.Reporte
{
    /// <summary>
    /// Clase de Report View Control
    /// </summary>
    public partial class ReportViewControl : System.Web.Mvc.ViewUserControl
    {
        /// <summary>
        /// Método para inicializar la página
        /// </summary>
        /// <param name="sender">Envio</param>
        /// <param name="e">Evento</param>
        protected void Page_Init(object sender, EventArgs e)
        {
            Context.Handler = Page;
        }

        /// <summary>
        /// Método para cargar la página
        /// </summary>
        /// <param name="sender">Envio</param>
        /// <param name="e">Evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Model != null && Model is ReporteViewModel)
                {
                    if (!IsPostBack)
                    {
                        var model = (ReporteViewModel)Model;
                        ReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
                        ReportViewer.ShowParameterPrompts = false;
                        ReportViewer.ServerReport.ReportServerCredentials = new ReporteCredencial();
                        ReportViewer.ServerReport.ReportPath = model.RutaReporte;
                        ReportViewer.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["SrvReportingUrl"]);
                        ReportViewer.ServerReport.SetParameters(model.Parametros);
                        ReportViewer.ServerReport.Refresh();
                    }
                }

            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
        }
    }
}
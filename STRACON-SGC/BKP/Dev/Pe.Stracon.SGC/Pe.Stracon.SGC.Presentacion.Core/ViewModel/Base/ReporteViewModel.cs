using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base
{
    /// <summary>
    /// Modelo que representa Reporte General
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150510 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class ReporteViewModel
    {
        /// <summary>
        /// Constructor que representa la clase
        /// </summary>
        public ReporteViewModel()
        {
            this.Parametros = new List<ReportParameter>();
            this.RutaReporte = ConfigurationManager.AppSettings["SrvReportingSGCWorkspace"];
        }

        /// <summary>
        /// Listado de Parámetros
        /// </summary>
        public List<ReportParameter> Parametros { get; set; }

        /// <summary>
        /// Ruta del Reporte
        /// </summary>
        public string RutaReporte { get; set; }

        /// <summary>
        /// Agregar Parámetros
        /// </summary>
        /// <param name="nombreParametro">Nombre del Parámetro</param>
        /// <param name="valorParametro">Valor del Parámetro</param>
        public void AgregarParametro(string nombreParametro, string valorParametro)
        {
            this.Parametros.Add(new ReportParameter(nombreParametro, valorParametro));
        }
    }
}

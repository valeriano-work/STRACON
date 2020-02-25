using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Base
{
    /// <summary>
    /// Contoladora de generación de reportes
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150510 <br />
    /// Modificación:       <br />
    /// </remarks>
    public class ReportController : GenericController
    {
        /// <summary>
        /// Ruta de Reportes de SGC
        /// </summary>
        public static readonly string pathSGC = ConfigurationManager.AppSettings["SrvReportingSGCWorkspace"];   
    }
}

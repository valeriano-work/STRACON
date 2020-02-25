using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteTiempoAtencion
{
    /// <summary>
    /// Modelo de vista para el Reporte de Tiempo Atención
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ReporteTiempoAtencionBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="unidadOperativa">Lista items unidad operativa</param>
        /// <param name="reporteTiempoAtencion">Clase Response de Tiempo de Atención</param>
        public ReporteTiempoAtencionBusqueda(List<UnidadOperativaResponse> unidadOperativa, ReporteTiempoAtencionResponse reporteTiempoAtencion)
        {
            this.UnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFiltro(unidadOperativa, reporteTiempoAtencion.CodigoUnidadOperativa);
            this.ReporteTiempoAtencion = reporteTiempoAtencion;
        }

        #region Propiedades
        /// <summary>
        /// Lista de Unidades Operativas
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }
        /// <summary>
        /// Clase Response de Reporte de Tiempo de Atención
        /// </summary>
        public ReporteTiempoAtencionResponse ReporteTiempoAtencion { get; set; }
        #endregion

    }
}

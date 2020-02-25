using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteEstadioActualContrato
{
    /// <summary>
    /// Modelo de vista para la bandeja Reporte de Estadio Actual de Contrato
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150624 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ReporteEstadioActualContratoBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="unidadOperativa">Lista de Unidades Operativas</param>
        /// <param name="reporteEstadioActualContrato">Clase Response de Reporte de Estadio Actual de Contrato</param>
        public ReporteEstadioActualContratoBusqueda(List<UnidadOperativaResponse> unidadOperativa, ReporteEstadioActualContratoResponse reporteEstadioActualContrato)
        {
            this.UnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFiltro(unidadOperativa, reporteEstadioActualContrato.CodigoUnidadOperativa);
            this.ReporteEstadioActualContrato = reporteEstadioActualContrato;
        }

        #region Propiedades
        /// <summary>
        /// Lista de unidades operativas
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }
        /// <summary>
        /// Clase Response de Reporte de Estadio Actual de Contrato
        /// </summary>
        public ReporteEstadioActualContratoResponse ReporteEstadioActualContrato { get; set; }
        #endregion
    }
}

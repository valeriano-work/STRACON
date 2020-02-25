using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteBienesContrato
{
    /// Modelo de vista para la configuración de Bienes por Contrato
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150803 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteBienesContratoBusqueda : GenericViewModel
    {
        public ReporteBienesContratoBusqueda(List<UnidadOperativaResponse> unidadOperativa, List<CodigoValorResponse> tipoBien, ReporteBienesContratoResponse reporteBienesContrato)
        {
            this.UnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFiltro(unidadOperativa, reporteBienesContrato.CodigoUnidadOperativa);
            this.TipoBien = this.GenerarListadoOpcioneGenericoFiltro(tipoBien, reporteBienesContrato.CodigoTipoBien);

            this.ReporteBienesContrato = reporteBienesContrato;
        }

        #region Propiedades
        /// <summary>
        /// Lista de Unidades Operativas
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }
        /// <summary>
        /// Lista de Tipos de Bien
        /// </summary>
        public List<SelectListItem> TipoBien { get; set; }
        /// <summary>
        /// Clase Response de Reporte de Bienes
        /// </summary>
        public ReporteBienesContratoResponse ReporteBienesContrato { get; set; }
        #endregion
    }
}

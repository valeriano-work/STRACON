using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteContratoPorFinalizar
{
    /// <summary>
    /// Modelo de vista para el Reporte de Contrato Por Finalizar
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20160623 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ReporteContratoPorFinalizarBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para la búsqueda
        /// </summary>
        /// <param name="listaUnidadOperativa">Lista de Unidades Operativas</param>
        /// <param name="listaTipoContrato">Lista de Tipos de Contratos</param>
        /// <param name="listaTipoServicio">Lista de Tipos de Servicios</param>
        public ReporteContratoPorFinalizarBusqueda(List<UnidadOperativaResponse> listaUnidadOperativa, List<CodigoValorResponse> listaTipoContrato, List<CodigoValorResponse> listaTipoServicio, ReporteContratoPorFinalizarResponse reporteContratoPorFinalizar)
        {
            this.ListaUnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFiltro(listaUnidadOperativa);
            this.ListaTipoContrato = this.GenerarListadoOpcioneGenericoFiltro(listaTipoContrato);
            this.ListaTipoServicio = this.GenerarListadoOpcioneGenericoFiltro(listaTipoServicio);
            this.ReporteContratoPorFinalizar = reporteContratoPorFinalizar;
        }

        #region Propiedades
        /// <summary>
        /// Lista de Unidades Operativas
        /// </summary>
        public List<SelectListItem> ListaUnidadOperativa { get; set; }
        /// <summary>
        /// Lista de Tipos de Contrato
        /// </summary>
        public List<SelectListItem> ListaTipoContrato { get; set; }
        /// <summary>
        /// Lista de Tipos de Servicios
        /// </summary>
        public List<SelectListItem> ListaTipoServicio { get; set; }
        /// <summary>
        /// Clase Response de Contrato Por Finalizar
        /// </summary>
        public ReporteContratoPorFinalizarResponse ReporteContratoPorFinalizar { get; set; }
        #endregion
    }
}

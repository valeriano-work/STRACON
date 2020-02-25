using System.Collections.Generic;
using System.Web.Mvc;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.BandejaContrato
{
    /// <summary>
    /// Modelo de vista para Consultas Busqueda
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ConsultasBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="listadoContratoResponse"></param>
        public ConsultasBusqueda(ListadoContratoResponse listadoContratoResponse)
        {
            this.Contrato = listadoContratoResponse;
        }
        #region Propiedades
        /// <summary>
        /// Lista Responsable Flujo Estadio
        /// </summary>
        public List<SelectListItem> ResponsableFlujoEstadio { get; set; }         
        /// <summary>
        /// Datos del Contrato
        /// </summary>
        public ListadoContratoResponse Contrato { get; set; }
        #endregion
    }
}

using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ActividadesGestionContractual
{
    /// <summary>
    /// Modelo de vista para Actividades Gestion Contractual
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ActividadesGestionContractualModel : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para Actividades Gestion Contractual
        /// </summary>
        /// <param name="formaGeneracion">forma generación</param>
        /// <param name="nivel">nivel</param>
        public ActividadesGestionContractualModel(List<CodigoValorResponse> formaGeneracion, List<CodigoValorResponse> nivel)
        {
            this.Nivel = this.GenerarListadoOpcioneGenericoFiltro(nivel);
            this.Calendarizacion = this.GenerarListadoOpcionesSiNoFiltro();
            this.EvidenciaSox = this.GenerarListadoOpcionesSiNoFiltro();
            this.FormaGeneracion = this.GenerarListadoOpcioneGenericoFiltro(formaGeneracion);
            this.FuenteIntegracion = this.GenerarListadoOpcioneGenericoFiltro();
        }
        #region Propiedades
        /// <summary>
        /// Lista Nivel
        /// </summary>
        public List<SelectListItem> Nivel { get; set; }
        /// <summary>
        /// Lista Calendarización
        /// </summary>
        public List<SelectListItem> Calendarizacion { get; set; }
        /// <summary>
        /// Lista Evidencia Sox
        /// </summary>
        public List<SelectListItem> EvidenciaSox { get; set; }
        /// <summary>
        /// Lista Forma Generación
        /// </summary>
        public List<SelectListItem> FormaGeneracion { get; set; }
        /// <summary>
        /// Lista Fuente Integración
        /// </summary>
        public List<SelectListItem> FuenteIntegracion { get; set; }
        #endregion
    }
}

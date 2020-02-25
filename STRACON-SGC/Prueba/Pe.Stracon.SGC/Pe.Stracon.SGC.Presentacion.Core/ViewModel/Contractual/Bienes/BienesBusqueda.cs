using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.GyM.Security.Account.Model;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Bienes
{
    /// <summary>
    /// Modelo de vista Bienes
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150709
    /// Modificación:   
    /// </remarks>
    public class BienesBusqueda : GenericViewModel
    {
        #region Propiedades
        /// <summary>
        /// Listas de Tipos de Bien
        /// </summary>
        public List<SelectListItem> TipoBien { get; set; }
        /// <summary>
        /// Listas de Tipos de Tarifa
        /// </summary>
        public List<SelectListItem> TipoTarifa { get; set; }
        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }
        #endregion

        /// <summary>
        /// Constructor Bienes Busqueda
        /// </summary>
        /// <param name="plstTipoBien">Parametro Lista Tipo Bien</param>
        /// <param name="plstTipoTarifa">Parametro Lista Tipo Tarifa</param>
        public BienesBusqueda(List<CodigoValorResponse> plstTipoBien, List<CodigoValorResponse> plstTipoTarifa)
        {
            this.TipoBien = new List<SelectListItem>();
            this.TipoTarifa = new List<SelectListItem>();
            this.TipoBien = this.GenerarListadoOpcioneGenericoFiltro(plstTipoBien);
            this.TipoTarifa = this.GenerarListadoOpcioneGenericoFiltro(plstTipoTarifa);
            this.ControlPermisos = new Control();
        }
    }
}

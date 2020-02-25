using Pe.GyM.Security.Account.Model;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.UnidadOperativa
{
    /// <summary>
    /// Modelo de vista para la bandeja de busqueda
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public class UnidadOperativaBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor de Unidad operativa de búsqueda
        /// </summary>
        /// <param name="niveles">Niveles</param>
        public UnidadOperativaBusqueda(List<CodigoValorResponse> niveles, string tipo)
        {
            this.Niveles = this.GenerarListadoOpcioneGenericoFiltro(niveles);
            this.UnidadesOperativasPadre = this.GenerarListadoOpcioneGenericoFiltro();
            this.Estado = this.GenerarListadoOpcioneEstadoFiltro();
            this.Tipo = tipo;
        }
        #region Propiedades
        /// <summary>
        /// Niveles
        /// </summary>
        public List<SelectListItem> Niveles { get; set; }
        /// <summary>
        /// Unidades Operativas padre
        /// </summary>
        public List<SelectListItem> UnidadesOperativasPadre { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public List<SelectListItem> Estado { get; set; }
        /// <summary>
        /// Tipo
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }

        /// <summary>
        /// Si el sistema es Cierre contable
        /// </summary>
        public bool EsScc { get; set; }
        
        #endregion
    }
}

using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.Parametro
{
    /// <summary>
    /// Modelo de Parámetro
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroModel
    {
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public ParametroModel()
        {
            Parametro = new ParametroResponse();
            ListaEmpresa = new List<SelectListItem>();
            ListaSistema = new List<SelectListItem>();
            ListaTipoParametro = new List<SelectListItem>();
        }
        #region Propiedades
        /// <summary>
        /// Lista de Empresa
        /// </summary>
        public List<SelectListItem> ListaEmpresa { get; set; }

        /// <summary>
        /// Lista de Sistema
        /// </summary>
        public List<SelectListItem> ListaSistema { get; set; }

        /// <summary>
        /// Lista de Acceso
        /// </summary>
        public List<SelectListItem> ListaTipoParametro { get; set; }

        /// <summary>
        /// Parámetro
        /// </summary>
        public ParametroResponse Parametro { get; set; }
        #endregion
    }    
}

using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.SeccionParametro
{
    /// <summary>
    /// Modelo de Sección Parámetro
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class SeccionParametroModel
    {
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public SeccionParametroModel()
        {
            Parametro = new ParametroResponse();
            SeccionParametro = new ParametroSeccionResponse();
            ListaTipoDato = new List<SelectListItem>();
            ListaParametroRelacionado = new List<SelectListItem>();
            ListaSeccionRelacionada = new List<SelectListItem>();
            ListaSeccionRelacionadaVisible = new List<SelectListItem>();
        }
        #region Propiedades
        /// <summary>
        /// Lista de Tipo de Dato
        /// </summary>
        public List<SelectListItem> ListaTipoDato { get; set; }

        /// <summary>
        /// Lista de Parámetro Relacionado
        /// </summary>
        public List<SelectListItem> ListaParametroRelacionado { get; set; }

        /// <summary>
        /// Lista de Sección Relacionada
        /// </summary>
        public List<SelectListItem> ListaSeccionRelacionada { get; set; }

        /// <summary>
        /// Lista de Sección Relacionada Visible
        /// </summary>
        public List<SelectListItem> ListaSeccionRelacionadaVisible { get; set; }

        /// <summary>
        /// Parámetro
        /// </summary>
        public ParametroResponse Parametro { get; set; }

        /// <summary>
        /// Parámetro Sección
        /// </summary>
        public ParametroSeccionResponse SeccionParametro { get; set; }
        #endregion
    }    
}

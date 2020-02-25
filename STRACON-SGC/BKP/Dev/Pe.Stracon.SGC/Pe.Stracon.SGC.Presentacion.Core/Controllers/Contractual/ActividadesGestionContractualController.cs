using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ActividadesGestionContractual;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Actividades Gestion Contractual
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150318
    /// Modificación:
    /// </remarks>
    public class ActividadesGestionContractualController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        #endregion

        #region Vistas
        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var nivel = politicaService.ListarNivelUnidadOperativa();
            var formaGeneracion = politicaService.ListarFormaGeneracion();
            var modelo = new ActividadesGestionContractualModel(formaGeneracion.Result, nivel.Result);
            return View(modelo);
        }
        #endregion

        #region Vistas Parciales
        #endregion

        #region Json
        #endregion
    }
}
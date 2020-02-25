using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Core.Controllers.Base
{
    /// <summary>
    /// Controladora del Componente de Error
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150318
    /// Modificación:
    /// </remarks>
    public class ErrorController : Controller
    {
        #region Vistas
        /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index(int id)
        {
            TempData["StatusCode"] = id;
            return View();
        }
        #endregion
    }
}

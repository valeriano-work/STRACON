using System.Web.Mvc;
using Pe.GyM.Security.Web.Session;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Base
{
    /// <summary>
    /// Controladora de Cierre de sesión
    /// </summary>
    /// <remarks>
    /// Creación: 	GMD 20140508 <br />
    /// Modificación: 	 <br />
    /// </remarks>
    public class LogOutController : Controller
    {
        /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            return HttpGyMSessionContext.LogOut();
        }
    }
}

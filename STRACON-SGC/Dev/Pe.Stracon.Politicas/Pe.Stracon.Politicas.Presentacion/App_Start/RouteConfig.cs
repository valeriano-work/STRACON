using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pe.Stracon.Politicas.Presentacion
{
    /// <summary>
    /// Controlador que muestra la configuración de la ruta
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150430 <br />
    /// Modificación:       <br />
    /// </remarks>
    public class RouteConfig
    {
        /// <summary>
        /// Método para Registrar Routes
        /// </summary>
        /// <param name="routes">Routes</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Where(r => r is Route).ToList().ForEach(r =>
            {
                Route router = (Route)r;
                if (router.DataTokens != null && router.DataTokens.ContainsKey("area"))
                {
                    router.DataTokens["Namespaces"] = "Pe.Stracon.Politicas.Presentacion.Core.Controllers." + router.DataTokens["area"];
                }
            });

            routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{id}",
             defaults: new { areaDefault = "General", controller = "UnidadOperativa", action = "Index", id = UrlParameter.Optional }
         ).DataTokens.Add("area", "General");
        }
    }
}
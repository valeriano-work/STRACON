using System.Web.Http;

namespace Pe.Stracon.Politicas.Presentacion
{
    /// <summary>
    /// Controlador que muestra la configración de la aplicación web
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150430 <br />
    /// Modificación:       <br />
    /// </remarks>
    public static class WebApiConfig
    {
        /// <summary>
        /// Clase para registrar
        /// </summary>
        /// <param name="config">configuración</param>
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

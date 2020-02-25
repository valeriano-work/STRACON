using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Areas.General
{
    /// <summary>
    /// Controlador que muestra el registro del área general
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150430 <br />
    /// Modificación:       <br />
    /// </remarks>
    public class GeneralAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Método de tipo carácter de nombre de área
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "General";
            }
        }

        /// <summary>
        /// Método publico de registro de área
        /// </summary>
        /// <param name="context">Context</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "General_default",
                "General/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

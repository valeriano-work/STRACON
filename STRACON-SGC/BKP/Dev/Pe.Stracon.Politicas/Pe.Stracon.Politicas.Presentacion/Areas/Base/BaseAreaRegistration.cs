using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Areas.Base
{
    /// <summary>
    /// Controlador que muestra la base de área de registración
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150430 <br />
    /// Modificación:       <br />
    /// </remarks>
    public class BaseAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// Método de tipo carácter de nombre de área
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "Base";
            }
        }

        /// <summary>
        /// Método publico de registro de área
        /// </summary>
        /// <param name="context">Context</param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Base_default",
                "Base/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

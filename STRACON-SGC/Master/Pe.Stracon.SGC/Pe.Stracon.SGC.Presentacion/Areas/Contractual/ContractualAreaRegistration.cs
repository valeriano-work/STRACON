using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Areas.Contractual
{
    /// <summary>
    /// 
    /// </summary>
    public class ContractualAreaRegistration : AreaRegistration
    {
        /// <summary>
        /// 
        /// </summary>
        public override string AreaName
        {
            get
            {
                return "Contractual";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Contractual_default",
                "Contractual/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System.Web.Mvc;
using Pe.GyM.Security.Account.Service;
using Pe.GyM.Security.Web.Session;
using Pe.GyM.Security.Web.Base;
using System.Configuration;
using System;
using System.Web;

namespace Pe.GyM.Security.Web.Filters
{
    /// <summary>
    /// Filtro de validación de accesos a peticiones web
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public class AuthorizeFilter : AuthorizeAttribute
    {
        private const int StatusCodeSessionExpired = 490;
        /// <summary>
        /// Metodo aplicado para la autotización del usuario al contenido
        /// </summary>
        /// <param name="filterContext">Contexto actual de la petición</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            CuentaUsuarioService service = new CuentaUsuarioService();

            string token = filterContext.HttpContext.Request.QueryString[QueryStringParams.TOKEN];
            var cookie = filterContext.HttpContext.Request.Cookies["CLIENT_SITE_TOKEN"];
            var cookieValue = cookie != null ? cookie.Value : "";
            var sistemToken = ConfigurationManager.AppSettings["CLIENT_SITE_TOKEN"] ?? cookieValue;   

            if (token != null && HttpGyMSessionContext.CurrentAccount() == null)
            {
                var current = service.IniciarSessionPorToken(token, sistemToken);     
                if (current != null) 
                { 
                    HttpGyMSessionContext.SetAccount(current);
                }
            }

            if (HttpGyMSessionContext.CurrentAccount() == null)
            {
                var sistemDebug = ConfigurationManager.AppSettings["URL_DEBUG"];
                string urlDebug = !string.IsNullOrWhiteSpace(sistemDebug) ? ("&" + QueryStringParams.RETURN_URL_DEBUG + "=" + sistemDebug) : "";
                urlDebug = System.Web.Security.FormsAuthentication.LoginUrl + "?" + QueryStringParams.RETURN_URL + "=" + sistemToken + urlDebug;

                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    var httpStatusCode = new HttpStatusCodeResult(AuthorizeFilter.StatusCodeSessionExpired, urlDebug);
                    filterContext.Result = httpStatusCode;
                }
                else
                {
                    filterContext.Result = new RedirectResult(urlDebug);
                }

                filterContext.Result.ExecuteResult(filterContext);
            }
            else if (!service.ValidarAcceso(filterContext.HttpContext.Request.RawUrl))
            {
                filterContext.Result = new HttpUnauthorizedResult();
                filterContext.Result.ExecuteResult(filterContext);
            }
        }
    }
}

using System.Web;
using System.Web.SessionState;
using Pe.GyM.Security.Account.Model;
using System.Web.Security;
using System.Configuration;
using Pe.GyM.Security.Web.Base;
using System.Web.Mvc;
using System.Reflection;
using System;


namespace Pe.GyM.Security.Web.Session
{
    /// <summary>
    /// Manejador de las session de usuario
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public sealed class HttpGyMSessionContext
    {
        public static string USER_GYM = "SessionUserGyMContext";
        /// <summary>
        /// Obtiene la sesión actual.
        /// </summary>
        /// <returns></returns>
        public static CuentaUsuario CurrentAccount()
        {
            var result = HttpContext.Current.Session != null ? (CuentaUsuario)HttpContext.Current.Session[USER_GYM] : null;
            return result;
        }

        /// <summary>
        /// Obtiene la sesión actual
        /// </summary>
        /// <param name="account"></param>
        public static void SetAccount(CuentaUsuario account)
        {
            string alias = ConfigurationManager.AppSettings["impersonate"];
            // si no tiene datos en impersonate, funciona con el usuario logueado
            if (!string.IsNullOrEmpty(alias))
            {
                account.Alias = alias;
                account.Nombre = alias + "- impersonate por -";
            }
            HttpContext.Current.Session.Add(USER_GYM, account);
        }

        /// <summary>
        /// Limpia la sesión actual
        /// </summary>
        /// <returns>url de logue</returns>
        public static RedirectResult LogOut()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Session.Clear();
            var cookie = HttpContext.Current.Request.Cookies["CLIENT_SITE_TOKEN"];
            var cookieValue = cookie != null ? cookie.Value : "";
            var sistemToken = ConfigurationManager.AppSettings["CLIENT_SITE_TOKEN"] ?? cookieValue;
            var sistemDebug = ConfigurationManager.AppSettings["URL_DEBUG"];

            string urlDebug = !string.IsNullOrWhiteSpace(sistemDebug) ? ("&" + QueryStringParams.RETURN_URL_DEBUG + "=" + sistemDebug) : "";
            string ssoSiteUrl = string.Format("{0}?{1}={2}{3}", System.Web.Security.FormsAuthentication.LoginUrl, QueryStringParams.RETURN_URL, sistemToken, urlDebug);
            string LogoutUrl = string.Format("{0}&{1}={2}", ssoSiteUrl, QueryStringParams.ACTIONSSO, QueryStringParams.LOGOUT);

            return new RedirectResult(LogoutUrl);
        }

        /// <summary>
        /// Permite compartir la sessión con otras aplicacines
        /// </summary>
        /// <param name="applicationName">Identificado de aplicación para compartir sesión</param>
        /// <param name="modules">modulos cargados del sistema</param>
        public static void SharedSession(string applicationName, HttpModuleCollection modules)
        {
            foreach (string moduleName in modules)
            {
                IHttpModule module = modules[moduleName];
                SessionStateModule ssm = module as SessionStateModule;
                if (ssm != null)
                {
                    FieldInfo storeInfo = typeof(SessionStateModule).GetField("_store", BindingFlags.Instance | BindingFlags.NonPublic);
                    SessionStateStoreProviderBase store = (SessionStateStoreProviderBase)storeInfo.GetValue(ssm);
                    if (store == null) //In IIS7 Integrated mode, module.Init() is called later
                    {
                        FieldInfo runtimeInfo = typeof(HttpRuntime).GetField("_theRuntime", BindingFlags.Static | BindingFlags.NonPublic);
                        HttpRuntime theRuntime = (HttpRuntime)runtimeInfo.GetValue(null);
                        FieldInfo appNameInfo = typeof(HttpRuntime).GetField("_appDomainAppId", BindingFlags.Instance | BindingFlags.NonPublic);
                        appNameInfo.SetValue(theRuntime, applicationName);
                    }
                    else
                    {
                        Type storeType = store.GetType();
                        if (storeType.Name.Equals("OutOfProcSessionStateStore"))
                        {
                            FieldInfo uribaseInfo = storeType.GetField("s_uribase", BindingFlags.Static | BindingFlags.NonPublic);
                            uribaseInfo.SetValue(storeType, applicationName);
                        }
                    }
                }
            }
        }
    }
}

using Castle.Windsor;
using Castle.Windsor.Installer;
using Pe.GyM.Security.Web.Session;
using Pe.Stracon.SGC.Aplicacion.Core.Factory;
//using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
//using Pe.Stracon.SGC.Aplicacion.Service.Contractual;
using Pe.Stracon.SGC.Cross.Core.Base;
using System;
using System.Configuration;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pe.Stracon.SGC.Presentacion
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    /// 
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        private static string APPLICATION_NAME = "Pe.Stracon";

        /// <summary>
        /// 
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            log4net.Config.XmlConfigurator.Configure();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapContainer();
            HttpGyMSessionContext.SharedSession(APPLICATION_NAME, this.Modules);
        }

        /// <summary>
        /// 
        /// </summary>
        protected void Application_End()
        {
            container.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            var cuenta = HttpGyMSessionContext.CurrentAccount();
            if (cuenta != null)
            {
                cuenta.CodigoEmpresa = ConfigurationManager.AppSettings["CODIGO_EMPRESA"];
                cuenta.CodigoSistema = ConfigurationManager.AppSettings["CODIGO_SISTEMA"];

                var entorno = container.Resolve<IEntornoActualAplicacion>();
                entorno.UsuarioSession = cuenta.Alias;
                entorno.CodigoEmpresa = cuenta.CodigoEmpresa;
                entorno.CodigoSistema = cuenta.CodigoSistema;
                entorno.Terminal = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                                    ?? HttpContext.Current.Request.UserHostAddress;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_Start(object sender, EventArgs e)
        {
            HttpCookie myCookie = new HttpCookie("CLIENT_SITE_TOKEN");
            myCookie.Value = ConfigurationManager.AppSettings["CLIENT_SITE_TOKEN"];
            HttpContext.Current.Response.Cookies.Add(myCookie);
        }

        private static void BootstrapContainer()
        {
            container = new WindsorContainer()
                            .Install(FromAssembly.Named("Pe.Stracon.SGC.Aplicacion.Core"), FromAssembly.Named("Pe.Stracon.Politicas.Aplicacion.Core"));
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
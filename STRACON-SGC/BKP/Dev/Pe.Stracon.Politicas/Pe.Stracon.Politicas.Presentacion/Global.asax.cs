using Castle.Windsor;
using Castle.Windsor.Installer;
using Pe.GyM.Security.Web.Session;
using Pe.Stracon.Politicas.Aplicacion.Core.Factory;
using Pe.Stracon.Politicas.Cross.Core.Base;
using System;
using System.Configuration;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Pe.Stracon.Politicas.Presentacion
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication 
    {
        private static IWindsorContainer container;
        private static string APPLICATION_NAME = "Pe.Stracon";

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BootstrapContainer();

            //HttpGyMSessionContext.SharedSession(APPLICATION_NAME, this.Modules);
            HttpGyMSessionContext.SharedSession(APPLICATION_NAME, this.Modules);
        }
        protected void Application_End()
        {
            container.Dispose();
        }

        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            var cuenta = HttpGyMSessionContext.CurrentAccount();
            if (cuenta != null)
            {
                var entorno = container.Resolve<IEntornoActualAplicacion>();
                entorno.UsuarioSession = cuenta.Alias;
                entorno.CodigoEmpresa = cuenta.CodigoEmpresa;
                entorno.CodigoSistema = cuenta.CodigoSistema;
                entorno.Terminal = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
                                    ?? HttpContext.Current.Request.UserHostAddress;
            }

        }

        private static void BootstrapContainer()
        {
            //Database.SetInitializer<PoliticaDbContextProvider>(new DbContextInitializer());
            //Database.SetInitializer<ApplicationAuditDbContextProvider>(new CreateDatabaseIfNotExists<ApplicationAuditDbContextProvider>());
            container = new WindsorContainer()
                .Install(FromAssembly.InThisApplication());
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
[assembly: OwinStartup(typeof(Pe.Stracon.Politicas.Presentacion.App_Start.Startup))]

namespace Pe.Stracon.Politicas.Presentacion.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
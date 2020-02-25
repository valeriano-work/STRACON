using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Pe.Stracon.SGC.Aplicacion.Core.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Core.Installers
{
    public class EnvironmentInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Instalación
        /// </summary>
        /// <param name="container">Contenedor</param>
        /// <param name="store">Store</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<EnvironmentFacility>();
        }
    }
}

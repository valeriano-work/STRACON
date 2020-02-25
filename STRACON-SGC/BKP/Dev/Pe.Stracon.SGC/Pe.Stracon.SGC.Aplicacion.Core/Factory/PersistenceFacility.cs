using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using System.Configuration;

namespace Pe.Stracon.SGC.Aplicacion.Core.Factory
{
    /// <summary>
    /// Facilitador de la implementación del objeto de persistencia
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PersistenceFacility : AbstractFacility
    {
        protected override void Init()
        {
            string valueLifestylePerThread = ConfigurationManager.AppSettings["LifestylePerThread"];
            bool isLifestylePerThread = !string.IsNullOrEmpty(valueLifestylePerThread) && bool.Parse(valueLifestylePerThread);

            if (isLifestylePerThread)
            {
                Kernel.Register(Component.For<IDbContextProvider>()
                                 .ImplementedBy<SGCDbContextProvider>()
                                 .LifestylePerThread());
            }
            else
            {
                Kernel.Register(Component.For<IDbContextProvider>()
                                 .ImplementedBy<SGCDbContextProvider>()
                                 .LifestylePerWebRequest());
            }
        }
    }
}

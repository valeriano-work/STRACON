using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using Pe.Stracon.Politicas.Cross.Core.Base;
using Pe.Stracon.Politicas.Cross.Core.Security;

namespace Pe.Stracon.Politicas.Aplicacion.Core.Factory
{
    /// <summary>
    /// Facilitador de Entorno
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class EnvironmentFacility : AbstractFacility
    {
        /// <summary>
        /// Método de Inicio
        /// </summary>
        protected override void Init()
        {
            Kernel.Register(Component.For<IEntornoActualAplicacion>()
                .ImplementedBy<EntornoActualAplicacion>()
                .LifestylePerWebRequest());
        }
    }
}

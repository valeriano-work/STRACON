using Castle.MicroKernel;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pe.Stracon.Politicas.Aplicacion.Core.Factory
{
    /// <summary>
    /// Factory de injección de controllers
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        /// <summary>
        /// Controlador de fabrica Windsor
        /// </summary>
        /// <param name="kernel">Kernel</param>
        public WindsorControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Controaldor de Release
        /// </summary>
        /// <param name="controller">Kernel</param>
        public override void ReleaseController(IController controller)
        {
            kernel.ReleaseComponent(controller);
        }

        /// <summary>
        /// Permite obtener un controlador de instacia
        /// </summary>
        /// <param name="requestContext">Solicitud de Contexto</param>
        /// <param name="controllerType">Tipo de contexto</param>
        /// <returns>Kernel resuelto por tipo</returns>
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
            return (IController)kernel.Resolve(controllerType);
        }
    }
}
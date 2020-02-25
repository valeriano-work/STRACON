using Pe.Stracon.SGC.Aplicacion.Core.Base;
using System;

namespace Pe.Stracon.SGC.Aplicacion.Service.Base
{
    /// <summary>
    /// Implementación base generica de servicios de aplicación
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public abstract class GenericService : IGenericService
    {

        private bool Disposed = false;
        /// <summary>
        /// Finaliza el objeto
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.Disposed)
            {
                if (disposing)
                {

                }
            }
            this.Disposed = true;
        }
        /// <summary>
        /// Finaliza el objeto
        /// </summary>
        /// <param name="disposing"></param>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

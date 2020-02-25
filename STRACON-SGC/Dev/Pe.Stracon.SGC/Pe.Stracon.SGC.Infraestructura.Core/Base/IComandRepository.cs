using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Cross.Core.Base;
using System;

namespace Pe.Stracon.SGC.Infraestructura.Core.Base
{
    /// <summary>
    /// Repository contract: for persisting an entity.
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public interface IComandRepository<T> : IDisposable
        where T : Entity
    {        
        /// <summary>
        /// Save an entity.
        /// </summary>
        /// <param name="obj">The entity to save.</param>
        void Insertar(T entity, IEntornoActualAplicacion entorno = null);
        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="obj">The entity to update.</param>
        void Editar(T entity, IEntornoActualAplicacion entorno = null);
        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="obj">The entity to update.</param>
        void Eliminar(params object[] llaves);
        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entorno">Environment with the session</param>
        /// <param name="llaves">Code of The entity to delete.</param>
        void EliminarEntorno(IEntornoActualAplicacion entorno, params object[] llaves);
        /// <summary>
        /// Get Entity by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(params object[] id);
        /// <summary>
        /// Save all changes
        /// </summary>
        /// <returns></returns>
        int GuardarCambios();
    }
}

using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using System;

namespace Pe.Stracon.Politicas.Infraestructura.Core.Base
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
        void Insertar(T entity);
        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="obj">The entity to update.</param>
        void Editar(T entity);
        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="obj">The entity to update.</param>
        void Eliminar(params object[] llaves);
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

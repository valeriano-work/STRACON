using System;
using System.Reflection;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using Pe.Stracon.Politicas.Infraestructura.Core.Base;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;
using Pe.Stracon.Politicas.Cross.Core.Base;

namespace Pe.Stracon.Politicas.Infraestructura.Repository.Base
{
    /// <summary>
    /// Repository base for all wite model
    /// </summary>
    public abstract class ComandRepository<T> : IComandRepository<T>
         where T : Entity
    {
        public IDbContextProvider dataBaseProvider { get; set; }
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        /// <summary>
        /// Realiza una inserción en BD
        /// </summary>
        /// <param name="entidad">Entidad</param>
        public void Insertar(T entidad)
        {
            entidad.EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;
            entidad.UsuarioCreacion = entornoActualAplicacion.UsuarioSession;
            entidad.TerminalCreacion = entornoActualAplicacion.UsuarioSession;

            entidad.FechaCreacion = DateTime.Now;
            entidad.FechaModificacion = null;

            this.dataBaseProvider.DbSet<T>().Add(entidad);
            RegistrarAuditoria(entidad);
        }

        /// <summary>
        /// Realiza un edición en BD
        /// </summary>
        /// <param name="entidad">Entidad</param>
        public void Editar(T entidad)
        {
            entidad.FechaModificacion = DateTime.Now;
            entidad.UsuarioModificacion = entornoActualAplicacion.UsuarioSession;
            entidad.TerminalModificacion = entornoActualAplicacion.Terminal;

            this.dataBaseProvider.Modified(entidad);
            RegistrarAuditoria(entidad);
        }

        /// <summary>
        /// Realiza una eliminación logica en la BD
        /// </summary>
        /// <param name="llaves">llaves a elminar</param>
        public void Eliminar(params object[] llaves)
        {

            var entidadEliminar = this.GetById(llaves);
            entidadEliminar.EstadoRegistro = DatosConstantes.EstadoRegistro.Inactivo;
            entidadEliminar.UsuarioModificacion = entornoActualAplicacion.UsuarioSession;
            entidadEliminar.TerminalModificacion = entornoActualAplicacion.Terminal;
            entidadEliminar.FechaModificacion = DateTime.Now;

            RegistrarAuditoria(entidadEliminar);
        }

        /// <summary>
        /// Obtiene la entidad por su id
        /// </summary>
        /// <param name="id">id de la entidad</param>
        /// <returns>Entidad</returns>
        public T GetById(params object[] id)
        {
            return this.dataBaseProvider.DbSet<T>().Find(id);
        }

        /// <summary>
        /// Guarda los cambios realizados
        /// </summary>
        /// <returns></returns>
        public int GuardarCambios()
        {
            return this.dataBaseProvider.Persist();
        }

        /// <summary>
        /// Registra en auditoria
        /// </summary>
        /// <param name="entity">Entidad</param>
        public void RegistrarAuditoria(T entity)
        {

            var hasTraceAudit = typeof(T).GetCustomAttribute<TraceAuditAttribute>();
            if (hasTraceAudit != null)
            {
                using (IDbContextProvider dataBaseProviderAudit = new PoliticaAuditDbContextProvider())
                {
                    dataBaseProviderAudit.DbSet<T>().Add(entity);
                    dataBaseProviderAudit.Persist();
                }
            }
        }

        /// <summary>
        /// Ejeuta el metodo dispose del proveedor de la base de datos
        /// </summary>
        public void Dispose()
        {
            if (this.dataBaseProvider != null)
            {
                this.dataBaseProvider.Dispose();
            }
        }
    }
}
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using System;
using System.Reflection;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Base
{
    /// <summary>
    /// Repository base for all wite model
    /// </summary>
    public abstract class ComandRepository<T> : IComandRepository<T>
         where T : Entity
    {
        public IDbContextProvider dataBaseProvider { get; set; }
        //public IDbContextProvider dataBaseProviderAudit { get; set; }
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        public void Insertar(T entidad, IEntornoActualAplicacion entorno = null)
        {
            entidad.EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;
            entidad.UsuarioCreacion = entorno == null ? entornoActualAplicacion.UsuarioSession : entorno.UsuarioSession;
            entidad.FechaCreacion = DateTime.Now;
            entidad.TerminalCreacion = entorno == null ? entornoActualAplicacion.Terminal : entorno.Terminal;

            this.dataBaseProvider.DbSet<T>().Add(entidad);
            RegistrarAuditoria(entidad);
        }

        public void Editar(T entidad, IEntornoActualAplicacion entorno = null)
        {
            entidad.UsuarioModificacion = entorno == null ? entornoActualAplicacion.UsuarioSession : entorno.UsuarioSession;
            entidad.FechaModificacion = DateTime.Now;
            entidad.TerminalModificacion = entorno == null ? entornoActualAplicacion.Terminal : entorno.Terminal;

            this.dataBaseProvider.Modified(entidad);
            RegistrarAuditoria(entidad);
        }

        public void Eliminar(params object[] llaves)
        {
            var entidadEliminar = this.GetById(llaves);
            entidadEliminar.EstadoRegistro = DatosConstantes.EstadoRegistro.Inactivo;
            entidadEliminar.UsuarioModificacion = entornoActualAplicacion.UsuarioSession;
            entidadEliminar.FechaModificacion = DateTime.Now;
            entidadEliminar.TerminalModificacion = entornoActualAplicacion.Terminal;

            RegistrarAuditoria(entidadEliminar);
        }

        public void EliminarEntorno( IEntornoActualAplicacion entorno, params object[] llaves)
        {
            var entidadEliminar = this.GetById(llaves);
            entidadEliminar.EstadoRegistro = DatosConstantes.EstadoRegistro.Inactivo;
            entidadEliminar.UsuarioModificacion = entorno == null ? entornoActualAplicacion.UsuarioSession : entorno.UsuarioSession;
            entidadEliminar.FechaModificacion = DateTime.Now;
            entidadEliminar.TerminalModificacion = entorno == null ? entornoActualAplicacion.Terminal : entorno.Terminal;

            RegistrarAuditoria(entidadEliminar);
        }

        public T GetById(params object[] id)
        {
            return this.dataBaseProvider.DbSet<T>().Find(id);
        }

        public int GuardarCambios()
        {
            return this.dataBaseProvider.Persist();
        }

        public void RegistrarAuditoria(T entity)
        {

            var hasTraceAudit = typeof(T).GetCustomAttribute<TraceAuditAttribute>();
            if (hasTraceAudit != null)
            {
                using (IDbContextProvider dataBaseProviderAudit = new SGCAuditDbContextProvider())
                {
                    dataBaseProviderAudit.DbSet<T>().Add(entity);
                    dataBaseProviderAudit.Persist();
                }
            }
        }

        public void Dispose()
        {
            if (this.dataBaseProvider != null)
            {
                this.dataBaseProvider.Dispose();
            }
        }
    }
}

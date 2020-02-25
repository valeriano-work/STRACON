using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.Mapping.General
{
    /// <summary>
    /// Implementación del mapeo de la entidad Trabajador Suplente
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorSuplenteMapping : BaseEntityMapping<TrabajadorSuplenteEntity>
    {
        /// <summary>
        /// Constuctor del Mapping de Departamento
        /// </summary>
        public TrabajadorSuplenteMapping()
            : base()
        {
            HasKey(x => x.CodigoTrabajador).ToTable("TRABAJADOR_SUPLENTE", "GRL");
            Property(u => u.CodigoTrabajador).HasColumnName("CODIGO_TRABAJADOR");
            Property(u => u.CodigoSuplente).HasColumnName("CODIGO_SUPLENTE");
            Property(u => u.FechaInicio).HasColumnName("FECHA_INICIO");
            Property(u => u.FechaFin).HasColumnName("FECHA_FIN");
            Property(u => u.Activo).HasColumnName("ACTIVO");
            Property(u => u.Ejecutado).HasColumnName("EJECUTADO");
            Property(u => u.EstadoRegistro).HasColumnName("ESTADO_REGISTRO");
            Property(u => u.PerfilesAgregados).HasColumnName("PERFILES_AGREGADOS");     
            Property(u => u.UsuarioCreacion).HasColumnName("USUARIO_CREACION");
            Property(u => u.FechaCreacion).HasColumnName("FECHA_CREACION");
            Property(u => u.TerminalCreacion).HasColumnName("TERMINAL_CREACION");
            Property(u => u.UsuarioModificacion).HasColumnName("USUARIO_MODIFICACION");
            Property(u => u.FechaModificacion).HasColumnName("FECHA_MODIFICACION");
            Property(u => u.TerminalModificacion).HasColumnName("TERMINAL_MODIFICACION");
        }
    }
}

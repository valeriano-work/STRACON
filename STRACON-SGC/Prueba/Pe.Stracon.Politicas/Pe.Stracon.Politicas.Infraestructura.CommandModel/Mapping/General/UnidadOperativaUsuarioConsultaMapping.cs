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
    /// Implementación del mapeo de la entidad unidad operativa staff
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20161121 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaUsuarioConsultaMapping : BaseEntityMapping<UnidadOperativaUsuarioConsultaEntity>
    {
         /// <summary>
        /// Constuctor del Mapping de Unidad Operativa Responsable
        /// </summary>
        public UnidadOperativaUsuarioConsultaMapping()
            : base()
        {
            HasKey(x => x.CodigoUnidadUsuarioConsulta).ToTable("UNIDAD_OPERATIVA_USUARIO_CONSULTA", "GRL");
            Property(u => u.CodigoUnidadUsuarioConsulta).HasColumnName("CODIGO_UNIDAD_OPERATIVA_USUARIO_CONSULTA");
            Property(u => u.CodigoUnidadOperativa).HasColumnName("CODIGO_UNIDAD_OPERATIVA");          
            Property(u => u.CodigoTrabajador).HasColumnName("CODIGO_TRABAJADOR");
            Property(u => u.EstadoRegistro).HasColumnName("ESTADO_REGISTRO");
            Property(u => u.UsuarioCreacion).HasColumnName("USUARIO_CREACION");
            Property(u => u.FechaCreacion).HasColumnName("FECHA_CREACION");
            Property(u => u.TerminalCreacion).HasColumnName("TERMINAL_CREACION");
            Property(u => u.UsuarioModificacion).HasColumnName("USUARIO_MODIFICACION");
            Property(u => u.FechaModificacion).HasColumnName("FECHA_MODIFICACION");
            Property(u => u.TerminalModificacion).HasColumnName("TERMINAL_MODIFICACION");            
        }
    }
}

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
    /// Implementación del mapeo de la entidad trabajadorUnidadOperativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150326 <br />
    /// Modificación:            <br />
    /// </remarks>
    class TrabajadorUnidadOperativaMapping : BaseEntityMapping<TrabajadorUnidadOperativaEntity>
    {
        /// <summary>
        /// Constuctor del Mapping de TrabajadorUnidadOperativa
        /// </summary>
        
        public TrabajadorUnidadOperativaMapping()
            : base()
        {
            HasKey(x => x.CodigoTrabajadorUnidadOperativa).ToTable("TRABAJADOR_UNIDAD_OPERATIVA", "GRL");
            Property(u => u.CodigoTrabajadorUnidadOperativa).HasColumnName("CODIGO_TRABAJADOR_UNIDAD_OPERATIVA");
            Property(u => u.CodigoUnidadOperativaMatriz).HasColumnName("CODIGO_UNIDAD_OPERATIVA_MATRIZ");
            Property(u => u.CodigoTrabajador).HasColumnName("CODIGO_TRABAJADOR");
            Property(u => u.CodigoUnidadOperativa).HasColumnName("CODIGO_UNIDAD_OPERATIVA");
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

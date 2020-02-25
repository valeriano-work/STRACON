using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Contrato Parrafo Variable
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class VariableListaMapping : BaseEntityMapping<VariableListaEntity>
    {
        public VariableListaMapping()
            : base()
        {
            HasKey(x => x.CodigoVariableLista).ToTable("VARIABLE_LISTA", "CTR");
            Property(u => u.CodigoVariableLista).HasColumnName("CODIGO_VARIABLE_LISTA");
            Property(u => u.CodigoVariable).HasColumnName("CODIGO_VARIABLE");
            Property(u => u.Nombre).HasColumnName("NOMBRE");
            Property(u => u.Descripcion).HasColumnName("DESCRIPCION");
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

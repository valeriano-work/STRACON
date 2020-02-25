using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Campo de Variable
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class VariableCampoMapping : BaseEntityMapping<VariableCampoEntity>
    {
        public VariableCampoMapping()
            : base()
        {
            HasKey(x => x.CodigoVariableCampo).ToTable("VARIABLE_CAMPO", "CTR");
            Property(u => u.CodigoVariableCampo).HasColumnName("CODIGO_VARIABLE_CAMPO");
            Property(u => u.CodigoVariable).HasColumnName("CODIGO_VARIABLE");
            Property(u => u.Nombre).HasColumnName("NOMBRE");
            Property(u => u.Orden).HasColumnName("ORDEN");
            Property(u => u.TipoAlineamiento).HasColumnName("TIPO_ALINEAMIENTO");
            Property(u => u.Tamanio).HasColumnName("TAMANIO");
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

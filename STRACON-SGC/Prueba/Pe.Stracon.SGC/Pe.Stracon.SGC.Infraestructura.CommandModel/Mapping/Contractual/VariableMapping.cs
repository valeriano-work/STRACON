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
    /// Implementación del mapeo de la entidad Variable
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class VariableMapping : BaseEntityMapping<VariableEntity>
    {
        public VariableMapping()
            :base()
        {
            HasKey(x => x.CodigoVariable).ToTable("VARIABLE", "CTR");
            Property(u => u.CodigoVariable).HasColumnName("CODIGO_VARIABLE");
            Property(u => u.CodigoPlantilla).HasColumnName("CODIGO_PLANTILLA");
            Property(u => u.Identificador).HasColumnName("IDENTIFICADOR");
            Property(u => u.Nombre).HasColumnName("NOMBRE");
            Property(u => u.CodigoTipo).HasColumnName("CODIGO_TIPO");
            Property(u => u.IndicadorGlobal).HasColumnName("INDICADOR_GLOBAL");
            Property(u => u.IndicadorVariableSistema).HasColumnName("INDICADOR_VARIABLE_SISTEMA");
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

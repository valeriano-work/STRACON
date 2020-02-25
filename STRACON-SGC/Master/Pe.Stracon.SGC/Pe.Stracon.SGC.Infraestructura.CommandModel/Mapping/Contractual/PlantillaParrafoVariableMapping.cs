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
    /// Implementación del mapeo de la entidad Plantilla Párrafo Variable
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150529 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaParrafoVariableMapping : BaseEntityMapping<PlantillaParrafoVariableEntity>
    {
        public PlantillaParrafoVariableMapping()
            : base()
        {
            HasKey(x => x.CodigoPlantillaParrafoVariable).ToTable("PLANTILLA_PARRAFO_VARIABLE", "CTR");
            Property(u => u.CodigoPlantillaParrafoVariable).HasColumnName("CODIGO_PLANTILLA_PARRAFO_VARIABLE");
            Property(u => u.CodigoPlantillaParrafo).HasColumnName("CODIGO_PLANTILLA_PARRAFO");
            Property(u => u.CodigoVariable).HasColumnName("CODIGO_VARIABLE");
            Property(u => u.Orden).HasColumnName("ORDEN");
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

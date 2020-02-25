using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Contrato Parrafo Variable
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ContratoParrafoVariableMapping : BaseEntityMapping<ContratoParrafoVariableEntity>
    {
        public ContratoParrafoVariableMapping()
            :base()
        {
            HasKey(x => x.CodigoContratoParrafoVariable).ToTable("CONTRATO_PARRAFO_VARIABLE","CTR");
            Property(u => u.CodigoContratoParrafo).HasColumnName("CODIGO_CONTRATO_PARRAFO");
            Property(u => u.CodigoVariable).HasColumnName("CODIGO_VARIABLE");
            Property(u => u.ValorTexto).HasColumnName("VALOR_TEXTO");
            Property(u => u.ValorNumero).HasColumnName("VALOR_NUMERO");
            Property(u => u.ValorFecha).HasColumnName("VALOR_FECHA");
            Property(u => u.ValorImagen).HasColumnName("VALOR_IMAGEN");
            Property(u => u.ValorTabla).HasColumnName("VALOR_TABLA");
            Property(u => u.ValorTablaEditable).HasColumnName("VALOR_TABLA_EDITABLE");
            Property(u => u.ValorBien).HasColumnName("VALOR_BIEN");
            Property(u => u.ValorBienEditable).HasColumnName("VALOR_BIEN_EDITABLE");
            Property(u => u.ValorFirmante).HasColumnName("VALOR_FIRMANTE");
            Property(u => u.ValorFirmanteEditable).HasColumnName("VALOR_FIRMANTE_EDITABLE");
            Property(u => u.ValorLista).HasColumnName("VALOR_LISTA");
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

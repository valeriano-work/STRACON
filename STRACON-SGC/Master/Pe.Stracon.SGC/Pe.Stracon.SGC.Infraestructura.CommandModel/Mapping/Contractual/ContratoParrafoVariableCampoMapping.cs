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
    public class ContratoParrafoVariableCampoMapping: BaseEntityMapping<ContratoParrafoVariableCampoEntity>
    {
        public ContratoParrafoVariableCampoMapping()
            :base()
        {
            HasKey(x => x.CodigoContratoParrafoVariableCampo).ToTable("CONTRATO_PARRAFO_VARIABLE_CAMPO","CTR");
            Property(u => u.CodigoContratoParrafoVariable).HasColumnName("CODIGO_CONTRATO_PARRAFO_VARIABLE");
            Property(u => u.CodigoVariableCampo).HasColumnName("CODIGO_VARIABLE_CAMPO");
            Property(u => u.NumeroFila).HasColumnName("NUMERO_FILA");
            Property(u => u.Valor).HasColumnName("VALOR");
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

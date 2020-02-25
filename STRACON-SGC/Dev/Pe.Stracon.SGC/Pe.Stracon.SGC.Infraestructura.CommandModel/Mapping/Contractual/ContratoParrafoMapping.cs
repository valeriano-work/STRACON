using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Contrato Parrafo
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ContratoParrafoMapping : BaseEntityMapping<ContratoParrafoEntity>
    {
        public ContratoParrafoMapping()
            :base()
        {
            HasKey(x => x.CodigoContratoParrafo).ToTable("CONTRATO_PARRAFO","CTR");
            Property(u => u.CodigoContratoParrafo).HasColumnName("CODIGO_CONTRATO_PARRAFO");
            Property(u => u.CodigoContrato).HasColumnName("CODIGO_CONTRATO");
            Property(u => u.CodigoPlantillaParrafo).HasColumnName("CODIGO_PLANTILLA_PARRAFO");
            Property(u => u.ContenidoParrafo).HasColumnName("CONTENIDO");
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

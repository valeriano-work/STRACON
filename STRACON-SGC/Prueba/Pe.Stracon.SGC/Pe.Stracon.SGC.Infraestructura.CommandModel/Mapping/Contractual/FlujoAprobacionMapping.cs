using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;


namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Flujo Aprobacion
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150511 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class FlujoAprobacionMapping : BaseEntityMapping<FlujoAprobacionEntity>
    {
        public FlujoAprobacionMapping()
            :base()
        {
            HasKey(x => x.CodigoFlujoAprobacion).ToTable("FLUJO_APROBACION", "CTR");
            Property(u => u.CodigoFlujoAprobacion).HasColumnName("CODIGO_FLUJO_APROBACION");
            Property(u => u.CodigoUnidadOperativa).HasColumnName("CODIGO_UNIDAD_OPERATIVA");
            Property(u => u.IndicadorAplicaMontoMinimo).HasColumnName("INDICADOR_APLICA_MONTO_MINIMO");
            Property(u => u.CodigoPrimerFirmante).HasColumnName("CODIGO_PRIMER_FIRMANTE");
            Property(u => u.CodigoSegundoFirmante).HasColumnName("CODIGO_SEGUNDO_FIRMANTE");
            Property(u => u.CodigoPrimerFirmanteOriginal).HasColumnName("CODIGO_PRIMER_FIRMANTE_ORIGINAL");
            Property(u => u.CodigoSegundoFirmanteOriginal).HasColumnName("CODIGO_SEGUNDO_FIRMANTE_ORIGINAL");
            Property(u => u.EstadoRegistro).HasColumnName("ESTADO_REGISTRO");
            Property(u => u.UsuarioCreacion).HasColumnName("USUARIO_CREACION");
            Property(u => u.FechaCreacion).HasColumnName("FECHA_CREACION");
            Property(u => u.TerminalCreacion).HasColumnName("TERMINAL_CREACION");
            Property(u => u.UsuarioModificacion).HasColumnName("USUARIO_MODIFICACION");
            Property(u => u.FechaModificacion).HasColumnName("FECHA_MODIFICACION");
            Property(u => u.TerminalModificacion).HasColumnName("TERMINAL_MODIFICACION");
            Property(u => u.CodigoPrimerFirmanteVinculada).HasColumnName("CODIGO_PRIMER_FIRMANTE_VINCULADA");
            Property(u => u.CodigoSegundoFirmanteVinculada).HasColumnName("CODIGO_SEGUNDO_FIRMANTE_VINCULADA");
        }
    }
}

using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Contrato
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ContratoMapping : BaseEntityMapping<ContratoEntity>
    {
        public ContratoMapping()
            : base()
        {
            HasKey(x => x.CodigoContrato).ToTable("CONTRATO", "CTR");
            Property(u => u.CodigoContrato).HasColumnName("CODIGO_CONTRATO");
            Property(u => u.CodigoUnidadOperativa).HasColumnName("CODIGO_UNIDAD_OPERATIVA");
            Property(u => u.CodigoProveedor).HasColumnName("CODIGO_PROVEEDOR");
            Property(u => u.NumeroContrato).HasColumnName("NUMERO_CONTRATO");
            Property(u => u.Descripcion).HasColumnName("DESCRIPCION");
            Property(u => u.NumeroAdenda).HasColumnName("NUMERO_ADENDA");
            Property(u => u.NumeroAdendaConcatenado).HasColumnName("NUMERO_ADENDA_CONCATENADO");
            Property(u => u.CodigoTipoServicio).HasColumnName("CODIGO_TIPO_SERVICIO");
            Property(u => u.CodigoTipoRequerimiento).HasColumnName("CODIGO_TIPO_REQUERIMIENTO");
            Property(u => u.CodigoTipoDocumento).HasColumnName("CODIGO_TIPO_DOCUMENTO");
            Property(u => u.IndicadorVersionOficial).HasColumnName("INDICADOR_VERSION_OFICIAL");
            Property(u => u.FechaInicioVigencia).HasColumnName("FECHA_INICIO_VIGENCIA");
            Property(u => u.FechaFinVigencia).HasColumnName("FECHA_FIN_VIGENCIA");
            Property(u => u.CodigoMoneda).HasColumnName("CODIGO_MONEDA");
            Property(u => u.MontoContrato).HasColumnName("MONTO_CONTRATO");
            Property(u => u.MontoAcumulado).HasColumnName("MONTO_ACUMULADO");
            Property(u => u.CodigoEstado).HasColumnName("CODIGO_ESTADO");
            Property(u => u.CodigoPlantilla).HasColumnName("CODIGO_PLANTILLA");
            Property(u => u.CodigoContratoPrincipal).HasColumnName("CODIGO_CONTRATO_PRINCIPAL");
            Property(u => u.CodigoEstadoEdicion).HasColumnName("CODIGO_ESTADO_EDICION");
            Property(u => u.ComentarioModificacion).HasColumnName("COMENTARIO_MODIFICACION");
            Property(u => u.RespuestaModificacion).HasColumnName("RESPUESTA_MODIFICACION");
            Property(u => u.CodigoFlujoAprobacion).HasColumnName("CODIGO_FLUJO_APROBACION");
            Property(u => u.CodigoEstadioActual).HasColumnName("CODIGO_ESTADIO_ACTUAL");
            Property(u => u.EstadoRegistro).HasColumnName("ESTADO_REGISTRO");
            Property(u => u.UsuarioCreacion).HasColumnName("USUARIO_CREACION");
            Property(u => u.FechaCreacion).HasColumnName("FECHA_CREACION");
            Property(u => u.TerminalCreacion).HasColumnName("TERMINAL_CREACION");
            Property(u => u.UsuarioModificacion).HasColumnName("USUARIO_MODIFICACION");
            Property(u => u.FechaModificacion).HasColumnName("FECHA_MODIFICACION");
            Property(u => u.TerminalModificacion).HasColumnName("TERMINAL_MODIFICACION");
            Property(u => u.EsFlexible).HasColumnName("ES_FLEXIBLE");
            Property(u => u.EsCorporativo).HasColumnName("ES_CORPORATIVO");
            Property(u => u.CodigoContratoOriginal).HasColumnName("CODIGO_CONTRATO_ORIGINAL");
        }
    }
}

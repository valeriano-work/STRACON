using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Contrato Estadio Observación
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ContratoEstadioObservacionMapping : BaseEntityMapping<ContratoEstadioObservacionEntity>
    {
        public ContratoEstadioObservacionMapping()
            :base()
        {
            HasKey(x => x.CodigoContratoEstadioObservacion).ToTable("CONTRATO_ESTADIO_OBSERVACION","CTR");
            Property(u => u.CodigoContratoEstadioObservacion).HasColumnName("CODIGO_CONTRATO_ESTADIO_OBSERVACION");
            Property(u => u.CodigoContratoEstadio).HasColumnName("CODIGO_CONTRATO_ESTADIO");
            Property(u => u.Descripcion).HasColumnName("DESCRIPCION");
            Property(u => u.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            Property(u => u.CodigoContratoParrafo).HasColumnName("CODIGO_CONTRATO_PARRAFO");
            Property(u => u.CodigoArchivo).HasColumnName("CODIGO_ARCHIVO");
            Property(u => u.RutaArchivoSharepoint).HasColumnName("RUTA_ARCHIVO_SHAREPOINT");
            Property(u => u.CodigoEstadioRetorno).HasColumnName("CODIGO_ESTADIO_RETORNO");
            Property(u => u.Destinatario).HasColumnName("DESTINATARIO");
            Property(u => u.CodigoTipoRespuesta).HasColumnName("CODIGO_TIPO_RESPUESTA");
            Property(u => u.Respuesta).HasColumnName("RESPUESTA");
            Property(u => u.FechaRespuesta).HasColumnName("FECHA_RESPUESTA");
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

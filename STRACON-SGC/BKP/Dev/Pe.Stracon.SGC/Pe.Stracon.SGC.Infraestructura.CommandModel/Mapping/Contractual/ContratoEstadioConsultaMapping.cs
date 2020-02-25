using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Contrato Estadio Consulta 
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ContratoEstadioConsultaMapping : BaseEntityMapping<ContratoEstadioConsultaEntity>
    {
        public ContratoEstadioConsultaMapping()
            :base()
        {
            HasKey(x => x.CodigoContratoEstadioConsulta).ToTable("CONTRATO_ESTADIO_CONSULTA","CTR");
            Property(u => u.CodigoContratoEstadioConsulta).HasColumnName("CODIGO_CONTRATO_ESTADIO_CONSULTA");
            Property(u => u.CodigoContratoEstadio).HasColumnName("CODIGO_CONTRATO_ESTADIO");
            Property(u => u.Descripcion).HasColumnName("DESCRIPCION");
            Property(u => u.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            Property(u => u.CodigoContratoParrafo).HasColumnName("CODIGO_CONTRATO_PARRAFO");
            Property(u => u.Destinatario).HasColumnName("DESTINATARIO");
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

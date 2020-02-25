using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Contrato Estadio
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ContratoEstadioMapping : BaseEntityMapping<ContratoEstadioEntity>
    {
        public ContratoEstadioMapping()
            :base()
        {
            HasKey(x => x.CodigoContratoEstadio).ToTable("CONTRATO_ESTADIO","CTR");
            Property(u => u.CodigoContratoEstadio).HasColumnName("CODIGO_CONTRATO_ESTADIO");
            Property(u => u.CodigoContrato).HasColumnName("CODIGO_CONTRATO");
            Property(u => u.CodigoFlujoAprobacionEstadio).HasColumnName("CODIGO_FLUJO_APROBACION_ESTADIO");
            Property(u => u.FechaIngreso).HasColumnName("FECHA_INGRESO");
            Property(u => u.FechaFinalizacion).HasColumnName("FECHA_FINALIZACION");
            Property(u => u.CodigoResponsable).HasColumnName("CODIGO_RESPONSABLE");
            Property(u => u.CodigoEstadoContratoEstadio).HasColumnName("CODIGO_ESTADO_CONTRATO_ESTADIO");
            Property(u => u.FechaPrimeraNotificacion).HasColumnName("FECHA_PRIMERA_NOTIFICACION");
            Property(u => u.FechaUltimaNotificacion).HasColumnName("FECHA_ULTIMA_NOTIFICACION");
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

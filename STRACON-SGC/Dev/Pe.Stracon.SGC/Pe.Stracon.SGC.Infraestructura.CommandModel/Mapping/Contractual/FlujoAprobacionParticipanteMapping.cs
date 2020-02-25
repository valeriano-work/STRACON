using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;


namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Flujo Aprobacion Participante
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150511 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class FlujoAprobacionParticipanteMapping : BaseEntityMapping<FlujoAprobacionParticipanteEntity>
    {
        public FlujoAprobacionParticipanteMapping()
            :base()
        {
            HasKey(x => x.CodigoFlujoAprobacionParticipante).ToTable("FLUJO_APROBACION_PARTICIPANTE", "CTR");
            Property(u => u.CodigoFlujoAprobacionParticipante).HasColumnName("CODIGO_FLUJO_APROBACION_PARTICIPANTE");
            Property(u => u.CodigoFlujoAprobacionEstadio).HasColumnName("CODIGO_FLUJO_APROBACION_ESTADIO");
            Property(u => u.CodigoTrabajador).HasColumnName("CODIGO_TRABAJADOR");
            Property(u => u.CodigoTrabajadorOriginal).HasColumnName("CODIGO_TRABAJADOR_ORIGINAL");
            Property(u => u.CodigoTipoParticipante).HasColumnName("CODIGO_TIPO_PARTICIPANTE");
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

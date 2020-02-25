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
    public class ProcesoAuditoriaMapping : BaseEntityMapping<ProcesoAuditoriaEntity>
    {
        public ProcesoAuditoriaMapping()
            :base()
        {
            HasKey(x => x.CodigoAuditoria).ToTable("AUDITORIA", "CTR");
            Property(u => u.CodigoAuditoria).HasColumnName("CODIGO_AUDITORIA");
            Property(u => u.CodigoUnidadOperativa).HasColumnName("CODIGO_UNIDAD_OPERATIVA");
            Property(u => u.FechaPlanificada).HasColumnName("FECHA_PLANIFICADA");
            Property(u => u.FechaEjecucion).HasColumnName("FECHA_EJECUCION");
            Property(u => u.CantidadAuditadas).HasColumnName("CANTIDAD_AUDITADAS");
            Property(u => u.CantidadObservadas).HasColumnName("CANTIDAD_OBSERVADAS");
            Property(u => u.ResultadoAuditoria).HasColumnName("RESULTADO_AUDITORIA");
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

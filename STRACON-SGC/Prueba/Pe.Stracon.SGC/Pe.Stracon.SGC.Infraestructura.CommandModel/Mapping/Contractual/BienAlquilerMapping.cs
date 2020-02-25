using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Bien Alquiler
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class BienAlquilerMapping : BaseEntityMapping<BienAlquilerEntity>
    {
        public BienAlquilerMapping()
            :base()
        {
            HasKey(x => x.CodigoBienAlquiler).ToTable("BIEN_ALQUILER", "CTR");
            Property(u => u.CodigoBienAlquiler).HasColumnName("CODIGO_BIEN_ALQUILER");
            Property(u => u.CodigoBien).HasColumnName("CODIGO_BIEN");
            Property(u => u.IndicadorSinLimite).HasColumnName("INDICADOR_SIN_LIMITE");
            Property(u => u.CantidadLimite).HasColumnName("CANTIDAD_LIMITE");
            Property(u => u.EstadoRegistro).HasColumnName("ESTADO_REGISTRO");
            Property(u => u.UsuarioCreacion).HasColumnName("USUARIO_CREACION");
            Property(u => u.FechaCreacion).HasColumnName("FECHA_CREACION");
            Property(u => u.TerminalCreacion).HasColumnName("TERMINAL_CREACION");
            Property(u => u.UsuarioModificacion).HasColumnName("USUARIO_MODIFICACION");
            Property(u => u.FechaModificacion).HasColumnName("FECHA_MODIFICACION");
            Property(u => u.TerminalModificacion).HasColumnName("TERMINAL_MODIFICACION");
            Property(u => u.Monto).HasColumnName("MONTO");
        }
    }
}

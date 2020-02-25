using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.Mapping.General
{
    /// <summary>
    /// Implementación del mapeo de la entidad zona horaria
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ZonaHorariaMapping : BaseEntityMapping<ZonaHorariaEntity>
    {
        /// <summary>
        /// Constuctor del Mapping de Zona Horaria
        /// </summary>
        public ZonaHorariaMapping()
            : base()
        {
            HasKey(x => x.Codigo).ToTable("ZONA_HORARIA", "GRL");
            Property(u => u.Codigo).HasColumnName("CODIGO_ZONA_HORARIA");
            Property(u => u.HoraUTC).HasColumnName("HORA_UTC");
            Property(u => u.MinutoUTC).HasColumnName("MINUTO_UTC");
            Property(u => u.Descripcion).HasColumnName("DESCRIPCION");
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

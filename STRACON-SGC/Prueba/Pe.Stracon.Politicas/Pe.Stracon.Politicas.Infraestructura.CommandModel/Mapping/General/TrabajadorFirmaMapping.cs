using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.Mapping.General
{
    /// <summary>
    /// Implementación del mapeo de la entidad trabajador firma.
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150326 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorFirmaMapping : BaseEntityMapping<TrabajadorFirmaEntity>
    {
        /// <summary>
        /// Constuctor del Mapping de Trabajador Firma
        /// </summary>
        public TrabajadorFirmaMapping()
            : base()
        {
            HasKey(x => x.Codigo).ToTable("TRABAJADOR_FIRMA", "GRL");
            Property(u => u.Codigo).HasColumnName("CODIGO_FIRMA");
            Property(u => u.CodigoTrabajador).HasColumnName("CODIGO_TRABAJADOR");
            Property(u => u.Firma).HasColumnName("FIRMA_TRABAJADOR");
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

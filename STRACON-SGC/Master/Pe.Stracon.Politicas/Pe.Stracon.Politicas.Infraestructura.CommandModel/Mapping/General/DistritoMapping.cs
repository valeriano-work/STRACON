using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.Mapping.General
{
    /// <summary>
    /// Implementación del mapeo de la entidad distrito
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class DistritoMapping : BaseEntityMapping<DistritoEntity>
    {
        /// <summary>
        /// Constuctor del Mapping de Distrito
        /// </summary>
        public DistritoMapping()
            : base()
        {
            HasKey(x => x.Codigo).ToTable("DISTRITO", "GRL");
            Property(u => u.Codigo).HasColumnName("CODIGO_DISTRITO");
            Property(u => u.CodigoPronvicia).HasColumnName("CODIGO_PROVINCIA");
            Property(u => u.CodigoUbigeo).HasColumnName("CODIGO_UBIGEO");
            Property(u => u.Nombre).HasColumnName("NOMBRE");            
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

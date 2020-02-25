using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Bien Registro
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class BienRegistroMapping: BaseEntityMapping<BienRegistroEntity>
    {
        public BienRegistroMapping()
            :base()
        {
            HasKey(x => x.CodigoBienRegistro).ToTable("BIEN_REGISTRO", "HST");
            Property(u => u.CodigoBienRegistro).HasColumnName("CODIGO_BIEN_REGISTRO");
            Property(u => u.CodigoTipoContenido).HasColumnName("CODIGO_TIPO_CONTENIDO");
            Property(u => u.Contenido).HasColumnName("CONTENIDO");
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

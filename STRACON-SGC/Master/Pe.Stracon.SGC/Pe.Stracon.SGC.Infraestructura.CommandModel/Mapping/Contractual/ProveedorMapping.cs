using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Proveedor
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ProveedorMapping : BaseEntityMapping<ProveedorEntity>
    {
        public ProveedorMapping()
            :base()
        {
            HasKey(x => x.CodigoProveedor).ToTable("PROVEEDOR", "CTR");
            Property(u => u.CodigoProveedor).HasColumnName("CODIGO_PROVEEDOR");
            Property(u => u.CodigoIdentificacion).HasColumnName("CODIGO_IDENTIFICACION");
            Property(u => u.Nombre).HasColumnName("NOMBRE");
            Property(u => u.NombreComercial).HasColumnName("NOMBRE_COMERCIAL");
            Property(u => u.TipoDocumento).HasColumnName("TIPO_DOCUMENTO");
            Property(u => u.NumeroDocumento).HasColumnName("NUMERO_DOCUMENTO");
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

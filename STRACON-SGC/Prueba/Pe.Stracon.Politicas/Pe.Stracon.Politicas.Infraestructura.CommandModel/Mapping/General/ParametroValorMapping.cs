using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.Mapping.General
{
    /// <summary>
    /// Implementación del mapeo de la entidad parámetro valor
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroValorMapping : BaseEntityMapping<ParametroValorEntity>
    {
        /// <summary>
        /// Constuctor del Mapping de Parametro Valor
        /// </summary>
        public ParametroValorMapping()
            : base()
        {
            HasKey(x => new{ x.CodigoParametro, x.CodigoSeccion, x.CodigoValor}).ToTable("PARAMETRO_VALOR", "GRL");
            Property(u => u.CodigoParametro).HasColumnName("CODIGO_PARAMETRO").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnOrder(1);
            Property(u => u.CodigoSeccion).HasColumnName("CODIGO_SECCION").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnOrder(2);
            Property(u => u.CodigoValor).HasColumnName("CODIGO_VALOR").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnOrder(3);
            Property(u => u.Valor).HasColumnName("VALOR");
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

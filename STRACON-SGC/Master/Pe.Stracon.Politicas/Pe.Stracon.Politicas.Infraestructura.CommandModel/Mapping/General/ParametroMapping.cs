using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.Mapping.General
{
    /// <summary>
    /// Implementación del mapeo de la entidad parámetro
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroMapping : BaseEntityMapping<ParametroEntity>
    {
        /// <summary>
        /// Constuctor del Mapping de Parámetro
        /// </summary>
        public ParametroMapping()
            : base()
        {
            HasKey(x => x.CodigoParametro).ToTable("PARAMETRO", "GRL");
            Property(u => u.CodigoParametro).HasColumnName("CODIGO_PARAMETRO").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnOrder(1);
            Property(u => u.CodigoEmpresa).HasColumnName("CODIGO_EMPRESA");
            Property(u => u.CodigoSistema).HasColumnName("CODIGO_SISTEMA");
            Property(u => u.CodigoIdentificador).HasColumnName("CODIGO_IDENTIFICADOR");
            Property(u => u.IndicadorEmpresa).HasColumnName("INDICADOR_EMPRESA");
            Property(u => u.Nombre).HasColumnName("NOMBRE");
            Property(u => u.Descripcion).HasColumnName("DESCRIPCION");            
            Property(u => u.IndicadorPermiteAgregar).HasColumnName("INDICADOR_PERMITE_AGREGAR");
            Property(u => u.IndicadorPermiteModificar).HasColumnName("INDICADOR_PERMITE_MODIFICAR");
            Property(u => u.IndicadorPermiteEliminar).HasColumnName("INDICADOR_PERMITE_ELIMINAR");
            Property(u => u.TipoParametro).HasColumnName("TIPO_PARAMETRO");
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

using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.Mapping.General
{
    /// <summary>
    /// Implementación del mapeo de la entidad parámetro sección
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroSeccionMapping : BaseEntityMapping<ParametroSeccionEntity>
    {
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public ParametroSeccionMapping()
            : base()
        {
            HasKey(x => new { x.CodigoParametro, x.CodigoSeccion }).ToTable("PARAMETRO_SECCION", "GRL");
            Property(u => u.CodigoParametro).HasColumnName("CODIGO_PARAMETRO").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnOrder(1);
            Property(u => u.CodigoSeccion).HasColumnName("CODIGO_SECCION").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).HasColumnOrder(2);
            Property(u => u.Nombre).HasColumnName("NOMBRE");
            Property(u => u.CodigoTipoDato).HasColumnName("CODIGO_TIPO_DATO");
            Property(u => u.IndicadorPermiteModificar).HasColumnName("INDICADOR_PERMITE_MODIFICAR");
            Property(u => u.IndicadorObligatorio).HasColumnName("INDICADOR_OBLIGATORIO");
            Property(u => u.IndicadorSistema).HasColumnName("INDICADOR_SISTEMA");
            Property(u => u.CodigoParametroRelacionado).HasColumnName("CODIGO_PARAMETRO_RELACIONADO");
            Property(u => u.CodigoSeccionRelacionado).HasColumnName("CODIGO_SECCION_RELACIONADO");
            Property(u => u.CodigoSeccionRelacionadoMostrar).HasColumnName("CODIGO_SECCION_RELACIONADO_MOSTRAR");
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

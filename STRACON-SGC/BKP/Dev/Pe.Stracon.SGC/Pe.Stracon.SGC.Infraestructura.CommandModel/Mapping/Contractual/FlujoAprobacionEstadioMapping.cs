using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;


namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Flujo Aprobacion Estadio
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150511 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class FlujoAprobacionEstadioMapping : BaseEntityMapping<FlujoAprobacionEstadioEntity>
    {
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public FlujoAprobacionEstadioMapping()
            :base()
        {
            HasKey(x => x.CodigoFlujoAprobacionEstadio).ToTable("FLUJO_APROBACION_ESTADIO", "CTR");
            Property(u => u.CodigoFlujoAprobacionEstadio).HasColumnName("CODIGO_FLUJO_APROBACION_ESTADIO");
            Property(u => u.CodigoFlujoAprobacion).HasColumnName("CODIGO_FLUJO_APROBACION");
            Property(u => u.Orden).HasColumnName("ORDEN");
            Property(u => u.Descripcion).HasColumnName("DESCRIPCION");
            Property(u => u.TiempoAtencion).HasColumnName("TIEMPO_ATENCION");
            Property(u => u.HorasAtencion).HasColumnName("HORAS_ATENCION");
            Property(u => u.IndicadorVersionOficial).HasColumnName("INDICADOR_VERSION_OFICIAL");
            Property(u => u.IndicadorPermiteCarga).HasColumnName("INDICADOR_PERMITE_CARGA");
            Property(u => u.IndicadorNumeroContrato).HasColumnName("INDICADOR_NUMERO_CONTRATO");
            Property(u => u.IndicadorIncluirVisto).HasColumnName("INDICADOR_INCLUIR_VISTO");
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

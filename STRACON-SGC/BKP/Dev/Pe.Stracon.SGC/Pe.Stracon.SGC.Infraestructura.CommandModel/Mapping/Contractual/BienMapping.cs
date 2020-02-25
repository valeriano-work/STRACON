using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Bien
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class BienMapping : BaseEntityMapping<BienEntity>
    {
        public BienMapping()
            : base()
        {
            HasKey(x => x.CodigoBien).ToTable("BIEN","CTR");
            Property(u => u.CodigoBien).HasColumnName("CODIGO_BIEN");
            Property(u => u.CodigoTipoBien).HasColumnName("CODIGO_TIPO_BIEN");
            Property(u => u.CodigoIdentificacion).HasColumnName("CODIGO_IDENTIFICACION");
            Property(u => u.NumeroSerie).HasColumnName("NUMERO_SERIE");
            Property(u => u.Descripcion).HasColumnName("DESCRIPCION");
            Property(u => u.Marca).HasColumnName("MARCA");
            Property(u => u.Modelo).HasColumnName("MODELO");
            Property(u => u.FechaAdquisicion).HasColumnName("FECHA_ADQUISICION");
            Property(u => u.TiempoVida).HasColumnName("TIEMPO_VIDA");
            Property(u => u.ValorResidual).HasColumnName("VALOR_RESIDUAL");
            Property(u => u.CodigoTipoTarifa).HasColumnName("CODIGO_TIPO_TARIFA");
            Property(u => u.CodigoPeriodoAlquiler).HasColumnName("CODIGO_PERIODO_ALQUILER");
            Property(u => u.ValorAlquiler).HasColumnName("VALOR_ALQUILER");
            Property(u => u.CodigoMoneda).HasColumnName("CODIGO_MONEDA");
            Property(u => u.MesInicioAlquiler).HasColumnName("MES_INICIO_ALQUILER");
            Property(u => u.AnioInicioAlquiler).HasColumnName("ANIO_INICIO_ALQUILER");
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

using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.Mapping.General
{
    /// <summary>
    /// Implementación del mapeo de la entidad unidad operativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaMapping : BaseEntityMapping<UnidadOperativaEntity>
    {
        /// <summary>
        /// Constuctor del Mapping de Unidad Operativa
        /// </summary>
        public UnidadOperativaMapping()
            : base()
        {
            HasKey(x => x.Codigo).ToTable("UNIDAD_OPERATIVA", "GRL");
            Property(u => u.Codigo).HasColumnName("CODIGO_UNIDAD_OPERATIVA");
            Property(u => u.CodigoIdentificacion).HasColumnName("CODIGO_IDENTIFICACION");

            Property(u => u.Nombre).HasColumnName("NOMBRE");
            Property(u => u.IndicadorActiva).HasColumnName("INDICADOR_ACTIVA");
            Property(u => u.CodigoNivelJerarquia).HasColumnName("CODIGO_NIVEL_JERARQUIA");
            Property(u => u.CodigoUnidadOperativaPadre).HasColumnName("CODIGO_UNIDAD_OPERATIVA_PADRE");
            Property(u => u.CodigoTipoUnidadOperativa).HasColumnName("CODIGO_TIPO_UNIDAD_OPERATIVA");
            Property(u => u.CodigoResponsable).HasColumnName("CODIGO_RESPONSABLE");
            Property(u => u.CodigoZonaHoraria).HasColumnName("CODIGO_ZONA_HORARIA");
            Property(u => u.CodigoPrimerRepresentante).HasColumnName("CODIGO_PRIMER_REPRESENTANTE");
            Property(u => u.CodigoSegundoRepresentante).HasColumnName("CODIGO_SEGUNDO_REPRESENTANTE");
            Property(u => u.CodigoTercerRepresentante).HasColumnName("CODIGO_TERCER_REPRESENTANTE");
            Property(u => u.CodigoCuartoRepresentante).HasColumnName("CODIGO_CUARTO_REPRESENTANTE");
            Property(u => u.CodigoPrimerRepresentanteOriginal).HasColumnName("CODIGO_PRIMER_REPRESENTANTE_ORIGINAL");
            Property(u => u.CodigoSegundoRepresentanteOriginal).HasColumnName("CODIGO_SEGUNDO_REPRESENTANTE_ORIGINAL");
            Property(u => u.CodigoTercerRepresentanteOriginal).HasColumnName("CODIGO_TERCER_REPRESENTANTE_ORIGINAL");
            Property(u => u.CodigoCuartoRepresentanteOriginal).HasColumnName("CODIGO_CUARTO_REPRESENTANTE_ORIGINAL");
            Property(u => u.Direccion).HasColumnName("DIRECCION");
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

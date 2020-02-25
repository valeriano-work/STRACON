using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.Mapping.General
{
    /// <summary>
    /// Implementación del mapeo de la entidad trabajador
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150326 <br />
    /// Modificación:            <br />
    /// </remarks>
    class TrabajadorMapping : BaseEntityMapping<TrabajadorEntity>
    {
        /// <summary>
        /// Constuctor del Mapping de Trabajador
        /// </summary>
        public TrabajadorMapping()
            : base()
        {
            HasKey(x => x.Codigo).ToTable("TRABAJADOR", "GRL");
            Property(u => u.Codigo).HasColumnName("CODIGO_TRABAJADOR");
            Property(u => u.CodigoIdentificacion).HasColumnName("CODIGO_IDENTIFICACION");
            Property(u => u.CodigoTipoDocumentoIdentidad).HasColumnName("CODIGO_TIPO_DOCUMENTO_IDENTIDAD");
            Property(u => u.NumeroDocumentoIdentidad).HasColumnName("NUMERO_DOCUMENTO_IDENTIDAD");
            Property(u => u.ApellidoPaterno).HasColumnName("APELLIDO_PATERNO");
            Property(u => u.ApellidoMaterno).HasColumnName("APELLIDO_MATERNO");
            Property(u => u.Nombres).HasColumnName("NOMBRES");
            Property(u => u.NombreCompleto).HasColumnName("NOMBRE_COMPLETO");
            Property(u => u.Organizacion).HasColumnName("ORGANIZACION");
            Property(u => u.Departamento).HasColumnName("DEPARTAMENTO");
            Property(u => u.Cargo).HasColumnName("CARGO");
            Property(u => u.TelefonoTrabajo).HasColumnName("TELEFONO_TRABAJO");
            Property(u => u.Anexo).HasColumnName("ANEXO");            
            Property(u => u.TelefonoMovil).HasColumnName("TELEFONO_MOVIL");
            Property(u => u.TelefonoPersonal).HasColumnName("TELEFONO_PERSONAL");
            Property(u => u.CorreoElectronico).HasColumnName("CORREO_ELECTRONICO");
            Property(u => u.CodigoUnidadOperativaMatriz).HasColumnName("CODIGO_UNIDAD_OPERATIVA_MATRIZ");
            Property(u => u.IndicadorTieneFoto).HasColumnName("INDICADOR_TIENE_FOTO");
            Property(u => u.IndicadorTodaUnidadOperativa).HasColumnName("INDICADOR_TODA_UNIDAD_OPERATIVA");
            Property(u => u.Dominio).HasColumnName("DOMINIO");
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

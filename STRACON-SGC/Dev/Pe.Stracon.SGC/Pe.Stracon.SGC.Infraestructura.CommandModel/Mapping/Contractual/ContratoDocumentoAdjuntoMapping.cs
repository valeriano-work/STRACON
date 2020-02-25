using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Mapping.Contractual
{
    /// <summary>
    /// Implementación del mapeo de la entidad Contrato Documento
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ContratoDocumentoAdjuntoMapping : BaseEntityMapping<ContratoDocumentoAdjuntoEntity>
    {
        /// <summary>
        /// Constructo de la clase
        /// </summary>
        public ContratoDocumentoAdjuntoMapping()
            :base()
        {
            HasKey(x => x.CodigoContratoDocumentoAdjunto).ToTable("CONTRATO_DOCUMENTO_ADJUNTO","CTR");
            Property(u => u.CodigoContratoDocumentoAdjunto).HasColumnName("CODIGO_CONTRATO_DOCUMENTO_ADJUNTO");
            Property(u => u.CodigoContrato).HasColumnName("CODIGO_CONTRATO");
            Property(u => u.CodigoArchivo).HasColumnName("CODIGO_ARCHIVO");
            Property(u => u.NombreArchivo).HasColumnName("NOMBRE_ARCHIVO");
            Property(u => u.RutaArchivoSharePoint).HasColumnName("RUTA_ARCHIVO_SHAREPOINT");
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

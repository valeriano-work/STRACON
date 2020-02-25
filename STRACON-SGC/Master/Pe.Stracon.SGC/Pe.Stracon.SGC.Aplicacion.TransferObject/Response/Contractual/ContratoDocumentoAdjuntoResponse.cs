using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de documentos adjuntos al contrato
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150528 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ContratoDocumentoAdjuntoResponse
    {
        /// <summary>
        /// Código del Documento adjunto al contrato
        /// </summary>
        public Guid CodigoContratoDocumentoAdjunto { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid CodigoContrato { get; set; }
        /// <summary>
        /// Código del Archivo
        /// </summary>
        public int CodigoArchivo { get; set; }
        /// <summary>
        /// Ruta de Archivo en el SharePoint
        /// </summary>
        public string RutaArchivoSharePoint { get; set; }
        /// <summary>
        /// Nombre del Archivo
        /// </summary>
        public string NombreArchivo { get; set; }
        /// <summary>
        /// Contenido del archivo
        /// </summary>
        public Object ContenidoArchivo { get; set; }
        /// <summary>
        /// Usuario de Creacion
        /// </summary>
        public string UsuarioCreacion { get; set; }
    }
}

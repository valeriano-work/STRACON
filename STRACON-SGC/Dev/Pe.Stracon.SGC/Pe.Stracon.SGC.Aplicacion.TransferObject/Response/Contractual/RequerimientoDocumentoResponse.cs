using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Requerimientos - Consultas
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150528 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class RequerimientoDocumentoResponse
    {
        /// <summary>
        /// Codigo de Requerimiento Documento
        /// </summary>
        public Guid CodigoRequerimientoDocumento { get; set; }
        /// <summary>
        /// Codigo de Requerimiento
        /// </summary>
        public Guid CodigoRequerimiento { get; set; }
        /// <summary>
        /// Número de Requerimiento
        /// </summary>
        public string NumeroRequerimiento { get; set; }
        /// <summary>
        /// Ruta de Archivo en el SharePoint
        /// </summary>
        public string RutaArchivoSharePoint { get; set; }
        /// <summary>
        /// Contenido
        /// </summary>
        public string Contenido { get; set; }
        /// <summary>
        /// Codigo de Archivo
        /// </summary>
        public int CodigoArchivo { get; set; }
        /// <summary>
        /// Indicador Actual
        /// </summary>
        public bool IndicadorActual { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        public byte Version { get; set; } 
    }
}

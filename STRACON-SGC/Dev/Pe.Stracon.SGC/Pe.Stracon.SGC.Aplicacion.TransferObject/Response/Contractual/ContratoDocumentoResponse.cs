using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Contratos - Consultas
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150528 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ContratoDocumentoResponse
    {
        /// <summary>
        /// Codigo de Contrato Documento
        /// </summary>
        public Guid CodigoContratoDocumento { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid CodigoContrato { get; set; }
        /// <summary>
        /// Número de Contrato
        /// </summary>
        public string NumeroContrato { get; set; }
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

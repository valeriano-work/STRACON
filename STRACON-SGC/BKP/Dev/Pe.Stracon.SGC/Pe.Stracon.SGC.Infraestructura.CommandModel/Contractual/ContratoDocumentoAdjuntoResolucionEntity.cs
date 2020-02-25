using System;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Contrato Documento Adjunto
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150525 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ContratoDocumentoAdjuntoResolucionEntity : Entity
    {
        /// <summary>
        /// Codigo Contrato Documento Adjunto
        /// </summary>
        public Guid CodigoContratoDocumentoAdjuntoResolucion { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid CodigoContrato { get; set; }
        /// <summary>
        /// Codigo de Archivo
        /// </summary>
        public int CodigoArchivo { get; set; }
        /// <summary>
        /// Nombre del Archivo
        /// </summary>
        public string NombreArchivo { get; set; }
        /// <summary>
        /// ruta del archivo sharepoint
        /// </summary>
        public string RutaArchivoSharePoint { get; set; }

    }
}
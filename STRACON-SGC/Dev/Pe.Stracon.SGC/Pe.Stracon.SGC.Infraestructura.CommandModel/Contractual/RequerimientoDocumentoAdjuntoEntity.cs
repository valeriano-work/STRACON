using System;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Requerimiento Documento Adjunto
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150525 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class RequerimientoDocumentoAdjuntoEntity : Entity
    {
        /// <summary>
        /// Codigo Requerimiento Documento Adjunto
        /// </summary>
        public Guid CodigoRequerimientoDocumentoAdjunto { get; set; }
        /// <summary>
        /// Codigo de Requerimiento
        /// </summary>
        public Guid CodigoRequerimiento { get; set; }
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

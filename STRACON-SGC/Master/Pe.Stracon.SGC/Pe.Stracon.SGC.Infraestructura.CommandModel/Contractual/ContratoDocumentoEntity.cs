using System;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Contrato Documento
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150525 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ContratoDocumentoEntity : Entity
    {
        /// <summary>
        /// Codigo Contrato Documento
        /// </summary>
        public Guid CodigoContratoDocumento { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid CodigoContrato { get; set; }
        /// <summary>
        /// Codigo de Archivo
        /// </summary>
        public int CodigoArchivo { get; set; }
        /// <summary>
        /// ruta del archivo sharepoint
        /// </summary>
        public string RutaArchivoSharePoint { get; set; }
        /// <summary>
        /// Indicador Actual
        /// </summary>
        public bool IndicadorActual { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        public byte Version { get; set; }
        /// <summary>
        /// Contenido del documento
        /// </summary>
        public string Contenido { get; set; }
        /// <summary>
        /// Contenido del documento de Busqueda
        /// </summary>
        public string ContenidoBusqueda { get; set; }

    }
}

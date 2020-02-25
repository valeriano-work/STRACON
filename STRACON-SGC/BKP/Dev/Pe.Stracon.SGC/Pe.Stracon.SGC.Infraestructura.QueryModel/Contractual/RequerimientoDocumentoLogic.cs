using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Requerimiento Documento
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class RequerimientoDocumentoLogic : Logic
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
        /// Codigo de Archivo
        /// </summary>
        public int CodigoArchivo { get; set; }
        /// <summary>
        /// Ruta de Archivo en el SharePoint
        /// </summary>
        public string RutaArchivoSharePoint { get; set; }
        /// <summary>
        /// Contenido
        /// </summary>
        public string Contenido { get; set; }
        /// <summary>
        /// Indicador Actual
        /// </summary>
        public bool IndicadorActual { get; set; }
        /// <summary>
        /// Version
        /// </summary>
        public byte Version { get; set; }
        /// <summary>
        /// Usuario de Creación
        /// </summary>
        public string UsuarioCreacion { get; set; }
        /// <summary>
        /// Fecha de Creación
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Terminal de Creación
        /// </summary>
        public string TerminalCreacion { get; set; }
        /// <summary>
        /// Codigo de Requerimiento Estadio
        /// </summary>
        public Guid? CodigoRequerimientoEstadio { get; set; }
    }
}

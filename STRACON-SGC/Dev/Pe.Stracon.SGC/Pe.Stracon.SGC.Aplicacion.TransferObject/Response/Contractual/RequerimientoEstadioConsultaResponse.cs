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
    public class RequerimientoEstadioConsultaResponse
    {
        /// <summary>
        /// Codigo de Requerimiento Estadio Consulta
        /// </summary>
        public Guid? CodigoRequerimientoEstadioConsulta { get; set; }
        /// <summary>
        /// Codigo Requerimiento de Estadio
        /// </summary>
        public Guid CodigoRequerimientoEstadio { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Fecha de Consulta
        /// </summary>
        public string FechaConsulta { get; set; }
        /// <summary>
        /// Codigo de Parrafo
        /// </summary>
        public Guid? CodigoRequerimientoParrafo { get; set; }
        /// <summary>
        /// Destinatario
        /// </summary>
        public Guid Destinatario { get; set; }
        /// <summary>
        /// Destinatario
        /// </summary>
        public string NombreDestinatario { get; set; }
        /// <summary>
        /// Respuesta
        /// </summary>
        public string Respuesta { get; set; }
        /// <summary>
        /// Fecha de Respuesta
        /// </summary>
        public string FechaRespuesta { get; set; }
        /// <summary>
        /// Consultante
        /// </summary>
        public Guid? Consultor { get; set; }
        /// <summary>
        /// Nombre del Consultante
        /// </summary>
        public string NombreConsultor { get; set; }

        /// <summary>
        /// Código del Requerimiento
        /// </summary>
        public Guid? CodigoRequerimiento { get; set; }
    }
}

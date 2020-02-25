using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Requerimientos - Observaciones
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150527 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class RequerimientoEstadioObservacionResponse
    {
        /// <summary>
        /// Codigo Requerimiento Estadio de Observacion
        /// </summary>
        public Guid CodigoRequerimientoEstadioObservacion { get; set; }
        /// <summary>
        /// Codigo Requerimiento de Estadio
        /// </summary>
        public Guid CodigoRequerimientoEstadio { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Fecha de Registro
        /// </summary>
        public string FechaRegistro { get; set; }
        /// <summary>
        /// Codigo de Parrafo
        /// </summary>
        public Guid? CodigoRequerimientoParrafo { get; set; }
        /// <summary>
        /// Codigo de Archivo
        /// </summary>
        public int? CodigoArchivo { get; set; }
        /// <summary>
        /// Ruta Sharepoint
        /// </summary>
        public string RutaArchivoSharepoint { get; set; }
        /// <summary>
        /// Codigo Estadio de Retorno
        /// </summary>
        public Guid? CodigoEstadioRetorno { get; set; }
        /// <summary>
        /// Destinatario
        /// </summary>
        public Guid? Destinatario { get; set; }
        /// <summary>
        /// Destinatario
        /// </summary>
        public string NombreDestinatario { get; set; }
        /// <summary>
        /// Codigo Tipo Respuesta
        /// </summary>
        public string CodigoTipoRespuesta { get; set; }
        /// <summary>
        /// Nombre Tipo Respuesta
        /// </summary>
        public string NombreTipoRespuesta { get; set; }
        /// <summary>
        /// Respuesta
        /// </summary>
        public string Respuesta { get; set; }
        /// <summary>
        /// Fecha de Respuesta
        /// </summary>
        public string FechaRespuesta { get; set; }

        /// <summary>
        /// Observador
        /// </summary>
        public string Observador { get; set; }

        /// <summary>
        /// Nombre del Observador
        /// </summary>
        public string NombreObservador { get; set; }
    }
}

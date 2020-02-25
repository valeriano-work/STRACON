using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Requerimiento estadio observación
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class RequerimientoEstadioObservacionLogic : Logic
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
        public DateTime? FechaRegistro { get; set; }
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
        /// Codigo Tipo Respuesta
        /// </summary>
        public string CodigoTipoRespuesta { get; set; }
        /// <summary>
        /// Respuesta
        /// </summary>
        public string Respuesta { get; set; }
        /// <summary>
        /// Fecha de Respuesta
        /// </summary>
        public DateTime? FechaRespuesta { get; set; }
        /// <summary>
        /// Observador
        /// </summary>
        public string Observador { get; set; }
    }
}

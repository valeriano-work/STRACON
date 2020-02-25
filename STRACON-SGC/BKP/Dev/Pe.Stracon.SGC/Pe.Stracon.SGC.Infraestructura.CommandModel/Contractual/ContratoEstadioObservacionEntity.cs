using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Contrato Estadio Observación
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150525 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ContratoEstadioObservacionEntity : Entity
    {
        /// <summary>
        /// Codigo de Contrato de Estadio de Observacion
        /// </summary>
        public Guid CodigoContratoEstadioObservacion { get; set; }
        /// <summary>
        /// Codigo Contrato de Estadio
        /// </summary>
        public Guid CodigoContratoEstadio { get; set; }
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
        public Guid? CodigoContratoParrafo { get; set; }
        /// <summary>
        /// Codigo de Archivo
        /// </summary>
        public int? CodigoArchivo { get; set; }
        /// <summary>
        /// Ruta de Archivo de Sharepoint
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
        /// Codigo Tipo de Respuesta
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
    }
}

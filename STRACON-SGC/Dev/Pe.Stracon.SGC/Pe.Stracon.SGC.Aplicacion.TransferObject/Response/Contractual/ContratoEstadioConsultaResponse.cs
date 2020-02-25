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
    public class ContratoEstadioConsultaResponse
    {
        /// <summary>
        /// Codigo de Contrato Estadio Consulta
        /// </summary>
        public Guid? CodigoContratoEstadioConsulta { get; set; }
        /// <summary>
        /// Codigo Contrato de Estadio
        /// </summary>
        public Guid CodigoContratoEstadio { get; set; }
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
        public Guid? CodigoContratoParrafo { get; set; }
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
        /// Código del Contrato
        /// </summary>
        public Guid? CodigoContrato { get; set; }
    }
}

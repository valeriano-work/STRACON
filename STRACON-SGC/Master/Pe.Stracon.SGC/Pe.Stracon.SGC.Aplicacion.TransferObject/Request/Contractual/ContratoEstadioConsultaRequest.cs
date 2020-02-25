using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request del contrato
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150528 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ContratoEstadioConsultaRequest : Filtro
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
        /// Fecha de Registro
        /// </summary>
        public DateTime FechaRegistro { get; set; }
        /// <summary>
        /// Codigo de Parrafo
        /// </summary>
        public Guid? CodigoContratoParrafo { get; set; }
        /// <summary>
        /// Destinatario
        /// </summary>
        public Guid Destinatario { get; set; }
        /// <summary>
        /// Respuesta
        /// </summary>
        public string Respuesta { get; set; }
        /// <summary>
        /// Fecha de Respuesta
        /// </summary>
        public DateTime FechaRespuesta { get; set; } 
    }
}

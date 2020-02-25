using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Consulta
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ConsultaLogic : Logic
    {
        /// <summary>
        /// Codigo de consulta
        /// </summary>
        public Guid CodigoConsulta { get; set; }
        /// <summary>
        /// Remitente
        /// </summary>
        public Guid CodigoRemitente { get; set; }
        /// <summary>
        /// Destinatario
        /// </summary>
        public Guid CodigoDestinatario { get; set; }
        /// <summary>
        /// Tipo
        /// </summary>
        public string Tipo { get; set; }
        /// <summary>
        /// Asunto
        /// </summary>
        public string Asunto { get; set; }
        /// <summary>
        /// Contenido
        /// </summary>
        public string Contenido { get; set; }
        /// <summary>
        /// Estado de consulta
        /// </summary>
        public string EstadoConsulta { get; set; }
        /// <summary>
        /// Fecha de envío
        /// </summary>
        public DateTime? FechaEnvio { get; set; }
        /// <summary>
        /// Respuesta
        /// </summary>
        public string Respuesta { get; set; }
        /// <summary>
        /// Fecha de respuesta
        /// </summary>
        public DateTime? FechaRespuesta { get; set; }
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Area
        /// </summary>
        public string CodigoArea { get; set; }
        /// <summary>
        /// Días sin respuesta
        /// </summary>
        public int DiaSinRespuesta { get; set; }
        /// <summary>
        /// Código de consulta relacionado
        /// </summary>
        public Guid? CodigoConsultaRelacionado { get; set; }
        /// <summary>
        /// Código de consulta original
        /// </summary>
        public Guid? CodigoConsultaOriginal { get; set; }
        /// <summary>
        /// Codigo de remitnte original
        /// </summary>
        public Guid? CodigoRemitenteOriginal { get; set; }
        /// <summary>
        /// Visto Remitente Original
        /// </summary>
        public bool? VistoRemitenteOriginal { get; set; }
    }
}

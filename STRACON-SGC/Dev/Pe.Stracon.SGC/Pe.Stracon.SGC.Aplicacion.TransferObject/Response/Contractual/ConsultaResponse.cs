using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Consulta
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150601 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ConsultaResponse
    {
        /// <summary>
        /// Codigo de consulta
        /// </summary>
        public Guid? CodigoConsulta { get; set; }
        /// <summary>
        /// Remitente
        /// </summary>
        public Guid CodigoRemitente { get; set; }
        /// <summary>
        /// Nombre de Remitente
        /// </summary>
        public string NombreRemitente { get; set; }
        /// <summary>
        /// Destinatario
        /// </summary>
        public Guid CodigoDestinatario { get; set; }
        /// <summary>
        /// Nombre de Destinatario
        /// </summary>
        public string NombreDestinatario { get; set; }
        /// <summary>
        /// Tipo
        /// </summary>
        public string Tipo { get; set; }
        /// <summary>
        /// Descripción tipo
        /// </summary>
        public string DescripcionTipo { get; set; }
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
        /// Descripción de Estado de consulta
        /// </summary>
        public string DescripcionEstadoConsulta { get; set; }
        /// <summary>
        /// Fecha de envío
        /// </summary>
        public DateTime? FechaEnvio { get; set; }
        /// <summary>
        /// Fecha de envío string
        /// </summary>
        public string FechaEnvioString { get; set; }
        /// <summary>
        /// Respuesta
        /// </summary>
        public string Respuesta { get; set; }
        /// <summary>
        /// Fecha de respuesta
        /// </summary>
        public DateTime? FechaRespuesta { get; set; }
        /// <summary>
        /// Fecha de respuesta string
        /// </summary>
        public string FechaRespuestaString { get; set; }
        /// <summary>
        /// Lista destinatario
        /// </summary>
        public Dictionary<string, string> ListaDestinatario { get; set; }
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Area
        /// </summary>
        public string CodigoArea { get; set; }
        /// <summary>
        /// Descripcion de área
        /// </summary>
        public string DescripcionArea { get; set; }
        /// <summary>
        /// Días sin respuesta
        /// </summary>
        public int DiaSinRespuesta { get; set; }
        /// <summary>
        /// Tipo de usuario: [R] Remitente [D] Destinatario
        /// </summary>
        public string TipoUsuario { get; set; }
        /// <summary>
        /// Código de consulta relacionado
        /// </summary>
        public Guid? CodigoConsultaRelacionado { get; set; }
        /// <summary>
        /// Remitente Original
        /// </summary>
        public string NombreRemitenteOriginal { get; set; }
        /// <summary>
        /// Codigo de remitnte original
        /// </summary>
        public Guid? CodigoRemitenteOriginal { get; set; }
        /// <summary>
        /// Lista de adjuntos de la consulta
        /// </summary>
        public List<ConsultaAdjuntoResponse> ListaAdjuntos { get; set; }
        /// <summary>
        /// Visto Remitente Original
        /// </summary>
        public bool? VistoRemitenteOriginal { get; set; }
        /// <summary>
        /// Código de consulta original
        /// </summary>
        public Guid? CodigoConsultaOriginal { get; set; }
    }
}

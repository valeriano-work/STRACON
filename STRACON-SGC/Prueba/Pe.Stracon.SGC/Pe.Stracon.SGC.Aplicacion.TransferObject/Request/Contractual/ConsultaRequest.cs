using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Consulta
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150601 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ConsultaRequest : Filtro
    {
        /// <summary>
        /// Codigo de consulta
        /// </summary>
        public string CodigoConsulta { get; set; }
        /// <summary>
        /// Remitente
        /// </summary>
        public string CodigoRemitente { get; set; }
        /// <summary>
        /// Destinatario
        /// </summary>
        public string CodigoDestinatario { get; set; }
        /// <summary>
        /// Correo de destinatario
        /// </summary>
        public string CorreoDestinatario { get; set; }
        /// <summary>
        /// Nombre del destinatario
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
        /// Fecha de envío string
        /// </summary>
        public string FechaEnvioString { get; set; }
        /// <summary>
        /// Fecha de envío 
        /// </summary>
        public DateTime FechaEnvio { get; set; }
        /// <summary>
        /// Respuesta
        /// </summary>
        public string Respuesta { get; set; }
        /// <summary>
        /// Fecha de respuesta string
        /// </summary>
        public string FechaRespuestaString { get; set; }
        /// <summary>
        /// Fecha de respuesta 
        /// </summary>
        public DateTime? FechaRespuesta { get; set; }
        /// <summary>
        /// Codigo de Unidad Operativa 
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de área
        /// </summary>
        public string CodigoArea { get; set; }
        /// <summary>
        /// Nombre de área
        /// </summary>
        public string NombreArea { get; set; }
        /// <summary>
        /// Es válido
        /// </summary>
        public bool EsValido { get; set; }
        /// <summary>
        /// Texto adicional en el contenido de la consulta
        /// </summary>
        public string Adicional { get; set; }
        /// <summary>
        /// Código de usuario de sesion
        /// </summary>
        public string CodigoUsuarioSesion { get; set; }
        /// <summary>
        /// Código de consulta relacionado
        /// </summary>
        public string CodigoConsultaRelacionado { get; set; }
        /// <summary>
        /// Lista de adjuntos
        /// </summary>
        public List<ConsultaAdjuntoRequest> ListaAdjuntos { get; set; }
    }
}

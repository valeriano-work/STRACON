using System;
namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Representa el objeto response de Plantilla Notificacion
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150401 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaNotificacionResponse
    {
        /// <summary>
        /// Código Plantilla Notificacion
        /// </summary>
        public Guid CodigoPlantillaNotificacion { get; set; }
        /// <summary>
        /// Código de Sistema
        /// </summary>
        public Guid CodigoSistema { get; set; }
        /// <summary>
        /// Código Tipo de Notificación
        /// </summary>
        public string CodigoTipoNotificacion { get; set; }
        /// <summary>
        /// Asunto
        /// </summary>
        public string Asunto { get; set; }
        /// <summary>
        /// Indicador Activa
        /// </summary>
        public bool IndicadorActiva { get; set; }
        /// <summary>
        /// Contenido
        /// </summary>
        public string Contenido { get; set; }
        /// <summary>
        /// Contenido Recortado
        /// </summary>
        public string ContenidoReCortado { get; set; }
        /// <summary>
        /// Codigo Tipo Destinatario
        /// </summary>
        public string CodigoTipoDestinatario { get; set; }
        /// <summary>
        /// Destinatario
        /// </summary>
        public string Destinatario { get; set; }
        /// <summary>
        /// Destinatario Copia
        /// </summary>
        public string DestinatarioCopia { get; set; }
    }
}

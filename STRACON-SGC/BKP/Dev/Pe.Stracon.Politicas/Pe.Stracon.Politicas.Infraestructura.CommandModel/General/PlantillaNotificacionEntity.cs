using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using System;
namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Representa el objeto entity de Plantilla Notificacion
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150401 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaNotificacionEntity : Entity
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
        /// Código del Tipo de Destinatario
        /// </summary>
        public string CodigoTipoDestinatario { get; set; }
        /// <summary>
        /// Destinatario
        /// </summary>
        public string Destinatario { get; set; }
        /// <summary>
        /// Destinatario en Copia
        /// </summary>
        public string DestinatarioCopia { get; set; }
    }
}

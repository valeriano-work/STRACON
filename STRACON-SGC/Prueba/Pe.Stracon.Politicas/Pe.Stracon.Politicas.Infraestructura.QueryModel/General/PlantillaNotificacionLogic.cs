using Pe.Stracon.Politicas.Infraestructura.QueryModel.Base;
using System;
namespace Pe.Stracon.Politicas.Infraestructura.QueryModel.General
{
    /// <summary>
    /// Representa los datos de Plantilla Notificacion
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 27032015 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaNotificacionLogic : Logic
    {
        /// <summary>
        /// CodigoPlantillaNotificacion
        /// </summary>
        public Guid CodigoPlantillaNotificacion { get; set; }
        /// <summary>
        /// CodigoSistema
        /// </summary>
        public Guid CodigoSistema { get; set; }
        /// <summary>
        /// CodigoTipoNotificacion
        /// </summary>
        public string CodigoTipoNotificacion { get; set; }
        /// <summary>
        /// Asunto
        /// </summary>
        public string Asunto { get; set; }
        /// <summary>
        /// IndicadorActiva
        /// </summary>
        public bool IndicadorActiva { get; set; }
        /// <summary>
        /// Contenido
        /// </summary>
        public string Contenido { get; set; }
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

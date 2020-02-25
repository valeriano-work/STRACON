using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General
{
    /// <summary>
    /// Representa el objeto request de Plantilla Notificacion
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150401 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaNotificacionRequest : Filtro
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PlantillaNotificacionRequest()
        {
            EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;
        }
        /// <summary>
        /// Código Plantilla Notificacion
        /// </summary>
        public string CodigoPlantillaNotificacion { get; set; }
        /// <summary>
        /// Código de Sistema
        /// </summary>
        public string CodigoSistema { get; set; }
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
        public bool? IndicadorActiva { get; set; }
        /// <summary>
        /// Indicador de Plantilla Activa
        /// </summary>
        public string IndicadorActivaFiltro { get; set; }
        /// <summary>
        /// Contenido
        /// </summary>
        public string Contenido { get; set; }
        /// <summary>
        /// Código del Tipo de Destinatario
        /// </summary>
        public string CodigoTipoDestinatario {get; set;}
        /// <summary>
        /// Destinatario
        /// </summary>
        public string Destinatario { get; set; }
        /// <summary>
        /// Destinatario en Copia
        /// </summary>
        public string DestinatarioCopia { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
    }
}

using System;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
namespace Pe.Stracon.Politicas.Aplicacion.Adapter.General
{
    /// <summary>
    /// Adaptador de Plantilla Notificacion
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public sealed class PlantillaNotificacionAdapter
    {
        /// <summary>
        /// Obtener Plantilla Notificacion Response
        /// </summary>
        /// <param name="plantillaNotificacionLogic">plantilla Notificacion Logic</param>
        /// <returns>Lista con el resultado de la operación</returns>
        public static PlantillaNotificacionResponse ObtenerPlantillaNotificacionResponse(PlantillaNotificacionLogic plantillaNotificacionLogic)
        {
            int tamanioMaximo = 50;
            PlantillaNotificacionResponse plantillaNotificacionResponse  = new PlantillaNotificacionResponse();

            plantillaNotificacionResponse.CodigoPlantillaNotificacion = plantillaNotificacionLogic.CodigoPlantillaNotificacion;
            plantillaNotificacionResponse.CodigoSistema = plantillaNotificacionLogic.CodigoSistema;
            plantillaNotificacionResponse.CodigoTipoNotificacion = plantillaNotificacionLogic.CodigoTipoNotificacion;
            plantillaNotificacionResponse.Asunto = plantillaNotificacionLogic.Asunto;
            plantillaNotificacionResponse.IndicadorActiva = plantillaNotificacionLogic.IndicadorActiva;
            plantillaNotificacionResponse.Contenido = plantillaNotificacionLogic.Contenido;
            if (plantillaNotificacionLogic.Contenido.Length > tamanioMaximo)
            {
                plantillaNotificacionResponse.ContenidoReCortado = plantillaNotificacionLogic.Contenido.Substring(0, tamanioMaximo) + "...";
            }
            else
            {
                plantillaNotificacionResponse.ContenidoReCortado = plantillaNotificacionLogic.Contenido;
            }
            plantillaNotificacionResponse.CodigoTipoDestinatario = plantillaNotificacionLogic.CodigoTipoDestinatario;
            plantillaNotificacionResponse.Destinatario = plantillaNotificacionLogic.Destinatario;
            plantillaNotificacionResponse.DestinatarioCopia = plantillaNotificacionLogic.DestinatarioCopia;

            return plantillaNotificacionResponse;
        }
        /// <summary>
        /// Registra Plantilla de Notificaciones
        /// </summary>
        /// <param name="plantillaNotificacionRequest">Plantilla Notificacion Request</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public static PlantillaNotificacionEntity RegistrarPlantillaNotificacion(PlantillaNotificacionRequest plantillaNotificacionRequest)
        {
            PlantillaNotificacionEntity plantillaNotificacionEntity = new PlantillaNotificacionEntity();

            if (plantillaNotificacionRequest.CodigoPlantillaNotificacion != null)
            {
                plantillaNotificacionEntity.CodigoPlantillaNotificacion = new Guid(plantillaNotificacionRequest.CodigoPlantillaNotificacion);
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                plantillaNotificacionEntity.CodigoPlantillaNotificacion = code;
            }

            plantillaNotificacionEntity.CodigoSistema = new Guid(plantillaNotificacionRequest.CodigoSistema);
            plantillaNotificacionEntity.CodigoTipoNotificacion = plantillaNotificacionRequest.CodigoTipoNotificacion;
            plantillaNotificacionEntity.Asunto = plantillaNotificacionRequest.Asunto;
            plantillaNotificacionEntity.IndicadorActiva = (bool)plantillaNotificacionRequest.IndicadorActiva;
            plantillaNotificacionEntity.Contenido = plantillaNotificacionRequest.Contenido;
            plantillaNotificacionEntity.CodigoTipoDestinatario = plantillaNotificacionRequest.CodigoTipoDestinatario;
            plantillaNotificacionEntity.Destinatario = plantillaNotificacionRequest.Destinatario;
            plantillaNotificacionEntity.DestinatarioCopia = plantillaNotificacionRequest.DestinatarioCopia;
            plantillaNotificacionEntity.EstadoRegistro = plantillaNotificacionRequest.EstadoRegistro;


            return plantillaNotificacionEntity;
        }
    }
}

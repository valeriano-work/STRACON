using Pe.Stracon.Politicas.Aplicacion.Adapter.General;
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.Service.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using Pe.Stracon.Politicas.Infraestructura.Core.CommandContract.General;
using Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General;
using Pe.Stracon.PoliticasCross.Core.Exception;
using System;
using System.Collections.Generic;

namespace Pe.Stracon.Politicas.Aplicacion.Service.General
{
    /// <summary>
    /// Implementación de Plantilla Notificacion 
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaNotificacionService : GenericService, IPlantillaNotificacionService
    {
        #region Parametros
        /// <summary>
        /// Repositorio de plantilla notificacion logic
        /// </summary>
        public IPlantillaNotificacionLogicRepository plantillaNotificacionLogicRepository { get; set; }
        /// <summary>
        /// Repositorio de plantilla notificacion entity
        /// </summary>
        public IPlantillaNotificacionEntityRepository plantillaNotificacionEntityRepository { get; set; }
        #endregion
        /// <summary>
        /// Realiza la busqueda de Plantilla Notificación
        /// </summary>
        /// <param name="filtro">Parametros a buscar</param>
        /// <returns>Lista de Plantillas de Notificación</returns>
        public ProcessResult<List<PlantillaNotificacionResponse>> BuscarPlantillaNotificacion(PlantillaNotificacionRequest filtro)
        {
            ProcessResult<List<PlantillaNotificacionResponse>> resultado = new ProcessResult<List<PlantillaNotificacionResponse>>();

            try
            {
                var codigoPlantillaNotificacion = (filtro.CodigoPlantillaNotificacion != null && filtro.CodigoPlantillaNotificacion !="") ? new Guid(filtro.CodigoPlantillaNotificacion) : (Guid?)null;
                var codigoSistema = (filtro.CodigoSistema != null && filtro.CodigoSistema != "") ? new Guid(filtro.CodigoSistema) : (Guid?)null;

                var lista = plantillaNotificacionLogicRepository.BuscarPlantillaNotificacion(
                    codigoPlantillaNotificacion,
                    codigoSistema,
                    filtro.CodigoTipoNotificacion,
                    filtro.Asunto,
                    filtro.IndicadorActiva,
                    filtro.Contenido,
                    filtro.EstadoRegistro);

                resultado.Result = new List<PlantillaNotificacionResponse>();

                foreach (var item in lista)
                {
                    var PlantillaNotificacion = PlantillaNotificacionAdapter.ObtenerPlantillaNotificacionResponse(item);
                    resultado.Result.Add(PlantillaNotificacion);
                }
            }
            catch (Exception e)
            {
                resultado.Result = new List<PlantillaNotificacionResponse>();
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaNotificacionService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Registra Plantilla Notificación
        /// </summary>
        /// <param name="data">data</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<PlantillaNotificacionRequest> RegistrarPlantillaNotificacion(PlantillaNotificacionRequest data)
        {
            ProcessResult<PlantillaNotificacionRequest> resultado = new ProcessResult<PlantillaNotificacionRequest>();
            try
            {
                PlantillaNotificacionEntity entidad = PlantillaNotificacionAdapter.RegistrarPlantillaNotificacion(data);
                if (data.CodigoPlantillaNotificacion == null)
                {

                }
                else
                {
                    var entidadSincronizar = plantillaNotificacionEntityRepository.GetById(entidad.CodigoPlantillaNotificacion);
                    entidadSincronizar.CodigoPlantillaNotificacion = entidad.CodigoPlantillaNotificacion;
                    entidadSincronizar.CodigoSistema = entidad.CodigoSistema;
                    entidadSincronizar.CodigoTipoNotificacion = entidad.CodigoTipoNotificacion;
                    entidadSincronizar.Asunto = entidad.Asunto;
                    entidadSincronizar.IndicadorActiva = entidad.IndicadorActiva;
                    entidadSincronizar.Contenido = entidad.Contenido;
                    entidadSincronizar.CodigoTipoDestinatario = entidad.CodigoTipoDestinatario;
                    entidadSincronizar.Destinatario = entidad.Destinatario;
                    entidadSincronizar.DestinatarioCopia = entidad.DestinatarioCopia;
                    entidadSincronizar.EstadoRegistro = entidad.EstadoRegistro;

                    plantillaNotificacionEntityRepository.Editar(entidadSincronizar);
                }

                plantillaNotificacionEntityRepository.GuardarCambios();
                resultado.Result = data;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaNotificacionService>(e);
            }

            return resultado;
        }



    }
}

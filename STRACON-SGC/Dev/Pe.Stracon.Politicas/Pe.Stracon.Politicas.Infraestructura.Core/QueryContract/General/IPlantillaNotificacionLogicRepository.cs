using Pe.Stracon.Politicas.Infraestructura.Core.Base;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using System;
using System.Collections.Generic;
namespace Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General
{
    /// <summary>
    /// Interface de Plantilla Notificación 
    /// </summary>
    /// <remarks>
    /// Creación:   GMD <br />
    /// Modificación:            <br />
    /// </remarks>
    public interface IPlantillaNotificacionLogicRepository : IQueryRepository<PlantillaNotificacionLogic>
    {
        /// <summary>
        /// Realiza la busqueda de Plantilla 
        /// </summary>
        /// <param name="codigoPlantillaNotificacion">Código Plantilla Notificacion</param>
        /// <param name="codigoSistema">Código Sistema</param>
        /// <param name="codigoTipoNotificacion">Código Tipo Notificacion</param>
        /// <param name="asunto">Asunto</param>
        /// <param name="indicadorActiva">Indicador Activa</param>
        /// <param name="contenido">Contenido</param>
        /// <param name="estadoRegistro">Estado Registro</param>
        /// <returns>Lista con el resultado de la operación</returns>
        List<PlantillaNotificacionLogic> BuscarPlantillaNotificacion(
            Guid? codigoPlantillaNotificacion,
            Guid? codigoSistema,
            string codigoTipoNotificacion,
            string asunto,
            bool? indicadorActiva,
            string contenido,
            string estadoRegistro
        );
    }
}

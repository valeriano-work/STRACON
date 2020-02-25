using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using System;
using System.Collections.Generic;

namespace Pe.Stracon.SGC.Application.Core.ServiceContract
{
    public interface IFlujoAprobacionService : IGenericService
    {
        /// <summary>
        /// Busca Bandeja Flujo Aprobacion
        /// </summary>
        /// <param name="filtro">campos de busqueda</param>
        /// <returns>Clase Flujo aprobacion con los datos de busqueda</returns>
        ProcessResult<List<FlujoAprobacionResponse>> BuscarBandejaFlujoAprobacion(FlujoAprobacionRequest filtro);
        /// <summary>
        /// Registra o Actualiza un Flujo Aprobacion
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<FlujoAprobacionRequest> RegistrarFlujoAprobacion(FlujoAprobacionRequest data);

        /// <summary>
        /// Eliminar una o muchas actividades de flujo de aprobacion
        /// </summary>
        /// <param name="listaCodigoFlujoAprobacion">Lista de códigos a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> EliminarFlujoAprobacion(List<Object> listaCodigoFlujoAprobacion);

        /// <summary>
        /// Busca Bandeja Flujo Aprobacion Estadio
        /// </summary>
        /// <param name="filtro">campos de busqueda</param>
        /// <returns>Clase Flujo aprobacion con los datos de busqueda</returns>
        ProcessResult<List<FlujoAprobacionEstadioResponse>> BuscarBandejaFlujoAprobacionEstadio(string CodigoFlujoAprobacionEstadio = null, string CodigoFlujoAprobacion = null, bool obtenerInformacionRepresentante = false);
              
        /// <summary>
        /// Registra / Edita Flujo Aprobacion Estadios
        /// </summary>
        /// <param name="data">Datos de estadio</param>
        /// <param name="responsable">Responsable de estadio</param>
        /// <param name="informados">Informados de estadio</param>
        /// <param name="responsableVinculadas">Responsable de vinculadas</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<FlujoAprobacionEstadioRequest> RegistrarFlujoAprobacionEstadio(FlujoAprobacionEstadioRequest data, List<FlujoAprobacionEstadioRequest> responsable, List<FlujoAprobacionEstadioRequest> informados, List<FlujoAprobacionEstadioRequest> responsableVinculadas);

        /// <summary>
        /// Eliminar una o muchas actividades de flujo de aprobacion estadio
        /// </summary>
        /// <param name="listaCodigoFlujoAprobacion">Lista de códigos a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> EliminarFlujoAprobacionEstadio(List<Object> listaCodigoFlujoAprobacionEstadio);

        ///// <summary>
        ///// Copia Estadio
        ///// </summary>
        ///// <param name="data">Datos a Copiar</param>
        ///// <returns>Indicador con el resultado de la operación</returns>
        //ProcessResult<List<FlujoAprobacionEstadioResponse>> CopiarEstadio(FlujoAprobacionRequest data);

        /// <summary>
        /// Busca Bandeja Flujo Aprobacion participante
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <returns>Registros de flujo aprobacion participante</returns>
        ProcessResult<List<FlujoAprobacionParticipanteResponse>> BuscarFlujoAprobacionParticipante(FlujoAprobacionRequest filtro);

        /// <summary>
        /// Busca los Estadios de Flujo de Aprobación Estadio
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Clase Flujo aprobación con los datos de busqueda</returns>
        ProcessResult<List<FlujoAprobacionEstadioResponse>> BuscarFlujoAprobacionEstadioDescripcion(FlujoAprobacionEstadioRequest filtro);

        /// <summary>
        /// Actualiza el reemplazo al trabajador original
        /// </summary>
        /// <param name="codigoTrabajador">Codigo de trabajador</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<string> ActualizarTrabajadorOriginalFlujo(Guid codigoTrabajador);
    }
}

using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using System;
using System.Collections.Generic;

namespace Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract
{
    /// <summary>
    /// Definición de servicios para Trabajador
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public interface ITrabajadorService : IGenericService
    {
        /// <summary>
        /// Búsqueda de Trabajador
        /// </summary>
        /// <param name="filtro">Trabajador Request</param>
        /// <returns>Lista con registros</returns>
        ProcessResult<List<TrabajadorResponse>> BuscarTrabajador(TrabajadorRequest filtro);

        /// <summary>
        /// Lista registros de trabajadores a partir de códigos.
        /// </summary>
        /// <param name="listaCodigos">Lista de códigos de trabajadores</param>
        /// <returns>Listas de trabajadores</returns>
        ProcessResult<List<TrabajadorResponse>> ListarTrabajadores(List<Guid?> listaCodigos);

        /// <summary>
        /// Registrar Trabajador
        /// </summary>
        /// <param name="data">Trabajador Response</param>
        /// <returns>Identificador con resultado</returns>
        ProcessResult<TrabajadorRequest> RegistrarTrabajador(TrabajadorRequest data);

        /// <summary>
        /// Eliminar el registro de trabajadores.
        /// </summary>
        /// <param name="listaTrabajadores">Lista de trabajadores</param>
        /// <returns>Resultado de la operación</returns>
        /// <returns>Identificador con resultado</returns>
        ProcessResult<TrabajadorRequest> EliminarTrabajador(List<TrabajadorRequest> listaTrabajadores);

        /// <summary>
        /// Búsqueda de Trabajador
        /// </summary>
        /// <param name="filtro">Trabajador Request</param>
        /// <returns>Lista con registros</returns>
        ProcessResult<List<TrabajadorDatoMinimoResponse>> BuscarTrabajadorDatoMinimo(TrabajadorRequest filtro);

        /// <summary>
        /// Búsqueda de la firma de un Trabajador.
        /// </summary>
        /// <param name="trabajador">Trabajador Request</param>
        /// <returns>Lista con Firma Trabajador</returns>
        ProcessResult<TrabajadorResponse> BuscarFirmaTrabajador(TrabajadorRequest trabajador);
        
        /// <summary>
        /// Registrar la firma de un Trabajador.
        /// </summary>
        /// <param name="trabajador">Trabajador Request</param>
        /// <returns>Identificador con resultado</returns>
        ProcessResult<TrabajadorResponse> RegistrarFirmaTrabajador(TrabajadorRequest trabajador);

        /// <summary>
        /// Notificar inicios y cierres de periodo.
        /// </summary>
        /// <param name="listaTrabajadores">Lista de trabajaores</param>
        /// <param name="CodigoNotificar">tipo de notificacion</param>
        /// <param name="AnioPeriodo">Anio de Periodo</param>
        /// <param name="MesPeriodo"> Mes del Periodo </param>
        /// <param name="codigoSistema">Código del sistema</param>
        /// <param name="profileCorreo">Perfil de la cuenta que ejecuta la notificación.</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> NotificaParticipanteCalendarizacion(List<Guid?> listaTrabajadores, string CodigoNotificar, string AnioPeriodo,
                                                                        string MesPeriodo, string NombreActividad, Guid codigoSistema, string profileCorreo);

        /// <summary>
        /// Registrar TrabajadorUnidadOperativa
        /// </summary>
        /// <param name="data">Trabajador Response</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<TrabajadorRequest> RegistrarTrabajadorUnidadOperativa(TrabajadorRequest data);

        /// <summary>
        /// Lista los proyectos asociados a un trabajador.
        /// </summary>
        /// <param name="codigoTrabajador">Código de trabajador</param>
        /// <returns>Lista de proyectos asociados</returns>
        ProcessResult<List<TrabajadorUnidadOperativaResponse>> ListarTrabajadorUnidadOperativa(TrabajadorUnidadOperativaRequest filtro);

        /// <summary>
        /// Eliminar trabajador unidad operativa
        /// </summary>
        /// <param name="codigoTrabajadorUnidadOperativa">CodigoTrabajadorUnidadOperativa</param>
        /// <returns>Resultado del registro</returns>
        ProcessResult<TrabajadorUnidadOperativaRequest> EliminarTrabajadorUnidadOperativa(Guid codigoTrabajadorUnidadOperativa);

        /// <summary>
        /// Búsqueda de TrabajadorSuplente
        /// </summary>
        /// <param name="filtro">Trabajador Request</param>
        /// <returns>Lista con resultados de busqueda</returns>
        ProcessResult<List<TrabajadorSuplenteResponse>> BuscarTrabajadorSuplente(TrabajadorRequest filtro);

        /// <summary>
        /// Registrar Trabajador Suplente
        /// </summary>
        /// <param name="data">TrabajadorSuplente Response</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<TrabajadorSuplenteRequest> RegistrarTrabajadorSuplente(TrabajadorSuplenteRequest data);

        /// <summary>
        /// Actualiza el reemplazo al trabajador original
        /// </summary>
        /// <param name="codigoTrabajador">Codigo de trabajador</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<string> EnviarNotificacionFinReemplazo(Guid codigoTrabajador, Guid codigoSuplente);
               
    }
}

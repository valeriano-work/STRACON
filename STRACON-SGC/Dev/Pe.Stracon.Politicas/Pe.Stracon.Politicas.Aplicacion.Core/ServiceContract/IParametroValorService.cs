using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using System.Collections.Generic;

namespace Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract
{
    /// <summary>
    /// Definición del servicio de aplicación Parametro Valor Service
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22150326 <br />
    /// Modificación:            <br />
    /// </remarks>
    public interface IParametroValorService : IGenericService
    {
        /// <summary>
        /// Realiza la busqueda de Parametro Valor
        /// </summary>
        /// <param name="filtro">Filtro de Parametro Valor</param>
        /// <returns>Listado de unidad operativas encontrados</returns>
        ProcessResult<List<ParametroValorResponse>> BuscarParametroValor(ParametroValorRequest filtro);

        /// <summary>
        /// Realiza la busqueda de Parametro Valor
        /// </summary>
        /// <param name="filtro">Filtro de Parametro Valor</param>
        /// <returns>Listado de unidad operativas encontrados</returns>
        ProcessResult<List<dynamic>> BuscarParametroValorDinamico(ParametroValorRequest filtro);

        /// <summary>
        /// Realiza el registro de un de Parametro Valor
        /// </summary>
        /// <param name="filtro">Filtro de Parametro Valor</param>
        /// <returns>Indicador de Error</returns>
        ProcessResult<string> RegistrarParametroValor(ParametroValorRequest filtro);

        /// <summary>
        /// Realiza el eliminar de un de Parametro Valor
        /// </summary>
        /// <param name="filtro">Filtro de Parametro Valor</param>
        /// <returns>Indicador de Error</returns>
        ProcessResult<string> EliminarParametroValor(ParametroValorRequest filtro);

        /// <summary>
        /// Realiza el eliminar de un de Parametro Valor
        /// </summary>
        /// <param name="filtro">Lista de Parametro Valor a Eliminar</param>
        /// <returns>Indicador de Error</returns>
        ProcessResult<string> EliminarMasivoParametroValor(List<ParametroValorRequest> filtro);
    }
}

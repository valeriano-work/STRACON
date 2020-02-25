using System;
using System.Collections.Generic;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;

namespace Pe.Stracon.SGC.Aplicacion.Core.ServiceContract
{
    /// <summary>
    /// Servicio que representa los Contratos
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150710 <br />
    /// Modificación: <br />
    /// </remarks>
    public interface IBienService : IGenericService
    {
        /// <summary>
        /// Método que retorna la Lista de Bienes
        /// </summary>
        /// <param name="filtro">objeto request del tipo Bien</param>
        /// <returns>Lista de Bienes</returns>
        ProcessResult<List<BienResponse>> ListarBienes(BienRequest filtro, List<CodigoValorResponse> plstTipoBien = null,
                                                                                  List<CodigoValorResponse> plstTipoTarifa = null,
                                                                                  List<CodigoValorResponse> plstMoneda = null,
                                                                                  List<CodigoValorResponse> plstPeriodoAlq = null);

        /// <summary>
        /// Método que registra y/o Edita un Bien
        /// </summary>
        /// <param name="objRqst">objeto request del tipo Bien</param>
        /// <returns>Retorna entero, 1 transacción Ok.</returns>
        ProcessResult<Object> RegistraEditaBien(BienRequest objRqst);

        /// <summary>
        /// Retorna información del bien.
        /// </summary>
        /// <param name="codigoBien">código del bien</param>
        /// <returns>Información del bien</returns>
        ProcessResult<BienResponse> RetornaBienPorId(Guid codigoBien);

        /// <summary>
        /// Retorna información del bien alquiler por código.
        /// </summary>
        /// <param name="codigoBienAlquiler">código del bien alquiler</param>
        /// <returns>Información del bien alquiler por código</returns>
        ProcessResult<BienAlquilerResponse> RetornaBienAlquilerPorId(Guid codigoBienAlquiler);

        /// <summary>
        /// Método que retorna la Lista de Bienes Alquiler
        /// </summary>
        /// <param name="filtro">objeto request del tipo Bien</param>
        /// <returns>Lista de Bienes</returns>
        ProcessResult<List<BienAlquilerResponse>> ListarBienAlquiler(Guid codigoBien);

        /// <summary>
        /// Método que registra y/o Edita un Bien Alquiler
        /// </summary>
        /// <param name="objRqst">objeto request del tipo BienAlquiler</param>
        /// <returns>Retorna entero, 1 transacción Ok.</returns>
        ProcessResult<Object> RegistraEditaBienAlquiler(BienAlquilerRequest objRqst);

        /// <summary>
        ///  Retorna los periodos de alquiler.
        /// </summary>
        /// <param name="tipoTarifa">Código del Tipo de Tarifa</param>
        /// <returns>Periodos de alquiler</returns>
        ProcessResult<List<CodigoValorResponse>> PeriodoAlquilerPorTarifa(string tipoTarifa);

        /// <summary>
        /// Retorna la lista del descripciones de campos del bien.
        /// </summary>
        /// <param name="tipoContenido">código del tipo de contenido</param>
        /// <returns></returns>
        ProcessResult<List<BienRegistroResponse>> ListaBienRegistro(string tipoContenido);

        /// <summary>
        /// Retorna la lista de bienes con su descripción completa.
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Lista de bienes con su descripción completa</returns>
        ProcessResult<List<BienResponse>> ObtenerDescripcionCompletaBien(BienRequest filtro);

        /// <summary>
        /// Elimina uno o muchos Bien
        /// </summary>
        /// <param name="listaCodigosBien">Lista de Códigos de Bien a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> EliminarBien(List<object> listaCodigosBien);

        /// <summary>
        /// Elimina uno o muchos Bien Alquiler
        /// </summary>
        /// <param name="listaCodigosBienAlquiler">Lista de Códigos de Bien Alquiler a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> EliminarBienAlquiler(List<object> listaCodigosBienAlquiler);

        /// <summary>
        /// Sincronizar bienes de servicio Amt
        /// </summary>
        /// <returns>Registro de nuevos equipos de Amt</returns>
        ProcessResult<string> SincronizarBienesServicioAmt();
    }
}

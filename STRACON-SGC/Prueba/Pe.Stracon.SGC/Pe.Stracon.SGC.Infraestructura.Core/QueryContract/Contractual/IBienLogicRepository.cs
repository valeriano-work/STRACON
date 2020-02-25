using System;
using System.Collections.Generic;
using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;

namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    public interface IBienLogicRepository : IQueryRepository<BienLogic>
    {
        /// <summary>
        /// Retorna la lista de los bienes.
        /// </summary>
        /// <param name="codigoIdentificacion">Código de Identificación</param>
        /// <param name="tipoBien">Tipo de bien</param>
        /// <param name="numeroSerie">número de serie</param>
        /// <param name="descripcion">descripción de bienes</param>
        /// <param name="marca">marca del bien</param>
        /// <param name="modelo">modelo del bien</param>
        /// <param name="fechaDesde">rango de fecha inicial de adquisición del bien</param>
        /// <param name="fechaHasta">rango de fecha final de adquisición del bien</param>
        /// <param name="tipoTarifa">Tipo de tarifa del bien</param>
        /// <returns>Lista de Bienes</returns>
        List<BienLogic> ListaBandejaBien(string codigoIdentificacion, string tipoBien, string numeroSerie, string descripcion, string marca,
                                                  string modelo, string fechaDesde, string fechaHasta, string tipoTarifa);

        /// <summary>
        /// Retorna 1 si transacció nok.
        /// </summary>
        /// <param name="codigoBien">código del bien</param>
        /// <returns>Flag de proceso</returns>
        List<BienAlquilerLogic> ListaBienAlquiler(Guid codigoBien);

        /// <summary>
        /// Retorna la lista del alquiler de bienes.
        /// </summary>
        /// <param name="codigoBien">código del bien</param>
        /// <returns>Lista de alquiler de bienes</returns>
        int RegistraHSTBienRegistro(string TipoContenido, string contenido, string userCrea, string TermianlCrea);

                /// <summary>
        /// Retorna la lista del descripciones de campos del alquiler.
        /// </summary>
        /// <param name="tipoContenido">código del tipo de contenido</param>
        /// <returns></returns>
        List<BienRegistroLogic> ListaBienRegistro(string tipoContenido);

        /// <summary>
        /// Obtiene los bienes con su descripción completa
        /// </summary>
        /// <param name="descripcion">Descripción del bien</param>
        /// <returns>Lista de bienes con su descripción completa</returns>
        List<BienLogic> ObtenerDescripcionCompletaBien(string descripcion);
    }
}

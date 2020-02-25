using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Query.Contractual
{
    /// <summary>
    /// Implementación del repositorio de Bienes
    /// </summary>
    public class BienLogicRepository : QueryRepository<BienLogic>, IBienLogicRepository
    {
        /// <summary>
        /// Retorna la lista de los bienes.
        /// </summary>
        /// <param name="tipoBien">Tipo de bien</param>
        /// <param name="numeroSerie">número de serie</param>
        /// <param name="descripcion">descripción de bienes</param>
        /// <param name="marca">marca del bien</param>
        /// <param name="modelo">modelo del bien</param>
        /// <param name="fechaDesde">rango de fecha inicial de adquisición del bien</param>
        /// <param name="fechaHasta">rango de fecha final de adquisición del bien</param>
        /// <param name="tipoTarifa">Tipo de tarifa del bien</param>
        /// <returns>Lista de Bienes</returns>
        public List<BienLogic> ListaBandejaBien(string codigoIdentificacion, string tipoBien, string numeroSerie, string descripcion, string marca,
                                                  string modelo, string fechaDesde, string fechaHasta, string tipoTarifa)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_IDENTIFICACION",SqlDbType.NVarChar) { Value = (object)codigoIdentificacion ?? DBNull.Value},
                new SqlParameter("TIPO_BIEN",SqlDbType.NVarChar) { Value = (object)tipoBien ?? DBNull.Value},
                new SqlParameter("NUMERO_SERIE",SqlDbType.NVarChar) { Value = (object)numeroSerie ?? DBNull.Value},
                new SqlParameter("DESCRIPCION",SqlDbType.NVarChar) { Value = (object)descripcion ?? DBNull.Value},
                new SqlParameter("MARCA",SqlDbType.NVarChar) { Value = (object)marca ?? DBNull.Value},
                new SqlParameter("MODELO",SqlDbType.NVarChar) { Value = (object)modelo ?? DBNull.Value},
                new SqlParameter("FECHA_DESDE",SqlDbType.NVarChar) { Value = (object)fechaDesde ?? DBNull.Value},
                new SqlParameter("FECHA_HASTA",SqlDbType.NVarChar) { Value = (object)fechaHasta ?? DBNull.Value},
                    new SqlParameter("TIPO_TARIFA",SqlDbType.NVarChar) { Value = (object)tipoTarifa ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<BienLogic>("CTR.USP_BANDEJA_BIENES", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Retorna 1 si transacció nok.
        /// </summary>
        /// <param name="codigoBien">código del bien</param>
        /// <returns>Flag de proceso</returns>
        public int RegistraHSTBienRegistro(string TipoContenido, string contenido,string userCrea, string TermianlCrea )
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("TIPO_CONTENIDO",SqlDbType.NVarChar ) { Value = (object)TipoContenido },
                new SqlParameter("CONTENIDO",SqlDbType.NVarChar) { Value = (object)contenido },
                    new SqlParameter("UserCreacion",SqlDbType.NVarChar) { Value = (object)userCrea },
                    new SqlParameter("TERMINAL_CREACION",SqlDbType.NVarChar) { Value = (object)TermianlCrea },
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<int>("CTR.USP_BIEN_REGISTRO_INS", parametros).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Retorna la lista del alquiler de bienes.
        /// </summary>
        /// <param name="codigoBien">código del bien</param>
        /// <returns>Lista de alquiler de bienes</returns>
        public List<BienAlquilerLogic> ListaBienAlquiler(Guid codigoBien)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_BIEN",SqlDbType.UniqueIdentifier ) { Value = (object)codigoBien },
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<BienAlquilerLogic>("CTR.USP_BANDEJA_BIENALQUILER_POR_BIEN", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Retorna la lista del descripciones de campos del bien.
        /// </summary>
        /// <param name="tipoContenido">código del tipo de contenido</param>
        /// <returns></returns>
        public List<BienRegistroLogic> ListaBienRegistro(string tipoContenido)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_TIPO_CONTENIDO",SqlDbType.Char ) { Value = (object)tipoContenido },
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<BienRegistroLogic>("CTR.USP_CONTENIDO_BIEN_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Retorna la lista de bienes con su descripción completa.
        /// </summary>
        /// <param name="descripcion">Descripción del bien</param>
        /// <returns>Lista de bienes con su descripción completa</returns>
        public List<BienLogic> ObtenerDescripcionCompletaBien(string descripcion)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("DESCRIPCION",SqlDbType.NVarChar) { Value = (object)descripcion ?? DBNull.Value },
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<BienLogic>("CTR.USP_BIEN_DESCRIPCION_COMPLETA_SEL", parametros).ToList();
            return result;
        }
    }
}

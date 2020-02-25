using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Pe.Stracon.Politicas.Cross.Core.Base;
using Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using Pe.Stracon.Politicas.Infraestructura.Repository.Base;

namespace Pe.Stracon.Politicas.Infraestructura.Repository.Query.General
{
    /// <summary>
    /// Implementación del repositorio de Parametro Valor
    /// </summary>
    /// <remarks>
    /// Creación:   GMD <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroLogicRepository : QueryRepository<ParametroLogic>, IParametroLogicRepository
    {
        /// <summary>
        /// Entorno de Aplicación Actual
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        /// <summary>
        /// Permite buscar Parametros
        /// </summary>
        /// <param name="codigoParametro">Código de Parametro</param>
        /// <param name="indicadorGlobal">Indicador Global</param>
        /// <param name="codigoEmpresa">Código de Empresa</param>
        /// <param name="codigoSistema">Código de Sistema</param>
        /// <param name="codigoIdentificador">Código Identificador</param>
        /// <param name="tipoParametro">Código de Tipo de Parámetro</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="descripcion">Descripción</param>
        /// <param name="indicadorPermiteAgregar">Indicador de Permite Agregar</param>
        /// <param name="indicadorPermiteModificar">Indicador de Permite Modificar</param>
        /// <param name="indicadorPermiteEliminar">Indicador de Permite Eliminar</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista de Parametros</returns>
        public List<ParametroLogic> BuscarParametro(
            int? codigoParametro, 
            bool? indicadorGlobal,
            Guid? codigoEmpresa,
            Guid? codigoSistema,
            string codigoIdentificador,
            string tipoParametro,
            string nombre, 
            string descripcion, 
            bool? indicadorPermiteAgregar,
            bool? indicadorPermiteModificar,
            bool? indicadorPermiteEliminar, 
            string estadoRegistro)
        {

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int)                 { Value = (object)codigoParametro ?? DBNull.Value },
                new SqlParameter("INDICADOR_EMPRESA", SqlDbType.Bit)                { Value = (object)indicadorGlobal ?? DBNull.Value },
                new SqlParameter("CODIGO_EMPRESA", SqlDbType.UniqueIdentifier)      { Value = (object)codigoEmpresa ?? DBNull.Value },
                new SqlParameter("CODIGO_SISTEMA", SqlDbType.UniqueIdentifier)      { Value = (object)codigoSistema ?? DBNull.Value },
                new SqlParameter("CODIGO_IDENTIFICADOR", SqlDbType.Char)            { Value = (object)codigoIdentificador ?? DBNull.Value },                
                new SqlParameter("TIPO_PARAMETRO", SqlDbType.Char)                  { Value = (object)tipoParametro ?? DBNull.Value },                
                new SqlParameter("NOMBRE", SqlDbType.NVarChar)                      { Value = (object)nombre ?? DBNull.Value },
                new SqlParameter("DESCRIPCION", SqlDbType.NVarChar)                 { Value = (object)descripcion ?? DBNull.Value },
                new SqlParameter("INDICADOR_PERMITE_AGREGAR", SqlDbType.Bit)        { Value = (object)indicadorPermiteAgregar ?? DBNull.Value },
                new SqlParameter("INDICADOR_PERMITE_MODIFICAR", SqlDbType.Bit)      { Value = (object)indicadorPermiteModificar ?? DBNull.Value },
                new SqlParameter("INDICADOR_PERMITE_ELIMINAR", SqlDbType.Bit)       { Value = (object)indicadorPermiteEliminar ?? DBNull.Value },
                new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char)                 { Value = (object)estadoRegistro ?? DBNull.Value }
            };
            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<ParametroLogic>("GRL.USP_PARAMETRO_SEL", parametros).ToList();

            return resultado;
        }
    }
}
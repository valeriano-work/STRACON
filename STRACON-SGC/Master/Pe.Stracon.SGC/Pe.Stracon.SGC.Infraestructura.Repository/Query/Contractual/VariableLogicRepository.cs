using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Base;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Query.Contractual
{
    /// <summary>
    /// Implementación del repositorio Variable
    /// </summary>
    public class VariableLogicRepository : QueryRepository<VariableLogic>, IVariableLogicRepository
    {
        /// <summary>
        /// Permite la búsqueda de variables de acuerdo al indicador global
        /// </summary>
        /// <returns>Lista de variables de acuerdo al indicador global</returns>
        public List<VariableLogic> BuscarVariableGlobal(Guid? codigoPlantilla)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PLANTILLA",SqlDbType.UniqueIdentifier) { Value = (object)codigoPlantilla ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO",SqlDbType.Char) { Value = (object)DatosConstantes.EstadoRegistro.Activo ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<VariableLogic>("CTR.USP_VARIABLE_GLOBAL_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Realiza la busqueda de variables 
        /// </summary>
        /// <param name="codigoVariable">Código de variable</param>
        /// <param name="identificador">Identificador</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="codigoTipo">Código de Tipo</param>
        /// <param name="indicadorGlobal">Indicador Global</param>
        /// <param name="codigoPlantilla">Código de plantilla</param>
        /// <returns>Lista de variables</returns>
        public List<VariableLogic> BuscarVariable(Guid? codigoVariable, string identificador, string nombre, string codigoTipo, bool? indicadorGlobal, Guid? codigoPlantilla, bool? indicadorVariableSistema)
        {
             SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_VARIABLE",SqlDbType.UniqueIdentifier) { Value = (object)codigoVariable ?? DBNull.Value},
                new SqlParameter("IDENTIFICADOR",SqlDbType.NVarChar) { Value = (object)identificador ?? DBNull.Value},
                new SqlParameter("NOMBRE",SqlDbType.NVarChar) { Value = (object)nombre ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO",SqlDbType.NVarChar) { Value = (object)codigoTipo ?? DBNull.Value},
                new SqlParameter("INDICADOR_GLOBAL",SqlDbType.Bit) { Value = (object)indicadorGlobal ?? DBNull.Value},
                new SqlParameter("CODIGO_PLANTILLA",SqlDbType.UniqueIdentifier) { Value = (object)codigoPlantilla ?? DBNull.Value},        
                new SqlParameter("INDICADOR_VARIABLE_SISTEMA",SqlDbType.Bit) { Value = (object)indicadorVariableSistema ?? DBNull.Value}
            };
             var result = this.dataBaseProvider.ExecuteStoreProcedure<VariableLogic>("CTR.USP_VARIABLE_SEL", parametros).ToList();
            return result;
        }
    }
}

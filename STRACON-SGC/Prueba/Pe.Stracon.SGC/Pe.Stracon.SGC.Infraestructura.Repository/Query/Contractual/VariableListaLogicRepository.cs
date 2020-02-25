using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Query.Contractual
{
    /// <summary>
    /// Implementación de Variable Lista
    /// </summary>
    public class VariableListaLogicRepository : QueryRepository<VariableListaLogic>, IVariableListaLogicRepository
    {
        /// <summary>
        /// Busca lista de variable
        /// </summary>
        /// <param name="codigoVariableLista">Codigo de variable lista</param>
        /// <param name="codigoVariable">Codigo de variable</param>
        /// <param name="nombre">Nombre de lista</param>
        /// <returns>Lista de opciones de la variable</returns>
        public List<VariableListaLogic> BuscarLista(Guid? codigoVariableLista, Guid? codigoVariable, string nombre)
        {
            var parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_VARIABLE_LISTA",SqlDbType.UniqueIdentifier) { Value = (object)codigoVariableLista ?? DBNull.Value},
                new SqlParameter("CODIGO_VARIABLE",SqlDbType.UniqueIdentifier) { Value = (object)codigoVariable ?? DBNull.Value},
                new SqlParameter("NOMBRE",SqlDbType.NVarChar) { Value = (object)nombre ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<VariableListaLogic>("CTR.USP_VARIABLE_LISTA_SEL", parametros).ToList();
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Base;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Query.Contractual
{
    /// <summary>
    /// Implementación de Variable Campo
    /// </summary>
    public class VariableCampoLogicRepository : QueryRepository<VariableCampoLogic>, IVariableCampoLogicRepository
    {
        /// <summary>
        /// Busca campos de variable
        /// </summary>
        /// <param name="codigoVariableCampo">Código de Campo</param>
        /// <param name="codigoVariable">Código de Variable</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="orden">Orden</param>
        /// <returns>Lista de Campos</returns>
        public List<VariableCampoLogic> BuscarCampo(Guid? codigoVariableCampo, Guid? codigoVariable, string nombre, byte? orden)
        {
            var parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_VARIABLE_CAMPO",SqlDbType.UniqueIdentifier) { Value = (object)codigoVariableCampo ?? DBNull.Value},
                new SqlParameter("CODIGO_VARIABLE",SqlDbType.UniqueIdentifier) { Value = (object)codigoVariable ?? DBNull.Value},
                new SqlParameter("NOMBRE",SqlDbType.NVarChar) { Value = (object)nombre ?? DBNull.Value},
                new SqlParameter("ORDEN",SqlDbType.TinyInt) { Value = (object)orden ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<VariableCampoLogic>("CTR.USP_VARIABLE_CAMPO_SEL", parametros).ToList();
            return result;
        }
    }
}

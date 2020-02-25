using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    public interface IVariableListaLogicRepository : IQueryRepository<VariableListaLogic>
    {
        /// <summary>
        /// Busca lista de variable
        /// </summary>
        /// <param name="codigoVariableLista">Codigo de variable lista</param>
        /// <param name="codigoVariable">Codigo de variable</param>
        /// <param name="nombre">Nombre de lista</param>
        /// <returns>Lista de opciones de la variable</returns>
        List<VariableListaLogic> BuscarLista(Guid? codigoVariableLista, Guid? codigoVariable, string nombre);
    }
}

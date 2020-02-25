using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;

namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    public interface IVariableCampoLogicRepository : IQueryRepository<VariableCampoLogic>
    {
        /// <summary>
        /// Busca campos de variable
        /// </summary>
        /// <param name="codigoVariableCampo">Código de Campo</param>
        /// <param name="codigoVariable">Código de Variable</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="orden">Orden</param>
        /// <returns>Lista de Campos</returns>
        List<VariableCampoLogic> BuscarCampo(Guid? codigoVariableCampo, Guid? codigoVariable, string nombre, byte? orden);
        
    }
}

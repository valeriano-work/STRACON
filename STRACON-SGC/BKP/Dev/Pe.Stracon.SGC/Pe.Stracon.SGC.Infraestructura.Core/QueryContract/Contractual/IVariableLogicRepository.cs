using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    /// <summary>
    /// Definición del Repositorio de Variable
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150527 <br />
    /// Modificación :           <br />
    /// </remarks>
    public interface IVariableLogicRepository : IQueryRepository<VariableLogic>
    {
        /// <summary>
        /// Realiza la búsqueda de variables de acuerdo al indicador global y plantilla
        /// </summary>
        /// <param name="codigoPlantilla">Código de Plantilla</param>
        /// <returns>Lista de variables de acuerdo al indicador global y plantilla</returns>
        List<VariableLogic> BuscarVariableGlobal(Guid? codigoPlantilla);

        /// <summary>
        /// Realiza la busqueda de variables 
        /// </summary>
        /// <param name="codigoVariable"></param>
        /// <param name="identificador"></param>
        /// <param name="nombre"></param>
        /// <param name="codigoTipo"></param>
        /// <param name="indicadorGlobal"></param>
        /// <param name="codigoPlantilla"></param>
        /// <returns>Lista de variables</returns>
        List<VariableLogic> BuscarVariable(Guid? codigoVariable, string identificador, string nombre, string codigoTipo, bool? indicadorGlobal, Guid? codigoPlantilla, bool? indicadorVariableSistema);
    }
}

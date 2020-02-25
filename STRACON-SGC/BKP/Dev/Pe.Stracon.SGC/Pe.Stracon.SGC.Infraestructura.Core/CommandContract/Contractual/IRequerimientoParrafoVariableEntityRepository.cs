using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual
{
    /// <summary>
    /// Definición del Repositorio de Requerimiento Párrafo Variable
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150612 <br />
    /// Modificación :               <br />
    /// </remarks>
    public interface IRequerimientoParrafoVariableEntityRepository : IComandRepository<RequerimientoParrafoVariableEntity>
    {
        /// <summary>
        /// Realiza la inserción o actualización de Requerimiento Párrafo Variable
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int RegistrarRequerimientoParrafoVariable(RequerimientoParrafoVariableEntity data);
    }
}

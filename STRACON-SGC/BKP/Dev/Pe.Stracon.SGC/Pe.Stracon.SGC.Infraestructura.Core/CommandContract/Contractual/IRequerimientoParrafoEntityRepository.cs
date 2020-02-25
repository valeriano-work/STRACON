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
    /// Definición del Repositorio de Requerimiento Párrafo
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150612 <br />
    /// Modificación :               <br />
    /// </remarks>
    public interface IRequerimientoParrafoEntityRepository : IComandRepository<RequerimientoParrafoEntity>
    {
        /// <summary>
        /// Realiza la inserción o actualización de Requerimiento Párrafo
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int RegistrarRequerimientoParrafo(RequerimientoParrafoEntity data);

        /// <summary>
        /// Elimina el contenido de un Requerimiento
        /// </summary>
        /// <param name="CodigoRequerimiento">Código de requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int EliminarContenidoRequerimiento(Guid CodigoRequerimiento);
    }
}

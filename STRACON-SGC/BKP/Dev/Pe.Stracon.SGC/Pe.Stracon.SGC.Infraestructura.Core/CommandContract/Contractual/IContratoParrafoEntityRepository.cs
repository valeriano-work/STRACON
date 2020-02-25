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
    /// Definición del Repositorio de Contrato Párrafo
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150612 <br />
    /// Modificación :               <br />
    /// </remarks>
    public interface IContratoParrafoEntityRepository : IComandRepository<ContratoParrafoEntity>
    {
        /// <summary>
        /// Realiza la inserción o actualización de Contrato Párrafo
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int RegistrarContratoParrafo(ContratoParrafoEntity data);

        /// <summary>
        /// Elimina el contenido de un contrato
        /// </summary>
        /// <param name="CodigoContrato">Código de contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int EliminarContenidoContrato(Guid CodigoContrato);
    }
}

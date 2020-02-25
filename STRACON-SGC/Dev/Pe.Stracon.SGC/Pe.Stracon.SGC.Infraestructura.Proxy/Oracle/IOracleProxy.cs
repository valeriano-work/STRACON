using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Proxy.Oracle
{
    /// <summary>
    /// Interface de proxy del servicio de Oracle
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150424 <br />
    /// Modificación:            <br />
    /// </remarks> 
    public interface IOracleProxy
    {
        /// <summary>
        /// Obtiene los proveedores
        /// </summary>
        /// <param name="request">Request de búsqueda</param>
        /// <returns>Lista de Proveedores</returns>
        List<ProveedorOracleLogic> ObtenerProveedores(string request);
    }
}

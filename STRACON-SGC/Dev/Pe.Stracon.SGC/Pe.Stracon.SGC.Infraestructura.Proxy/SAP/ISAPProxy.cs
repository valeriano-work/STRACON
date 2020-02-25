using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Proxy.SAP
{
    /// <summary>
    /// Interface de proxy del servicio SAP
    /// </summary>
    /// <remarks>
    /// Creación:  Qualis-Tech : 12/12/2018 <br />
    /// </remarks>
    public interface ISAPProxy
    {
        /// <summary>
        /// Obtiene los proveedores
        /// </summary>
        /// <param name="request">Request de búsqueda</param>
        /// <returns>Lista de Proveedores</returns>
        List<ProveedorSAPLogic> ZSGC_OBTPROVEEDORES(string request);

        /// <summary>
        /// Obtener los equipos de SAP
        /// </summary>
        /// <returns>Lista de equipos</returns>
        List<BienLogic> ObtenerEquipos();
    }
}




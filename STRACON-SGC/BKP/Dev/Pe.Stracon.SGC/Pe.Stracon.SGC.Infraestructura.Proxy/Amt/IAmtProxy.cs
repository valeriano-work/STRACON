using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Proxy.Amt
{
    /// <summary>
    /// Interface de proxy del servicio AMT
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20170628 <br />
    /// Modificación:            <br />
    /// </remarks> 
    public interface IAmtProxy
    {
        /// <summary>
        /// Obtener los equipos de ATM
        /// </summary>
        /// <returns>Lista de equipos</returns>
        List<BienLogic> ObtenerEquipos();
    }
}

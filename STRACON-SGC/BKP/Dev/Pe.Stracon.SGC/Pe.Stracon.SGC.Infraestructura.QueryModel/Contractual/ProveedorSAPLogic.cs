using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa los datos del Proveedor SAP
    /// </summary>
    /// <remarks>
    /// Creación:  Qualis-Tech : 12/12/2018 <br />
    /// </remarks>
    public class ProveedorSAPLogic
    {
        /// <summary>
        /// Número Ruc del Proveedor
        /// </summary>
        public string Ruc { get; set; }
        /// <summary>
        /// Nombre del Proveedor
        /// </summary>
        public string Nombre { get; set; }
    }
}




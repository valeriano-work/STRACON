using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa los datos del Proveedor Oracle
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150602 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class ProveedorOracleLogic
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

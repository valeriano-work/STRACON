using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Reporte de Contrato Pnedinte de Elaborar
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150630 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteContratoPendienteElaborarResponse
    {
        /// <summary>
        /// Ruc de Proveedor
        /// </summary>
        public string RucProveedor { get; set; }
        /// <summary>
        /// Nombre de Proveedor
        /// </summary>
        public string NombreProveedor { get; set; }
        /// <summary>
        /// Año
        /// </summary>
        public int Anio { get; set; }
        /// <summary>
        /// Número del Mes
        /// </summary>
        public int Mes { get; set; }
        /// <summary>
        /// Código del Tipo de Orden
        /// </summary>
        public string CodigoTipoOrden { get; set; }
        /// <summary>
        /// Código de Moneda
        /// </summary>
        public string CodigoMoneda { get; set; }
    }
}

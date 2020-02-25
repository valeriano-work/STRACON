using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Reporte de Contrato Pendiente de Elaborar
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150630 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteContratoPendienteElaborarRequest
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
        public string Anio { get; set; }
        /// <summary>
        /// Número del Mes
        /// </summary>
        public string Mes { get; set; }
        /// <summary>
        /// Nombre del Mes
        /// </summary>
        public string NombreMes { get; set; }
        /// <summary>
        /// Código del Tipo de Orden
        /// </summary>
        public string CodigoTipoOrden { get; set; }
        /// <summary>
        /// Descripción del Tipo de Orden
        /// </summary>
        public string DescripcionTipoOrden { get; set; }
        /// <summary>
        /// Código de Moneda
        /// </summary>
        public string CodigoMoneda { get; set; }
        /// <summary>
        /// Descripción de Moneda
        /// </summary>
        public string DescripcionMoneda { get; set; }
    }
}

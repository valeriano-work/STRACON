using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Bienes
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150803 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteBienesContratoResponse
    {
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Tipo de Bien
        /// </summary>
        public string CodigoTipoBien { get; set; }
        /// <summary>
        /// Ruc de Proveedor
        /// </summary>
        public string RucProveedor { get; set; }
        /// <summary>
        /// Nombre de Proveedor
        /// </summary>
        public string NombreProveedor { get; set; }
        /// <summary>
        /// Número de Contrato
        /// </summary>
        public string NumeroContrato { get; set; }
        /// <summary>
        /// Número de Serie
        /// </summary>
        public string NumeroSerie { get; set; }
    }
}

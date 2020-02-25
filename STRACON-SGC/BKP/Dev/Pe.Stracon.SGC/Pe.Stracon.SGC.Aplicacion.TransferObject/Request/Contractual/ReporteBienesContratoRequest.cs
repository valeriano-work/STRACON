using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Bienes
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150803 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteBienesContratoRequest
    {
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Nombre de Unidad Operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Tipo de Bien
        /// </summary>
        public string CodigoTipoBien { get; set; }
        /// <summary>
        /// Descripción de Tipo de Bien
        /// </summary>
        public string DescripcionTipoBien { get; set; }
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
        /// <summary>
        /// Mes
        /// </summary>
        public string Mes { get; set; }
        /// <summary>
        /// Año
        /// </summary>
        public string Ano { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de ContratoFirmante
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150527 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ContratoFirmanteResponse
    {
        /// <summary>
        /// Código contrato Firmante 
        /// </summary>
        public string CodigoContratoFirmante { get; set; }
        /// <summary>
        /// Código contrato parrafo variable 
        /// </summary>
        public string CodigoContratoParrafoVariable { get; set; }
        /// <summary>
        /// Nombre del firmante
        /// </summary>
        public string NombreFirmante { get; set; }
        /// <summary>
        /// Datos adicionales
        /// </summary>
        public string DatoAdicional { get; set; }
    }
}

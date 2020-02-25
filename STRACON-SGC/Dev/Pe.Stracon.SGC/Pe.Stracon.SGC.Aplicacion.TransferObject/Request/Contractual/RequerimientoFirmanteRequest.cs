using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de contrato Firmante
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150803 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class RequerimientoFirmanteRequest : Filtro
    {
        /// <summary>
        /// Codigo de contrato Firmante
        /// </summary>
        public string CodigoRequerimientoFirmante { get; set; }
        /// <summary>
        /// Codigo de contrato párrafo variable
        /// </summary>
        public string CodigoRequerimientoParrafoVariable { get; set; }
        /// <summary>
        /// Nombre del firmante
        /// </summary>
        public string NombreFirmante { get; set; }
        /// <summary>
        /// Datos adicionales del firmante
        /// </summary>
        public string DatoAdicional { get; set; }
    }
}

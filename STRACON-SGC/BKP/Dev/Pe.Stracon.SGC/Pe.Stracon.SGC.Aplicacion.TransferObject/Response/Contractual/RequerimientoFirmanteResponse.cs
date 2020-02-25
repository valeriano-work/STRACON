using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de RequerimientoFirmante
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150527 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class RequerimientoFirmanteResponse
    {
        /// <summary>
        /// Código Requerimiento Firmante 
        /// </summary>
        public string CodigoRequerimientoFirmante { get; set; }
        /// <summary>
        /// Código Requerimiento parrafo variable 
        /// </summary>
        public string CodigoRequerimientoParrafoVariable { get; set; }
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

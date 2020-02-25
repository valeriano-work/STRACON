using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de contrato bien
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150803 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ContratoBienRequest : Filtro
    {
        /// <summary>
        /// Código de Contrato Bien
        /// </summary>
        public string CodigoContratoBien { get; set; }
        /// <summary>
        /// Código de Contrato
        /// </summary>
        public string CodigoContrato { get; set; }
        /// <summary>
        /// Código de Bien
        /// </summary>
        public string CodigoBien { get; set; }
    }
}

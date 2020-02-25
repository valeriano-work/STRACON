using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de ContratoBien
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150609 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ContratoBienResponse
    {
        /// <summary>
        /// Codigo Contrato Bien
        /// </summary>
        public Guid CodigoContratoBien { get; set; }
        /// <summary>
        /// Codigo Contrato
        /// </summary>
        public Guid CodigoContrato { get; set; }
        /// <summary>
        /// Codigo de Bien
        /// </summary>
        public Guid CodigoBien { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public char EstadoRegistro { get; set; }
    }
}

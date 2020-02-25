using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de RequerimientoBien
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150609 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class RequerimientoBienResponse
    {
        /// <summary>
        /// Codigo Requerimiento Bien
        /// </summary>
        public Guid CodigoRequerimientoBien { get; set; }
        /// <summary>
        /// Codigo Requerimiento
        /// </summary>
        public Guid CodigoRequerimiento { get; set; }
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

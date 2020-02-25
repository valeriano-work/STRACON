using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel
{
    /// <summary>
    /// Representa los datos de bien de un contrato
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20151020 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class RequerimientoBienLogic : Logic
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa los datos del Campo de Variable
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class VariableCampoLogic : Logic
    {
        /// <summary>
        /// Código de Campo
        /// </summary>
        public Guid CodigoVariableCampo { get; set; }
        /// <summary>
        /// Código de Variable
        /// </summary>
        public Guid CodigoVariable { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Orden
        /// </summary>
        public byte Orden { get; set; }
        /// <summary>
        /// Tipo de Alineamiento
        /// </summary>
        public string TipoAlineamiento { get; set; }
        /// <summary>
        /// Tamaño de Columna
        /// </summary>
        public decimal Tamanio { get; set; }
    }
}

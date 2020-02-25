using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Implementación de la entidad para Campo de Variable
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150627 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class VariableCampoEntity : Entity
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
        /// Nombre de Campo
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

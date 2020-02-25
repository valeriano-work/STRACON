using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Implementación de la entidad para Plantilla Párrafo Variable
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150529 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaParrafoVariableEntity : Entity
    {
        /// <summary>
        /// Código de Plantilla Párrafo Variable
        /// </summary>
        public Guid CodigoPlantillaParrafoVariable { get; set; }
        /// <summary>
        /// Código de Plantilla Párrafo
        /// </summary>
        public Guid CodigoPlantillaParrafo { get; set; }
        /// <summary>
        /// Código de Variable
        /// </summary>
        public Guid CodigoVariable { get; set; }
        /// <summary>
        /// Orden
        /// </summary>
        public Int16 Orden { get; set; }
    }
}

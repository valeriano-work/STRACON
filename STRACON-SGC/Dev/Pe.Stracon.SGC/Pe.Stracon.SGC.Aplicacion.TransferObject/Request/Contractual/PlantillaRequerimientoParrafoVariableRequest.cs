using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Plantilla Párrafo Variable
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150529 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class PlantillaRequerimientoParrafoVariableRequest : Filtro
    {
        /// <summary>
        /// Código de Plantilla Párrafo Variable
        /// </summary>
        public string CodigoPlantillaParrafoVariable { get; set; }
        /// <summary>
        /// Código de Plantilla Párrafo
        /// </summary>
        public string CodigoPlantillaParrafo { get; set; }
        /// <summary>
        /// Código de Variable
        /// </summary>
        public string CodigoVariable { get; set; }
        /// <summary>
        /// Orden
        /// </summary>
        public Int16? Orden { get; set; }
    }
}

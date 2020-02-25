using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Implementación de la entidad para plantilla nota pie
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20170822 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaRequerimientoNotaPieEntity : Entity
    {
        /// <summary>
        /// Código de Plantilla Nota Pie
        /// </summary>
        public Guid CodigoPlantillaNotaPie { get; set; }
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public Guid CodigoPlantilla { get; set; }
        /// <summary>
        /// Orden
        /// </summary>
        public byte Orden { get; set; }
        /// <summary>
        /// Título
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Contenido
        /// </summary>
        public string Contenido { get; set; }

    }
}

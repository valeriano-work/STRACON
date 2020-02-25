using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de plantilla nota pie
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20170821 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class PlantillaRequerimientoNotaPieResponse
    {
        /// <summary>
        /// Código de Plantilla Nota Pie
        /// </summary>
        public Guid? CodigoPlantillaNotaPie { get; set; }
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public Guid? CodigoPlantilla { get; set; }
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

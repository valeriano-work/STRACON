using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa los datos de la plantilla Nota Pie
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20170818 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaNotaPieLogic : Logic
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

using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa los datos de la plantilla párrafo
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150521 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaRequerimientoParrafoLogic : Logic
    {
        /// <summary>
        /// Código de Plantilla Párrafo
        /// </summary>
        public Guid CodigoPlantillaParrafo { get; set; }
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

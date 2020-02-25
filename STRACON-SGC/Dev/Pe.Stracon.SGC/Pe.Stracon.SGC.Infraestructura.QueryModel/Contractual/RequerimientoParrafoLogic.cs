using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Requerimiento Parrafo
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class RequerimientoParrafoLogic : Logic
    {
        /// <summary>
        /// Codigo de Requerimiento Parrafo
        /// </summary>
        public Guid CodigoRequerimientoParrafo { get; set; }
        /// <summary>
        /// Codigo de Requerimiento
        /// </summary>
        public Guid CodigoRequerimiento { get; set; }
        /// <summary>
        /// Codigo de Plantilla Parrafo
        /// </summary>
        public Guid CodigoPlantillaParrafo { get; set; }
        /// <summary>
        /// Título del Párrafo
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Contenido del párrafo
        /// </summary>
        public string Contenido { get; set; }
        /// <summary>
        /// Orden del párrafo
        /// </summary>
        public byte Orden { get; set; } 
    }
}

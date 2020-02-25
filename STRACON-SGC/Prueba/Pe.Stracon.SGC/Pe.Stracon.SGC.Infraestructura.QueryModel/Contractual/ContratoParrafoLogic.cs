using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Contrato Parrafo
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ContratoParrafoLogic : Logic
    {
        /// <summary>
        /// Codigo de Contrato Parrafo
        /// </summary>
        public Guid CodigoContratoParrafo { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid CodigoContrato { get; set; }
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

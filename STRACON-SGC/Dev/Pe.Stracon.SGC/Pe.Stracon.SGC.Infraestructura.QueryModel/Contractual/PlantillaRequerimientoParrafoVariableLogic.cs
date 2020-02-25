using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa los datos de plantilla párrafo variable
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150529 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaRequerimientoParrafoVariableLogic : Logic
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
        /// <summary>
        /// Código de Tipo de Variable
        /// </summary>
        public string CodigoTipoVariable { get; set; }
        /// <summary>
        /// Nombre de Variable
        /// </summary>
        public string NombreVariable { get; set; }
        /// <summary>
        /// Identificador de Variable
        /// </summary>
        public string IdentificadorVariable { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string DescripcionVariable { get; set; }
    }
}

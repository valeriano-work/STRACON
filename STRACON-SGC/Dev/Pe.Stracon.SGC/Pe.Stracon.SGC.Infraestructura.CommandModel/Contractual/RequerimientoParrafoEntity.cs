using System;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Requerimiento Parrafo
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150511 <br />
    /// Modificación :           <br />
    /// </remarks> 
    public class RequerimientoParrafoEntity: Entity
    {
        /// <summary>
        /// Codigo de RequerimientoParrafo
        /// </summary>
        public Guid CodigoRequerimientoParrafo { get; set; }
        /// <summary>
        /// Codigo de Requerimiento
        /// </summary>
        public Guid CodigoRequerimiento { get; set; }
        /// <summary>
        /// Codigo de PlantillaParrafo
        /// </summary>
        public Guid CodigoPlantillaParrafo { get; set; }
        /// <summary>
        /// Contenido
        /// </summary>
        public string ContenidoParrafo { get; set; }
    }
}

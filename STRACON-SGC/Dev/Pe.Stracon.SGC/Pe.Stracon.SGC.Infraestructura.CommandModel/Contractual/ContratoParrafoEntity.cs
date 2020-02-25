using System;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Contrato Parrafo
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150511 <br />
    /// Modificación :           <br />
    /// </remarks> 
    public class ContratoParrafoEntity: Entity
    {
        /// <summary>
        /// Codigo de ContratoParrafo
        /// </summary>
        public Guid CodigoContratoParrafo { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid CodigoContrato { get; set; }
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

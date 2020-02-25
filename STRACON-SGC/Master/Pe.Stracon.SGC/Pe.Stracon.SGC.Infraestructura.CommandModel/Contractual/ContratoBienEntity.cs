using System;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Contrato Bien
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150511 <br />
    /// Modificación :           <br />
    /// </remarks>  
    public class ContratoBienEntity : Entity
    {
        /// <summary>
        /// Codigo de Contrato de Bien
        /// </summary>
        public Guid CodigoContratoBien { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid CodigoContrato { get; set; }
        /// <summary>
        /// Codigo de Bien
        /// </summary>
        public Guid CodigoBien { get; set; } 
    }
}

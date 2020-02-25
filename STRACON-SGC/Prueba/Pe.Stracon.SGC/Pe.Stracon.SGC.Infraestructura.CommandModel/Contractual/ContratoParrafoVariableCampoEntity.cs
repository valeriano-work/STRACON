using System;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Contrato Parrafo Variable Campo
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150511 <br />
    /// Modificación :           <br />
    /// </remarks> 
    public class ContratoParrafoVariableCampoEntity : Entity
    {
        /// <summary>
        /// Codigo Contrato Parrafo Variable Campo
        /// </summary>
        public Guid CodigoContratoParrafoVariableCampo { get; set; }
        /// <summary>
        /// Codigo Contrato Parrafo Variable
        /// </summary>
        public Guid CodigoContratoParrafoVariable { get; set; }
        /// <summary>
        /// Codigo Variabl eCampo
        /// </summary>
        public Guid CodigoVariableCampo { get; set; }
        /// <summary>
        /// NumeroFila
        /// </summary>
        public byte NumeroFila { get; set; }
        /// <summary>
        /// Valor
        /// </summary>
        public string Valor { get; set; } 

    }
}

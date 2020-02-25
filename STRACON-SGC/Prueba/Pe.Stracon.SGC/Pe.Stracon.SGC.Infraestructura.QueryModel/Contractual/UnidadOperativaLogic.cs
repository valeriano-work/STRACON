using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Unidad Operativa 
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class UnidadOperativaLogic : Logic
    {
        /// <summary>
        /// Codigo Unidad Operativa
        /// </summary>
        public Guid CodigoUnidadOperativa { get; set; }
    }
}
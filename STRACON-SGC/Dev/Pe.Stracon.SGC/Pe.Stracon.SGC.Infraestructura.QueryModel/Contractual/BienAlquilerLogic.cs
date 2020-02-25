using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Bien Alquiler
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class BienAlquilerLogic : Logic
    {
        /// <summary>
        /// Codigo del Bien de Alquiler
        /// </summary>
        public Guid CodigoBienAlquiler { get; set; }
        /// <summary>
        /// Codigo de Bien
        /// </summary>
        public Guid CodigoBien { get; set; }
        /// <summary>
        /// Indicador Sin Límite
        /// </summary>
        public bool IndicadorSinLimite { get; set; }
        /// <summary>
        /// Cantidad Límite
        /// </summary>
        public decimal? CantidadLimite { get; set; }
        /// <summary>
        /// Monto
        /// </summary>
        public decimal Monto { get; set; } 
    }
}

using System;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad BIEN_ALQUILER
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150710 <br />
    /// Modificación: <br />
    /// </remarks>
    public class BienAlquilerEntity : Entity
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

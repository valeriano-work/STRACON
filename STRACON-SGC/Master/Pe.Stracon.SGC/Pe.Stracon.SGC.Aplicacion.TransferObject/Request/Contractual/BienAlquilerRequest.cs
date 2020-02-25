using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Bien Alquiler
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class BienAlquilerRequest
    {
        /// <summary>
        /// Codigo del Bien de Alquiler
        /// </summary>
        public Guid? CodigoBienAlquiler { get; set; }
        /// <summary>
        /// Codigo de Bien
        /// </summary>
        public Guid? CodigoBien { get; set; }
        /// <summary>
        /// Indicador Sin Límite
        /// </summary>
        public bool IndicadorSinLimite { get; set; }
        /// <summary>
        /// Cantidad Límite
        /// </summary>
        public decimal CantidadLimite { get; set; }
        /// <summary>
        /// Cantidad Límite en cadena de texto
        /// </summary>
        public string CantidadLimiteString { get; set; }
        /// <summary>
        /// Monto
        /// </summary>
        public decimal Monto { get; set; }
        /// <summary>
        /// Monto en cadena de texto
        /// </summary>
        public string MontoString { get; set; }
    }
}

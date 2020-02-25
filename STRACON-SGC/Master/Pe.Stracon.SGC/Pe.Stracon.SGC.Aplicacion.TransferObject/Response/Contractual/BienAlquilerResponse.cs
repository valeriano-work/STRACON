using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Bien Alquiler
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150527 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class BienAlquilerResponse
    {
        /// <summary>
        /// Código del Bien de Alquiler
        /// </summary>
        public string CodigoBienAlquiler { get; set; }
        /// <summary>
        /// Código de Bien
        /// </summary>
        public string CodigoBien { get; set; }
        /// <summary>
        /// Indicador Sin Límite
        /// </summary>
        public bool IndicadorSinLimite { get; set; }
        /// <summary>
        /// Cantidad Límite
        /// </summary>
        public decimal? CantidadLimite { get; set; }
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

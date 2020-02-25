using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Bien
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class BienRequest
    {
        /// <summary>
        /// Codigo del Bien
        /// </summary>
        public Guid? CodigoBien { get; set; }
        /// <summary>
        /// Codigo del Tipo de Bien
        /// </summary>
        public string CodigoTipoBien { get; set; }
        /// <summary>
        /// Código de Identificación
        /// </summary>
        public string CodigoIdentificacion { get; set; }
        /// <summary>
        /// Numero de Serie
        /// </summary>
        public string NumeroSerie { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Marca
        /// </summary>
        public string Marca { get; set; }
        /// <summary>
        /// Modelo
        /// </summary>
        public string Modelo { get; set; }
        /// <summary>
        /// Fecha de Adquisicion
        /// </summary>
        public DateTime? FechaAdquisicion { get; set; }
        /// <summary>
        /// Fecha de Adquisición en cadena de texto
        /// </summary>
        public string FechaAdquisicionString { get; set; }
        /// <summary>
        /// Filtro fecha de inicio
        /// </summary>
        public string FechaInicio { get; set; }
        /// <summary>
        /// Filtro fecha fin
        /// </summary>
        public string FechaFin { get; set; }
        /// <summary>
        /// Tiempo de Vida
        /// </summary>
        public decimal TiempoVida { get; set; }
        /// <summary>
        /// Tiempo de Vida en cadena de texto
        /// </summary>
        public string TiempoVidaString { get; set; }
        /// <summary>
        /// Valor Residual
        /// </summary>
        public decimal ValorResidual { get; set; }
        /// <summary>
        /// Valor Residual en cadena de texto
        /// </summary>
        public string ValorResidualString { get; set; }
        /// <summary>
        /// Codigo de Tipo de Tarifa
        /// </summary>
        public string CodigoTipoTarifa { get; set; }
        /// <summary>
        /// Codigo Periodo de Alquiler
        /// </summary>
        public string CodigoPeriodoAlquiler { get; set; }
        /// <summary>
        /// Valor de Alquiler
        /// </summary>
        public decimal ValorAlquiler { get; set; }
        /// <summary>
        /// Valor de Alquiler en cadena de texto
        /// </summary>
        public string ValorAlquilerString { get; set; }
        /// <summary>
        /// Codigo de Moneda
        /// </summary>
        public string CodigoMoneda { get; set; }
        /// <summary>
        /// Mes de Inicio de Alquiler
        /// </summary>
        public Byte? MesInicioAlquiler { get; set; }
        /// <summary>
        /// Año de Inicio de Alquiler
        /// </summary>
        public Int16? AnioInicioAlquiler { get; set; }
    }
}

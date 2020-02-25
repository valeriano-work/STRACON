using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Bien
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150527 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class BienResponse
    {
        /// <summary>
        /// Código del Bien
        /// </summary>
        public string CodigoBien { get; set; }
        /// <summary>
        /// Código del Tipo de Bien
        /// </summary>
        public string CodigoTipoBien { get; set; }
        /// <summary>
        /// Código de Identificación
        /// </summary>
        public string CodigoIdentificacion { get; set; }
        /// <summary>
        /// Nombre del Tipo de Bien
        /// </summary>
        public string NombreTipoBien { get; set; }
        /// <summary>
        /// Número de Serie
        /// </summary>
        public string NumeroSerie { get; set; }
        /// <summary>
        /// Descripción
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
        /// Fecha de Adquisición
        /// </summary>
        public string FechaAdquisicion { get; set; }
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
        /// Código de Tipo de Tarifa
        /// </summary>
        public string CodigoTipoTarifa { get; set; }
        /// <summary>
        /// Nombre de Tipo de Tarifa
        /// </summary>
        public string NombreTipoTarifa { get; set; }
        /// <summary>
        /// Código Periodo de Alquiler
        /// </summary>
        public string CodigoPeriodoAlquiler { get; set; }
        /// <summary>
        /// Nombre Periodo de Alquiler
        /// </summary>
        public string NombrePeriodoAlquiler { get; set; }
        /// <summary>
        /// Valor de Alquiler
        /// </summary>
        public decimal? ValorAlquiler { get; set; }
        /// <summary>
        /// Valor de Alquiler en cadena de texto
        /// </summary>
        public string ValorAlquilerString { get; set; }
        /// <summary>
        /// Código de Moneda
        /// </summary>
        public string CodigoMoneda { get; set; }
        /// <summary>
        /// Nombre de Moneda
        /// </summary>
        public string NombreMoneda { get; set; }
        /// <summary>
        /// Descripción Completa del Bien
        /// </summary>
        public string DescripcionCompleta { get; set; }
        /// <summary>
        /// Mes de Inicio de Alquiler
        /// </summary>
        public Byte? MesInicioAlquiler { get; set; }
        /// <summary>
        /// Año de Inicio de Alquiler
        /// </summary>
        public Int16? AnioInicioAlquiler { get; set; }
        /// <summary>
        /// Descripción del Mes de Inicio de Alquiler
        /// </summary>
        public string DescripcionMesInicioAlquiler { get; set; }
        /// <summary>
        /// Inicio de Alquiler concatenado
        /// </summary>
        public string MesAnioInicioAlquiler { get; set; }
    }
}

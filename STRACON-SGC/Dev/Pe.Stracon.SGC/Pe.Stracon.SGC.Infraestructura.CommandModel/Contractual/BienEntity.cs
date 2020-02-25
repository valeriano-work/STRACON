using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad bien
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150710 <br />
    /// Modificación: <br />
    /// </remarks>
    public class BienEntity : Entity
    {
        /// <summary>
        /// Codigo del Bien
        /// </summary>
        public Guid CodigoBien { get; set; }
        /// <summary>
        /// Código del Tipo de Bien
        /// </summary>
        public string CodigoTipoBien { get; set; }
        /// <summary>
        /// Código de Identificación
        /// </summary>
        public string CodigoIdentificacion { get; set; }
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
        public DateTime FechaAdquisicion { get; set; }
        /// <summary>
        /// Tiempo de Vida
        /// </summary>
        public decimal TiempoVida { get; set; }
        /// <summary>
        /// Valor Residual
        /// </summary>
        public decimal ValorResidual { get; set; }
        /// <summary>
        /// Código de Tipo de Tarifa
        /// </summary>
        public string CodigoTipoTarifa { get; set; }
        /// <summary>
        /// Código Periodo de Alquiler
        /// </summary>
        public string CodigoPeriodoAlquiler { get; set; }
        /// <summary>
        /// Valor de Alquiler
        /// </summary>
        public decimal? ValorAlquiler { get; set; }
        /// <summary>
        /// Código de Moneda
        /// </summary>
        public string CodigoMoneda { get; set; }
        /// <summary>
        /// Mes de Inicio de Alquiler
        /// </summary>
        public Byte MesInicioAlquiler { get; set; }
        /// <summary>
        /// Año de Inicio de Alquiler
        /// </summary>
        public Int16 AnioInicioAlquiler { get; set; }
    }
}

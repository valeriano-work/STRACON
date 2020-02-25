using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de plantilla
    /// </summary>
    /// <remarks>
    /// Creación :      <br />
    /// Modificación :               <br />
    /// </remarks>
    public class PlantillaRequerimientoResponse
    {
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public Guid? CodigoPlantilla { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Código de Estado de Vigencia
        /// </summary>
        public string CodigoEstadoVigencia { get; set; }
        /// <summary>
        /// Descripción de Estado de Vigencia
        /// </summary>
        public string DescripcionEstadoVigencia { get; set; }
        /// <summary>
        /// Indicador Adhesión
        /// </summary>
        public bool IndicadorAdhesion { get; set; }
        /// <summary>
        /// Fecha de Inicio de Vigencia en cadena de texto
        /// </summary>
        public string FechaInicioVigenciaString { get; set; }
        /// <summary>
        /// Fecha de Inicio de Vigencia
        /// </summary>
        public DateTime FechaInicioVigencia { get; set; }
        /// <summary>
        /// Fecha de Fin de Vigencia en cadena de texto
        /// </summary>
        public string FechaFinVigenciaString { get; set; }
        /// <summary>
        /// Fecha de Fin de Vigencia
        /// </summary>
        public DateTime? FechaFinVigencia { get; set; }
    }
}

using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa los datos de la plantilla
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150518 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class PlantillaLogic : Logic
    {
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public Guid CodigoPlantilla { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Código de Tipo de Contrato
        /// </summary>
        public string CodigoTipoContrato { get; set; }
        /// <summary>
        /// Descripción de Tipo de Contrato
        /// </summary>
        public string DescripcionTipoContrato { get; set; }
        /// <summary>
        /// Código de Tipo de Documento de Contrato
        /// </summary>
        public string CodigoTipoDocumentoContrato { get; set; }
        /// <summary>
        /// Descripción de Tipo de Documento de Contrato
        /// </summary>
        public string DescripcionTipoDocumentoContrato { get; set; }
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
        public string FechaInicioVigencia { get; set; }
        /// <summary>
        /// Fecha de Inicio de Vigencia
        /// </summary>
        public DateTime FechaInicioVigenciaDate { get; set; }
        /// <summary>
        /// Fecha de Fin de Vigencia en cadena de texto
        /// </summary>
        public string FechaFinVigencia { get; set; }
        /// <summary>
        /// Fecha de Fin de Vigencia
        /// </summary>
        public DateTime? FechaFinVigenciaDate { get; set; }
        /// <summary>
        /// Usuario de Creación
        /// </summary>
        public string UsuarioCreacion { get; set; }
        /// <summary>
        /// Fecha de Creación
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Terminal de Creación
        /// </summary>
        public string TerminalCreacion { get; set; }
        /// <summary>
        /// Usuario de Modificación
        /// </summary>
        public string UsuarioModificacion { get; set; }
        /// <summary>
        /// Fecha de Modificación
        /// </summary>
        public DateTime? FechaModificacion { get; set; }
        /// <summary>
        /// Terminal de Modificación
        /// </summary>
        public string TerminalModificacion { get; set; }
    }
}

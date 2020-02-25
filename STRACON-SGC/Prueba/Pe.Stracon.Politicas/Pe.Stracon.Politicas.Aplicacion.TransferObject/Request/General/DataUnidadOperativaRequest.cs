using System;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General
{
    /// <summary>
    /// Representa el objeto de filtro a aplicar a la Data Unidad Operativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class DataUnidadOperativaRequest
    {
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Identificación de la unidad operativa
        /// </summary>
        public string CodigoIdentificacion { get; set; }
        /// <summary>
        /// Nombre 
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Indicador de activación 
        /// </summary>
        public bool? IndicadorActiva { get; set; }
        /// <summary>
        /// Nombre 
        /// </summary>
        public string CodigoNivelJerarquia { get; set; }
        /// <summary>
        /// Nombre de unidad operativa padre
        /// </summary>
        public string CodigoUnidadOperativaPadre { get; set; }
        /// <summary>
        /// Tipo de unidad operativa
        /// </summary>
        public string CodigoTipoUnidadOperativa { get; set; }        
        /// <summary>
        /// Nombre del responsable
        /// </summary>
        public string CodigoResponsable { get; set; }
        /// <summary>
        /// Nombre del responsable
        /// </summary>
        public string CodigoZonaHoraria { get; set; }
        /// <summary>
        /// Código del primer representante
        /// </summary>
        public string CodigoPrimerRepresentante { get; set; }
        /// <summary>
        /// Código del segundo representante
        /// </summary>
        public string CodigoSegundoRepresentante { get; set; }
        /// <summary>
        /// Código del segundo representante
        /// </summary>
        public string CodigoTercerRepresentante { get; set; }
        /// <summary>
        /// Código del segundo representante
        /// </summary>
        public string CodigoCuartoRepresentante { get; set; }
        /// <summary>
        /// Dirección
        /// </summary>
        public string Direccion { get; set; }
    }
}

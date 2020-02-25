using System;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad de unidad operativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaEntity : Entity
    {
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public Guid Codigo { get; set; }
        /// <summary>
        /// Código de identificación de la unidad operativa
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
        /// Código de nivel de jerarquía
        /// </summary>
        public string CodigoNivelJerarquia { get; set; }
        /// <summary>
        /// Código de unidad operativa padre
        /// </summary>
        public Guid? CodigoUnidadOperativaPadre { get; set; }
        /// <summary>
        /// Código de tipo de unidad operativa
        /// </summary>
        public string CodigoTipoUnidadOperativa { get; set; }
        /// <summary>
        /// Código del responsable
        /// </summary>
        public Guid? CodigoResponsable { get; set; }
        /// <summary>
        /// Código del primer representante
        /// </summary>
        public Guid? CodigoPrimerRepresentante { get; set; }
        /// <summary>
        /// Código del segundo representante
        /// </summary>
        public Guid? CodigoSegundoRepresentante { get; set; }
        /// <summary>
        /// Código del tercer representante
        /// </summary>
        public Guid? CodigoTercerRepresentante { get; set; }
        /// <summary>
        /// Código del cuarto representante
        /// </summary>
        public Guid? CodigoCuartoRepresentante { get; set; }
        /// <summary>
        /// Dirección
        /// </summary>
        public string Direccion { get; set; }
        /// <summary>
        /// Código de zona horaria
        /// </summary>
        public Guid? CodigoZonaHoraria { get; set; }
        /// <summary>
        /// Código del primer representante Original
        /// </summary>
        public Guid? CodigoPrimerRepresentanteOriginal { get; set; }
        /// <summary>
        /// Código del segundo representante Original
        /// </summary>
        public Guid? CodigoSegundoRepresentanteOriginal { get; set; }
        /// <summary>
        /// Código del tercer representante Original
        /// </summary>
        public Guid? CodigoTercerRepresentanteOriginal { get; set; }
        /// <summary>
        /// Código del cuarto representante Original
        /// </summary>
        public Guid? CodigoCuartoRepresentanteOriginal { get; set; }
    }
}

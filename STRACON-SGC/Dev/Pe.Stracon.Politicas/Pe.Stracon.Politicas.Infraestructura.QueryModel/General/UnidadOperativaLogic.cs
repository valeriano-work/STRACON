using System;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.Politicas.Infraestructura.QueryModel.General
{
    /// <summary>
    /// Representa los datos generales de la unidad operativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22150326 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaLogic : Logic
    {
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de identificación de la unidad operativa
        /// </summary>
        public string CodigoIdentificacion { get; set; }
        /// <summary>
        /// Nombre 
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Código de Nivel de Jerarquía
        /// </summary>
        public string CodigoNivelJerarquia { get; set; }
        /// <summary>
        /// Descripción de Nivel de Jerarquía
        /// </summary>
        public string DescripcionNivelJerarquia { get; set; }
        /// <summary>
        /// Valor del Nivel de Jerarquía
        /// </summary>
        public int? NivelJerarquia { get; set; }
        /// <summary>
        /// Código de unidad operativa padre
        /// </summary>
        public Guid? CodigoUnidadOperativaPadre { get; set; }
        /// <summary>
        /// Nombre de unidad operativa padre
        /// </summary>
        public string NombreUnidadOperativaPadre { get; set; }
        /// <summary>
        /// Tipo de unidad operativa
        /// </summary>
        public string CodigoTipoUnidadOperativa { get; set; }
        /// <summary>
        /// Indicador de activación 
        /// </summary>
        public bool? IndicadorActiva { get; set; }        
        /// <summary>
        /// Código del responsable
        /// </summary>
        public Guid? CodigoResponsable { get; set; }
        /// <summary>
        /// Nombre del responsable
        /// </summary>
        public string NombreResponsable { get; set; }
        /// <summary>
        /// Código del primer representante
        /// </summary>
        public Guid? CodigoPrimerRepresentante { get; set; }
        /// <summary>
        /// Nombre del primer representante
        /// </summary>
        public string NombrePrimerRepresentante { get; set; }
        /// <summary>
        /// Código del segundo representante
        /// </summary>
        public Guid? CodigoSegundoRepresentante { get; set; }
        /// <summary>
        /// Nombre del segundo representante
        /// </summary>
        public string NombreSegundoRepresentante { get; set; }
        /// <summary>
        /// Código del tercer representante
        /// </summary>
        public Guid? CodigoTercerRepresentante { get; set; }
        /// <summary>
        /// Nombre del tercer representante
        /// </summary>
        public string NombreTercerRepresentante { get; set; }
        /// <summary>
        /// Código del cuarto representante
        /// </summary>
        public Guid? CodigoCuartoRepresentante { get; set; }
        /// <summary>
        /// Nombre del cuarto representante
        /// </summary>
        public string NombreCuartoRepresentante { get; set; }  
        /// <summary>
        /// Dirección
        /// </summary>
        public string Direccion { get; set; }
        /// <summary>
        /// Logo Unidad Operativo
        /// </summary>
        public string LogoUnidadOperativa { get; set; }
    }
}

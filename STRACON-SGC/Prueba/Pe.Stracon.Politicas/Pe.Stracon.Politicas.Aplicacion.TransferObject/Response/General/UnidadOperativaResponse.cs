using System;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Datos generales de la unidad operativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaResponse: Paginado
    {
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Identificación de la unidad operativa
        /// </summary>
        public string CodigoIdentificacion { get; set; }
        /// <summary>
        /// Nombre 
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Nivel asociado
        /// </summary>
        public string CodigoNivelJerarquia { get; set; }
        /// <summary>
        /// Descripción del Nivel asociado
        /// </summary>
        public string DescripcionNivelJerarquia { get; set; }
        /// <summary>
        /// Valor del Nivel asociado
        /// </summary>
        public int? NivelJerarquia { get; set; }
        /// <summary>
        /// Nombre de unidad operativa padre
        /// </summary>
        public Guid? CodigoUnidadOperativaPadre { get; set; }
        /// <summary>
        /// Unidad Operativa Padre
        /// </summary>
        public UnidadOperativaResponse UnidadOperativaPadre { get; set; }
        /// <summary>
        /// Nombre de unidad operativa padre
        /// </summary>
        public string NombreUnidadOperativaPadre { get; set; }
        /// <summary>
        /// Tipo de unidad operativa
        /// </summary>
        public string CodigoTipoUnidadOperativa { get; set; }
        /// <summary>
        /// Descripción de Tipo de unidad operativa
        /// </summary>
        public string DescripcionTipoUnidadOperativa { get; set; }
        /// <summary>
        /// Indicador de activación 
        /// </summary>
        public bool? IndicadorActiva { get; set; }
        /// <summary>
        /// Nombre del responsable
        /// </summary>
        public Guid? CodigoResponsable { get; set; }
        /// <summary>
        /// Nombre del responsable
        /// </summary>
        public string NombreResponsable { get; set; }
        /// <summary>
        /// Objeto de Trabajador Responsable
        /// </summary>
        public TrabajadorResponse Responsable { get; set; }
        /// <summary>
        /// Código del primer representante
        /// </summary>
        public Guid? CodigoPrimerRepresentante { get; set; }
        /// <summary>
        /// Nombre del primer representante
        /// </summary>
        public string NombrePrimerRepresentante { get; set; }
        /// <summary>
        /// Objeto de primer representante
        /// </summary>
        public TrabajadorResponse PrimerRepresentante { get; set; }
        /// <summary>
        /// Código del segundo representante
        /// </summary>
        public Guid? CodigoSegundoRepresentante { get; set; }
        /// <summary>
        /// Nombre del segundo representante
        /// </summary>
        public string NombreSegundoRepresentante { get; set; }
        /// <summary>
        /// Objeto de segundo representante
        /// </summary>
        public TrabajadorResponse SegundoRepresentante { get; set; }
        /// <summary>
        /// Código del tercer representante
        /// </summary>
        public Guid? CodigoTercerRepresentante { get; set; }
        /// <summary>
        /// Nombre del tercer representante
        /// </summary>
        public string NombreTercerRepresentante { get; set; }
        /// <summary>
        /// Objeto de tercer representante
        /// </summary>
        public TrabajadorResponse TercerRepresentante { get; set; }
        /// <summary>
        /// Código del cuarto representante
        /// </summary>
        public Guid? CodigoCuartoRepresentante { get; set; }
        /// <summary>
        /// Nombre del cuarto representante
        /// </summary>
        public string NombreCuartoRepresentante { get; set; }
        /// <summary>
        /// Objeto de cuarto representante
        /// </summary>
        public TrabajadorResponse CuartoRepresentante { get; set; }
        /// <summary>
        /// Dirección
        /// </summary>
        public string Direccion { get; set; }
        /// <summary>
        /// Logo Unidad Operativa
        /// </summary>
        public string LogoUnidadOperativa { get; set; }
    }
}

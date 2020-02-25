using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.UnidadOperativa
{
    /// <summary>
    /// Modelo de vista para el formulario de unidad operativa
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public class UnidadOperativaFormulario : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="niveles">Niveles a cargar</param>
        /// <param name="tipo">Tipo de visualización</param>
        public UnidadOperativaFormulario(List<CodigoValorResponse> niveles, string tipo)
        {
            this.Niveles = this.GenerarListadoOpcioneGenericoFormulario(niveles);
            this.UnidadesOperativasPadre = this.GenerarListadoOpcioneGenericoFormulario(null);
            this.TiposUnidadOperativa = this.GenerarListadoOpcioneGenericoFormulario(null);
            unidadOperativa = new UnidadOperativaResponse();
            this.unidadOperativa.Responsable = new TrabajadorResponse();
            this.unidadOperativa.PrimerRepresentante = new TrabajadorResponse();
            this.unidadOperativa.SegundoRepresentante = new TrabajadorResponse();
            this.unidadOperativa.TercerRepresentante = new TrabajadorResponse();
            this.unidadOperativa.CuartoRepresentante = new TrabajadorResponse();
            unidadOperativa.IndicadorActiva = true;
            this.Tipo = tipo;
        }

        /// <summary>
        /// Constructor usado para la edición de datos
        /// </summary>
        /// <param name="niveles">Niveles a cargar</param>
        /// <param name="unidadesSuperiores">Unidades Superiores a cargar</param>
        /// <param name="tipos">Tipos a cargar</param>
        /// <param name="unidadOperativa">Unidad operativa a editar</param>
        /// <param name="tipo">Tipo de visualización</param>
        public UnidadOperativaFormulario(List<CodigoValorResponse> niveles, List<UnidadOperativaResponse> unidadesSuperiores, List<CodigoValorResponse> tipos, UnidadOperativaResponse unidadOperativa, string tipo)
        {
            this.Niveles = this.GenerarListadoOpcioneGenericoFormulario(niveles, unidadOperativa.CodigoNivelJerarquia);
            this.UnidadesOperativasPadre = new List<SelectListItem>();
            this.UnidadesOperativasPadre = unidadesSuperiores.Select(u => new SelectListItem()
            {
                Value = u.CodigoUnidadOperativa.ToString(),
                Text = u.Nombre,
                Selected = (u.CodigoUnidadOperativa == unidadOperativa.CodigoUnidadOperativaPadre)
            }).ToList();
            this.UnidadesOperativasPadre = this.GenerarListadoOpcioneGenericoFormulario(this.UnidadesOperativasPadre);
            this.TiposUnidadOperativa = this.GenerarListadoOpcioneGenericoFormulario(tipos, unidadOperativa.CodigoTipoUnidadOperativa);
            this.unidadOperativa = unidadOperativa;
            this.unidadOperativa.Responsable = this.unidadOperativa.Responsable ?? new TrabajadorResponse();
            this.unidadOperativa.PrimerRepresentante = this.unidadOperativa.PrimerRepresentante ?? new TrabajadorResponse();
            this.unidadOperativa.SegundoRepresentante = this.unidadOperativa.SegundoRepresentante ?? new TrabajadorResponse();
            this.unidadOperativa.TercerRepresentante = this.unidadOperativa.TercerRepresentante ?? new TrabajadorResponse();
            this.unidadOperativa.CuartoRepresentante = this.unidadOperativa.CuartoRepresentante ?? new TrabajadorResponse();
            this.Tipo = tipo;
        }
        #region Propiedades
        /// <summary>
        /// Niveles
        /// </summary>
        public List<SelectListItem> Niveles { get; set; }
        /// <summary>
        /// Unidades operativas padre
        /// </summary>
        public List<SelectListItem> UnidadesOperativasPadre { get; set; }
        /// <summary>
        /// Tipos de unidades opeartivas
        /// </summary>
        public List<SelectListItem> TiposUnidadOperativa { get; set; }
        /// <summary>
        /// Unidad operativa
        /// </summary>
        public UnidadOperativaResponse unidadOperativa { get; set; }
        /// <summary>
        /// Tipo de Visualización
        /// </summary>
        /// 
        public List<SelectListItem> sistema { get; set; }
        /// <summary>
        /// Tipo de Visualización
        /// </summary>

        public string Tipo { get; set; }
        #endregion
    }
}

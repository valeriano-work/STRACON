using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;


namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.VariablePlantillaRequerimiento
{
    /// <summary>
    /// Modelo de vista Variable Plantilla Formulario
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150709
    /// Modificación:   
    /// </remarks>
    public class VariablePlantillaRequerimientoFormulario : GenericViewModel
    {
        /// <summary>
        /// Constructor Variable Plantilla Formulario
        /// </summary>
        /// <param name="plantilla">Plantilla</param>
        /// <param name="tipoVariable">Tipo Variable</param>
        public VariablePlantillaRequerimientoFormulario(List<PlantillaRequerimientoResponse> plantilla, List<CodigoValorResponse> tipoVariable)
        {
            var listaPlantilla = plantilla.Select(x => new CodigoValorResponse() { Codigo = x.CodigoPlantilla, Valor = x.Descripcion }).ToList();
            this.Plantilla = this.GenerarListadoOpcioneGenericoFormulario(listaPlantilla);
            this.Tipo = this.GenerarListadoOpcioneGenericoFormulario(tipoVariable);
            this.variableResponse = new VariableResponse()
            {
                IndicadorGlobal = false
            };
        }
        /// <summary>
        /// Constructor Variable Plantilla Formulario
        /// </summary>
        /// <param name="plantilla">Formulario</param>
        /// <param name="variable">Variable</param>
        /// <param name="tipoVariable">Tipo Variable</param>
        public VariablePlantillaRequerimientoFormulario(List<PlantillaRequerimientoResponse> plantilla, VariableResponse variable, List<CodigoValorResponse> tipoVariable)
        {
            var listaPlantilla = plantilla.Select(x => new CodigoValorResponse() { Codigo = x.CodigoPlantilla, Valor = x.Descripcion }).ToList();
            this.Plantilla = this.GenerarListadoOpcioneGenericoFormulario(listaPlantilla, variable.CodigoPlantilla);
            this.Tipo = this.GenerarListadoOpcioneGenericoFormulario(tipoVariable, variable.CodigoTipo);
            this.variableResponse = variable;
        }

        #region Propiedades
        /// <summary>
        /// Lista Plantilla
        /// </summary>
        public List<SelectListItem> Plantilla { get; set; }
        /// <summary>
        /// Lista Tipo
        /// </summary>
        public List<SelectListItem> Tipo { get; set; }
        /// <summary>
        /// Clases con campos Variable
        /// </summary>
        public VariableResponse variableResponse { get; set; }
        #endregion
    }
}

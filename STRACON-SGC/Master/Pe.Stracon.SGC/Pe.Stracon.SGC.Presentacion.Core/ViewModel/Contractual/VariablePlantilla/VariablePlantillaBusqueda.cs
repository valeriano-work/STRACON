using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Pe.GyM.Security.Account.Model;


namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.VariablePlantilla
{
    /// <summary>
    /// Modelo de vista  Variable Plantilla
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150709
    /// Modificación:   
    /// </remarks>
    public class VariablePlantillaBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor Variable Plantilla Busqueda
        /// </summary>
        /// <param name="plantilla">Plantilla</param>
        /// <param name="tipoVariable">Tipo Variable</param>
        public VariablePlantillaBusqueda(List<PlantillaResponse> plantilla, List<CodigoValorResponse> tipoVariable)
        {
            var listaPlantilla = plantilla.Select(x => new CodigoValorResponse() { Codigo = x.CodigoPlantilla, Valor = x.Descripcion }).ToList();
            this.Plantilla = this.GenerarListadoOpcioneGenericoFiltro(listaPlantilla);
            this.Tipo = this.GenerarListadoOpcioneGenericoFiltro(tipoVariable);
            this.AplicaPlantillas = this.GenerarListadoOpcionesSiNoFiltro();
            this.variableResponse = new VariableResponse();
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
        /// Lista Aplica todas las plantillas
        /// </summary>
        public List<SelectListItem> AplicaPlantillas { get; set; }
        /// <summary>
        /// Clases con campos Variable
        /// </summary>
        public VariableResponse variableResponse { get; set; }
        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }
        #endregion
    }
}

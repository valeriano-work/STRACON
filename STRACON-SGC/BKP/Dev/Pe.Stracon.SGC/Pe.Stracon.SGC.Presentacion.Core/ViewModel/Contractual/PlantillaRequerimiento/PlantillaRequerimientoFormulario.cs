using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Web.Mvc;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.PlantillaRequerimiento

{
    /// <summary>
    /// Modelo de vista de plantilla
    /// </summary>
    /// <remarks>
    /// Creación:                    </br>
    /// Modificación:                </br>
    /// </remarks>
    public class PlantillaRequerimientoFormulario : GenericViewModel

    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="estadoVigencia">Lista de Estados de Vigencia</param>
        public PlantillaRequerimientoFormulario(List<CodigoValorResponse> estadoVigencia, string indicadorCopia)
        {
            this.EstadoVigencia = this.GenerarListadoOpcioneGenericoFormulario(estadoVigencia);
            this.IndicadorCopia = indicadorCopia;
            this.Plantilla = new PlantillaRequerimientoResponse();
        }

        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="estadoVigencia">Lista de Estados de Vigencia</param>
        /// <param name="plantilla">Clase Response de Plantilla</param>
        public PlantillaRequerimientoFormulario(List<CodigoValorResponse> estadoVigencia, PlantillaRequerimientoResponse plantilla)
        {
           this.EstadoVigencia = this.GenerarListadoOpcioneGenericoFormulario(estadoVigencia, plantilla.CodigoEstadoVigencia);
           this.Plantilla = plantilla;
        }

        #region Propiedades
         /// <summary>
        /// Lista de Estados de Vigencia
        /// </summary>
        public List<SelectListItem> EstadoVigencia { get; set; }
        /// <summary>
        /// Clase Response de Plantilla
        /// </summary>
        public PlantillaRequerimientoResponse Plantilla { get; set; }
        /// <summary>
        /// Indica si el formulario nuevo es copia o no
        /// </summary>
        public string IndicadorCopia { get; set; }
        #endregion
    }
}

using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.PlantillaRequerimiento
{
    /// <summary>
    /// Modelo de vista para el registro de párrafos
    /// </summary>
    /// <remarks>
    /// Creación:     
    /// Modificación:
    /// </remarks>
    public class PlantillaRequerimientoParrafoFormulario : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        public PlantillaRequerimientoParrafoFormulario()
        {
            this.PlantillaRequerimientoParrafoModel = new PlantillaRequerimientoParrafoResponse();
        }

        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="plantillaParrafo">Lista de Párrafos</param>
        public PlantillaRequerimientoParrafoFormulario(PlantillaRequerimientoParrafoResponse plantillaParrafo)
        {
            PlantillaRequerimientoParrafoModel = new PlantillaRequerimientoParrafoResponse();
            this.PlantillaRequerimientoParrafoModel = plantillaParrafo;
        }

        #region Propiedades
        /// <summary>
        /// Modelo de Párrafo
        /// </summary>
        public PlantillaRequerimientoParrafoResponse PlantillaRequerimientoParrafoModel { get; set; }
        #endregion
    }
}

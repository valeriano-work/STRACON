using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Plantilla
{
    /// <summary>
    /// Modelo de vista para el registro de párrafos
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150527
    /// Modificación:
    /// </remarks>
    public class PlantillaParrafoFormulario : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        public PlantillaParrafoFormulario()
        {
            this.PlantillaParrafoModel = new PlantillaParrafoResponse();
        }

        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="plantillaParrafo">Lista de Párrafos</param>
        public PlantillaParrafoFormulario(PlantillaParrafoResponse plantillaParrafo)
        {
            PlantillaParrafoModel = new PlantillaParrafoResponse();
            this.PlantillaParrafoModel = plantillaParrafo;
        }

        #region Propiedades
        /// <summary>
        /// Modelo de Párrafo
        /// </summary>
        public PlantillaParrafoResponse PlantillaParrafoModel { get; set; }
        #endregion
    }
}

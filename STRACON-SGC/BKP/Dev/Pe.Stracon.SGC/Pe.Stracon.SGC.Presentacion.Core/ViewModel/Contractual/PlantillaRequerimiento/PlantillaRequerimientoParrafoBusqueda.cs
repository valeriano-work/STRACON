using Pe.GyM.Security.Account.Model;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.PlantillaRequerimiento
{
    /// <summary>
    /// Modelo de vista para la bandeja Plantilla Párrafo
    /// </summary>
    /// <remarks>
    /// Creación:      
    /// Modificación:   
    /// </remarks>
    public class PlantillaRequerimientoParrafoBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        public PlantillaRequerimientoParrafoBusqueda()
        {
            this.PlantillaRequerimientoParrafo = new PlantillaRequerimientoParrafoRequest();
        }

        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="plantilla">Clase de respuesta Plantilla</param>
        public PlantillaRequerimientoParrafoBusqueda(PlantillaRequerimientoResponse plantilla)
        {
            this.Plantilla = plantilla;
        }

        #region Propiedades
        /// <summary>
        /// Clase de respuesta Plantilla
        /// </summary>
        public PlantillaRequerimientoResponse Plantilla { get; set; }

        /// <summary>
        /// Clase de respuesta Plantilla Párrafo
        /// </summary>
        public PlantillaRequerimientoParrafoRequest PlantillaRequerimientoParrafo { get; set; }


        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }
        #endregion
    }
}
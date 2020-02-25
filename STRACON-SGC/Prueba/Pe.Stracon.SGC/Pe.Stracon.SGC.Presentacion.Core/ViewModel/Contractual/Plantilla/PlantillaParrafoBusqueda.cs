using Pe.GyM.Security.Account.Model;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Plantilla
{
    /// <summary>
    /// Modelo de vista para la bandeja Plantilla Párrafo
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150520
    /// Modificación:   
    /// </remarks>
    public class PlantillaParrafoBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        public PlantillaParrafoBusqueda()
        {
            this.PlantillaParrafo = new PlantillaParrafoRequest();
        }

        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="plantilla">Clase de respuesta Plantilla</param>
        public PlantillaParrafoBusqueda(PlantillaResponse plantilla)
        {
            this.Plantilla = plantilla;
        }

        #region Propiedades
        /// <summary>
        /// Clase de respuesta Plantilla
        /// </summary>
        public PlantillaResponse Plantilla { get; set; }

        /// <summary>
        /// Clase de respuesta Plantilla Párrafo
        /// </summary>
        public PlantillaParrafoRequest PlantillaParrafo { get; set; }


        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }
        #endregion
    }
}
using Pe.GyM.Security.Account.Model;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.PlantillaRequerimiento
{
    /// <summary>
    /// Modelo de vista para la bandeja Plantilla Nota Pie
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20170821
    /// Modificación:   
    /// </remarks>
    public class PlantillaRequerimientoNotaPieBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        public PlantillaRequerimientoNotaPieBusqueda()
        {
            this.PlantillaRequerimientoNotaPie = new PlantillaRequerimientoNotaPieRequest();
        }

        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="plantilla">Clase de respuesta Plantilla</param>
        public PlantillaRequerimientoNotaPieBusqueda(PlantillaRequerimientoResponse plantilla)
        {
            this.Plantilla = plantilla;
        }

        #region Propiedades
        /// <summary>
        /// Clase de respuesta Plantilla
        /// </summary>
        public PlantillaRequerimientoResponse Plantilla { get; set; }

        /// <summary>
        /// Clase de respuesta Plantilla Nota Pie
        /// </summary>
        public PlantillaRequerimientoNotaPieRequest PlantillaRequerimientoNotaPie { get; set; }


        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }
        #endregion
    }
}

using Pe.GyM.Security.Account.Model;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Plantilla
{
    /// <summary>
    /// Modelo de vista para la bandeja Plantilla Nota Pie
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20170821
    /// Modificación:   
    /// </remarks>
    public class PlantillaNotaPieBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        public PlantillaNotaPieBusqueda()
        {
            this.PlantillaNotaPie = new PlantillaNotaPieRequest();
        }

        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="plantilla">Clase de respuesta Plantilla</param>
        public PlantillaNotaPieBusqueda(PlantillaResponse plantilla)
        {
            this.Plantilla = plantilla;
        }

        #region Propiedades
        /// <summary>
        /// Clase de respuesta Plantilla
        /// </summary>
        public PlantillaResponse Plantilla { get; set; }

        /// <summary>
        /// Clase de respuesta Plantilla Nota Pie
        /// </summary>
        public PlantillaNotaPieRequest PlantillaNotaPie { get; set; }


        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }
        #endregion
    }
}

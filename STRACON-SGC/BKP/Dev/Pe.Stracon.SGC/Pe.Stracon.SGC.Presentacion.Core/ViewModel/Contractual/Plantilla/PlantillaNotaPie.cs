using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Plantilla
{
    /// <summary>
    /// Modelo de vista para el registro de notas al pie
    /// <remarks>
    /// Creación:  GMD 20170821
    /// Modificación:
    /// </remarks>
    public class PlantillaNotaPie : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        public PlantillaNotaPie()
        {
            this.PlantillaNotaPieModel = new PlantillaNotaPieResponse();
        }

        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="plantillaNota">Lista de Notas</param>
        public PlantillaNotaPie(PlantillaNotaPieResponse plantillaNota)
        {
            PlantillaNotaPieModel = new PlantillaNotaPieResponse();
            this.PlantillaNotaPieModel = plantillaNota;
        }

        #region Propiedades
        /// <summary>
        /// Modelo de Nota
        /// </summary>
        public PlantillaNotaPieResponse PlantillaNotaPieModel { get; set; }
        #endregion
    }
}

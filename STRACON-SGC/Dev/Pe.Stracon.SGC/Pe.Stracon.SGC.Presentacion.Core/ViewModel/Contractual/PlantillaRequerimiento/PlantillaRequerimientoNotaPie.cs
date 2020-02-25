using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.PlantillaRequerimiento
{
    /// <summary>
    /// Modelo de vista para el registro de notas al pie
    /// <remarks>
    /// Creación:  GMD 20170821
    /// Modificación:
    /// </remarks>
    public class PlantillaRequerimientoNotaPie : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        public PlantillaRequerimientoNotaPie()
        {
            this.PlantillaRequerimientoNotaPieModel = new PlantillaRequerimientoNotaPieResponse();
        }

        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="plantillaNota">Lista de Notas</param>
        public PlantillaRequerimientoNotaPie(PlantillaRequerimientoNotaPieResponse plantillaNota)
        {
            PlantillaRequerimientoNotaPieModel = new PlantillaRequerimientoNotaPieResponse();
            this.PlantillaRequerimientoNotaPieModel = plantillaNota;
        }

        #region Propiedades
        /// <summary>
        /// Modelo de Nota
        /// </summary>
        public PlantillaRequerimientoNotaPieResponse PlantillaRequerimientoNotaPieModel { get; set; }
        #endregion
    }
}

using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ListadoContrato
{
    /// <summary>
    /// Modelo de vista de Contrato Párrafo Bien
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150803 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ContratoParrafoBienFormulario
    {
        /// <summary>
        /// Constructor usado para la búsqueda de datos
        /// </summary>
        public ContratoParrafoBienFormulario(List<BienResponse> bien)
        {
            this.Bien = bien;
        }

        #region Propiedades
        /// <summary>
        /// Lista de Bienes
        /// </summary>
        public List<BienResponse> Bien { get; set; }
        #endregion
    }
}

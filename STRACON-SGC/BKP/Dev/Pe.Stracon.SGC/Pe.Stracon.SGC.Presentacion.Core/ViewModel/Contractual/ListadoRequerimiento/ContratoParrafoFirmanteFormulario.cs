using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ListadoRequerimiento
{
    /// <summary>
    /// Modelo de vista de Contrato Párrafo Firmante
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20151027 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ContratoParrafoFirmanteFormulario
    {
        /// <summary>
        /// Constructor usado para la búsqueda de datos
        /// </summary>
        public ContratoParrafoFirmanteFormulario(/*List<ContratoFirmanteResponse> firmante*/ Guid codigoVariable)
        {
            //this.Firmante = firmante;
            this.CodigoVariable = codigoVariable;
        }

        #region Propiedades
        /// <summary>
        /// Lista de Bienes
        /// </summary>
        public List<ContratoFirmanteResponse> Firmante { get; set; }

        public Guid CodigoVariable { get; set; }
        #endregion
    }
}

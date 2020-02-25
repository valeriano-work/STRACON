using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ListadoContrato
{
    /// <summary>
    /// Modelo de vista de Contrato Párrafo Tabla
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150630 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ContratoParrafoTablaFormulario
    {
        /// <summary>
        /// Constructor usado para la búsqueda de datos
        /// </summary>
        public ContratoParrafoTablaFormulario(List<VariableCampoResponse> variableCampo)
        {
            this.VariableCampo = variableCampo;
        }

        #region Propiedades
        /// <summary>
        /// Lista de Campos de Variable
        /// </summary>
        public List<VariableCampoResponse> VariableCampo { get; set; }
        #endregion
    }
}

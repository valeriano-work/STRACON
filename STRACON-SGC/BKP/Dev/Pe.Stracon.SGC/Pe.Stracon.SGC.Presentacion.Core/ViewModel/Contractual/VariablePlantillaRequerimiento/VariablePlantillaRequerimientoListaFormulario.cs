using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.VariablePlantillaRequerimiento
{
    /// <summary>
    /// Modelo de vista Variable Plantilla Lista Formulario
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150709
    /// Modificación:   
    /// </remarks>
    public class VariablePlantillaRequerimientoListaFormulario : GenericViewModel
    {
        #region Propiedades
        /// <summary>
        /// Lista de opciones de Variable
        /// </summary>
        public VariableListaResponse VariableLista { get; set; }
        #endregion

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public VariablePlantillaRequerimientoListaFormulario(string codigoVariable)
        {
            this.VariableLista = new VariableListaResponse();
            if (codigoVariable != null && codigoVariable != "" && codigoVariable != "00000000-0000-0000-0000-000000000000")
            {
                this.VariableLista.CodigoVariable = new Guid(codigoVariable);
            }
        }

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public VariablePlantillaRequerimientoListaFormulario(VariableListaResponse variableListaResponse)
        {
            this.VariableLista = variableListaResponse;
        }
    }
}

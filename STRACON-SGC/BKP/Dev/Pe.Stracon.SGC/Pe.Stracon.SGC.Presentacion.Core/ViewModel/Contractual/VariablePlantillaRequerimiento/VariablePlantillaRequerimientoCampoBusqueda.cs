using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.VariablePlantillaRequerimiento
{
    /// <summary>
    /// Modelo de vista Variable Plantilla Campo Busqueda
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150709
    /// Modificación:   
    /// </remarks>
    public class VariablePlantillaRequerimientoCampoBusqueda : GenericViewModel
    {
        #region Propiedades
        /// <summary>
        /// Clases con campos Variable
        /// </summary>
        public VariableResponse Variable { get; set; }
        #endregion

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public VariablePlantillaRequerimientoCampoBusqueda(VariableResponse variableResponse)
        {
            this.Variable = variableResponse;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.VariablePlantilla
{
    /// <summary>
    /// Modelo de vista Variable Plantilla Campo Formulario
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150709
    /// Modificación:   
    /// </remarks>
    public class VariablePlantillaCampoFormulario : GenericViewModel
    {
        #region Propiedades
        /// <summary>
        /// Campos de Variable
        /// </summary>
        public VariableCampoResponse VariableCampo { get; set; }
        /// <summary>
        /// Lista de Tipos de Alineamiento
        /// </summary>
        public List<SelectListItem> TipoAlineamiento { get; set; }
        #endregion

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public VariablePlantillaCampoFormulario(string codigoVariable, List<CodigoValorResponse> listaTipoAlineamiento)
        {
            this.VariableCampo = new VariableCampoResponse();
            if (codigoVariable != null && codigoVariable != "" && codigoVariable != "00000000-0000-0000-0000-000000000000")
            {
                this.VariableCampo.CodigoVariable = new Guid(codigoVariable);
            }
            this.TipoAlineamiento = this.GenerarListadoOpcioneGenericoFormulario(listaTipoAlineamiento);
        }

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public VariablePlantillaCampoFormulario(VariableCampoResponse variableCampoResponse, List<CodigoValorResponse> listaTipoAlineamiento)
        {
            this.VariableCampo = variableCampoResponse;
            this.TipoAlineamiento = this.GenerarListadoOpcioneGenericoFormulario(listaTipoAlineamiento, variableCampoResponse.TipoAlineamiento);
        }
    }
}

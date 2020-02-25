using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ListadoContrato
{
    /// <summary>
    /// Modelo de vista de Contrato Vista Previa
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150608 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ContratoVistaPreviaFormulario : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        public ContratoVistaPreviaFormulario()
        {
            this.Contrato = new ContratoResponse();
        }

        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        public ContratoVistaPreviaFormulario(ContratoDocumentoResponse contratoDocumento)
        {
            this.ContratoDocumento = contratoDocumento;
        }

        #region Propiedades
        /// <summary>
        /// Clase Response de Contrato
        /// </summary>
        public ContratoResponse Contrato { get; set; }

        /// <summary>
        /// Clase Response de Contrato Documento
        /// </summary>
        public ContratoDocumentoResponse ContratoDocumento { get; set; }
        #endregion
    }
}

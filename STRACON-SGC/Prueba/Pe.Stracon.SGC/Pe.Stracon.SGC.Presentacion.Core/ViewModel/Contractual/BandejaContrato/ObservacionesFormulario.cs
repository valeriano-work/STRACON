using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.BandejaContrato
{
    /// <summary>
    /// Modelo de vista para Observaciones de Formulario
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ObservacionesFormulario : GenericViewModel
    {
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="listadoContratoResponse"></param>
        public ObservacionesFormulario(ListadoContratoResponse listadoContratoResponse, ContratoDocumentoResponse contratoDocumento)
        {
            this.Contrato = listadoContratoResponse;
            this.ContratoDocumento = contratoDocumento;
        }
        /// <summary>
        /// Datos del Contrato
        /// </summary>
        public ListadoContratoResponse Contrato { get; set; }

        /// <summary>
        /// Documento del contrato
        /// </summary>
        public ContratoDocumentoResponse ContratoDocumento { get; set; }
    }
}

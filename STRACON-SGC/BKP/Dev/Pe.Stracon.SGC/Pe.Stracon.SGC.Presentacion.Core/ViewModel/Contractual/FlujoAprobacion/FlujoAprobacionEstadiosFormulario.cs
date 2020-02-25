using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion
{
    /// <summary>
    /// Modelo de vista de flujo aprobacion formulario
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150511
    /// Modificación:   
    /// </remarks>
    public class FlujoAprobacionEstadiosFormulario : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        public FlujoAprobacionEstadiosFormulario(/*List<CodigoValorResponse> listaOrdenFirmantes*/)
        {
            this.flujoAprobacionEstadioResponse = new FlujoAprobacionEstadioResponse();
            this.flujoAprobacionEstadioResponse.ListaNombreInformado = new Dictionary<string, string>();
            this.flujoAprobacionEstadioResponse.ListaNombreRepresentante = new Dictionary<string, string>();
            this.flujoAprobacionEstadioResponse.ListaNombreResponsableVinculadas = new Dictionary<string, string>();
            //this.ListaOrdenFirmantes = this.GenerarListadoOpcioneGenericoFormulario(listaOrdenFirmantes);
        }
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="flujoAprobacionEstadio">Flujo aprobacion estadio</param>
        public FlujoAprobacionEstadiosFormulario(FlujoAprobacionEstadioResponse flujoAprobacionEstadio)
        {
            this.flujoAprobacionEstadioResponse = flujoAprobacionEstadio;
        }
       

        #region Propiedades
        /// <summary>
        /// Objeto Flujo Aprobación Response
        /// </summary>
        public FlujoAprobacionEstadioResponse flujoAprobacionEstadioResponse { get; set; }

        /// <summary>
        /// Objeto Lista Orden de firmantes
        /// </summary>
        public List<SelectListItem> ListaOrdenFirmantes { get; set; }
        #endregion
    }
}

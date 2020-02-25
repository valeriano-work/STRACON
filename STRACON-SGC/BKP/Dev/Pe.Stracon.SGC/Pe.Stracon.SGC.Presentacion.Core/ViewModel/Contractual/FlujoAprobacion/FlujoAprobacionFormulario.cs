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
    public class FlujoAprobacionFormulario : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        public FlujoAprobacionFormulario()
        {
            
        }
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="unidadOperativa">Unidad Operativa</param>
        /// <param name="tipoServicio">Tipo de Servicio</param>
        public FlujoAprobacionFormulario(List<UnidadOperativaResponse> unidadOperativa, List<CodigoValorResponse> tipoServicio)
        {
            this.UnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFormulario(unidadOperativa);
            this.TipoServicio = this.GenerarListadoOpcioneGenericoListaFormulario(tipoServicio).OrderBy(item => item.Text).ToList();
            this.flujoAprobacionResponse = new FlujoAprobacionResponse();
            this.flujoAprobacionResponse.ListaPrimerFirmante = new Dictionary<string, string>();
            this.flujoAprobacionResponse.ListaSegundoFirmante = new Dictionary<string, string>();

            this.flujoAprobacionResponse.ListaPrimerFirmanteVinculada = new Dictionary<string, string>();
            this.flujoAprobacionResponse.ListaSegundoFirmanteVinculada = new Dictionary<string, string>();
        }
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="unidadOperativa">Unidad Operativa</param>
        /// <param name="tipoServicio">Tipo de Servicio</param>
        /// <param name="flujoAprobacionResponse">Flujo de Aprobacion Response</param>
        public FlujoAprobacionFormulario(List<UnidadOperativaResponse> unidadOperativa, List<CodigoValorResponse> tipoServicio, FlujoAprobacionResponse flujoAprobacionResponse)
        {
            this.UnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFormulario(unidadOperativa, flujoAprobacionResponse.CodigoUnidadOperativa);
            this.TipoServicio = this.GenerarListadoOpcioneGenericoListaFormulario(tipoServicio, flujoAprobacionResponse.ListaTipoServicio).OrderBy(item => item.Text).ToList();
            this.flujoAprobacionResponse = flujoAprobacionResponse;
        }

        #region Propiedades
        /// <summary>
        /// Unidad Operativa
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }
        /// <summary>
        /// Tipo de Servicio
        /// </summary>
        public List<SelectListItem> TipoServicio { get; set; }
        /// <summary>
        /// Campos flujo Aprobacion Response
        /// </summary>
        public FlujoAprobacionResponse flujoAprobacionResponse { get; set; }
        #endregion
    }
}

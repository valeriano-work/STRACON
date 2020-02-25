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
    public class FlujoAprobacionFormularioCopiarEstadio : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="unidadOperativa">Unidad Operativa</param>
        /// <param name="tipoServicio">Tipo de Servicio</param>
        /// <param name="tipoRequerimiento">Tipo de Requerimiento</param>
        /// <param name="tipoContrato">Tipo de Contrato</param>
        public FlujoAprobacionFormularioCopiarEstadio(List<UnidadOperativaResponse> unidadOperativa, List<CodigoValorResponse> tipoServicio, List<CodigoValorResponse> tipoRequerimiento, List<CodigoValorResponse> tipoContrato, FlujoAprobacionResponse flujoAprobacion)
        {
            this.UnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFormulario(unidadOperativa, flujoAprobacion.CodigoUnidadOperativa);
            this.TipoServicio = this.GenerarListadoOpcioneGenericoFormulario(tipoServicio/*, flujoAprobacion.CodigoTipoServicio*/);
            this.TipoRequerimiento = this.GenerarListadoOpcioneGenericoFormulario(tipoRequerimiento, flujoAprobacion.CodigoTipoContrato);
            this.TipoContrato = this.GenerarListadoOpcioneGenericoFormulario(tipoContrato);
            this.flujoAprobacionResponse = flujoAprobacion;
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
        /// Tipo de Requerimiento
        /// </summary>
        public List<SelectListItem> TipoRequerimiento { get; set; }
        /// <summary>
        /// Tipo de Contrato
        /// </summary>
        public List<SelectListItem> TipoContrato { get; set; }

        /// <summary>
        /// Campos flujo Aprobacion Response
        /// </summary>
        public FlujoAprobacionResponse flujoAprobacionResponse { get; set; }
        #endregion
    }
}

using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ProcesoAuditoria
{
    /// <summary>
    /// Modelo de vista Formulario Proceso Auditoria
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150709
    /// Modificación:   
    /// </remarks>
    public class ProcesoAuditoriaFormulario : GenericViewModel
    {
        /// <summary>
        /// Constructor Formulario Proceso de auditoria
        /// </summary>
        public ProcesoAuditoriaFormulario()
        {
        }

        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="unidadOperativa">Unidad Operativa</param>
        public ProcesoAuditoriaFormulario(List<UnidadOperativaResponse> unidadOperativa)
        {
            this.UnidadOperativa = new List<SelectListItem>();
            this.UnidadOperativa.Add(new SelectListItem { Value = "", Text = GenericoResource.EtiquetaSeleccionar });
            this.UnidadOperativa.AddRange(
                unidadOperativa.Select(item => new SelectListItem { Value = item.CodigoUnidadOperativa.ToString(), Text = item.Nombre }
            ));
            this.procesoAuditoriaResponse = new ProcesoAuditoriaResponse();
        }

        /// <summary>
        /// Constructor usado para la edicion de datos
        /// </summary>
        /// <param name="unidadOperativa">Unidad Operativa</param>
        /// <param name="procesoAuditoriaRequest">Proceso Auditoria Request</param>
        public ProcesoAuditoriaFormulario(List<UnidadOperativaResponse> unidadOperativa, ProcesoAuditoriaResponse procesoAuditoriaResponse)
        {
            this.UnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFormulario(unidadOperativa, procesoAuditoriaResponse.CodigoUnidadOperativa);
            this.procesoAuditoriaResponse = procesoAuditoriaResponse;
        }


        #region Propiedades
        /// <summary>
        /// Lista de unidades operativas
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }
        /// <summary>
        /// Campos Proceso Auditoria Response
        /// </summary>
        public ProcesoAuditoriaResponse procesoAuditoriaResponse { get; set; }
        #endregion
    }
}

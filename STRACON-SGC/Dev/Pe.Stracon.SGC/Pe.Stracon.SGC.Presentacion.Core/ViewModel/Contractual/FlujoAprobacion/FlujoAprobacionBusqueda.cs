using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using Pe.GyM.Security.Account.Model;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion
{
    /// <summary>
    /// Modelo de vista para la configuración del Flujo de Aprobación.
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public class FlujoAprobacionBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="unidadOperativa">Unidad Operativa</param>
        /// <param name="tipoServicio">Tipo de Servicio</param>
        /// <param name="tipoContrato">Tipo de Contrato</param>
        public FlujoAprobacionBusqueda(List<UnidadOperativaResponse> unidadOperativa, List<CodigoValorResponse> tipoServicio)
        {
            this.UnidadOperativa = new List<SelectListItem>();
            if (unidadOperativa != null)
            {
                this.UnidadOperativa.Add(new SelectListItem { Value = "", Text = GenericoResource.EtiquetaTodos });
                this.UnidadOperativa.AddRange(
                    unidadOperativa.Select(item => new SelectListItem { Value = item.CodigoUnidadOperativa.ToString(), Text = item.Nombre }
                ));
            }
            this.TipoServicio = this.GenerarListadoOpcioneGenericoFiltro(tipoServicio);
        }

        #region Propiedades
        /// <summary>
        /// Lista de unidades operativas
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }
        /// <summary>
        /// Lista Tipo Servicio
        /// </summary>
        public List<SelectListItem> TipoServicio { get; set; }
        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }
        
        #endregion
    }
}

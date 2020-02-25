using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Pe.GyM.Security.Account.Model;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ProcesoAuditoria
{
    /// <summary>
    /// Modelo de vista Proceso de Auditoria
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150709
    /// Modificación:   
    /// </remarks>
    public class ProcesoAuditoriaBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor Usado para el registro de datos
        /// </summary>
        /// <param name="unidadOperativa">Unidad Operativa</param>
        public ProcesoAuditoriaBusqueda(List<UnidadOperativaResponse> unidadOperativa)
        {
            this.UnidadOperativa = new List<SelectListItem>();
            this.UnidadOperativa.Add(new SelectListItem { Value = "", Text = GenericoResource.EtiquetaTodos });
            this.UnidadOperativa.AddRange(
                unidadOperativa.Select(item => new SelectListItem { Value = item.CodigoUnidadOperativa.ToString(), Text = item.Nombre }
            ));
        }

        #region Propiedades
        /// <summary>
        /// Lista de unidades operativas
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }

        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }
        #endregion
    }
}

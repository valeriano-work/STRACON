using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Web.Mvc;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion
{
    /// <summary>
    /// Modelo de vista para la configuración del Flujo Aprobación Estadios Busqueda.
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150511
    /// Modificación:   
    /// </remarks>
    public class FlujoAprobacionEstadiosBusqueda : GenericViewModel
    {

        /// <summary>
        /// Constructor Flujo Aprobacion Estadios 
        /// </summary>
        /// <param name="flujoAprobacion"></param>
        public FlujoAprobacionEstadiosBusqueda(FlujoAprobacionResponse flujoAprobacion)
        {
            this.flujoAprobacionResponse = flujoAprobacion;
        }
        #region Propiedades
        /// <summary>
        /// Objeto Flujo Aprobación
        /// </summary>
        public FlujoAprobacionResponse flujoAprobacionResponse { get; set; }
        #endregion
    }
}

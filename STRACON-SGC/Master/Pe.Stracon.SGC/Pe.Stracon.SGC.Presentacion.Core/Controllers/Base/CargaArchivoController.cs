using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Base
{
    /// <summary>
    /// Controladora de Componente de Carga de Archivo
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150318
    /// Modificación:
    /// </remarks>
    public class CargaArchivoController : GenericController
    {
        #region Vistas Parciales
        /// <summary>
        /// Formulario de Carga
        /// </summary>
        /// <returns>Vista de Formulario de carga</returns>
        public ActionResult FormularioCarga()
        {
            return PartialView();
        }
        #endregion
    }
}

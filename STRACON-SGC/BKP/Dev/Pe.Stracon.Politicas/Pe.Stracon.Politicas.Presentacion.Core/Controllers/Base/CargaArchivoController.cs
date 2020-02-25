using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Core.Controllers.Base
{
    /// <summary>
    /// Controladora del Componente de Carga de Archivo
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150318
    /// Modificación:
    /// </remarks>
    public class CargaArchivoController : GenericController
    {
        /// <summary>
        /// Muestra el popup de Formulario de Carga
        /// </summary>
        /// <returns>Vista Parcial</returns>
        public ActionResult FormularioCarga()
        {
            return PartialView();
        }
    }
}

using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using System.Web.Mvc;


namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    public class ReporteTiempoEjecucionController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Servicio de manejo de Unidad Operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }
        #endregion

        #region Vistas
        /// <summary>
        /// Muestra la vista Index 
        /// </summary> 
        /// <returns>Vista Index</returns>
        public ActionResult TiempoEjecucion()
        {
            return View();
        }
        #endregion

        #region Vistas Parciales
        #endregion

        #region Json
        #endregion
    }
}

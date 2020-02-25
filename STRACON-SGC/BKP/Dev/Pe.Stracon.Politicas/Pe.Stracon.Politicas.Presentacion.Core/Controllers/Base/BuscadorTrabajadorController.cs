using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Core.Controllers.Base
{
    /// <summary>
    /// Controladora del Componente de Búsqueda de Trabajadores
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150318
    /// Modificación:
    /// </remarks>
    public class BuscadorTrabajadorController : GenericController
    {
        /// <summary>
        /// Servicio para el manejo de Trabajadores
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }

        #region Vistas Parciales
        /// <summary>
        /// Muestra el popup de búsqueda de trabajadores
        /// </summary>
        /// <returns>Vista Parcial</returns>
        public ActionResult BuscarTrabajador()
        {
            return PartialView();
        }

        #endregion

        #region Json
        /// <summary>
        /// Método para recargar la grilla
        /// </summary>
        /// <param name="nombreUsuario">Nombre de Usuario</param>
        /// <param name="nombreTrabajador">Nombre de Trabajador</param>
        /// <returns>Json con la estructura a mostrar</returns>
        public JsonResult Buscar(string nombreUsuario, string nombreTrabajador)
        {
            var resultado = trabajadorService.BuscarTrabajador(new TrabajadorRequest() 
            { 
                CodigoIdentificacion = nombreUsuario,
                Nombres = nombreTrabajador
            });

            return Json(resultado);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Base;
using Pe.Stracon.SGC.Aplicacion.Core.Base;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Base
{
    /// <summary>
    /// Controladora de Componente de Búsqueda de Trabajadores
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150318
    /// Modificación:
    /// </remarks>
    public class BuscadorProveedorController : GenericController
    {
        #region Propiedades
        /// <summary>
        /// Serviciop para el manejo de Proveedores
        /// </summary>
        public IProveedorService proveedorService { get; set; }
        #endregion

        #region Vistas Parciales
        /// <summary>
        /// Muestra el popup de búsqueda de Proveedores
        /// </summary>
        /// <returns>Vista Parcial</returns>
        public ActionResult BuscarProveedor()
        {
            return PartialView();
        }
        #endregion

        #region Json
        /// <summary>
        /// Método para recargar la grilla
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Lista de proveedores</returns>
        public JsonResult BuscarProveedorOracle(ProveedorRequest filtro)
        {
            var resultado = proveedorService.BuscarProveedorOracle(new ProveedorRequest() { RucNombreProveedor = filtro.RucNombreProveedor });
            var json =  Json(resultado);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        /// <summary>
        /// Método para recargar la grilla
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Lista de proveedores</returns>
        public JsonResult BuscarProveedorSAP(ProveedorRequest filtro)
        {
            var resultado = proveedorService.BuscarProveedorSAP(new ProveedorRequest() { RucNombreProveedor = filtro.RucNombreProveedor });
            var json = Json(resultado);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        ///// <summary>
        ///// Método para buscar los proveedores que tienen contrato y que se guardan en la tabla [CTR].[PROVEEDOR]
        ///// </summary>
        ///// <param name="rucNombreProveedor">Filtro de búsqueda</param>
        ///// <returns>Lista de proveedores</returns>
        //public JsonResult BuscarProveedorLocal(string rucNombreProveedor)//ProveedorRequest filtro)
        //{
        //    ProveedorRequest filtro = new ProveedorRequest();
        //    filtro.NombreComercial = rucNombreProveedor;

        //    var resultado = proveedorService.BuscarProveedor(filtro);
        //    return Json(resultado.Result, JsonRequestBehavior.AllowGet);
        //}
        #endregion
    }
}

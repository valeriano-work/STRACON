using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Bienes;
using Pe.Stracon.SGC.Cross.Core.Util;
using Pe.GyM.Security.Web.Filters;
using Pe.GyM.Security.Web.Session;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Bienes
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150720
    /// Modificación:
    /// </remarks>
    public class BienesController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de parametros
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Servicio de manejo de bienes
        /// </summary>
        public IBienService bienService { get; set; }

        #endregion

        #region Vistas

        /// <summary>
        /// Vista Principal, checkin para demo
        /// </summary>
        /// <returns>Vista Principal</returns>
        public ActionResult Index()
        {
            var listaTipoBien = retornaTipoBien();
            var listaTipoTarifa = retornaTipoTarifaBien();            
            BienesBusqueda modelo = new BienesBusqueda(listaTipoBien, listaTipoTarifa);
            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/Bienes/");
            return View(modelo);
        }
        /// <summary>
        /// Bandeja Bien Alquiler
        /// </summary>
        /// <param name="codigoBien"></param>
        /// <param name="nombreTipoBien"></param>
        /// <param name="numeroSerie"></param>
        /// <param name="descripcion"></param>
        /// <param name="marca"></param>
        /// <returns>Vista Bandeja Bien Alquiler</returns>
        public ActionResult BandejaBienAlquiler(string codigoBien, string nombreTipoBien =null, 
                                                string numeroSerie=null, string descripcion=null,string marca=null )
        {
            string nombreUni = string.Empty, nombreUnidades = string.Empty;
            var periodoAlq = politicaService.ListaPeriodoAlquilerDinamico().Result;            
            if (string.IsNullOrEmpty(codigoBien))
            {
                codigoBien = Guid.Empty.ToString();
            }
            var entBien = bienService.RetornaBienPorId(Guid.Parse(codigoBien)).Result;
            var filtroPeriodo = periodoAlq.Where(a => a.Atributo1 == entBien.CodigoPeriodoAlquiler).ToList();
            if (filtroPeriodo !=null && filtroPeriodo.Count > 0)
            {
                nombreUni = filtroPeriodo[0].Atributo4;
                nombreUnidades = filtroPeriodo[0].Atributo5;
            }

            ViewBag.unidad = nombreUni;
            ViewBag.unidades = nombreUnidades;
            ViewBag.codigoBien = codigoBien;
            ViewBag.nombreTipoBien = nombreTipoBien;
            ViewBag.numeroSerie = numeroSerie;
            ViewBag.descripcion = descripcion;
            ViewBag.marca = marca;
            ViewBag.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/Bienes/");

            return View();
        }
        #endregion

        #region Vistas Parciales
        /// <summary>
        /// Formulario de Bienes
        /// </summary>
        /// <param name="codigoBien">Codigo Bien</param>
        /// <returns>Vista Parcial de Formulario Bienes</returns>
        public ActionResult FormularioBienes(string codigoBien)
        {
            var listaTipoBien = retornaTipoBien();
            var listaTipoTarifa = retornaTipoTarifaBien();
            var listaMoneda = retornaMonedaBien();
            var listaMesInicioAlquiler = Utilitario.ObtenerListaMeses().Select(item => new CodigoValorResponse() { Codigo = item.Key, Valor = item.Value }).ToList();
            BienesFormulario modelo = new BienesFormulario(listaTipoBien, listaTipoTarifa, listaMoneda, listaMesInicioAlquiler);
            if (!string.IsNullOrEmpty(codigoBien))
            {
                var resultBien = bienService.RetornaBienPorId(Guid.Parse(codigoBien));
                if (resultBien.IsSuccess)
                {
                    modelo.Bien = resultBien.Result;
                    var periodosBien = bienService.PeriodoAlquilerPorTarifa(modelo.Bien.CodigoTipoTarifa).Result;

                    foreach (var item in periodosBien)
	                {
                        modelo.lstPeriodoAlquiler.Add(new SelectListItem { Text = item.Valor.ToString(), Value=item.Codigo.ToString()});
	                }
                }
            }
            modelo.lstNumeroSerie = bienService.ListaBienRegistro(DatosConstantes.TipoContenidoBienRegistro.NumeroSerie).Result;
            modelo.lstDescripcion = bienService.ListaBienRegistro(DatosConstantes.TipoContenidoBienRegistro.Descripcion).Result;
            modelo.lstMarca = bienService.ListaBienRegistro(DatosConstantes.TipoContenidoBienRegistro.Marca).Result;
            modelo.lstModelo = bienService.ListaBienRegistro(DatosConstantes.TipoContenidoBienRegistro.Modelo).Result;

            return PartialView(modelo);
        }
        /// <summary>
        /// Vista del formulario para información del Bien Alquiler
        /// </summary>
        /// <param name="codigoBienAlquiler">coidog del Bien Alquiler</param>
        /// <returns>Vista de Formu</returns>
        public ActionResult FormularioBienAlquiler(string codigoBien, string codigoBienAlquiler)
        {
            string nombreUni = string.Empty, nombreUnidades = string.Empty;
            BienAlquilerFormulario modelo = new BienAlquilerFormulario();
            if (!string.IsNullOrEmpty(codigoBien))
            {                
                var periodoAlq = politicaService.ListaPeriodoAlquilerDinamico().Result;
                var entBien = bienService.RetornaBienPorId(Guid.Parse(codigoBien)).Result;
                var filtroPeriodo = periodoAlq.Where(a => a.Atributo1 == entBien.CodigoPeriodoAlquiler).ToList();
                if (filtroPeriodo != null && filtroPeriodo.Count > 0)
                {
                    nombreUni = filtroPeriodo[0].Atributo4;
                    nombreUnidades = filtroPeriodo[0].Atributo5;
                }                
            }

            if (!string.IsNullOrEmpty(codigoBienAlquiler))
            {
                var resultBienAlquiler = bienService.RetornaBienAlquilerPorId(Guid.Parse(codigoBienAlquiler)).Result;                                
                modelo.BienAlquiler = resultBienAlquiler;
            }
            ViewBag.unidad = nombreUni;
            ViewBag.unidades = nombreUnidades;
            return PartialView(modelo);
        }

        #endregion

        #region Json

        /// <summary>
        /// Retorna listado de bienes
        /// </summary>
        /// <param name="objFiltro">Objeto Filtro</param>
        /// <returns>Lista con el resultado de la operación</returns>
        public JsonResult ListaBienesBandeja(BienRequest objFiltro)
        {
            var listaTipoBien = retornaTipoBien();
            var listaTipoTarifa = retornaTipoTarifaBien();
            var listaMoneda = retornaMonedaBien();
            var listaPeriodAl = retornaPeriodoAlquilerBien();

            var resultado = bienService.ListarBienes(objFiltro, listaTipoBien, listaTipoTarifa, listaMoneda, listaPeriodAl);
            var jsonResult = Json(resultado, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = Int32.MaxValue;
            return jsonResult;
        }
        /// <summary>
        /// Registra los bienes
        /// </summary>
        /// <param name="objParam">Objeto de Parametro</param>
        /// <returns>1 si actualizar registro OK y -1 si hubo error.</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarBienes(BienRequest objParam)
        {
            var resultado = bienService.RegistraEditaBien(objParam);
            return Json(resultado);
        }
        /// <summary>
        /// Registra los precios del bien Alquiler
        /// </summary>
        /// <param name="objParam">objeto request del bien-alquiler</param>
        /// <returns>1 si actualizar registro OK y -1 si hubo error.</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarBienAlquiler(BienAlquilerRequest objParam)
        {
            var resultado = bienService.RegistraEditaBienAlquiler(objParam);
            return Json(resultado);
        }
        /// <summary>
        /// Método para la bandejas de bienes alquiler
        /// </summary>
        /// <param name="codigoBien">codigo del bien</param>
        /// <returns>Retorna los bienes de alquiler por Bien</returns>
        public JsonResult ListaBienAlquilerBandeja(string codigoBien)
        {
            if (string.IsNullOrEmpty(codigoBien))
            {
                codigoBien = Guid.Empty.ToString();
            }
            var resultado = bienService.ListarBienAlquiler(Guid.Parse(codigoBien));
            return Json(resultado);
        }
        /// <summary>
        /// Elimina un registro del tipo Bien
        /// </summary>
        /// <param name="codigoBien">cóigo del bien</param>
        /// <returns>1 si eliminación OK y -1 si hubo error.</returns>
        [AuthorizeEliminarFilter]
        public JsonResult EliminarBien(List<object> listaCodigosBien)
        {
            var result = bienService.EliminarBien(listaCodigosBien);
            return Json(result);
        }
        /// <summary>
        /// Elimina un registro de la entidad Bien-Alquiler
        /// </summary>
        /// <param name="listaCodigosBienAlquiler">código del bien alquiler</param>
        /// <returns>1 si eliminación OK y -1 si hubo error.</returns>
        [AuthorizeEliminarFilter]
        public JsonResult EliminarBienAlquiler(List<object> listaCodigosBienAlquiler)
        {
            var result = bienService.EliminarBienAlquiler(listaCodigosBienAlquiler);
            return Json(result);
        }

        /// <summary>
        /// Sincronizar bienes de servicio de AMT
        /// </summary>
        /// <returns>Actualizar equipos</returns>
        public JsonResult SincronizarServicioAmt()
        {
            var result = bienService.SincronizarBienesServicioAmt();

            var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = Int32.MaxValue;
            jsonResult.RecursionLimit = 1024;

            return jsonResult;
        }

        #endregion

        #region parametros_generales

        /// <summary>
        /// Retorna la lista de Tipo de Bien de parámetros
        /// </summary>
        /// <returns>Lista de Tipo de bien de parametros</returns>
        public List<CodigoValorResponse> retornaTipoBien()
        {
            List<CodigoValorResponse> listaTipoBien = new List<CodigoValorResponse>();
            if (Session[DatosConstantes.Sesiones.SessionTipoBien] == null)
            {
                listaTipoBien = politicaService.ListaTipoBien().Result;
                Session[DatosConstantes.Sesiones.SessionTipoBien] = listaTipoBien;
            }
            else
            {
                listaTipoBien = (List<CodigoValorResponse>)Session[DatosConstantes.Sesiones.SessionTipoBien];
            }
            return listaTipoBien;
        }
        
        /// <summary>
        /// Retorna la lista de Tipo de Tarifa Bien de parámetros
        /// </summary>
        /// <returns>Lista de Tipo de Tarifa Bien de Parametros</returns>
        public List<CodigoValorResponse> retornaTipoTarifaBien()
        {
            List<CodigoValorResponse> listaTipoTarifa = new List<CodigoValorResponse>();
            if (Session[DatosConstantes.Sesiones.SessionTipoTarifaBien] == null)
            {
                listaTipoTarifa = politicaService.ListaTipoTarifaBien().Result;
                Session[DatosConstantes.Sesiones.SessionTipoTarifaBien] = listaTipoTarifa;
            }
            else
            {
                listaTipoTarifa = (List<CodigoValorResponse>)Session[DatosConstantes.Sesiones.SessionTipoTarifaBien];
            }
            return listaTipoTarifa;
        }

        /// <summary>
        /// Retorna la lista de Periodo Alquiler del Bien de parámetros
        /// </summary>
        /// <returns>Lista de Periodo de alquiler del bien de parametro</returns>
        public List<CodigoValorResponse> retornaPeriodoAlquilerBien()
        {
            List<CodigoValorResponse> listaPeriodAl = new List<CodigoValorResponse>();
            if (Session[DatosConstantes.Sesiones.SessionPeriodoAlquilerBien] == null)
            {
                listaPeriodAl = politicaService.ListaPeriodoAlquilerBien().Result;
                Session[DatosConstantes.Sesiones.SessionPeriodoAlquilerBien] = listaPeriodAl;
            }
            else
            {
                listaPeriodAl = (List<CodigoValorResponse>)Session[DatosConstantes.Sesiones.SessionPeriodoAlquilerBien];
            }
            return listaPeriodAl;
        }
        
        /// <summary>
        /// Retorna la Moneda de parámetros
        /// </summary>
        /// <returns>lista de moneda de Parámetros</returns>
        public List<CodigoValorResponse> retornaMonedaBien()
        {
            List<CodigoValorResponse> listaMoneda = new List<CodigoValorResponse>();
            if (Session[DatosConstantes.Sesiones.SessionMonedaBien] == null)
            {
                listaMoneda = politicaService.ListarMoneda().Result;
                Session[DatosConstantes.Sesiones.SessionMonedaBien] = listaMoneda;
            }
            else
            {
                listaMoneda = (List<CodigoValorResponse>)Session[DatosConstantes.Sesiones.SessionMonedaBien];
            }
            return listaMoneda;
        }
        /// <summary>
        /// Lista dinámica para cargar los periodos de alquiler.
        /// </summary>
        /// <param name="tipoTarifa">código del Tipo de Tarifa.</param>
        /// <returns>lista de periodo de Alquiler</returns>
        public JsonResult PeriodoAlquilerPorTarifa(string tipoTarifa)
        {
            var resultado = bienService.PeriodoAlquilerPorTarifa(tipoTarifa);
            return Json(resultado);
        }
        
        #endregion
    }
}

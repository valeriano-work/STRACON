using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;
using Pe.Stracon.Politicas.Presentacion.Core.Controllers.Base;
using Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.Parametro;
using Pe.Stracon.Politicas.Presentacion.Recursos.Base;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Core.Controllers.General
{
    /// <summary>
    /// Controladora de Parámetro
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public class ParametroController : GenericController
    {
        /// <summary>
        /// Servicio de Parámetro
        /// </summary>
        public IParametroService parametroService { get; set; }
        #region Vistas
        /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            ParametroModel model = new ParametroModel();

            model.ListaSistema = ListarSistema("", GenericoResource.EtiquetaTodos);
            model.ListaTipoParametro = ListarTipoParametro(GenericoResource.EtiquetaTodos);
            return View(model);
        }

        /// <summary>
        /// Muestra la vista del formulario de Parámetro
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Vista de formulario de Parámetro</returns>
        public ActionResult FormularioParametro(ParametroRequest request)
        {
            ParametroModel model = new ParametroModel();

            model.ListaSistema = ListarSistema("", GenericoResource.EtiquetaSeleccionar);
            model.ListaTipoParametro = ListarTipoParametro(GenericoResource.EtiquetaSeleccionar);
                        
            if (request.CodigoParametro != null)
            {
                model.Parametro = parametroService.BuscarParametro(new ParametroRequest() { 
                    CodigoParametro = request.CodigoParametro
                }).Result.FirstOrDefault();
                model.ListaSistema.ForEach(delegate(SelectListItem item)
                {
                    if (model.Parametro.CodigoSistema != null && item.Value.ToUpper() == model.Parametro.CodigoSistema.ToUpper())
                    {
                        item.Selected = true;
                    }
                });
                model.ListaTipoParametro.ForEach(delegate(SelectListItem item)
                {
                    if (item.Value == model.Parametro.TipoParametro)
                    {
                        item.Selected = true;
                    }
                });
            }
            return PartialView(model);
        }
        
        #endregion

        #region Json
        /// <summary>
        /// Permite realizar la búsqueda de parametros
        /// </summary>
        /// <param name="request">Request de busqueda</param>
        /// <returns>Json</returns>
        public JsonResult BuscarParametro(ParametroRequest request)
        {
            var response = parametroService.BuscarParametro(request);
            return Json(response);
        }
        /// <summary>
        /// Permite realizar el registro de parametros
        /// </summary>
        /// <param name="request">Request de registro</param>
        /// <returns>Json</returns>
        public JsonResult GuardarParametro(ParametroRequest request)
        {
            request.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            var response = parametroService.RegistrarParametro(request);
            return Json(response);
        }

        /// <summary>
        /// Permite realizar la eliminación del parámetro
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>Json</returns>
        public JsonResult EliminarParametro(ParametroRequest request)
        {
            request.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            var response = parametroService.EliminarParametro(request);
            return Json(response);
        }        
        #endregion

        /// <summary>
        /// Lista los sistemas por empresa
        /// </summary>
        /// <param name="codigoEmpresa">Código de Empresa</param>
        /// <param name="etiquetaDefecto">Etiqueta por defecto</param>
        /// <returns>Lista de Selección</returns>
        private List<SelectListItem> ListarSistema(string codigoEmpresa, string etiquetaDefecto)
        {
            List<SelectListItem> listaSistema = new List<SelectListItem>();
            listaSistema.Add(new SelectListItem { Value = string.Empty, Text = etiquetaDefecto });
            listaSistema.Add(new SelectListItem { Value = DatosConstantes.Sistema.CodigoSCC, Text = "Sistema de Gestión de Cierre Contable" });
            listaSistema.Add(new SelectListItem { Value = DatosConstantes.Sistema.CodigoSGC, Text = "Sistema de Gestión Contractual" });

            return listaSistema;
        }

        /// <summary>
        /// Lista los Tipo de Parametros
        /// </summary>
        /// <param name="etiquetaDefecto">Etiqueta de Defecto</param>
        /// <returns>Lista de Tipo de Parámetros</returns>
        private List<SelectListItem> ListarTipoParametro(string etiquetaDefecto)
        {
            List<SelectListItem> listaTipoParametro = new List<SelectListItem>();
            listaTipoParametro.Add(new SelectListItem { Value = string.Empty, Text = etiquetaDefecto });
            listaTipoParametro.Add(new SelectListItem { Value = DatosConstantes.TipoParametro.Comun, Text = GenericoResource.EtiquetaTipoParametroComun });
            listaTipoParametro.Add(new SelectListItem { Value = DatosConstantes.TipoParametro.Sistema, Text = GenericoResource.EtiquetaTipoParametroSistema });
            listaTipoParametro.Add(new SelectListItem { Value = DatosConstantes.TipoParametro.Funcional, Text = GenericoResource.EtiquetaTipoParametroFuncional });

            return listaTipoParametro;
        }
        
    }
}
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Presentacion.Core.Controllers.Base;
using Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.ValorParametro;
using System.Web.Mvc;
using System.Linq;
using Pe.Stracon.Politicas.Presentacion.Recursos.Base;
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using System.Collections.Generic;
using Pe.GyM.Security.Web.Session;
using Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.Parametro;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;
using Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.SeccionParametro;

namespace Pe.Stracon.Politicas.Presentacion.Core.Controllers.General
{
    /// <summary>
    /// Controladora de Unidad Operativa
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public class SeccionParametroController : GenericController
    {
        public IParametroService parametroService { get; set; }
        public IParametroSeccionService parametroSeccionService { get; set; }
        #region Vistas
        /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <param name="codigoParametro">Código de Parámetro</param>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index(int codigoParametro)
        {
            SeccionParametroModel model = new SeccionParametroModel();

            model.Parametro = parametroService.BuscarParametro(new ParametroRequest()
            {
                CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon,
                CodigoParametro = codigoParametro
            }).Result.FirstOrDefault();

            return View(model);
        }

        /// <summary>
        /// Muesta la vista del Formulario de la Sección del Parámetro
        /// </summary>
        /// <param name="codigoParametro">Código del Parámetro</param>
        /// <param name="codigoSeccion">Código de Sección</param>
        /// <returns>Vista de Formulario</returns>
        public ActionResult FormularioSeccionParametro(int codigoParametro, int? codigoSeccion)
        {
            SeccionParametroModel model = new SeccionParametroModel();            

            model.Parametro = parametroService.BuscarParametro(new ParametroRequest() { CodigoParametro = codigoParametro, CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon }).Result.FirstOrDefault();
            
            int? codigoParametroRelacionado = null;
            string tipoDato = string.Empty;
            if (codigoSeccion != null)
            {
                model.SeccionParametro = parametroSeccionService.BuscarParametroSeccion(new ParametroSeccionRequest() { CodigoParametro = model.Parametro.CodigoParametro, CodigoSeccion = codigoSeccion }).Result.FirstOrDefault();

                codigoParametroRelacionado = model.SeccionParametro.CodigoParametroRelacionado;
                tipoDato = model.SeccionParametro.CodigoTipoDato;
            }

            model.ListaParametroRelacionado = ListarParametroRelacionado(DatosConstantes.Empresa.CodigoStracon, model.Parametro.CodigoSistema, codigoParametroRelacionado, GenericoResource.EtiquetaSeleccionar);
            model.ListaTipoDato = ListarTipoDato(tipoDato, GenericoResource.EtiquetaSeleccionar);

            model.ListaSeccionRelacionada = ListarSeccionRelacionado(codigoParametroRelacionado, model.SeccionParametro.CodigoSeccionRelacionado, GenericoResource.EtiquetaSeleccionar);
            model.ListaSeccionRelacionadaVisible = ListarSeccionRelacionado(codigoParametroRelacionado, model.SeccionParametro.CodigoSeccionRelacionadoMostrar, GenericoResource.EtiquetaSeleccionar);
            

            return PartialView(model);
        }        
        #endregion

        #region Json
        /// <summary>
        /// Permite realizar la busqueda de las Secciones del Parámetro
        /// </summary>
        /// <param name="codigoParametro">Código de Parámetro</param>
        /// <returns>Json</returns>
        public JsonResult BuscarSeccionParametro(int codigoParametro)
        {
            var listaParametroSeccion = parametroSeccionService.BuscarParametroSeccion(new ParametroSeccionRequest()
            {
                CodigoParametro = codigoParametro
            });

            return Json(listaParametroSeccion);
        }

        /// <summary>
        /// Permite realizar la busqueda de las Secciones del Parámetro
        /// </summary>
        /// <param name="codigoParametro">Código de Parámetro</param>
        /// <returns>Json</returns>
        public JsonResult GuardarSeccionParametro(ParametroSeccionRequest seccion)
        {
            var resultado = parametroSeccionService.RegistrarParametroSeccion(seccion);

            return Json(resultado);
        }

        /// <summary>
        /// Permite buscar el parametro
        /// </summary>
        /// <param name="codigoParametro">Código de Parametro</param>
        /// <returns>Secciones del Parametro</returns>
        public JsonResult EliminarSeccionParametro(List<ParametroSeccionRequest> listaRequest)
        {
            var resultItem = parametroSeccionService.EliminarMasivoParametroSeccion(listaRequest);
            return Json(resultItem);
        }
        #endregion
        /// <summary>
        /// Lista los Parámetros
        /// </summary>
        /// <param name="codigoEmpresa">Código de Empresa</param>
        /// <param name="codigoSistema">Código de Sistema</param>
        /// <param name="codigoParametroMarcado">Código del Parámetro Marcado</param>
        /// <param name="etiquetaDefecto">Etiqueta por Defecto</param>
        /// <returns>Lista de Parámetro</returns>
        private List<SelectListItem> ListarParametroRelacionado(string codigoEmpresa, string codigoSistema, int? codigoParametroMarcado, string etiquetaDefecto)
        {
            var listaParametro = parametroService.BuscarParametro(new ParametroRequest() { CodigoEmpresa = codigoEmpresa }).Result;

            var listaParametroRelacionado = listaParametro.Where(item => item.IndicadorEmpresa ).ToList();
            listaParametroRelacionado.AddRange(listaParametro.Where(item => item.CodigoSistema == codigoSistema).ToList());

            listaParametroRelacionado = listaParametroRelacionado.OrderBy(item => item.Nombre).ToList();

            List<SelectListItem> listaTipoDato = new List<SelectListItem>();

            if (etiquetaDefecto != null)
            {
                listaTipoDato.Add(new SelectListItem { Value = string.Empty, Text = etiquetaDefecto });
            }
            listaTipoDato.AddRange(listaParametroRelacionado.Select(item => new SelectListItem()
            {
                Value = item.CodigoParametro.ToString(),
                Text = item.Nombre,
                Selected = (item.CodigoParametro == codigoParametroMarcado)
            }));

            return listaTipoDato;
        }

        /// <summary>
        /// Lista Sección Relacionado
        /// </summary>
        /// <param name="codigoParametroRelacionado">Código de Parámetro Relacionado</param>
        /// <param name="codigoSeccionRelacionado">Código de Sección Relacionada</param>
        /// <param name="etiquetaDefecto">Etiqueta por Defecto</param>
        /// <returns>Lista de Sección Relacionado</returns>
        private List<SelectListItem> ListarSeccionRelacionado(int? codigoParametroRelacionado, int? codigoSeccionRelacionado, string etiquetaDefecto)
        {
            var listaSeccionRelacioado = codigoParametroRelacionado != null ? parametroSeccionService.BuscarParametroSeccion(new ParametroSeccionRequest() { CodigoParametro = codigoParametroRelacionado }).Result : null;

            List<SelectListItem> listaSeccionRelacionado = new List<SelectListItem>();

            if (etiquetaDefecto != null)
            {
                listaSeccionRelacionado.Add(new SelectListItem { Value = string.Empty, Text = etiquetaDefecto });
            }

            if (listaSeccionRelacioado != null)
            {
                listaSeccionRelacionado.AddRange(listaSeccionRelacioado.Select(item => new SelectListItem()
                {
                    Value = item.CodigoSeccion.ToString(),
                    Text = item.Nombre,
                    Selected = (item.CodigoSeccion == codigoSeccionRelacionado)
                }));
            }

            return listaSeccionRelacionado;
        }
        /// <summary>
        /// Lista los Tipos de Dato
        /// </summary>
        /// <param name="etiquetaDefecto">Etiqueta por defecto</param>
        /// <returns>Lista de Tipo de Dato</returns>
        private List<SelectListItem> ListarTipoDato(string tipoDatoMarcado, string etiquetaDefecto)
        {
            List<SelectListItem> listaTipoDato = new List<SelectListItem>();
            if (etiquetaDefecto != null)
            {
                listaTipoDato.Add(new SelectListItem { Value = string.Empty, Text = etiquetaDefecto });
            }
            listaTipoDato.Add(new SelectListItem { Value = DatosConstantes.TipoDato.Decimal,    Text = "Decimal", Selected = (DatosConstantes.TipoDato.Decimal == tipoDatoMarcado) });
            listaTipoDato.Add(new SelectListItem { Value = DatosConstantes.TipoDato.Encriptado, Text = "Encriptado", Selected = (DatosConstantes.TipoDato.Encriptado == tipoDatoMarcado) });
            listaTipoDato.Add(new SelectListItem { Value = DatosConstantes.TipoDato.Entero,     Text = "Entero", Selected = (DatosConstantes.TipoDato.Entero == tipoDatoMarcado) });
            listaTipoDato.Add(new SelectListItem { Value = DatosConstantes.TipoDato.Fecha,      Text = "Fecha", Selected = (DatosConstantes.TipoDato.Fecha == tipoDatoMarcado) });
            listaTipoDato.Add(new SelectListItem { Value = DatosConstantes.TipoDato.Texto,      Text = "Texto", Selected = (DatosConstantes.TipoDato.Texto == tipoDatoMarcado) });

            return listaTipoDato;
        }
    }
}
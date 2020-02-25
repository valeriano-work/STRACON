using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ActividadesGestionContractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.PlantillaRequerimiento;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using System;
using System.IO;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Cross.Core.Util;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.GyM.Security.Web.Filters;
using Pe.GyM.Security.Web.Session;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Plantilla
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150518
    /// Modificación:   
    /// </remarks>
    public class PlantillaRequerimientoController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary>
        public IPoliticaService politicaService { get; set; }

        /// <summary>
        /// Servicio de manejo de plantilla
        /// </summary>
        public IPlantillaRequerimientoService plantillaRequerimientoService { get; set; }

        /// <summary>
        /// Servicio de manejo de Listado Requerimiento
        /// </summary>
        public IRequerimientoService RequerimientoService { get; set; }
        #endregion

        #region Vistas
        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var estadoVigencia = politicaService.ListarEstadoVigenciaRequerimiento();
            var modelo = new PlantillaRequerimientoBusqueda(estadoVigencia.Result);

            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/PlantillaRequerimiento/");

            return View(modelo);
        }
        /// <summary>
        /// Muestra la vista párrafo
        /// </summary>
        /// <returns>Vista párrafo</returns>
        public ActionResult PlantillaRequerimientoParrafo(string codigoPlantilla)
        {
            var plantilla = new PlantillaRequerimientoResponse();

            if (!string.IsNullOrWhiteSpace(codigoPlantilla))
            {
                plantilla = plantillaRequerimientoService.BuscarPlantilla(new PlantillaRequerimientoRequest() { CodigoPlantilla = codigoPlantilla }).Result.FirstOrDefault();
            }

            PlantillaRequerimientoParrafoBusqueda modelo = new PlantillaRequerimientoParrafoBusqueda(plantilla);
            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/PlantillaRequerimiento/");
            return View(modelo);
        }

        /// <summary>
        /// Muestra el formulario de plantilla párrafo
        /// </summary>
        /// <param name="codigoPlantillaParrafo">Código de Plantilla Párrafo</param>
        /// <returns>Vista del formulario plantilla párrafo</returns>
        public ActionResult FormularioPlantillaParrafo(string codigoPlantilla, string codigoPlantillaParrafo)
        {
            PlantillaRequerimientoParrafoFormulario modelo;

            if (!string.IsNullOrWhiteSpace(codigoPlantillaParrafo))
            {
                var plantillaParrafo = plantillaRequerimientoService.BuscarPlantillaParrafo(new PlantillaRequerimientoParrafoRequest() { CodigoPlantillaParrafo = codigoPlantillaParrafo }).Result.FirstOrDefault();

                if (plantillaParrafo != null)
                {
                    modelo = new PlantillaRequerimientoParrafoFormulario(plantillaParrafo);
                }
                else
                {
                    modelo = new PlantillaRequerimientoParrafoFormulario(plantillaParrafo);
                }
            }
            else
            {
                modelo = new PlantillaRequerimientoParrafoFormulario();
                if (!string.IsNullOrWhiteSpace(codigoPlantilla))
                {
                    modelo.PlantillaRequerimientoParrafoModel.CodigoPlantilla = new Guid(codigoPlantilla);
                }
            }

            return View(modelo);
        }

        /// <summary>
        /// Muestra la vista nota pie
        /// </summary>
        /// <param name="codigoPlantilla">Código plantilla</param>
        /// <returns>Vista nota pie</returns>
        public ActionResult PlantillaRequerimientoNotaPie(string codigoPlantilla)
        {
            var plantilla = new PlantillaRequerimientoResponse();

            if (!string.IsNullOrWhiteSpace(codigoPlantilla))
            {
                plantilla = plantillaRequerimientoService.BuscarPlantilla(new PlantillaRequerimientoRequest() { CodigoPlantilla = codigoPlantilla }).Result.FirstOrDefault();
            }

            PlantillaRequerimientoNotaPieBusqueda modelo = new PlantillaRequerimientoNotaPieBusqueda(plantilla);
            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/PlantillaRequerimiento/");
            return View(modelo);
        }

        /// <summary>
        /// Muestra el formulario de plantilla nota pie
        /// </summary> 
        /// <param name="codigoPlantilla">Código de plantilla</param>
        /// <param name="codigoPlantillaNotaPie">Código nota pie</param>
        /// <returns>Vista del formulario plantilla nota pie</returns>
        public ActionResult FormularioPlantillaRequerimientoNotaPie(string codigoPlantilla, string codigoPlantillaNotaPie)
        {
            var modelo = new PlantillaRequerimientoNotaPie();

            if (!string.IsNullOrWhiteSpace(codigoPlantillaNotaPie))
            {
                var nota = plantillaRequerimientoService.BuscarNotasPiePorPlantilla(new PlantillaRequerimientoNotaPieRequest() { CodigoPlantillaNotaPie = codigoPlantillaNotaPie }).Result.FirstOrDefault();

                if (nota != null)
                {
                    modelo = new PlantillaRequerimientoNotaPie(nota);
                }
            }

            if (!string.IsNullOrWhiteSpace(codigoPlantilla))
            {
                modelo.PlantillaRequerimientoNotaPieModel.CodigoPlantilla = new Guid(codigoPlantilla);
            }

            return View(modelo);
        }

        #endregion

        #region Vistas Parciales
        /// <summary>
        /// Muestra el formulario de plantilla
        /// </summary>
        /// <param name="codigoPlantilla">Código de Plantilla</param>
        /// <returns>Vista del formulario plantilla</returns>
        public ActionResult FormularioPlantilla(string codigoPlantilla, string indicadorCopia)
        {
            PlantillaRequerimientoFormulario modelo;

            var estadoVigencia = politicaService.ListarEstadoVigencia();

            if (!string.IsNullOrWhiteSpace(codigoPlantilla))
            {
                var resultadoPlantilla = plantillaRequerimientoService.BuscarPlantilla(new PlantillaRequerimientoRequest() { CodigoPlantilla = codigoPlantilla });

                var plantilla = resultadoPlantilla.Result.FirstOrDefault();

                if (plantilla != null && indicadorCopia != "1")
                {
                    modelo = new PlantillaRequerimientoFormulario(estadoVigencia.Result, plantilla);
                }
                else
                {
                    modelo = new PlantillaRequerimientoFormulario(estadoVigencia.Result, indicadorCopia);
                }
            }
            else
            {
                modelo = new PlantillaRequerimientoFormulario(estadoVigencia.Result, indicadorCopia);
            }

            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra el contenido de la Plantilla.
        /// </summary>
        /// <param name="filtro">Filtro para la búsqueda</param>
        /// <returns>Contenido en formato PDF de la Plantilla</returns>
        public ActionResult GenerarVistaPreviaPlantilla(PlantillaRequerimientoRequest filtro)
        {
            string contenido = "";
            string nombreDocumento = string.Format("{0}.{1}", filtro.Descripcion, DatosConstantes.ArchivosRequerimiento.ExtensionValidaCarga);
            var plantillaParrafo = plantillaRequerimientoService.BuscarPlantillaParrafo(new PlantillaRequerimientoParrafoRequest() { CodigoPlantilla = filtro.CodigoPlantilla });
            if (plantillaParrafo.Result != null && plantillaParrafo.Result.Count > 0)
            {
                foreach (var parrafo in plantillaParrafo.Result)
                {
                    contenido = contenido + parrafo.Contenido; //+ "</br>";
                }
            }

            string lslinkCss = System.Web.HttpContext.Current.Server.MapPath("~/Theme/app/cssPdf.css");
            var urlLogo = politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.UrlLogoStracon).FirstOrDefault().Atributo3;
            var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.WidthLogo).FirstOrDefault().Atributo3);
            var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.HeightLogo).FirstOrDefault().Atributo3);

            var contenidoRequerimiento = RequerimientoService.GenerarPdfDesdeHtml(contenido, "", "", null, Guid.Parse(filtro.CodigoPlantilla), null, null, lslinkCss, false, urlLogo, widthLogo, heightLogo);
            MemoryStream memoryStream = null;
            if (contenidoRequerimiento != null)
            {
                memoryStream = new MemoryStream((byte[])contenidoRequerimiento);
            }

            if (memoryStream != null)
            {
                byte[] byteArchivo = memoryStream.ToArray();
                Response.Clear();
                Response.AddHeader("Content-Disposition", string.Format("attachement; filename={0}", nombreDocumento));
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(byteArchivo);
                Response.End();
            }
            else
            {
                return null;
            }
            return RedirectToAction("Reporte");
        }
        #endregion

        #region Json
        /// <summary>
        /// Busca plantillas
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de plantillas</returns>
        public JsonResult BuscarPlantilla(PlantillaRequerimientoRequest filtro)
        {
            var resultado = plantillaRequerimientoService.BuscarPlantilla(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Registrar Plantilla
        /// </summary>
        /// <param name="data">Campos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarPlantilla(PlantillaRequerimientoRequest data)
        {
            var resultado = plantillaRequerimientoService.RegistrarPlantilla(data);
            return Json(resultado);
        }

        /// <summary>
        /// Eliminar Plantilla
        /// </summary>
        /// <param name="listaCodigosPlantilla">Listade de códigos de plantilla a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEliminarFilter]
        public JsonResult EliminarPlantilla(List<object> listaCodigosPlantilla)
        {
            var resultado = plantillaRequerimientoService.EliminarPlantilla(listaCodigosPlantilla);
            return Json(resultado);
        }

        /// <summary>
        /// Busca plantilla párrafo
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de plantilla párrafo</returns>
        public JsonResult BuscarPlantillaParrafo(PlantillaRequerimientoParrafoRequest filtro)
        {
            var resultado = plantillaRequerimientoService.BuscarPlantillaParrafo(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Busca varibales globales
        /// </summary>
        /// <param name="codigoPlantilla">Código de Plantilla</param>
        /// <returns>Lista de varibales globales</returns>
        public JsonResult BuscarVariableGlobal(string codigoPlantilla)
        {
            var resultado = plantillaRequerimientoService.BuscarVariableGlobal(codigoPlantilla);
            return Json(resultado);
        }

        /// <summary>
        /// Eliminar Plantilla Párrafo
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEliminarFilter]
        public JsonResult EliminarPlantillaParrafo(List<object> listaCodigosPlantillaParrafo)
        {
            var resultado = plantillaRequerimientoService.EliminarPlantillaParrafo(listaCodigosPlantillaParrafo);
            return Json(resultado);
        }

        /// <summary>
        /// Registrar Plantilla Párrafo
        /// </summary>
        /// <param name="data">Campos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarPlantillaParrafo(PlantillaRequerimientoParrafoRequest data)
        {
            //cambio de quitado de etiqueta AuthorizeEscrituraFilter, solo debe estar comentado para local.
            var resultado = plantillaRequerimientoService.RegistrarPlantillaParrafo(data);
            return Json(resultado);
        }

        /// <summary>
        /// Busca notas al pie por plantilla
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de notas al pie</returns>
        public JsonResult BuscarNotasPiePorPlantilla(PlantillaRequerimientoNotaPieRequest filtro)
        {
            var resultado = plantillaRequerimientoService.BuscarNotasPiePorPlantilla(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Eliminar Notas
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        // [AuthorizeEliminarFilter]
        public JsonResult EliminarNotas(List<Guid> listaCodigosNotas)
        {
            var resultado = plantillaRequerimientoService.EliminarNotas(listaCodigosNotas);
            return Json(resultado);
        }

        /// <summary>
        /// Registrar Plantilla Nota al pie
        /// </summary>
        /// <param name="data">Campos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        //  [AuthorizeEscrituraFilter]
        public JsonResult RegistrarNotaPie(PlantillaRequerimientoNotaPieRequest data)
        {
            var resultado = plantillaRequerimientoService.RegistrarNotaPie(data);
            return Json(resultado);
        }

        #endregion
    }
}
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ActividadesGestionContractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Plantilla;
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
    public class PlantillaController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary>
        public IPoliticaService politicaService { get; set; }

        /// <summary>
        /// Servicio de manejo de plantilla
        /// </summary>
        public IPlantillaService plantillaService { get; set; }

        /// <summary>
        /// Servicio de manejo de Listado contrato
        /// </summary>
        public IContratoService contratoService { get; set; }
        #endregion

        #region Vistas
        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var tipoContrato = politicaService.ListarTipoContrato().Result.OrderBy(item => item.Valor).ToList();
            var tipoDocumentoContrato = politicaService.ListarTipoDocumentoContrato().Result.OrderBy(item => item.Valor).ToList();
            var estadoVigencia = politicaService.ListarEstadoVigencia();
            var modelo = new PlantillaBusqueda(tipoContrato, tipoDocumentoContrato, estadoVigencia.Result);

            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/Plantilla/");

            return View(modelo);
        }
        /// <summary>
        /// Muestra la vista párrafo
        /// </summary>
        /// <returns>Vista párrafo</returns>
        public ActionResult PlantillaParrafo(string codigoPlantilla)
        {
            var plantilla = new PlantillaResponse();

            if (!string.IsNullOrWhiteSpace(codigoPlantilla))
            {
                plantilla = plantillaService.BuscarPlantilla(new PlantillaRequest() { CodigoPlantilla = codigoPlantilla }).Result.FirstOrDefault();
            }

            PlantillaParrafoBusqueda modelo = new PlantillaParrafoBusqueda(plantilla);
            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/Plantilla/");
            return View(modelo);
        }

        /// <summary>
        /// Muestra el formulario de plantilla párrafo
        /// </summary>
        /// <param name="codigoPlantillaParrafo">Código de Plantilla Párrafo</param>
        /// <returns>Vista del formulario plantilla párrafo</returns>
        public ActionResult FormularioPlantillaParrafo(string codigoPlantilla, string codigoPlantillaParrafo)
        {
            PlantillaParrafoFormulario modelo;

            if (!string.IsNullOrWhiteSpace(codigoPlantillaParrafo))
            {
                var plantillaParrafo = plantillaService.BuscarPlantillaParrafo(new PlantillaParrafoRequest() { CodigoPlantillaParrafo = codigoPlantillaParrafo }).Result.FirstOrDefault();

                if (plantillaParrafo != null)
                {
                    modelo = new PlantillaParrafoFormulario(plantillaParrafo);
                }
                else
                {
                    modelo = new PlantillaParrafoFormulario(plantillaParrafo);
                }
            }
            else
            {
                modelo = new PlantillaParrafoFormulario();
                if (!string.IsNullOrWhiteSpace(codigoPlantilla))
                {
                    modelo.PlantillaParrafoModel.CodigoPlantilla = new Guid(codigoPlantilla);
                }
            }

            return View(modelo);
        }

        /// <summary>
        /// Muestra la vista nota pie
        /// </summary>
        /// <param name="codigoPlantilla">Código plantilla</param>
        /// <returns>Vista nota pie</returns>
        public ActionResult PlantillaNotaPie(string codigoPlantilla)
        {
            var plantilla = new PlantillaResponse();

            if (!string.IsNullOrWhiteSpace(codigoPlantilla))
            {
                plantilla = plantillaService.BuscarPlantilla(new PlantillaRequest() { CodigoPlantilla = codigoPlantilla }).Result.FirstOrDefault();
            }

            PlantillaNotaPieBusqueda modelo = new PlantillaNotaPieBusqueda(plantilla);
            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/Plantilla/");
            return View(modelo);
        }

        /// <summary>
        /// Muestra el formulario de plantilla nota pie
        /// </summary> 
        /// <param name="codigoPlantilla">Código de plantilla</param>
        /// <param name="codigoPlantillaNotaPie">Código nota pie</param>
        /// <returns>Vista del formulario plantilla nota pie</returns>
        public ActionResult FormularioPlantillaNotaPie(string codigoPlantilla, string codigoPlantillaNotaPie)
        {
            var modelo = new PlantillaNotaPie();

            if (!string.IsNullOrWhiteSpace(codigoPlantillaNotaPie))
            {
                var nota = plantillaService.BuscarNotasPiePorPlantilla(new PlantillaNotaPieRequest() { CodigoPlantillaNotaPie = codigoPlantillaNotaPie }).Result.FirstOrDefault();

                if (nota != null)
                {
                    modelo = new PlantillaNotaPie(nota);
                }
            }

            if (!string.IsNullOrWhiteSpace(codigoPlantilla))
            {
                modelo.PlantillaNotaPieModel.CodigoPlantilla = new Guid(codigoPlantilla);
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
            PlantillaFormulario modelo;
            var tipoServicio = politicaService.ListarTipoContrato();
            var tipoRequerimiento = politicaService.ListarTipoServicio();
            var tipoDocumentoContrato = politicaService.ListarTipoDocumentoContrato();
            var estadoVigencia = politicaService.ListarEstadoVigencia();

            if (!string.IsNullOrWhiteSpace(codigoPlantilla))
            {
                var resultadoPlantilla = plantillaService.BuscarPlantilla(new PlantillaRequest() { CodigoPlantilla = codigoPlantilla });

                var plantilla = resultadoPlantilla.Result.FirstOrDefault();

                if (plantilla != null && indicadorCopia != "1")
                {
                    modelo = new PlantillaFormulario(tipoServicio.Result, tipoRequerimiento.Result, tipoDocumentoContrato.Result, estadoVigencia.Result, plantilla);
                }
                else
                {
                    modelo = new PlantillaFormulario(tipoServicio.Result, tipoRequerimiento.Result, tipoDocumentoContrato.Result, estadoVigencia.Result, indicadorCopia, plantilla.EsMayorMenor);
                }
            }
            else
            {
                modelo = new PlantillaFormulario(tipoServicio.Result, tipoRequerimiento.Result, tipoDocumentoContrato.Result, estadoVigencia.Result, indicadorCopia, null);
            }

            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra el contenido de la Plantilla.
        /// </summary>
        /// <param name="filtro">Filtro para la búsqueda</param>
        /// <returns>Contenido en formato PDF de la Plantilla</returns>
        public ActionResult GenerarVistaPreviaPlantilla(PlantillaRequest filtro)
        {
            string contenido = "";
            string nombreDocumento = string.Format("{0}.{1}", filtro.Descripcion, DatosConstantes.ArchivosContrato.ExtensionValidaCarga);
            var plantillaParrafo = plantillaService.BuscarPlantillaParrafo(new PlantillaParrafoRequest() { CodigoPlantilla = filtro.CodigoPlantilla });
            if (plantillaParrafo.Result != null && plantillaParrafo.Result.Count > 0)
            {
                foreach (var parrafo in plantillaParrafo.Result)
                {
                    contenido = contenido + parrafo.Contenido; //+ "</br>";
                }
            }

            string lslinkCss = System.Web.HttpContext.Current.Server.MapPath("~/Theme/app/cssPdf.css");
            var urlLogo = politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.UrlLogoStracon).FirstOrDefault().Atributo3;
            var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.WidthLogo).FirstOrDefault().Atributo3);
            var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.HeightLogo).FirstOrDefault().Atributo3);

            var contenidoContrato = contratoService.GenerarPdfDesdeHtml(contenido, "", "", null, Guid.Parse(filtro.CodigoPlantilla), null, null, lslinkCss, false, urlLogo, widthLogo, heightLogo);
            MemoryStream memoryStream = null;
            if (contenidoContrato != null)
            {
                memoryStream = new MemoryStream((byte[])contenidoContrato);
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
        public JsonResult BuscarPlantilla(PlantillaRequest filtro)
        {
            var resultado = plantillaService.BuscarPlantilla(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Registrar Plantilla
        /// </summary>
        /// <param name="data">Campos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarPlantilla(PlantillaRequest data)
        {
            var resultado = plantillaService.RegistrarPlantilla(data);
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
            var resultado = plantillaService.EliminarPlantilla(listaCodigosPlantilla);
            return Json(resultado);
        }

        /// <summary>
        /// Busca plantilla párrafo
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de plantilla párrafo</returns>
        public JsonResult BuscarPlantillaParrafo(PlantillaParrafoRequest filtro)
        {
            var resultado = plantillaService.BuscarPlantillaParrafo(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Busca varibales globales
        /// </summary>
        /// <param name="codigoPlantilla">Código de Plantilla</param>
        /// <returns>Lista de varibales globales</returns>
        public JsonResult BuscarVariableGlobal(string codigoPlantilla)
        {
            var resultado = plantillaService.BuscarVariableGlobal(codigoPlantilla);
            return Json(resultado);
        }

        /// <summary>
        /// Eliminar Plantilla Párrafo
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEliminarFilter]
        public JsonResult EliminarPlantillaParrafo(List<object> listaCodigosPlantillaParrafo)
        {
            var resultado = plantillaService.EliminarPlantillaParrafo(listaCodigosPlantillaParrafo);
            return Json(resultado);
        }

        /// <summary>
        /// Registrar Plantilla Párrafo
        /// </summary>
        /// <param name="data">Campos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarPlantillaParrafo(PlantillaParrafoRequest data)
        {
            //cambio de quitado de etiqueta AuthorizeEscrituraFilter, solo debe estar comentado para local.
            var resultado = plantillaService.RegistrarPlantillaParrafo(data);
            return Json(resultado);
        }

        /// <summary>
        /// Busca notas al pie por plantilla
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de notas al pie</returns>
        public JsonResult BuscarNotasPiePorPlantilla(PlantillaNotaPieRequest filtro)
        {
            var resultado = plantillaService.BuscarNotasPiePorPlantilla(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Eliminar Notas
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        // [AuthorizeEliminarFilter]
        public JsonResult EliminarNotas(List<Guid> listaCodigosNotas)
        {
            var resultado = plantillaService.EliminarNotas(listaCodigosNotas);
            return Json(resultado);
        }

        /// <summary>
        /// Registrar Plantilla Nota al pie
        /// </summary>
        /// <param name="data">Campos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        //  [AuthorizeEscrituraFilter]
        public JsonResult RegistrarNotaPie(PlantillaNotaPieRequest data)
        {
            var resultado = plantillaService.RegistrarNotaPie(data);
            return Json(resultado);
        }

        #endregion
    }
}
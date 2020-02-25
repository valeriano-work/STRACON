using Pe.GyM.Security.Account.Model;
using Pe.GyM.Security.Web.Filters;
using Pe.GyM.Security.Web.Session;
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Cross.Core.Util;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Consulta;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Consulta
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150318
    /// Modificación:
    /// </remarks>
    public class ConsultaController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Servicio de unidad operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }

        /// <summary>
        /// Servicio de Contratos
        /// </summary>
        public IConsultaService consultaService { get; set; }

        /// <summary>
        /// Servicio de trabajadores
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }

        /// <summary>
        /// Interface para obtener el entorno de la aplicación.
        /// </summary>
        public IEntornoActualAplicacion entornoAplicacion { get; set; }

        #endregion

        #region Vistas
        /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var listaTipoConsulta = new List<SelectListItem>();
            listaTipoConsulta.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaTodos });

            var listaConsulta = politicaService.ListarTipoConsulta().Result;

            listaTipoConsulta.AddRange(listaConsulta.Select(item => new SelectListItem() { Value = item.Codigo.ToString(), Text = item.Valor.ToString() }).ToList());

            //var trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = entornoAplicacion.UsuarioSession }).Result.FirstOrDefault();

            //Session["DatosTrabajador"] = trabajador;

            var trabajador = HttpGyMSessionContext.CurrentAccount();


            var listUnidadOperativa = unidadOperativaService.BuscarUnidadOperativaProyectoPorEmpresaMatriz(new FiltroUnidadOperativa() { CodigoUnidadOperativa = trabajador.CodigoUnidadOperativaMatriz }).Result;
            var listUnidadOperativaCombo = new List<SelectListItem>();
            listUnidadOperativaCombo.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaTodos });
            listUnidadOperativaCombo.AddRange(listUnidadOperativa.Select(item => new SelectListItem() { Value = item.CodigoUnidadOperativa.ToString(), Text = item.Nombre.ToString() }).ToList());

            var listArea = politicaService.ListarArea().Result;
            var listAreaCombo = new List<SelectListItem>();
            listAreaCombo.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaTodos });
            listAreaCombo.AddRange(listArea.Select(item => new SelectListItem() { Value = item.Codigo.ToString(), Text = item.Valor.ToString() }).ToList());

            var listEstadoConsulta = politicaService.ListarEstadoConsulta().Result;
            var listEstadoConsultaCombo = new List<SelectListItem>();
            listEstadoConsultaCombo.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaTodos });
            listEstadoConsultaCombo.AddRange(listEstadoConsulta.Select(item => new SelectListItem() { Value = item.Codigo.ToString(), Text = item.Valor.ToString() }).ToList());

            ViewBag.ListaTipoConsulta = listaTipoConsulta;
            ViewBag.ListArea = listAreaCombo;
            ViewBag.ListEstadoConsulta = listEstadoConsultaCombo;
            ViewBag.ListUnidadOperativa = listUnidadOperativaCombo;
            ViewBag.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/Consulta/");
            return View();
        }
        #endregion

        #region Vistas Parciales
        /// <summary>
        /// Muestra el formulario de Consultas
        /// </summary>
        /// <returns>Vista del formulario Consulta</returns>
        public ActionResult FormularioConsulta()
        {
            ConsultaFormulario modelo;

            //var trabajador = (TrabajadorResponse)Session["DatosTrabajador"];
            var trabajador = HttpGyMSessionContext.CurrentAccount();

            var listaTipoConsulta = new List<SelectListItem>();
            listaTipoConsulta.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });
            var listaConsulta = politicaService.ListarTipoConsulta().Result;
            listaTipoConsulta.AddRange(listaConsulta.Select(item => new SelectListItem() { Value = item.Codigo.ToString(), Text = item.Valor.ToString() }).ToList());

            var listUnidadOperativa = unidadOperativaService.BuscarUnidadOperativaProyectoPorEmpresaMatriz(new FiltroUnidadOperativa() { CodigoUnidadOperativa = trabajador.CodigoUnidadOperativaMatriz }).Result;

            var listUnidadOperativaCombo = new List<SelectListItem>();
            listUnidadOperativaCombo.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });
            listUnidadOperativaCombo.AddRange(listUnidadOperativa.Select(item => new SelectListItem() { Value = item.CodigoUnidadOperativa.ToString(), Text = item.Nombre.ToString() }).ToList());

            var listArea = politicaService.ListarArea().Result;
            var listAreaCombo = new List<SelectListItem>();
            listAreaCombo.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });
            listAreaCombo.AddRange(listArea.Select(item => new SelectListItem() { Value = item.Codigo.ToString(), Text = item.Valor.ToString() }).ToList());


            var listaStaff = new List<SelectListItem>();
            listaStaff.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });

            modelo = new ConsultaFormulario(listaTipoConsulta, listUnidadOperativaCombo, listAreaCombo);

            if (!string.IsNullOrWhiteSpace(trabajador.CodigoUnidadOperativaMatriz))
            {
                var list = unidadOperativaService.BuscarUnidadOperativaStaff(new FiltroUnidadOperativa() { CodigoUnidadOperativa = trabajador.CodigoUnidadOperativaMatriz }).Result;

                var indicadorStaff = (list.Where(x => x.CodigoTrabajador == new Guid(trabajador.CodigoTrabajador)).FirstOrDefault() != null ? true : false);
                modelo.IndicadorStaff = indicadorStaff;

                listaStaff.AddRange(list.Select(item => new SelectListItem() { Value = item.CodigoTrabajador.Value.ToString(), Text = item.NombreCompleto.ToString() }).ToList());
            }

            modelo.ListaStaff = listaStaff;

            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra el formulario de Responder Consultas
        /// </summary>
        /// <param name="codigoConsulta">Código de Consulta</param>
        /// <returns>Vista del formulario de Responder Consulta</returns>
        public ActionResult FormularioResponderConsulta(string codigoConsulta)
        {
            ConsultaFormulario modelo;

            //var trabajador = (TrabajadorResponse)Session["DatosTrabajador"];
            var trabajador = HttpGyMSessionContext.CurrentAccount();

            var listaTipoConsulta = new List<SelectListItem>();
            listaTipoConsulta.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });
            var listaConsulta = politicaService.ListarTipoConsulta().Result;
            listaTipoConsulta.AddRange(listaConsulta.Select(item => new SelectListItem() { Value = item.Codigo.ToString(), Text = item.Valor.ToString() }).ToList());

            var listUnidadOperativa = unidadOperativaService.BuscarUnidadOperativaProyectoPorEmpresaMatriz(new FiltroUnidadOperativa() { CodigoUnidadOperativa = trabajador.CodigoUnidadOperativaMatriz }).Result;
            var listUnidadOperativaCombo = new List<SelectListItem>();
            listUnidadOperativaCombo.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });
            listUnidadOperativaCombo.AddRange(listUnidadOperativa.Select(item => new SelectListItem() { Value = item.CodigoUnidadOperativa.ToString(), Text = item.Nombre.ToString() }).ToList());

            var listArea = politicaService.ListarArea().Result;
            var listAreaCombo = new List<SelectListItem>();
            listAreaCombo.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });
            listAreaCombo.AddRange(listArea.Select(item => new SelectListItem() { Value = item.Codigo.ToString(), Text = item.Valor.ToString() }).ToList());

            modelo = new ConsultaFormulario(listaTipoConsulta, listUnidadOperativaCombo, listAreaCombo);

            if (!string.IsNullOrWhiteSpace(codigoConsulta))
            {
                var consultaAdjuntoRequest = new ConsultaAdjuntoRequest();
                consultaAdjuntoRequest.UsuarioSession = trabajador.Alias;
                consultaAdjuntoRequest.CodigoConsulta = new Guid(codigoConsulta);

                modelo.Consulta = consultaService.ListadoConsulta(new ConsultaRequest() { CodigoConsulta = codigoConsulta, CodigoUsuarioSesion = trabajador.CodigoTrabajador }).Result.FirstOrDefault();
                modelo.Consulta.ListaAdjuntos = consultaService.BuscarConsultaAdjunto(consultaAdjuntoRequest).Result;
            }

            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra el formulario de Reenviar Consultas
        /// </summary>
        /// <param name="codigoConsulta">Código de Consulta</param>
        /// <returns>Vista del formulario de Responder Consulta</returns>
        public ActionResult FormularioReenviarConsulta(string codigoConsultaRelacionado)
        {
            ConsultaFormulario modelo;

            //var trabajador = (TrabajadorResponse)Session["DatosTrabajador"];
            var trabajador = HttpGyMSessionContext.CurrentAccount();

            var listaTipoConsulta = new List<SelectListItem>();
            listaTipoConsulta.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });
            var listaConsulta = politicaService.ListarTipoConsulta().Result;
            listaTipoConsulta.AddRange(listaConsulta.Select(item => new SelectListItem() { Value = item.Codigo.ToString(), Text = item.Valor.ToString() }).ToList());

            var listUnidadOperativa = unidadOperativaService.BuscarUnidadOperativaProyectoPorEmpresaMatriz(new FiltroUnidadOperativa() { CodigoUnidadOperativa = trabajador.CodigoUnidadOperativaMatriz }).Result;
            var listUnidadOperativaCombo = new List<SelectListItem>();
            listUnidadOperativaCombo.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });
            listUnidadOperativaCombo.AddRange(listUnidadOperativa.Select(item => new SelectListItem() { Value = item.CodigoUnidadOperativa.ToString(), Text = item.Nombre.ToString() }).ToList());

            var listArea = politicaService.ListarArea().Result;
            var listAreaCombo = new List<SelectListItem>();
            listAreaCombo.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });
            listAreaCombo.AddRange(listArea.Select(item => new SelectListItem() { Value = item.Codigo.ToString(), Text = item.Valor.ToString() }).ToList());

            modelo = new ConsultaFormulario(listaTipoConsulta, listUnidadOperativaCombo, listAreaCombo);

            if (!string.IsNullOrWhiteSpace(codigoConsultaRelacionado))
            {
                var consultaAdjuntoRequest = new ConsultaAdjuntoRequest();
                consultaAdjuntoRequest.UsuarioSession = trabajador.Alias;
                consultaAdjuntoRequest.CodigoConsulta = new Guid(codigoConsultaRelacionado);

                modelo.Consulta = consultaService.ListadoConsulta(new ConsultaRequest() { CodigoConsulta = codigoConsultaRelacionado, CodigoUsuarioSesion = trabajador.CodigoTrabajador }).Result.FirstOrDefault();
                modelo.Consulta.ListaAdjuntos = consultaService.BuscarConsultaAdjunto(consultaAdjuntoRequest).Result;
            }

            return PartialView(modelo);
        }

        /// <summary>
        /// Formulario de Carga
        /// </summary>
        /// <returns>Vista de Formulario de carga</returns>
        public ActionResult FormularioCargaAdjunto(ConsultaRequest request, Control controles)
        {
            FormularioCargaAdjunto modelo = new FormularioCargaAdjunto();
            //var trabajador = (TrabajadorResponse)Session["DatosTrabajador"];
            var trabajador = HttpGyMSessionContext.CurrentAccount();

            request.CodigoUsuarioSesion = trabajador.CodigoTrabajador;

            modelo.Consulta = consultaService.ListadoConsulta(request).Result.FirstOrDefault();
            modelo.UsuarioSession = entornoAplicacion.UsuarioSession;
            modelo.ControlPermisos = controles;
            return PartialView(modelo);
        }
        #endregion

        #region Json
        /// <summary>
        /// Busca consultas
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Lista de Contratos</returns>
        public JsonResult BuscarConsulta(ConsultaRequest filtro)
        {
            //var trabajador = (TrabajadorResponse)Session["DatosTrabajador"];
            var trabajador = HttpGyMSessionContext.CurrentAccount();

            filtro.CodigoUsuarioSesion = trabajador.CodigoTrabajador;
            var resultado = consultaService.ListadoConsulta(filtro);
            return Json(resultado);
        }
        /// <summary>
        /// Busca Trabajador
        /// </summary>
        /// <param name="filtroReq"></param>
        /// <returns>Lista con el resultado de la operación</returns>
        public JsonResult BuscarTrabajadorUO(string filtroReq)
        {
            TrabajadorRequest filtro = new TrabajadorRequest();
            filtro.NombreCompleto = filtroReq;
            ProcessResult<List<TrabajadorDatoMinimoResponse>> resultado = trabajadorService.BuscarTrabajadorDatoMinimo(filtro);
            return Json(resultado.Result, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Registrar Consulta
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarConsulta(ConsultaRequest data)
        {
            //var trabajador = (TrabajadorResponse)Session["DatosTrabajador"];
            var trabajador = HttpGyMSessionContext.CurrentAccount();

            data.CodigoRemitente = trabajador.CodigoTrabajador;
            data.CodigoUsuarioSesion = trabajador.CodigoTrabajador;

            var resultado = consultaService.RegistrarConsulta(data);

            //Limpiando carpeta de adjuntos
            var pathTemp = ConfigurationManager.AppSettings["CarpetaAdjuntosFileServer"];
            string[] filePaths = Directory.GetFiles(Server.MapPath(pathTemp));

            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);

            return Json(resultado);
        }
        /// <summary>
        /// Reenviar Consulta
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult ReenviarConsulta(ConsultaRequest data)
        {
            var trabajador = HttpGyMSessionContext.CurrentAccount();
            data.CodigoRemitente = trabajador.CodigoTrabajador;
            var resultado = consultaService.ReenviarConsulta(data);

            //Limpiando carpeta de adjuntos
            var pathTemp = ConfigurationManager.AppSettings["CarpetaAdjuntosFileServer"];
            string[] filePaths = Directory.GetFiles(Server.MapPath(pathTemp));

            foreach (string filePath in filePaths)
                System.IO.File.Delete(filePath);

            return Json(resultado);
        }

        /// <summary>
        /// Eliminar Consulta
        /// </summary>
        /// <param name="listaCodigosPlantilla">Listade de códigos de plantilla a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEliminarFilter]
        public JsonResult EliminarConsulta(List<object> listaCodigosConsulta)
        {
            var resultado = consultaService.EliminarConsulta(listaCodigosConsulta);
            return Json(resultado);
        }

        /// <summary>
        /// Permite buscar archivos adjuntos a la consulta
        /// </summary>
        /// <returns>Vista de Formulario de carga</returns>
        public JsonResult BuscarArchivoAdjunto(ConsultaAdjuntoRequest request)
        {
            //var trabajador = (TrabajadorResponse)Session["DatosTrabajador"];
            var trabajador = HttpGyMSessionContext.CurrentAccount();

            //request.UsuarioSession = trabajador.CodigoIdentificacion;
            request.UsuarioSession = trabajador.Alias;
            var resultado = consultaService.BuscarConsultaAdjunto(request);
            return Json(resultado);
        }

        /// <summary>
        /// Registra archivos adjuntos a la consulta
        /// </summary>
        /// <returns>Vista de Formulario de carga</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarConsultaAdjunto()
        {
            //var trabajador = (TrabajadorResponse)Session["DatosTrabajador"];
            var trabajador = HttpGyMSessionContext.CurrentAccount();

            HttpPostedFileBase file = Request.Files.Count > 0 ? Request.Files[0] : null;

            var codigoConsulta = new Guid(Request["CodigoConsulta"].ToString());
            var nombreArchivo = Request["NombreArchivo"].ToString();

            var request = new ConsultaAdjuntoRequest();
            request.CodigoConsulta = codigoConsulta;

            var unidadOperativa = consultaService.ListadoConsulta(new ConsultaRequest()
            {
                CodigoConsulta = request.CodigoConsulta.ToString(),
                CodigoUsuarioSesion = trabajador.CodigoTrabajador,
            }).Result.FirstOrDefault();

            request.CodigoUnidadOperativa = (unidadOperativa != null ? unidadOperativa.CodigoUnidadOperativa : (Guid?)null);
            request.NombreArchivo = nombreArchivo;
            request.CodigoConsultaRelacionado = (Request["CodigoConsultaRelacionado"].ToString() != "null" ? new Guid(Request["CodigoConsultaRelacionado"].ToString()) : (Guid?)null);
            using (MemoryStream ms = new MemoryStream())
            {
                file.InputStream.CopyTo(ms);
                request.ArchivoAdjunto = ms.ToArray();
            }

            var resultado = consultaService.RegistrarConsultaAdjunto(request);
            return Json(resultado);
        }

        /// <summary>
        /// Elimina archivos adjuntos a la consulta
        /// </summary>
        /// <returns>Vista de Formulario de carga</returns>
        [AuthorizeEliminarFilter]
        public JsonResult EliminarArchivoAdjunto(ConsultaAdjuntoRequest request)
        {
            var resultado = consultaService.EliminarConsultaAdjunto(request);
            return Json(resultado);
        }

        /// <summary>
        /// Muestra el contenido del Contrato, dependiendo de su versión.
        /// </summary>
        /// <param name="CodigoDeContrato">Código del Contrato</param>
        /// <returns>Contenido del Contrato</returns>
        public ActionResult DescargarArchivoAdjunto(ConsultaAdjuntoRequest request)
        {
            //string NombreFile = string.Empty;
            var FileContrato = consultaService.ObtenerArchivoAdjunto(request);
            MemoryStream memorySt = null;
            if (FileContrato.Result != null)
            {
                memorySt = new MemoryStream((byte[])FileContrato.Result.ContenidoArchivo);
            }

            if (memorySt != null)
            {
                byte[] byteArchivo = memorySt.ToArray();
                Response.Clear();
                Response.AddHeader("Content-Disposition", string.Format("attachement; filename={0}", FileContrato.Result.NombreArchivo));
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

        /// <summary>
        /// Registra archivos adjuntos al contrato
        /// </summary>
        /// <returns>Vista de Formulario de carga</returns>
        public JsonResult CargarArchivoAdjunto()
        {
            ProcessResult<ConsultaAdjuntoRequest> resultado = new ProcessResult<ConsultaAdjuntoRequest>(); 
            HttpPostedFileBase file = Request.Files.Count > 0 ? Request.Files[0] : null;

            string pathTemp = string.Empty;
            pathTemp = System.Web.Configuration.WebConfigurationManager.AppSettings["CarpetaAdjuntosFileServer"];
            pathTemp = Server.MapPath(pathTemp);

            if (!Directory.Exists(pathTemp))
                Directory.CreateDirectory(pathTemp);

            //bool okExtensionDoc = false;
            string strExtension = Path.GetExtension(Request.Files[0].FileName).ToLower();

            string nameFile = Path.GetFileNameWithoutExtension(Request.Files[0].FileName) + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss") + strExtension;
            string strSaveLocation = string.Format("{0}{1}", pathTemp, nameFile);

            System.IO.FileInfo item = new System.IO.FileInfo(strSaveLocation);
            if (!item.Exists)
                Request.Files[0].SaveAs(strSaveLocation);

            var adjunto = new ConsultaAdjuntoRequest();
            adjunto.RutaArchivoSharePoint = strSaveLocation;
            adjunto.NombreArchivo = Path.GetFileNameWithoutExtension(Request.Files[0].FileName) + strExtension;

            resultado.Result = adjunto;
            resultado.IsSuccess = true;
            return Json(resultado);
        }
        #endregion
    }
}

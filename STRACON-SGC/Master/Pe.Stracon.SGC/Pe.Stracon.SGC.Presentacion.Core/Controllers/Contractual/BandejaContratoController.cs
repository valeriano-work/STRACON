using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Pe.GyM.Security.Web.Session;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.Helpers;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.BandejaContrato;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.GyM.Security.Web.Filters;
using Pe.Stracon.SGC.Cross.Core.Util;
using Pe.GyM.Security.Account.Model;
using Pe.GyM.Security.Account.SRASecurityService;
using System.Configuration;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Bandeja Contrato
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150318
    /// Modificación:
    /// </remarks>
    public class BandejaContratoController : GenericController
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
        public IContratoService contratoService { get; set; }

        /// <summary>
        /// Servicio de trabajadores
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }

        /// <summary>
        /// Interfaz de comunicación son los servidores SharePoint.
        /// </summary>
        public ISharePointService sharePointService { get; set; }

        /// <summary>
        /// Interface para obtener el entorno de la aplicación.
        /// </summary>
        public IEntornoActualAplicacion entornoAplicacion { get; set; }
        /// <summary>
        /// Servicio de manejo de flujo de aprobación
        /// </summary>
        public IFlujoAprobacionService flujoAprobacionService { get; set; }
        #endregion

        #region Vistas
        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var UsuarioSesion = HttpGyMSessionContext.CurrentAccount();
            var ListaTrabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = UsuarioSesion.Alias });
            var listaUOResponsable = contratoService.ListarUnidadOperativaResponsable(Guid.Parse(ListaTrabajador.Result[0].CodigoTrabajador));

            List<Guid?> lstUOBuscar = new List<Guid?>();
            foreach (var item in listaUOResponsable.Result)
            {
                lstUOBuscar.Add(item.CodigoUnidadOperativa);
            }

            var ListaUOs = unidadOperativaService.ListarUnidadesOperativas(lstUOBuscar);
            // = unidadOperativaService.ListarUnidadesOperativasPorResponsable(UsuarioSesion.Alias).Result;

            //var ListaTipoServicio = politicaService.ListarTipoServicio();
            var ListaTipoServicio = retornaTipoServicio();
            //var ListaTipoRequerimiento = politicaService.ListarTipoRequerimiento();
            var ListaTipoRequerimiento = retornaTipoRequerimiento();
            BandejaContratoBusqueda modelo = new BandejaContratoBusqueda(ListaUOs.Result, ListaTipoServicio, ListaTipoRequerimiento);
            modelo.ListaEstadio.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaTodos });
            modelo.ListaEstadio.AddRange(flujoAprobacionService.BuscarFlujoAprobacionEstadioDescripcion(new FlujoAprobacionEstadioRequest()).Result.Select(x => new SelectListItem()
            {
                Text = x.Descripcion,
                Value = x.Descripcion
            }).ToList());

            if (ListaTrabajador.Result != null && ListaTrabajador.Result.Count > 0)
            {
                modelo.CodigoResponsable = Guid.Parse(ListaTrabajador.Result[0].CodigoTrabajador);
            }
            else
            {
                modelo.CodigoResponsable = Guid.Empty;
            }

            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/BandejaContrato/");

            return View(modelo);
        }
        /// <summary>
        /// Muestra la vista Observaciones
        /// </summary>
        /// <returns>La vista Observación</returns>
        public ActionResult Observaciones(ContratoResponse prm)
        {
            ViewBag.CodigoTrabajador = retornaCodigoTrabajadorSession();
            ViewBag.CodigoDeContrato = prm.CodigoContrato;
            ViewBag.NumeroContrado = prm.NumeroContrato;
            ViewBag.NombreUO = prm.NombreUnidadOperativa;
            ViewBag.NombreTipoServicio = prm.NombreTipoServicio;
            ViewBag.NombreTipoRequerimiento = prm.NombreTipoRequerimiento;
            ViewBag.NombreProveedor = prm.NombreProveedor;
            ViewBag.FechaCreacion = prm.FechaIngreso;
            ViewBag.CodigoContratoEstadio = prm.CodigoContratoEstadio;
            Session.Remove(DatosConstantes.Sesiones.SessionParrafoContrato);

            if (prm.CodigoContrato != null)//Llenamos el session
            {
                obtenerSessionParrafosPorContrato(new Guid(prm.CodigoContrato.ToString()));
            }
            ViewBag.ObsPorResponder = RetornaCantidadObservacionesResponder((Guid)prm.CodigoContratoEstadio);
            ViewBag.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/BandejaContrato/");
            return View();
        }
        /// <summary>
        /// Muestra la vista Consultas
        /// </summary>
        /// <returns>Vista Consulta</returns>
        public ActionResult Consultas(ContratoResponse prm)
        {

            ViewBag.CodigoTrabajador = retornaCodigoTrabajadorSession();
            ViewBag.CodigoDeContrato = prm.CodigoContrato;
            ViewBag.NumeroContrado = prm.NumeroContrato;
            ViewBag.CodigoFlujoAprobacion = prm.CodigoFlujoAprobacion;
            ViewBag.NombreUO = prm.NombreUnidadOperativa;
            ViewBag.NombreTipoServicio = prm.NombreTipoServicio;
            ViewBag.NombreTipoRequerimiento = prm.NombreTipoRequerimiento;
            ViewBag.NombreProveedor = prm.NombreProveedor;
            ViewBag.FechaCreacion = prm.FechaIngreso;
            ViewBag.CodigoContratoEstadio = prm.CodigoContratoEstadio;
            ViewBag.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/BandejaContrato/");
            Session.Remove(DatosConstantes.Sesiones.SessionParrafoContrato);
            if (prm.CodigoContrato != null)//Llenamos el session
            {
                obtenerSessionParrafosPorContrato(new Guid(prm.CodigoContrato.ToString()));
            }
            return View();
        }

    
        #endregion

        #region Vistas Parciales
        /// <summary>
        /// Muestra la vista Formulario Observaciones
        /// </summary>
        /// <returns>Vista Parcial de Formulario Observacion</returns>
        public ActionResult FormularioObservaciones(ListadoContratoRequest contratoRequest)
        {
            var contrato = contratoService.BuscarListadoContrato(contratoRequest).Result.FirstOrDefault();
            var documentoContrato = new ContratoDocumentoResponse();

            if (!Convert.ToBoolean(contrato.IndicadorAdhesion))
            {
                documentoContrato = contratoService.DocumentosPorContrato(contrato.CodigoContrato.Value).Result.FirstOrDefault();
            }

            var modelo = new ObservacionesFormulario(contrato, documentoContrato);
            return PartialView(modelo);
        }
        /// <summary>
        /// Muestra la vista Formulario Responder Observacion
        /// </summary>
        /// <returns>Vista Parcial de Formulario Responder Observacion</returns>
        public ActionResult FormularioResponderObservacion(Guid codigoContratoEstadioObservacion, Guid codigoContrato, string TipoVista)
        {
            var contrato = contratoService.BuscarListadoContrato(new ListadoContratoRequest()
            {
                CodigoContrato = codigoContrato.ToString()
            }).Result.FirstOrDefault();

            var documentoContrato = new ContratoDocumentoResponse();

            if (!Convert.ToBoolean(contrato.IndicadorAdhesion))
            {
                documentoContrato = contratoService.DocumentosPorContrato(contrato.CodigoContrato.Value).Result.FirstOrDefault();
            }

            ObservacionesFormulario model = new ObservacionesFormulario(contrato, documentoContrato);

            var rptaObservacion = contratoService.ObtieneContratoEstadioObservacionPorID(codigoContratoEstadioObservacion);
            string lsRespuesta = string.Empty;
            string lsParrafo = retornaContenidoParrafoContrato(rptaObservacion.CodigoContratoParrafo);
            if (TipoVista == "C")
            {//Edicion
                lsRespuesta = rptaObservacion.Respuesta;
            }
            ViewBag.TipoVista = TipoVista;
            ViewBag.Codigo = rptaObservacion.CodigoContratoEstadioObservacion;
            ViewBag.CodigoContratoEstadio = rptaObservacion.CodigoContratoEstadio;
            ViewBag.TextoObservacion = rptaObservacion.Descripcion;
            ViewBag.FechaRegistro = rptaObservacion.FechaRegistro;
            ViewBag.CodigoContratoParrafo = rptaObservacion.CodigoContratoParrafo;
            ViewBag.CodigoEstadioRetorno = rptaObservacion.CodigoEstadioRetorno;
            ViewBag.Destinatario = rptaObservacion.Destinatario;
            ViewBag.TextoParrafo = lsParrafo;
            ViewBag.TextoRespuesta = lsRespuesta;
            return PartialView(model);
        }
        /// <summary>
        /// Muestra la vista Formulario Consulta
        /// </summary>
        /// <returns>Vista Parcial de Formulario de Consulta</returns>
        public ActionResult FormularioConsulta(Guid codigoFlujoAprobacion, Guid codigoContrato)
        {
            var contrato = contratoService.BuscarListadoContrato(new ListadoContratoRequest()
            {
                CodigoContrato = codigoContrato.ToString()
            }).Result.FirstOrDefault();

            ConsultasBusqueda model = new ConsultasBusqueda(contrato);
            model.ResponsableFlujoEstadio = new List<SelectListItem>();

            var UsuarioSesion = HttpGyMSessionContext.CurrentAccount();
            var ListaTrabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = UsuarioSesion.Alias });

            if (ListaTrabajador.Result == null) ListaTrabajador.Result = new List<Politicas.Aplicacion.TransferObject.Response.General.TrabajadorResponse>();

            var listaResponsable = contratoService.RetornaResponsablesFlujoEstadio(codigoFlujoAprobacion, codigoContrato);
            foreach (var item in listaResponsable.Result)
            {
                if (ListaTrabajador.Result.Count > 0)
                {
                    if (item.CodigoTrabajador.ToUpper() != ListaTrabajador.Result[0].CodigoTrabajador.ToUpper())
                    {
                        model.ResponsableFlujoEstadio.Add(new SelectListItem() { Text = item.NombreCompleto, Value = item.CodigoTrabajador });
                    }
                }
                else
                {
                    model.ResponsableFlujoEstadio.Add(new SelectListItem() { Text = item.NombreCompleto, Value = item.CodigoTrabajador });
                }
            }
            //model.ResponsableFlujoEstadio = new List<SelectListItem>();
            return PartialView(model);
        }
        /// <summary>
        /// Muestra la vista Formula Responder Consulta
        /// </summary>
        /// <returns>Vista Parcial de Formulario Responder Consulta</returns>
        public ActionResult FormularioResponderConsulta(Guid codigoContratoEstadioConsulta, Guid codigoContrato, string TipoVista)
        {
            var contrato = contratoService.BuscarListadoContrato(new ListadoContratoRequest()
            {
                CodigoContrato = codigoContrato.ToString()
            }).Result.FirstOrDefault();

            var documentoContrato = new ContratoDocumentoResponse();

            if (!Convert.ToBoolean(contrato.IndicadorAdhesion))
            {
                documentoContrato = contratoService.DocumentosPorContrato(contrato.CodigoContrato.Value).Result.FirstOrDefault();
            }

            ObservacionesFormulario model = new ObservacionesFormulario(contrato, documentoContrato);

            var rptaConsulta = contratoService.ObtieneContratoEstadioConsultaPorID(codigoContratoEstadioConsulta);
            string lsRespuesta = string.Empty;
            string lsParrafo = retornaContenidoParrafoContrato(rptaConsulta.CodigoContratoParrafo);

            if (TipoVista == "C")
            {//Edicion
                lsRespuesta = rptaConsulta.Respuesta;
            }
            ViewBag.TipoVista = TipoVista;
            ViewBag.Codigo = rptaConsulta.CodigoContratoEstadioConsulta;
            ViewBag.CodigoContratoEstadio = rptaConsulta.CodigoContratoEstadio;
            ViewBag.FechaConsulta = rptaConsulta.FechaConsulta;
            ViewBag.CodigoContratoParrafo = rptaConsulta.CodigoContratoParrafo;
            ViewBag.Destinatario = rptaConsulta.Destinatario;
            ViewBag.TextoParrafo = lsParrafo;
            ViewBag.TextoConsulta = rptaConsulta.Descripcion;
            ViewBag.TextoRespuesta = lsRespuesta;
            return PartialView(model);
        }

        /// <summary>
        /// Muestra el formulario de trabajador Suplente
        /// </summary>
        /// <returns>Vista FormularioTrabajador</returns>
        public ActionResult FormularioTrabajadorSuplente()
        {
            var usuarioActual = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = entornoAplicacion.UsuarioSession }).Result.FirstOrDefault();

            var trabajadorSuplente = trabajadorService.BuscarTrabajadorSuplente(new TrabajadorRequest() { CodigoTrabajador = new Guid(usuarioActual.CodigoTrabajador) }).Result.FirstOrDefault();

            TrabajadorSuplenteModel modelo = new TrabajadorSuplenteModel(usuarioActual);

            if (trabajadorSuplente != null)
            {
                var trabajadorSuplenteDefinicion = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = trabajadorSuplente.CodigoSuplente }).Result;

                trabajadorSuplente.ListaSuplente = trabajadorSuplenteDefinicion.ToDictionary(x => x.CodigoTrabajador, y => y.NombreCompleto);

                modelo = new TrabajadorSuplenteModel(trabajadorSuplente, usuarioActual);
            }

            return PartialView(modelo);
        }

        #endregion

        #region Json
        /// <summary>
        /// Busca Bandeja Contrato
        /// </summary>
        /// <returns>Lista de Contrato</returns>
        public JsonResult BuscarBandejaContrato(ContratoRequest request)

        {
            var listaTipoServicio = retornaTipoServicio();
            var listaTipoRequerimiento = retornaTipoRequerimiento();
            
            var resultado = contratoService.BuscarBandejaProcesosContratoOrdenado(request, listaTipoServicio, listaTipoRequerimiento);
            var jsonResult = Json(resultado, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        /// <summary>
        /// Busca Bandeja Observaciones
        /// </summary>
        /// <returns>Lista de Observaciones</returns>
        public JsonResult BuscarBandejaObservaciones(Guid? CodigoContratoEstadio)
        {
            Guid codContratoEsta = Guid.Empty;
            if (CodigoContratoEstadio != null)
            {
                codContratoEsta = (Guid)CodigoContratoEstadio;
            }
            var resultado = contratoService.BuscarBandejaContratosObservacion(codContratoEsta);
            return Json(resultado);
        }
        /// <summary>
        /// Registra Observaciones
        /// </summary>
        /// <returns>Objeto request de Contrato Estadio Observacion</returns>
        ///[AuthorizeEscrituraFilter]
        public JsonResult RegistrarObservaciones()
        {
            var request = new ContratoEstadioObservacionRequest();

            if (Request["CodigoContrato"] != null)
            {
                request.CodigoContrato = new Guid(Request["CodigoContrato"].ToString());
            }

            if (Request["ConCopiaCorreo"] != null)
            {
                request.NotificacionObservadoCC = Request["ConCopiaCorreo"].ToString();
            }

            if (Request["CodigoContratoEstadio"] != null)
            {
                request.CodigoContratoEstadio = new Guid(Request["CodigoContratoEstadio"].ToString());
            }

            if (Request["Descripcion"] != null)
            {
                request.Descripcion = Request["Descripcion"].ToString();
            }

            if (Request["Destinatario"] != null)
            {
                request.Destinatario = new Guid(Request["Destinatario"].ToString());
            }

            if (Request["CodigoEstadioRetorno"] != null)
            {
                request.CodigoEstadioRetorno = new Guid(Request["CodigoEstadioRetorno"].ToString());
            }

            if (Request["IndicadorAdhesion"] != null)
            {
                request.IndicadorAdhesion = Convert.ToBoolean(Request["IndicadorAdhesion"].ToString());

                if (request.IndicadorAdhesion)
                {
                    HttpPostedFileBase file = Request.Files.Count > 0 ? Request.Files[0] : null;
                    if (file != null)
                    {
                        byte[] documentoContrato = null;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            file.InputStream.CopyTo(ms);
                            documentoContrato = ms.ToArray();
                        }
                        request.NombreArchivo = file.FileName;
                        request.DocumentoContrato = documentoContrato;
                    }
                }
            }
         

            var resultado = contratoService.RegistraContratoEstadioObservacion(request);
            return Json(resultado);
        }
        /// <summary>
        /// Respuesta a Observaciones de contrato
        /// </summary>
        /// <param name="objRqst">objeto request de Contrato Estadio Observacion</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ///[AuthorizeEscrituraFilter]
        public JsonResult RespondeObservaciones(ContratoEstadioObservacionRequest objRqst)
        {
            var resultado = contratoService.RespondeContratoEstadioObservacion(objRqst);
            return Json(resultado);
        }
        /// <summary>
        /// Busca Bandeja Consulta
        /// </summary>
        /// <returns>Lista con el resultado de la operación</returns>
        public JsonResult BuscarBandejaConsulta(Guid CodigoContratoEstadio)
        {
            var resultado = contratoService.BuscarBandejaContratosConsultas(CodigoContratoEstadio);
            return Json(resultado);
        }
        /// <summary>
        /// Registra la consulta del contrato
        /// </summary>
        /// <param name="objRqst">objeto request que contiene la información</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        //[AuthorizeEscrituraFilter]
        public JsonResult RegistrarConsulta(ContratoEstadioConsultaRequest objRqst)
        {
            var resultado = contratoService.RegistraContratoEstadioConsulta(objRqst);
            return Json(resultado);
        }
        /// <summary>
        /// Metodo para Aprobar un Estadío de un Contrato
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato</param>
        /// <param name="codigoContratoEstadio">Código de Contrato de Estadio</param>
        /// <param name="MotivoAprobacion">Motivo de aprobación no obligatoria</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ///[AuthorizeEscrituraFilter]
        public JsonResult AprobarContratoEstadio(Guid codigoContrato, Guid codigoContratoEstadio, string MotivoAprobacion)
        {
            var resultado = contratoService.ApruebaContratoEstadio(codigoContrato, codigoContratoEstadio, MotivoAprobacion, entornoAplicacion.UsuarioSession);
            return Json(resultado);
        }
        /// <summary>
        /// Retorna la lista de Párrafos por Contrato.
        /// </summary>
        /// <param name="CodigoContrato">Código del Contrato</param>
        /// <returns>Lista de Parrafos por contrato</returns>
        public JsonResult ListaParrafosPorContrato(Guid CodigoContrato)
        {
            Aplicacion.Core.Base.ProcessResult<List<ContratoParrafoResponse>> lstParrafos = new Aplicacion.Core.Base.ProcessResult<List<ContratoParrafoResponse>>();
            obtenerSessionParrafosPorContrato(CodigoContrato);
            lstParrafos.Result = (List<ContratoParrafoResponse>)Session[DatosConstantes.Sesiones.SessionParrafoContrato];
            return Json(lstParrafos);
        }
        /// <summary>
        /// Retorna la lista de estadíos por Contrato
        /// </summary>
        /// <param name="CodigoContratoEstadio">Código de Contrato Estadío</param>
        /// <returns>Lista Estadios por Contrato</returns>
        public JsonResult ListaEstadiosPorContrato(Guid CodigoContratoEstadio)
        {
            var listaEstadio = contratoService.RetornaEstadioContratoObservacion(CodigoContratoEstadio);
            return Json(listaEstadio);
        }

        /// <summary>
        /// Muestra el contenido del Contrato, dependiendo de su versión.
        /// </summary>
        /// <param name="CodigoDeContrato">Código del Contrato</param>
        /// <param name="codigoContratoEstadio"></param>
        /// <returns>Contenido del Contrato</returns>
        public ActionResult MostrarContratoDocumento(Guid CodigoDeContrato, Guid? codigoContratoEstadio)
        {
            string NombreFile = string.Empty;
            string lslinkCss = System.Web.HttpContext.Current.Server.MapPath("~/Theme/app/cssPdf.css");
            var FileContrato = contratoService.GenerarContenidoContrato(CodigoDeContrato, codigoContratoEstadio, ref NombreFile, lslinkCss);
            MemoryStream memorySt = null;
            if (FileContrato.Result != null && FileContrato.IsSuccess)
            {
                memorySt = new MemoryStream((byte[])FileContrato.Result);
            }

            if (memorySt != null)
            {
                byte[] byteArchivo = memorySt.ToArray();
                Response.Clear();
                Response.AddHeader("Content-Disposition", string.Format("attachement; filename={0}", NombreFile));
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
        /// Muestra el contenido del Contrato, dependiendo su observación.
        /// </summary>
        /// <param name="codigoContratoEstadioObservacion">Código de la Observación del Estadio del Contrato</param>
        /// <returns>Contenido del Contrato</returns>
        public ActionResult MostrarContratoDocumentoAnteriorObservacion(Guid codigoContratoEstadioObservacion)
        {
            string nombreArchivo = string.Empty;
            var FileContrato = contratoService.ObtenerContratoAnteriorObservacion(codigoContratoEstadioObservacion, ref nombreArchivo);
            MemoryStream memorySt = null;
            if (FileContrato.Result != null)
            {
                memorySt = new MemoryStream((byte[])FileContrato.Result);
            }

            if (memorySt != null)
            {
                byte[] byteArchivo = memorySt.ToArray();
                Response.Clear();
                Response.AddHeader("Content-Disposition", string.Format("attachement; filename={0}", nombreArchivo));
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
        /// Muestra el contenido del Contrato, dependiendo su observación.
        /// </summary>
        /// <param name="codigoContratoEstadioObservacion">Código de la Observación del Estadio del Contrato</param>
        /// <returns>Contenido del Contrato</returns>
        public ActionResult MostrarContratoDocumentoReemplazanteObservacion(Guid codigoContratoEstadioObservacion)
        {
            string nombreArchivo = string.Empty;
            var FileContrato = contratoService.ObtenerContratoReemplazanteObservacion(codigoContratoEstadioObservacion, ref nombreArchivo);
            MemoryStream memorySt = null;
            if (FileContrato.Result != null)
            {
                memorySt = new MemoryStream((byte[])FileContrato.Result);
            }

            if (memorySt != null)
            {
                byte[] byteArchivo = memorySt.ToArray();
                Response.Clear();
                Response.AddHeader("Content-Disposition", string.Format("attachement; filename={0}", nombreArchivo));
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
        /// Permite registrar el trabajador
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <returns>Resultado de la operación</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarTrabajadorSuplente(TrabajadorSuplenteRequest filtro)
        {
            filtro.UsuarioSession = entornoAplicacion.UsuarioSession;
            filtro.Terminal = entornoAplicacion.Terminal;

            var resultado = trabajadorService.RegistrarTrabajadorSuplente(filtro);

            if (resultado.IsSuccess)
            {
                if (filtro.Activo == false)
                {
                    var result = flujoAprobacionService.ActualizarTrabajadorOriginalFlujo(filtro.CodigoTrabajador);

                    resultado.IsSuccess = result.IsSuccess;
                    trabajadorService.EnviarNotificacionFinReemplazo(filtro.CodigoTrabajador, filtro.CodigoSuplente.Value);
                }
            }

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
            Pe.Stracon.Politicas.Aplicacion.Core.Base.ProcessResult<List<TrabajadorDatoMinimoResponse>> resultado = trabajadorService.BuscarTrabajadorDatoMinimo(filtro);
            return Json(resultado.Result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        /// <summary>
        /// Carga información de un contrato estadio.
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        public JsonResult CargaDocumentoContratoEstadio()
        {
            Aplicacion.Core.Base.ProcessResult<object> rpta = new Aplicacion.Core.Base.ProcessResult<object>();
            string codigoContratoDocumento = string.Empty, NombreUO = string.Empty, hayError = string.Empty;
            string lsDirectorioDestino, listName, folderName;
            Guid codigoContrato;

            HttpPostedFileBase file = Request.Files.Count > 0 ? Request.Files[0] : null;
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    codigoContratoDocumento = Guid.NewGuid().ToString();
                    codigoContrato = Guid.Parse(Request["CodigoDeContrato"].ToString());
                    NombreUO = Request["NombreUnidadOperativa"].ToString();

                    #region InformacionRepositorioSharePoint
                    string NombreFile = string.Format("{0}.{1}", codigoContratoDocumento.ToString(), DatosConstantes.ArchivosContrato.ExtensionValidaCarga);
                    Aplicacion.Core.Base.ProcessResult<string> miDirectorio = contratoService.RetornaDirectorioFile(codigoContrato, NombreUO, NombreFile);
                    lsDirectorioDestino = miDirectorio.Result.ToString();
                    string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });
                    listName = nivelCarpeta[0];
                    folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                    #endregion
                    //CodigoArchivoSHP = ProcesaArchivoSharePoint(file, lstCodigosParam, ref hayErrorShp, ref lsRutaDestinoArchivo);                    
                    MemoryStream ms;
                    using (ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                    }
                    var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, NombreFile, ms);
                    if (Convert.ToInt32(regSHP.Result) > 0 && hayError == string.Empty)
                    {
                        ContratoDocumentoResponse cdr = new ContratoDocumentoResponse();
                        cdr.CodigoContratoDocumento = Guid.Parse(codigoContratoDocumento);
                        cdr.CodigoContrato = codigoContrato;
                        cdr.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                        cdr.RutaArchivoSharePoint = lsDirectorioDestino;
                        rpta = contratoService.RegistraContratoDocumentoCargaArchivo(cdr);
                        if (Convert.ToInt32(regSHP.Result) == -1)
                        {
                            rpta.IsSuccess = false;
                            rpta.Result = regSHP.Exception;
                        }
                    }
                    else
                    {
                        rpta.IsSuccess = false;
                        rpta.Result = hayError;
                    }
                }
                catch (Exception ex)
                {
                    rpta.IsSuccess = false;
                    rpta.Result = ex.Message;
                }
            }
            return Json(rpta);
        }

        #region MetodosInternos
        /// <summary>
        /// Metodo para registrar los párrafos en una sessión.
        /// </summary>
        /// <param name="codigoContrato">código del contrato que contiene los párrafos.</param>
        private void obtenerSessionParrafosPorContrato(Guid codigoContrato)
        {
            List<ContratoParrafoResponse> lstParrafos = new List<ContratoParrafoResponse>();
            if (Session[DatosConstantes.Sesiones.SessionParrafoContrato] == null)
            {
                lstParrafos = contratoService.RetornaParrafosPorContrato(codigoContrato).Result;
                Session[DatosConstantes.Sesiones.SessionParrafoContrato] = lstParrafos;
            }
        }

        /// <summary>
        /// Retorna el código GUID del Trabajador.
        /// </summary>
        /// <returns>Codigo Guid del Trabajador</returns>
        private string retornaCodigoTrabajadorSession()
        {
            var UsuarioSesion = HttpGyMSessionContext.CurrentAccount();
            var ListaTrabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = UsuarioSesion.Alias });
            string ls_codtrb = string.Empty;
            if (ListaTrabajador.Result != null && ListaTrabajador.Result.Count > 0)
            {
                ls_codtrb = ListaTrabajador.Result[0].CodigoTrabajador.ToString();
            }
            else
            {
                ls_codtrb = Guid.Empty.ToString();
            }
            return ls_codtrb;
        }
        /// <summary>
        /// Retorna el contenido de cada párrafo por el codigo.
        /// </summary>
        /// <param name="codigoContratoParrafo">Código el Párrafo de contrato.</param>
        /// <returns>Contenido de Parrafo</returns>
        private string retornaContenidoParrafoContrato(Guid? codigoContratoParrafo)
        {
            string lsParrafo = string.Empty;
            int li_index = -1;//Obtenemos el Párrafo            
            List<ContratoParrafoResponse> lstParrafos = (List<ContratoParrafoResponse>)Session[DatosConstantes.Sesiones.SessionParrafoContrato];
            if (lstParrafos != null && lstParrafos.Count > 0)
            {
                li_index = lstParrafos.FindIndex(x => x.CodigoContratoParrafo.ToString().ToUpper() == codigoContratoParrafo.ToString().ToUpper());
                if (li_index > -1)
                {
                    lsParrafo = lstParrafos[li_index].Contenido;
                }
            }
            return lsParrafo;
        }

        /// <summary>
        /// Procedimiento que actualiza el Archivo en Repositorio SharePoint y devuelve el ID generado del archivo
        /// </summary>
        /// <param name="file">Codigo File</param>
        /// <param name="lstParametros">Codigo Lista Parametros</param>
        /// <param name="hayError">Codigo Error</param>
        /// <param name="RutaDestino">Codigo Ruta Destino</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int ProcesaArchivoSharePoint(HttpPostedFileBase file, List<string> lstParametros, ref string hayError, ref string RutaDestino)
        {
            int resultado = -1;
            try
            {
                string lsUrlServerSHP = string.Empty, lsSite = string.Empty;
                string userShp = string.Empty, passWord = string.Empty, dominio = string.Empty;
                RutaDestino = string.Empty;

                Guid CodContrato = Guid.Parse(lstParametros[0]);
                string NombreUO = lstParametros[1];
                string NombreFile = string.Format("{0}.{1}", lstParametros[2], DatosConstantes.ArchivosContrato.ExtensionValidaCarga);

                #region GrabarInformacionSH
                /*Servicio armar el directorio.*/
                var lsRuta = contratoService.RetornaDirectorioFile(CodContrato, NombreUO, NombreFile);

                string lsDirectorioDestino = lsRuta.Result.ToString();
                RutaDestino = lsDirectorioDestino;

                var cfgSharePoint = politicaService.ListarConfiguracionSharePoint(null, "3");
                var crdSharePoint = politicaService.ListarCredencialesAccesoDinamico();

                lsUrlServerSHP = cfgSharePoint.Result[0].Valor.ToString();
                lsSite = cfgSharePoint.Result[1].Valor.ToString();

                userShp = crdSharePoint.Result[0].Atributo3;
                passWord = crdSharePoint.Result[0].Atributo4;
                dominio = crdSharePoint.Result[0].Atributo5;

                MemoryStream ms;
                using (ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                }
                /*Revisamos la estructura de las carpetas SharePoint*/
                string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });

                SharepointEN shEnt = new SharepointEN();
                shEnt.siteUrlParam = string.Format("{0}{1}", lsUrlServerSHP, lsSite);
                shEnt.listName = nivelCarpeta[0];
                shEnt.folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                shEnt.fileName = NombreFile;
                shEnt.msfile = ms;

                SharepointHelper shp = new SharepointHelper(userShp, passWord, dominio);
                int NewFileSharePoint = shp.RegistraFileSharePointSCC(shEnt, ref hayError);

                return NewFileSharePoint;
                #endregion
            }
            catch (Exception)
            {
                resultado = -1;
            }
            return resultado;
        }

        /// <summary>
        /// metodo para retorna el contenido html de un parrafo.
        /// </summary>
        /// <param name="codigoContratoParrafo">Código del Contrato - Parrafo</param>
        /// <returns>Contenido HTML de Parrafo</returns>
        public JsonResult ConsultaContenidoParrafo(Guid codigoContratoParrafo)
        {
            Aplicacion.Core.Base.ProcessResult<string> rptaParrafo = new ProcessResult<string>();
            rptaParrafo.Result = retornaContenidoParrafoContrato(codigoContratoParrafo);

            return Json(rptaParrafo);
        }

        /// <summary>
        /// Retorna la cantidad de obesrvaciones pendientes de responder.
        /// </summary>
        /// <param name="codigoContratoEstadio">Código de Contrato Estadio.</param>
        /// <returns>Cantidad de Observaciones pendientes</returns>
        private int RetornaCantidadObservacionesResponder(Guid codigoContratoEstadio)
        {
            int obsPorResponder = 0;
            var lstObservaciones = contratoService.BuscarBandejaContratosObservacion(codigoContratoEstadio);
            if (lstObservaciones.Result != null && lstObservaciones.Result.Count > 0)
            {
                foreach (var item in lstObservaciones.Result)
                {
                    if (string.IsNullOrEmpty(item.CodigoTipoRespuesta))
                    {
                        obsPorResponder++;
                    }
                }
            }
            return obsPorResponder;
        }
        /// <summary>
        /// Método para obetener la cantidad de obesrvaciones pendientes de responder.
        /// </summary>
        /// <param name="codigoContratoEstadio"></param>
        /// <returns>Obeservaciones pendientes por responder</returns>
        public JsonResult ObservacionesPorResponder(Guid codigoContratoEstadio)
        {
            Aplicacion.Core.Base.ProcessResult<object> rpta = new ProcessResult<object>();
            rpta.Result = RetornaCantidadObservacionesResponder(codigoContratoEstadio);
            return Json(rpta);
        }

        /// <summary>
        /// Retorna la lista de Tipo de Servicio del Contrato
        /// </summary>
        /// <returns>Lista de Tipo de Servicio del Contrato</returns>
        public List<CodigoValorResponse> retornaTipoServicio()
        {
            List<CodigoValorResponse> listaTipoServicio = new List<CodigoValorResponse>();
            if (Session[DatosConstantes.Sesiones.SessionTipoServicio] == null)
            {
                listaTipoServicio = politicaService.ListarTipoContrato().Result;
                Session[DatosConstantes.Sesiones.SessionTipoServicio] = listaTipoServicio;
            }
            else
            {
                listaTipoServicio = (List<CodigoValorResponse>)Session[DatosConstantes.Sesiones.SessionTipoServicio];
            }
            return listaTipoServicio;
        }

        /// <summary>
        /// Retorna la lista de Tipo de Requerimiento del Contrato
        /// </summary>
        /// <returns>Lista de Tipo de Requerimiento del Contrato</returns>
        public List<CodigoValorResponse> retornaTipoRequerimiento()
        {
            List<CodigoValorResponse> listaTipoRequerimiento = new List<CodigoValorResponse>();
            if (Session[DatosConstantes.Sesiones.SessionTipoRequerimiento] == null)
            {
                listaTipoRequerimiento = politicaService.ListarTipoServicio().Result;
                Session[DatosConstantes.Sesiones.SessionTipoRequerimiento] = listaTipoRequerimiento;
            }
            else
            {
                listaTipoRequerimiento = (List<CodigoValorResponse>)Session[DatosConstantes.Sesiones.SessionTipoRequerimiento];
            }
            return listaTipoRequerimiento;
        }
        #endregion
    }
}
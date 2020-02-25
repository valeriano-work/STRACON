using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Base;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ListadoRequerimiento;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using System.IO;
using Pe.Stracon.SGC.Cross.Core.Util;
using System.Web;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using System.Globalization;
using Pe.GyM.Security.Web.Filters;
using Pe.GyM.Security.Account.Model;
using Pe.GyM.Security.Web.Session;


namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Listado Contrato
    /// </summary>
    /// <remarks>
    /// Creación:       QUALIS 20191015
    /// Modificación:
    /// </remarks>
    public class ListadoRequerimientoController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary> 
        public IPoliticaService politicaService { get; set; }

        /// <summary>
        /// Servicio de manejo de unidad operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }

        /// <summary>
        /// Servicio de manejo de trabajador
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }


        /// <summary>
        /// Servicio de manejo de plantilla
        /// </summary>
        public IPlantillaService plantillaService { get; set; }

        /// <summary>
        /// Servicio de manejo de flujo de aprobación
        /// </summary>
        public IFlujoAprobacionService flujoAprobacionService { get; set; }

        /// <summary>
        /// Servicio de manejo de proveedor
        /// </summary>
        public IProveedorService proveedorService { get; set; }

        /// <summary>
        /// Servicio de información de requerimiento
        /// </summary>
        public IRequerimientoService contratoService { get; set; }

        /// <summary>
        /// Servicio de información de variable
        /// </summary>
        public IVariableService variableService { get; set; }

        /// <summary>
        /// Servicio de manejo de Bien
        /// </summary>
        public IBienService bienService { get; set; }

        /// <summary>
        /// Interface para obtener el entorno de la aplicación.
        /// </summary>
        public IEntornoActualAplicacion entornoAplicacion { get; set; }

        /// <summary>
        /// Trabajador que entro al listado de contratos
        /// </summary>
        public static TrabajadorResponse trabajador { get; set; }

        #endregion

        #region Vistas
        /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var listaUnidadOperativa = new List<SelectListItem>();
            listaUnidadOperativa.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaTodos });

            trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = entornoAplicacion.UsuarioSession }).Result.FirstOrDefault();

            if (trabajador != null)
            {
                if (trabajador.IndicadorTodaUnidadOperativa)
                {
                    var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto }).Result;
                    listaUnidadOperativa.AddRange(unidadOperativa.Select(item => new SelectListItem() { Value = item.CodigoUnidadOperativa.ToString(), Text = item.Nombre }).ToList());
                }
                else
                {
                    TrabajadorUnidadOperativaRequest trabajadaroUnidadOperativaRequest = new TrabajadorUnidadOperativaRequest();
                    trabajadaroUnidadOperativaRequest.CodigoUnidadOperativaMatriz = new Guid(trabajador.CodigoUnidadOperativaMatriz);
                    trabajadaroUnidadOperativaRequest.CodigoTrabajador = new Guid(trabajador.CodigoTrabajador);

                    var listaUnidadOperativaAsociadoTrabajador = trabajadorService.ListarTrabajadorUnidadOperativa(trabajadaroUnidadOperativaRequest).Result;
                    listaUnidadOperativa.AddRange(listaUnidadOperativaAsociadoTrabajador.Select(item => new SelectListItem() { Value = item.CodigoUnidadOperativa.ToString(), Text = item.NombreUnidadOperativa }).ToList());
                }
            }

            var TipoDocAdj = politicaService.ListarDocAdjunto().Result.OrderBy(x => x.Valor).ToList();
            var TipoModCon = politicaService.ListarModCon().Result.OrderBy(x => x.Valor).ToList();
            var tipoDocumento = politicaService.ListarTipoDocumentoRequerimiento().Result.OrderBy(x => x.Valor).ToList();
            var estadoContrato = politicaService.ListarEstadoContrato().Result.OrderBy(x => x.Valor).ToList();
            var estadoEdicion = politicaService.ListarEstadoEdicion().Result;


            var modelo = new ListadoRequerimientoBusqueda(TipoDocAdj, tipoDocumento, estadoContrato, listaUnidadOperativa, estadoEdicion);
            modelo.ListaEstadio.Add(new SelectListItem() { Text = GenericoResource.EtiquetaTodos, Value = string.Empty });
            modelo.ListaEstadio.AddRange(flujoAprobacionService.BuscarFlujoAprobacionEstadioDescripcion(new FlujoAprobacionEstadioRequest()).Result.Where(p => p.Orden != 1 || p.Descripcion != "Edición").Select(x => new SelectListItem()
            {
                Text = x.Descripcion,
                Value = x.Descripcion
            }).ToList());

            modelo.Aprobado = DatosConstantes.EstadoContrato.Aprobacion;

            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/ListadoRequerimiento/");

            modelo.NoAprobado = "NA";

            var moneda = politicaService.ListarMoneda().Result.OrderBy(x => x.Valor).ToList();
            modelo.Moneda.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });
            modelo.Moneda.AddRange(moneda.Select(item => new SelectListItem() { Text = item.Valor.ToString(), Value = item.Codigo.ToString() }).ToList());


            return View(modelo);
        }
        #endregion

        #region Vistas Parciales
        /// <summary>
        /// Muestra el formulario de Contrato
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato</param>
        /// <param name="valorEdicion"></param>
        /// <returns>Vista del formulario Contrato</returns>
        public ActionResult FormularioContrato(string codigoContrato, string valorEdicion)
        {
            ContratoFormulario modelo;

            if (!string.IsNullOrWhiteSpace(codigoContrato))
            {
                RequerimientoResponse contrato = contratoService.RetornaRequerimientoPorId(new Guid(codigoContrato)).Result;

                var TipoDocAdj = politicaService.ListarDocAdjunto().Result.OrderBy(x => x.Valor).ToList();
                var tipoDocumento = politicaService.ListarTipoDocumentoContrato().Result.OrderBy(x => x.Valor).ToList();
                var moneda = politicaService.ListarMoneda().Result.OrderBy(x => x.Valor).ToList();
                var TipoModCon = politicaService.ListarModCon().Result.OrderBy(x => x.Valor).ToList();

                List<SelectListItem> listaUnidadOperativa = new List<SelectListItem>();
                var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto, CodigoUnidadOperativa = contrato.CodigoUnidadOperativa.ToString() }).Result;
                listaUnidadOperativa.AddRange(unidadOperativa.Select(item => new SelectListItem() { Value = item.CodigoUnidadOperativa.ToString(), Text = item.Nombre, Selected = true }).ToList());
                if (contrato.CodigoRequerido != "")
                {
                    var NomRequerido = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = new Guid(contrato.CodigoRequerido) }).Result;
                    contrato.ListaRequerido = NomRequerido.ToDictionary(x => x.CodigoTrabajador, y => y.NombreCompleto);
                }


                modelo = new ContratoFormulario();
                modelo.Contrato = contrato;
                modelo.ListadoUnidadOperativa = listaUnidadOperativa;
                modelo.TipoDocAdj = TipoDocAdj.FindAll(p => p.Codigo.ToString() == modelo.Contrato.CodigoDocAdj.ToString()).Select(item => new SelectListItem() { Text = item.Valor.ToString(), Value = item.Codigo.ToString() }).ToList();
                modelo.TipoModCon = TipoModCon.FindAll(p => p.Codigo.ToString() == modelo.Contrato.CodigoModCon.ToString()).Select(item => new SelectListItem() { Text = item.Valor.ToString(), Value = item.Codigo.ToString() }).ToList();
                modelo.TipoDocumento = tipoDocumento.FindAll(p => p.Codigo.ToString() == modelo.Contrato.CodigoTipoDocumento.ToString()).Select(item => new SelectListItem() { Text = item.Valor.ToString(), Value = item.Codigo.ToString() }).ToList();
                modelo.Moneda.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });
                modelo.Moneda.AddRange(moneda.Select(item => new SelectListItem() { Text = item.Valor.ToString(), Value = item.Codigo.ToString(), Selected = item.Codigo.ToString() == contrato.CodigoMoneda }).ToList());               
                modelo.NuevoContrato = false;
            }
            else
            {
                var TipoDocAdj = politicaService.ListarDocAdjunto().Result.OrderBy(x => x.Codigo).ToList();
                var TipoModCon = politicaService.ListarModCon().Result.OrderBy(x => x.Codigo).ToList();
                var tipoDocumento = politicaService.ListarTipoDocumentoRequerimiento().Result.OrderBy(x => x.Valor).ToList();
                var moneda = politicaService.ListarMoneda().Result.OrderBy(x => x.Valor).ToList();

                List<SelectListItem> listaUnidadOperativa = new List<SelectListItem>();
                listaUnidadOperativa.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });

                trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = entornoAplicacion.UsuarioSession }).Result.FirstOrDefault();               

                if (trabajador != null)
                {
                    if (trabajador.IndicadorTodaUnidadOperativa)
                    {
                        var unidadOperativa = unidadOperativaService.BuscarUnidadOperativaSAP(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto }).Result;
                        listaUnidadOperativa.AddRange(unidadOperativa.Select(item => new SelectListItem() { Value = item.CodigoUnidadOperativa.ToString(), Text = item.Nombre }).ToList());
                    }
                    else
                    {
                        TrabajadorUnidadOperativaRequest trabajadaroUnidadOperativaRequest = new TrabajadorUnidadOperativaRequest();
                        trabajadaroUnidadOperativaRequest.CodigoUnidadOperativaMatriz = new Guid(trabajador.CodigoUnidadOperativaMatriz);
                        trabajadaroUnidadOperativaRequest.CodigoTrabajador = new Guid(trabajador.CodigoTrabajador);

                        var listaUnidadOperativaAsociadoTrabajador = trabajadorService.ListarTrabajadorUnidadOperativaSAP(trabajadaroUnidadOperativaRequest).Result;
                        listaUnidadOperativa.AddRange(listaUnidadOperativaAsociadoTrabajador.Select(item => new SelectListItem() { Value = item.CodigoUnidadOperativa.ToString(), Text = item.NombreUnidadOperativa }).ToList());
                    }
                }
                modelo = new ContratoFormulario(TipoDocAdj, tipoDocumento, moneda, listaUnidadOperativa, TipoModCon);
                modelo.NuevoContrato = true;
            }
            modelo.ValorEdicion = valorEdicion;
            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra el formulario de Contrato
        /// </summary>
        /// <param name="data">Datos del contrato</param>
        /// <returns>Vista del formulario Contrato</returns>
        public ActionResult FormularioCopiaContrato(ListadoContratoResponse data)
        {
            var moneda = politicaService.ListarMoneda().Result.OrderBy(x => x.Valor).ToList();

            CopiaContratoFormulario modelo = new CopiaContratoFormulario(moneda);

            List<SelectListItem> listaUnidadOperativa = new List<SelectListItem>();
            //var listaUnidadOperativa = new List<SelectListItem>();
            listaUnidadOperativa.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaTodos });

            trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = entornoAplicacion.UsuarioSession }).Result.FirstOrDefault();

            if (trabajador != null)
            {
                if (trabajador.IndicadorTodaUnidadOperativa)
                {
                    var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto }).Result;
                    listaUnidadOperativa.AddRange(unidadOperativa.Select(item => new SelectListItem() { Value = item.CodigoUnidadOperativa.ToString(), Text = item.Nombre }).ToList());
                }
                else
                {
                    TrabajadorUnidadOperativaRequest trabajadaroUnidadOperativaRequest = new TrabajadorUnidadOperativaRequest();
                    trabajadaroUnidadOperativaRequest.CodigoUnidadOperativaMatriz = new Guid(trabajador.CodigoUnidadOperativaMatriz);
                    trabajadaroUnidadOperativaRequest.CodigoTrabajador = new Guid(trabajador.CodigoTrabajador);

                    var listaUnidadOperativaAsociadoTrabajador = trabajadorService.ListarTrabajadorUnidadOperativa(trabajadaroUnidadOperativaRequest).Result;
                    listaUnidadOperativa.AddRange(listaUnidadOperativaAsociadoTrabajador.Select(item => new SelectListItem() { Value = item.CodigoUnidadOperativa.ToString(), Text = item.NombreUnidadOperativa }).ToList());
                }
            }


            var tipoServicio = politicaService.ListarTipoContrato().Result.OrderBy(x => x.Valor).ToList();

            modelo.ListadoUnidadOperativa = listaUnidadOperativa;

            List<SelectListItem> listaTipoServicio = new List<SelectListItem>();
            listaTipoServicio.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaTodos });
            listaTipoServicio.AddRange(tipoServicio.Select(item => new SelectListItem() { Text = item.Valor.ToString(), Value = item.Codigo.ToString() }).ToList());
            modelo.TipoServicio = listaTipoServicio;

            modelo.Contrato.CodigoContrato = data.CodigoContrato;
            modelo.Contrato.NumeroContrato = (data.CodigoTipoDocumento == DatosConstantes.TipoDocumento.Adenda) ? data.NumeroAdendaConcatenado : data.NumeroContrato;
            modelo.Contrato.CodigoTipoDocumento = data.CodigoTipoDocumento;
            modelo.Contrato.CodigoTipoRequerimiento = data.CodigoTipoRequerimiento;
            modelo.Contrato.CodigoTipoServicio = data.CodigoTipoServicio;
            modelo.Contrato.CodigoUnidadOperativa = data.CodigoUnidadOperativa;
            modelo.Contrato.EsFlexible = data.EsFlexible;
            modelo.Contrato.IndicadorAdhesion = data.IndicadorAdhesion;
            modelo.Contrato.CodigoPlantilla = data.CodigoPlantilla;
            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra el Formulario de Contrato Párrafo
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato</param>
        /// <returns>Vista del formulario contrato párrafo</returns>
        public ActionResult FormularioContratoParrafo(string codigoContrato)
        {
            var esCopia = false;

            ContratoParrafoFormulario modelo;
            List<PlantillaParrafoResponse> listaPlantillaParrafo = new List<PlantillaParrafoResponse>();
            PlantillaParrafoRequest filtroPlantillaParrafo = new PlantillaParrafoRequest();
            PlantillaParrafoVariableRequest filtroPlantillaParrafoVariable = new PlantillaParrafoVariableRequest();
            List<PlantillaParrafoVariableResponse> listaPlantillaParrafoVariable = new List<PlantillaParrafoVariableResponse>();
            TrabajadorResponse primerFirmante = null;
            TrabajadorResponse segundoFirmante = null;

            var configuracionContrato = politicaService.ListaConfiguracionGeneracionContrato().Result;
            string intervaloAutoGuardado = string.Empty;
            if (configuracionContrato != null && configuracionContrato.Count > 0)
            {
                intervaloAutoGuardado = configuracionContrato.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.IntervaloTiempoAutoguardado).FirstOrDefault().Atributo3;
            }


            #region Obteniendo objeto contrato

            var contrato = contratoService.ObtieneRequerimientoPorID(new Guid(codigoContrato)).Result;
            //INICIO: Agregado por Julio Carrera -Norma Contable
            var plantilla = plantillaService.BuscarPlantilla(new PlantillaRequest() { CodigoPlantilla = contrato.CodigoPlantilla.ToString() }).Result.FirstOrDefault();
            Session["CodigoTipoRequerimiento"] = plantilla.EsMayorMenor;
            //Session["CodigoTipoRequerimiento"] = contrato.CodigoTipoRequerimiento;
            //TempData["CodigoTipoRequerimiento"] = contrato.CodigoTipoRequerimiento;
            //FIN: Agregado por Julio Carrera -Norma Contable
            var flujoActual = contrato.CodigoFlujoAprobacion;

            if (contrato.CodigoRequerimientoOriginal != null)
            {
                var parrafos = contratoService.RetornaParrafosPorRequerimiento(new Guid(codigoContrato));

                if (parrafos.Result.Count == 0)
                {
                    esCopia = true;
                    contrato = contratoService.ObtieneRequerimientoPorID((Guid)contrato.CodigoRequerimientoOriginal).Result;
                }
            }

            #endregion

            if (contrato != null)
            {
                //Obteniendo los representantes por defecto
                var listaRepFirmantesStracon = flujoAprobacionService.BuscarBandejaFlujoAprobacion(new FlujoAprobacionRequest() { CodigoFlujoAprobacion = flujoActual.ToString() }).Result;

                if (listaRepFirmantesStracon != null && listaRepFirmantesStracon.Count > 0)
                {
                    var empresaVinculada = contratoService.ObtenerEmpresaVinculadaPorProveedor(contrato.CodigoProveedor).Result;

                    if (string.IsNullOrEmpty(empresaVinculada.NombreEmpresa))
                    {
                        if (listaRepFirmantesStracon.FirstOrDefault().CodigoPrimerFirmante != null)
                        {
                            primerFirmante = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = Guid.Parse(listaRepFirmantesStracon.FirstOrDefault().CodigoPrimerFirmante) }).Result.FirstOrDefault();
                        }
                        if (listaRepFirmantesStracon.FirstOrDefault().CodigoSegundoFirmante != null)
                        {
                            segundoFirmante = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = Guid.Parse(listaRepFirmantesStracon.FirstOrDefault().CodigoSegundoFirmante) }).Result.FirstOrDefault();
                        }
                    }
                    else
                    {
                        if (listaRepFirmantesStracon.FirstOrDefault().CodigoPrimerFirmanteVinculada != null)
                        {
                            primerFirmante = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = Guid.Parse(listaRepFirmantesStracon.FirstOrDefault().CodigoPrimerFirmanteVinculada) }).Result.FirstOrDefault();
                        }
                        if (listaRepFirmantesStracon.FirstOrDefault().CodigoSegundoFirmanteVinculada != null)
                        {
                            segundoFirmante = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = Guid.Parse(listaRepFirmantesStracon.FirstOrDefault().CodigoSegundoFirmanteVinculada) }).Result.FirstOrDefault();
                        }
                    }

                }
            }

            //Generando listaValorPorDefecto
            var datoContrato = contratoService.BuscarListadoRequerimiento(new ListadoRequerimientoRequest()
            {
                CodigoRequerimiento = contrato.CodigoRequerimiento.ToString()
            }).Result.FirstOrDefault();

            var datoContratoCopia = new ListadoRequerimientoResponse();

            var monedaDescripcion = "";
            var monedaPoliticas = politicaService.ListarMoneda().Result.OrderBy(x => x.Valor).ToList();
            if (esCopia)
            {
                datoContratoCopia = contratoService.BuscarListadoRequerimiento(new ListadoRequerimientoRequest()
                {
                    CodigoRequerimiento = codigoContrato
                }).Result.FirstOrDefault();

                monedaDescripcion = monedaPoliticas.Find(p => p.Codigo.ToString() == datoContratoCopia.CodigoMoneda).Valor.ToString();
            }
            else
            {
                monedaDescripcion = monedaPoliticas.Find(p => p.Codigo.ToString() == datoContrato.CodigoMoneda).Valor.ToString();
            }

            var variablePorDefecto = new ValorPorDefectoRequest();
            variablePorDefecto.CodigoUnidadOperativa = datoContrato.CodigoUnidadOperativa.ToString();
            //variablePorDefecto.CodigoTipoServicio = datoContrato.CodigoTipoServicio.ToString();
            variablePorDefecto.CodigoTipoRequerimiento = datoContrato.CodigoTipoRequerimiento.ToString();
            variablePorDefecto.CodigoTipoDocumento = datoContrato.CodigoTipoDocumento.ToString();
            variablePorDefecto.CodigoContratoPrincipal = datoContrato.CodigoRequerimientoPrincipal.ToString();

            if (esCopia)
            {
                variablePorDefecto.RucProveedor = datoContratoCopia.NumeroDocumentoProveedor.ToString();
                variablePorDefecto.NombreProveedor = datoContratoCopia.NombreProveedor.ToString();
                variablePorDefecto.CodigoMoneda = datoContratoCopia.CodigoMoneda.ToString();
                variablePorDefecto.DescripcionMoneda = monedaDescripcion;
                variablePorDefecto.MontoContratoString = datoContratoCopia.MontoRequerimiento.ToString();
                variablePorDefecto.FechaInicioContrato = datoContratoCopia.FechaInicioVigencia;
                variablePorDefecto.FechaInicioContratoString = datoContratoCopia.FechaInicioVigenciaString;
                variablePorDefecto.FechaFinContrato = datoContratoCopia.FechaFinVigencia;
                variablePorDefecto.FechaFinContratoString = datoContratoCopia.FechaFinVigenciaString;
                variablePorDefecto.DescripcionContrato = datoContratoCopia.Descripcion;
            }
            else
            {
                variablePorDefecto.RucProveedor = datoContrato.NumeroDocumentoProveedor.ToString();
                variablePorDefecto.NombreProveedor = datoContrato.NombreProveedor.ToString();
                variablePorDefecto.CodigoMoneda = datoContrato.CodigoMoneda.ToString();
                variablePorDefecto.DescripcionMoneda = monedaDescripcion; //MLV           
                variablePorDefecto.MontoContratoString = datoContrato.MontoRequerimiento.ToString();
                variablePorDefecto.FechaInicioContrato = datoContrato.FechaInicioVigencia;
                variablePorDefecto.FechaInicioContratoString = datoContrato.FechaInicioVigenciaString;//MLV
                variablePorDefecto.FechaFinContrato = datoContrato.FechaFinVigencia;
                variablePorDefecto.FechaFinContratoString = datoContrato.FechaFinVigenciaString;//MLV
                variablePorDefecto.DescripcionContrato = datoContrato.Descripcion;
            }

            var plantillaFiltro = new PlantillaRequest();
            plantillaFiltro.CodigoEstadoVigencia = DatosConstantes.EstadoVigencia.Vigente;
            plantillaFiltro.IndicadorAdhesion = false;

            if (contrato != null)
            {
                plantillaFiltro.CodigoTipoContrato = contrato.CodigoDocAdj;
                plantillaFiltro.CodigoTipoDocumentoContrato = contrato.CodigoTipoDocumento;
            }

            var resultadoPlantilla = plantillaService.BuscarPlantilla(plantillaFiltro).Result.FirstOrDefault();

            if (resultadoPlantilla != null)
            {
                var resultadoPlantillaParrafo = plantillaService.BuscarPlantillaParrafo(new PlantillaParrafoRequest()
                {
                    CodigoPlantilla = resultadoPlantilla.CodigoPlantilla.ToString(),
                    IndicadorObtenerListaVariable = true
                }).Result.OrderBy(item => item.Orden);

                listaPlantillaParrafo = resultadoPlantillaParrafo.ToList();


                List<CodigoValorResponse> listaVariablePorDefecto = new List<CodigoValorResponse>();
                var etiquetaImagen = "<img name='imgCto' class='imgContratoParrafo' identificadorControl='{0}' src='{1}'>";

                UnidadOperativaResponse unidadOperativa = new UnidadOperativaResponse();
                unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = variablePorDefecto.CodigoUnidadOperativa }).Result.FirstOrDefault();

                if (unidadOperativa.CodigoUnidadOperativaPadre != null)
                {
                    unidadOperativa.UnidadOperativaPadre = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = unidadOperativa.CodigoUnidadOperativaPadre.ToString() }).Result.FirstOrDefault();

                    unidadOperativa.UnidadOperativaPadre.PrimerRepresentante = primerFirmante;

                    unidadOperativa.UnidadOperativaPadre.SegundoRepresentante = segundoFirmante;
                }

                //Obteniendo los valores de las variables de los párrafos
                var listaValoresVariablesParrafo = contratoService.ObtenerVariablesRequerimientoParrafo(contrato.CodigoRequerimiento.ToString()).Result;

                if (esCopia)
                {
                    //Mantener valores ingresados de copia de contrato

                    var ruc = listaValoresVariablesParrafo.Where(v => v.Identificador == DatosConstantes.IdentificadorVariableDefecto.RucProveedor).FirstOrDefault();

                    if (ruc != null)
                    {
                        ruc.ValorTexto = datoContratoCopia.NumeroDocumentoProveedor.ToString();
                    }

                    var nombreProveedor = listaValoresVariablesParrafo.Where(v => v.Identificador == DatosConstantes.IdentificadorVariableDefecto.NombreProveedor || v.Identificador == DatosConstantes.IdentificadorVariableDefecto.ProveedorNombre).FirstOrDefault();

                    if (nombreProveedor != null)
                    {
                        nombreProveedor.ValorTexto = datoContratoCopia.NombreProveedor.ToString();
                    }

                    var direccionProveedor = listaValoresVariablesParrafo.Where(v => v.Identificador == DatosConstantes.IdentificadorVariableDefecto.ProveedorDomicilio || v.Identificador == DatosConstantes.IdentificadorVariableDefecto.LocadorDomicilio).FirstOrDefault();

                    if (direccionProveedor != null)
                    {
                        direccionProveedor.ValorTexto = string.Empty;
                    }

                    var montoTotal = listaValoresVariablesParrafo.Where(v => v.Identificador == DatosConstantes.IdentificadorVariableDefecto.MontoContrato).FirstOrDefault();

                    if (montoTotal != null)
                    {
                        montoTotal.ValorTexto = datoContratoCopia.MontoRequerimiento.ToString();
                    }

                    var moneda = listaValoresVariablesParrafo.Where(v => v.Identificador == DatosConstantes.IdentificadorVariableDefecto.MonedaContrato).FirstOrDefault();

                    if (moneda != null && !string.IsNullOrEmpty(datoContratoCopia.DescripcionMoneda))
                    {
                        moneda.ValorTexto = datoContratoCopia.DescripcionMoneda;
                    }

                    var fechaInicio = listaValoresVariablesParrafo.Where(v => v.Identificador == DatosConstantes.IdentificadorVariableDefecto.FechaInicioContrato).FirstOrDefault();

                    if (fechaInicio != null)
                    {
                        fechaInicio.ValorFechaString = datoContratoCopia.FechaInicioVigenciaString;
                    }

                    var fechaFin = listaValoresVariablesParrafo.Where(v => v.Identificador == DatosConstantes.IdentificadorVariableDefecto.FechaFinContrato).FirstOrDefault();

                    if (fechaFin != null)
                    {
                        fechaFin.ValorFechaString = datoContratoCopia.FechaFinVigenciaString;
                    }

                    var fechaInicioVigencia = listaValoresVariablesParrafo.Where(v => v.Identificador == DatosConstantes.IdentificadorVariableDefecto.PlazoVigenciaDesde).FirstOrDefault();

                    if (fechaInicioVigencia != null)
                    {
                        fechaInicioVigencia.ValorFechaString = datoContratoCopia.FechaInicioVigenciaString;
                    }

                    var fechaFinVigencia = listaValoresVariablesParrafo.Where(v => v.Identificador == DatosConstantes.IdentificadorVariableDefecto.PlazoVigenciaHasta).FirstOrDefault();

                    if (fechaFinVigencia != null)
                    {
                        fechaFinVigencia.ValorFechaString = datoContratoCopia.FechaFinVigenciaString;
                    }
                    foreach (var item in listaValoresVariablesParrafo)
                    {
                        switch (item.Identificador)
                        {
                            case DatosConstantes.IdentificadorVariableDefecto.PlazoVigenciaDesde:
                            case DatosConstantes.IdentificadorVariableDefecto.FechaInicioContrato:
                                item.ValorFechaString = datoContratoCopia.FechaInicioVigenciaString;
                                break;
                            case DatosConstantes.IdentificadorVariableDefecto.PlazoVigenciaHasta:
                            case DatosConstantes.IdentificadorVariableDefecto.FechaFinContrato:
                                item.ValorFechaString = datoContratoCopia.FechaFinVigenciaString;
                                break;
                            case DatosConstantes.IdentificadorVariableDefecto.MonedaContrato:
                                item.ValorTexto = monedaDescripcion;
                                break;
                            case DatosConstantes.IdentificadorVariableDefecto.MontoContrato:
                                item.ValorTexto = datoContratoCopia.MontoRequerimiento.ToString();
                                break;
                        }
                    }
                }
                else
                {

                    var ruc = listaValoresVariablesParrafo.Where(v => v.Identificador == DatosConstantes.IdentificadorVariableDefecto.RucProveedor).FirstOrDefault();

                    if (ruc != null)
                    {
                        ruc.ValorTexto = datoContrato.NumeroDocumentoProveedor.ToString();
                    }

                    var nombreProveedor = listaValoresVariablesParrafo.Where(v => v.Identificador == DatosConstantes.IdentificadorVariableDefecto.NombreProveedor || v.Identificador == DatosConstantes.IdentificadorVariableDefecto.ProveedorNombre).FirstOrDefault();

                    if (nombreProveedor != null)
                    {
                        nombreProveedor.ValorTexto = datoContrato.NombreProveedor.ToString();
                    }

                    foreach (var item in listaValoresVariablesParrafo)
                    {
                        switch (item.Identificador)
                        {
                            case DatosConstantes.IdentificadorVariableDefecto.PlazoVigenciaDesde:
                            case DatosConstantes.IdentificadorVariableDefecto.FechaInicioContrato:
                                item.ValorFechaString = datoContrato.FechaInicioVigenciaString;
                                break;
                            case DatosConstantes.IdentificadorVariableDefecto.PlazoVigenciaHasta:
                            case DatosConstantes.IdentificadorVariableDefecto.FechaFinContrato:
                                item.ValorFechaString = datoContrato.FechaFinVigenciaString;
                                break;
                            case DatosConstantes.IdentificadorVariableDefecto.MonedaContrato:
                                item.ValorTexto = monedaDescripcion;
                                break;
                            case DatosConstantes.IdentificadorVariableDefecto.MontoContrato:
                                item.ValorTexto = datoContrato.MontoRequerimiento.ToString();
                                break;
                        }
                    }
                }

                foreach (var item in listaPlantillaParrafo)
                {
                    foreach (var variable in item.ListaPlantillaParrafoVariable)
                    {
                        variablePorDefecto.IdentificadorVariable = variable.IdentificadorVariable;
                        var contenido = listaPlantillaParrafo.Where(x => x.CodigoPlantillaParrafo == item.CodigoPlantillaParrafo).FirstOrDefault().Contenido;

                        if (variable.CodigoTipoVariable == DatosConstantes.TipoVariable.Imagen && listaValoresVariablesParrafo != null)
                        {
                            var valorVariableImagen = listaValoresVariablesParrafo.Where(p => p.CodigoVariable == variable.CodigoVariable).FirstOrDefault();
                            if (contrato.CodigoEstadoEdicion == DatosConstantes.CodigoEstadoEdicion.EdicionParcial && valorVariableImagen != null && valorVariableImagen.ValorImagen != null)
                            {
                                contenido = contenido.Replace(variablePorDefecto.IdentificadorVariable, string.Format(etiquetaImagen, item.CodigoPlantillaParrafo, "data:image/jpg;base64," + Convert.ToBase64String(valorVariableImagen.ValorImagen)));
                            }
                            else
                            {
                                contenido = contenido.Replace(variablePorDefecto.IdentificadorVariable, string.Format(etiquetaImagen, item.CodigoPlantillaParrafo, ""));
                            }
                        }
                        else if (variable.CodigoTipoVariable == DatosConstantes.TipoVariable.Lista && listaValoresVariablesParrafo != null)
                        {
                            variable.ListaOpcionesVariable = variableService.BuscarVariableLista(new VariableListaRequest() { CodigoVariable = variable.CodigoVariable.ToString() }).Result;
                        }

                        listaPlantillaParrafo.Where(x => x.CodigoPlantillaParrafo == item.CodigoPlantillaParrafo).FirstOrDefault().Contenido = contenido;

                        listaVariablePorDefecto.Add(new CodigoValorResponse { Codigo = variable.IdentificadorVariable, Valor = variableService.ObtenerValorDefecto(variablePorDefecto, unidadOperativa).Result });
                    }
                }


                modelo = new ContratoParrafoFormulario(listaPlantillaParrafo, listaPlantillaParrafoVariable, listaVariablePorDefecto, listaValoresVariablesParrafo, intervaloAutoGuardado);
                modelo.EsCopia = esCopia;
            }
            else
            {
                modelo = new ContratoParrafoFormulario();
                modelo.IndicadorExistePlantilla = false;
            }

            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra el Formulario Contrato Párrafo Tabla
        /// </summary>
        /// <param name="codigoVariable">Código de Variable</param>
        /// <returns>Vista del Formulario Contrato Párrafo Tabla</returns>
        public ActionResult FormularioContratoParrafoTabla(string codigoVariable)
        {
            ContratoParrafoTablaFormulario modelo;
            var variableCampo = variableService.BuscarVariableCampo(new VariableCampoRequest() { CodigoVariable = codigoVariable });
            modelo = new ContratoParrafoTablaFormulario(variableCampo.Result);
            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra el Formulario Contrato Párrafo Bien
        /// </summary>
        /// <returns>Vista del Formulario Contrato Párrafo Bien</returns>
        public ActionResult FormularioContratoParrafoBien()
        {
            ContratoParrafoBienFormulario modelo;
            var bien = bienService.ObtenerDescripcionCompletaBien(new BienRequest() { });
            modelo = new ContratoParrafoBienFormulario(bien.Result);


            List<SelectListItem> sliTipoTarifa = new List<SelectListItem>();
            List<SelectListItem> sliTipoPeriodo = new List<SelectListItem>();

            SelectListItem tipoTarifa;
            tipoTarifa = new SelectListItem();
            tipoTarifa.Value = "F";
            tipoTarifa.Text = "Fijo";
            sliTipoTarifa.Add(tipoTarifa);
            tipoTarifa = new SelectListItem();
            tipoTarifa.Value = "E";
            tipoTarifa.Text = "Escalonado";
            sliTipoTarifa.Add(tipoTarifa);

            modelo.lstTipoTarifa = sliTipoTarifa;
            modelo.lstPeriodoAlquiler = sliTipoTarifa;

            return PartialView(modelo);
        }

        public JsonResult ListarTipoPeriodos(string tipoTarifa)
        {
            var resultado = politicaService.ListaPeriodoAlquilerBien().Result;
            CodigoValorResponse codigovalor = new CodigoValorResponse();
            switch (tipoTarifa)
            {
                case "F":
                    //codigovalor.Codigo = "H";
                    //codigovalor.Valor = "Por Hora";
                    resultado.RemoveAt(3);
                    //resultado.RemoveAt(2);
                    //resultado.RemoveAt(0);
                    break;
                case "E":
                    resultado.RemoveAt(2);
                    resultado.RemoveAt(1);
                    resultado.RemoveAt(0);
                    
                    //codigovalor.Codigo = "D";
                    //codigovalor.Valor = "Por Día";
                    //resultado.Remove(codigovalor);
                    //codigovalor.Codigo = "M";
                    //codigovalor.Valor = "Por Mes";
                    //resultado.Remove(codigovalor);
                    //codigovalor.Codigo = "O";
                    //codigovalor.Valor = "Por hora";
                    //resultado.Remove(codigovalor);
                    break;
            }
            var jsonResult = Json(resultado, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        /// <summary>
        /// Muestra el Formulario Contrato Párrafo Firmante
        /// </summary>
        /// <returns>Vista del Formulario Contrato Párrafo Firmante</returns>
        public ActionResult FormularioContratoParrafoFirmante()
        {
            ContratoParrafoFirmanteFormulario modelo;
            var variable = variableService.BuscarVariable(new VariableRequest() { Identificador = DatosConstantes.TipoVariable.Firmante });
            modelo = new ContratoParrafoFirmanteFormulario(new Guid(variable.Result.FirstOrDefault().CodigoVariable.ToString()));
            return PartialView(modelo);
        }


        /// <summary>
        /// Muestra el formulario de Contrato Editar
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato</param>
        /// <returns>Vista del formulario Contrato</returns>
        public ActionResult FormularioContratoEditar(string codigoContrato)
        {
            string contenido = string.Empty, rptaAuto = string.Empty;
            if (codigoContrato == null)
            {
                codigoContrato = Guid.Empty.ToString();
            }
            var contrato = contratoService.RetornaRequerimientoPorId(new Guid(codigoContrato));
            var doctos = contratoService.DocumentosPorRequerimiento(new Guid(codigoContrato));
            if (doctos.Result != null && doctos.Result.Count > 0)
            {
                contenido = doctos.Result[0].Contenido;
            }
            if (contrato.Result != null)
            {
                rptaAuto = contrato.Result.RespuestaModificacion;
            }

            ContratoFormularioEditar modelo = new ContratoFormularioEditar();
            modelo.CodigoContrato = codigoContrato;
            modelo.Contenido = contenido;
            modelo.RespuestaAuto = rptaAuto;
            modelo.CodigoEstadoEdicion = contrato.Result.CodigoEstadoEdicion;

            return View(modelo);
        }

        /// <summary>
        /// Muestra el formulario de Contrato Párrafo Vista Previa
        /// </summary>
        /// <returns>Vista del formulario Contrato Párrafo Vista Previa</returns>
        public ActionResult FormularioContratoVistaPrevia(string codigoContrato, string contenido)
        {
            ContratoVistaPreviaFormulario modelo;

            ContratoDocumentoResponse contratoDocumento = new ContratoDocumentoResponse();
            contratoDocumento.Contenido = contenido;

            if (!string.IsNullOrWhiteSpace(codigoContrato))
            {
                modelo = null;
            }
            else
            {
                modelo = new ContratoVistaPreviaFormulario(contratoDocumento);
            }

            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra la Vista Previa del Documento contenido del Contrato, dependiendo de su versión.
        /// </summary>
        /// <param name="contenido">Contenido del Contrato</param>
        /// <param name="nombreDocumento"></param>
        /// <param name="codigoContrato"></param>
        /// <returns>Contenido del Contrato</returns>
        [ValidateInput(false)]
        public ActionResult GenerarVistaPreviaContrato(string contenido, string nombreDocumento, string codigoContrato)
        {
            List<TrabajadorResponse> listaFirmantes = null;
            RequerimientoResponse contrato = null;

            //Obteniendo objeto contrato}
            if (!string.IsNullOrEmpty(codigoContrato))
            {
                contrato = contratoService.ObtieneRequerimientoPorID(new Guid(codigoContrato)).Result;

                listaFirmantes = contratoService.ObtenerListaFirmantesStracon(contrato).Result;
            }

            nombreDocumento = string.Format("{0}.{1}", nombreDocumento, DatosConstantes.ArchivosContrato.ExtensionValidaCarga);
            contenido = contenido.Replace("$$", "\"");
            string lslinkCss = System.Web.HttpContext.Current.Server.MapPath("~/Theme/app/cssPdf.css");



            #region Cambio para Logo por Unidad Operativa
            var urlLogo = "";
            var entUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = contrato.CodigoUnidadOperativa.ToString() });

            if (entUnidadOperativa.Result[0].LogoUnidadOperativa == null)
            {

                urlLogo = politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.UrlLogoStracon).FirstOrDefault().Atributo3;
            }
            else
            {
                urlLogo = entUnidadOperativa.Result[0].LogoUnidadOperativa;
            }


            #endregion


            //var urlLogo = politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.UrlLogoStracon).FirstOrDefault().Atributo3;
            var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.WidthLogo).FirstOrDefault().Atributo3);
            var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.HeightLogo).FirstOrDefault().Atributo3);


            byte[] contenidoContrato = null;


            if (contrato.CodigoTipoDocumento == Pe.Stracon.SGC.Infraestructura.Core.Context.DatosConstantes.TipoDocumento.Contrato)
            {
                contenidoContrato = contratoService.GenerarPdfDesdeHtml(contenido,
                                                                        DatosConstantes.ContenidoPiePaginaContrato.EtiquetaCopiaNoOficial,
                                                                        (contrato != null ? contrato.NumeroRequerimiento : ""),
                                                                        (contrato != null ? contrato.CodigoRequerimiento : null),
                                                                        contrato.CodigoPlantilla,
                                                                        listaFirmantes,
                                                                        null,
                                                                        lslinkCss,
                                                                        false,
                                                                        urlLogo,
                                                                        widthLogo,
                                                                        heightLogo);
            }
            else
            {
                contenidoContrato = contratoService.GenerarPdfDesdeHtml(contenido, DatosConstantes.ContenidoPiePaginaContrato.EtiquetaCopiaNoOficial, (contrato != null ? contrato.NumeroAdendaConcatenado : ""), (contrato != null ? contrato.CodigoRequerimiento : null), contrato.CodigoPlantilla, listaFirmantes, null, lslinkCss, false, urlLogo, widthLogo, heightLogo);
            }

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

        /// <summary>
        /// Muestra el popup de búsqueda de Contratos principales
        /// </summary>
        /// <returns>Vista Parcial</returns>
        public ActionResult BuscarContratoPrincipal()
        {
            return PartialView();
        }

        /// <summary>
        /// Muestra el formulario de Contrato Editar
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato</param>
        /// <returns>Vista del formulario Contrato</returns>
        public ActionResult FormularioContratoFlexibleEditar(string codigoContrato)
        {
            string contenido = string.Empty, rptaAuto = string.Empty;
            if (codigoContrato == null)
            {
                codigoContrato = Guid.Empty.ToString();
            }
            var contrato = contratoService.RetornaRequerimientoPorId(new Guid(codigoContrato));
            var doctos = contratoService.DocumentosPorRequerimiento(new Guid(codigoContrato));
            if (doctos.Result != null && doctos.Result.Count > 0)
            {
                contenido = doctos.Result[0].Contenido;
            }


            if (contrato.Result != null)
            {
                rptaAuto = contrato.Result.RespuestaModificacion;
            }
            ViewBag.CodigoDeContrato = codigoContrato;
            ViewBag.Contenido = contenido;
            ViewBag.RespuestaAuto = rptaAuto;
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <returns></returns>
        public ActionResult FormularioContratoFlexibleCopiar(string codigoContrato)
        {
            string contenido = string.Empty, rptaAuto = string.Empty;
            if (codigoContrato == null)
            {
                codigoContrato = Guid.Empty.ToString();
            }
            var contrato = contratoService.RetornaRequerimientoPorId(new Guid(codigoContrato));
            var doctos = contratoService.DocumentosPorRequerimiento(new Guid(codigoContrato));
            if (doctos.Result != null && doctos.Result.Count > 0)
            {
                contenido = doctos.Result[0].Contenido;
            }


            if (contrato.Result != null)
            {
                rptaAuto = contrato.Result.RespuestaModificacion;
            }
            ViewBag.CodigoDeContrato = codigoContrato;
            ViewBag.Contenido = contenido;
            ViewBag.RespuestaAuto = rptaAuto;
            ViewBag.NumeroContrato = contrato.Result.NumeroRequerimiento;
            return PartialView();
        }
        /// <summary>
        /// Muestra el popup de para ingresar el motivo de eliminación del contrato
        /// </summary>
        /// <returns>Vista Parcial</returns>
        public ActionResult FormularioContratoEliminar(Guid codigoContrato)
        {
            ViewBag.codigoContrato = codigoContrato;
            return PartialView();
        }

        /// <summary>
        /// Muestra el popup de para ingresar el número de contrato para su búsqueda
        /// </summary>
        /// <returns>Vista Parcial</returns>
        public ActionResult BuscarNumeroContrato()
        {
            return PartialView();
        }

        #endregion

        #region Json
        /// <summary>
        /// Busca Contratos
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Lista de Contratos</returns>
        public JsonResult BuscarContrato(ListadoRequerimientoRequest filtro)
        {
            filtro.Trabajador = trabajador ?? trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = entornoAplicacion.UsuarioSession }).Result.FirstOrDefault();

            //var resultado = contratoService.BuscarListadoContrato(filtro);
            var resultado = contratoService.BuscarListadoRequerimientoOrden(filtro);
            var jsonResult = Json(resultado, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        /// <summary>
        /// Buscar Contrato por número
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Lista de Contratos</returns>
        public JsonResult BuscarContratoPorNumero(ListadoRequerimientoRequest filtro)
        {
            filtro.Trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = entornoAplicacion.UsuarioSession }).Result.FirstOrDefault();
            var resultado = contratoService.BuscarRequerimiento(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Busca los bienes con su descripción completa
        /// </summary>
        /// <param name="descripcion">Descripción del Bien</param>
        /// <returns>Lista de Bienes con descripción completa</returns>
        public JsonResult ObtenerDescripcionCompletaBien(string descripcion)
        {
            List<BienResponse> resultado = new List<BienResponse>();
            if (!string.IsNullOrEmpty(descripcion))
            {
                resultado = bienService.ObtenerDescripcionCompletaBien(new BienRequest() { Descripcion = descripcion }).Result;
            }
            var jsonResult = Json(resultado, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = Int32.MaxValue;
            return jsonResult;
        }

        /// <summary>
        /// Busca un Proveedor y si no existe lo registra
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Registro de Proveedor encontrado o registrado</returns>
        public JsonResult BuscarRegistrarProveedorContrato(ProveedorRequest filtro)
        {
            var resultado = proveedorService.BuscarRegistrarProveedorContrato(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Obtiene el Monto Acumulado del Contrato Principal más sus Adendas
        /// </summary>
        /// <param name="codigoContratoPrincipal">Código de Contrato Principal</param>
        /// <returns>Monto Acumulado del Contrato Principal más sus Adendas</returns>
        public JsonResult ObtenerMontoAcumuladoContrato(string codigoContratoPrincipal)
        {
            var resultado = contratoService.ObtenerMontoAcumuladoRequerimiento(codigoContratoPrincipal);
            return Json(resultado);
        }

        /// <summary>
        /// Obtiene el Símbolo en base a la Moneda
        /// </summary>
        /// <param name="codigoMoneda">Código de Moneda</param>
        /// <returns>Símbolo en base a la Moneda</returns>
        public JsonResult BuscarSimboloMoneda(string codigoMoneda)
        {
            var resultado = politicaService.ListarMonedaDinamico();
            resultado.Result = resultado.Result.Where(item => item.Atributo1 == codigoMoneda).ToList();
            return Json(resultado);
        }

        /// <summary>
        /// Obtiene el Monto Mínimo en base a la Moneda
        /// </summary>
        /// <param name="codigoMoneda">Código de Moneda</param>
        /// <returns>Monto Mínimo en base a la Moneda</returns>
        public JsonResult BuscarMontoMinimo(string codigoMoneda)
        {
            var resultado = politicaService.ListarMontoMinimoControlDinamico();
            resultado.Result = resultado.Result.Where(item => item.Atributo4 == codigoMoneda).ToList();
            return Json(resultado);
        }

        /// <summary>
        /// En base a la unidad operativa debe devolver la lista de Tipo de Servicio
        /// </summary>
        /// <param name="codigoUnidadOperativa"></param>
        /// <returns></returns>
        public JsonResult BuscarUnidadOperativa(string codigoUnidadOperativa)
        {
            Guid variable = new Guid(codigoUnidadOperativa);
            var lista_filtrada = contratoService.Obtener_Tipo_Requerimiento(variable);
            var lista_total = politicaService.ListarTipoContrato();

            //ProcessResult<object> resultado = new ProcessResult<object> {IsSuccess = true};
            lista_total.Result = lista_total.Result.Where(x => lista_filtrada.Contains(x.Codigo.ToString())).OrderBy(x => x.Valor).ToList();
            //resultado.Result = lista_total.Result;
            //resultado.Exception = null;

            return Json(""); //(resultado);
        }

        /// <summary>
        /// Obtiene el Tipo de Servicio
        /// </summary>
        /// <param name="codigoTipoContrato">Código de Tipo de Contrato</param>
        /// <returns>Tipo de Servicio</returns>
        public JsonResult BuscarTipoServicio(string codigoTipoContrato)
        {
            var resultado = politicaService.ListarTipoServicio(codigoTipoContrato);
            return Json(resultado);
        }

        /// <summary>
        /// Busca Plantillas y Flujos de aprobación
        /// </summary>
        /// <param name="plantilla">Filtro de Plantilla para búsqueda</param>
        /// <param name="flujoAprobacion">Filtro de Flujo de Aprobación para búsqueda</param>
        /// <param name="codigoMoneda">Codigo de moneda</param>
        /// <param name="montoContratoString">Monto Contrato</param>
        /// <param name="montoAcumuladoString">Monto Acumulado</param>
        /// <returns>Lista de Plantillas y Flujos de Aprobación</returns>
        public JsonResult BuscarPlantillaFlujoAprobacion(PlantillaRequest plantilla, FlujoAprobacionRequest flujoAprobacion, string codigoMoneda, string montoContratoString, string montoAcumuladoString)
        {
            //ProcessResult<object> resultado = new ProcessResult<object> {IsSuccess = true};
            PlantillaParrafoRequest plantillaParrafo = new PlantillaParrafoRequest();

            plantilla.CodigoEstadoVigencia = DatosConstantes.EstadoVigencia.Vigente;
            var resultadoPlantilla = plantillaService.BuscarPlantilla(plantilla).Result.FirstOrDefault();

            if (resultadoPlantilla != null)
            {
                plantillaParrafo.CodigoPlantilla = resultadoPlantilla.CodigoPlantilla.ToString();
            }
            var resultadoPlantillaParrafo = plantillaService.BuscarPlantillaParrafo(plantillaParrafo).Result;

            #region  Regla de Monto Minimo

            NumberFormatInfo numberFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = ","
            };

            #endregion

            decimal montoContrato = montoContratoString != "" ? Decimal.Parse(montoContratoString, numberFormatInfo) : 0;
            decimal montoAcumladoContratoSeleccionado = montoAcumuladoString != "" ? Decimal.Parse(montoAcumuladoString, numberFormatInfo) : 0;

            var montoMinimo = politicaService.ListarMontoMinimoControlDinamico().Result.Where(a => a.Atributo4 == codigoMoneda).FirstOrDefault();

            decimal valorMontoMinimo = montoMinimo != null ? Decimal.Parse(montoMinimo.Atributo3, numberFormatInfo) : 0;

            flujoAprobacion.IndicadorAplicaMontoMinimo = (montoContrato + montoAcumladoContratoSeleccionado) >= valorMontoMinimo;

            var resultadoFlujoAprobacion = flujoAprobacionService.BuscarBandejaFlujoAprobacion(flujoAprobacion).Result;

            if ((resultadoPlantilla == null) && (resultadoFlujoAprobacion == null || resultadoFlujoAprobacion.Count == 0))
            {
                //resultado.Result = "1";
            }
            else if (resultadoPlantilla == null)
            {
                //resultado.Result = "2";
            }
            else if (resultadoFlujoAprobacion == null || resultadoFlujoAprobacion.Count == 0)
            {
                //resultado.Result = "3";
            }
            else if (!resultadoPlantilla.IndicadorAdhesion && (resultadoPlantillaParrafo == null || resultadoPlantillaParrafo.Count == 0))
            {
                //resultado.Result = "4";
            }
            else if ((resultadoFlujoAprobacion != null || resultadoFlujoAprobacion.Count != 0))
            {
                //ProcessResult<List<FlujoAprobacionEstadioResponse>> listaFlujoEstadio = flujoAprobacionService.BuscarBandejaFlujoAprobacionEstadio(null, resultadoFlujoAprobacion[0].CodigoFlujoAprobacion, true);

                var count = 0;//listaFlujoEstadio.Result.Count(item => item.IndicadorVersionOficial == true);

                if (count == 0)
                {
                    //resultado.Result = "5";
                }
                else
                {
                    //resultado.Result = resultadoFlujoAprobacion;
                }
            }

            return Json(""); //(resultado);
        }

        /// <summary>
        /// Busca Lista de Párrafos
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Lista de Párrafo</returns>
        public JsonResult BuscarListaParrafo(PlantillaParrafoRequest filtro)
        {
            filtro.IndicadorObtenerListaVariable = true;
            var resultado = plantillaService.BuscarPlantillaParrafo(filtro);
            resultado.Result.OrderBy(x => x.Orden).ToList().ForEach(item => item.Contenido = null);
            return Json(resultado);
        }

        /// <summary>
        /// Registrar Contrato - Parrafos
        /// </summary>
        /// <param name="request">Datos de Contrato a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarContrato(RequerimientoRequest request)
        {
            var resultado = contratoService.RegistrarListadoRequerimiento(request);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Registrar Contrato General - Cabecera
        /// </summary>
        /// <param name="request">Datos de Contrato a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarContratoGeneral(RequerimientoRequest request)
        {
            var resultado = contratoService.RegistrarRequerimiento(request);
            return Json(resultado);
        }

        /// <summary>
        /// Registrar copia de contrato
        /// </summary>
        /// <param name="request">Datos del Contrato a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarCopiaContrato(RequerimientoRequest request)
        {
            var resultado = contratoService.RegistrarCopiaRequerimiento(request);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Busca Contratos principales
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Lista de Contratos principales</returns>
        public JsonResult ListarContratoPrincipal(ListadoRequerimientoRequest filtro)
        {
            var resultado = contratoService.ListadoRequerimientoPrincipal(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Registrar Respuesta del Autorizador para el Contrato.
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarRespuestaAutorizador(RequerimientoRequest objRqst)
        {
            var result = contratoService.RegistraRespuestaRequerimiento(objRqst);
            return Json(result);
        }

        /// <summary>
        /// Registrar Respuesta del Autorizador para el Contrato.
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarRespuestaGrabarAutorizador(RequerimientoRequest objRqst)
        {
            var result = contratoService.RegistrarRespuestaGrabarRequerimiento(objRqst);
            return Json(result);
        }

        /// <summary>
        /// Eliminar Contrato
        /// </summary>
        /// <param name="contrato">Datos de contrato a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        [AuthorizeEliminarFilter]
        public JsonResult EliminarContrato(ListadoRequerimientoRequest contrato)
        {
            var resultado = contratoService.EliminarRequerimiento(contrato);
            return Json(resultado);
        }

        /// <summary>
        /// Registra el documento como Adhesión
        /// </summary>
        /// <returns></returns>
        [AuthorizeEscrituraFilter]
        public JsonResult RegistrarContratoAdhesion()
        {
            HttpPostedFileBase file = Request.Files.Count > 0 ? Request.Files[0] : null;

            var codigoContrato = Request["CodigoContrato"].ToString();

            byte[] documentoContrato = null;
            using (MemoryStream ms = new MemoryStream())
            {
                file.InputStream.CopyTo(ms);
                documentoContrato = ms.ToArray();
            }

            var resultado = contratoService.RegistrarListadoRequerimientoAdhesion(new RequerimientoRequest()
            {
                CodigoRequerimiento = codigoContrato,
                RequerimientoDocumento = new RequerimientoDocumentoRequest()
                {
                    NombreArchivo = file.FileName,
                    Documento = documentoContrato
                }

            });
            return Json(resultado);
        }

        /// <summary>
        /// Permite la búsqueda de Trabajadores
        /// </summary>
        /// <param name="nombreTrabajador">Nombre de Trabajador</param>
        /// <returns>Lista con el resultado de la operación</returns>
        public JsonResult BuscarTrabajador(string nombreTrabajador)
        {
            TrabajadorRequest filtro = new TrabajadorRequest();
            filtro.NombreCompleto = nombreTrabajador;
            Pe.Stracon.Politicas.Aplicacion.Core.Base.ProcessResult<List<TrabajadorDatoMinimoResponse>> resultado = trabajadorService.BuscarTrabajadorDatoMinimo(filtro);            
            return Json(resultado.Result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarTrabajador1(string nombreTrabajador)
        {
            TrabajadorRequest filtro = new TrabajadorRequest();
            filtro.NombreCompleto = nombreTrabajador;
            Pe.Stracon.Politicas.Aplicacion.Core.Base.ProcessResult<List<TrabajadorDatoMinimoResponse>> resultado = trabajadorService.BuscarTrabajadorDatoMinimo(filtro);
            return Json(resultado.Result, JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// Método para recargar la grilla
        /// </summary>
        /// <param name="nombreProveedor">Filtro de Búsqueda</param>
        /// <returns>Lista de proveedores</returns>
        public JsonResult BuscarProveedorSAP(string nombreProveedor)
        {
            //ProveedorRequest filtro = new ProveedorRequest();
            //filtro.RucNombreProveedor = nombreProveedor;
            //var resultado = proveedorService.BuscarProveedorSAP(new ProveedorRequest() { RucNombreProveedor = filtro.RucNombreProveedor });
            //Pe.Stracon.SGC.Presentacion.Base.BuscadorProveedor.Actions.BuscarProveedorSAP
            ////var json = Json(resultado);
            ////json.MaxJsonLength = int.MaxValue;
            //return json;

            TrabajadorRequest filtro = new TrabajadorRequest();
            filtro.NombreCompleto = nombreProveedor;
                        Pe.Stracon.Politicas.Aplicacion.Core.Base.ProcessResult<List<TrabajadorDatoMinimoResponse>> resultado = trabajadorService.BuscarTrabajadorDatoMinimo(filtro);
            return Json(resultado.Result, JsonRequestBehavior.AllowGet);
        }




        #endregion
    }
}
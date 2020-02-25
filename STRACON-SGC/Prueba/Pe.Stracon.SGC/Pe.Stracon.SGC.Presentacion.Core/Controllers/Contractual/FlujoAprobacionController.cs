using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ActividadesGestionContractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.FlujoAprobacion;
using System.Web.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Cross.Core.Util;
using Pe.GyM.Security.Web.Session;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    public class FlujoAprobacionController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Servicio de manejo de Unidad Operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }

        /// <summary>
        /// Servicio Flujo Aprobacion
        /// </summary>
        public IFlujoAprobacionService flujoAprobacionService { get; set; }
        /// <summary>
        /// Servicio de trabajador
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }

        /// <summary>
        /// Servicio de Contrato
        /// </summary>
        public IContratoService contratoService { get; set; }

        /// <summary>
        /// Servicio de Variable
        /// </summary>
        public IVariableService variableService { get; set; }

        #endregion

        #region Vistas
        /// /// <summary>
        /// Muestra la Vista Principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
                       
            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = "03" });

            //CRG: Cambio flujo de aprobación por tipo de contrato
            var tipoServicio = politicaService.ListarTipoContrato().Result.OrderBy(item => item.Valor).ToList();
            var modelo = new FlujoAprobacionBusqueda(unidadOperativa.Result, tipoServicio);

            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/FlujoAprobacion");
                
            return View(modelo);
        }

        /// <summary>
        /// Muestra la Vista Estadios
        /// </summary>
        /// <returns>Vista Estadio</returns>
        public ActionResult Estadios(string id)
        {
            var resultado = flujoAprobacionService.BuscarBandejaFlujoAprobacion(new FlujoAprobacionRequest()
            {
                CodigoFlujoAprobacion = id,
                IndicadorObtenerDescripcion = true
            });

            var estadio = resultado.Result.FirstOrDefault();

            FlujoAprobacionEstadiosBusqueda modelo = new FlujoAprobacionEstadiosBusqueda(estadio);
            return View(modelo);
        }
        #endregion

        #region Vistas Parciales
        /// <summary>
        /// Muestra la vista Formulario Flujo Aprobacion 
        /// </summary>
        /// <returns>Vista Formulario Flujo Aprobación</returns>
        public ActionResult FormularioFlujoAprobacion(string codigoFlujoAprobacion)
        {
            
            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = "03" }).Result;

            //CRG: Cambio flujo de aprobación por tipo de contrato
            var tipoServicio = politicaService.ListarTipoContrato().Result;

            FlujoAprobacionFormulario modelo = new FlujoAprobacionFormulario();
            
            if (!string.IsNullOrWhiteSpace(codigoFlujoAprobacion))
            {
                var flujoAprobacion = flujoAprobacionService.BuscarBandejaFlujoAprobacion(new FlujoAprobacionRequest()
                {
                    CodigoFlujoAprobacion = codigoFlujoAprobacion
                }).Result.FirstOrDefault();

                if (flujoAprobacion != null)
                {
                    var primerFirmante = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = new Guid(flujoAprobacion.CodigoPrimerFirmante) }).Result;
                    var segundoFirmante = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = new Guid(flujoAprobacion.CodigoSegundoFirmante) }).Result;

                    flujoAprobacion.ListaPrimerFirmante = primerFirmante.ToDictionary(x => x.CodigoTrabajador, y => y.NombreCompleto);
                    flujoAprobacion.ListaSegundoFirmante = segundoFirmante.ToDictionary(x => x.CodigoTrabajador, y => y.NombreCompleto);

                    if (flujoAprobacion.CodigoPrimerFirmanteVinculada != null)
                    {
                        var primerFirmanteVinculada = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = new Guid(flujoAprobacion.CodigoPrimerFirmanteVinculada) }).Result;
                        flujoAprobacion.ListaPrimerFirmanteVinculada = primerFirmanteVinculada.ToDictionary(x => x.CodigoTrabajador, y => y.NombreCompleto);
                    }

                    if (flujoAprobacion.CodigoSegundoFirmanteVinculada != null)
                    {
                        var segundoFirmanteVinculada = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = new Guid(flujoAprobacion.CodigoSegundoFirmanteVinculada) }).Result;
                        flujoAprobacion.ListaSegundoFirmanteVinculada = segundoFirmanteVinculada.ToDictionary(x => x.CodigoTrabajador, y => y.NombreCompleto);
                    }

                    modelo = new FlujoAprobacionFormulario(unidadOperativa, tipoServicio, flujoAprobacion);
                }               
            }
            else
            {
                modelo = new FlujoAprobacionFormulario(unidadOperativa, tipoServicio);
            }
                
            return PartialView(modelo);
        }
        /// <summary>
        /// Muestra la vista Formulario Copiar Estadio
        /// </summary>
        /// <returns>Vista Formulario Copiar Estadio</returns>
        public ActionResult FormularioCopiarEstadio(string codigoFlujoAprobacion)
        {
            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = "03" });
            var tipoServicio = politicaService.ListarTipoContrato();
            var tipoRequerimiento = politicaService.ListarTipoServicio();
            var tipoContrato = politicaService.ListarFormaContrato();

            var flujoAprobacion = flujoAprobacionService.BuscarBandejaFlujoAprobacion(new FlujoAprobacionRequest()
            {
                CodigoFlujoAprobacion = codigoFlujoAprobacion
            });



            FlujoAprobacionFormularioCopiarEstadio modelo = new FlujoAprobacionFormularioCopiarEstadio(unidadOperativa.Result, tipoServicio.Result, tipoRequerimiento.Result, tipoContrato.Result, flujoAprobacion.Result.FirstOrDefault());

            return PartialView(modelo);
        }
        /// <summary>
        /// Muestra la vista Formulario Flujo Aprobacion Estadios
        /// </summary>
        /// <returns>Vista Formulario Flujo Aprobación Estadio</returns>
        public ActionResult FormularioFlujoAprobacionEstadios(string codigoFlujoAprobacionEstadio)
        {
            FlujoAprobacionEstadiosFormulario modelo = new FlujoAprobacionEstadiosFormulario();
            //editar
            if (!string.IsNullOrWhiteSpace(codigoFlujoAprobacionEstadio))
            {
                var resultadoFlujoAprobacionEstadio = flujoAprobacionService.BuscarBandejaFlujoAprobacionEstadio(codigoFlujoAprobacionEstadio, null, true);

                var flujoAprobacionEstadio = resultadoFlujoAprobacionEstadio.Result.FirstOrDefault();

                if (flujoAprobacionEstadio != null)
                {
                    modelo = new FlujoAprobacionEstadiosFormulario(flujoAprobacionEstadio);
                }    
            }            
            return PartialView(modelo);
        }

        #endregion

        #region Json
        /// <summary>
        /// Busca Bandeja Flujo Aprobacion
        /// </summary>
        /// <returns>Lista con el resultado de la operación</returns>
        public JsonResult BuscarBandejaFlujoAprobacion(FlujoAprobacionRequest filtro)
        {
            filtro.IndicadorObtenerDescripcion = true;

            var resultado = flujoAprobacionService.BuscarBandejaFlujoAprobacion(filtro);

            return Json(resultado);
        }
        /// <summary>
        /// Eliminar Flujo Aprobacion
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        public JsonResult EliminarFlujoAprobacion(List<Object> listaCodigoFlujoAprobacion)
        {
            var resultado = flujoAprobacionService.EliminarFlujoAprobacion(listaCodigoFlujoAprobacion);
            return Json(resultado);
        }
        /// <summary>
        /// Registrar Flujo Aprobacion
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        public JsonResult RegistrarFlujoAprobacion(FlujoAprobacionRequest data)
        {
            var resultado = flujoAprobacionService.RegistrarFlujoAprobacion(data);
            return Json(resultado);
        }

        /// <summary>
        /// Buscar Bandeja Flujo Aprobacion Estadios
        /// </summary>
        /// <returns>Lista con el resultado de la operación</returns>
        public JsonResult BuscarBandejaFlujoAprobacionEstadios(string codigoFlujoAprobacionEstadio, string codigoFlujoAprobacion)
        {
            var resultado = flujoAprobacionService.BuscarBandejaFlujoAprobacionEstadio(codigoFlujoAprobacionEstadio, codigoFlujoAprobacion, true);
            return Json(resultado);
        }

        /// <summary>
        /// Eliminar Flujo Aprobacion Estadios
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        public JsonResult EliminarFlujoAprobacionEstadios(List<Object> listaCodigoFlujoAprobacionEstadio)
        {
            var resultado = flujoAprobacionService.EliminarFlujoAprobacionEstadio(listaCodigoFlujoAprobacionEstadio);
            return Json(resultado);
        }

        /// <summary>
        /// Registrar Flujo Aprobacion Estadios
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        public JsonResult RegistrarFlujoAprobacionEstadios(FlujoAprobacionEstadioRequest data, List<FlujoAprobacionEstadioRequest> responsable, List<FlujoAprobacionEstadioRequest> informados, List<FlujoAprobacionEstadioRequest> responsableVinculadas)
        {
            if (informados == null) 
                informados = new List<FlujoAprobacionEstadioRequest>();

            if (responsableVinculadas == null)
                responsableVinculadas = new List<FlujoAprobacionEstadioRequest>();

            var resultado = flujoAprobacionService.RegistrarFlujoAprobacionEstadio(data, responsable, informados, responsableVinculadas);
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

        ///// <summary>
        ///// Copia Estadio
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns>Indicador con el resultado de la operación</returns>
        //public JsonResult CopiarEstadio(FlujoAprobacionRequest data)
        //{
        //    var resultado = flujoAprobacionService.CopiarEstadio(data);
        //    return Json(resultado);
        //}
        #endregion
    }
}
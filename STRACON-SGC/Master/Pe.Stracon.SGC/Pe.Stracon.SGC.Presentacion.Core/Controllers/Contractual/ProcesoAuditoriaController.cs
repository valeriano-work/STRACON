using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ActividadesGestionContractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ProcesoAuditoria;
using System.Web.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using Pe.Stracon.SGC.Cross.Core.Util;
using Pe.GyM.Security.Web.Session;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    public class ProcesoAuditoriaController : GenericController
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

        #endregion

        #region Vistas
        /// /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = "03" });
            var modelo = new ProcesoAuditoriaBusqueda(unidadOperativa.Result);

            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/ProcesoAuditoria/");

            return View(modelo);
        }
        /// <summary>
        /// Servicio Proceso Auditoria
        /// </summary>
        public IProcesoAuditoriaService procesoAuditoriaService { get; set; }
        #endregion

        #region Vistas Parciales
        /// <summary>
        /// Muestra Formulario Proceso Auditoria
        /// </summary>
        /// <returns>Vista Parcial Formulario Proceso Auditoria</returns>
        public ActionResult FormularioProcesoAuditoria(string codigoAuditoria)
        {
            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = "03" });
            var modelo = new ProcesoAuditoriaFormulario();

            if (!string.IsNullOrWhiteSpace(codigoAuditoria))
            {
                var resultadoProcesoAuditoria = procesoAuditoriaService.BuscarBandejaProcesoAuditoria(new ProcesoAuditoriaRequest()
                {
                    CodigoAuditoria = codigoAuditoria
                });

                var procesoAuditoria = resultadoProcesoAuditoria.Result.FirstOrDefault();

                if (procesoAuditoria != null)
                {
                    modelo = new ProcesoAuditoriaFormulario(unidadOperativa.Result, procesoAuditoria);
                }    
            }
            else
            {
                modelo = new ProcesoAuditoriaFormulario(unidadOperativa.Result);
            }

            return PartialView(modelo);
        }
        #endregion

        #region Json
        /// <summary>
        /// Busca Bandeja Proceso Auditoria
        /// </summary>
        /// <returns>Lista con el resultado de la operación</returns>
        public JsonResult BuscarBandejaProcesoAuditoria(ProcesoAuditoriaRequest filtro)
        {
            var resultado = procesoAuditoriaService.BuscarBandejaProcesoAuditoria(filtro);
            return Json(resultado);
        }
        /// <summary>
        /// Eliminar Proceso Auditoria
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        public JsonResult EliminarProcesoAuditoria(List<Object> listaCodigosAuditoria)
        {
            var resultado = procesoAuditoriaService.EliminarProcesoAuditoria(listaCodigosAuditoria);
            return Json(resultado);
        }
        /// <summary>
        /// Registrar Proceso Auditoria
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        public JsonResult RegistrarProcesoAuditoria(ProcesoAuditoriaRequest data)
        {
            var resultado = procesoAuditoriaService.RegistrarProcesoAuditoria(data);
            return Json(resultado);
        }
        #endregion
    }
}
using Pe.GyM.Security.Account.SRASecurityService;
using Pe.GyM.Security.Web.Session;
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Cross.Core.Base;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;
using Pe.Stracon.Politicas.Presentacion.Core.Controllers.Base;
using Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.Trabajador;
using Pe.Stracon.Politicas.Presentacion.Recursos.Base;
using Pe.Stracon.Politicas.Presentacion.Recursos.Mensajes;
using Pe.Stracon.PoliticasCross.Core.Exception;
using Pe.Stracon.PoliticasCross.Core.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Core.Controllers.General
{
    /// <summary>
    /// Controladora de Unidad Operativa
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:
    /// </remarks>
    public class TrabajadorController : GenericController
    {
        #region Atributos
        /// <summary>
        /// Servicio de manejo de trabajadores.
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }
        /// <summary>
        /// Servicio de manejo de políticas.
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Servicio de manejo de unidad operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }
        /// <summary>
        /// Interface para obtener el entorno de la aplicación.
        /// </summary>
        public IEntornoActualAplicacion entornoAplicacion { get; set; }
        #endregion Atributos

        #region Vistas
        /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var identificacion = politicaService.ListarTipoDocumentoIdentidad();
            TrabajadorModel modelo = new TrabajadorModel(identificacion.Result, true);

            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/General/Trabajador/");

            return View(modelo);
        }
        #endregion Vistas

        #region Vistas Parciales
        /// <summary>
        /// Muestra el formulario de datos
        /// </summary>
        /// <param name="CodigoTrabajador">Código de trabajador</param>
        /// <returns>Vista FormularioTrabajador</returns>
        public ActionResult FormularioTrabajador(string CodigoTrabajador)
        {
            TrabajadorModel modelo;
            var identificacion = politicaService.ListarTipoDocumentoIdentidad();

            if (!string.IsNullOrWhiteSpace(CodigoTrabajador))
            {
                var resultadoTrabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest()
                {
                    CodigoTrabajador = new Guid(CodigoTrabajador)
                });

                var trabajador = resultadoTrabajador.Result.FirstOrDefault();

                if (trabajador != null)
                {
                    modelo = new TrabajadorModel(identificacion.Result, trabajador);
                }
                else
                {
                    modelo = new TrabajadorModel(identificacion.Result, false);
                }
            }
            else
            {
                modelo = new TrabajadorModel(identificacion.Result, false);
            }
            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra el formulario de trabajador unidad operativa
        /// </summary>
        /// <param name="codigoTrabajador">Código de trabajador</param>
        /// <returns>Vista FormularioTrabajador</returns>
        public ActionResult FormularioTrabajadorUnidadOperativa(string codigoTrabajador)
        {
            var unidadOperativaMatriz = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.EmpresaMatriz }).Result;
            var trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = new Guid(codigoTrabajador) }).Result.First();
            var modelo = new TrabajadorUnidadOperativaModel(trabajador, unidadOperativaMatriz);

            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra el formulario de trabajador unidad operativa
        /// </summary>
        /// <param name="codigoTrabajador">Código de trabajador</param>
        /// <returns>Vista FormularioTrabajador</returns>
        public ActionResult FormularioTrabajadorSuplente(string codigoTrabajador)
        {

            var trabajadorSuplente = trabajadorService.BuscarTrabajadorSuplente(new TrabajadorRequest() { CodigoTrabajador = new Guid(codigoTrabajador) }).Result.FirstOrDefault();

            var trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = new Guid(codigoTrabajador) }).Result.FirstOrDefault();

            TrabajadorSuplenteModel modelo = new TrabajadorSuplenteModel(trabajador);

            if (trabajadorSuplente != null)
            {
                var trabajadorSuplenteDefinicion = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = trabajadorSuplente.CodigoSuplente }).Result;

                trabajadorSuplente.ListaSuplente = trabajadorSuplenteDefinicion.ToDictionary(x => x.CodigoTrabajador, y => y.NombreCompleto);

                modelo = new TrabajadorSuplenteModel(trabajadorSuplente, trabajador);
            }

            return PartialView(modelo);
        }
        #endregion Vistas Parciales

        #region Json
        /// <summary>
        /// Permite buscar el trabajador
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <returns>Retorna el trabajador</returns>
        public JsonResult Buscar(TrabajadorRequest filtro)
        {
            var resultado = trabajadorService.BuscarTrabajador(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Permite buscar el trabajador
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Retorna el trabajador</returns>
        public JsonResult BuscarTrabajadorUnidadOperativa(TrabajadorUnidadOperativaRequest filtro)
        {
            var resultado = trabajadorService.ListarTrabajadorUnidadOperativa(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Permite registrar el trabajador
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <returns>Resultado de la operación</returns>
        public JsonResult Registrar(TrabajadorRequest filtro)
        {
            var resultado = trabajadorService.RegistrarTrabajador(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Permite registrar el trabajador
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <returns>Resultado de la operación</returns>
        public JsonResult RegistrarTrabajadorUnidadOperativa(TrabajadorRequest filtro)
        {
            var resultado = trabajadorService.RegistrarTrabajadorUnidadOperativa(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Permite registrar el trabajador
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <returns>Resultado de la operación</returns>
        public JsonResult RegistrarTrabajadorSuplente(TrabajadorSuplenteRequest filtro)
        {
            filtro.UsuarioSession = entornoAplicacion.UsuarioSession;
            filtro.Terminal       = entornoAplicacion.Terminal;

            var resultado = trabajadorService.RegistrarTrabajadorSuplente(filtro);

            return Json(resultado);
        }

        /// <summary>
        /// Permite registrar validar
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <returns>Resultado de la operación</returns>
        public JsonResult RegistrarValidar(TrabajadorRequest filtro)
        {
            var resultado = new ProcessResult<TrabajadorRequest>();
            try
            {
                var validacion = trabajadorService.BuscarTrabajador(new TrabajadorRequest { CodigoIdentificacion = filtro.CodigoIdentificacion, Dominio = filtro.Dominio });
                if (validacion.Result.Count > 0)
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<TrabajadorController>(UsuarioAD.EtiquetaTrabajadorExiste);
                }
                else
                {
                    resultado = trabajadorService.RegistrarTrabajador(filtro);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorController>(e);
            }
            return Json(resultado);
        }

        /// <summary>
        /// Permite cargar la firma del trabajador
        /// </summary>
        /// <returns>Resultado de la operación</returns>
        public JsonResult CargarFirmaTrabajador()
        {
            var resultado = new ProcessResult<TrabajadorResponse>();
            HttpPostedFileBase file = Request.Files.Count > 0 ? Request.Files[0] : null;
            if (file.ContentLength > 0)
            {
                try
                {
                    BinaryReader reader = new BinaryReader(file.InputStream);
                    byte[] firma = reader.ReadBytes((int)file.InputStream.Length);
                    var codigoTrabajador = new Guid(Request["CodigoTrabajador"].ToString());
                    Guid codigoFirma = Guid.Empty;
                    if(!string.IsNullOrWhiteSpace(Request["CodigoFirma"].ToString())){
                        codigoFirma = new Guid(Request["CodigoFirma"].ToString());
                    }
                    resultado = trabajadorService.RegistrarFirmaTrabajador(new TrabajadorRequest {
                        CodigoFirma = codigoFirma, 
                        CodigoTrabajador = codigoTrabajador, 
                        Firma = firma 
                    });
                }
                catch (Exception)
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<TrabajadorController>(MensajeResource.ExistenciaRegistro);
                }
            }
            else
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorController>(MensajeResource.ExistenciaRegistro);
            }
            return Json(resultado);
        }
        /// <summary>
        /// Permite ver la firma del trabajador
        /// </summary>
        /// <param name="codigoTrabajador">Código de Firma</param>
        /// <returns>Retorna el trabajador con su firma</returns>
        public JsonResult VerFirmaTrabajador(string codigoTrabajador)
        {
            var resultado = trabajadorService.BuscarFirmaTrabajador(new TrabajadorRequest() { CodigoTrabajador = new Guid(codigoTrabajador) });
            return Json(resultado);
        }

        /// <summary>
        /// Acción para la eliminación de trabajadores.
        /// </summary>
        /// <param name="listaTrabajadores">Lista de trabajadores</param>
        /// <returns>Resultado de la operación</returns>
        public JsonResult Eliminar(List<TrabajadorRequest> listaTrabajadores)
        {
            var resultado = trabajadorService.EliminarTrabajador(listaTrabajadores);
            return Json(resultado);
        }

        /// <summary>
        /// Elimina un proyecto asociado a un trabajador
        /// </summary>
        /// <param name="codigoTrabajadorUnidadOperativa">Código de trabajador unidad operativa</param>
        /// <returns>Resultado del registro</returns>
        public JsonResult EliminarTrabajadorUnidadOperativa(string codigoTrabajadorUnidadOperativa)
        {
            var resultado = trabajadorService.EliminarTrabajadorUnidadOperativa(new Guid(codigoTrabajadorUnidadOperativa));
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
        /// Busca las Unidades Operativas de Nivel Proyecto
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista con el resultado de la operación</returns>
        public JsonResult BuscarUnidadOperativaProyectoPorEmpresaMatriz(FiltroUnidadOperativa filtro)
        {
            ProcessResult<List<UnidadOperativaResponse>> resultado = unidadOperativaService.BuscarUnidadOperativaProyectoPorEmpresaMatriz(filtro);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        #endregion Json
    }
}
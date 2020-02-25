using Pe.GyM.Security.Web.Session;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;
using Pe.Stracon.Politicas.Presentacion.Core.Controllers.Base;
using Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.UnidadOperativa;
using Pe.Stracon.PoliticasCross.Core.Util;
using System.Collections.Generic;
using System.Linq;
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
    public class UnidadOperativaController : GenericController
    {
        /// <summary>
        /// Servicio para el manejo de Unidades Operativas
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary>
        public IParametroValorService parametroValorService { get; set; }
        /// <summary>
        /// Servicio de manejo de políticas
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Serviciop para el manejo de Trabajadores
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }

        #region Vistas
        /// <summary>
        /// Muestra la vista principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index(string tipo)
        {
            var niveles = politicaService.ListarNivelUnidadOperativa();

            var modelo = new UnidadOperativaBusqueda(niveles.Result, tipo);

            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "General/UnidadOperativa?tipo=REPDIR");
                      
            var cuenta = HttpGyMSessionContext.CurrentAccount();
            string codigoSistema = cuenta != null ? cuenta.CodigoSistema : string.Empty;
            
            modelo.EsScc = codigoSistema.Equals(DatosConstantes.Sistema.CodigoSCC) ? true : false;
                       
            return View(modelo);
        }
        #endregion

        #region Vistas Parciales

        /// <summary>
        /// Muestra el formulario de datos
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de unidad operativa</param>
        /// <param name="tipo">Tipo de Visualización</param>
        /// <returns>Vista del Formulario de Unidad Operativa</returns>
        public ActionResult FormularioUnidadOperativa(string codigoUnidadOperativa, string tipo)
        {
            UnidadOperativaFormulario modelo;
            var niveles = politicaService.ListarNivelUnidadOperativa();

            if (!string.IsNullOrWhiteSpace(codigoUnidadOperativa))
            {
                var resultadoUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = codigoUnidadOperativa });

                var unidadOperativa = resultadoUnidadOperativa.Result.FirstOrDefault();

                if (unidadOperativa != null)
                {
                    if (unidadOperativa.CodigoResponsable != null)
                    {
                        var resultadoTrabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = unidadOperativa.CodigoResponsable });
                        unidadOperativa.Responsable = resultadoTrabajador.Result.FirstOrDefault();
                    }
                    if (unidadOperativa.CodigoPrimerRepresentante != null)
                    {
                        var resultadoTrabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = unidadOperativa.CodigoPrimerRepresentante });
                        unidadOperativa.PrimerRepresentante = resultadoTrabajador.Result.FirstOrDefault();
                    }
                    if (unidadOperativa.CodigoSegundoRepresentante != null)
                    {
                        var resultadoTrabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = unidadOperativa.CodigoSegundoRepresentante });
                        unidadOperativa.SegundoRepresentante = resultadoTrabajador.Result.FirstOrDefault();
                    }
                    if (unidadOperativa.CodigoTercerRepresentante != null)
                    {
                        var resultadoTrabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = unidadOperativa.CodigoTercerRepresentante });
                        unidadOperativa.TercerRepresentante = resultadoTrabajador.Result.FirstOrDefault();
                    }
                    if (unidadOperativa.CodigoCuartoRepresentante != null)
                    {
                        var resultadoTrabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = unidadOperativa.CodigoCuartoRepresentante });
                        unidadOperativa.CuartoRepresentante = resultadoTrabajador.Result.FirstOrDefault();
                    }
                    var resultadoUnidadSuperior = unidadOperativaService.BuscarUnidadOperativaNivelSuperior(unidadOperativa.CodigoNivelJerarquia);
                    var resultadoTipo = politicaService.BuscarTipoUnidadOperativaPorCodigoNivel(unidadOperativa.CodigoNivelJerarquia);
                    modelo = new UnidadOperativaFormulario(niveles.Result, resultadoUnidadSuperior.Result, resultadoTipo.Result, unidadOperativa, tipo);
                }
                else
                {
                    modelo = new UnidadOperativaFormulario(niveles.Result, tipo);
                }
            }
            else
            {
                modelo = new UnidadOperativaFormulario(niveles.Result, tipo);
            }

            return PartialView(modelo);
        }

        /// <summary>
        /// Mostrar vista Asignar staff
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de unidad operativa</param>
        /// <returns>Mostrar asignar staff</returns>
        public ActionResult FormularioUnidadOperativaStaff(string codigoUnidadOperativa)
        {
            var listaSistema = new List<SelectListItem>();

            listaSistema.Add(new SelectListItem()
            {
                Text = "Sistema de Gestión Contractual",
                Value = DatosConstantes.Sistema.CodigoSGC,
                Selected = false
            });

            UnidadOperativaStaffFormulario modelo = new UnidadOperativaStaffFormulario(listaSistema);

            return PartialView(modelo);
        }

        /// <summary>
        /// Mostrar vista Asignar responsable
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de unidad operativa</param>
        /// <returns>Mostrar asignar responsable</returns>
        public ActionResult FormularioAsignarResponsable(string codigoUnidadOperativa)
        {    
            return PartialView();        
        }

        #endregion

        #region Json

        /// <summary>
        /// Permite buscar el trabajador
        /// </summary>
        /// <param name="filtro">Filtro de  unidad operativa</param>
        /// <returns>Retorna la unidad operativa</returns>
        public JsonResult Buscar(FiltroUnidadOperativa filtro)
        {
            var resultado = unidadOperativaService.BuscarUnidadOperativa(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Permite buscar el nivel de superior
        /// </summary>
        /// <param name="codigoNivel">Código de nivel</param>
        /// <returns>Resultado de la operación</returns>
        public JsonResult BuscarNivelSuperior(string codigoNivel)
        {
            var resultado = unidadOperativaService.BuscarUnidadOperativaNivelSuperior(codigoNivel);
            return Json(resultado);
        }

        /// <summary>
        /// Permite buscar el tipo de unidad operativa
        /// </summary>
        /// <param name="codigoNivel"></param>
        /// <returns>Resultado de la operación</returns>
        public JsonResult BuscarTipoUnidadOperativa(string codigoNivel)
        {
            var resultado = politicaService.BuscarTipoUnidadOperativaPorCodigoNivel(codigoNivel);

            return Json(resultado);
        }

        /// <summary>
        /// Permite registrar
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Resultado de la operación</returns>
        public JsonResult Registrar(DataUnidadOperativaRequest data)
        {
            var resultado = unidadOperativaService.RegistrarUnidadOperativa(data);
            return Json(resultado);
        }

        /// <summary>
        /// Método para eliminar Unidades Operativas
        /// </summary>
        /// <param name="listaCodigos">Lista de Códigos de Unidades Operativas</param>
        /// <returns>Resultado de la Operación</returns>
        public JsonResult EliminarUnidadOperativa(List<string> listaCodigos) 
        {
            var resultado = unidadOperativaService.EliminarUnidadesOperativas(listaCodigos);
            return Json(resultado);
        }

        /// <summary>
        /// Permite buscar el unidad operativa staff
        /// </summary>
        /// <param name="filtro">Filtro de  unidad operativa</param>
        /// <returns>Retorna la unidad operativa</returns>
        public JsonResult BuscarUnidadOperativaStaff(FiltroUnidadOperativa filtro)
        {
            var resultado = unidadOperativaService.BuscarUnidadOperativaStaff(filtro);
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

        /// <summary>
        /// Permite registrar Staff
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Resultado de la operación</returns>
        public JsonResult RegistrarStaff(DataUnidadOperativaStaffRequest data)
        {
            var resultado = unidadOperativaService.RegistrarUnidadOperativaStaff(data);
            return Json(resultado);
        }

        /// <summary>
        /// Permite Eliminar Staff
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Resultado de la operación</returns>
        public JsonResult EliminarUnidadOperativaStaff(DataUnidadOperativaStaffRequest request)
        {
            var response = unidadOperativaService.EliminarUnidadOperativaStaff(request);
            return Json(response);
        }

        /// <summary>
        /// Permite registrar el usuario de consulta de la Unidad Operativa
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Resultado de la operación json</returns>
        public JsonResult RegistrarUsuarioConsultaUnidadOperativa(DataUnidadOperativaUsuarioConsultaRequest data)
        {
            var resultado = unidadOperativaService.RegistrarUnidadOperativaUsuarioConsulta(data);
            return Json(resultado);
        }

        /// <summary>
        /// Permite Eliminar el usuario de consulta de la Unidad Operativa
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Resultado de la operación</returns>
        public JsonResult EliminarUsuarioConsultaUnidadOperativa(DataUnidadOperativaUsuarioConsultaRequest data)
        {                
            var response = unidadOperativaService.EliminarUnidadOperativaUsuarioConsulta(data);
            return Json(response);
        }

        /// <summary>
        /// Permite buscar usuarios de consulta de la unidad operativa
        /// </summary>
        /// <param name="filtro">Filtro de unidad operativa</param>
        /// <returns>Retorna los usuarios de consulta de la unidad operativa</returns>
        public JsonResult BuscarUsuariosConsultaUnidadOperativa(FiltroUnidadOperativa filtro)
        {
            var resultado = unidadOperativaService.BuscarUsuariosConsultaUnidadOperativa(filtro);
            return Json(resultado);
        }

        #endregion
    }
}

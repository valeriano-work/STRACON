using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.VariablePlantilla;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Cross.Core.Util;
using Pe.GyM.Security.Web.Session;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Variable Plantilla
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150318
    /// Modificación:
    /// </remarks>
    public class VariablePlantillaController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio Variable Service
        /// </summary>
        public IVariableService variableService { get; set; }
        /// <summary>
        /// Servicio Plantilla
        /// </summary>
        public IPlantillaService plantillaService { get; set; }
        #endregion

        #region Vistas
        /// /// <summary>
        /// Muestra la Vista Principal
        /// </summary>
        /// <returns>Vista principal de la opción</returns>
        public ActionResult Index()
        {
            var plantilla = plantillaService.BuscarPlantilla(new PlantillaRequest() { }).Result;
            var tipoVariable = variableService.ListarTipoVariable().Result;
            var modelo = new VariablePlantillaBusqueda(plantilla, tipoVariable);

            modelo.ControlPermisos = Utilitario.ObtenerControlPermisos(HttpGyMSessionContext.CurrentAccount(), "/Contractual/VariablePlantilla/");

            return View(modelo);
        }

        /// <summary>
        /// Muestra la vista de campos de una variable
        /// </summary>
        /// <param name="CodigoVariablePlantilla">Código de la variable a la que pertenecen los campos</param>
        /// <returns>Vista de campos de una variable</returns>
        public ActionResult VariablePlantillaCampo(string CodigoVariablePlantilla)
        {
            var listaVariable = variableService.BuscarVariable(new VariableRequest() { CodigoVariable = CodigoVariablePlantilla }).Result;
            var modelo = new VariablePlantillaCampoBusqueda(listaVariable.FirstOrDefault());

            return View(modelo);
        }
        #endregion

        #region Vistas Parciales
        /// <summary>
        /// Muestra la vista Formulario Variable Plantilla
        /// </summary>
        /// <param name="codigoVariable">Identificador Código Variable</param>
        /// <returns>Vista Formulario Variable Plantilla</returns>
        public ActionResult FormularioVariablePlantilla(string codigoVariable)
        {
            var plantilla = plantillaService.BuscarPlantilla(new PlantillaRequest() { }).Result;
            var tipoVariable = variableService.ListarTipoVariable().Result;
            VariablePlantillaFormulario modelo = null;

            if (!string.IsNullOrWhiteSpace(codigoVariable))
            {
                var resultadoVariable = variableService.BuscarVariable(new VariableRequest() {
                    CodigoVariable = codigoVariable
                });
                var variable = resultadoVariable.Result.FirstOrDefault();
                if (variable != null)
                {
                    modelo = new VariablePlantillaFormulario(plantilla, variable, tipoVariable);
                }
                else
                {
                    modelo = new VariablePlantillaFormulario(plantilla, tipoVariable);
                }
            }
            else
            {
                modelo = new VariablePlantillaFormulario(plantilla, tipoVariable);
            }


            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra el formulario de campos de variable
        /// </summary>
        /// <param name="CodigoVariableCampo">Código del campo</param>
        /// <returns>Vista Parcial de formulario de campos de variable</returns>
        public ActionResult FormularioVariablePlantillaCampo(VariableCampoRequest filtro)
        {
            VariablePlantillaCampoFormulario modelo = null;
            var listaTipoAlineamiento = variableService.ListarTipoAlineamiento().Result;
            if (filtro != null && filtro.CodigoVariableCampo != null && filtro.CodigoVariableCampo != "" && filtro.CodigoVariableCampo != "00000000-0000-0000-0000-000000000000")
            {
                var listaCampos = variableService.BuscarVariableCampo(filtro).Result;
                modelo = new VariablePlantillaCampoFormulario(listaCampos.FirstOrDefault(), listaTipoAlineamiento);
            }
            else
            {
                modelo = new VariablePlantillaCampoFormulario(filtro.CodigoVariable, listaTipoAlineamiento);
            }

            return PartialView(modelo);
        }

        /// <summary>
        /// Muestra el formulario de Lista de variable
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <returns>Vista Parcial de formulario de campos de variable</returns>
        public ActionResult FormularioVariablePlantillaLista(VariableListaRequest filtro)
        {
            VariablePlantillaListaFormulario modelo = null;

            if (filtro != null && filtro.CodigoVariableLista != null && filtro.CodigoVariableLista != "" && filtro.CodigoVariableLista != "00000000-0000-0000-0000-000000000000")
            {
                var listaOpciones = variableService.BuscarVariableLista(filtro).Result;
                modelo = new VariablePlantillaListaFormulario(listaOpciones.FirstOrDefault());
            }
            else
            {
                modelo = new VariablePlantillaListaFormulario(filtro.CodigoVariable);
            }

            return PartialView(modelo);
        }
        #endregion

        #region Json
        /// <summary>
        /// Busca Variables de plantilla
        /// </summary>
        /// <param name="filtro">Campos a buscar</param>
        /// <returns>Registros a buscar</returns>
        public JsonResult BuscarBandeVariablePlantilla(VariableRequest filtro)
        {
            var resultado = variableService.BuscarVariable(filtro);
            return Json(resultado);
        }
        /// <summary>
        /// Registra Variables
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador de proceso</returns>
        public JsonResult RegistrarVariablePlantilla(VariableRequest data)
        {
            var resultado = variableService.RegistrarVariable(data);
            return Json(resultado);
        }

        /// <summary>
        /// Eliminar Variable plantilla
        /// </summary>
        /// <param name="listaCodigoVariable">Lista con registros a eliminar</param>
        /// <returns>Identificador con resultado</returns>
        public JsonResult EliminarVariablePlantilla(List<Object> listaCodigoVariable)
        {
            var resultado = variableService.EliminarVariablePlantilla(listaCodigoVariable);
            return Json(resultado);
        }

        /// <summary>
        /// Realiza la búsqueda de Campos
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de Campos</returns>
        public JsonResult BuscarCampo(VariableCampoRequest filtro)
        {
            var resultado = variableService.BuscarVariableCampo(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Realiza la inserción o actualización de Campos
        /// </summary>
        /// <param name="data">Datos del campo</param>
        /// <returns>Código de resultado</returns>
        public JsonResult RegistrarCampo(VariableCampoRequest data)
        {
            var resultado = variableService.RegistrarVariableCampo(data);
            return Json(resultado);
        }

        /// <summary>
        /// Realiza la eliminación lógica de Campos
        /// </summary>
        /// <param name="lista">Lista de campos a eliminar</param>
        /// <returns>Código de resultado</returns>
        public JsonResult EliminarCampo(List<VariableCampoRequest> listaCodigos)
        {
            var resultado = variableService.EliminarVariableCampo(listaCodigos);
            return Json(resultado);
        }

        /// <summary>
        /// Realiza la búsqueda de Lista
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de Campos</returns>
        public JsonResult BuscarLista(VariableListaRequest filtro)
        {
            var resultado = variableService.BuscarVariableLista(filtro);
            return Json(resultado);
        }

        /// <summary>
        /// Realiza la inserción o actualización de Lista
        /// </summary>
        /// <param name="data">Datos del lista</param>
        /// <returns>Código de resultado</returns>
        public JsonResult RegistrarLista(VariableListaRequest data)
        {
            var resultado = variableService.RegistrarVariableLista(data);
            return Json(resultado);
        }

        /// <summary>
        /// Realiza la eliminación lógica de Lista
        /// </summary>
        /// <param name="lista">Lista de lista a eliminar</param>
        /// <returns>Código de resultado</returns>
        public JsonResult EliminarLista(List<VariableListaRequest> listaCodigos)
        {
            var resultado = variableService.EliminarVariableLista(listaCodigos);
            return Json(resultado);
        }
        #endregion
    }
}

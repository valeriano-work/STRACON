using System;
using System.Collections.Generic;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.Adapter.Contractual;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.Core.Message;
using Pe.Stracon.SGC.Aplicacion.Service.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Cross.Core.Exception;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Cross.Core.Extension;
using Pe.Stracon.SGC.Cross.Core.Base;

namespace Pe.Stracon.SGC.Aplicacion.Service.Contractual
{
    /// <summary>
    /// Servicio que representa las plantillas
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150518 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class PlantillaService : GenericService, IPlantillaService
    {
        #region Propiedades
        /// <summary>
        /// Variable de entorno de la aplicación
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        /// <summary>
        /// Servicio de manejo de política 
        /// </summary>
        public IPoliticaService politicaService { get; set; }

        /// <summary>
        /// Repositorio de manejo de plantilla logic
        /// </summary>
        public IPlantillaLogicRepository plantillaLogicRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de plantilla entity
        /// </summary>
        public IPlantillaEntityRepository plantillaEntityRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de plantilla párrafo entity
        /// </summary>
        public IPlantillaParrafoEntityRepository plantillaParrafoEntityRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de plantilla párrafo entity
        /// </summary>
        public IPlantillaParrafoVariableEntityRepository plantillaParrafoVariableEntityRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de variable logic
        /// </summary>
        public IVariableLogicRepository variableLogicRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de listado contrato logic
        /// </summary>
        public IListadoContratoLogicRepository listadoContratoLogicRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de plantilla nota pie entity
        /// </summary>
        public IPlantillaNotaPieEntityRepository plantillaNotaPieEntityRepository { get; set; }


        #endregion

        /// <summary>
        /// Realiza la búsqueda de plantillas
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de plantillas</returns>
        public ProcessResult<List<PlantillaResponse>> BuscarPlantilla(PlantillaRequest filtro)
        {
            ProcessResult<List<PlantillaResponse>> resultado = new ProcessResult<List<PlantillaResponse>>();
            List<CodigoValorResponse> resultadoTipoContrato = null;
            List<CodigoValorResponse> resultadoTipoDocumentoContrato = null;
            List<CodigoValorResponse> resultadoEstadoVigencia = null;

            try
            {
                resultadoTipoContrato = politicaService.ListarTipoContrato().Result;
                resultadoTipoDocumentoContrato = politicaService.ListarTipoDocumentoContrato().Result;
                resultadoEstadoVigencia = politicaService.ListarEstadoVigencia().Result;

                Guid? codigoPlantilla = filtro.CodigoPlantilla != null ? new Guid(filtro.CodigoPlantilla) : (Guid?)null;

                DateTime? fechaInicioVigencia = null;
                DateTime? fechaFinVigencia = null;

                if (!string.IsNullOrWhiteSpace(filtro.FechaInicioVigenciaString))
                {
                    fechaInicioVigencia = DateTime.ParseExact(filtro.FechaInicioVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    fechaInicioVigencia = null;
                }

                if (!string.IsNullOrWhiteSpace(filtro.FechaFinVigenciaString))
                {
                    fechaFinVigencia = DateTime.ParseExact(filtro.FechaFinVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    fechaFinVigencia = null;
                }

                List<PlantillaLogic> listado = plantillaLogicRepository.BuscarPlantilla(codigoPlantilla, filtro.Descripcion, filtro.CodigoTipoContrato,
                                                                                        filtro.CodigoTipoDocumentoContrato, filtro.CodigoEstadoVigencia, filtro.IndicadorAdhesion,
                                                                                        fechaInicioVigencia, fechaFinVigencia, filtro.NumeroPagina, filtro.RegistrosPagina);

                resultado.Result = new List<PlantillaResponse>();
                foreach (var registro in listado)
                {
                    var plantilla = PlantillaAdapter.ObtenerPlantillaPaginado(registro, resultadoTipoContrato, resultadoTipoDocumentoContrato, resultadoEstadoVigencia);
                    resultado.Result.Add(plantilla);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Registra o actualiza una plantilla
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarPlantilla(PlantillaRequest data)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            try
            {
                PlantillaEntity entidad = PlantillaAdapter.RegistrarPlantilla(data);
                DateTime fechaActual = DateTime.Now.Date;
                bool existeRepetido = false;

                if (!string.IsNullOrWhiteSpace(data.FechaInicioVigenciaString))
                {
                    var resultadoValidacion = plantillaLogicRepository.BuscarPlantillaTipo(data.CodigoTipoContrato, data.CodigoTipoDocumentoContrato, Convert.ToBoolean(data.IndicadorAdhesion));
                    existeRepetido = resultadoValidacion.Any(x => x.CodigoPlantilla != entidad.CodigoPlantilla && x.FechaInicioVigenciaDate == entidad.FechaInicioVigencia);
                    if (existeRepetido)
                    {
                        resultado.IsSuccess = false;
                        resultado.Exception = new ApplicationLayerException<PlantillaService>(MensajesSistema.PlantillaExiste);
                    }
                    else
                    {
                        if (data.CodigoPlantilla == null && data.CodigoPlantillaCopiar == null)
                        {
                            entidad.CodigoEstadoVigencia = DatosConstantes.EstadoVigencia.Proximo;
                            plantillaEntityRepository.Insertar(entidad, entornoActualAplicacion);
                        }
                        else if (data.CodigoPlantillaCopiar != null)
                        {
                            entidad.CodigoEstadoVigencia = DatosConstantes.EstadoVigencia.Proximo;
                            plantillaEntityRepository.CopiarPlantilla(new Guid(data.CodigoPlantillaCopiar), data.Descripcion, data.CodigoTipoContrato, data.CodigoTipoDocumentoContrato, Convert.ToDateTime(data.FechaInicioVigenciaString), entornoActualAplicacion.UsuarioSession, entornoActualAplicacion.Terminal, data.EsMayorMenor);
                        }
                        else
                        {

                            //var contratosAsociadoPlantilla = listadoContratoLogicRepository.BuscarListadoContrato(null, null, entidad.CodigoPlantilla, null, 
                            //                                                            null, null, DatosConstantes.EstadoContrato.Edicion,
                            //                                                            null, null, null, null, null, null, null,
                            //                                                            DatosConstantes.CodigoEstadoEdicion.EdicionParcial,null, 1, -1).FirstOrDefault();

                            //if (contratosAsociadoPlantilla == null)
                            //{
                            var entidadSincronizar = plantillaEntityRepository.GetById(entidad.CodigoPlantilla);
                            entidadSincronizar.Descripcion = entidad.Descripcion;
                            entidadSincronizar.CodigoTipoDocumentoContrato = entidad.CodigoTipoDocumentoContrato;
                            entidadSincronizar.CodigoTipoContrato = entidad.CodigoTipoContrato;
                            entidadSincronizar.IndicadorAdhesion = entidad.IndicadorAdhesion;
                            entidadSincronizar.FechaInicioVigencia = entidad.FechaInicioVigencia;
                            //INICIO: Agregado por Julio Carrera - Norma Contable
                            entidadSincronizar.Es_MayorMenor = entidad.Es_MayorMenor;
                            //FIN: Agregado por Julio Carrera - Norma Contable

                            plantillaEntityRepository.Editar(entidadSincronizar, entornoActualAplicacion);
                            //}
                            //else 
                            //{
                            //    resultado.IsSuccess = false;
                            //    resultado.Exception = new ApplicationLayerException<PlantillaService>(MensajesSistema.PlantillaNoModificar);
                            //}
                        }

                        plantillaEntityRepository.GuardarCambios();

                        plantillaEntityRepository.ActualizarPlantillaEstadoVigencia();

                        resultado.Result = data;
                    }
                }
                else
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<PlantillaService>(MensajesSistema.PlantillaFechaInicioVigenciIncorrecto);
                }
            }
            catch (Exception e)
            {
                LogBL.grabarLogError(new Exception("RegistrarPlantilla"));
                LogBL.grabarLogError(e.GetBaseException());
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaService>(e.GetBaseException().Message);
            }
            return resultado;
        }

        /// <summary>
        /// Elimina uno o muchas plantillas
        /// </summary>
        /// <param name="listaCodigosPlantilla">Lista de códigos de plantillas a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> EliminarPlantilla(List<object> listaCodigosPlantilla)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            try
            {
                foreach (var codigo in listaCodigosPlantilla)
                {
                    var llaveEntidad = new Guid(codigo.ToString());

                    //var contratosAsociadoPlantilla = listadoContratoLogicRepository.BuscarListadoContrato(null, null, llaveEntidad, null,
                    //                                                                   null, null, DatosConstantes.EstadoContrato.Edicion,
                    //                                                                   null, null, null, null, null, null, null,
                    //                                                                   DatosConstantes.CodigoEstadoEdicion.EdicionParcial,null, 1, -1).FirstOrDefault();

                    //if (contratosAsociadoPlantilla == null)
                    //{
                    plantillaEntityRepository.EliminarEntorno(entornoActualAplicacion, llaveEntidad);
                    //}
                    //else
                    //{
                    //    resultado.IsSuccess = false;
                    //    resultado.Exception = new ApplicationLayerException<PlantillaService>(MensajesSistema.PlantillaNoEliminar);
                    //}

                }
                resultado.Result = plantillaEntityRepository.GuardarCambios();

                plantillaEntityRepository.ActualizarPlantillaEstadoVigencia();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la búsqueda de plantilla párrafo
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de plantilla párrafo</returns>
        public ProcessResult<List<PlantillaParrafoResponse>> BuscarPlantillaParrafo(PlantillaParrafoRequest filtro)
        {
            ProcessResult<List<PlantillaParrafoResponse>> resultado = new ProcessResult<List<PlantillaParrafoResponse>>();

            try
            {
                Guid? codigoPlantillaParrafo = filtro.CodigoPlantillaParrafo != null ? new Guid(filtro.CodigoPlantillaParrafo) : (Guid?)null;
                Guid? codigoPlantilla = filtro.CodigoPlantilla != null ? new Guid(filtro.CodigoPlantilla) : (Guid?)null;

                List<PlantillaParrafoLogic> listado = plantillaLogicRepository.BuscarPlantillaParrafo(codigoPlantillaParrafo, codigoPlantilla, filtro.Orden, filtro.Titulo,
                                                                                        filtro.Contenido, filtro.NumeroPagina, filtro.RegistrosPagina);

                resultado.Result = new List<PlantillaParrafoResponse>();
                foreach (var registro in listado)
                {
                    var plantillaParrafo = PlantillaParrafoAdapter.ObtenerPlantillaParrafoPaginado(registro);

                    if (filtro.IndicadorObtenerListaVariable)
                    {
                        plantillaParrafo.ListaPlantillaParrafoVariable = BuscarPlantillaParrafoVariableCodigoPlantillaParrafo(new PlantillaParrafoVariableRequest()
                        {
                            CodigoPlantillaParrafo = plantillaParrafo.CodigoPlantillaParrafo.ToString()
                        }).Result;
                    }

                    resultado.Result.Add(plantillaParrafo);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Elimina uno o muchas plantilla párrafo
        /// </summary>
        /// <param name="listaCodigosPlantillaParrafo">Lista de códigos de plantilla párrafo a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> EliminarPlantillaParrafo(List<object> listaCodigosPlantillaParrafo)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            try
            {
                foreach (var codigo in listaCodigosPlantillaParrafo)
                {
                    var llaveEntidad = new Guid(codigo.ToString());
                    plantillaParrafoEntityRepository.Eliminar(llaveEntidad);
                }

                resultado.Result = plantillaParrafoEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la busqueda de variables globales
        /// </summary>
        /// <param name="codigoPlantilla">Código de plantilla</param>
        /// <returns>Variables Globales</returns>
        public ProcessResult<List<VariableResponse>> BuscarVariableGlobal(string codigoPlantilla)
        {
            ProcessResult<List<VariableResponse>> resultado = new ProcessResult<List<VariableResponse>>();

            try
            {
                Guid? codPlantilla = codigoPlantilla != null ? new Guid(codigoPlantilla) : (Guid?)null;

                List<VariableLogic> listado = variableLogicRepository.BuscarVariableGlobal(codPlantilla);

                resultado.Result = new List<VariableResponse>();
                foreach (var registro in listado)
                {
                    var variableResponse = new VariableResponse();

                    variableResponse.CodigoVariable = registro.CodigoVariable;
                    //variableResponse.CodigoPlantilla = (Guid)registro.CodigoPlantilla;
                    variableResponse.CodigoPlantilla = Guid.Parse(codigoPlantilla);
                    variableResponse.Nombre = registro.Nombre;
                    variableResponse.Identificador = registro.Identificador;

                    resultado.Result.Add(variableResponse);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Registra o actualiza un párrafo
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarPlantillaParrafo(PlantillaParrafoRequest data)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            Dictionary<string, string> contenidoArray = new Dictionary<string, string>();

            try
            {
                var contenidoTemporal = " " + data.Contenido;
                var identificadorInicioVariable = "##";

                var listaSeparat = contenidoTemporal.Split(new string[1] { identificadorInicioVariable }, StringSplitOptions.None);

                if (listaSeparat.Count() > 1)
                {
                    var listadoVariable = variableLogicRepository.BuscarVariableGlobal(new Guid(data.CodigoPlantilla));
                    var identificadorFinVariable = new string[10] { " ", "<", ".", ",", "-", "/", "\\", ")", "(", "&nbsp" };
                    for (int i = 1; i < listaSeparat.Count(); i++)
                    {
                        var lista = listaSeparat[i].Split(identificadorFinVariable, StringSplitOptions.None);
                        var identificadorVariable = identificadorInicioVariable + lista.FirstOrDefault().Trim().ToUpper().ToString();

                        if (listadoVariable.Any(x => x.Identificador.ToUpper() == identificadorVariable))
                        {
                            Guid codigoVariable = listadoVariable.Where(x => x.Identificador.ToUpper() == identificadorVariable).FirstOrDefault().CodigoVariable;
                            contenidoArray.SetValue(codigoVariable.ToString(), identificadorInicioVariable + lista.FirstOrDefault().Trim());
                        }
                    }
                }

                PlantillaParrafoEntity entidad = PlantillaParrafoAdapter.RegistrarPlantillaParrafo(data);

                var resultadoPorOrdenDescripcion = plantillaLogicRepository.BuscarPlantillaParrafoOrdenTitulo(new Guid(data.CodigoPlantilla), Convert.ToByte(data.Orden), data.Titulo);

                bool existeRepetido = resultadoPorOrdenDescripcion.Any(e => e.CodigoPlantillaParrafo != entidad.CodigoPlantillaParrafo);

                if (existeRepetido)
                {
                    string mensaje = "";
                    resultado.IsSuccess = false;

                    if (resultadoPorOrdenDescripcion.Where(x => x.Orden.ToString() == data.Orden.ToString() && x.Titulo == data.Titulo).Count() == 1)
                    {
                        mensaje = MensajesSistema.PlantillaParrafoExiste;
                    }
                    else if (resultadoPorOrdenDescripcion.Where(x => x.Orden.ToString() == data.Orden.ToString()).Count() == 1)
                    {
                        mensaje = MensajesSistema.PlantillaParrafoOrdenExiste;
                    }
                    else
                    {
                        mensaje = MensajesSistema.PlantillaParrafoTituloExiste;
                    }

                    resultado.Exception = new ApplicationLayerException<PlantillaService>(mensaje);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(data.CodigoPlantillaParrafo))
                    {
                        plantillaParrafoEntityRepository.Insertar(entidad);

                        PlantillaParrafoVariableRequest dataVariable = new PlantillaParrafoVariableRequest();
                        dataVariable.CodigoPlantillaParrafo = entidad.CodigoPlantillaParrafo.ToString();

                        int ordenAscendente = 1;
                        foreach (var item in contenidoArray)
                        {
                            dataVariable.CodigoVariable = item.Key.ToString();
                            dataVariable.Orden = Convert.ToInt16(ordenAscendente);
                            PlantillaParrafoVariableEntity entidadPlantillaParrafoVariable = PlantillaParrafoVariableAdapter.RegistrarPlantillaParrafoVariable(dataVariable);

                            plantillaParrafoVariableEntityRepository.Insertar(entidadPlantillaParrafoVariable);

                            ordenAscendente++;
                        }
                    }
                    else
                    {
                        //Editar Plantilla Párrafo
                        var entidadSincronizar = plantillaParrafoEntityRepository.GetById(entidad.CodigoPlantillaParrafo);
                        entidadSincronizar.CodigoPlantilla = entidad.CodigoPlantilla;
                        entidadSincronizar.Orden = entidad.Orden;
                        entidadSincronizar.Titulo = entidad.Titulo;
                        entidadSincronizar.Contenido = entidad.Contenido;

                        plantillaParrafoEntityRepository.Editar(entidadSincronizar);

                        //Editar Plantilla Párrafo Variable
                        var listaVariablesAnteriores = plantillaLogicRepository.BuscarPlantillaParrafoVariableCodigoPlantillaParrafo(entidad.CodigoPlantillaParrafo);

                        var listaEliminados = listaVariablesAnteriores.Where(v => !contenidoArray.Keys.Contains(v.CodigoVariable.ToString()));

                        foreach (var item in listaEliminados)
                        {
                            var llaveEntidad = item.CodigoPlantillaParrafoVariable;
                            plantillaParrafoVariableEntityRepository.Eliminar(llaveEntidad);
                        }

                        int orden = 1;
                        foreach (var contenido in contenidoArray)
                        {
                            var plantillaParrafoVariable = listaVariablesAnteriores.Where(item => item.CodigoVariable == new Guid(contenido.Key)).FirstOrDefault();
                            if (plantillaParrafoVariable == null)
                            {
                                PlantillaParrafoVariableRequest dataVariable = new PlantillaParrafoVariableRequest();
                                dataVariable.CodigoPlantillaParrafo = entidadSincronizar.CodigoPlantillaParrafo.ToString();
                                dataVariable.CodigoVariable = contenido.Key;
                                dataVariable.Orden = Convert.ToInt16(orden);
                                PlantillaParrafoVariableEntity entidadPlantillaParrafoVariable = PlantillaParrafoVariableAdapter.RegistrarPlantillaParrafoVariable(dataVariable);

                                plantillaParrafoVariableEntityRepository.Insertar(entidadPlantillaParrafoVariable);
                            }
                            else
                            {
                                var entidadSincronizarVariable = plantillaParrafoVariableEntityRepository.GetById(plantillaParrafoVariable.CodigoPlantillaParrafoVariable);
                                entidadSincronizarVariable.Orden = Convert.ToInt16(orden);

                                plantillaParrafoVariableEntityRepository.Editar(entidadSincronizarVariable);
                            }
                            orden++;
                        }
                    }

                    plantillaParrafoEntityRepository.GuardarCambios();
                    plantillaParrafoVariableEntityRepository.GuardarCambios();
                    resultado.Result = data;
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la búsqueda de plantilla párrafo variable
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de plantilla párrafo variable</returns>
        public ProcessResult<List<PlantillaParrafoVariableResponse>> BuscarPlantillaParrafoVariableCodigoPlantillaParrafo(PlantillaParrafoVariableRequest filtro)
        {
            ProcessResult<List<PlantillaParrafoVariableResponse>> resultado = new ProcessResult<List<PlantillaParrafoVariableResponse>>();

            try
            {
                if (string.IsNullOrEmpty(filtro.CodigoPlantillaParrafo))
                {
                    filtro.CodigoPlantillaParrafo = Guid.Empty.ToString();
                }
                List<PlantillaParrafoVariableLogic> listado = plantillaLogicRepository.BuscarPlantillaParrafoVariableCodigoPlantillaParrafo(new Guid(filtro.CodigoPlantillaParrafo));

                resultado.Result = new List<PlantillaParrafoVariableResponse>();
                foreach (var registro in listado)
                {
                    var plantillaParrafoVariable = PlantillaParrafoVariableAdapter.ObtenerPlantillaParrafoVariable(registro);
                    resultado.Result.Add(plantillaParrafoVariable);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Realiza la búsqueda de notas al pie por plantilla
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de notas al pie</returns>
        public ProcessResult<List<PlantillaNotaPieResponse>> BuscarNotasPiePorPlantilla(PlantillaNotaPieRequest filtro)
        {
            ProcessResult<List<PlantillaNotaPieResponse>> resultado = new ProcessResult<List<PlantillaNotaPieResponse>>();
            var listaNotas = new List<PlantillaNotaPieResponse>();
            try
            {
                Guid? codigoPlantillaNotaPie = filtro.CodigoPlantillaNotaPie != null ? new Guid(filtro.CodigoPlantillaNotaPie) : (Guid?)null;
                Guid? codigoPlantilla = filtro.CodigoPlantilla != null ? new Guid(filtro.CodigoPlantilla) : (Guid?)null;
                var listado = plantillaLogicRepository.BuscarNotasPiePorPlantilla(codigoPlantillaNotaPie, codigoPlantilla, filtro.NumeroPagina, filtro.RegistrosPagina);

                foreach (var item in listado)
                {
                    var nota = new PlantillaNotaPieResponse();
                    nota.CodigoPlantillaNotaPie = item.CodigoPlantillaNotaPie;
                    nota.CodigoPlantilla = item.CodigoPlantilla;
                    nota.Orden = item.Orden;
                    nota.Titulo = item.Titulo;
                    nota.Contenido = item.Contenido;

                    listaNotas.Add(nota);
                }

                resultado.Result = listaNotas;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaService>(e);
            }
            return resultado;
        }


        /// <summary>
        /// Registra o actualiza una nota al pie
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarNotaPie(PlantillaNotaPieRequest data)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            Dictionary<string, string> contenidoArray = new Dictionary<string, string>();

            try
            {
                var listado = plantillaLogicRepository.BuscarNotasPiePorPlantilla(null, new Guid(data.CodigoPlantilla), 1, -1);

                var existeOrden = listado.Any(n => n.Orden == data.Orden);

                if (existeOrden && string.IsNullOrEmpty(data.CodigoPlantillaNotaPie))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<PlantillaService>(MensajesSistema.PlantillaNotaOrdenExiste);
                }
                else
                {
                    //Mejorar visibilidad de etiqueta sup
                    if (data.Contenido.Contains("<sup>"))
                    {
                        data.Contenido = data.Contenido.Replace("<sup>", "<span style='font-size: 6px; vertical-align:super;'>");
                        data.Contenido = data.Contenido.Replace("</sup>", "</span>");
                    }

                    if (string.IsNullOrEmpty(data.CodigoPlantillaNotaPie))
                    {
                        var entidad = new PlantillaNotaPieEntity();
                        entidad.CodigoPlantillaNotaPie = Guid.NewGuid();
                        entidad.CodigoPlantilla = new Guid(data.CodigoPlantilla);
                        entidad.Orden = Convert.ToByte(data.Orden);
                        entidad.Titulo = data.Titulo;
                        entidad.Contenido = data.Contenido;

                        plantillaNotaPieEntityRepository.Insertar(entidad);
                    }
                    else
                    {
                        var entidadSincronizar = plantillaNotaPieEntityRepository.GetById(new Guid(data.CodigoPlantillaNotaPie));
                        entidadSincronizar.Orden = (byte)data.Orden;
                        entidadSincronizar.Titulo = data.Titulo;
                        entidadSincronizar.Contenido = data.Contenido;

                        plantillaNotaPieEntityRepository.Editar(entidadSincronizar);
                    }

                    plantillaNotaPieEntityRepository.GuardarCambios();
                    resultado.Result = data;
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Elimina uno o muchas notas al pie
        /// </summary>
        /// <param name="listaCodigosNotas">Lista de notas a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> EliminarNotas(List<Guid> listaCodigosNotas)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            try
            {
                foreach (var codigo in listaCodigosNotas)
                {
                    plantillaNotaPieEntityRepository.Eliminar(codigo);
                }

                resultado.Result = plantillaNotaPieEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaService>(e);
            }

            return resultado;
        }
    }
}

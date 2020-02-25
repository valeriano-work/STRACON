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
    public class PlantillaRequerimientoService : GenericService, IPlantillaRequerimientoService
        

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
        public IPlantillaRequerimientoLogicRepository plantillaRequerimientoLogicRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de plantilla entity
        /// </summary>
        public IPlantillaRequerimientoEntityRepository plantillaRequerimientoEntityRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de plantilla párrafo entity
        /// </summary>
        public IPlantillaRequerimientoParrafoEntityRepository plantillaRequerimientoParrafoEntityRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de plantilla párrafo entity
        /// </summary>
        public IPlantillaRequerimientoParrafoVariableEntityRepository plantillaRequerimientoParrafoVariableEntityRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de variable logic
        /// </summary>
        public IVariableLogicRepository variableLogicRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de listado contrato logic
        /// </summary>
        public IListadoRequerimientoLogicRepository listadoRequerimientoLogicRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de plantilla nota pie entity
        /// </summary>
        public IPlantillaRequerimientoNotaPieEntityRepository plantillaRequerimientoNotaPieEntityRepository { get; set; }


        #endregion

        /// <summary>
        /// Realiza la búsqueda de plantillas
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de plantillas</returns>
        public ProcessResult<List<PlantillaRequerimientoResponse>> BuscarPlantilla(PlantillaRequerimientoRequest filtro)
        {
            ProcessResult<List<PlantillaRequerimientoResponse>> resultado = new ProcessResult<List<PlantillaRequerimientoResponse>>();
            //List<CodigoValorResponse> resultadoTipoContrato = null;
            //List<CodigoValorResponse> resultadoTipoDocumentoContrato = null;
            List<CodigoValorResponse> resultadoEstadoVigencia = null;

            try
            {
                //resultadoTipoContrato = politicaService.ListarTipoContrato().Result;
                //resultadoTipoDocumentoContrato = politicaService.ListarTipoDocumentoContrato().Result;
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

                List<PlantillaRequerimientoLogic> listado = plantillaRequerimientoLogicRepository.BuscarPlantilla(codigoPlantilla, filtro.Descripcion, 
                                                                                        filtro.CodigoEstadoVigencia, filtro.IndicadorAdhesion,
                                                                                        fechaInicioVigencia, fechaFinVigencia, filtro.NumeroPagina, filtro.RegistrosPagina);

                resultado.Result = new List<PlantillaRequerimientoResponse>();
                foreach (var registro in listado)
                {
                    var plantilla = PlantillaRequerimientoAdapter.ObtenerPlantillaPaginado(registro,  resultadoEstadoVigencia);
                    resultado.Result.Add(plantilla);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Registra o actualiza una plantilla
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarPlantilla(PlantillaRequerimientoRequest data)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            try
            {
                PlantillaRequerimientoEntity entidad = PlantillaRequerimientoAdapter.RegistrarPlantilla(data);
                DateTime fechaActual = DateTime.Now.Date;
                bool existeRepetido = false;

                if (!string.IsNullOrWhiteSpace(data.FechaInicioVigenciaString))
                {
                    var resultadoValidacion = plantillaRequerimientoLogicRepository.BuscarPlantillaTipo(Convert.ToBoolean(data.IndicadorAdhesion));
                    existeRepetido = resultadoValidacion.Any(x => x.CodigoPlantilla != entidad.CodigoPlantilla && x.FechaInicioVigenciaDate == entidad.FechaInicioVigencia);
                    if (existeRepetido)
                    {
                        resultado.IsSuccess = false;
                        resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(MensajesSistema.PlantillaExiste);
                    }
                    else
                    {
                        if (data.CodigoPlantilla == null && data.CodigoPlantillaCopiar == null)
                        {
                            entidad.CodigoEstadoVigencia = DatosConstantes.EstadoVigencia.Proximo;
                            plantillaRequerimientoEntityRepository.Insertar(entidad, entornoActualAplicacion);
                        }
                        else if (data.CodigoPlantillaCopiar != null)
                        {
                            entidad.CodigoEstadoVigencia = DatosConstantes.EstadoVigencia.Proximo;
                            plantillaRequerimientoEntityRepository.CopiarPlantilla(new Guid(data.CodigoPlantillaCopiar), data.Descripcion, Convert.ToDateTime(data.FechaInicioVigenciaString), entornoActualAplicacion.UsuarioSession, entornoActualAplicacion.Terminal);                                     
                        }
                        else
                        {
                            var entidadSincronizar = plantillaRequerimientoEntityRepository.GetById(entidad.CodigoPlantilla);
                            entidadSincronizar.Descripcion = entidad.Descripcion;
                            entidadSincronizar.IndicadorAdhesion = entidad.IndicadorAdhesion;
                            entidadSincronizar.FechaInicioVigencia = entidad.FechaInicioVigencia;
                            plantillaRequerimientoEntityRepository.Editar(entidadSincronizar, entornoActualAplicacion);
                        }

                        plantillaRequerimientoEntityRepository.GuardarCambios();

                        plantillaRequerimientoEntityRepository.ActualizarPlantillaEstadoVigencia();

                        resultado.Result = data;
                    }
                }
                else
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(MensajesSistema.PlantillaFechaInicioVigenciIncorrecto);
                }
            }
            catch (Exception e)
            {
                LogBL.grabarLogError(new Exception("RegistrarPlantillaRequerimiento"));
                LogBL.grabarLogError(e.GetBaseException());
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(e.GetBaseException().Message);
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
                    plantillaRequerimientoEntityRepository.EliminarEntorno(entornoActualAplicacion, llaveEntidad);
                    //}
                    //else
                    //{
                    //    resultado.IsSuccess = false;
                    //    resultado.Exception = new ApplicationLayerException<PlantillaService>(MensajesSistema.PlantillaNoEliminar);
                    //}

                }
                resultado.Result = plantillaRequerimientoEntityRepository.GuardarCambios();

                plantillaRequerimientoEntityRepository.ActualizarPlantillaEstadoVigencia();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la búsqueda de plantilla párrafo
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de plantilla párrafo</returns>
        public ProcessResult<List<PlantillaRequerimientoParrafoResponse>> BuscarPlantillaParrafo(PlantillaRequerimientoParrafoRequest filtro)
        {
            ProcessResult<List<PlantillaRequerimientoParrafoResponse>> resultado = new ProcessResult<List<PlantillaRequerimientoParrafoResponse>>();

            try
            {
                Guid? codigoPlantillaParrafo = filtro.CodigoPlantillaParrafo != null ? new Guid(filtro.CodigoPlantillaParrafo) : (Guid?)null;
                Guid? codigoPlantilla = filtro.CodigoPlantilla != null ? new Guid(filtro.CodigoPlantilla) : (Guid?)null;

                List<PlantillaRequerimientoParrafoLogic> listado = plantillaRequerimientoLogicRepository.BuscarPlantillaParrafo(codigoPlantillaParrafo, codigoPlantilla, filtro.Orden, filtro.Titulo,
                                                                                        filtro.Contenido, filtro.NumeroPagina, filtro.RegistrosPagina);

                resultado.Result = new List<PlantillaRequerimientoParrafoResponse>();
                foreach (var registro in listado)
                {
                    var plantillaParrafo = PlantillaRequerimientoParrafoAdapter.ObtenerPlantillaParrafoPaginado(registro);

                    if (filtro.IndicadorObtenerListaVariable)
                    {
                        plantillaParrafo.ListaPlantillaParrafoVariable = BuscarPlantillaParrafoVariableCodigoPlantillaParrafo(new PlantillaRequerimientoParrafoVariableRequest()
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
                resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(e);
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
                    plantillaRequerimientoParrafoEntityRepository.Eliminar(llaveEntidad);
                }

                resultado.Result = plantillaRequerimientoParrafoEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(e);
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
                resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Registra o actualiza un párrafo
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarPlantillaParrafo(PlantillaRequerimientoParrafoRequest data)
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

                PlantillaRequerimientoParrafoEntity entidad = PlantillaRequerimientoParrafoAdapter.RegistrarPlantillaParrafo(data);

                var resultadoPorOrdenDescripcion = plantillaRequerimientoLogicRepository.BuscarPlantillaParrafoOrdenTitulo(new Guid(data.CodigoPlantilla), Convert.ToByte(data.Orden), data.Titulo);

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

                    resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(mensaje);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(data.CodigoPlantillaParrafo))
                    {
                        plantillaRequerimientoParrafoEntityRepository.Insertar(entidad);

                        PlantillaRequerimientoParrafoVariableRequest dataVariable = new PlantillaRequerimientoParrafoVariableRequest();
                        dataVariable.CodigoPlantillaParrafo = entidad.CodigoPlantillaParrafo.ToString();

                        int ordenAscendente = 1;
                        foreach (var item in contenidoArray)
                        {
                            dataVariable.CodigoVariable = item.Key.ToString();
                            dataVariable.Orden = Convert.ToInt16(ordenAscendente);
                            PlantillaRequerimientoParrafoVariableEntity entidadPlantillaParrafoVariable = PlantillaRequerimientoParrafoVariableAdapter.RegistrarPlantillaParrafoVariable(dataVariable);

                            plantillaRequerimientoParrafoVariableEntityRepository.Insertar(entidadPlantillaParrafoVariable);

                            ordenAscendente++;
                        }
                    }
                    else
                    {
                        //Editar Plantilla Párrafo
                        var entidadSincronizar = plantillaRequerimientoParrafoEntityRepository.GetById(entidad.CodigoPlantillaParrafo);
                        entidadSincronizar.CodigoPlantilla = entidad.CodigoPlantilla;
                        entidadSincronizar.Orden = entidad.Orden;
                        entidadSincronizar.Titulo = entidad.Titulo;
                        entidadSincronizar.Contenido = entidad.Contenido;

                        plantillaRequerimientoParrafoEntityRepository.Editar(entidadSincronizar);

                        //Editar Plantilla Párrafo Variable
                        var listaVariablesAnteriores = plantillaRequerimientoLogicRepository.BuscarPlantillaParrafoVariableCodigoPlantillaParrafo(entidad.CodigoPlantillaParrafo);

                        var listaEliminados = listaVariablesAnteriores.Where(v => !contenidoArray.Keys.Contains(v.CodigoVariable.ToString()));

                        foreach (var item in listaEliminados)
                        {
                            var llaveEntidad = item.CodigoPlantillaParrafoVariable;
                            plantillaRequerimientoParrafoVariableEntityRepository.Eliminar(llaveEntidad);
                        }

                        int orden = 1;
                        foreach (var contenido in contenidoArray)
                        {
                            var plantillaParrafoVariable = listaVariablesAnteriores.Where(item => item.CodigoVariable == new Guid(contenido.Key)).FirstOrDefault();
                            if (plantillaParrafoVariable == null)
                            {
                                PlantillaRequerimientoParrafoVariableRequest dataVariable = new PlantillaRequerimientoParrafoVariableRequest();
                                dataVariable.CodigoPlantillaParrafo = entidadSincronizar.CodigoPlantillaParrafo.ToString();
                                dataVariable.CodigoVariable = contenido.Key;
                                dataVariable.Orden = Convert.ToInt16(orden);
                                PlantillaRequerimientoParrafoVariableEntity entidadPlantillaParrafoVariable = PlantillaRequerimientoParrafoVariableAdapter.RegistrarPlantillaParrafoVariable(dataVariable);

                                plantillaRequerimientoParrafoVariableEntityRepository.Insertar(entidadPlantillaParrafoVariable);
                            }
                            else
                            {
                                var entidadSincronizarVariable = plantillaRequerimientoParrafoVariableEntityRepository.GetById(plantillaParrafoVariable.CodigoPlantillaParrafoVariable);
                                entidadSincronizarVariable.Orden = Convert.ToInt16(orden);

                                plantillaRequerimientoParrafoVariableEntityRepository.Editar(entidadSincronizarVariable);
                            }
                            orden++;
                        }
                    }

                    plantillaRequerimientoParrafoEntityRepository.GuardarCambios();
                    plantillaRequerimientoParrafoVariableEntityRepository.GuardarCambios();
                    resultado.Result = data;
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la búsqueda de plantilla párrafo variable
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de plantilla párrafo variable</returns>
        public ProcessResult<List<PlantillaRequerimientoParrafoVariableResponse>> BuscarPlantillaParrafoVariableCodigoPlantillaParrafo(PlantillaRequerimientoParrafoVariableRequest filtro)
        {
            ProcessResult<List<PlantillaRequerimientoParrafoVariableResponse>> resultado = new ProcessResult<List<PlantillaRequerimientoParrafoVariableResponse>>();

            try
            {
                if (string.IsNullOrEmpty(filtro.CodigoPlantillaParrafo))
                {
                    filtro.CodigoPlantillaParrafo = Guid.Empty.ToString();
                }
                List<PlantillaRequerimientoParrafoVariableLogic> listado = plantillaRequerimientoLogicRepository.BuscarPlantillaParrafoVariableCodigoPlantillaParrafo(new Guid(filtro.CodigoPlantillaParrafo));

                resultado.Result = new List<PlantillaRequerimientoParrafoVariableResponse>();
                foreach (var registro in listado)
                {
                    var plantillaParrafoVariable = PlantillaRequerimientoParrafoVariableAdapter.ObtenerPlantillaParrafoVariable(registro);
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
        public ProcessResult<List<PlantillaRequerimientoNotaPieResponse>> BuscarNotasPiePorPlantilla(PlantillaRequerimientoNotaPieRequest filtro)
        {
            ProcessResult<List<PlantillaRequerimientoNotaPieResponse>> resultado = new ProcessResult<List<PlantillaRequerimientoNotaPieResponse>>();
            var listaNotas = new List<PlantillaRequerimientoNotaPieResponse>();
            try
            {
                Guid? codigoPlantillaNotaPie = filtro.CodigoPlantillaNotaPie != null ? new Guid(filtro.CodigoPlantillaNotaPie) : (Guid?)null;
                Guid? codigoPlantilla = filtro.CodigoPlantilla != null ? new Guid(filtro.CodigoPlantilla) : (Guid?)null;
                var listado = plantillaRequerimientoLogicRepository.BuscarNotasPiePorPlantilla(codigoPlantillaNotaPie, codigoPlantilla, filtro.NumeroPagina, filtro.RegistrosPagina);

                foreach (var item in listado)
                {
                    var nota = new PlantillaRequerimientoNotaPieResponse();
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
                resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(e);
            }
            return resultado;
        }


        /// <summary>
        /// Registra o actualiza una nota al pie
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarNotaPie(PlantillaRequerimientoNotaPieRequest data)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            Dictionary<string, string> contenidoArray = new Dictionary<string, string>();

            try
            {
                var listado = plantillaRequerimientoLogicRepository.BuscarNotasPiePorPlantilla(null, new Guid(data.CodigoPlantilla), 1, -1);

                var existeOrden = listado.Any(n => n.Orden == data.Orden);

                if (existeOrden && string.IsNullOrEmpty(data.CodigoPlantillaNotaPie))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(MensajesSistema.PlantillaNotaOrdenExiste);
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
                        var entidad = new PlantillaRequerimientoNotaPieEntity();
                        entidad.CodigoPlantillaNotaPie = Guid.NewGuid();
                        entidad.CodigoPlantilla = new Guid(data.CodigoPlantilla);
                        entidad.Orden = Convert.ToByte(data.Orden);
                        entidad.Titulo = data.Titulo;
                        entidad.Contenido = data.Contenido;

                        plantillaRequerimientoNotaPieEntityRepository.Insertar(entidad);
                    }
                    else
                    {
                        var entidadSincronizar = plantillaRequerimientoNotaPieEntityRepository.GetById(new Guid(data.CodigoPlantillaNotaPie));
                        entidadSincronizar.Orden = (byte)data.Orden;
                        entidadSincronizar.Titulo = data.Titulo;
                        entidadSincronizar.Contenido = data.Contenido;

                        plantillaRequerimientoNotaPieEntityRepository.Editar(entidadSincronizar);
                    }

                    plantillaRequerimientoNotaPieEntityRepository.GuardarCambios();
                    resultado.Result = data;
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(e);
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
                    plantillaRequerimientoNotaPieEntityRepository.Eliminar(codigo);
                }

                resultado.Result = plantillaRequerimientoNotaPieEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<PlantillaRequerimientoService>(e);
            }

            return resultado;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.Service.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using Pe.Stracon.Politicas.Infraestructura.Core.CommandContract.General;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using Pe.Stracon.Politicas.Aplicacion.Adapter.General;
using Pe.Stracon.PoliticasCross.Core.Exception;
using System.Transactions;
using Pe.Stracon.PoliticasCross.Core.Base;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;
using System.Data;

namespace Pe.Stracon.Politicas.Aplicacion.Service.General
{
    /// <summary>
    /// Implementación base generica de servicios de aplicación
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroValorService : GenericService, IParametroValorService
    {
        /// <summary>
        /// Repositorio de parametro valor logic
        /// </summary>
        public IParametroValorLogicRepository parametroValorLogicRepository { get; set; }

        /// <summary>
        /// Service de Parametro Sección
        /// </summary>
        public IParametroSeccionService parametroSeccionService { get; set; }

        /// <summary>
        /// Service de Parametro
        /// </summary>
        public IParametroService parametroService { get; set; }

        /* JCP: 16/01/2018
         * Metodo Original para carga de parametros se reemplazo la logica 
         * por BuscarParametroValor_Optimizado que hace la carga de parametros
         * en memoria para luego utilizarlas
        /// <summary>
        /// Realiza la busqueda de Parametro Valor
        /// </summary>
        /// <param name="filtro">Filtro de Parametro Valor</param>
        /// <returns>Listado de parametro valor</returns>
        public ProcessResult<List<ParametroValorResponse>> BuscarParametroValor(ParametroValorRequest filtro)
        {
            ProcessResult<List<ParametroValorResponse>> resultado = new ProcessResult<List<ParametroValorResponse>>();

            try
            {
                List<ParametroValorLogic> listado = parametroValorLogicRepository.BuscarParametroValor(
                    filtro.CodigoParametro,
                    filtro.IndicadorEmpresa,
                    (filtro.CodigoEmpresa != null ? new Guid(filtro.CodigoEmpresa) : (Guid?)null),
                    (filtro.CodigoSistema != null ? new Guid(filtro.CodigoSistema) : (Guid?)null),
                    filtro.CodigoIdentificador,
                    filtro.TipoParametro,
                    filtro.CodigoSeccion,
                    filtro.CodigoValor,
                    filtro.Valor,
                    filtro.EstadoRegistro);

                var listaParametroValor = new List<ParametroValorResponse>();
                ParametroValorResponse parametroValor = new ParametroValorResponse();
                parametroValor.RegistroCadena = new Dictionary<string, string>();
                parametroValor.RegistroObjeto = new Dictionary<string, object>();

                for (var iterator = 0; iterator < listado.Count; iterator++)
                {
                    var itemValue = listado[iterator];
                    parametroValor.Valor = itemValue.Valor;
                    parametroValor.CodigoSeccion = itemValue.CodigoSeccion;

                    var listSecciones = parametroSeccionService.BuscarParametroSeccion(new ParametroSeccionRequest()
                    {
                        CodigoParametro = itemValue.CodigoParametro
                    }).Result;

                    var seccionActual = listSecciones.Where(itemSeccion => itemSeccion.CodigoSeccion == itemValue.CodigoSeccion).FirstOrDefault();
                    if (seccionActual != null)
                    {
                        string valorTexto = ParametroValorAdapter.ObtenerParametroValorTexto(itemValue.CodigoTipoDato, itemValue.Valor);
                        object valorObject = ParametroValorAdapter.ObtenerParametroValorObjeto(itemValue.CodigoTipoDato, itemValue.Valor);

                        //Asginación de la Sección con su respectivo Valor Original
                        parametroValor.RegistroCadena.Add(itemValue.CodigoSeccion.ToString(), valorTexto);
                        parametroValor.RegistroObjeto.Add(itemValue.CodigoSeccion.ToString(), valorObject);

                        //Asginación de la Sección con su respectivo Valor Relacionado
                        if (seccionActual.CodigoParametroRelacionado != null && seccionActual.CodigoSeccionRelacionado != null && seccionActual.CodigoSeccionRelacionadoMostrar != null)
                        {
                            var parametroValorRelacionado = parametroValorLogicRepository.BuscarParametroValor(seccionActual.CodigoParametroRelacionado, null, null, null, null, null, null, null, null, DatosConstantes.EstadoRegistro.Activo);

                            var codigoValorRelacionado = parametroValorRelacionado.Where(itemWhere => itemWhere.CodigoSeccion == seccionActual.CodigoSeccionRelacionado && itemWhere.Valor == valorTexto).Select(itemSelect => itemSelect.CodigoValor).FirstOrDefault();

                            var valorRelacionado = parametroValorRelacionado.Where(itemWhere => itemWhere.CodigoValor == codigoValorRelacionado && itemWhere.CodigoSeccion == seccionActual.CodigoSeccionRelacionadoMostrar).FirstOrDefault() ?? new ParametroValorLogic();
                            object valorObjectRelacionado = ParametroValorAdapter.ObtenerParametroValorObjeto(valorRelacionado.CodigoTipoDato, valorRelacionado.Valor);
                            string valorTextoRelacionado = ParametroValorAdapter.ObtenerParametroValorTexto(valorRelacionado.CodigoTipoDato, valorRelacionado.Valor);

                            parametroValor.RegistroCadena.Add("-" + itemValue.CodigoSeccion.ToString(), valorTextoRelacionado);
                            parametroValor.RegistroObjeto.Add("-" + itemValue.CodigoSeccion.ToString(), valorObjectRelacionado);
                        }


                        //Asginación del Estado de Registro
                        if (parametroValor.EstadoRegistro == null || parametroValor.EstadoRegistro == DatosConstantes.EstadoRegistro.Inactivo)
                        {
                            parametroValor.EstadoRegistro = itemValue.EstadoRegistro;
                        }

                        //Añade el registro en la Lista de Parametros según su quiebre
                        if (iterator == listado.Count - 1 || itemValue.CodigoValor != listado[iterator + 1].CodigoValor)
                        {
                            parametroValor.CodigoValor = itemValue.CodigoValor;
                            parametroValor.CodigoIdentificador = itemValue.CodigoIdentificador;
                            parametroValor.CodigoParametro = itemValue.CodigoParametro;

                            var seccionesFaltante = listSecciones.Where(itemWhere => !parametroValor.RegistroCadena.Any(itemAny => itemAny.Key == itemWhere.CodigoSeccion.ToString())).ToList();

                            foreach (var seccion in seccionesFaltante)
                            {
                                //Setear la Sección con su respectivo Valor
                                parametroValor.RegistroCadena.Add(seccion.CodigoSeccion.ToString(), null);

                                parametroValor.RegistroObjeto.Add(seccion.CodigoSeccion.ToString(), null);
                            }

                            listaParametroValor.Add(parametroValor);
                            //Limpiar variable
                            parametroValor = new ParametroValorResponse();
                            parametroValor.RegistroCadena = new Dictionary<string, string>();
                            parametroValor.RegistroObjeto = new Dictionary<string, object>();
                        }
                    }
                }

                resultado.Result = listaParametroValor;
            }
            catch (Exception e)
            {
                resultado.Result = new List<ParametroValorResponse>();
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ParametroValorService>(e);
            }

            return resultado;
        }*/

        /// <summary>
        /// Realiza la busqueda de Parametro Valor
        /// </summary>
        /// <param name="filtro">Filtro de Parametro Valor</param>
        /// <returns>Listado de parametro valor</returns>
        public ProcessResult<List<ParametroValorResponse>> BuscarParametroValor(ParametroValorRequest filtro)
        {
            ProcessResult<List<ParametroValorResponse>> resultado = new ProcessResult<List<ParametroValorResponse>>();

            try
            {
                List<ParametroValorLogic> listado = parametroValorLogicRepository.BuscarParametroValor(
                    filtro.CodigoParametro,
                    filtro.IndicadorEmpresa,
                    (filtro.CodigoEmpresa != null ? new Guid(filtro.CodigoEmpresa) : (Guid?)null),
                    (filtro.CodigoSistema != null ? new Guid(filtro.CodigoSistema) : (Guid?)null),
                    filtro.CodigoIdentificador,
                    filtro.TipoParametro,
                    filtro.CodigoSeccion,
                    filtro.CodigoValor,
                    filtro.Valor,
                    filtro.EstadoRegistro);

                var listaParametroValor = new List<ParametroValorResponse>();

                int? codigoParametro = null;

                if (listado.Count > 0)
                {
                    codigoParametro = listado.FirstOrDefault().CodigoParametro;
                }

                var listSecciones = parametroSeccionService.BuscarParametroSeccion(new ParametroSeccionRequest()
                {
                    CodigoParametro = codigoParametro
                }).Result;


                List<ParametroValorLogic> listaparametroValorRelacionado = new List<ParametroValorLogic>();
                List<int> listaParametrosCargados = new List<int>();

                foreach (ParametroSeccionResponse seccionActual in listSecciones)
                {
                    //para ver si tiene parametro relacionado
                    //tambien vemos que no lo tengamos cargado
                    if (seccionActual.CodigoParametroRelacionado != null &&
                        !listaParametrosCargados.Contains(seccionActual.CodigoParametroRelacionado.Value))
                    {
                        var parametroValorRelacionado = parametroValorLogicRepository.BuscarParametroValor(seccionActual.CodigoParametroRelacionado, null, null, null, null, null, null, null, null, DatosConstantes.EstadoRegistro.Activo);

                        listaparametroValorRelacionado.AddRange(parametroValorRelacionado);
                    }
                }


                ParametroValorResponse parametroValor = new ParametroValorResponse();
                parametroValor.RegistroCadena = new Dictionary<string, string>();
                parametroValor.RegistroObjeto = new Dictionary<string, object>();

                for (var iterator = 0; iterator < listado.Count; iterator++)
                {
                    var itemValue = listado[iterator];



                    var seccionActual = listSecciones.Where(itemSeccion => itemSeccion.CodigoSeccion == itemValue.CodigoSeccion).FirstOrDefault();
                    if (seccionActual != null)
                    {
                        string valorTexto = ParametroValorAdapter.ObtenerParametroValorTexto(itemValue.CodigoTipoDato, itemValue.Valor);
                        object valorObject = ParametroValorAdapter.ObtenerParametroValorObjeto(itemValue.CodigoTipoDato, itemValue.Valor);

                        //Asginación de la Sección con su respectivo Valor Original
                        parametroValor.RegistroCadena.Add(itemValue.CodigoSeccion.ToString(), valorTexto);
                        parametroValor.RegistroObjeto.Add(itemValue.CodigoSeccion.ToString(), valorObject);

                        //Asginación de la Sección con su respectivo Valor Relacionado
                        if (seccionActual.CodigoParametroRelacionado != null && seccionActual.CodigoSeccionRelacionado != null && seccionActual.CodigoSeccionRelacionadoMostrar != null)
                        {
                            var codigoValorRelacionado = listaparametroValorRelacionado.Where(itemWhere => itemWhere.CodigoSeccion == seccionActual.CodigoSeccionRelacionado && itemWhere.Valor == valorTexto).Select(itemSelect => itemSelect.CodigoValor).FirstOrDefault();

                            var valorRelacionado = listaparametroValorRelacionado.Where(itemWhere => itemWhere.CodigoValor == codigoValorRelacionado && itemWhere.CodigoSeccion == seccionActual.CodigoSeccionRelacionadoMostrar).FirstOrDefault() ?? new ParametroValorLogic();
                            object valorObjectRelacionado = ParametroValorAdapter.ObtenerParametroValorObjeto(valorRelacionado.CodigoTipoDato, valorRelacionado.Valor);
                            string valorTextoRelacionado = ParametroValorAdapter.ObtenerParametroValorTexto(valorRelacionado.CodigoTipoDato, valorRelacionado.Valor);

                            parametroValor.RegistroCadena.Add("-" + itemValue.CodigoSeccion.ToString(), valorTextoRelacionado);
                            parametroValor.RegistroObjeto.Add("-" + itemValue.CodigoSeccion.ToString(), valorObjectRelacionado);
                        }


                        //Asginación del Estado de Registro
                        if (parametroValor.EstadoRegistro == null || parametroValor.EstadoRegistro == DatosConstantes.EstadoRegistro.Inactivo)
                        {
                            parametroValor.EstadoRegistro = itemValue.EstadoRegistro;
                        }

                        //Añade el registro en la Lista de Parametros según su quiebre
                        if (iterator == listado.Count - 1 || itemValue.CodigoValor != listado[iterator + 1].CodigoValor)
                        {
                            parametroValor.CodigoValor = itemValue.CodigoValor;
                            parametroValor.CodigoIdentificador = itemValue.CodigoIdentificador;
                            parametroValor.CodigoParametro = itemValue.CodigoParametro;

                            var seccionesFaltante = listSecciones.Where(itemWhere => !parametroValor.RegistroCadena.Any(itemAny => itemAny.Key == itemWhere.CodigoSeccion.ToString())).ToList();

                            foreach (var seccion in seccionesFaltante)
                            {
                                //Setear la Sección con su respectivo Valor
                                parametroValor.RegistroCadena.Add(seccion.CodigoSeccion.ToString(), null);

                                parametroValor.RegistroObjeto.Add(seccion.CodigoSeccion.ToString(), null);
                            }

                            listaParametroValor.Add(parametroValor);
                            //Limpiar variable
                            parametroValor = new ParametroValorResponse();
                            parametroValor.RegistroCadena = new Dictionary<string, string>();
                            parametroValor.RegistroObjeto = new Dictionary<string, object>();
                        }
                    }
                }

                resultado.Result = listaParametroValor;
            }
            catch (Exception e)
            {
                resultado.Result = new List<ParametroValorResponse>();
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ParametroValorService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la busqueda de Parametro Valor
        /// </summary>
        /// <param name="filtro">Filtro de Parametro Valor</param>
        /// <returns>Listado de parametro valor dinamico</returns>
        public ProcessResult<List<dynamic>> BuscarParametroValorDinamico(ParametroValorRequest filtro)
        {
            #region Antiguo
            //var parametroValor = this.BuscarParametroValor(filtro);
            //var listaDinamica = new List<dynamic>();
            //parametroValor.Result.ForEach(p =>
            //{
            //    var expandoObject = new ExpandoObject();
            //    var expandoDictionary = (IDictionary<string, object>)expandoObject;

            //    if (p.RegistroObjeto != null)
            //    {
            //        foreach (var campo in p.RegistroObjeto)
            //        {
            //            expandoDictionary.Add("Atributo" + campo.Key, campo.Value);
            //        }
            //        listaDinamica.Add((dynamic)expandoObject);
            //    }
            //});
            #endregion
            #region Mejorado
            var listaDinamica = new List<dynamic>();
            DataTable listado = parametroValorLogicRepository.BuscarParametroValorMejorado(
                       filtro.CodigoParametro,
                       filtro.IndicadorEmpresa,
                       (filtro.CodigoEmpresa != null ? new Guid(filtro.CodigoEmpresa) : (Guid?)null),
                       (filtro.CodigoSistema != null ? new Guid(filtro.CodigoSistema) : (Guid?)null),
                       filtro.CodigoIdentificador,
                       filtro.TipoParametro,
                       filtro.CodigoSeccion,
                       filtro.CodigoValor,
                       filtro.Valor,
                       filtro.EstadoRegistro);

            foreach (DataRow row in listado.Rows)
            {
                int key = 1;
                var expandoObject = new ExpandoObject();
                var expandoDictionary = (IDictionary<string, object>)expandoObject;
                foreach (DataColumn column in listado.Columns)
                {
                    expandoDictionary.Add("Atributo" + key.ToString(), row[column]);
                    key += 1;
                }
                listaDinamica.Add((dynamic)expandoObject);
            }
            #endregion
            var resultado = new ProcessResult<List<dynamic>>();
            resultado.Result = listaDinamica;
            return resultado;
        }

        /// <summary>
        /// Realiza el registro de un de Parametro Valor
        /// </summary>
        /// <param name="filtro">Parametro Valor a Registrar</param>
        /// <returns>Indicador de Error</returns>
        public ProcessResult<string> RegistrarParametroValor(ParametroValorRequest filtro)
        {
            string result = "0";
            var resultadoProceso = new ProcessResult<string>();
            try
            {
                var listSecciones = parametroSeccionService.BuscarParametroSeccion(new ParametroSeccionRequest()
                {
                    CodigoParametro = filtro.CodigoParametro
                }).Result;

                int codigoValor = 0;
                bool isActualizacion = false;

                if (filtro.CodigoValor == null)
                {
                    var ultimoParametroValor = BuscarParametroValor(new ParametroValorRequest()
                    {
                        CodigoParametro = filtro.CodigoParametro,
                        EstadoRegistro = null
                    }).Result.OrderBy(itemOrderBy => itemOrderBy.CodigoValor).LastOrDefault();

                    if (ultimoParametroValor != null)
                    {
                        codigoValor = ultimoParametroValor.CodigoValor + 1;
                    }
                    else
                    {
                        codigoValor = 1;
                    }
                }
                else
                {
                    codigoValor = (int)filtro.CodigoValor;
                    isActualizacion = true;
                }

                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        foreach (var item in filtro.RegistroCadena)
                        {
                            bool isSeccionExistente = false;

                            var seccionActual = listSecciones.Where(itemWhere => itemWhere.CodigoSeccion.ToString() == item.Key).FirstOrDefault();

                            ParametroValorResponse parametroValorActual = null;

                            if (isActualizacion)
                            {
                                parametroValorActual = BuscarParametroValor(new ParametroValorRequest()
                                {
                                    CodigoParametro = filtro.CodigoParametro,
                                    CodigoSeccion = seccionActual.CodigoSeccion,
                                    CodigoValor = codigoValor
                                }).Result.FirstOrDefault();

                                isSeccionExistente = (parametroValorActual != null) ? true : false;
                            }

                            string value = "";

                            switch (seccionActual.CodigoTipoDato)
                            {
                                case "ENT":
                                    value = item.Value;
                                    break;
                                case "DEC":
                                    value = item.Value.Replace(',', '.');
                                    break;
                                case "FEC":
                                    value = item.Value;
                                    break;
                                default:
                                    value = item.Value;
                                    break;
                            }

                            ParametroValorLogic logic = new ParametroValorLogic();
                            logic.CodigoParametro = (int)filtro.CodigoParametro;
                            logic.CodigoSeccion = seccionActual.CodigoSeccion;
                            logic.CodigoValor = codigoValor;
                            logic.Valor = value;

                            if (!isActualizacion || !isSeccionExistente)
                            {
                                logic.EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;

                                if (parametroValorLogicRepository.RegistrarParametroValor(logic) <= 0)
                                {
                                    throw new Exception();
                                }
                            }
                            else
                            {
                                logic.EstadoRegistro = null;

                                if (parametroValorLogicRepository.ModificarParametroValor(logic) <= 0)
                                {
                                    throw new Exception();
                                }
                            }
                        }

                        scope.Complete();

                        resultadoProceso.Result = "1";
                        resultadoProceso.IsSuccess = true;
                    }
                    catch (Exception e)
                    {
                        scope.Dispose();
                        throw e;
                    }
                }
            }
            catch (Exception)
            {
                result = "-1";
                resultadoProceso.Result = result;
                resultadoProceso.IsSuccess = false;
            }
            return resultadoProceso;
        }

        /// <summary>
        /// Realiza el eliminar de un de Parametro Valor
        /// </summary>
        /// <param name="filtro">Parametro Valor a Eliminar</param>
        /// <returns>Indicador de Error</returns>
        public ProcessResult<string> EliminarParametroValor(ParametroValorRequest filtro)
        {
            string result = "0";
            var resultadoProceso = new ProcessResult<string>();
            try
            {
                var parametroActual = parametroService.BuscarParametro(new ParametroRequest()
                {
                    CodigoParametro = filtro.CodigoParametro
                }).Result.FirstOrDefault();

                if (!parametroActual.IndicadorPermiteEliminar)
                {
                    result = "2";
                    resultadoProceso.Result = result;
                    resultadoProceso.IsSuccess = false;
                    return resultadoProceso;
                }
                var parametroValorActual = BuscarParametroValor(new ParametroValorRequest()
                {
                    CodigoParametro = filtro.CodigoParametro,
                    CodigoValor = filtro.CodigoValor
                }).Result.FirstOrDefault();

                foreach (var item in parametroValorActual.RegistroCadena)
                {
                    ParametroValorLogic logic = new ParametroValorLogic();
                    logic.CodigoParametro = parametroValorActual.CodigoParametro;
                    logic.CodigoSeccion = Convert.ToInt32(item.Key);
                    logic.CodigoValor = parametroValorActual.CodigoValor;
                    logic.Valor = null;
                    logic.EstadoRegistro = DatosConstantes.EstadoRegistro.Inactivo;

                    if (parametroValorLogicRepository.ModificarParametroValor(logic) <= 0)
                    {
                        throw new Exception();
                    }
                }

                resultadoProceso.Result = "1";
                resultadoProceso.IsSuccess = true;
            }
            catch (Exception)
            {
                result = "-1";
                resultadoProceso.Result = result;
                resultadoProceso.IsSuccess = false;
            }
            return resultadoProceso;
        }

        /// <summary>
        /// Realiza el eliminar de un de Parametro Valor
        /// </summary>
        /// <param name="filtro">Lista de Parametro Valor a Eliminar</param>
        /// <returns>Indicador de Error</returns>
        public ProcessResult<string> EliminarMasivoParametroValor(List<ParametroValorRequest> filtro)
        {
            string result = "0";
            var resultadoProceso = new ProcessResult<string>();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    try
                    {
                        foreach (var item in filtro)
                        {
                            var resultItem = EliminarParametroValor(item);

                            if (!resultItem.IsSuccess)
                            {
                                throw new Exception();
                            }
                        }
                        scope.Complete();
                    }
                    catch (Exception e)
                    {
                        scope.Dispose();
                        throw e;
                    }
                }

                resultadoProceso.Result = "1";
                resultadoProceso.IsSuccess = true;
            }
            catch (Exception)
            {
                result = "-1";
                resultadoProceso.Result = result;
                resultadoProceso.IsSuccess = false;
            }
            return resultadoProceso;
        }
    }
}

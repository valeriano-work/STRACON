using System;
using System.Collections.Generic;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.Service.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Cross.Core;
using Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General;
using Pe.Stracon.PoliticasCross.Core.Exception;
using Pe.Stracon.Politicas.Aplicacion.Adapter.General;
using Pe.Stracon.Politicas.Infraestructura.Core.CommandContract.General;

namespace Pe.Stracon.Politicas.Aplicacion.Service.General
{
    /// <summary>
    /// Implementación base generica de servicios de aplicación
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroSeccionService : GenericService, IParametroSeccionService
    {
        /// <summary>
        /// Repositorio de parametro seccion logic
        /// </summary>
        public IParametroSeccionLogicRepository parametroSeccionLogicRepository { get; set; }
        /// <summary>
        /// Repositorio de parametro sección
        /// </summary>
        public IParametroSeccionEntityRepository parametroSeccionEntityRepository { get; set; }

        /// <summary>
        /// Realiza la busqueda de Sección Parámetro
        /// </summary>
        /// <param name="filtro">Filtro de Sección Parámetro</param>
        /// <returns>Listado de Parámetro Sección</returns>
        public ProcessResult<List<ParametroSeccionResponse>> BuscarParametroSeccion(ParametroSeccionRequest filtro)
        {
            ProcessResult<List<ParametroSeccionResponse>> resultado = new ProcessResult<List<ParametroSeccionResponse>>();

            try
            {
                var listado = parametroSeccionLogicRepository.BuscarParametroSeccion(filtro.CodigoParametro, filtro.CodigoSeccion, filtro.Nombre, filtro.CodigoTipoDato, filtro.IndicadorPermiteModificar, filtro.IndicadorObligatorio, filtro.IndicadorSistema, filtro.EstadoRegistro);
                var listaParametroSeccion = new List<ParametroSeccionResponse>();
                foreach(var item in listado)
                {
                    listaParametroSeccion.Add(ParametroSeccionAdapter.ObtenerParametroSeccionResponse(item));
                }
                resultado.Result = listaParametroSeccion;
                resultado.IsSuccess = true;
            }
            catch (Exception e)
            {
                resultado.Result = new List<ParametroSeccionResponse>();
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ParametroValorService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza el registro de un Parámetro Sección
        /// </summary>
        /// <param name="filtro">Parámetro Sección a Registrar</param>
        /// <returns>Indicador de Error</returns>
        public ProcessResult<string> RegistrarParametroSeccion(ParametroSeccionRequest filtro)
        {
            string result = "0";
            var resultadoProceso = new ProcessResult<string>();
            try
            {
                if (filtro.CodigoParametro == null)
                {
                    throw new Exception();
                }

                var seccionRepetida = BuscarParametroSeccion(new ParametroSeccionRequest()
                {
                    CodigoParametro = filtro.CodigoParametro,
                    Nombre = filtro.Nombre
                }).Result.Where(item => filtro.CodigoSeccion == null || item.CodigoSeccion != filtro.CodigoSeccion).FirstOrDefault();

                if (seccionRepetida != null)
                {
                    result = "2";
                    resultadoProceso.Result = result;
                    resultadoProceso.IsSuccess = true;

                    return resultadoProceso;
                }
                if (filtro.CodigoSeccion == null)
                {
                    var parametroSeccionUltimo = BuscarParametroSeccion(new ParametroSeccionRequest() { 
                        CodigoParametro = filtro.CodigoParametro,
                        EstadoRegistro = null }).Result.OrderByDescending(item => item.CodigoSeccion).FirstOrDefault();
                    filtro.CodigoSeccion = parametroSeccionUltimo != null ? parametroSeccionUltimo.CodigoSeccion + 1 : 1;

                    parametroSeccionEntityRepository.Insertar(ParametroSeccionAdapter.ObtenerParametroSeccionEntity(filtro));
                }
                else
                {
                    var entity = ParametroSeccionAdapter.ObtenerParametroSeccionEntity(filtro);
                    var entityActual = parametroSeccionEntityRepository.GetById(filtro.CodigoParametro,filtro.CodigoSeccion);

                    entityActual.Nombre = entity.Nombre;
                    entityActual.CodigoTipoDato = entity.CodigoTipoDato;
                    entityActual.IndicadorPermiteModificar = entity.IndicadorPermiteModificar;
                    entityActual.IndicadorObligatorio = entity.IndicadorObligatorio;
                    entityActual.CodigoParametroRelacionado = entity.CodigoParametroRelacionado;
                    entityActual.CodigoSeccionRelacionado = entity.CodigoSeccionRelacionado;
                    entityActual.CodigoSeccionRelacionadoMostrar = entity.CodigoSeccionRelacionadoMostrar;                    

                    parametroSeccionEntityRepository.Editar(entityActual);                    
                }

                parametroSeccionEntityRepository.GuardarCambios();
                resultadoProceso.IsSuccess = true;
            }
            catch (Exception e)
            {
                result = "-1";
                resultadoProceso.Result = result;
                resultadoProceso.IsSuccess = false;
                resultadoProceso.Exception = new ApplicationLayerException<ParametroValorService>(e);
            }
            return resultadoProceso;
        }

        /// <summary>
        /// Realiza la eliminación de una sección de parámetro
        /// </summary>
        /// <param name="filtro">Sección a Eliminar</param>
        /// <returns>Indicador de Error</returns>
        public ProcessResult<string> EliminarParametroSeccion(ParametroSeccionRequest filtro, bool autoGuardado = true)
        {
            string result = "0";
            var resultadoProceso = new ProcessResult<string>();
            try
            {
                parametroSeccionEntityRepository.Eliminar(filtro.CodigoParametro,filtro.CodigoSeccion);

                if (autoGuardado)
                {
                    parametroSeccionEntityRepository.GuardarCambios();
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
        /// Realiza la eliminación masiva de secciones de parámetro
        /// </summary>
        /// <param name="filtro">Lista de secciones a Eliminar</param>
        /// <returns>Indicador de Error</returns>
        public ProcessResult<string> EliminarMasivoParametroSeccion(List<ParametroSeccionRequest> filtro)
        {
            string result = "0";
            var resultadoProceso = new ProcessResult<string>();
            try
            {
                foreach (var item in filtro)
                {
                    var resultItem = EliminarParametroSeccion(item,false);

                    if (!resultItem.IsSuccess)
                    {
                        throw new Exception();
                    }
                }
                parametroSeccionEntityRepository.GuardarCambios();
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
using System;
using System.Linq;
using System.Collections.Generic;
using Pe.Stracon.Politicas.Aplicacion.Adapter.General;
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.Service.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Cross.Core;
using Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General;
using Pe.Stracon.PoliticasCross.Core.Exception;
using Pe.Stracon.Politicas.Infraestructura.Core.CommandContract.General;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;

namespace Pe.Stracon.Politicas.Aplicacion.Service.General
{
    /// <summary>
    /// Implementación base generica de servicios de aplicación
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroService : GenericService, IParametroService
    {
        /// <summary>
        /// Repositorio de parametro seccion logic
        /// </summary>
        public IParametroLogicRepository parametroLogicRepository { get; set; }

        /// <summary>
        /// Repositorio de parametro entidad
        /// </summary>
        public IParametroEntityRepository parametroEntityRepository { get; set; }

        /// <summary>
        /// Realiza la busqueda de Parámetro
        /// </summary>
        /// <param name="filtro">Filtro de Parametro</param>
        /// <returns>Listado de Parametro</returns>
        public ProcessResult<List<ParametroResponse>> BuscarParametro(ParametroRequest filtro)
        {
            ProcessResult<List<ParametroResponse>> resultado = new ProcessResult<List<ParametroResponse>>();

            try
            {
                var listado = parametroLogicRepository.BuscarParametro(
                    filtro.CodigoParametro, 
                    filtro.IndicadorEmpresa,
                    (filtro.CodigoEmpresa != null ? new Guid(filtro.CodigoEmpresa) : (Guid?)null),
                    (filtro.CodigoSistema != null ? new Guid(filtro.CodigoSistema) : (Guid?)null), 
                    filtro.CodigoIdentificador, 
                    filtro.TipoParametro,
                    filtro.Nombre, 
                    filtro.Descripcion, 
                    filtro.IndicadorPermiteAgregar,
                    filtro.IndicadorPermiteModificar,
                    filtro.IndicadorPermiteEliminar, 
                    filtro.EstadoRegistro);

                var listaParametro = new List<ParametroResponse>();
                foreach(var item in listado)
                {
                    listaParametro.Add(ParametroAdapter.ObtenerParametroResponse(item));
                }
                resultado.Result = listaParametro;
                resultado.IsSuccess = true;
            }
            catch (Exception e)
            {
                resultado.Result = new List<ParametroResponse>();
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ParametroService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza el registro de un Parámetro 
        /// </summary>
        /// <param name="filtro">Parametro a Registrar</param>
        /// <returns>Indicador de Error</returns>
        public ProcessResult<string> RegistrarParametro(ParametroRequest filtro)
        {
            string result = "0";
            var resultadoProceso = new ProcessResult<string>();
            try
            {          
                if (filtro.CodigoParametro == null)
                {
                    var parametroUltimo = BuscarParametro(new ParametroRequest() { EstadoRegistro = null }).Result.OrderByDescending(item => item.CodigoParametro).FirstOrDefault();
                    filtro.CodigoParametro = parametroUltimo != null ? parametroUltimo.CodigoParametro + 1 : 1;

                    parametroEntityRepository.Insertar(ParametroAdapter.ObtenerParametroEntity(filtro));
                }
                else
                {
                    var entity = ParametroAdapter.ObtenerParametroEntity(filtro);
                    var entityActual = parametroEntityRepository.GetById(filtro.CodigoParametro);

                    entityActual.IndicadorEmpresa = entity.IndicadorEmpresa;
                    entityActual.TipoParametro = entity.TipoParametro;
                    entityActual.CodigoSistema = entity.CodigoSistema;
                    entityActual.CodigoIdentificador = entity.CodigoIdentificador;
                    entityActual.Nombre = entity.Nombre;
                    entityActual.Descripcion = entity.Descripcion;
                    entityActual.IndicadorPermiteAgregar = entity.IndicadorPermiteAgregar;
                    entityActual.IndicadorPermiteModificar = entity.IndicadorPermiteModificar;
                    entityActual.IndicadorPermiteEliminar = entity.IndicadorPermiteEliminar;

                    parametroEntityRepository.Editar(entityActual);
                }

                parametroEntityRepository.GuardarCambios();
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
        /// Realiza la eliminación de un Parámetro
        /// </summary>
        /// <param name="filtro">Parametro Eliminar</param>
        /// <returns>Indicador de Error</returns>
        public ProcessResult<string> EliminarParametro(ParametroRequest filtro)
        {
            string result = "0";
            var resultadoProceso = new ProcessResult<string>();
            try
            {
                parametroEntityRepository.Eliminar(filtro.CodigoParametro);

                parametroEntityRepository.GuardarCambios();
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
    }
}
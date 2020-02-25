using Pe.Stracon.Politicas.Cross.Core;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.Service.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using Pe.Stracon.Politicas.Aplicacion.Adapter.General;
using System;
using System.Collections.Generic;
using System.Linq;
using Pe.Stracon.Politicas.Infraestructura.Core.CommandContract.General;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using System.Dynamic;
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;
using Pe.Stracon.PoliticasCross.Core.Exception;
using Pe.Stracon.Politicas.Aplicacion.Core.Message;

namespace Pe.Stracon.Politicas.Aplicacion.Service.General
{
    /// <summary>
    /// Implementación base generica de servicios de aplicación
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaService : GenericService, IUnidadOperativaService
    {
        /// <summary>
        /// Repositorio de manejo de unidad operativa logic
        /// </summary>
        public IUnidadOperativaLogicRepository unidadOperativaLogicRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de unidad operativa entity
        /// </summary>
        public IUnidadOperativaEntityRepository unidadOperativaEntityRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de unidad operativa entity staff
        /// </summary>
        public IUnidadOperativaStaffEntityRepository unidadOperativaStaffEntityRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de unidad operativa responsable entity
        /// </summary>
        public IUnidadOperativaUsuarioConsultaEntityRepository unidadOperativaResponsableEntityRepository { get; set; }

        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary>
        //public IParametroValorService parametroValorService { get; set; } 

        /// <summary>
        /// Servicio de parámetros de Politicas
        /// </summary>
        public IPoliticaService politicaService { get; set; }

        /// <summary>
        /// Realiza la busqueda de unidades operativas
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de unidad operativas encontrados</returns>
        public ProcessResult<List<UnidadOperativaResponse>> BuscarUnidadOperativa(FiltroUnidadOperativa filtro)
        {
            List<dynamic> resultadoNivel = null, resultadoTipo = null;
            ProcessResult<List<UnidadOperativaResponse>> resultado = new ProcessResult<List<UnidadOperativaResponse>>();
            try
            {
                resultadoNivel = politicaService.ListarNivelUnidadOperativaDinamico().Result;
                resultadoTipo = politicaService.ListarTipoUnidadOperativaDinamico().Result;
                Guid? unidadPadreIdentificador = filtro.UnidadSuperior != null ? new Guid(filtro.UnidadSuperior) : (Guid?)null;
                Guid? codigoUnidadOperativa = filtro.CodigoUnidadOperativa != null ? new Guid(filtro.CodigoUnidadOperativa) : (Guid?)null;
                List<UnidadOperativaLogic> listado = unidadOperativaLogicRepository.BuscarUnidadOperativa(codigoUnidadOperativa, filtro.Nombre, filtro.Nivel, unidadPadreIdentificador, filtro.Indicador, filtro.NumeroPagina, filtro.RegistrosPagina);
                resultado.Result = listado.Select(u => UnidadOperativaAdapter.ObtenerUnidadOperativaResponse(u, resultadoNivel, resultadoTipo)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Lista registros de Unidades Operativas a partir de códigos.
        /// </summary>
        /// <param name="listaCodigos">Lista de códigos de Unidades Operativas</param>
        /// <returns>Lista de unidades operativas</returns>
        public ProcessResult<List<UnidadOperativaResponse>> ListarUnidadesOperativas(List<Guid?> listaCodigos)
        {
            var resultado = new ProcessResult<List<UnidadOperativaResponse>>();

            try
            {
                List<UnidadOperativaLogic> listado = unidadOperativaLogicRepository.ListarUnidadesOperativas(listaCodigos);
                resultado.Result = listado.Select(u => UnidadOperativaAdapter.ObtenerUnidadOperativaResponse(u, null, null)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Lista las Unidades Operativas de una persona responsable.
        /// </summary>
        /// <param name="loginResponsable">Código de Identificación del Responsable</param>
        /// <returns>Lista unidades operativas</returns>
        public ProcessResult<List<UnidadOperativaResponse>> ListarUnidadesOperativasPorResponsable(string loginResponsable)
        {
            var resultado = new ProcessResult<List<UnidadOperativaResponse>>();

            try
            {
                List<UnidadOperativaLogic> listado = unidadOperativaLogicRepository.ListarUnidadesOperativasPorResponsable(loginResponsable);
                resultado.Result = listado.Select(u => UnidadOperativaAdapter.ObtenerUnidadOperativaResponse(u, null, null)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Lista las unidades operativas de un nivel superior al indicado como parámetro.
        /// </summary>
        /// <param name="codigoNivelUnidadOperativa">Codigo de Nivel de la Unidad Operativa</param>
        /// <returns>Listado de unidad operativas encontrados</returns>
        public ProcessResult<List<UnidadOperativaResponse>> BuscarUnidadOperativaNivelSuperior(string codigoNivelUnidadOperativa)
        {
            ProcessResult<List<UnidadOperativaResponse>> resultado = new ProcessResult<List<UnidadOperativaResponse>>();

            try
            {
                List<UnidadOperativaLogic> listado = unidadOperativaLogicRepository.BuscarUnidadOperativaNivelSuperior(codigoNivelUnidadOperativa);

                resultado.Result = listado.Select(u => UnidadOperativaAdapter.ObtenerUnidadOperativaResponse(u, null, null)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Registra una unidad operativa
        /// </summary>
        /// <param name="data">Parámetros de Búsqueda</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<DataUnidadOperativaRequest> RegistrarUnidadOperativa(DataUnidadOperativaRequest data)
        {
            ProcessResult<DataUnidadOperativaRequest> resultado = new ProcessResult<DataUnidadOperativaRequest>();
            try
            {
                UnidadOperativaEntity entidad = UnidadOperativaAdapter.ObtenerUnidadOperativaEntity(data);

                var resultadoRepetidoCI = unidadOperativaLogicRepository.RepiteCI(
                       data.CodigoIdentificacion
                );
                var resultadoRepetidoNombre = unidadOperativaLogicRepository.RepiteNombre(
                       data.Nombre
                );
                bool existeRepetidoCI = resultadoRepetidoCI.Any(e => e.CodigoUnidadOperativa != entidad.Codigo);
                bool existeRepetidoNombre = resultadoRepetidoNombre.Any(e => e.CodigoUnidadOperativa != entidad.Codigo);

                if (existeRepetidoCI || existeRepetidoNombre)
                {
                    resultado.IsSuccess = false;
                    if (existeRepetidoCI)
                    {
                        resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(MensajesSistema.UOCIExiste);
                    }
                    if (existeRepetidoNombre)
                    {
                        resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(MensajesSistema.UONombreExiste);
                    }
                }
                else
                {
                    if (data.CodigoUnidadOperativa == null)
                    {
                        entidad.CodigoPrimerRepresentanteOriginal = entidad.CodigoPrimerRepresentante;
                        entidad.CodigoSegundoRepresentanteOriginal = entidad.CodigoSegundoRepresentante;
                        entidad.CodigoTercerRepresentanteOriginal = entidad.CodigoTercerRepresentante;
                        entidad.CodigoCuartoRepresentanteOriginal = entidad.CodigoCuartoRepresentante;
                        unidadOperativaEntityRepository.Insertar(entidad);
                    }
                    else
                    {
                        var entidadEditar = unidadOperativaEntityRepository.GetById(entidad.Codigo);
                        entidadEditar.Nombre = entidad.Nombre;
                        entidadEditar.CodigoIdentificacion = entidad.CodigoIdentificacion;
                        entidadEditar.IndicadorActiva = entidad.IndicadorActiva;
                        entidadEditar.CodigoNivelJerarquia = entidad.CodigoNivelJerarquia;
                        entidadEditar.CodigoUnidadOperativaPadre = entidad.CodigoUnidadOperativaPadre;
                        entidadEditar.CodigoTipoUnidadOperativa = entidad.CodigoTipoUnidadOperativa;
                        entidadEditar.CodigoResponsable = entidad.CodigoResponsable ?? entidadEditar.CodigoResponsable;
                        entidadEditar.CodigoPrimerRepresentante = entidad.CodigoPrimerRepresentante ?? entidadEditar.CodigoPrimerRepresentante;
                        entidadEditar.CodigoSegundoRepresentante = entidad.CodigoSegundoRepresentante ?? entidadEditar.CodigoSegundoRepresentante;
                        entidadEditar.CodigoTercerRepresentante = entidad.CodigoTercerRepresentante ?? entidadEditar.CodigoTercerRepresentante;
                        entidadEditar.CodigoCuartoRepresentante = entidad.CodigoCuartoRepresentante ?? entidadEditar.CodigoCuartoRepresentante;
                        entidadEditar.CodigoPrimerRepresentanteOriginal = entidad.CodigoPrimerRepresentante ?? entidadEditar.CodigoPrimerRepresentante;
                        entidadEditar.CodigoSegundoRepresentanteOriginal = entidad.CodigoSegundoRepresentante ?? entidadEditar.CodigoSegundoRepresentante;
                        entidadEditar.CodigoTercerRepresentanteOriginal = entidad.CodigoTercerRepresentante ?? entidadEditar.CodigoTercerRepresentante;
                        entidadEditar.CodigoCuartoRepresentanteOriginal = entidad.CodigoCuartoRepresentante ?? entidadEditar.CodigoCuartoRepresentante;
                        entidadEditar.Direccion = entidad.Direccion ?? entidadEditar.Direccion;

                        unidadOperativaEntityRepository.Editar(entidadEditar);
                    }
                    unidadOperativaEntityRepository.GuardarCambios();
                    resultado.Result = data;
                }

            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }
            return resultado;
        }
        /// <summary>
        /// Metodo que elimina una Unidad Operativa
        /// </summary>
        /// <param name="data">Datos a Eliminar</param>
        /// <returns>Registro de proceso con resultado</returns>
        public ProcessResult<DataUnidadOperativaRequest> EliminarUnidadOperativa(DataUnidadOperativaRequest data)
        {
            ProcessResult<DataUnidadOperativaRequest> resultado = new ProcessResult<DataUnidadOperativaRequest>();

            try
            {
                var llaveEntidad = new Guid(data.CodigoUnidadOperativa);
                unidadOperativaEntityRepository.Eliminar(llaveEntidad);
                unidadOperativaEntityRepository.GuardarCambios();
                resultado.Result = data;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Método para eliminar masivamente Unidades Operativas.
        /// </summary>
        /// <param name="listaCodigos">Lista de Códigos de Unidades Operativas</param>
        /// <returns>Resultado de la Operación</returns>

        public ProcessResult<string> EliminarUnidadOperativaStaff(DataUnidadOperativaStaffRequest filtro)
        {
            string result = "0";
            var resultadoProceso = new ProcessResult<string>();
            try
            {
                unidadOperativaStaffEntityRepository.Eliminar(new Guid(filtro.CodigoUnidadOperativaStaff));

                unidadOperativaStaffEntityRepository.GuardarCambios();
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
        /// Método para eliminar masivamente Unidades Operativas.
        /// </summary>
        /// <param name="listaCodigos">Lista de Códigos de Unidades Operativas</param>
        /// <returns>Resultado de la Operación</returns>
        public ProcessResult<List<string>> EliminarUnidadesOperativas(List<string> listaCodigos)
        {
            var resultado = new ProcessResult<List<string>>();

            try
            {
                foreach (var codigo in listaCodigos)
                {
                    unidadOperativaEntityRepository.Eliminar(new Guid(codigo));
                }
                unidadOperativaEntityRepository.GuardarCambios();
                resultado.Result = listaCodigos;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la busqueda de unidades operativas staff
        /// </summary>
        /// <param name="nombre">Nombre entidad buscar</param>
        /// <returns>Listado de unidad operativas encontrados</returns>
        public ProcessResult<List<UnidadOperativaStaffResponse>> BuscarUnidadOperativaStaff(FiltroUnidadOperativa filtro)
        {
            ProcessResult<List<UnidadOperativaStaffResponse>> resultado = new ProcessResult<List<UnidadOperativaStaffResponse>>();
            try
            {
                Guid? codigoUnidadOperativa = filtro.CodigoUnidadOperativa != null ? new Guid(filtro.CodigoUnidadOperativa) : (Guid?)null;
                List<UnidadOperativaStaffLogic> listado = unidadOperativaLogicRepository.BuscarUnidadOperativaStaff(codigoUnidadOperativa, filtro.NumeroPagina, filtro.RegistrosPagina);
                resultado.Result = listado.Select(u => UnidadOperativaAdapter.ObtenerUnidadOperativaStaffResponse(u)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }

            return resultado;
        }


        /// <summary>
        /// Registra una unidad operativa
        /// </summary>
        /// <param name="data">Parámetros de Búsqueda</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<DataUnidadOperativaStaffRequest> RegistrarUnidadOperativaStaff(DataUnidadOperativaStaffRequest data)
        {
            ProcessResult<DataUnidadOperativaStaffRequest> resultado = new ProcessResult<DataUnidadOperativaStaffRequest>();
            try
            {
                UnidadOperativaStaffEntity entidad = UnidadOperativaAdapter.ObtenerUnidadOperativaStaffEntity(data);

                if (data.CodigoUnidadOperativaStaff == null)
                {
                    unidadOperativaStaffEntityRepository.Insertar(entidad);
                }

                unidadOperativaStaffEntityRepository.GuardarCambios();
                resultado.Result = data;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Realiza la busqueda de unidades operativas de nivel proyecto por Empresa Matriz
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de Unidad Operativa de nivel proyecto por Empresa Matriz</returns>
        public ProcessResult<List<UnidadOperativaResponse>> BuscarUnidadOperativaProyectoPorEmpresaMatriz(FiltroUnidadOperativa filtro)
        {
            List<dynamic> resultadoNivel = null;
            List<dynamic> resultadoTipo = null;
            ProcessResult<List<UnidadOperativaResponse>> resultado = new ProcessResult<List<UnidadOperativaResponse>>();
            try
            {
                Guid codigoUnidadOperativaMatriz = new Guid(filtro.CodigoUnidadOperativa);

                resultadoNivel = politicaService.ListarNivelUnidadOperativaDinamico().Result;
                resultadoTipo = politicaService.ListarTipoUnidadOperativaDinamico().Result;

                List<UnidadOperativaLogic> listado = unidadOperativaLogicRepository.BuscarUnidadOperativaProyectoPorEmpresaMatriz(codigoUnidadOperativaMatriz);
                
                resultado.Result = listado.Select(u => UnidadOperativaAdapter.ObtenerUnidadOperativaResponse(u, resultadoNivel, resultadoTipo)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Obtener la unidad operativa superior de un nivel específico
        /// </summary>
        /// <param name="filtro">Obtener código de Unidad Operativa y nivel</param>      
        /// <returns>Unidad operativa matriz o superior</returns>
        public ProcessResult<UnidadOperativaResponse> ObtenerUnidadOperativaPorNivelSuperior(FiltroUnidadOperativa filtro)
        {
            ProcessResult<UnidadOperativaResponse> resultado = new ProcessResult<UnidadOperativaResponse>();

            try
            {
                UnidadOperativaLogic objUnidadOperativa = unidadOperativaLogicRepository.ObtenerUnidadOperativaPorNivelSuperior(new Guid(filtro.CodigoUnidadOperativa), filtro.Nivel);
                resultado.Result = UnidadOperativaAdapter.ObtenerUnidadOperativaResponse(objUnidadOperativa, null, null);
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Registra el usuario de consulta de la unidad operativa
        /// </summary>
        /// <param name="data">Parámetros de Búsqueda</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<DataUnidadOperativaUsuarioConsultaRequest> RegistrarUnidadOperativaUsuarioConsulta(DataUnidadOperativaUsuarioConsultaRequest data)
        {
            ProcessResult<DataUnidadOperativaUsuarioConsultaRequest> resultado = new ProcessResult<DataUnidadOperativaUsuarioConsultaRequest>();
            try
            {
                UnidadOperativaUsuarioConsultaEntity entidad = UnidadOperativaAdapter.ObtenerUnidadOperativaUsuarioConsultaEntity(data);
                unidadOperativaResponsableEntityRepository.Insertar(entidad); 
                unidadOperativaResponsableEntityRepository.GuardarCambios();

                resultado.IsSuccess = true;
                resultado.Result = data;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Método para eliminar el usuario de consulta de la Unidad Operativa
        /// </summary>
        /// <param name="filtro">Datos de la unidad operativa usuario consulta</param>
        /// <returns>Resultado de la Operación</returns>
        public ProcessResult<string> EliminarUnidadOperativaUsuarioConsulta(DataUnidadOperativaUsuarioConsultaRequest filtro)
        {
            string result = "0";
            var resultadoProceso = new ProcessResult<string>();
            try
            {
                unidadOperativaResponsableEntityRepository.Eliminar(new Guid(filtro.CodigoUnidadUsuarioConsulta));
                unidadOperativaResponsableEntityRepository.GuardarCambios();
                resultadoProceso.IsSuccess = true;
            }
            catch (Exception e)
            {
                result = "-1";
                resultadoProceso.Result = result;
                resultadoProceso.IsSuccess = false;
                resultadoProceso.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }
            return resultadoProceso;
        }

        /// <summary>
        /// Realiza la búsqueda de los usuarios de consulta de la Unidad Operativa
        /// </summary>
        /// <param name="filtro">Código de la Unidad Operativa</param>
        /// <returns>Listado de usuarios de consulta</returns>
        public ProcessResult<List<UnidadOperativaUsuarioConsultaResponse>> BuscarUsuariosConsultaUnidadOperativa(FiltroUnidadOperativa filtro)
        {
            ProcessResult<List<UnidadOperativaUsuarioConsultaResponse>> resultado = new ProcessResult<List<UnidadOperativaUsuarioConsultaResponse>>();
            try
            {
                Guid? codigoUnidadOperativa = filtro.CodigoUnidadOperativa != null ? new Guid(filtro.CodigoUnidadOperativa) : (Guid?)null;
                List<UnidadOperativaUsuarioConsultaLogic> listado = unidadOperativaLogicRepository.BuscarUsuariosConsultaUnidadOperativa(codigoUnidadOperativa);
                resultado.Result = listado.Select(u => UnidadOperativaAdapter.ObtenerUnidadOperativaUsuarioConsultaResponse(u)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }

            return resultado;
        }
       
        /// <summary>
        /// Obtener los responsables por unidad operativa y sus niveles superiores
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de la unidad operativa</param>
        /// <param name="nombreUnidadOperativa">Nombre de la unidad operativa</param>
        /// <returns>Unidades y responsables de niveles superiores</returns>
        public ProcessResult<UnidadOperativaNivelResponse> ObtenerResponsablesUnidadOperativaPorNivel(string codigoUnidadOperativa, string nombreUnidadOperativa)
        {
            ProcessResult<UnidadOperativaNivelResponse> resultado = new ProcessResult<UnidadOperativaNivelResponse>();

            try
            {
                UnidadOperativaNivelLogic objUnidadOperativaNivel = unidadOperativaLogicRepository.ObtenerResponsablesUnidadOperativaPorNivelSuperior(string.IsNullOrEmpty(codigoUnidadOperativa) ? Guid.Empty : new Guid(codigoUnidadOperativa), nombreUnidadOperativa);
                resultado.Result = UnidadOperativaAdapter.ObtenerUnidadOperativaNivelResponse(objUnidadOperativaNivel);
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Obtener las unidades operativas para consulta de un trabajador
        /// </summary>
        /// <param name="filtro">Código del trabajador</param>
        /// <returns>Listado de unidades operativas</returns>
        public ProcessResult<List<UnidadOperativaUsuarioConsultaResponse>> ListarUnidadesOperativasConsultaPorTrabajador(Guid codigoTrabajador)
        {
            ProcessResult<List<UnidadOperativaUsuarioConsultaResponse>> resultado = new ProcessResult<List<UnidadOperativaUsuarioConsultaResponse>>();
            try
            {              
                List<UnidadOperativaUsuarioConsultaLogic> listado = unidadOperativaLogicRepository.ObtenerUnidadesOperativasConsultaPorTrabajador(codigoTrabajador);
                resultado.Result = listado.Select(u => UnidadOperativaAdapter.ObtenerUnidadOperativaUsuarioConsultaResponse(u)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }

            return resultado;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.Adapter.General;
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.Service.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using Pe.Stracon.Politicas.Infraestructura.Core.CommandContract.General;
using Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using Pe.Stracon.PoliticasCross.Core.Exception;
using Pe.Stracon.Politicas.Cross.Core.Base;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;
using Pe.Stracon.Politicas.Aplicacion.Core.Message;
using System.Configuration;
using Pe.GyM.Security.Account.SRASecurityService;
using Pe.Stracon.SGC.Presentacion.Core.LogError;
//using Pe.GyM.Security.Account.SRASecurityService;

namespace Pe.Stracon.Politicas.Aplicacion.Service.General
{
    /// <summary>
    /// Implementación de servicios para Trabajador
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorService : GenericService, ITrabajadorService
    {

        /// <summary>
        /// Instancia de sesion
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        /// <summary>
        /// Instancia del Repositorio Trabajador Logic
        /// </summary>
        public ITrabajadorLogicRepository trabajadorLogicRepository { get; set; }

        /// <summary>
        /// Instancia del Repositorio Trabajador Entity
        /// </summary>
        public ITrabajadorEntityRepository trabajadorEntityRepository { get; set; }

        /// <summary>
        /// Instancia del Repositorio TrabajadorUnidadOperativa Entity
        /// </summary>
        public ITrabajadorUnidadOperativaEntityRepository trabajadorUnidadOperativaEntityRepository { get; set; }

        /// <summary>
        /// Instancia del Repositorio TrabajadorSuplente Entity
        /// </summary>
        public ITrabajadorSuplenteEntityRepository trabajadorSuplenteEntityRepository { get; set; }

        /// <summary>
        /// Instancia del Repositorio Trabajador Firma Entity
        /// </summary>
        public ITrabajadorFirmaEntityRepository trabajadorFirmaEntityRepository { get; set; }

        /// <summary>
        /// Instancia del Servicio de Políticas
        /// </summary>
        public IPoliticaService politicaService { get; set; }

        /// <summary>
        /// Búsqueda de Trabajador
        /// </summary>
        /// <param name="filtro">Trabajador Request</param>
        /// <returns>Lista con resultados de busqueda</returns>
        public ProcessResult<List<TrabajadorResponse>> BuscarTrabajador(TrabajadorRequest filtro)
        {
            ProcessResult<List<TrabajadorResponse>> resultado = new ProcessResult<List<TrabajadorResponse>>();
            try
            {
                List<TrabajadorLogic> listado = trabajadorLogicRepository.BuscarTrabajador(filtro.CodigoTrabajador, filtro.CodigoIdentificacion, filtro.Dominio, filtro.CodigoTipoDocumentoIdentidad, filtro.NumeroDocumentoIdentidad, filtro.Nombres, filtro.NumeroPagina, filtro.RegistrosPagina);

                var listaTipoDocumento = politicaService.ListarTipoDocumentoIdentidad(null, "3");
                resultado.Result = listado.Select(u => TrabajadorAdapter.ObtenerTrabajadorPaginado(u, listaTipoDocumento.Result)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Lista registros de trabajadores a partir de códigos.
        /// </summary>
        /// <param name="listaCodigos">Lista de códigos de trabajadores</param>
        /// <returns>Lista de trabajadores</returns>
        public ProcessResult<List<TrabajadorResponse>> ListarTrabajadores(List<Guid?> listaCodigos)
        {
            var resultado = new ProcessResult<List<TrabajadorResponse>>();
            try
            {
                //var listaCodigosGuid = listaCodigos.Select(c => new Guid(c)).ToList();
                List<TrabajadorLogic> listado = trabajadorLogicRepository.ListarTrabajadores(listaCodigos);
                resultado.Result = listado.Select(u => TrabajadorAdapter.ObtenerTrabajadorPaginado(u, null)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Registrar Trabajador
        /// </summary>
        /// <param name="data">Trabajador Response</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<TrabajadorRequest> RegistrarTrabajador(TrabajadorRequest data)
        {
            ProcessResult<TrabajadorRequest> resultado = new ProcessResult<TrabajadorRequest>();
            try
            {
                TrabajadorEntity entidad = TrabajadorAdapter.ObtenerTrabajadorEntity(data);
                entidad.UsuarioCreacion = "";
                entidad.TerminalCreacion = "";
                entidad.FechaCreacion = DateTime.Now;

                if (data.CodigoTrabajador == null)
                {
                    data.CodigoTrabajador = Guid.NewGuid();
                    trabajadorEntityRepository.Insertar(entidad);
                }
                else
                {
                    var entidadEditar = trabajadorEntityRepository.GetById(entidad.Codigo);
                    entidadEditar.CodigoTipoDocumentoIdentidad = entidad.CodigoTipoDocumentoIdentidad; ;
                    entidadEditar.NumeroDocumentoIdentidad = entidad.NumeroDocumentoIdentidad;
                    entidadEditar.ApellidoPaterno = entidad.ApellidoPaterno;
                    entidadEditar.ApellidoMaterno = entidad.ApellidoMaterno;
                    entidadEditar.Nombres = entidad.Nombres;
                    entidadEditar.NombreCompleto = entidad.NombreCompleto;
                    entidadEditar.Cargo = entidad.Cargo;
                    entidadEditar.Organizacion = entidad.Organizacion;
                    entidadEditar.Departamento = entidad.Departamento;
                    entidadEditar.TelefonoTrabajo = entidad.TelefonoTrabajo;
                    entidadEditar.Anexo = entidad.Anexo;
                    entidadEditar.TelefonoMovil = entidad.TelefonoMovil;
                    entidadEditar.TelefonoPersonal = entidad.TelefonoPersonal;
                    entidadEditar.Dominio = entidad.Dominio;
                    trabajadorEntityRepository.Editar(entidadEditar);
                }

                trabajadorEntityRepository.GuardarCambios();
                resultado.Result = data;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Registrar TrabajadorUnidadOperativa
        /// </summary>
        /// <param name="data">Trabajador Response</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<TrabajadorRequest> RegistrarTrabajadorUnidadOperativa(TrabajadorRequest data)
        {
            ProcessResult<TrabajadorRequest> resultado = new ProcessResult<TrabajadorRequest>();
            try
            {
                if (string.IsNullOrEmpty(data.CodigoUnidadOperativaMatriz))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<TrabajadorService>(MensajesSistema.UnidadOperativaMatrizObligatorio);
                    return resultado;
                }

                var entidadEditar = trabajadorEntityRepository.GetById(data.CodigoTrabajador.Value);
                entidadEditar.CodigoUnidadOperativaMatriz = new Guid(data.CodigoUnidadOperativaMatriz);
                entidadEditar.IndicadorTodaUnidadOperativa = data.IndicadorTodaUnidadOperativa;

                trabajadorEntityRepository.Editar(entidadEditar);

                if (!data.IndicadorTodaUnidadOperativa)
                {
                    var trabajadorUnidadOperativa = trabajadorLogicRepository.ListarTrabajadorUnidadOperativa(data.trabajadorUnidadOperativaRequest.CodigoUnidadOperativaMatriz, data.CodigoTrabajador.Value).Where(p => p.CodigoUnidadOperativa == data.trabajadorUnidadOperativaRequest.CodigoUnidadOperativa).FirstOrDefault();

                    TrabajadorUnidadOperativaEntity entidadTrabajadorUnidadOperativa = TrabajadorAdapter.ObtenerTrabajadorUnidadOperativaEntity(data.trabajadorUnidadOperativaRequest);

                    if (trabajadorUnidadOperativa == null)
                    {
                        trabajadorUnidadOperativaEntityRepository.Insertar(entidadTrabajadorUnidadOperativa);
                    }
                    else
                    {
                        entidadTrabajadorUnidadOperativa.CodigoUnidadOperativaMatriz = entidadTrabajadorUnidadOperativa.CodigoUnidadOperativaMatriz;
                        entidadTrabajadorUnidadOperativa.CodigoTrabajadorUnidadOperativa = trabajadorUnidadOperativa.CodigoTrabajadorUnidadOperativa;
                        entidadTrabajadorUnidadOperativa.EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;
                        entidadTrabajadorUnidadOperativa.FechaCreacion = trabajadorUnidadOperativa.FechaCreacion;
                        trabajadorUnidadOperativaEntityRepository.Editar(entidadTrabajadorUnidadOperativa);
                    }

                    trabajadorUnidadOperativaEntityRepository.GuardarCambios();
                }

                trabajadorEntityRepository.GuardarCambios();
                resultado.Result = data;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Registrar Trabajador Suplente
        /// </summary>
        /// <param name="data">TrabajadorSuplente Response</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<TrabajadorSuplenteRequest> RegistrarTrabajadorSuplente(TrabajadorSuplenteRequest data)
        {
            ProcessResult<TrabajadorSuplenteRequest> resultado = new ProcessResult<TrabajadorSuplenteRequest>();
            TrabajadorSuplenteEntity entidad = new TrabajadorSuplenteEntity();

            try
            {
                var trabajadorSuplente = trabajadorSuplenteEntityRepository.GetById(data.CodigoTrabajador);

                #region SRA
                var trabajador = BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = data.CodigoTrabajador }).Result.FirstOrDefault();
                var Suplente = BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = data.CodigoSuplente }).Result.FirstOrDefault();

                SeguridadServiceClient seguridadService = new SeguridadServiceClient();

                if (data.Activo == true)
                {
                    //Buscamos al usuario original en el SRA
                    var usuarioSRAOriginal = seguridadService.GetUserByLoginAD(trabajador.CodigoIdentificacion, trabajador.DominioCorto);

                    if (Suplente != null && usuarioSRAOriginal != null)
                    {
                        //Verficamos si el usuario suplente esta registrado en el SRA
                        var usuarioSRASuplente = seguridadService.GetUserByLoginAD(Suplente.CodigoIdentificacion, Suplente.DominioCorto);

                        if (usuarioSRASuplente == null)
                        {
                            usuarioSRASuplente = seguridadService.InsertUserAD(Suplente.CodigoIdentificacion, Suplente.DominioCorto, data.UsuarioSession, data.Terminal);
                        }

                        //Validar que los perfiles del usuario original los tenga el usuario suplente
                        var perfilesOriginal = usuarioSRAOriginal.PERFILES.Where(p => p.S_TOKEN == ConfigurationManager.AppSettings["CLIENT_SITE_TOKEN"].ToString()).ToList();
                        var perfilesSuplente = usuarioSRASuplente.PERFILES.Where(p => p.S_TOKEN == ConfigurationManager.AppSettings["CLIENT_SITE_TOKEN"].ToString()).ToList();
                        var perfilesAgregados = string.Empty;

                        foreach (var item in perfilesOriginal)
                        {
                            if (perfilesSuplente.Where(p => p.S_NAME_PROFILE == item.S_NAME_PROFILE).FirstOrDefault() == null)
                            {
                                var obj = seguridadService.InsertUserProfileAsDesactivate(usuarioSRASuplente.ID_USER, item.N_ID_PROFILE, data.UsuarioSession, data.Terminal);
                                perfilesAgregados += (obj.N_ID_USER_PROFILE > 0 ? obj.N_ID_USER_PROFILE + "," : "");
                            }
                        }

                        //Actualizar el campo perfiles a la tabla Trabajador suplente
                        if (perfilesAgregados != string.Empty)
                        {
                            data.PerfilesAgregados = perfilesAgregados.TrimEnd(',');
                        }
                    }
                }
                else
                {
                    //Consultamos si esta registrado la combinacion trabajadorSuplente para este usuario logueado
                    //var trabajadorSuplente = BuscarTrabajadorSuplente(new TrabajadorRequest() { CodigoTrabajador = new Guid(trabajador.CodigoTrabajador) }).Result.FirstOrDefault();
                    if (trabajadorSuplente != null && !string.IsNullOrEmpty(trabajadorSuplente.PerfilesAgregados))
                    {
                        string[] perfiles = trabajadorSuplente.PerfilesAgregados.Split(',');
                        foreach (var item in perfiles)
                        {
                            seguridadService.DeleteUserProfile(Convert.ToInt32(item), data.UsuarioSession, data.Terminal);
                        }
                    }
                }
                #endregion

                //Obtenemos si un registro tiene el trabajador

                entidad = TrabajadorAdapter.ObtenerTrabajadorSuplenteEntity(data);

                #region antiguo
                //if (trabajadorSuplente == null)
                //{
                //    trabajadorSuplenteEntityRepository.Insertar(entidad);
                //}
                //else
                //{
                //    var entidadEditar = trabajadorSuplenteEntityRepository.GetById(entidad.CodigoTrabajador);   

                //    entidadEditar.CodigoSuplente = entidad.CodigoSuplente; ;
                //    entidadEditar.FechaInicio    = entidad.FechaInicio != null ? entidad.FechaInicio : DateTime.Now;
                //    entidadEditar.FechaFin       = entidad.FechaFin != null ? entidad.FechaFin : DateTime.Now;
                //    entidadEditar.FechaCreacion  = DateTime.Now;
                //    entidadEditar.Ejecutado      = (entidad.Activo == false ? false : entidadEditar.Ejecutado);
                //    entidadEditar.Activo         = entidad.Activo;

                //    if (entidad.Activo == false)
                //    {
                //        entidadEditar.PerfilesAgregados = null;
                //    }
                //    else
                //    {
                //        entidadEditar.PerfilesAgregados = (entidad.PerfilesAgregados != null ? entidad.PerfilesAgregados : entidadEditar.PerfilesAgregados);
                //    }

                //    trabajadorSuplenteEntityRepository.Editar(entidadEditar);
                //}

                //trabajadorSuplenteEntityRepository.GuardarCambios();
                //resultado.Result = data;
                #endregion

                //Se cambia por procedure para evitar error en el servidor de stracon(peru)

                #region Nuevo

                if (trabajadorSuplente == null)
                {
                    entidad.UsuarioCreacion   = data.UsuarioSession;
                    entidad.TerminalCreacion  = data.Terminal;
                    entidad.PerfilesAgregados = data.PerfilesAgregados;
                    entidad.Ejecutado         = data.Ejecutado;

                    var resultInsertar = trabajadorLogicRepository.RegistrarSuplenteTrabajador(entidad);

                    if(resultInsertar == 0)
                    {
                        resultado.IsSuccess = false;
                    }
                    else
                    {
                        resultado.IsSuccess = true;
                    }
                }
                else
                {
                    if (entidad.Activo == false)
                    {
                        entidad.PerfilesAgregados = null;
                    }

                    entidad.UsuarioModificacion  = data.UsuarioSession;
                    entidad.TerminalModificacion = data.Terminal;
                    entidad.PerfilesAgregados    = data.PerfilesAgregados;
                    entidad.Ejecutado            = data.Ejecutado;

                    var resultActualizar = trabajadorLogicRepository.ActualizarSuplenteTrabajador(entidad);

                    if (resultActualizar == 0)
                    {
                        resultado.IsSuccess = false;
                    }
                    else
                    {
                        resultado.IsSuccess = true;
                    }
                }

                resultado.Result = data;
                #endregion

            }
            catch (Exception e)
            {
                LogEN.grabarLogError(e, entidad.FechaInicio.ToString());
            }
            return resultado;
        }

        /// <summary>
        /// Lista los proyectos asociados a un trabajador.
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de proyectos asociados</returns>
        public ProcessResult<List<TrabajadorUnidadOperativaResponse>> ListarTrabajadorUnidadOperativa(TrabajadorUnidadOperativaRequest filtro)
        {
            var resultado = new ProcessResult<List<TrabajadorUnidadOperativaResponse>>();
            try
            {
                var listado = trabajadorLogicRepository.ListarTrabajadorUnidadOperativa(filtro.CodigoUnidadOperativaMatriz, filtro.CodigoTrabajador).Where(p => p.EstadoRegistro == "1").ToList();
                resultado.Result = listado.Select(u => TrabajadorAdapter.ObtenerTrabajadorUnidadOperativaResponse(u)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Eliminar el registro de trabajadores.
        /// </summary>
        /// <param name="listaTrabajadores">Lista de trabajadores</param>
        /// <returns>Resultado de la operación</returns>
        public ProcessResult<TrabajadorRequest> EliminarTrabajador(List<TrabajadorRequest> listaTrabajadores)
        {
            ProcessResult<TrabajadorRequest> resultado = new ProcessResult<TrabajadorRequest>();

            try
            {
                foreach (var codigo in listaTrabajadores)
                {
                    trabajadorEntityRepository.Eliminar(codigo.CodigoTrabajador);
                }
                trabajadorEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<UnidadOperativaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Búsqueda de Trabajador
        /// </summary>
        /// <param name="filtro">Trabajador Request</param>
        /// <returns>Lista con resultados de busqueda</returns>
        public ProcessResult<List<TrabajadorDatoMinimoResponse>> BuscarTrabajadorDatoMinimo(TrabajadorRequest filtro)
        {
            ProcessResult<List<TrabajadorDatoMinimoResponse>> resultado = new ProcessResult<List<TrabajadorDatoMinimoResponse>>();
            try
            {
                resultado.Result = new List<TrabajadorDatoMinimoResponse>();
                List<TrabajadorLogic> listado = trabajadorLogicRepository.BuscarTrabajadorDatoMinimo(filtro.Dominio, filtro.CodigoIdentificacion, filtro.NombreCompleto, filtro.CorreoElectronico);
                foreach (TrabajadorLogic item in listado)
                {
                    TrabajadorDatoMinimoResponse tdm = new TrabajadorDatoMinimoResponse();
                    tdm = TrabajadorAdapter.ObtenerTrabajadorDatoMinimo(item);
                    resultado.Result.Add(tdm);
                }
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Búsqueda de la firma de un Trabajador.
        /// </summary>
        /// <param name="trabajador">Trabajador Request</param>
        /// <returns>Lista con resultados de busqueda</returns>
        public ProcessResult<TrabajadorResponse> BuscarFirmaTrabajador(TrabajadorRequest trabajador)
        {
            ProcessResult<TrabajadorResponse> resultado = new ProcessResult<TrabajadorResponse>();
            try
            {
                var dato = trabajadorLogicRepository.BuscarFirmaTrabajador(TrabajadorAdapter.ObtenerTrabajadorEntity(trabajador));
                if (dato != null)
                {
                    resultado.Result = TrabajadorAdapter.ObtenerTrabajadorPaginado(dato, null);
                }
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Registrar la firma de un Trabajador.
        /// </summary>
        /// <param name="trabajador">Trabajador Request</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<TrabajadorResponse> RegistrarFirmaTrabajador(TrabajadorRequest trabajador)
        {
            ProcessResult<TrabajadorResponse> resultado = new ProcessResult<TrabajadorResponse>();
            try
            {
                TrabajadorFirmaEntity entidad = new TrabajadorFirmaEntity();
                if (trabajador.CodigoFirma == Guid.Empty)
                {
                    entidad.Codigo = Guid.NewGuid();
                    entidad.CodigoTrabajador = trabajador.CodigoTrabajador;
                    entidad.Firma = trabajador.Firma;
                    trabajadorFirmaEntityRepository.Insertar(entidad);
                }
                else
                {
                    entidad = trabajadorFirmaEntityRepository.GetById(trabajador.CodigoFirma);
                    entidad.Firma = trabajador.Firma;
                    trabajadorFirmaEntityRepository.Editar(entidad);
                }
                trabajadorFirmaEntityRepository.GuardarCambios();
                resultado.Result = new TrabajadorResponse { CodigoFirma = entidad.Codigo.ToString(), CodigoTrabajador = entidad.CodigoTrabajador.ToString(), Firma = entidad.Firma };
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Notificar inicios y cierres de periodo.
        /// </summary>
        /// <param name="listaTrabajadores">Lista de trabajaores</param>
        /// <param name="CodigoNotificar">tipo de notificacion</param>
        /// <param name="AnioPeriodo">Anio de Periodo</param>
        /// <param name="MesPeriodo"> Mes del Periodo </param>
        /// <param name="NombreActividad"></param>
        /// <param name="codigoSistema">Código del sistema</param>
        /// <param name="profileCorreo">Perfil de la cuenta que ejecuta la notificación.</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> NotificaParticipanteCalendarizacion(List<Guid?> listaTrabajadores, string CodigoNotificar, string AnioPeriodo,
                                                                        string MesPeriodo, string NombreActividad, Guid codigoSistema, string profileCorreo)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            try
            {
                resultado.Result = trabajadorLogicRepository.NotificaParticipanteCalendarizacion(listaTrabajadores, CodigoNotificar, AnioPeriodo,
                                                                MesPeriodo, NombreActividad, codigoSistema, profileCorreo);
            }
            catch (Exception ex)
            {
                resultado.Result = -1;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Eliminar el registro de trabajadorUnidadOperativa.
        /// </summary>
        /// <param name="codigoTrabajadorUnidadOperativa">Código de trabajador unidad operativa</param>
        /// <returns>Resultado de la operación</returns>
        public ProcessResult<TrabajadorUnidadOperativaRequest> EliminarTrabajadorUnidadOperativa(Guid codigoTrabajadorUnidadOperativa)
        {
            ProcessResult<TrabajadorUnidadOperativaRequest> resultado = new ProcessResult<TrabajadorUnidadOperativaRequest>();

            try
            {
                trabajadorUnidadOperativaEntityRepository.Eliminar(codigoTrabajadorUnidadOperativa);
                trabajadorUnidadOperativaEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Búsqueda de TrabajadorSuplente
        /// </summary>
        /// <param name="filtro">Trabajador Request</param>
        /// <returns>Lista con resultados de busqueda</returns>
        public ProcessResult<List<TrabajadorSuplenteResponse>> BuscarTrabajadorSuplente(TrabajadorRequest filtro)
        {
            ProcessResult<List<TrabajadorSuplenteResponse>> resultado = new ProcessResult<List<TrabajadorSuplenteResponse>>();
            try
            {
                List<TrabajadorSuplenteLogic> listado = trabajadorLogicRepository.ListarTrabajadorSuplente(filtro.CodigoTrabajador.Value);
                resultado.Result = listado.Select(u => TrabajadorAdapter.ObtenerTrabajadorSuplenteResponse(u)).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<TrabajadorService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Actualiza el reemplazo al trabajador original
        /// </summary>
        /// <param name="codigoTrabajador">Codigo de trabajador</param>
        /// <param name="codigoSuplente"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<string> EnviarNotificacionFinReemplazo(Guid codigoTrabajador, Guid codigoSuplente)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                //Enviar notificación
                var profile = politicaService.ListaCuentaNotificacionSGC(null, "3").Result.FirstOrDefault();
                var profileCorreo = (profile != null ? profile.Valor.ToString() : "");
                trabajadorLogicRepository.EnviarNotificacionFinReemplazo(codigoTrabajador, codigoSuplente, profileCorreo);

                resultado.Result = "1";
            }
            catch (Exception e)
            {
                throw e;
            }

            return resultado;
        }
    }
}

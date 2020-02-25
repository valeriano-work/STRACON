using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Transactions;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.Adapter.Contractual;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.Service.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Cross.Core.Exception;
using Pe.Stracon.SGC.Cross.Core.Util;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;

namespace Pe.Stracon.SGC.Aplicacion.Service.Contractual
{
    /// <summary>
    /// Servicio que representa las Consultas
    /// </summary>
    /// <remarks>
    /// Creación: GMD 20150710 <br />
    /// Modificación:<br />
    /// </remarks>
    public class ConsultaService : GenericService, IConsultaService
    {
        #region Parametros
        /// <summary>
        /// Repositorio de plantilla
        /// </summary>
        public IConsultaLogicRepository consultaLogicRepository { get; set; }
        /// <summary>
        /// Repositorio de plantilla
        /// </summary>
        public IConsultaEntityRepository consultaEntityRepository { get; set; }
        /// <summary>
        /// Servicio de trabajador
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }
        /// <summary>
        /// Servicio de plantilla de notificación
        /// </summary>
        public IPlantillaNotificacionService plantillaNotificacionService { get; set; }
        /// <summary>
        /// Servicio de politicas
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Repositorio lógico de consulta adjunto
        /// </summary>
        public IConsultaAdjuntoLogicRepository consultaAdjuntoLogicRepository { get; set; }
        /// <summary>
        /// Repositorio de consulta adjunto
        /// </summary>
        public IConsultaAdjuntoEntityRepository consultaAdjuntoEntityRepository { get; set; }
        /// <summary>
        /// Servicio de politicas
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }
        /// <summary>
        /// Interfaz de comunicación son los servidores SharePoint.
        /// </summary>
        public ISharePointService sharePointService { get; set; }
        /// <summary>
        /// Repositorio de consulta usuarios
        /// </summary>
        public IConsultaTrazabilidadEntityRepository consultaTrazabilidadEntityRepository { get; set; }

        /// <summary>
        /// Interface para obtener el entorno de la aplicación.
        /// </summary>
        public IEntornoActualAplicacion entornoAplicacion { get; set; }
        #endregion

        /// <summary>
        /// Realiza la búsqueda de consultas
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de contratos</returns>
        public ProcessResult<List<ConsultaResponse>> ListadoConsulta(ConsultaRequest filtro)
        {
            ProcessResult<List<ConsultaResponse>> resultado = new ProcessResult<List<ConsultaResponse>>();
            try
            {
                Guid? CodigoRemitente = (filtro.CodigoRemitente != null && filtro.CodigoRemitente != "") ? new Guid(filtro.CodigoRemitente) : (Guid?)null;
                Guid? CodigoDestinatario = (filtro.CodigoDestinatario != null && filtro.CodigoDestinatario != "") ? new Guid(filtro.CodigoDestinatario) : (Guid?)null;

                Guid? CodigoUnidadOperativa = (filtro.CodigoUnidadOperativa != null && filtro.CodigoUnidadOperativa != "") ? new Guid(filtro.CodigoUnidadOperativa) : (Guid?)null;
                Guid? CodigoConsulta = (filtro.CodigoConsulta != null && filtro.CodigoConsulta != "") ? new Guid(filtro.CodigoConsulta) : (Guid?)null;
                Guid? CodigoUsuarioSesion = (filtro.CodigoUsuarioSesion != null && filtro.CodigoUsuarioSesion != "") ? new Guid(filtro.CodigoUsuarioSesion) : (Guid?)null;

                List<ConsultaLogic> listado = consultaLogicRepository.ListaConsulta(CodigoRemitente, CodigoDestinatario, filtro.Tipo, CodigoUnidadOperativa, filtro.CodigoArea, CodigoConsulta, CodigoUsuarioSesion, filtro.EstadoConsulta, filtro.NumeroPagina, filtro.RegistrosPagina);

                resultado.Result = new List<ConsultaResponse>();
                var resultadoTrabajador = trabajadorService.BuscarTrabajadorDatoMinimo(new TrabajadorRequest()).Result;

                var listaArea = politicaService.ListarArea().Result;
                var listEstado = politicaService.ListarEstadoConsulta().Result;
                var tipo = politicaService.ListarTipoConsulta().Result;

                foreach (var registro in listado)
                {
                    var listadoConsulta = ConsultaAdapter.ObtenerConsultaResponse(registro, listaArea, listEstado, tipo, new Guid(filtro.CodigoUsuarioSesion), resultadoTrabajador);
                    resultado.Result.Add(listadoConsulta);
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Retorna información de la consulta.
        /// </summary>
        /// <param name="codigoConsulta">código de la consulta</param>
        /// <returns>Información de la consulta</returns>
        public ProcessResult<ConsultaResponse> ConsultaPorId(Guid codigoConsulta)
        {
            ProcessResult<ConsultaResponse> rpta = new ProcessResult<ConsultaResponse>();
            try
            {
                ConsultaEntity entConsulta = consultaEntityRepository.GetById(codigoConsulta);

                rpta.Result = new ConsultaResponse();
                rpta.Result = ConsultaAdapter.ObtenerConsultaResponseDeEntity(entConsulta);
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ConsultaService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Registra / Responde Consulta
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<ConsultaRequest> RegistrarConsulta(ConsultaRequest data)
        {
            ProcessResult<ConsultaRequest> resultado = new ProcessResult<ConsultaRequest>();
            try
            {
                ConsultaEntity entidad = ConsultaAdapter.ObtenerConsultaEntity(data);

                if (data.CodigoConsulta == null)
                {
                    entidad.EstadoConsulta = DatosConstantes.EstadoConsulta.Enviado;
                    entidad.FechaEnvio = DateTime.Now;
                    entidad.VistoRemitenteOriginal = true;
                    consultaEntityRepository.Insertar(entidad);
                    consultaEntityRepository.GuardarCambios();

                    if (!string.IsNullOrEmpty(data.CodigoDestinatario))
                    {
                        var destinatario = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = new Guid(data.CodigoDestinatario) }).Result.FirstOrDefault();

                        data.CorreoDestinatario = destinatario.CorreoElectronico;
                        data.NombreDestinatario = destinatario.NombreCompleto;

                        EnviarNotificacion(DatosConstantes.TipoNotificacion.RegistroConsultas, data.DescripcionTipo, data.Asunto, data.NombreDestinatario, data.CorreoDestinatario);
                    }
                }
                else //es un responder
                {
                    var entidadSincronizar = consultaEntityRepository.GetById(entidad.CodigoConsulta);

                    entidadSincronizar.Respuesta = entidad.Respuesta;
                    entidadSincronizar.FechaRespuesta = (entidadSincronizar.CodigoConsultaOriginal != null ? (DateTime?)null : DateTime.Now);
                    entidadSincronizar.EsValido = entidad.EsValido;

                    if (entidad.EsValido == true)
                    {
                        entidadSincronizar.EstadoConsulta = DatosConstantes.EstadoConsulta.Contestado;
                    }
                    else
                    {
                        entidadSincronizar.EstadoConsulta = DatosConstantes.EstadoConsulta.NoAplica;
                    }

                    //Listamos todas las consultas que hayan sido reenviadas incluyendo la original que tienen el mismo codigo de consulta original
                    var listaConsultas = consultaLogicRepository.ListaConsultaSimple(null, null, null, null, null, null, null).Where(x => (x.CodigoConsultaOriginal == entidadSincronizar.CodigoConsultaOriginal || x.CodigoConsulta == entidadSincronizar.CodigoConsultaOriginal) && x.CodigoConsulta != entidad.CodigoConsulta).ToList();

                    if (entidadSincronizar.CodigoConsultaOriginal != null)
                    {
                        var consultaOriginal = consultaEntityRepository.GetById(entidadSincronizar.CodigoConsultaOriginal);

                        //insertamos un nuevo registro de contestacion de consulta
                        var consultaRespuesta = new ConsultaEntity();
                        consultaRespuesta.Asunto = entidadSincronizar.Asunto;
                        consultaRespuesta.CodigoArea = entidadSincronizar.CodigoArea;
                        consultaRespuesta.CodigoConsulta = Guid.NewGuid();
                        consultaRespuesta.CodigoConsultaOriginal = entidadSincronizar.CodigoConsultaOriginal;
                        consultaRespuesta.CodigoConsultaRelacionado = entidadSincronizar.CodigoConsultaRelacionado;
                        consultaRespuesta.CodigoDestinatario = entidadSincronizar.CodigoDestinatario;
                        consultaRespuesta.CodigoRemitente = consultaOriginal.CodigoRemitente;
                        consultaRespuesta.CodigoUnidadOperativa = entidadSincronizar.CodigoUnidadOperativa;
                        consultaRespuesta.Contenido = entidadSincronizar.Contenido;
                        consultaRespuesta.EstadoConsulta = entidadSincronizar.EstadoConsulta;
                        consultaRespuesta.EstadoRegistro = entidadSincronizar.EstadoRegistro;
                        consultaRespuesta.EsValido = entidadSincronizar.EsValido;
                        consultaRespuesta.FechaCreacion = entidadSincronizar.FechaCreacion;
                        consultaRespuesta.FechaEnvio = entidadSincronizar.FechaEnvio;
                        consultaRespuesta.FechaModificacion = entidadSincronizar.FechaModificacion;
                        consultaRespuesta.FechaRespuesta = DateTime.Now;
                        consultaRespuesta.Respuesta = entidadSincronizar.Respuesta;
                        consultaRespuesta.TerminalCreacion = entidadSincronizar.TerminalCreacion;
                        consultaRespuesta.TerminalModificacion = entidadSincronizar.TerminalModificacion;
                        consultaRespuesta.Tipo = entidadSincronizar.Tipo;
                        consultaRespuesta.UsuarioCreacion = entidadSincronizar.UsuarioCreacion;
                        consultaRespuesta.UsuarioModificacion = entidadSincronizar.UsuarioModificacion;
                        consultaRespuesta.VistoRemitenteOriginal = entidadSincronizar.VistoRemitenteOriginal;

                        consultaEntityRepository.Insertar(consultaRespuesta);
                        consultaEntityRepository.GuardarCambios();
                        //entidadSincronizar.CodigoRemitente = consultaOriginal.CodigoRemitente;
                    }
                    //Actualizamos la consulta con respuesta
                    consultaEntityRepository.Editar(entidadSincronizar);
                    consultaEntityRepository.GuardarCambios();

                    //Enviar notificación de respuesta
                    if (entidadSincronizar.CodigoRemitente != null)
                    {
                        var destinatario = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = entidadSincronizar.CodigoRemitente }).Result.FirstOrDefault();
                        EnviarNotificacion(DatosConstantes.TipoNotificacion.RespuestaConsultas, data.DescripcionTipo, entidadSincronizar.Asunto, destinatario.NombreCompleto, destinatario.CorreoElectronico);
                    }

                    //Actualizamos todas las consultas que hayan sido reenviadas incluyendo la original que tienen el mismo codigo de consulta original
                    foreach (var item in listaConsultas)
                    {
                        var itemEditar = consultaEntityRepository.GetById(item.CodigoConsulta);

                        itemEditar.VistoRemitenteOriginal = (itemEditar.CodigoConsulta == entidadSincronizar.CodigoConsultaOriginal ? false : true);
                        itemEditar.EstadoConsulta = entidadSincronizar.EstadoConsulta;
                        //itemEditar.FechaRespuesta = entidadSincronizar.FechaRespuesta;
                        //entidadOriginalSincronizar.Respuesta = entidadSincronizar.Respuesta;
                        itemEditar.EsValido = entidadSincronizar.EsValido;
                        consultaEntityRepository.Editar(itemEditar);
                        consultaEntityRepository.GuardarCambios();
                    }

                    //var entidadOriginalSincronizar = consultaEntityRepository.GetById(entidadSincronizar.CodigoConsultaOriginal);
                    //if (entidadOriginalSincronizar != null)
                    //{
                    //    entidadOriginalSincronizar.VistoRemitenteOriginal = false;
                    //    entidadOriginalSincronizar.EstadoConsulta = entidadSincronizar.EstadoConsulta;
                    //    entidadOriginalSincronizar.FechaRespuesta = entidadSincronizar.FechaRespuesta;
                    //    //entidadOriginalSincronizar.Respuesta = entidadSincronizar.Respuesta;
                    //    entidadOriginalSincronizar.EsValido = entidadSincronizar.EsValido;
                    //    consultaEntityRepository.Editar(entidadOriginalSincronizar);
                    //    consultaEntityRepository.GuardarCambios();
                    //}
                }

                //Registrar adjuntos
                if (data.ListaAdjuntos != null)
                {
                    foreach (var item in data.ListaAdjuntos)
                    {
                        byte[] bytes = System.IO.File.ReadAllBytes(item.RutaArchivoSharePoint);
                        item.CodigoConsulta = entidad.CodigoConsulta;
                        item.ArchivoAdjunto = bytes;
                        var resultadoAdjunto = RegistrarConsultaAdjunto(item);
                    }
                    data.ListaAdjuntos = null;


                }                

                resultado.Result = data;

            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ConsultaService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Reenvia Consulta
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<ConsultaRequest> ReenviarConsulta(ConsultaRequest data)
        {
            ProcessResult<ConsultaRequest> resultado = new ProcessResult<ConsultaRequest>();
            try
            {
                ConsultaEntity entidad = ConsultaAdapter.ObtenerConsultaEntity(data);
                entidad.EstadoConsulta = DatosConstantes.EstadoConsulta.Enviado;
                entidad.FechaEnvio = DateTime.Now;

                //Obtenemos la consulta original
                var entidadSincronizar = consultaEntityRepository.GetById(new Guid(data.CodigoConsultaRelacionado));

                entidad.Asunto = "RE: " + entidadSincronizar.Asunto;
                var nombreRemitenteOriginal = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = entidadSincronizar.CodigoRemitente }).Result.FirstOrDefault().NombreCompleto;
                entidad.Contenido = data.Adicional + "</br></br> Enviado por " + nombreRemitenteOriginal + " el " + entidadSincronizar.FechaEnvio.Value.ToString("dd/M/yyyy") + ":</br></br>" + entidadSincronizar.Contenido;
                entidad.Tipo = entidadSincronizar.Tipo;
                entidad.CodigoDestinatario = new Guid(data.CodigoDestinatario);
                entidad.CodigoRemitente = new Guid(data.CodigoRemitente);
                entidad.CodigoUnidadOperativa = entidadSincronizar.CodigoUnidadOperativa;
                entidad.CodigoArea = entidadSincronizar.CodigoArea;
                entidad.CodigoConsultaRelacionado = new Guid(data.CodigoConsultaRelacionado);
                entidad.CodigoConsultaOriginal = (entidadSincronizar.CodigoConsultaOriginal == null ? entidadSincronizar.CodigoConsulta : entidadSincronizar.CodigoConsultaOriginal);
                entidad.VistoRemitenteOriginal = true;
                consultaEntityRepository.Insertar(entidad);
                consultaEntityRepository.GuardarCambios();

                //Cambiamos el estado en la consulta original a reenviado
                entidadSincronizar.EstadoConsulta = DatosConstantes.EstadoConsulta.Reenviado;
                consultaEntityRepository.Editar(entidadSincronizar);
                consultaEntityRepository.GuardarCambios();

                //Enviar Correo
                ParametrosNotificacion datos = new ParametrosNotificacion();
                datos.TipoNotificacion = DatosConstantes.TipoNotificacion.RegistroConsultas;
                datos.variables = new Dictionary<string, string>();

                PlantillaNotificacionRequest filtro = new PlantillaNotificacionRequest();
                filtro.CodigoSistema = ConfigurationManager.AppSettings["CODIGO_SISTEMA"].ToString();
                filtro.CodigoTipoNotificacion = datos.TipoNotificacion;

                var datosPlantilla = plantillaNotificacionService.BuscarPlantillaNotificacion(filtro).Result.FirstOrDefault();

                if (datosPlantilla != null)
                {
                    var profile = politicaService.ListaCuentaNotificacionSGC(null, "3").Result.FirstOrDefault();
                    datos.profileCorreo = (profile != null ? profile.Valor.ToString() : "");

                    var urlSistema = politicaService.ListaUrlSistemas(null, "3").Result.FirstOrDefault().Valor.ToString();
                    urlSistema = string.Format("{0}{1}{2}{3}{4}{5}{6}", "<a href='", urlSistema,
                                    DatosConstantes.UrlOpcionesSistema.RutaConsulta, "'>", urlSistema,
                                    DatosConstantes.UrlOpcionesSistema.RutaConsulta, "</a>");

                    var destinatario = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = entidad.CodigoDestinatario }).Result.FirstOrDefault();

                    datos.variables.Add("@para", destinatario.NombreCompleto);
                    datos.variables.Add("@tipo_consulta", data.DescripcionTipo);
                    datos.variables.Add("@url_opcion_sistema", urlSistema);
                    datos.textoNotificar = data.Adicional + "</br></br> Enviado por " + nombreRemitenteOriginal + " el " + entidadSincronizar.FechaEnvio.Value.ToString("dd/M/yyyy") + ":</br></br>" + datosPlantilla.Contenido;

                    foreach (var item in datos.variables)
                    {
                        datos.textoNotificar = datos.textoNotificar.Replace(item.Key, item.Value);
                    }

                    consultaLogicRepository.NotificarConsulta(entidadSincronizar.Asunto, datos.textoNotificar, destinatario.CorreoElectronico, null, datos.profileCorreo);
                }
                
                //copiar los adjuntos del original
                var resultAdjunto = consultaAdjuntoLogicRepository.BuscarConsultaAdjunto(
                    null,
                    new Guid(data.CodigoConsultaRelacionado),
                    null,
                    null,
                    DatosConstantes.EstadoRegistro.Activo
                    );

                if (resultAdjunto != null && resultAdjunto.Count > 0)
                {
                    foreach (var item in resultAdjunto)
                    {
                        item.CodigoConsultaAdjunto = Guid.NewGuid();
                        item.CodigoConsulta = entidad.CodigoConsulta;
                        consultaAdjuntoEntityRepository.Insertar(ConsultaAdapter.ObtenerConsultaAdjuntoEntityDeLogic(item));
                        consultaAdjuntoEntityRepository.GuardarCambios();
                    }
                }

                //Guardar nuevos adjuntos
                if (data.ListaAdjuntos != null)
                {
                    foreach (var item in data.ListaAdjuntos)
                    {
                        byte[] bytes = System.IO.File.ReadAllBytes(item.RutaArchivoSharePoint);
                        item.CodigoConsulta = entidad.CodigoConsulta;
                        item.ArchivoAdjunto = bytes;
                        var resultadoAdjunto = RegistrarConsultaAdjunto(item);
                    }
                }

                    data.ListaAdjuntos = null;

                resultado.Result = data;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ConsultaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Eliminar Consulta
        /// </summary>
        /// <param name="listaCodigoContrato">Lista de Códigos de consultas a Eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> EliminarConsulta(List<object> listaCodigoConsulta)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            try
            {
                foreach (var codigo in listaCodigoConsulta)
                {
                    var llaveEntidad = new Guid(codigo.ToString());
                    consultaEntityRepository.EliminarEntorno(entornoAplicacion, llaveEntidad);
                }

                resultado.Result = consultaEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ConsultaService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Método para retornar los documentos adjuntos por Contrato
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        public ProcessResult<List<ConsultaAdjuntoResponse>> BuscarConsultaAdjunto(ConsultaAdjuntoRequest request)
        {
            ProcessResult<List<ConsultaAdjuntoResponse>> resultado = new ProcessResult<List<ConsultaAdjuntoResponse>>();
            try
            {
                var result = consultaAdjuntoLogicRepository.BuscarConsultaAdjunto(
                    request.CodigoConsultaAdjunto,
                    request.CodigoConsulta,
                    request.CodigoArchivo,
                    request.NombreArchivo,
                    DatosConstantes.EstadoRegistro.Activo
                    );
                resultado.Result = new List<ConsultaAdjuntoResponse>();

                foreach (var item in result)
                {
                    resultado.Result.Add(ConsultaAdapter.ObtenerConsultaAdjuntoResponseDeLogic(item, request.UsuarioSession));
                }
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ConsultaService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Método para registra los documentos adjuntos de la consulta
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        public ProcessResult<string> RegistrarConsultaAdjunto(ConsultaAdjuntoRequest request)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                //var entConsulta = consultaEntityRepository.GetById(request.CodigoConsulta);
                //Registro de información
                string hayError = string.Empty;
                //var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = entConsulta.CodigoUnidadOperativa.ToString() });

                request.CodigoConsultaAdjunto = Guid.NewGuid();
                #region InformacionRepositorioSharePoint
                string nombreArchivo = string.Format("{0}.{1}", request.CodigoConsultaAdjunto.ToString(), request.ExtencionArchivo);
                ProcessResult<string> miDirectorio = RetornaDirectorioFile(request.CodigoConsulta.Value, nombreArchivo, null, true);
                string directorioDestino = miDirectorio.Result.ToString();
                string[] nivelCarpeta = directorioDestino.Split(new char[] { '/' });
                string nombreLista = nivelCarpeta[0];
                string nombreCarpeta = string.Format("{0}/{1}/{2}", nivelCarpeta[1], nivelCarpeta[2], nivelCarpeta[3]);
                #endregion

                #region GrabarContenidoAdjuntoSHP
                MemoryStream msFile = new MemoryStream(request.ArchivoAdjunto);
                if (msFile != null)
                {
                    var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, nombreLista, nombreCarpeta, nombreArchivo, msFile);
                    if (Convert.ToInt32(regSHP.Result) > 0 && hayError == string.Empty)
                    {
                        request.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                        request.RutaArchivoSharePoint = directorioDestino;
                    }
                    else
                    {
                        if (Convert.ToInt32(regSHP.Result) > 0)
                        {
                            var fileShpDelete = sharePointService.EliminaArchivoSharePoint(new List<int>() { Convert.ToInt32(regSHP.Result) }, nombreLista, ref hayError);
                        }
                        resultado.IsSuccess = false;
                        resultado.Exception = new ApplicationLayerException<ContratoService>("Ocurrió un problema al registra el archivo en el SharePoint: " + hayError);
                        LogBL.grabarLogError(new Exception(hayError));
                        return resultado;
                    }
                }
                else
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<ContratoService>("Ocurrió un problema al subir el documento.");
                    LogBL.grabarLogError(new Exception("Ocurrió un problema al subir el documento"));
                    return resultado;
                }
                #endregion

                #region Grabar registro del documento adjunto
                consultaAdjuntoEntityRepository.Insertar(ConsultaAdapter.ObtenerConsultaAdjuntoEntityDeRequest(request));
                consultaAdjuntoEntityRepository.GuardarCambios();

                if (request.CodigoConsultaRelacionado.HasValue)
                {
                    request.CodigoConsultaAdjunto = Guid.NewGuid();
                    request.CodigoConsulta = request.CodigoConsultaRelacionado.Value;
                    consultaAdjuntoEntityRepository.Insertar(ConsultaAdapter.ObtenerConsultaAdjuntoEntityDeRequest(request));
                    consultaAdjuntoEntityRepository.GuardarCambios();
                }

                #endregion
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ConsultaService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Método que elimina los documentos adjuntos al Contrato
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        public ProcessResult<string> EliminarConsultaAdjunto(ConsultaAdjuntoRequest request)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                var contratoDocumentoAdjuntoEntity = consultaAdjuntoEntityRepository.GetById(request.CodigoConsultaAdjunto.Value);

                #region Grabar registro del documento adjunto
                consultaAdjuntoEntityRepository.Eliminar(request.CodigoConsultaAdjunto);
                consultaAdjuntoEntityRepository.GuardarCambios();
                #endregion
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Retorna la ruta del directorio SharePoint para escribir el archivo.
        /// </summary>
        /// <param name="codigoContrato">Código del contrato</param>
        /// <param name="nombreUnidadOperativa">código de la unidad operativa</param>
        /// <param name="nombreFile">Nombre del archivo</param>
        /// <param name="fechaInicioVigencia">Fecha de Inicio de Vigencia</param>
        /// <param name="esAdjunto">Indica que un documento es adjunto</param>
        /// <param name="lstPrmRepositorioShp">Lista del repositorio de SharePoint</param>
        /// <returns>Ruta de directorio de sharepoint</returns>
        public ProcessResult<string> RetornaDirectorioFile(Guid codigoConsulta,
                                                           string nombreFile, DateTime? fechaInicioVigencia = null,
                                                            bool esAdjunto = false, List<CodigoValorResponse> lstPrmRepositorioShp = null)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            string lsValue = string.Empty, directorioSHP = string.Empty; ;
            try
            {
                int Anio = 0, Mes = 0;
                string NombreMes = string.Empty;

                Anio = DateTime.Now.Year;
                Mes = DateTime.Now.Month;

                NombreMes = Utilitario.ObtenerNombreMes(Mes);
                List<CodigoValorResponse> lstRepositorioSharePointSGC = new List<CodigoValorResponse>();
                if (lstPrmRepositorioShp == null)
                {
                    var RepositorioSharePoint = politicaService.ListarRepositorioSharePointSGC(null, "3");
                    lstRepositorioSharePointSGC = RepositorioSharePoint.Result;
                }
                else
                {
                    lstRepositorioSharePointSGC = lstPrmRepositorioShp;
                }

                foreach (CodigoValorResponse item in lstRepositorioSharePointSGC)
                {
                    lsValue = string.Empty;
                    if (item.Codigo.ToString().Equals("01"))
                    {
                        lsValue = item.Valor.ToString().Replace("[ANIO]", Anio.ToString());
                        directorioSHP += lsValue + "/";
                    }
                    if (item.Codigo.ToString().Equals("02"))
                    {
                        lsValue = item.Valor.ToString().Replace("[MES]", Mes.ToString("d2"));
                        lsValue = lsValue.Replace("[NOMBRE_MES]", NombreMes);
                        lsValue = lsValue.Replace("[NOMBRE_UNIDAD_OPERATIVA]", "Consultas") + "/";
                        directorioSHP += lsValue + nombreFile;
                    }
                }
                resultado.Result = directorioSHP + (esAdjunto ? "/Adjunto" : string.Empty);
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);//GRC16062015
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Metodo que retorna los bytes para la generación del archivo PDF.
        /// </summary>
        /// <param name="codigoContrato">Código del Contrato</param>
        /// <param name="codigoContratoEstadio">código del Contrato - estadio.</param>
        /// <param name="NombreArchivoContrato">Nombre del archivo a descargar</param>
        /// <returns>Bytes para generar pdf</returns>
        public ProcessResult<ConsultaAdjuntoResponse> ObtenerArchivoAdjunto(ConsultaAdjuntoRequest request)
        {
            ProcessResult<ConsultaAdjuntoResponse> resultado = new ProcessResult<ConsultaAdjuntoResponse>();
            try
            {
                var consultaAdjuntoResponse = new ConsultaAdjuntoResponse();


                var documentoAdjunto = consultaAdjuntoEntityRepository.GetById(request.CodigoConsultaAdjunto);

                //Obtener documento del SharePoint, consultamos la ruta.                    
                string mensajeError = string.Empty;
                ProcessResult<Object> contenidoArchivo = new ProcessResult<Object>();
                string listName = "";
                string[] rutaArchivo = documentoAdjunto.RutaArchivoSharePoint.Split(new char[] { '/' });
                var codigoArchivo = documentoAdjunto.CodigoArchivo;
                listName = rutaArchivo[0];
                contenidoArchivo = sharePointService.DescargaArchivoPorId(ref mensajeError, codigoArchivo, listName);
                if (!String.IsNullOrEmpty(mensajeError))
                {
                    //resultado.Result = mensajeError;
                    resultado.IsSuccess = false;
                }
                else
                {
                    consultaAdjuntoResponse.NombreArchivo = documentoAdjunto.NombreArchivo;
                    consultaAdjuntoResponse.ContenidoArchivo = contenidoArchivo.Result;

                    resultado.Result = consultaAdjuntoResponse;
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                //resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ConsultaService>(ex);
            }
            return resultado;
        }

        public void EnviarNotificacion(string tipoNotificacion, string descripcionTipo, string asunto, string nombreDestinatario, string correoDestinatario, string textoAdicional = null)
        {
            var asuntoConcatenado = string.Empty;
            ParametrosNotificacion datos = new ParametrosNotificacion();
            datos.TipoNotificacion = tipoNotificacion;
            datos.variables = new Dictionary<string, string>();

            PlantillaNotificacionRequest filtro = new PlantillaNotificacionRequest();
            filtro.CodigoSistema = ConfigurationManager.AppSettings["CODIGO_SISTEMA"].ToString();
            filtro.CodigoTipoNotificacion = datos.TipoNotificacion;

            var datosPlantilla = plantillaNotificacionService.BuscarPlantillaNotificacion(filtro).Result.FirstOrDefault();

            if (datosPlantilla != null)
            {
                var profile = politicaService.ListaCuentaNotificacionSGC(null, "3").Result.FirstOrDefault();
                datos.profileCorreo = (profile != null ? profile.Valor.ToString() : "");

                var urlSistema = politicaService.ListaUrlSistemas(null, "3").Result.FirstOrDefault().Valor.ToString();
                urlSistema = string.Format("{0}{1}{2}{3}{4}{5}{6}", "<a href='", urlSistema,
                                DatosConstantes.UrlOpcionesSistema.RutaConsulta, "'>", urlSistema,
                                DatosConstantes.UrlOpcionesSistema.RutaConsulta, "</a>");

                if (tipoNotificacion == DatosConstantes.TipoNotificacion.RespuestaConsultas)
                {
                    asuntoConcatenado = datosPlantilla.Asunto;

                    datos.variables.Add("@para", nombreDestinatario);
                    datos.variables.Add("@asunto_consulta", asunto);
                    datos.variables.Add("@url_opcion_sistema", urlSistema);
                    datos.textoNotificar = datosPlantilla.Contenido;
                }
                else
                {
                    asuntoConcatenado = datosPlantilla.Asunto + " " + asunto;

                    datos.variables.Add("@para", nombreDestinatario);
                    datos.variables.Add("@tipo_consulta", descripcionTipo);
                    datos.variables.Add("@url_opcion_sistema", urlSistema);
                    datos.textoNotificar = datosPlantilla.Contenido;
                }
                

                foreach (var item in datos.variables)
                {
                    datos.textoNotificar = datos.textoNotificar.Replace(item.Key, item.Value);
                }
            }
            consultaLogicRepository.NotificarConsulta(asuntoConcatenado, datos.textoNotificar, correoDestinatario, null, datos.profileCorreo);
        }
    }
}

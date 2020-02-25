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
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using iTextSharp.tool.xml.html;
using Pe.Stracon.SGC.Infraestructura.Repository.Query.Contractual;
using System.Text;
using iTextSharp.tool.xml.pipeline.html;
using iTextSharp.tool.xml.pipeline.css;
using iTextSharp.tool.xml.parser;
using iTextSharp.tool.xml.pipeline.end;
using Pe.Stracon.SGC.Aplicacion.Core.Message;
using System.Globalization;

using iTextSharp.text.pdf.parser;
using HtmlAgilityPack;

namespace Pe.Stracon.SGC.Aplicacion.Service.Contractual
{
    /// <summary>
    /// Servicio que representa los Contratos
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150525 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class ContratoService : GenericService, IContratoService
    {
        #region Parametros
        /// <summary>
        /// Variable de entorno de la aplicación
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }
        /// <summary>
        /// Servicio de manejo de política 
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Repositorio de manejo de listado contrato logic
        /// </summary>
        public IListadoContratoLogicRepository listadoContratoLogicRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de contrato entity
        /// </summary>
        public IContratoEntityRepository contratoEntityRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de flujo de aprobación logic
        /// </summary>
        public IFlujoAprobacionService flujoAprobacionService { get; set; }
        /// <summary>
        /// Interfaz de comunicación son los servidores SharePoint.
        /// </summary>
        public ISharePointService sharePointService { get; set; }
        /// <summary>
        /// Servicio de manejo de Unidad Operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }
        /// <summary>
        /// Repositorio de manejo de contrato documento entity
        /// </summary>
        public IContratoDocumentoEntityRepository contratoDocumentoEntityRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de contrato estadio entity
        /// </summary>
        public IContratoEstadioEntityRepository contratoEstadioEntityRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de contrato párrafo entity
        /// </summary>
        public IContratoParrafoEntityRepository contratoParrafoEntityRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de contrato párrafo variable entity
        /// </summary>
        public IContratoParrafoVariableEntityRepository contratoParrafoVariableEntityRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de contrato bien entity
        /// </summary>
        public IContratoBienEntityRepository contratoBienEntityRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de contrato firmante entity
        /// </summary>
        public IContratoFirmanteEntityRepository contratoFirmanteEntityRepository { get; set; }
        /// <summary>
        /// Servicio de trabajador
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }
        /// <summary>
        /// Servicio de Plantillas
        /// </summary>
        public IPlantillaService plantillaService { get; set; }
        /// <summary>
        /// Interface para obtener información de la entidad contrato.
        /// </summary>
        public IContratoEntityRepository contratoRepository { get; set; }
        /// <summary>
        /// Interfaz de comunicación para el Flujo de Aprobación Estadio.
        /// </summary>
        public IFlujoAprobacionEstadioEntityRepository flujoAprobacionEstadioRepository { get; set; }
        /// <summary>
        /// Interface para información de Contrato Estadio
        /// </summary>
        public IContratoEstadioEntityRepository contratoEstadioRepository { get; set; }
        /// <summary>
        /// Interfaz de comunicación para el Flujo de Aprobación Logic.
        /// </summary>
        public IFlujoAprobacionLogicRepository flujoAprobacionLogicRepository { get; set; }
        /// <summary>
        /// Servicio de manejo de Contratos
        /// </summary>
        public IContratoLogicRepository contratoLogicRepository { get; set; }
        /// <summary>
        /// Servicio de manejo de Contratos - Observaciones por Estadio
        /// </summary>
        public IContratoEstadioObservacionEntityRepository contratoEstadioObservacionRepository { get; set; }
        /// <summary>
        /// Servicio de manejo de Contratos - Consultas por Estadio
        /// </summary>
        public IContratoEstadioConsultaEntityRepository contratoEstadioConsultaRepository { get; set; }
        /// <summary>
        /// Interface para obtener el entorno de la aplicación.
        /// </summary>
        public IEntornoActualAplicacion entornoAplicacion { get; set; }
        /// <summary>
        /// Interface para obtener información de la entidad de plantilla.
        /// </summary>
        public IPlantillaEntityRepository plantillaEntityRepository { get; set; }
        /// <summary>
        /// Interfaz de comunicación para la Plantilla de Notificación
        /// </summary>
        public IPlantillaNotificacionService plantillaNotificacionService { get; set; }
        /// <summary>
        /// Interface para obtener información del logic del documento adjunto del contrato.
        /// </summary>
        public IContratoDocumentoAdjuntoLogicRepository contratoDocumentoAdjuntoLogicRepository { get; set; }

        /// <summary>
        /// S09-SGC-01
        /// </summary>
        public IContratoDocumentoAdjuntoResolucionLogicRepository contratoDocumentoAdjuntoResolucionLogicRepository { get; set; }

        /// <summary>
        /// Interface para obtener información del entity del documento adjunto del contrato.
        /// </summary>
        public IContratoDocumentoAdjuntoEntityRepository contratoDocumentoAdjuntoEntityRepository { get; set; }

        /// <summary>
        /// S09-SGC-01 
        /// </summary>
        public IContratoDocumentoAdjuntoResolucionEntityRepository contratoDocumentoAdjuntoResolucionEntityRepository { get; set; }

        /// <summary>
        /// Repositorio de plantilla
        /// </summary>
        public IPlantillaEntityRepository plantillaRepository { get; set; }
        /// <summary>
        /// Repositorio de plantilla
        /// </summary>
        public IConsultaLogicRepository consultaLogicRepository { get; set; }

        /// <summary>
        /// Servcio Parámetro Valor
        /// </summary>
        public IParametroValorService parametroValorService { get; set; }

        /// <summary>
        /// Repositorio de Plantilla Logic
        /// </summary>
        public IPlantillaLogicRepository plantillaLogicRepository { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IProveedorEntityRepository proveedorEntityRepository { get; set; }

        #endregion

        /// <summary>
        /// lista las unidades operativas por responsable
        /// </summary>
        /// <param name="codigoResponsable">código de responsable</param>
        /// <returns>Unidades operativas por responsable</returns>
        public ProcessResult<List<UnidadOperativaResponse>> ListarUnidadOperativaResponsable(Guid codigoResponsable)
        {
            ProcessResult<List<UnidadOperativaResponse>> rpta = new ProcessResult<List<UnidadOperativaResponse>>();
            try
            {
                rpta.Result = new List<UnidadOperativaResponse>();
                var lstUOs = contratoLogicRepository.ListarUnidadOperativaResponsable(codigoResponsable);
                foreach (var item in lstUOs)
                {
                    rpta.Result.Add(ContratoAdapter.ObtenerUnidadOperativaResponseDeLogic(item));
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Método para recuperar los registros de la bandeja de proceso.
        /// </summary>
        /// <param name="filtro">Objeto Contrato Request</param>
        /// <param name="lstTipoContrato">Lista de Tipos de Servicio</param>
        /// <param name="lstTipoServicio">Lista de Tipo de Requerimiento</param>
        /// <returns>Registros de bandeja de procesos</returns>                
        public ProcessResult<List<ContratoResponse>> BuscarBandejaProcesosContrato(ContratoRequest filtro,
                                                                                   List<CodigoValorResponse> lstTipoContrato = null,
                                                                                   List<CodigoValorResponse> lstTipoServicio = null)
        {
            ProcessResult<List<ContratoLogic>> listaRegistros = new ProcessResult<List<ContratoLogic>>();
            ProcessResult<List<ContratoResponse>> rpta = new ProcessResult<List<ContratoResponse>>();
            List<CodigoValorResponse> listaTipoServicio;
            List<CodigoValorResponse> listaTipoRequerimiento;
            ContratoResponse itemRpta;
            try
            {
                if (lstTipoContrato != null)
                {
                    listaTipoServicio = lstTipoContrato;
                }
                else
                {
                    listaTipoServicio = politicaService.ListarTipoContrato().Result;
                }
                if (lstTipoServicio != null)
                {
                    listaTipoRequerimiento = lstTipoServicio;
                }
                else
                {
                    listaTipoRequerimiento = politicaService.ListarTipoServicio().Result;
                }

                var listaUO = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa());

                listaRegistros.Result = contratoLogicRepository.ListaBandejaContratos(
                    (Guid)filtro.CodigoResponsable,
                    filtro.CodigoUnidadOperativa,
                    filtro.NombreProveedor,
                    filtro.NumeroDocProveedor,
                    filtro.CodigoTipoServicio,
                    filtro.CodigoTipoRequerimiento,
                    filtro.NombreEstadio,
                    filtro.IndicadorFinalizarAprobacion);

                rpta.Result = new List<ContratoResponse>();
                foreach (ContratoLogic itemLogic in listaRegistros.Result)
                {
                    itemRpta = new ContratoResponse();
                    itemRpta = ContratoAdapter.ObtenerContratoResponseDeLogic(itemLogic, listaUO.Result, listaTipoServicio, listaTipoRequerimiento);
                    rpta.Result.Add(itemRpta);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Método para recuperar los registros de la bandeja de proceso de contratos con observaciones
        /// </summary>
        /// <param name="CodigoContratoEstadio">Codigo de Contrato estadio.</param>
        /// <returns>Registro de bandeja de procesos de contrato por observaciones</returns>
        public ProcessResult<List<ContratoEstadioObservacionResponse>> BuscarBandejaContratosObservacion(Guid CodigoContratoEstadio)
        {
            ProcessResult<List<ContratoEstadioObservacionLogic>> listaRegistros = new ProcessResult<List<ContratoEstadioObservacionLogic>>();
            ProcessResult<List<ContratoEstadioObservacionResponse>> rpta = new ProcessResult<List<ContratoEstadioObservacionResponse>>();
            ContratoEstadioObservacionResponse itemRpta;
            List<Guid?> filtroTrb = new List<Guid?>();
            try
            {
                listaRegistros.Result = contratoLogicRepository.ListaBandejaContratosObservacion(CodigoContratoEstadio);
                foreach (ContratoEstadioObservacionLogic item in listaRegistros.Result)
                {
                    if (!string.IsNullOrEmpty(item.Observador))
                    {
                        var listaTrabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = item.Observador });
                        if (listaTrabajador.Result != null && listaTrabajador.Result.Count > 0)
                        {
                            filtroTrb.Add(Guid.Parse(listaTrabajador.Result[0].CodigoTrabajador));
                            item.Observador = listaTrabajador.Result[0].CodigoTrabajador.ToString();
                        }
                    }
                    if (item.Destinatario != null)
                    {
                        filtroTrb.Add(item.Destinatario);
                    }
                }
                rpta.Result = new List<ContratoEstadioObservacionResponse>();
                var lstTrbajadores = trabajadorService.ListarTrabajadores(filtroTrb);
                var lstTipoRespuesta = politicaService.ListarTipoRespuestaObservacion();

                foreach (ContratoEstadioObservacionLogic itemLogic in listaRegistros.Result)
                {
                    itemRpta = new ContratoEstadioObservacionResponse();
                    itemRpta = ContratoAdapter.ObtenerContratoEstadioResponseDeLogic(itemLogic, lstTrbajadores.Result, lstTipoRespuesta.Result);
                    rpta.Result.Add(itemRpta);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Método para recuperar los registros de la bandeja de proceso de contratos con consultas
        /// </summary>
        /// <param name="CodigoContratoEstadio">Codigo de Contrato estadio.</param>
        /// <returns>Registros de bandeja de procesos de contrato</returns>
        public ProcessResult<List<ContratoEstadioConsultaResponse>> BuscarBandejaContratosConsultas(Guid CodigoContratoEstadio)
        {
            ProcessResult<List<ContratoEstadioConsultaLogic>> listaRegistros = new ProcessResult<List<ContratoEstadioConsultaLogic>>();
            ProcessResult<List<ContratoEstadioConsultaResponse>> rpta = new ProcessResult<List<ContratoEstadioConsultaResponse>>();
            ContratoEstadioConsultaResponse itemRpta;
            List<Guid?> filtroTrb = new List<Guid?>();
            try
            {
                listaRegistros.Result = contratoLogicRepository.ListaBandejaContratosConsultas(CodigoContratoEstadio);

                foreach (ContratoEstadioConsultaLogic item in listaRegistros.Result)
                {
                    //filtroTrb.Add(item.Consultor);
                    var listaTrabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = item.Consultor });
                    if (listaTrabajador.Result != null && listaTrabajador.Result.Count > 0)
                    {
                        //filtroTrb.Add(Guid.Parse(listaTrabajador.Result[0].CodigoTrabajador));
                        item.Consultor = listaTrabajador.Result[0].CodigoTrabajador.ToString();
                        filtroTrb.Add(Guid.Parse(listaTrabajador.Result[0].CodigoTrabajador));
                    }

                    filtroTrb.Add(item.Destinatario);
                }

                var lstTrbajadores = trabajadorService.ListarTrabajadores(filtroTrb);
                rpta.Result = new List<ContratoEstadioConsultaResponse>();
                foreach (ContratoEstadioConsultaLogic itemLogic in listaRegistros.Result)
                {
                    itemRpta = new ContratoEstadioConsultaResponse();
                    itemRpta = ContratoAdapter.ObtenerContratoEstadioResponseDeLogic(itemLogic, lstTrbajadores.Result);
                    rpta.Result.Add(itemRpta);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Registra una Observación del Contrato por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request ContratoEstadioObservacionRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistraContratoEstadioObservacion(ContratoEstadioObservacionRequest objParm)
        {
            ProcessResult<Object> rpta = new ProcessResult<Object>();
            ParametrosNotificacion objPrm = new ParametrosNotificacion();
            bool esNuevoRegistro = false;
            int esNotificado = 0;

            ContratoEstadioObservacionEntity entidad = ContratoAdapter.ObtenerContratoEstadioObservacionEntityDeRequest(objParm);

            //Obtener el responsable del contrato estadio
            var contratoEstadio = contratoLogicRepository.ListarContratoEstadio(entidad.CodigoContratoEstadio).FirstOrDefault();

            if (contratoEstadio != null)
            {
                var codigoResponsable = contratoLogicRepository.ObtenerResponsableContratoEstadioEdicion(entidad.CodigoContratoEstadio, (Guid)entidad.CodigoEstadioRetorno, (Guid)entidad.Destinatario);

                if (codigoResponsable != null)
                {
                    entidad.Destinatario = codigoResponsable;
                }
            }

            int resultadoNuevoContratoEstadio = 0;
            try
            {
                ContratoDocumentoEntity entidadContratoDocumento = null;

                if (objParm.IndicadorAdhesion && objParm.DocumentoContrato != null && objParm.DocumentoContrato.Count() > 0)
                {
                    //Generando contrato documento                        
                    var contratoDocumento = contratoLogicRepository.ListarContratoDocumento(objParm.CodigoContrato.Value).OrderBy(item => item.Version).LastOrDefault();
                    entidad.CodigoArchivo = contratoDocumento.CodigoArchivo;
                    entidad.RutaArchivoSharepoint = contratoDocumento.RutaArchivoSharePoint;

                    entidadContratoDocumento = ContratoDocumentoAdapter.RegistrarContratoDocumento(new ContratoDocumentoRequest()
                    {
                        CodigoContrato = objParm.CodigoContrato.ToString(),
                        IndicadorActual = true,
                        Version = (short)(contratoDocumento.Version + 1)
                    });

                    /*Registramos información del SharePoint*/
                    string nombreFile, lsDirectorioDestino, listName, folderName, hayError = string.Empty;

                    #region InformacionRepositorioSharePoint
                    var rutaArchivoSplit = contratoDocumento.RutaArchivoSharePoint.Split('/').ToList();
                    string miDirectorio = string.Empty;

                    int i = 0;
                    while (i < rutaArchivoSplit.Count - 1)
                    {
                        miDirectorio += rutaArchivoSplit[i] + "/";
                        i++;
                    }
                    nombreFile = string.Format("{0}.{1}", entidadContratoDocumento.CodigoContratoDocumento.ToString(), objParm.ExtencionArchivo);
                    lsDirectorioDestino = miDirectorio;
                    string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });
                    listName = nivelCarpeta[0];
                    folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                    #endregion

                    #region GrabarContenidoContratoSHP
                    MemoryStream msFile = new MemoryStream(objParm.DocumentoContrato);
                    if (msFile != null)
                    {
                        var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, nombreFile, msFile);
                        if (Convert.ToInt32(regSHP.Result) > 0 && hayError == string.Empty)
                        {
                            entidadContratoDocumento.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                            entidadContratoDocumento.RutaArchivoSharePoint = lsDirectorioDestino;
                        }
                        else
                        {
                            if (Convert.ToInt32(regSHP.Result) > 0)
                            {
                                var fileShpDelete = sharePointService.EliminaArchivoSharePoint(new List<int>() { Convert.ToInt32(regSHP.Result) }, listName, ref hayError);
                            }
                            rpta.IsSuccess = false;
                            rpta.Exception = new ApplicationLayerException<ContratoService>("Ocurrió un problema al registra el archivo en el SharePoint: " + hayError);
                            LogBL.grabarLogError(new Exception(hayError));
                            return rpta;
                        }
                    }
                    else
                    {
                        rpta.IsSuccess = false;
                        rpta.Exception = new ApplicationLayerException<ContratoService>("El documento presenta errores.");
                        LogBL.grabarLogError(new Exception("El documento presenta errores."));
                        return rpta;
                    }
                    #endregion
                }

                using (TransactionScope tsc = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (entidadContratoDocumento != null)
                    {
                        contratoDocumentoEntityRepository.RegistrarContratoDocumento(entidadContratoDocumento);
                    }

                    var destinatario = (Guid)objParm.Destinatario;

                    Guid newCodigoContratoEstadio = Guid.NewGuid();
                    resultadoNuevoContratoEstadio = contratoLogicRepository.ObservaEstadioContrato(
                                    newCodigoContratoEstadio,
                                    objParm.CodigoContratoEstadio,
                                    (Guid)objParm.CodigoContrato,
                                    (Guid)objParm.CodigoEstadioRetorno,
                                    destinatario,
                                    entornoAplicacion.UsuarioSession,
                                    entornoAplicacion.Terminal);
                    if (resultadoNuevoContratoEstadio == 1)
                    {
                        if (entidad.CodigoContratoEstadioObservacion == Guid.Empty)
                        {
                            entidad.CodigoContratoEstadioObservacion = Guid.NewGuid();
                            entidad.CodigoContratoEstadio = newCodigoContratoEstadio;
                            entidad.FechaRegistro = DateTime.Now;
                            contratoEstadioObservacionRepository.Insertar(entidad);
                            esNuevoRegistro = true;
                        }
                        else
                        {
                            var entidadUpdate = contratoEstadioObservacionRepository.GetById(entidad.CodigoContratoEstadioObservacion);
                            entidadUpdate.Descripcion = entidad.Descripcion;
                            entidadUpdate.CodigoContratoParrafo = entidad.CodigoContratoParrafo;
                            entidadUpdate.CodigoEstadioRetorno = entidad.CodigoEstadioRetorno;
                            entidadUpdate.Destinatario = entidad.Destinatario;
                            entidadUpdate.CodigoTipoRespuesta = entidad.CodigoTipoRespuesta;
                            entidadUpdate.Respuesta = entidad.Respuesta;
                            entidadUpdate.FechaRespuesta = entidad.FechaRespuesta;
                            contratoEstadioObservacionRepository.Editar(entidadUpdate);
                        }
                        rpta.Result = contratoEstadioObservacionRepository.GuardarCambios();
                    }
                    else
                    {
                        rpta.Result = "Problemas al registrar nuevo Estadío de Contrato ó el contrato ya fue observado, por favor regrese a su bandeja de contratos.";
                        rpta.IsSuccess = false;
                    }
                    tsc.Complete();
                }

                if (esNuevoRegistro)
                {
                    esNotificado = generaNotificacionCorreo(DatosConstantes.TipoNotificacion.ContratosObservado, entidad.CodigoContratoEstadio, null, null, null, null, null, objParm.Destinatario, objParm.NotificacionObservadoCC);

                }
                else
                {
                    esNotificado = generaNotificacionCorreo(DatosConstantes.TipoNotificacion.ObservacionRechazada, entidad.CodigoContratoEstadio);
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                rpta.Result = ex.Message;
                rpta.IsSuccess = false;
            }
            return rpta;
        }
        /// <summary>
        /// Responde la Observación del Contrato por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request ContratoEstadioObservacionRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RespondeContratoEstadioObservacion(ContratoEstadioObservacionRequest objParm)
        {
            ProcessResult<Object> rpta = new ProcessResult<Object>();
            ContratoEstadioObservacionEntity entidad = ContratoAdapter.ObtenerContratoEstadioObservacionEntityDeRequest(objParm);
            bool esNuevoRegistro = false, esNoAplica = false;
            int esNotificado = 0;
            try
            {
                using (TransactionScope tsc = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (entidad.CodigoContratoEstadioObservacion == Guid.Empty)
                    {
                        entidad.CodigoContratoEstadioObservacion = Guid.NewGuid();
                        entidad.FechaRegistro = DateTime.Now;
                        contratoEstadioObservacionRepository.Insertar(entidad);
                        esNuevoRegistro = true;
                    }
                    else
                    {
                        var entidadUpdate = contratoEstadioObservacionRepository.GetById(entidad.CodigoContratoEstadioObservacion);
                        entidadUpdate.CodigoContratoEstadio = entidad.CodigoContratoEstadio;
                        entidadUpdate.Descripcion = entidad.Descripcion;
                        entidadUpdate.CodigoContratoParrafo = entidad.CodigoContratoParrafo;
                        entidadUpdate.CodigoEstadioRetorno = entidad.CodigoEstadioRetorno;
                        entidadUpdate.Destinatario = entidad.Destinatario;
                        entidadUpdate.CodigoTipoRespuesta = entidad.CodigoTipoRespuesta;
                        entidadUpdate.Respuesta = entidad.Respuesta;
                        entidadUpdate.FechaRespuesta = DateTime.Now;
                        contratoEstadioObservacionRepository.Editar(entidadUpdate);

                        /*Si no Aplica, entonces retorna al estadio anterior.*/
                        if (entidad.CodigoTipoRespuesta.Equals(DatosConstantes.TipoRespuestaObservacion.NoAplica))
                        {
                            var contratoEstadio = contratoEstadioRepository.GetById(objParm.CodigoContratoEstadio);
                            /*Obtenemos el estadio anterior.*/
                            var lsEstadioAnterior = contratoLogicRepository.EstadoAnteriorContratoEstadio(objParm.CodigoContratoEstadio, contratoEstadio.CodigoContrato);
                            /*Obtenemos el código de Contrato.*/
                            if (lsEstadioAnterior != null && lsEstadioAnterior.Count > 0)
                            {
                                esNoAplica = true;
                                Guid newCodigoContratoEstadio = Guid.NewGuid();
                                int resultadoNuevoContratoEstadio = 0;
                                resultadoNuevoContratoEstadio = contratoLogicRepository.ObservaEstadioContrato(
                                                newCodigoContratoEstadio,
                                                objParm.CodigoContratoEstadio,
                                                contratoEstadio.CodigoContrato,
                                                lsEstadioAnterior[0].CodigoFlujoAprobacionEstadio,
                                                lsEstadioAnterior[0].CodigoTrabajador.Value,
                                                entornoAplicacion.UsuarioSession,
                                                entornoAplicacion.Terminal);
                            }
                        }
                        rpta.Result = contratoEstadioObservacionRepository.GuardarCambios();
                    }
                    tsc.Complete();
                }
                if (esNuevoRegistro)
                {
                    esNotificado = generaNotificacionCorreo(DatosConstantes.TipoNotificacion.ContratosObservado, entidad.CodigoContratoEstadio);
                }
                else
                {
                    if (esNoAplica)
                    {
                        esNotificado = generaNotificacionCorreo(DatosConstantes.TipoNotificacion.ObservacionRechazada, entidad.CodigoContratoEstadio);
                    }
                }
            }
            catch (Exception ex)
            {
                rpta.Result = ex.Message;
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Registra una Observación del Contrato por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request ContratoEstadioObservacionRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistraContratoEstadioConsulta(ContratoEstadioConsultaRequest objParm)
        {
            ProcessResult<Object> rpta = new ProcessResult<Object>();
            bool esNuevoRegistro = false;
            //Thread procesoNotificar;
            try
            {
                ContratoEstadioConsultaEntity entidad = ContratoAdapter.ObtenerContratoEstadioConsultEntityDeRequest(objParm);
                ParametrosNotificacion objPrm = new ParametrosNotificacion();
                if (entidad.CodigoContratoEstadioConsulta == Guid.Empty)
                {
                    entidad.FechaRegistro = DateTime.Now;
                    entidad.FechaRespuesta = null;
                    entidad.CodigoContratoEstadioConsulta = Guid.NewGuid();
                    contratoEstadioConsultaRepository.Insertar(entidad);
                    esNuevoRegistro = true;
                    rpta.Result = contratoEstadioConsultaRepository.GuardarCambios();
                }
                else
                {
                    //var entidadUpdate = contratoEstadioConsultaRepository.GetById(entidad.CodigoContratoEstadioConsulta);
                    //entidadUpdate.Descripcion = entidad.Descripcion;
                    //entidadUpdate.FechaRegistro = DateTime.Now; //DateTime.Now; // entidad.FechaRegistro;
                    //entidadUpdate.CodigoContratoParrafo = entidad.CodigoContratoParrafo;
                    //entidadUpdate.Destinatario = entidad.Destinatario;
                    //entidadUpdate.Respuesta = entidad.Respuesta;
                    //entidadUpdate.FechaRespuesta = DateTime.Now;
                    //contratoEstadioConsultaRepository.Editar(entidadUpdate);

                    //entidad.UsuarioModificacion = entorno == null ? entornoActualAplicacion.UsuarioSession : entorno.UsuarioSession;
                    //entidad.FechaModificacion = DateTime.Now;
                    //entidad.TerminalModificacion = entorno == null ? entornoActualAplicacion.Terminal : entorno.Terminal;


                    int result = contratoLogicRepository.Responder_Consulta(entidad.CodigoContratoEstadioConsulta,entidad.Respuesta, entornoActualAplicacion.UsuarioSession, entornoActualAplicacion.Terminal);

                }
                
                if (esNuevoRegistro)
                {
                    int notificar = generaNotificacionCorreo(DatosConstantes.TipoNotificacion.NuevaConsulta, entidad.CodigoContratoEstadio);
                }
                else
                {
                    //objPrm = obtieneParametrosCorreo(DatosConstantes.TipoNotificacion.RespuestaConsulta, entidad.CodigoContratoEstadio);
                    //procesoNotificar = new Thread(NotificacionContrato);
                    //procesoNotificar.Start(objPrm);
                    int notificar = generaNotificacionCorreo(DatosConstantes.TipoNotificacion.RespuestaConsulta, entidad.CodigoContratoEstadio);
                }

            }
            catch (Exception ex)
            {
                rpta.Result = ex.Message;
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Registra una Observación del Contrato por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request ContratoEstadioObservacionRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistraContratoEstadio(ContratoEstadioRequest objParm)
        {
            ProcessResult<Object> rpta = new ProcessResult<Object>();
            try
            {
                ContratoEstadioEntity entidad = ContratoAdapter.ObtenerContratoEstadioEntityDeRequest(objParm);
                if (entidad.CodigoContratoEstadio == Guid.Empty)
                {
                    entidad.CodigoContratoEstadio = Guid.NewGuid();
                    contratoEstadioRepository.Insertar(entidad);
                }
                else
                {
                    var entidadUpdate = contratoEstadioRepository.GetById(entidad.CodigoContratoEstadio);
                    entidadUpdate.FechaIngreso = entidad.FechaIngreso;
                    entidadUpdate.FechaFinalizacion = entidad.FechaFinalizacion;
                    entidadUpdate.CodigoResponsable = entidad.CodigoResponsable;
                    entidadUpdate.CodigoEstadoContratoEstadio = entidad.CodigoEstadoContratoEstadio;
                    entidadUpdate.FechaPrimeraNotificacion = entidad.FechaPrimeraNotificacion;
                    entidadUpdate.FechaUltimaNotificacion = entidad.FechaUltimaNotificacion;
                    contratoEstadioRepository.Editar(entidadUpdate);
                }
                rpta.Result = contratoEstadioRepository.GuardarCambios();
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Metodo para obtener datos de Contrato Estadio Observacion por el ID
        /// </summary>
        /// <param name="CodigoContratoEstadioObservacion">Id del Codigo Contrato Estadio Observacion </param>
        /// <returns>Contrato de estadio por observación</returns>
        public ContratoEstadioObservacionResponse ObtieneContratoEstadioObservacionPorID(Guid CodigoContratoEstadioObservacion)
        {
            ContratoEstadioObservacionResponse rpta = new ContratoEstadioObservacionResponse();
            try
            {
                var result = contratoEstadioObservacionRepository.GetById(CodigoContratoEstadioObservacion);
                rpta = ContratoAdapter.ObtenerContratoEstadioObservacionResponseDeEntity(result);
            }
            catch (Exception)
            {
                rpta = null;
            }
            return rpta;
        }
        /// <summary>
        /// Metodo para obtener datos de Contrato Estadio Consulta por el ID
        /// </summary>
        /// <param name="CodigoContratoEstadioConsulta">Id del Codigo Contrato Estadio Consulta </param>
        /// <returns>Contrato estadio</returns>
        public ContratoEstadioConsultaResponse ObtieneContratoEstadioConsultaPorID(Guid CodigoContratoEstadioConsulta)
        {
            ContratoEstadioConsultaResponse rpta = new ContratoEstadioConsultaResponse();

            try
            {
                var result = contratoEstadioConsultaRepository.GetById(CodigoContratoEstadioConsulta);
                rpta = ContratoAdapter.ObtenerContratoEstadioConsultaResponseDeEntity(result);
            }
            catch (Exception)
            {
                rpta = null;
            }
            return rpta;
        }

        /// <summary>
        /// Metodo para aprobar cada contrato según su estadío.
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato </param>
        /// <param name="codigoContratoEstadio">Código de Contrato Estadío</param>
        /// <param name="login"></param>
        /// <param name="MotivoAprobacion">Motivo de Aprobación</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> ApruebaContratoEstadio(Guid codigoContrato, Guid codigoContratoEstadio, string MotivoAprobacion, string login = null)
        {
            ProcessResult<Object> rpta = new ProcessResult<Object>();
            int resultProcesoAprobacion = -1;
            string contenidoContrato = string.Empty, NombreFile = string.Empty, listName = string.Empty, folderName = string.Empty,
                   lsDirectorioDestino = string.Empty, hayError = string.Empty;

            try
            {
                ContratoEntity entContrato = contratoRepository.GetById(codigoContrato);
                PlantillaEntity entPlantilla = plantillaRepository.GetById(entContrato.CodigoPlantilla);
                ContratoEstadioEntity entidadContratoEstadio = contratoEstadioRepository.GetById(codigoContratoEstadio);
                FlujoAprobacionEstadioEntity entidadFlujoAprobacionEstadio = flujoAprobacionEstadioRepository.GetById(entidadContratoEstadio.CodigoFlujoAprobacionEstadio);

                var flujosAprobacion = flujoAprobacionService.BuscarBandejaFlujoAprobacionEstadio(null, entidadFlujoAprobacionEstadio.CodigoFlujoAprobacion.ToString()).Result.OrderByDescending(o => o.Orden);
                var esUltimoEstadio = false;

                if (flujosAprobacion.Count() > 0)
                {
                    var ultimoEstadio = new Guid(flujosAprobacion.FirstOrDefault().CodigoFlujoAprobacionEstadio);

                    if (ultimoEstadio == entidadFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio)
                    {
                        esUltimoEstadio = true;
                    }
                }

                if (entidadFlujoAprobacionEstadio.IndicadorPermiteCarga)
                {
                    var documentoFinal = contratoLogicRepository.DocumentosPorContrato(codigoContrato).FirstOrDefault();

                    if (documentoFinal.FechaCreacion < entidadContratoEstadio.FechaCreacion)
                    {
                        rpta.Result = "Debe de subir el contrato antes de aprobar el mismo.";
                        rpta.IsSuccess = false;
                        rpta.Exception = new ApplicationLayerException<ContratoService>("Debe de subir el contrato antes de aprobar el mismo.");
                        return rpta;
                    }
                }

                List<string> revisores = null;
                List<TrabajadorResponse> firmantes = null;

                if (entContrato.IndicadorVersionOficial == false)
                {
                    revisores = ObtenerListaRevisoresStracon(entContrato, entidadFlujoAprobacionEstadio, login).Result;

                    firmantes = ObtenerListaFirmantesStracon(new ContratoResponse() { CodigoContrato = entContrato.CodigoContrato, CodigoFlujoAprobacion = entContrato.CodigoFlujoAprobacion, CodigoProveedor = entContrato.CodigoProveedor }).Result;

                }
                var entUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = entContrato.CodigoUnidadOperativa.ToString() });

                var RepositorioSharePoint = politicaService.ListarRepositorioSharePointSGC(null, "3");
                string siteURLShp = sharePointService.RetornaSiteUrlSharePoint();
                Microsoft.SharePoint.Client.SharePointOnlineCredentials crdSHP = sharePointService.RetornaCredencialesServer();
              

                #region Cambio para Logo por Unidad Operativa
                var urlLogo = "";
                var entUnidadOperativa_logo = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = entContrato.CodigoUnidadOperativa.ToString() });

                if (entUnidadOperativa_logo.Result[0].LogoUnidadOperativa == null)
                {

                    urlLogo = politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.UrlLogoStracon).FirstOrDefault().Atributo3;
                }
                else
                {
                    urlLogo = entUnidadOperativa_logo.Result[0].LogoUnidadOperativa;
                }


                #endregion

                //var urlLogo = politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.UrlLogoStracon).FirstOrDefault().Atributo3;
                var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.WidthLogo).FirstOrDefault().Atributo3);
                var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.HeightLogo).FirstOrDefault().Atributo3);

                var usuarioEstadio = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = entContrato.UsuarioCreacion }).Result.FirstOrDefault();

                using (TransactionScope tsc = new TransactionScope(TransactionScopeOption.Required))
                {
                    resultProcesoAprobacion = contratoLogicRepository.ApruebaContratoEstadio(codigoContratoEstadio,
                                                entUnidadOperativa.Result[0].CodigoIdentificacion,
                                                entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal, usuarioEstadio.CodigoTrabajador, MotivoAprobacion.Trim());

                    if (resultProcesoAprobacion == 1)
                    {
                        if (entidadFlujoAprobacionEstadio.IndicadorVersionOficial && !entPlantilla.IndicadorAdhesion)
                        {
                            List<ContratoDocumentoLogic> contratoDocumento = contratoLogicRepository.DocumentosPorContrato(codigoContrato);
                            //Esta lista contiene 2 registros, la ultima modificación y la anterior.
                            if (contratoDocumento != null && contratoDocumento.Count > 0)
                            {
                                #region InformacionRepositorioSharePoint
                                NombreFile = string.Format("{0}.{1}", contratoDocumento[0].CodigoContratoDocumento.ToString(), DatosConstantes.ArchivosContrato.ExtensionValidaCarga);
                                ProcessResult<string> miDirectorio = RetornaDirectorioFile(codigoContrato, entUnidadOperativa.Result[0].Nombre, NombreFile, entContrato.FechaInicioVigencia, false, RepositorioSharePoint.Result);
                                lsDirectorioDestino = miDirectorio.Result.ToString();
                                /*Revisamos la estructura de las carpetas SharePoint*/
                                string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });
                                listName = nivelCarpeta[0];
                                folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                                #endregion

                                #region GrabarContenidoContratoSHP

                                contenidoContrato = contratoDocumento[0].Contenido;
                                MemoryStream msFile = null;

                                ////MLV
                                var numeroCabecera = entContrato.NumeroAdenda > 0 ? string.IsNullOrEmpty(entContrato.NumeroAdendaConcatenado) ? entContrato.NumeroContrato : entContrato.NumeroAdendaConcatenado : entContrato.NumeroContrato;
                                msFile = new MemoryStream(GenerarPdfDesdeHtml(contenidoContrato, "", numeroCabecera, codigoContrato, entContrato.CodigoPlantilla, firmantes, revisores, null, false, urlLogo, widthLogo, heightLogo));

                                if (msFile != null)
                                {
                                    var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, NombreFile, msFile, siteURLShp, crdSHP);
                                    if (Convert.ToInt32(regSHP.Result) > 0)
                                    {
                                        ContratoDocumentoEntity conDocEnt = new ContratoDocumentoEntity();
                                        conDocEnt.CodigoContratoDocumento = contratoDocumento[0].CodigoContratoDocumento;
                                        conDocEnt.CodigoContrato = contratoDocumento[0].CodigoContrato;
                                        conDocEnt.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                                        conDocEnt.RutaArchivoSharePoint = lsDirectorioDestino;
                                        conDocEnt.Contenido = contratoDocumento[0].Contenido;
                                        conDocEnt.IndicadorActual = true;
                                        conDocEnt.EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;
                                        conDocEnt.UsuarioCreacion = contratoDocumento[0].UsuarioCreacion;
                                        conDocEnt.FechaCreacion = contratoDocumento[0].FechaCreacion;
                                        conDocEnt.TerminalCreacion = contratoDocumento[0].TerminalCreacion;
                                        conDocEnt.Version = contratoDocumento[0].Version;
                                        contratoDocumentoEntityRepository.Editar(conDocEnt, entornoAplicacion);
                                        int rptaCambios = contratoDocumentoEntityRepository.GuardarCambios();
                                        if (rptaCambios != 1)
                                        {
                                            /*Borramos el documento subido al SHP.*/
                                            var fileShpDelete = sharePointService.EliminaArchivoSharePoint(new List<int>() { conDocEnt.CodigoArchivo }, listName, ref hayError);
                                            rpta.Result = "";
                                            rpta.IsSuccess = false;
                                            rpta.Exception = new ApplicationLayerException<ContratoService>("Problemas al registrar el Contrato Documento Entity: Contrato-Service : ApruebaContratoEstadio"); ;
                                            return rpta;
                                        }
                                    }
                                    else
                                    {
                                        rpta.Result = hayError;
                                        rpta.IsSuccess = false;
                                        rpta.Exception = regSHP.Exception;
                                        return rpta;
                                    }
                                }
                                else
                                {
                                    rpta.Result = "No se pudo generar los bytes del contenido del Documento, verificar.";
                                    rpta.IsSuccess = false;
                                    rpta.Exception = new ApplicationLayerException<ContratoService>("No se pudo generar los bytes del contenido del Documento, verificar.");
                                    return rpta;
                                }

                                #endregion
                            }
                            else
                            {
                                rpta.Result = "No existe contenido del documento para generar información, verifique Contrato-Documento.";
                                rpta.IsSuccess = false;
                            }
                        }
                        rpta.Result = resultProcesoAprobacion;
                    }
                    else
                    {
                        rpta.Result = "Problemas al generar la aprobación del documento.";
                        rpta.IsSuccess = false;
                    }
                    tsc.Complete();
                }
                if (resultProcesoAprobacion == 1)
                {
                    List<ContratoDocumentoLogic> contratoEstadio = contratoLogicRepository.DocumentosPorContrato(codigoContrato);
                    if (contratoEstadio != null && contratoEstadio.Count > 0)
                    {
                        try
                        {
                            //Enviar notificación para contratos históricos aprobados
                            if (entContrato.CodigoTipoRequerimiento == DatosConstantes.TipoServicio.ContratoHistorico && entContrato.CodigoEstado == DatosConstantes.EstadoContrato.Aprobacion)
                            {
                                var contratoEstadioEdicion = contratoLogicRepository.ObtenerContratoEstadioEdicion(codigoContrato, entContrato.CodigoFlujoAprobacion);
                                generaNotificacionCorreo(DatosConstantes.TipoNotificacion.AprobacionContratoHistorico, contratoEstadioEdicion, null, null, null, null, entContrato.UsuarioCreacion);
                            }
                            else
                            {
                                if (esUltimoEstadio == false)
                                {
                                    var codigoResponsable = flujoAprobacionLogicRepository.ObtenerResponsableSiguienteEstadioFlujoAprobacion(entidadFlujoAprobacionEstadio.CodigoFlujoAprobacion, entidadFlujoAprobacionEstadio.Orden, entidadFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio, codigoContratoEstadio);
                                    generaNotificacionCorreo(DatosConstantes.TipoNotificacion.NuevoContratoBandeja, codigoContratoEstadio, null, null, null, null, null, codigoResponsable);
                                }
                            }
                        }
                        catch
                        {
                            rpta.Result = "No se pudo enviar la notificación.";
                            rpta.IsSuccess = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rpta.Result = ex.Message;
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Método para retornar los párrafos por contrato
        /// </summary>
        /// <param name="CodigoContrato">Código de Contrato</param>
        /// <returns>Parrafos de contrato</returns>
        public ProcessResult<List<ContratoParrafoResponse>> RetornaParrafosPorContrato(Guid CodigoContrato)
        {
            ProcessResult<List<ContratoParrafoResponse>> rpta = new ProcessResult<List<ContratoParrafoResponse>>();
            try
            {
                List<ContratoParrafoLogic> result = contratoLogicRepository.RetornaParrafosPorContrato(CodigoContrato);
                ContratoParrafoResponse objRsp;
                rpta.Result = new List<ContratoParrafoResponse>();
                foreach (ContratoParrafoLogic item in result)
                {
                    objRsp = new ContratoParrafoResponse();
                    objRsp = ContratoAdapter.ObtenerContratoParrafoResponseDeLogic(item);
                    rpta.Result.Add(objRsp);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Método para retornar los párrafos por contrato
        /// </summary>
        /// <param name="CodigoContratoEstadio">Código de estadio de contrato</param>
        /// <returns>Parrafos de contrato</returns>
        public ProcessResult<List<FlujoAprobacionEstadioResponse>> RetornaEstadioContratoObservacion(Guid CodigoContratoEstadio)
        {
            ProcessResult<List<FlujoAprobacionEstadioResponse>> rpta = new ProcessResult<List<FlujoAprobacionEstadioResponse>>();
            try
            {
                List<FlujoAprobacionEstadioLogic> result = contratoLogicRepository.RetornaEstadioContratoObservacion(CodigoContratoEstadio);
                FlujoAprobacionEstadioResponse objRsp;
                List<Guid?> filtroTrb = new List<Guid?>();

                foreach (FlujoAprobacionEstadioLogic item in result)
                {
                    if (!string.IsNullOrEmpty(item.CodigoResponsable))
                    {
                        filtroTrb.Add(Guid.Parse(item.CodigoResponsable));
                    }

                    if (!string.IsNullOrEmpty(item.UsuarioCreacion))
                    {
                        var usuarioEstadioEdicion = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = item.UsuarioCreacion }).Result.FirstOrDefault();
                        item.CorreoElectronico = usuarioEstadioEdicion.CorreoElectronico;

                        filtroTrb.Add(new Guid(usuarioEstadioEdicion.CodigoTrabajador));

                        if (item.Orden == 1)
                        {
                            item.CodigoResponsable = usuarioEstadioEdicion.CodigoTrabajador;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(item.CodigoResponsable))
                            {
                                item.CodigoResponsable = usuarioEstadioEdicion.CodigoTrabajador;
                            }
                            else
                            {
                                if (usuarioEstadioEdicion.CodigoTrabajador == item.CodigoResponsable)
                                {
                                    item.CodigoResponsable = usuarioEstadioEdicion.CodigoTrabajador;
                                }
                            }
                        }
                    }
                }

                var lstTrbajadores = trabajadorService.ListarTrabajadores(filtroTrb);

                rpta.Result = new List<FlujoAprobacionEstadioResponse>();
                foreach (FlujoAprobacionEstadioLogic item in result)
                {
                    objRsp = new FlujoAprobacionEstadioResponse();
                    objRsp = ContratoAdapter.ObtenerFlujoAprobacionEstadioResponseDeLogic(item, lstTrbajadores.Result);
                    rpta.Result.Add(objRsp);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Método que retorna los responsable por flujo de aprobación.
        /// </summary>
        /// <param name="codigoFlujoAprobacion">código del flujo de aprobación.</param>
        /// <param name="codigoContrato"></param>
        /// <returns>Responsables por flujo de aprobación</returns>
        public ProcessResult<List<TrabajadorResponse>> RetornaResponsablesFlujoEstadio(Guid codigoFlujoAprobacion, Guid codigoContrato)
        {
            ProcessResult<List<TrabajadorResponse>> rpta = new ProcessResult<List<TrabajadorResponse>>();
            List<Guid?> filtroTrb = new List<Guid?>();
            try
            {
                //rpta.Result = new List<TrabajadorResponse>();
                rpta.Result = contratoLogicRepository.RetornaResponsablesFlujoEstadio(codigoFlujoAprobacion, codigoContrato);
                foreach (var item in rpta.Result)
                {
                    if (!string.IsNullOrEmpty(item.CodigoTrabajador))
                    {
                        filtroTrb.Add(Guid.Parse(item.CodigoTrabajador));
                    }

                    if (!string.IsNullOrEmpty(item.UsuarioCreacion))
                    {
                        var usuarioEstadioEdicion = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = item.UsuarioCreacion }).Result.FirstOrDefault();
                        if (usuarioEstadioEdicion != null)
                        {
                            item.CorreoElectronico = usuarioEstadioEdicion.CorreoElectronico;

                            filtroTrb.Add(new Guid(usuarioEstadioEdicion.CodigoTrabajador));
                            item.CodigoTrabajador = usuarioEstadioEdicion.CodigoTrabajador;
                        }
                    }
                }
                var lstTrbajadores = trabajadorService.ListarTrabajadores(filtroTrb);
                int li_index = -1;
                foreach (var item in rpta.Result)
                {
                    li_index = lstTrbajadores.Result.FindIndex(x => x.CodigoTrabajador.ToLower() == item.CodigoTrabajador.ToLower());
                    if (li_index > -1)
                    {
                        item.NombreCompleto = lstTrbajadores.Result[li_index].NombreCompleto;
                    }
                    else
                    {
                        item.NombreCompleto = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Método para listar los documentos de la bandeja de solicitud.
        /// </summary>
        /// <param name="filtro">Información en el ContratoRequest</param>
        /// <returns>Documentos de bandeja de solicitud</returns>
        public ProcessResult<List<ContratoResponse>> ListaBandejaSolicitudContratos(ContratoRequest filtro)
        {
            ProcessResult<List<ContratoLogic>> listaRegistros = new ProcessResult<List<ContratoLogic>>();
            ProcessResult<List<ContratoResponse>> rpta = new ProcessResult<List<ContratoResponse>>();
            ContratoResponse itemRpta;
            try
            {
                FiltroUnidadOperativa filtroUO = new FiltroUnidadOperativa();
                filtroUO.Nivel = DatosConstantes.Nivel.Proyecto;
                var listaUO = unidadOperativaService.BuscarUnidadOperativa(filtroUO);
                var listaEdicion = politicaService.ListarEstadoEdicion();
                var listaTipoDocumento = politicaService.ListarTipoDocumentoContrato();

                listaRegistros.Result = contratoLogicRepository.ListaBandejaSolicitudContratos(filtro.NumeroContrato,
                    filtro.CodigoUnidadOperativa,
                    filtro.NombreProveedor,
                    filtro.NumeroDocProveedor);

                rpta.Result = new List<ContratoResponse>();
                foreach (ContratoLogic itemLogic in listaRegistros.Result)
                {
                    itemRpta = new ContratoResponse();
                    itemRpta = ContratoAdapter.ObtenerContratoResponseDeLogic(itemLogic, listaUO.Result, null, null,
                                                                    listaEdicion.Result, listaTipoDocumento.Result);

                    var usuarioModificacion = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = itemRpta.UsuarioCreacion }).Result.FirstOrDefault();
                    if (usuarioModificacion != null)
                    {
                        itemRpta.UsuarioCreacion = usuarioModificacion.NombreCompleto;
                    }
                    else
                    {
                        itemRpta.UsuarioCreacion = null;
                    }

                    rpta.Result.Add(itemRpta);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Método para listar los documentos de la bandeja de revisión de contratos.
        /// </summary>
        /// <param name="filtro">Información en el ContratoRequest</param>
        /// <returns>Lista de contratos para revisión</returns>
        public ProcessResult<List<ContratoResponse>> ListaBandejaRevisionContratos(ContratoRequest filtro)
        {
            ProcessResult<List<ContratoLogic>> listaRegistros = new ProcessResult<List<ContratoLogic>>();
            ProcessResult<List<ContratoResponse>> rpta = new ProcessResult<List<ContratoResponse>>();
            ContratoResponse itemRpta;
            try
            {
                FiltroUnidadOperativa filtroUO = new FiltroUnidadOperativa();
                filtroUO.Nivel = DatosConstantes.Nivel.Proyecto;
                var listaUO = unidadOperativaService.BuscarUnidadOperativa(filtroUO);
                var listaEdicion = politicaService.ListarEstadoEdicion();
                var listaTipoDocumento = politicaService.ListarTipoDocumentoContrato();

                listaRegistros.Result = contratoLogicRepository.ListaBandejaRevisionContratos(filtro.NumeroContrato,
                    filtro.CodigoUnidadOperativa,
                    filtro.NombreProveedor,
                    filtro.NumeroDocProveedor);

                rpta.Result = new List<ContratoResponse>();
                foreach (ContratoLogic itemLogic in listaRegistros.Result)
                {
                    itemRpta = new ContratoResponse();
                    itemRpta = ContratoAdapter.ObtenerContratoResponseDeLogic(itemLogic, listaUO.Result, null, null,
                                                                    listaEdicion.Result, listaTipoDocumento.Result);

                    var usuarioModificacion = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = itemRpta.UsuarioCreacion }).Result.FirstOrDefault();
                    itemRpta.UsuarioCreacion = usuarioModificacion.NombreCompleto;

                    rpta.Result.Add(itemRpta);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Metodo para obtener datos de Contrato Estadio Observacion por el ID
        /// </summary>
        /// <param name="codigoContrato">Id del Codigo Contrato Estadio Observacion </param>
        /// <returns>Contratos de estadio</returns>
        public ProcessResult<ContratoResponse> ObtieneContratoPorID(Guid codigoContrato)
        {
            ProcessResult<ContratoResponse> rpta = new ProcessResult<ContratoResponse>();
            try
            {
                var result = contratoRepository.GetById(codigoContrato);
                rpta.Result = new ContratoResponse();
                rpta.Result = ContratoAdapter.ObtenerContratoResponseDeEntity(result);
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Registra la Respuesta de la Solicitud de Modificación del Contrato
        /// </summary>
        /// <param name="objCtr">Objeto request de Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistraRespuestaContrato(ContratoRequest objCtr)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                var contrato = contratoRepository.GetById(new Guid(objCtr.CodigoContrato));
                var entUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = contrato.CodigoUnidadOperativa.ToString() });
                List<ContratoDocumentoLogic> contratoDocumento = new List<ContratoDocumentoLogic>();

                var RepositorioSharePoint = politicaService.ListarRepositorioSharePointSGC(null, "3");
                string SiteURL = sharePointService.RetornaSiteUrlSharePoint();

                Microsoft.SharePoint.Client.SharePointOnlineCredentials crdSHP = sharePointService.RetornaCredencialesServer();
                var lstMontoMinimo = politicaService.ListarMontoMinimoControlDinamico().Result;
                var montoMinimoPrm = lstMontoMinimo.Where(a => a.Atributo4 == contrato.CodigoMoneda).FirstOrDefault().Atributo3;
                if (montoMinimoPrm == null)
                {
                    montoMinimoPrm = 0;
                }
                int resultProcesoAprobacion = -1;

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.SolicitudAutorizada) ||
                        objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.SolicitudDenegada) ||
                        objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.Editada))
                {
                    contrato.RespuestaModificacion = objCtr.RespuestaModificacion;
                }
                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionAprobada))
                {
                    contrato.CodigoEstado = DatosConstantes.EstadoContrato.Aprobacion;
                }
                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionRechazada))
                {
                    contrato.RespuestaModificacion = objCtr.RespuestaModificacion;
                    contrato.ComentarioModificacion = objCtr.ComentarioModificacion;
                }

                contrato.CodigoEstadoEdicion = objCtr.CodigoEstadoEdicion;

                contratoRepository.Editar(contrato, entornoAplicacion);
                resultado.Result = contratoRepository.GuardarCambios();

                var listaRevisores = ObtenerListaRevisoresStracon(contrato).Result;
                var listaFirmantes = ObtenerListaFirmantesStracon(new ContratoResponse() { CodigoContrato = contrato.CodigoContrato, CodigoFlujoAprobacion = contrato.CodigoFlujoAprobacion, CodigoProveedor = contrato.CodigoProveedor }).Result;

                var urlLogo = politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.UrlLogoStracon).FirstOrDefault().Atributo3;
                var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.WidthLogo).FirstOrDefault().Atributo3);
                var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.HeightLogo).FirstOrDefault().Atributo3);

                //Obtener el usuario de creación del contrato para reemplazarlo como responsable en el flujo
                var usuarioEstadio = string.Empty;

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionAprobada))
                {
                    var trabajadorEdicion = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = contrato.UsuarioCreacion }).Result;

                    if (trabajadorEdicion != null)
                    {
                        var objTrabajador = trabajadorEdicion.FirstOrDefault();

                        if (objTrabajador != null)
                        {
                            usuarioEstadio = objTrabajador.CodigoTrabajador;
                        }
                    }
                }

                using (TransactionScope tsc = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (Convert.ToInt32(resultado.Result) == 1 && objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.Editada))
                    {
                        Guid newCodigoContratoDoc = Guid.NewGuid();
                        #region InformacionRepositorioSharePoint
                        string NombreFile = string.Format("{0}.{1}", newCodigoContratoDoc.ToString(), DatosConstantes.ArchivosContrato.ExtensionValidaCarga);
                        ProcessResult<string> miDirectorio = RetornaDirectorioFile(contrato.CodigoContrato, entUnidadOperativa.Result[0].Nombre, NombreFile, contrato.FechaInicioVigencia, false, RepositorioSharePoint.Result);
                        string lsDirectorioDestino = miDirectorio.Result.ToString();
                        string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });
                        string listName = nivelCarpeta[0];
                        string folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                        string hayError = string.Empty;
                        #endregion

                        #region GrabarContenidoContratoSHP
                        ////MLV
                        //MemoryStream msFile = new MemoryStream(GenerarPdfDesdeHtml(objCtr.ContenidoContrato, "", contrato.NumeroContrato, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));
                        var numeroCabecera = contrato.NumeroAdenda > 0 ? string.IsNullOrEmpty(contrato.NumeroAdendaConcatenado) ? contrato.NumeroContrato : contrato.NumeroAdendaConcatenado : contrato.NumeroContrato;
                        MemoryStream msFile = new MemoryStream(GenerarPdfDesdeHtml(objCtr.ContenidoContrato, "", numeroCabecera, null, contrato.CodigoPlantilla, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));

                        if (msFile != null)
                        {
                            var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, NombreFile, msFile, SiteURL, crdSHP);
                            if (Convert.ToInt32(regSHP.Result) > 0)
                            {
                                ContratoDocumentoLogic cdl = new ContratoDocumentoLogic();
                                cdl.CodigoContratoDocumento = newCodigoContratoDoc;
                                cdl.CodigoContrato = contrato.CodigoContrato;
                                cdl.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                                cdl.RutaArchivoSharePoint = lsDirectorioDestino;
                                cdl.Contenido = objCtr.ContenidoContrato;
                                //El procedimiento se encarga de registrar el nuevo CD, inactivando los anteriores.
                                int regCD = contratoLogicRepository.RegistraContratoDocumentoCargaArchivo(cdl, entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal);
                                if (regCD != 1)
                                {
                                    /*Borramos el documento subido al SHP.*/
                                    var fileShpDelete = sharePointService.EliminaArchivoSharePoint(new List<int>() { cdl.CodigoArchivo }, listName, ref hayError);
                                    resultado.Result = "";
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<ContratoService>("Problemas al registrar el Contrato Documento Entity: Contrato-Service : RegistraRespuestaContrato");
                                    return resultado;
                                }
                            }
                        }
                        else
                        {
                            resultado.Result = hayError;
                            resultado.IsSuccess = false;
                            resultado.Exception = new ApplicationLayerException<ContratoService>("Problemas al registrar nueva Version de Documento en SharePoint");
                            return resultado;
                        }
                        #endregion
                    }
                    if (Convert.ToInt32(resultado.Result) == 1 && objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionAprobada))
                    {
                        contratoDocumento = contratoLogicRepository.DocumentosPorContrato(contrato.CodigoContrato);

                        if (contratoDocumento != null && contratoDocumento.Count > 0)
                        {
                            resultProcesoAprobacion = contratoLogicRepository.ApruebaContratoEstadio((Guid)contratoDocumento[0].CodigoContratoEstadio,
                                                                            entUnidadOperativa.Result[0].CodigoIdentificacion,
                                                                            entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal, usuarioEstadio, "");
                            if (resultProcesoAprobacion != 1)
                            {
                                resultado.Result = "Problemas al registrar la aprobación del contrato.";
                                resultado.IsSuccess = false;
                                resultado.Exception = new ApplicationLayerException<ContratoService>("Problemas al registrar la aprobación del contrato");
                                tsc.Dispose();
                            }
                        }
                        else
                        {
                            resultado.Result = "No se generó correctamente el Codigo del contrato Estadío. Contrato Service - RegistraRespuestaContrato.";
                            resultado.IsSuccess = false;
                            resultado.Exception = new ApplicationLayerException<ContratoService>("No se generó correctamente el Codigo del contrato Estadío. Contrato Service - RegistraRespuestaContrato.");
                            tsc.Dispose();
                        }
                    }
                    tsc.Complete();
                }

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionRechazada))
                {
                    var contratoEstadioEdicion = contratoLogicRepository.ObtenerContratoEstadioEdicion(contrato.CodigoContrato, contrato.CodigoFlujoAprobacion);
                    generaNotificacionCorreo(DatosConstantes.TipoNotificacion.ContratoRechazadoPorLegal, contratoEstadioEdicion, null, null, null, null, contrato.UsuarioCreacion);
                }
                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionAprobada))
                {
                    ContratoEstadioEntity entidadContratoEstadio = contratoEstadioRepository.GetById(contratoDocumento[0].CodigoContratoEstadio);
                    FlujoAprobacionEstadioEntity entidadFlujoAprobacionEstadio = flujoAprobacionEstadioRepository.GetById(entidadContratoEstadio.CodigoFlujoAprobacionEstadio);

                    var codigoResponsable = flujoAprobacionLogicRepository.ObtenerResponsableSiguienteEstadioFlujoAprobacion((Guid)contrato.CodigoFlujoAprobacion, entidadFlujoAprobacionEstadio.Orden, entidadFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio, entidadContratoEstadio.CodigoContratoEstadio);
                    generaNotificacionCorreo(DatosConstantes.TipoNotificacion.NuevoContratoBandeja, entidadContratoEstadio.CodigoContratoEstadio, null, null, null, null, null, codigoResponsable);
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return resultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ProcessResult<List<ReporteContratoObservadoAprobadoResponse>> BuscarNumeroContrato(ReporteContratoObservadoAprobadoRequest filtro)
        {
            ProcessResult<List<ReporteContratoObservadoAprobadoResponse>> resultado = new ProcessResult<List<ReporteContratoObservadoAprobadoResponse>>();

            try
            {

                List<ContratoLogic> listado = contratoLogicRepository.BuscarNumeroContrato(
                                                                                                 filtro.CodigoUnidadOperativa,
                                                                                                 filtro.NumeroContrato,
                                                                                                 filtro.NumeroPagina,
                                                                                                 filtro.RegistrosPagina
                                                                                                 );

                resultado.Result = new List<ReporteContratoObservadoAprobadoResponse>();

                foreach (var registro in listado)
                {
                    var contrato = ContratoAdapter.ObtenerNumeroContratoPaginado(registro);
                    resultado.Result.Add(contrato);
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);

                //resultado.Result    = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }

            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ProcessResult<List<ReporteContratoObservadoAprobadoResponse>> BuscarContratoObservadoAprobado(ReporteContratoObservadoAprobadoRequest filtro)
        {
            ProcessResult<List<ReporteContratoObservadoAprobadoResponse>> resultado = new ProcessResult<List<ReporteContratoObservadoAprobadoResponse>>();

            try
            {
                Guid? codigoUnidadOperativa = filtro.CodigoUnidadOperativa != null ? filtro.CodigoUnidadOperativa : (Guid?)null;
                Guid? codigoContrato = filtro.CodigoContrato != null ? filtro.CodigoContrato : (Guid?)null;
                DateTime? fechaInicioVigencia = null;
                DateTime? fechaFinVigencia = null;
                string nombreBaseDatoPolitica = ConfigurationManager.AppSettings["NombreBaseDatosPoliticas"].ToString();

                if (!string.IsNullOrWhiteSpace(filtro.FechaConsultaDesdeString))
                {
                    fechaInicioVigencia = Utilitario.CadenaFormatoFecha(filtro.FechaConsultaDesdeString, "dd/MM/yyyy");
                }
                else
                {
                    fechaInicioVigencia = null;
                }

                if (!string.IsNullOrWhiteSpace(filtro.FechaConsultaHastaString))
                {
                    fechaFinVigencia = Utilitario.CadenaFormatoFecha(filtro.FechaConsultaHastaString, "dd/MM/yyyy");
                }
                else
                {
                    fechaFinVigencia = null;
                }


                List<ContratoObservadoAprobadoLogic> listado = contratoLogicRepository.BuscarContratoObservadoAprobado(codigoUnidadOperativa,
                                                                                                                       codigoContrato,
                                                                                                                       filtro.TipoAccionContrato,
                                                                                                                       fechaInicioVigencia,
                                                                                                                       fechaFinVigencia,
                                                                                                                       nombreBaseDatoPolitica,
                                                                                                                       filtro.NumeroPagina,
                                                                                                                       filtro.RegistrosPagina);
                resultado.Result = new List<ReporteContratoObservadoAprobadoResponse>();

                foreach (var registro in listado)
                {
                    var contrato = ContratoAdapter.ObtenerContratoObservadoAprobadoPaginado(registro);

                    if (contrato.AccionPor != null && contrato.AccionPor != "")
                    {
                        var usuarioAccion = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = contrato.AccionPor }).Result.FirstOrDefault();
                        if (usuarioAccion != null)
                        {
                            contrato.AccionPor = usuarioAccion.NombreCompleto;
                        }
                        else
                        {
                            contrato.AccionPor = null;
                        }
                    }

                    if (contrato.UsuarioRespuesta != null && contrato.UsuarioRespuesta != "")
                    {
                        var usuarioRespuesta = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = contrato.UsuarioRespuesta }).Result.FirstOrDefault();
                        if (usuarioRespuesta != null)
                        {
                            contrato.UsuarioRespuesta = usuarioRespuesta.NombreCompleto;
                        }
                        else
                        {
                            contrato.UsuarioRespuesta = null;
                        }
                    }
                    resultado.Result.Add(contrato);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }


        /// <summary>
        /// Registra la Respuesta de la Solicitud de Modificación del Contrato para revisión
        /// </summary>
        /// <param name="objCtr">Objeto request de Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistraRespuestaContratoRevision(ContratoRequest objCtr)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                var contrato = contratoRepository.GetById(new Guid(objCtr.CodigoContrato));
                var entUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = contrato.CodigoUnidadOperativa.ToString() });
                List<ContratoDocumentoLogic> contratoDocumento = new List<ContratoDocumentoLogic>();

                var RepositorioSharePoint = politicaService.ListarRepositorioSharePointSGC(null, "3");
                string SiteURL = sharePointService.RetornaSiteUrlSharePoint();

                Microsoft.SharePoint.Client.SharePointOnlineCredentials crdSHP = sharePointService.RetornaCredencialesServer();
                var lstMontoMinimo = politicaService.ListarMontoMinimoControlDinamico().Result;
                var montoMinimoPrm = lstMontoMinimo.Where(a => a.Atributo4 == contrato.CodigoMoneda).FirstOrDefault().Atributo3;
                if (montoMinimoPrm == null)
                {
                    montoMinimoPrm = 0;
                }
                int resultProcesoAprobacion = -1;

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.SolicitudAutorizada) ||
                        objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.SolicitudDenegada) ||
                        objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.Editada))
                {
                    contrato.RespuestaModificacion = objCtr.RespuestaModificacion;
                }
                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionAprobada))
                {
                    contrato.CodigoEstado = DatosConstantes.EstadoContrato.Revision;
                }
                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.RevisionAprobada))
                {
                    contrato.CodigoEstado = DatosConstantes.EstadoContrato.Aprobacion;
                }
                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionRechazada) || objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.RevisionRechazada))
                {
                    contrato.RespuestaModificacion = objCtr.RespuestaModificacion;
                }

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionAprobada))
                {
                    contrato.CodigoEstadoEdicion = DatosConstantes.CodigoEstadoEdicion.RevisionRevisada;
                }
                else
                {
                    contrato.CodigoEstadoEdicion = objCtr.CodigoEstadoEdicion;
                }

                contratoRepository.Editar(contrato, entornoAplicacion);
                resultado.Result = contratoRepository.GuardarCambios();

                var listaRevisores = ObtenerListaRevisoresStracon(contrato).Result;
                var listaFirmantes = ObtenerListaFirmantesStracon(new ContratoResponse() { CodigoContrato = contrato.CodigoContrato, CodigoFlujoAprobacion = contrato.CodigoFlujoAprobacion, CodigoProveedor = contrato.CodigoProveedor }).Result;

                var urlLogo = politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.UrlLogoStracon).FirstOrDefault().Atributo3;
                var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.WidthLogo).FirstOrDefault().Atributo3);
                var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.HeightLogo).FirstOrDefault().Atributo3);

                //Obtener el usuario de creación del contrato para reemplazarlo como responsable en el flujo
                var usuarioEstadio = string.Empty;

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.RevisionAprobada))
                {
                    var trabajadorEdicion = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = contrato.UsuarioCreacion }).Result;

                    if (trabajadorEdicion != null)
                    {
                        var objTrabajador = trabajadorEdicion.FirstOrDefault();

                        if (objTrabajador != null)
                        {
                            usuarioEstadio = objTrabajador.CodigoTrabajador;
                        }
                    }
                }

                using (TransactionScope tsc = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (Convert.ToInt32(resultado.Result) == 1 && (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.Editada) || objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.RevisionRevisada)))
                    {
                        Guid newCodigoContratoDoc = Guid.NewGuid();
                        #region InformacionRepositorioSharePoint
                        string NombreFile = string.Format("{0}.{1}", newCodigoContratoDoc.ToString(), DatosConstantes.ArchivosContrato.ExtensionValidaCarga);
                        ProcessResult<string> miDirectorio = RetornaDirectorioFile(contrato.CodigoContrato, entUnidadOperativa.Result[0].Nombre, NombreFile, contrato.FechaInicioVigencia, false, RepositorioSharePoint.Result);
                        string lsDirectorioDestino = miDirectorio.Result.ToString();
                        string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });
                        string listName = nivelCarpeta[0];
                        string folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                        string hayError = string.Empty;
                        #endregion

                        #region GrabarContenidoContratoSHP
                        ////MLV
                        //MemoryStream msFile = new MemoryStream(GenerarPdfDesdeHtml(objCtr.ContenidoContrato, "", contrato.NumeroContrato, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));
                        var numeroCabecera = contrato.NumeroAdenda > 0 ? string.IsNullOrEmpty(contrato.NumeroAdendaConcatenado) ? contrato.NumeroContrato : contrato.NumeroAdendaConcatenado : contrato.NumeroContrato;
                        MemoryStream msFile = new MemoryStream(GenerarPdfDesdeHtml(objCtr.ContenidoContrato, "", numeroCabecera, null, contrato.CodigoPlantilla, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));

                        if (msFile != null)
                        {
                            var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, NombreFile, msFile, SiteURL, crdSHP);
                            if (Convert.ToInt32(regSHP.Result) > 0)
                            {
                                ContratoDocumentoLogic cdl = new ContratoDocumentoLogic();
                                cdl.CodigoContratoDocumento = newCodigoContratoDoc;
                                cdl.CodigoContrato = contrato.CodigoContrato;
                                cdl.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                                cdl.RutaArchivoSharePoint = lsDirectorioDestino;
                                cdl.Contenido = objCtr.ContenidoContrato;
                                //El procedimiento se encarga de registrar el nuevo CD, inactivando los anteriores.
                                int regCD = contratoLogicRepository.RegistraContratoDocumentoCargaArchivo(cdl, entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal);
                                if (regCD != 1)
                                {
                                    /*Borramos el documento subido al SHP.*/
                                    var fileShpDelete = sharePointService.EliminaArchivoSharePoint(new List<int>() { cdl.CodigoArchivo }, listName, ref hayError);
                                    resultado.Result = "";
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<ContratoService>("Problemas al registrar el Contrato Documento Entity: Contrato-Service : RegistraRespuestaContrato");
                                    return resultado;
                                }
                            }
                        }
                        else
                        {
                            resultado.Result = hayError;
                            resultado.IsSuccess = false;
                            resultado.Exception = new ApplicationLayerException<ContratoService>("Problemas al registrar nueva Version de Documento en SharePoint");
                            return resultado;
                        }
                        #endregion
                    }
                    if (Convert.ToInt32(resultado.Result) == 1 && objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.RevisionAprobada))
                    {
                        contratoDocumento = contratoLogicRepository.DocumentosPorContrato(contrato.CodigoContrato);
                        if (contratoDocumento != null && contratoDocumento.Count > 0)
                        {
                            resultProcesoAprobacion = contratoLogicRepository.ApruebaContratoEstadio((Guid)contratoDocumento[0].CodigoContratoEstadio,
                                                                            entUnidadOperativa.Result[0].CodigoIdentificacion,
                                                                            entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal, usuarioEstadio, "");
                            if (resultProcesoAprobacion != 1)
                            {
                                resultado.Result = "Problemas al registrar la aprobación del contrato.";
                                resultado.IsSuccess = false;
                                resultado.Exception = new ApplicationLayerException<ContratoService>("Problemas al registrar la aprobación del contrato");
                                tsc.Dispose();
                            }
                        }
                        else
                        {
                            resultado.Result = "No se generó correctamente el Codigo del contrato Estadío. Contrato Service - RegistraRespuestaContrato.";
                            resultado.IsSuccess = false;
                            resultado.Exception = new ApplicationLayerException<ContratoService>("No se generó correctamente el Codigo del contrato Estadío. Contrato Service - RegistraRespuestaContrato.");
                            tsc.Dispose();
                        }
                    }
                    tsc.Complete();
                }

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionRechazada) || objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.RevisionRechazada))
                {
                    var contratoEstadioEdicion = contratoLogicRepository.ObtenerContratoEstadioEdicion(contrato.CodigoContrato, contrato.CodigoFlujoAprobacion);
                    generaNotificacionCorreo(DatosConstantes.TipoNotificacion.ContratoRechazadoPorLegal, contratoEstadioEdicion, null, null, null, null, contrato.UsuarioCreacion);
                }

                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.RevisionAprobada))
                {
                    ContratoEstadioEntity entidadContratoEstadio = contratoEstadioRepository.GetById(contratoDocumento[0].CodigoContratoEstadio);
                    FlujoAprobacionEstadioEntity entidadFlujoAprobacionEstadio = flujoAprobacionEstadioRepository.GetById(entidadContratoEstadio.CodigoFlujoAprobacionEstadio);

                    var codigoResponsable = flujoAprobacionLogicRepository.ObtenerResponsableSiguienteEstadioFlujoAprobacion((Guid)contrato.CodigoFlujoAprobacion, entidadFlujoAprobacionEstadio.Orden, entidadFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio, entidadContratoEstadio.CodigoContratoEstadio);
                    generaNotificacionCorreo(DatosConstantes.TipoNotificacion.NuevoContratoBandeja, entidadContratoEstadio.CodigoContratoEstadio, null, null, null, null, null, codigoResponsable);
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Registra la Respuesta de la Soliitud de Modificacion del Contrato
        /// </summary>
        /// <param name="objCtr">Objeto request de Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistrarRespuestaGrabarContrato(ContratoRequest objCtr)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                var contrato = contratoRepository.GetById(new Guid(objCtr.CodigoContrato));
                var entUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = contrato.CodigoUnidadOperativa.ToString() });
                var RepositorioSharePoint = politicaService.ListarRepositorioSharePointSGC(null, "3");
                string SiteURL = sharePointService.RetornaSiteUrlSharePoint();

                Microsoft.SharePoint.Client.SharePointOnlineCredentials crdSHP = sharePointService.RetornaCredencialesServer();
                var lstMontoMinimo = politicaService.ListarMontoMinimoControlDinamico().Result;
                var montoMinimoPrm = lstMontoMinimo.Where(a => a.Atributo4 == contrato.CodigoMoneda).FirstOrDefault().Atributo3;
                if (montoMinimoPrm == null)
                {
                    montoMinimoPrm = 0;
                }

                contratoRepository.Editar(contrato, entornoAplicacion);
                resultado.Result = contratoRepository.GuardarCambios();
                //17-04-2017 FIN 
                var listaRevisores = ObtenerListaRevisoresStracon(contrato).Result;
                var listaFirmantes = ObtenerListaFirmantesStracon(new ContratoResponse() { CodigoContrato = contrato.CodigoContrato, CodigoFlujoAprobacion = contrato.CodigoFlujoAprobacion, CodigoProveedor = contrato.CodigoProveedor }).Result;

                var urlLogo = politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.UrlLogoStracon).FirstOrDefault().Atributo3;
                var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.WidthLogo).FirstOrDefault().Atributo3);
                var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.HeightLogo).FirstOrDefault().Atributo3);

                using (TransactionScope tsc = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (Convert.ToInt32(resultado.Result) == 1 && objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.Editada))
                    {
                        Guid newCodigoContratoDoc = Guid.NewGuid();
                        #region InformacionRepositorioSharePoint
                        string NombreFile = string.Format("{0}.{1}", newCodigoContratoDoc.ToString(), DatosConstantes.ArchivosContrato.ExtensionValidaCarga);
                        ProcessResult<string> miDirectorio = RetornaDirectorioFile(contrato.CodigoContrato, entUnidadOperativa.Result[0].Nombre, NombreFile, contrato.FechaInicioVigencia, false, RepositorioSharePoint.Result);
                        string lsDirectorioDestino = miDirectorio.Result.ToString();
                        string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });
                        string listName = nivelCarpeta[0];
                        string folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                        string hayError = string.Empty;
                        #endregion

                        #region GrabarContenidoContratoSHP
                        //MLV
                        //MemoryStream msFile = new MemoryStream(GenerarPdfDesdeHtml(objCtr.ContenidoContrato, "", contrato.NumeroContrato, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));
                        var numeroCabecera = contrato.NumeroAdenda > 0 ? string.IsNullOrEmpty(contrato.NumeroAdendaConcatenado) ? contrato.NumeroContrato : contrato.NumeroAdendaConcatenado : contrato.NumeroContrato;
                        MemoryStream msFile = new MemoryStream(GenerarPdfDesdeHtml(objCtr.ContenidoContrato, "", numeroCabecera, contrato.CodigoContrato, contrato.CodigoPlantilla, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));

                        if (msFile != null)
                        {
                            var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, NombreFile, msFile, SiteURL, crdSHP);
                            if (Convert.ToInt32(regSHP.Result) > 0)
                            {
                                ContratoDocumentoLogic cdl = new ContratoDocumentoLogic();
                                cdl.CodigoContratoDocumento = newCodigoContratoDoc;
                                cdl.CodigoContrato = contrato.CodigoContrato;
                                cdl.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                                cdl.RutaArchivoSharePoint = lsDirectorioDestino;
                                cdl.Contenido = objCtr.ContenidoContrato;
                                //El procedimiento se encarga de registrar el nuevo CD, inactivando los anteriores.
                                int regCD = contratoLogicRepository.RegistraContratoDocumentoCargaArchivo(cdl, entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal);
                                if (regCD != 1)
                                {
                                    /*Borramos el documento subido al SHP.*/
                                    var fileShpDelete = sharePointService.EliminaArchivoSharePoint(new List<int>() { cdl.CodigoArchivo }, listName, ref hayError);
                                    resultado.Result = "";
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<ContratoService>("Problemas al registrar el Contrato Documento Entity: Contrato-Service : RegistraRespuestaContrato");
                                    return resultado;
                                }
                            }
                        }
                        else
                        {
                            resultado.Result = hayError;
                            resultado.IsSuccess = false;
                            resultado.Exception = new ApplicationLayerException<ContratoService>("Problemas al registrar nueva Version de Documento en SharePoint");
                            return resultado;
                        }
                        #endregion
                    }
                    tsc.Complete();
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return resultado;
        }


        /// <summary>
        /// Método para retornar los documentos PDf por Contrato
        /// </summary>
        /// <param name="CodigoContrato">Código de Contrato</param>
        /// <returns>Documentos PDF</returns>
        public ProcessResult<List<ContratoDocumentoResponse>> DocumentosPorContrato(Guid CodigoContrato)
        {
            ProcessResult<List<ContratoDocumentoResponse>> rpta = new ProcessResult<List<ContratoDocumentoResponse>>();
            try
            {
                ContratoDocumentoResponse cdrEntidad;
                var result = contratoLogicRepository.DocumentosPorContrato(CodigoContrato);
                rpta.Result = new List<ContratoDocumentoResponse>();
                foreach (ContratoDocumentoLogic item in result)
                {
                    cdrEntidad = ContratoAdapter.ObtenerContratoDocumentoResponseDeLogic(item);
                    rpta.Result.Add(cdrEntidad);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Método para retornar los documentos adjuntos por Contrato
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        public ProcessResult<List<ContratoDocumentoAdjuntoResponse>> BuscarContratoDocumentoAdjunto(ContratoDocumentoAdjuntoRequest request)
        {
            ProcessResult<List<ContratoDocumentoAdjuntoResponse>> resultado = new ProcessResult<List<ContratoDocumentoAdjuntoResponse>>();
            try
            {
                var result = contratoDocumentoAdjuntoLogicRepository.BuscarContratoDocumentoAdjunto(
                    request.CodigoContratoDocumentoAdjunto,
                    request.CodigoContrato,
                    request.CodigoArchivo,
                    request.NombreArchivo,
                    DatosConstantes.EstadoRegistro.Activo
                    );
                resultado.Result = new List<ContratoDocumentoAdjuntoResponse>();

                foreach (var item in result)
                {
                    resultado.Result.Add(ContratoAdapter.ObtenerContratoDocumentoAdjuntoResponseDeLogic(item));
                }
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProcessResult<List<ContratoDocumentoAdjuntoResolucionResponse>> BuscarContratoDocumentoAdjuntoResolucion(ContratoDocumentoAdjuntoResolucionRequest request)
        {
            ProcessResult<List<ContratoDocumentoAdjuntoResolucionResponse>> resultado = new ProcessResult<List<ContratoDocumentoAdjuntoResolucionResponse>>();
            try
            {
                var result = contratoDocumentoAdjuntoResolucionLogicRepository.BuscarContratoDocumentoAdjuntoResolucion(
                    request.CodigoContratoDocumentoAdjuntoResolucion,
                    request.CodigoContrato,
                    request.CodigoArchivo,
                    request.NombreArchivo,
                    DatosConstantes.EstadoRegistro.Activo
                    );
                resultado.Result = new List<ContratoDocumentoAdjuntoResolucionResponse>();

                foreach (var item in result)
                {
                    var trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = item.UsuarioCreacion }).Result.FirstOrDefault();

                    resultado.Result.Add(ContratoAdapter.ObtenerContratoDocumentoAdjuntoResolucionResponseDeLogic(item, trabajador.NombreCompleto));
                }
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Método para registra los documentos adjuntos por Contrato
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        public ProcessResult<string> RegistrarContratoDocumentoAdjunto(ContratoDocumentoAdjuntoRequest request)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                var contratoEntity = contratoRepository.GetById(request.CodigoContrato.Value);

                if (!(contratoEntity.CodigoEstado == DatosConstantes.EstadoContrato.Edicion || contratoEntity.CodigoEstado == DatosConstantes.EstadoContrato.Aprobacion
                    || contratoEntity.CodigoEstado == DatosConstantes.EstadoContrato.Vencido || contratoEntity.CodigoEstado == DatosConstantes.EstadoContrato.Vigente))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<ContratoService>("El contrato no se encuentra en Estado de Edición, Aprobación, Vencido o Vigente");
                    return resultado;
                }

                //Registro de información
                string hayError = string.Empty;
                var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = request.CodigoUnidadOperativa.ToString() });

                request.CodigoContratoDocumentoAdjunto = Guid.NewGuid();
                #region InformacionRepositorioSharePoint
                string nombreArchivo = string.Format("{0}.{1}", request.CodigoContratoDocumentoAdjunto.ToString(), request.ExtencionArchivo);
                ProcessResult<string> miDirectorio = RetornaDirectorioFile(request.CodigoContrato.Value, unidadOperativa.Result[0].Nombre, nombreArchivo, null, true);
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
                contratoDocumentoAdjuntoEntityRepository.Insertar(ContratoAdapter.ObtenerContratoDocumentoAdjuntoEntityDeRequest(request));
                contratoDocumentoAdjuntoEntityRepository.GuardarCambios();
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
        /// Se registra el documento adjunto de resolución, de momento sólo guarda un archivo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProcessResult<string> RegistrarContratoDocumentoAdjuntoResolucion(ContratoDocumentoAdjuntoResolucionRequest request)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                var contratoEntity = contratoRepository.GetById(request.CodigoContrato.Value);

                if (!(contratoEntity.CodigoEstado == DatosConstantes.EstadoContrato.Vigente))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<ContratoService>("El contrato no se encuentra en Estado de Vigente");
                    return resultado;
                }

                if (!(request.ValidacionResolucion == DatosConstantes.TipoValidacionContratoResolucion.Cumple_Carga))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<ContratoService>("Este contrato ya fue anteriormente actualizado.");
                    return resultado;
                }

                String[] resolucion = request.FechaResolucionString.Split('/');
                String[] fecha_fin = request.FechaFinVigenciaString.Split('/');

                request.FechaResolucion = new DateTime(Convert.ToInt32(resolucion[2]), Convert.ToInt32(resolucion[1]), Convert.ToInt32(resolucion[0]));
                DateTime fechafin = new DateTime(Convert.ToInt32(fecha_fin[2]), Convert.ToInt32(fecha_fin[1]), Convert.ToInt32(fecha_fin[0]));

                if (request.FechaResolucion > fechafin)
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<ContratoService>("La fecha de resolución no puede ser mayor a la fecha de fin de vigencia.");
                    return resultado;
                }

                //Registro de información
                string hayError = string.Empty;
                var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = request.CodigoUnidadOperativa.ToString() });

                request.CodigoContratoDocumentoAdjuntoResolucion = Guid.NewGuid();
                #region InformacionRepositorioSharePoint
                string nombreArchivo = string.Format("{0}.{1}", request.CodigoContratoDocumentoAdjuntoResolucion.ToString(), request.ExtencionArchivo);
                ProcessResult<string> miDirectorio = RetornaDirectorioFile(request.CodigoContrato.Value, unidadOperativa.Result[0].Nombre, nombreArchivo, null, true);
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
                try
                {
                    var result = contratoDocumentoAdjuntoResolucionLogicRepository.Insertar_Documento_Adjunto_Resolucion(
                        request.CodigoContrato,
                        request.CodigoArchivo,
                        request.NombreArchivo,
                        request.RutaArchivoSharePoint,
                        entornoAplicacion.UsuarioSession,
                        entornoAplicacion.Terminal,
                        request.FechaResolucion
                        );
                }
                catch (Exception ex)
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
                    LogBL.grabarLogError(new Exception("Ocurrió un problema al insertar en la tabla Documento Adjunto Resolución"));
                }
                return resultado;

                #endregion
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>("AAAA", ex);
                LogBL.grabarLogError(new Exception("Ocurrió un problema al validar los parametros de lógica"));
            }
            return resultado;
        }

        /// <summary>
        /// Método que elimina los documentos adjuntos al Contrato
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        public ProcessResult<string> EliminarContratoDocumentoAdjunto(ContratoDocumentoAdjuntoRequest request)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                var contratoDocumentoAdjuntoEntity = contratoDocumentoAdjuntoEntityRepository.GetById(request.CodigoContratoDocumentoAdjunto.Value);

                var contratoEntity = contratoRepository.GetById(contratoDocumentoAdjuntoEntity.CodigoContrato);

                if (!(contratoEntity.CodigoEstado == DatosConstantes.EstadoContrato.Edicion || contratoEntity.CodigoEstado == DatosConstantes.EstadoContrato.Aprobacion))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<ContratoService>("El contrato se encuentra en Estado de Edición o en Aprobación");
                    return resultado;
                }

                if (!(contratoDocumentoAdjuntoEntity.UsuarioCreacion == entornoAplicacion.UsuarioSession))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<ContratoService>("El documento adjunto solo puede ser eliminado por el propietario del mismo");
                    return resultado;
                }

                #region Grabar registro del documento adjunto
                contratoDocumentoAdjuntoEntityRepository.Eliminar(request.CodigoContratoDocumentoAdjunto);
                contratoDocumentoAdjuntoEntityRepository.GuardarCambios();
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
        /// Elimina el adjunto de la resolución del contrato S09-SGC-01
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProcessResult<string> EliminarContratoDocumentoAdjuntoResolucion(ContratoDocumentoAdjuntoResolucionRequest request)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                var contratoDocumentoAdjuntoResolucionEntity = contratoDocumentoAdjuntoResolucionEntityRepository.GetById(request.CodigoContratoDocumentoAdjuntoResolucion.Value);

                var contratoEntity = contratoRepository.GetById(contratoDocumentoAdjuntoResolucionEntity.CodigoContrato);

                if (!(contratoEntity.CodigoEstado == DatosConstantes.EstadoContrato.Edicion || contratoEntity.CodigoEstado == DatosConstantes.EstadoContrato.Aprobacion))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<ContratoService>("El contrato se encuentra en Estado de Edición o en Aprobación");
                    return resultado;
                }

                if (!(contratoDocumentoAdjuntoResolucionEntity.UsuarioCreacion == entornoAplicacion.UsuarioSession))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<ContratoService>("El documento adjunto solo puede ser eliminado por el propietario del mismo");
                    return resultado;
                }

                #region Grabar registro del documento adjunto
                contratoDocumentoAdjuntoResolucionEntityRepository.Eliminar(request.CodigoContratoDocumentoAdjuntoResolucion);
                contratoDocumentoAdjuntoResolucionEntityRepository.GuardarCambios();
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
        public ProcessResult<string> RetornaDirectorioFile(Guid codigoContrato, string nombreUnidadOperativa,
                                                           string nombreFile, DateTime? fechaInicioVigencia = null,
                                                            bool esAdjunto = false, List<CodigoValorResponse> lstPrmRepositorioShp = null)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            string lsValue = string.Empty, directorioSHP = string.Empty; ;
            try
            {
                int Anio = 0, Mes = 0;
                string NombreMes = string.Empty;
                if (fechaInicioVigencia == null)
                {
                    var entContrato = contratoRepository.GetById(codigoContrato);
                    Anio = entContrato.FechaInicioVigencia.Year;
                    Mes = entContrato.FechaInicioVigencia.Month;
                }
                else
                {
                    Anio = fechaInicioVigencia.Value.Year;
                    Mes = fechaInicioVigencia.Value.Month;
                }

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
                        lsValue = lsValue.Replace("[NOMBRE_UNIDAD_OPERATIVA]", nombreUnidadOperativa) + "/";
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
        /// Metodo para cargar un Archivo a un estadio de contrato.
        /// </summary>
        /// <param name="objRsp">Objeto Contrato Documento Response</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistraContratoDocumentoCargaArchivo(ContratoDocumentoResponse objRsp)
        {
            ProcessResult<Object> objRpta = new ProcessResult<Object>();
            try
            {
                ContratoDocumentoLogic objLogic = ContratoAdapter.ObtenerContratoDocumentoLogicDeResponse(objRsp);
                objRpta.Result = contratoLogicRepository.RegistraContratoDocumentoCargaArchivo(objLogic, entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal);
            }
            catch (Exception ex)
            {
                objRpta.Result = -1;
                objRpta.IsSuccess = false;
                objRpta.Exception = new ApplicationLayerException<ContratoService>(ex.Message);
            }
            return objRpta;
        }

        /// <summary>
        /// Metodo que retorna los bytes para la generación del archivo PDF.
        /// </summary>
        /// <param name="request">Código del Contrato</param>
        /// <returns>Bytes para generar pdf</returns>
        public ProcessResult<ContratoDocumentoAdjuntoResponse> ObtenerArchivoAdjunto(ContratoDocumentoAdjuntoRequest request)
        {
            ProcessResult<ContratoDocumentoAdjuntoResponse> resultado = new ProcessResult<ContratoDocumentoAdjuntoResponse>();
            try
            {
                var contratoDocumentoAdjuntoResponse = new ContratoDocumentoAdjuntoResponse();


                var documentoAdjunto = contratoDocumentoAdjuntoEntityRepository.GetById(request.CodigoContratoDocumentoAdjunto);

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
                    contratoDocumentoAdjuntoResponse.NombreArchivo = documentoAdjunto.NombreArchivo;
                    contratoDocumentoAdjuntoResponse.ContenidoArchivo = contenidoArchivo.Result;

                    resultado.Result = contratoDocumentoAdjuntoResponse;
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                //resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene el archivo adjunto de resolución de contrato S09-SGC-01
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProcessResult<ContratoDocumentoAdjuntoResolucionResponse> ObtenerArchivoAdjuntoResolucion(ContratoDocumentoAdjuntoResolucionRequest request)
        {
            ProcessResult<ContratoDocumentoAdjuntoResolucionResponse> resultado = new ProcessResult<ContratoDocumentoAdjuntoResolucionResponse>();
            try
            {
                var contratoDocumentoAdjuntoResponse = new ContratoDocumentoAdjuntoResolucionResponse();

                //var documentoAdjunto = contratoDocumentoAdjuntoResolucionEntityRepository.GetById(request.CodigoContratoDocumentoAdjuntoResolucion);

                //Obtener documento del SharePoint, consultamos la ruta.                    
                string mensajeError = string.Empty;
                ProcessResult<Object> contenidoArchivo = new ProcessResult<Object>();
                string listName = "";
                string[] rutaArchivo = request.RutaArchivoSharePoint.Split(new char[] { '/' });
                var codigoArchivo = Convert.ToInt32(request.CodigoArchivo);
                listName = rutaArchivo[0];
                contenidoArchivo = sharePointService.DescargaArchivoPorId(ref mensajeError, codigoArchivo, listName);
                if (!String.IsNullOrEmpty(mensajeError))
                {
                    //resultado.Result = mensajeError;
                    resultado.IsSuccess = false;
                }
                else
                {
                    contratoDocumentoAdjuntoResponse.NombreArchivo = request.NombreArchivo;
                    contratoDocumentoAdjuntoResponse.ContenidoArchivo = contenidoArchivo.Result;

                    resultado.Result = contratoDocumentoAdjuntoResponse;
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                //resultado.Result = ex.Message;
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
        /// <param name="nombreArchivoContrato">Nombre del archivo a descargar</param>
        /// <param name="linkFileCss"></param>
        /// <returns>Bytes para generar pdf</returns>
        public ProcessResult<Object> GenerarContenidoContrato(Guid codigoContrato, Guid? codigoContratoEstadio, ref string nombreArchivoContrato, string linkFileCss = null)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                /*Verificamos si el documento es la versión Oficial*/
                ContratoEntity objContrato = contratoRepository.GetById(codigoContrato);

                PlantillaEntity plantillaEntity = plantillaEntityRepository.GetById(objContrato.CodigoPlantilla);

                string extencionDocumento = DatosConstantes.ArchivosContrato.ExtensionValidaCarga;
                long CodigoArchivo = 0;
                string MsgError = string.Empty;
                var listaDocumentoFinal = contratoLogicRepository.DocumentosPorContrato(codigoContrato).ToList();

                //Para obtener el docuemento de tipo adhesion se ordena por la version
                var documentoFinal = plantillaEntity.IndicadorAdhesion ? listaDocumentoFinal.OrderBy(item => item.Version).LastOrDefault() : listaDocumentoFinal.FirstOrDefault();

                if (objContrato.IndicadorVersionOficial || plantillaEntity.IndicadorAdhesion)
                {
                    //Obtener documento del SharePoint, consultamos la ruta.

                    ProcessResult<Object> contenidoArchivo = new ProcessResult<Object>();
                    string listName = "";

                    string[] rutaArchivo = documentoFinal.RutaArchivoSharePoint.Split(new char[] { '/' });
                    CodigoArchivo = documentoFinal.CodigoArchivo;

                    listName = rutaArchivo[0];
                    //Obtiene la extención del documento si es de tipo adhesion
                    extencionDocumento = plantillaEntity.IndicadorAdhesion ? rutaArchivo.LastOrDefault().Split('.').LastOrDefault() : extencionDocumento;
                    contenidoArchivo = sharePointService.DescargaArchivoPorId(ref MsgError, CodigoArchivo, listName);

                    if (!String.IsNullOrEmpty(MsgError))
                    {
                        resultado.Result = GenerarContratoLocal(codigoContrato, objContrato, documentoFinal.Contenido, linkFileCss);
                    }
                    else
                    {
                        resultado.Result = contenidoArchivo.Result;
                    }
                }
                else
                {

                    resultado.Result = GenerarContratoLocal(codigoContrato, objContrato, documentoFinal.Contenido, linkFileCss);
                    //MLV SUBIR NUEVAMENTE DOCUMENTO AL SHAREPOINT*/
                    ////var objDocumento = contratoDocumentoEntityRepository.GetById(documentoFinal.CodigoContratoDocumento);
                    ////objDocumento.Contenido = contenido;
                    ////contratoDocumentoEntityRepository.Editar(objDocumento);
                    ////contratoDocumentoEntityRepository.GuardarCambios();
                    //var msFile = new MemoryStream(GenerarPdfDesdeHtml(contenido, "", numeroCabecera, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));
                    //string siteURLShp = sharePointService.RetornaSiteUrlSharePoint();
                    //NetworkCredential crdSHP = sharePointService.RetornaCredencialesServer();
                    //string[] nivelCarpeta = "03.03.24 SGC 2017/02 Febrero/1726 ZANJA/f6ad2365-0dc7-4f4c-8258-2baa7e9b0429.pdf".Split(new char[] { '/' });
                    //string listName = nivelCarpeta[0];
                    //string folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                    //string hayError = string.Empty;
                    //string NombreFile = string.Format("{0}.{1}", "F6AD2365-0DC7-4F4C-8258-2BAA7E9B0429", DatosConstantes.ArchivosContrato.ExtensionValidaCarga);
                    //var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, NombreFile, msFile, siteURLShp, crdSHP);
                }

                if (objContrato.NumeroContrato != null)
                {
                    nombreArchivoContrato = string.Format("{0}.{1}", objContrato.NumeroContrato, extencionDocumento);
                }
                else
                {
                    nombreArchivoContrato = string.Format("{0}.{1}", documentoFinal.CodigoContrato, extencionDocumento);
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Devuelve bit para el filestream
        /// </summary>
        /// <param name="codigoContrato"></param>
        /// <param name="objContrato"></param>
        /// <param name="contenido_"></param>
        /// <param name="linkFileCss"></param>
        /// <returns></returns>
        public byte[] GenerarContratoLocal(Guid codigoContrato, ContratoEntity objContrato, string contenido_, string linkFileCss)
        {
            List<ContratoEstadioLogic> contratoEstadio = contratoLogicRepository.ListarContratoEstadio(null, codigoContrato);
            var contrato = contratoEntityRepository.GetById(codigoContrato);
            List<ContratoEstadioLogic> contratoEstadioAux = new List<ContratoEstadioLogic>();
            DateTime fechaFinalizacion;
            string fechaFinal = string.Empty, piePagina = string.Empty;
            List<Guid?> lstTrabajador = new List<Guid?>();
            contratoEstadioAux = contratoEstadio.FindAll(x => x.CodigoEstadoContratoEstadio.Equals(DatosConstantes.CodigoEstadoContratoEstadio.Aprobado)).OrderByDescending(x => x.FechaFinalizacion).ToList();

            if (contratoEstadioAux != null && contratoEstadioAux.Count > 0)
            {
                fechaFinalizacion = (DateTime)contratoEstadioAux[0].FechaFinalizacion;
                lstTrabajador.Add(contratoEstadioAux[0].CodigoResponsable);
                fechaFinal = fechaFinalizacion.ToString(DatosConstantes.Formato.FormatoFecha);
            }

            piePagina = DatosConstantes.ContenidoPiePaginaContrato.EtiquetaCopiaNoOficial;


            var datosTrabajador = trabajadorService.ListarTrabajadores(lstTrabajador);

            #region correción de HTML sino cierra todas las etiquetas(p)


            string htmllocal = contenido_;

            HtmlNode.ElementsFlags["p"] = HtmlElementFlag.Closed;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmllocal);

            var nuevoContenido = doc.DocumentNode.OuterHtml;

            #endregion

            string contenido = nuevoContenido;

            var listaRevisores = ObtenerListaRevisoresStracon(objContrato).Result;

            var listaFirmantes = ObtenerListaFirmantesStracon(new ContratoResponse() { CodigoContrato = objContrato.CodigoContrato, CodigoFlujoAprobacion = objContrato.CodigoFlujoAprobacion, CodigoProveedor = objContrato.CodigoProveedor }).Result;

            #region Cambio para Logo por Unidad Operativa
            var urlLogo = "";
            var entUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = contrato.CodigoUnidadOperativa.ToString() });

            if (entUnidadOperativa.Result[0].LogoUnidadOperativa == null)
            {

                urlLogo = politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.UrlLogoStracon).FirstOrDefault().Atributo3;
            }
            else
            {
                urlLogo = entUnidadOperativa.Result[0].LogoUnidadOperativa;
            }


            #endregion

            //var urlLogo = politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.UrlLogoStracon).FirstOrDefault().Atributo3;
            var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.WidthLogo).FirstOrDefault().Atributo3);
            var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.HeightLogo).FirstOrDefault().Atributo3);

            var numeroCabecera = objContrato.NumeroAdenda > 0 ? string.IsNullOrEmpty(objContrato.NumeroAdendaConcatenado) ? objContrato.NumeroContrato : objContrato.NumeroAdendaConcatenado : objContrato.NumeroContrato;
            return GenerarPdfDesdeHtml(contenido, piePagina, numeroCabecera, codigoContrato, contrato.CodigoPlantilla, listaFirmantes, listaRevisores, linkFileCss, false, urlLogo, widthLogo, heightLogo);

            //var urlLogo = politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.UrlLogoStracon).FirstOrDefault().Atributo3;
            //var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.WidthLogo).FirstOrDefault().Atributo3);
            //var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionContrato().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionContrato.HeightLogo).FirstOrDefault().Atributo3);

            //var numeroCabecera = objContrato.NumeroAdenda > 0 ? string.IsNullOrEmpty(objContrato.NumeroAdendaConcatenado) ? objContrato.NumeroContrato : objContrato.NumeroAdendaConcatenado : objContrato.NumeroContrato;
            //return GenerarPdfDesdeHtml(contenido, piePagina, numeroCabecera, codigoContrato, contrato.CodigoPlantilla, listaFirmantes, listaRevisores, linkFileCss, false, urlLogo, widthLogo, heightLogo);



        }

        /// <summary>
        /// Metodo que retorna los bytes del contrato reemplazado en la observación.
        /// </summary>
        /// <param name="codigoContratoEstadioObservacion">Código de la observación del estadio Contrato</param>
        /// <param name="nombreArchivoContrato">Nombre del archivo a descargar</param>
        /// <returns>Documento de contrato que reemplazo la Observación</returns>
        public ProcessResult<Object> ObtenerContratoAnteriorObservacion(Guid codigoContratoEstadioObservacion, ref string nombreArchivoContrato)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                var observacion = ObtieneContratoEstadioObservacionPorID(codigoContratoEstadioObservacion);

                long codigoArchivo = observacion.CodigoArchivo.Value;
                string[] rutaArchivo = observacion.RutaArchivoSharepoint.Split(new char[] { '/' });
                string extencionDocumento = rutaArchivo.LastOrDefault().Split('.').LastOrDefault();

                string MsgError = string.Empty;

                //Obtener documento del SharePoint, consultamos la ruta.
                ProcessResult<Object> contenidoArchivo = new ProcessResult<Object>();
                string listName = "";

                listName = rutaArchivo[0];

                contenidoArchivo = sharePointService.DescargaArchivoPorId(ref MsgError, codigoArchivo, listName);
                if (!String.IsNullOrEmpty(MsgError))
                {
                    resultado.Result = MsgError;
                    resultado.IsSuccess = false;
                }
                else
                {
                    resultado.Result = contenidoArchivo.Result;
                }

                nombreArchivoContrato = string.Format("{0}.{1}", observacion.CodigoContratoEstadioObservacion, extencionDocumento);

            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return resultado;
        }
        /// <summary>
        /// Metodo que retorna los bytes del contrato reemplzanate en la observación.
        /// </summary>
        /// <param name="codigoContratoEstadioObservacion">Código de la observación del estadio Contrato</param>
        /// <param name="nombreArchivoContrato">Nombre del archivo a descargar</param>
        /// <returns>Documento de contrato que reemplazo la Observación</returns>
        public ProcessResult<Object> ObtenerContratoReemplazanteObservacion(Guid codigoContratoEstadioObservacion, ref string nombreArchivoContrato)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                var observacion = ObtieneContratoEstadioObservacionPorID(codigoContratoEstadioObservacion);
                var contratoEstadio = contratoEstadioRepository.GetById(observacion.CodigoContratoEstadio);

                return GenerarContenidoContrato(contratoEstadio.CodigoContrato, null, ref nombreArchivoContrato);

            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return resultado;
        }
        /// <summary>
        /// Retorna información del contrato.
        /// </summary>
        /// <param name="codigoContrato">código de contrato</param>
        /// <returns>Información del contrato</returns>
        public ProcessResult<ContratoResponse> RetornaContratoPorId(Guid codigoContrato)
        {
            ProcessResult<ContratoResponse> rpta = new ProcessResult<ContratoResponse>();
            try
            {
                ContratoEntity entContrato = contratoRepository.GetById(codigoContrato);

                ProveedorEntity proveedorEntity = proveedorEntityRepository.GetById(entContrato.CodigoProveedor);

                rpta.Result = new ContratoResponse();
                rpta.Result = ContratoAdapter.ObtenerContratoResponseDeEntity(entContrato, proveedorEntity);
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }

        //private void NotificacionContrato(object objSend)
        //{
        //    ParametrosNotificacion oparamNot = (ParametrosNotificacion)objSend;
        //    int ejecutaEnvio = contratoLogicRepository.NotificaBandejaContratos(oparamNot.asunto,
        //                                                                            oparamNot.textoNotificar, oparamNot.cuentaNotificar,
        //                                                                            oparamNot.cuentaCopiar, oparamNot.profileCorreo);
        //}

        /// <summary>
        /// Genera Notificación de correo
        /// </summary>
        /// <param name="TipoNotificacion">Tipo de Notificación</param>
        /// <param name="codigoContratoEstadio">Código de contrato por Estadio</param>
        /// <param name="lstTrab">Lista de Trabajadores</param>
        /// <param name="listaUni">Lista de Unidad</param>
        /// <param name="lstProfile">Lista Profile</param>
        /// <param name="lstUrl">Lista Url</param>
        /// <param name="usuarioCreacion">Usuario de creación de contrato</param>
        /// <param name="codigoResponsable"></param>
        /// <param name="codigos_con_copia"></param>
        /// <returns>Notificación de correo</returns>
        private int generaNotificacionCorreo(string TipoNotificacion, Guid codigoContratoEstadio,
                                             List<TrabajadorResponse> lstTrab = null, List<UnidadOperativaResponse> listaUni = null,
                                             List<CodigoValorResponse> lstProfile = null, List<CodigoValorResponse> lstUrl = null, string usuarioCreacion = null, Guid? codigoResponsable = null, string codigos_con_copia = null)
        {
            ParametrosNotificacion datos = new ParametrosNotificacion();
            datos.TipoNotificacion = TipoNotificacion;
            datos.variables = new Dictionary<string, string>();
            List<Guid?> filtroTrb = new List<Guid?>();
            List<TrabajadorResponse> listaResponsables = new List<TrabajadorResponse>();
            List<UnidadOperativaResponse> listaUnidades = new List<UnidadOperativaResponse>();
            List<CodigoValorResponse> listaProfileCorreo = new List<CodigoValorResponse>();
            List<CodigoValorResponse> listaUrlSistema = new List<CodigoValorResponse>();
            List<Guid?> observacion_copia = new List<Guid?>();
            List<TrabajadorResponse> lista_observacion_copia = new List<TrabajadorResponse>();
            List<String> lista_texto_copia = new List<String>();
            string lista_concatenada_correos = string.Empty;

            var datosCorreo = contratoLogicRepository.InformacionNotificacionContratoEstadio(codigoContratoEstadio, TipoNotificacion);

            string[] informados;
            if (lstProfile != null)
            {
                listaProfileCorreo = lstProfile;
            }
            else
            {
                listaProfileCorreo = politicaService.ListaCuentaNotificacionSGC(null, "3").Result;
            }
            if (lstUrl != null)
            {
                listaUrlSistema = lstUrl;
            }
            else
            {
                listaUrlSistema = politicaService.ListaUrlSistemas(null, "3").Result;
            }

            #region InformacionParaCorreo
            if (datosCorreo != null && datosCorreo.Count > 0)
            {
                if (codigoResponsable != null)
                {
                    datosCorreo[0].CodigoResponsable = codigoResponsable;
                }

                filtroTrb.Add(datosCorreo[0].CodigoResponsable);
                if (!string.IsNullOrEmpty(datosCorreo[0].Informados))
                {
                    informados = datosCorreo[0].Informados.Split(new char[] { ';' });
                    foreach (string item in informados)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            filtroTrb.Add(Guid.Parse(item));
                        }
                    }
                }
                if (lstTrab != null)
                {
                    listaResponsables = lstTrab;
                }
                else
                {
                    listaResponsables = trabajadorService.ListarTrabajadores(filtroTrb).Result;
                }
                if (listaUni != null)
                {
                    listaUnidades = listaUni;
                }
                else
                {
                    listaUnidades = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = datosCorreo[0].CodigoUnidadOperativa.ToString() }).Result;
                }

                if (codigos_con_copia != null)
                {
                    lista_concatenada_correos = codigos_con_copia.Replace(",", ";");
                }

                string ls_url = string.Empty;
                int indexTrb = -1;

                if (datos.TipoNotificacion == DatosConstantes.TipoNotificacion.NuevaConsulta || datos.TipoNotificacion == DatosConstantes.TipoNotificacion.RespuestaConsulta)
                {
                    if (listaResponsables != null && listaResponsables.Count > 0)
                    {
                        indexTrb = listaResponsables.FindIndex(x => x.CodigoTrabajador.ToString().ToLower() == datosCorreo[0].CodigoResponsable.ToString().ToLower());
                        if (indexTrb > -1)
                        {
                            datos.variables.Add("@para", listaResponsables[indexTrb].NombreCompleto);
                        }
                    }
                }
                indexTrb = -1;
                if (datos.TipoNotificacion == DatosConstantes.TipoNotificacion.ContratosObservado ||
                    datos.TipoNotificacion == DatosConstantes.TipoNotificacion.ObservacionRechazada ||
                    datos.TipoNotificacion == DatosConstantes.TipoNotificacion.NuevoContratoBandeja
                )
                {
                    if (listaResponsables != null && listaResponsables.Count > 0)
                    {
                        indexTrb = listaResponsables.FindIndex(x => x.CodigoTrabajador.ToString().ToLower() == datosCorreo[0].CodigoResponsable.ToString().ToLower());
                        if (indexTrb > -1)
                        {
                            datos.variables.Add("@responsable_estadio", listaResponsables[indexTrb].NombreCompleto);
                        }
                    }
                }
                foreach (var item in listaUrlSistema)
                {
                    if (item.Codigo.Equals(DatosConstantes.IdentificadorSistema.IdentificadorSGC))
                    {
                        ls_url = item.Valor.ToString();
                    }
                }

                if (datos.TipoNotificacion == DatosConstantes.TipoNotificacion.ContratoRechazadoPorLegal)
                {
                    ls_url = string.Format("{0}{1}{2}{3}{4}{5}{6}", "<a href='", ls_url,
                                           DatosConstantes.UrlOpcionesSistema.RutaListadoContrato, "'>", ls_url,
                                           DatosConstantes.UrlOpcionesSistema.RutaListadoContrato, "</a>");
                }
                else
                {
                    ls_url = string.Format("{0}{1}{2}{3}{4}{5}{6}", "<a href='", ls_url,
                                            DatosConstantes.UrlOpcionesSistema.RutaBandejaContrato, "'>", ls_url,
                                            DatosConstantes.UrlOpcionesSistema.RutaBandejaContrato, "</a>");
                }

                datos.variables.Add("@numero_contrato", datosCorreo[0].NumeroContrato);
                datos.variables.Add("@nombre_proyecto", listaUnidades[0].Nombre);
                datos.variables.Add("@nombre_proveedor", datosCorreo[0].NombreProveedor);
                datos.variables.Add("@url_opcion_sistema.", ls_url);

                #region Parametros Adicionales para Notificación Observación y Nuevo Contrato en Bandeja.

                if (datos.TipoNotificacion == DatosConstantes.TipoNotificacion.ContratosObservado)
                {
                    datos.variables.Add("@observacion", datosCorreo[0].DescripcionObservacion);
                    datos.variables.Add("@descripcion", datosCorreo[0].DescripcionContrato);
                }

                if (datos.TipoNotificacion == DatosConstantes.TipoNotificacion.NuevoContratoBandeja)
                {
                    var trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = datosCorreo[0].UsuarioCreacion }).Result.FirstOrDefault();
                    datos.variables.Add("@usuario_creacion", trabajador.NombreCompleto);
                    datos.variables.Add("@descripcion", datosCorreo[0].DescripcionContrato);
                }

                #endregion

                datos.profileCorreo = listaProfileCorreo[0].Valor.ToString();

                if (listaResponsables != null && listaResponsables.Count > 0)
                {
                    datos.cuentaNotificar = listaResponsables.Find(x => x.CodigoTrabajador.ToString().ToLower() == datosCorreo[0].CodigoResponsable.ToString().ToLower()).CorreoElectronico;
                }

                if (!string.IsNullOrEmpty(datosCorreo[0].Informados) && listaResponsables != null)
                {
                    informados = datosCorreo[0].Informados.Split(new char[] { ';' });
                    foreach (string item in informados)
                    {
                        if (!string.IsNullOrEmpty(item))
                        {
                            datos.cuentaCopiar += listaResponsables.Find(x => x.CodigoTrabajador.ToString().ToLower() == item.ToLower()).CorreoElectronico + ";";
                        }
                    }
                }

                if (usuarioCreacion != null)
                {
                    var trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = usuarioCreacion }).Result.FirstOrDefault();
                    datos.variables.Add("@responsable_estadio", trabajador.NombreCompleto);
                    datos.cuentaNotificar = trabajador.CorreoElectronico;
                }

                if (datos.TipoNotificacion == DatosConstantes.TipoNotificacion.AprobacionContratoHistorico)
                {
                    datos.cuentaCopiar = listaResponsables.Find(x => x.CodigoTrabajador.ToString().ToLower() == datosCorreo[0].CodigoResponsable.ToString().ToLower()).CorreoElectronico;
                }
            }
            #endregion

            PlantillaNotificacionRequest filtro = new PlantillaNotificacionRequest();
            filtro.CodigoSistema = ConfigurationManager.AppSettings["CODIGO_SISTEMA"].ToString();
            filtro.CodigoTipoNotificacion = datos.TipoNotificacion;

            var datosPlantilla = plantillaNotificacionService.BuscarPlantillaNotificacion(filtro).Result;
            if (datosPlantilla != null && datosPlantilla.Count > 0)
            {
                datos.asunto = datosPlantilla[0].Asunto;
                datos.textoNotificar = datosPlantilla[0].Contenido;

                foreach (var item in datos.variables)
                {
                    datos.textoNotificar = datos.textoNotificar.Replace(item.Key, item.Value);
                }
            }

            //Si hubiera cuentas a copiar entonces le agrego los concatenados obtenidos al momento de observar
            if (datos.cuentaCopiar != null)
            {
                datos.cuentaCopiar = datos.cuentaCopiar + ";" + lista_concatenada_correos;
            }

            //Si la lista de concatenadosal momento de observar es diferente a vacío pero las cuentas a copiar obtenidas de BBDD es nulo, éstas pasan a escribir esta información
            if (lista_concatenada_correos != string.Empty && datos.cuentaCopiar == null)
            {
                datos.cuentaCopiar = lista_concatenada_correos;
            }

            //return datos;
            int ejecutaEnvio = contratoLogicRepository.NotificaBandejaContratos(datos.asunto, datos.textoNotificar, datos.cuentaNotificar, datos.cuentaCopiar, datos.profileCorreo);
            return ejecutaEnvio;
        }


        ///// <summary>
        ///// Método para listar contrato estadio responsable
        ///// </summary>
        ///// <param name="filtro">Filtro</param>
        ///// <returns>Listado de contrato estadio responsable</returns>
        //public ProcessResult<List<ContratoEstadioResponse>> ListaContratoEstadioResponsable(ContratoRequest filtro)
        //{
        //    ProcessResult<List<ContratoEstadioResponse>> resultado = new ProcessResult<List<ContratoEstadioResponse>>();
        //    try
        //    {
        //        var result = contratoLogicRepository.ListadoContratoEstadioResponsable(new Guid(filtro.CodigoContrato));
        //        resultado.Result = new List<ContratoEstadioResponse>();

        //        foreach (var item in result)
        //        {
        //            resultado.Result.Add(ContratoAdapter.ObtenerContratoEstadioResponsableResponseDeLogic(item));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.IsSuccess = false;
        //        resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
        //    }
        //    return resultado;
        //}

        /// <summary>
        /// Obtiene la lista de revisores del contrato
        /// </summary>
        /// <param name="contrato">Entidad del contrato</param>
        /// <param name="entidadFlujoAprobacionEstadio">Codigo de contrato estadio</param>
        /// <param name="login">Usuario actual</param>
        /// <returns>Lista de revisores</returns>
        public ProcessResult<List<string>> ObtenerListaRevisoresStracon(ContratoEntity contrato, FlujoAprobacionEstadioEntity entidadFlujoAprobacionEstadio = null, string login = "")
        {
            ProcessResult<List<string>> rpta = new ProcessResult<List<string>>();

            try
            {
                List<string> listaRevisoresSGC = new List<string>();
                TrabajadorResponse revisorActual = null;
                List<Guid?> codigosRevisores = new List<Guid?>();

                //Obteniendo el revisor Actual

                if (login != "")
                {
                    revisorActual = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = login }).Result.FirstOrDefault();
                }
                var listaRevisoresFlujoAprobacion = new List<FlujoAprobacionParticipanteLogic>();
                //Lista de revisores de todo el flujo de aprobación
                if (entidadFlujoAprobacionEstadio != null)
                {
                    listaRevisoresFlujoAprobacion = flujoAprobacionLogicRepository.BuscarFlujoAprobacionParticipante(entidadFlujoAprobacionEstadio.CodigoFlujoAprobacion).Where(p => p.CodigoTrabajador.ToString() == revisorActual.CodigoTrabajador && p.IndicadorIncluirVisto == true).ToList();
                }
                //Lista de revisores que ya han aprobado el contrato
                var listaRevisores = contratoLogicRepository.ListadoContratoEstadioResponsable(contrato.CodigoContrato).ToList();

                codigosRevisores = listaRevisores.Select(x => x.CodigoResponsable).ToList();

                var responsables = trabajadorService.ListarTrabajadores(codigosRevisores).Result;


                foreach (var item in listaRevisores)
                {
                    foreach (var p in responsables)
                    {
                        if (item.CodigoResponsable.ToString() == p.CodigoTrabajador)
                        {
                            listaRevisoresSGC.Add(p.Nombres + " " + p.ApellidoPaterno);
                        }
                    }
                }

                if (listaRevisoresFlujoAprobacion.Count > 0 && entidadFlujoAprobacionEstadio.Orden > 1)
                {
                    listaRevisoresSGC.Add(revisorActual.Nombres + " " + revisorActual.ApellidoPaterno);
                }

                rpta.Result = listaRevisoresSGC;
            }
            catch (Exception ex)
            {
                rpta.Result = null;
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Obtiene la lista de firmantes del contrato
        /// </summary>
        /// <param name="contrato">Contrato</param>
        /// <returns>Lista de firmantes</returns>
        public ProcessResult<List<TrabajadorResponse>> ObtenerListaFirmantesStracon(ContratoResponse contrato)
        {
            ProcessResult<List<TrabajadorResponse>> rpta = new ProcessResult<List<TrabajadorResponse>>();

            try
            {
                List<TrabajadorResponse> listaFirmantes = new List<TrabajadorResponse>();

                var listaRepFirmantesStracon = flujoAprobacionService.BuscarBandejaFlujoAprobacion(new FlujoAprobacionRequest() { CodigoFlujoAprobacion = contrato.CodigoFlujoAprobacion.ToString() }).Result.FirstOrDefault();

                var empresaVinculada = contratoLogicRepository.ObtenerEmpresaVinculadaPorProveedor(contrato.CodigoProveedor);

                if (listaRepFirmantesStracon != null)
                {
                    if (empresaVinculada == null)
                    {
                        var primerFirmante = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = new Guid(listaRepFirmantesStracon.CodigoPrimerFirmante) }).Result.FirstOrDefault();

                        var segundoFirmante = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = new Guid(listaRepFirmantesStracon.CodigoSegundoFirmante) }).Result.FirstOrDefault();

                        if (primerFirmante != null)
                        {
                            listaFirmantes.Add(primerFirmante);
                        }

                        if (segundoFirmante != null)
                        {
                            listaFirmantes.Add(segundoFirmante);
                        }
                    }
                    else
                    {
                        var primerFirmanteVinculada = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = new Guid(listaRepFirmantesStracon.CodigoPrimerFirmanteVinculada) }).Result.FirstOrDefault();

                        var segundoFirmanteVinculada = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoTrabajador = new Guid(listaRepFirmantesStracon.CodigoSegundoFirmanteVinculada) }).Result.FirstOrDefault();

                        if (primerFirmanteVinculada != null)
                        {
                            listaFirmantes.Add(primerFirmanteVinculada);
                        }

                        if (segundoFirmanteVinculada != null)
                        {
                            listaFirmantes.Add(segundoFirmanteVinculada);
                        }
                    }
                }

                rpta.Result = listaFirmantes;
            }
            catch (Exception ex)
            {
                rpta.Result = null;
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Obtiene la empresa vinculada por proveedor
        /// </summary>
        /// <param name="codigoProveedor">Código del proveedor</param>
        /// <returns>Empresa vinculada por proveedor</returns>
        public ProcessResult<EmpresaVinculadaResponse> ObtenerEmpresaVinculadaPorProveedor(Guid? codigoProveedor)
        {
            ProcessResult<EmpresaVinculadaResponse> rpta = new ProcessResult<EmpresaVinculadaResponse>();
            EmpresaVinculadaResponse empresaResponse = new EmpresaVinculadaResponse();

            try
            {
                var empresaVinculada = contratoLogicRepository.ObtenerEmpresaVinculadaPorProveedor(codigoProveedor);

                if (empresaVinculada != null)
                {
                    empresaResponse.CodigoEmpresaVinculada = empresaVinculada.CodigoEmpresaVinculada;
                    empresaResponse.NombreEmpresa = empresaVinculada.NombreEmpresa;
                    empresaResponse.NumeroRuc = empresaVinculada.NumeroRuc;
                }

                rpta.Result = empresaResponse;
            }
            catch (Exception ex)
            {
                rpta.Result = null;
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Realiza la búsqueda de listado contrato
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de contratos</returns>
        public ProcessResult<List<ListadoContratoResponse>> BuscarListadoContrato(ListadoContratoRequest filtro)
        {
            ProcessResult<List<ListadoContratoResponse>> resultado = new ProcessResult<List<ListadoContratoResponse>>();
            List<CodigoValorResponse> resultadoTipoServicio = null;
            List<CodigoValorResponse> resultadoTipoRequerimiento = null;
            List<CodigoValorResponse> resultadoTipoDocumento = null;
            List<CodigoValorResponse> resultadoEstadoContrato = null;
            List<CodigoValorResponse> resultadoEstadoEdicion = null;
            List<UnidadOperativaResponse> resultadoUnidadOperativa = null;

            List<Guid?> listaUnidadOperativaAsociadoTrabajador = null;

            try
            {
                resultadoTipoServicio = politicaService.ListarTipoContrato().Result;
                resultadoTipoRequerimiento = politicaService.ListarTipoServicio().Result;
                resultadoTipoDocumento = politicaService.ListarTipoDocumentoContrato().Result;
                resultadoEstadoContrato = politicaService.ListarEstadoContrato().Result;
                resultadoEstadoEdicion = politicaService.ListarEstadoEdicion().Result;
                resultadoUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa()).Result;

                Guid? codigoContrato = filtro.CodigoContrato != null ? new Guid(filtro.CodigoContrato) : (Guid?)null;
                Guid? codigoUnidadOperativa = filtro.CodigoUnidadOperativa != null ? new Guid(filtro.CodigoUnidadOperativa) : (Guid?)null;
                bool? indicadorTodaUnidadOperativa = filtro.Trabajador != null ? filtro.Trabajador.IndicadorTodaUnidadOperativa : (bool?)null;
                Guid? codigoTrabajadorResponsable = filtro.CodigoTrabajadorResponsable != null ? new Guid(filtro.CodigoTrabajadorResponsable) : (Guid?)null;

                if (filtro.Trabajador != null && filtro.Trabajador.IndicadorTodaUnidadOperativa == false)
                {
                    var trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = entornoAplicacion.UsuarioSession }).Result.FirstOrDefault();

                    TrabajadorUnidadOperativaRequest trabajadaroUnidadOperativaRequest = new TrabajadorUnidadOperativaRequest();
                    trabajadaroUnidadOperativaRequest.CodigoUnidadOperativaMatriz = new Guid(trabajador.CodigoUnidadOperativaMatriz);
                    trabajadaroUnidadOperativaRequest.CodigoTrabajador = new Guid(trabajador.CodigoTrabajador);

                    listaUnidadOperativaAsociadoTrabajador = trabajadorService.ListarTrabajadorUnidadOperativa(trabajadaroUnidadOperativaRequest).Result.Select(x => x.CodigoUnidadOperativa).ToList();
                }

                //Guid? codigoTrabajador = filtro.CodigoTrabajador != null ? new Guid(filtro.CodigoTrabajador) : (Guid?)null;

                DateTime? fechaInicioVigencia = null;
                DateTime? fechaFinVigencia = null;
                decimal? montoContrato = null;

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
                    fechaFinVigencia = DateTime.ParseExact(filtro.FechaFinVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture); ;
                }
                else
                {
                    fechaFinVigencia = null;
                }

                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";
                numberFormatInfo.NumberGroupSeparator = ",";

                if (!string.IsNullOrWhiteSpace(filtro.MontoContratoString))
                {
                    montoContrato = Decimal.Parse(filtro.MontoContratoString, numberFormatInfo);
                }
                else
                {
                    montoContrato = null;
                }
                var resultadoTrabajador = trabajadorService.BuscarTrabajadorDatoMinimo(new TrabajadorRequest()).Result;

                List<ListadoContratoLogic> listado = listadoContratoLogicRepository.BuscarListadoContrato(codigoContrato, codigoUnidadOperativa, null, filtro.CodigoTipoServicio,
                                                                                        filtro.CodigoTipoRequerimiento, filtro.CodigoTipoDocumento, filtro.CodigoEstadoContrato,
                                                                                        filtro.NumeroContrato, filtro.NumeroAdendaConcatenado, filtro.NumeroDocumentoProveedor, filtro.NombreProveedor,
                                                                                        filtro.Descripcion, indicadorTodaUnidadOperativa, listaUnidadOperativaAsociadoTrabajador,
                                                                                        filtro.CodigoEstadoEdicion, filtro.DescripcionContrato, codigoTrabajadorResponsable, filtro.NombreEstadio,
                                                                                        filtro.IndicadorFinalizarAprobacion, filtro.NumeroPagina, filtro.RegistrosPagina);

                resultado.Result = new List<ListadoContratoResponse>();
                foreach (var registro in listado)
                {

                    var listadoContrato = ListadoContratoAdapter.ObtenerListadoContratoPaginado(registro, resultadoTipoServicio, resultadoTipoRequerimiento, resultadoTipoDocumento, resultadoEstadoContrato, resultadoEstadoEdicion, resultadoTrabajador, resultadoUnidadOperativa);
                    resultado.Result.Add(listadoContrato);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ProcessResult<List<ListadoContratoResponse>> BuscarListadoContratoOrden(ListadoContratoRequest filtro)
        {
            ProcessResult<List<ListadoContratoResponse>> resultado = new ProcessResult<List<ListadoContratoResponse>>();
            List<CodigoValorResponse> resultadoTipoServicio = null;
            List<CodigoValorResponse> resultadoTipoRequerimiento = null;
            List<CodigoValorResponse> resultadoTipoDocumento = null;
            List<CodigoValorResponse> resultadoEstadoContrato = null;
            List<CodigoValorResponse> resultadoEstadoEdicion = null;
            List<UnidadOperativaResponse> resultadoUnidadOperativa = null;

            List<Guid?> listaUnidadOperativaAsociadoTrabajador = null;

            try
            {
                resultadoTipoServicio = politicaService.ListarTipoContrato().Result;
                resultadoTipoRequerimiento = politicaService.ListarTipoServicio().Result;
                resultadoTipoDocumento = politicaService.ListarTipoDocumentoContrato().Result;
                resultadoEstadoContrato = politicaService.ListarEstadoContrato().Result;
                resultadoEstadoEdicion = politicaService.ListarEstadoEdicion().Result;
                resultadoUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa()).Result;

                Guid? codigoContrato = filtro.CodigoContrato != null ? new Guid(filtro.CodigoContrato) : (Guid?)null;
                Guid? codigoUnidadOperativa = filtro.CodigoUnidadOperativa != null ? new Guid(filtro.CodigoUnidadOperativa) : (Guid?)null;
                bool? indicadorTodaUnidadOperativa = filtro.Trabajador != null ? filtro.Trabajador.IndicadorTodaUnidadOperativa : (bool?)null;
                Guid? codigoTrabajadorResponsable = filtro.CodigoTrabajadorResponsable != null ? new Guid(filtro.CodigoTrabajadorResponsable) : (Guid?)null;

                if (filtro.Trabajador != null && filtro.Trabajador.IndicadorTodaUnidadOperativa == false)
                {
                    var trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = entornoAplicacion.UsuarioSession }).Result.FirstOrDefault();

                    TrabajadorUnidadOperativaRequest trabajadaroUnidadOperativaRequest = new TrabajadorUnidadOperativaRequest();
                    trabajadaroUnidadOperativaRequest.CodigoUnidadOperativaMatriz = new Guid(trabajador.CodigoUnidadOperativaMatriz);
                    trabajadaroUnidadOperativaRequest.CodigoTrabajador = new Guid(trabajador.CodigoTrabajador);

                    listaUnidadOperativaAsociadoTrabajador = trabajadorService.ListarTrabajadorUnidadOperativa(trabajadaroUnidadOperativaRequest).Result.Select(x => x.CodigoUnidadOperativa).ToList();
                }

                DateTime? fechaInicioVigencia = null;
                DateTime? fechaFinVigencia = null;
                decimal? montoContrato = null;

                decimal? montoAcumuladoInicio = null;
                decimal? montoAcumuladoFin = null;

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
                    fechaFinVigencia = DateTime.ParseExact(filtro.FechaFinVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture); ;
                }
                else
                {
                    fechaFinVigencia = null;
                }

                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";
                numberFormatInfo.NumberGroupSeparator = ",";

                if (!string.IsNullOrWhiteSpace(filtro.MontoContratoString))
                {
                    montoContrato = Decimal.Parse(filtro.MontoContratoString, numberFormatInfo);
                }
                else
                {
                    montoContrato = null;
                }

                var resultadoTrabajador = trabajadorService.BuscarTrabajadorDatoMinimo(new TrabajadorRequest()).Result;

                if (!string.IsNullOrWhiteSpace(filtro.MontoAcumuladoInicio))
                {
                    montoAcumuladoInicio = Decimal.Parse(filtro.MontoAcumuladoInicio, numberFormatInfo);
                }
                else
                {
                    montoAcumuladoInicio = null;
                }

                if (!string.IsNullOrWhiteSpace(filtro.MontoAcumuladoFin))
                {
                    montoAcumuladoFin = Decimal.Parse(filtro.MontoAcumuladoFin, numberFormatInfo);
                }
                else
                {
                    montoAcumuladoFin = null;
                }

                List<ListadoContratoLogic> listado = listadoContratoLogicRepository.BuscarListadoContratoOrden(
                                                                        codigoContrato, codigoUnidadOperativa, null, filtro.CodigoTipoServicio,
                                                                        filtro.CodigoTipoRequerimiento, filtro.CodigoTipoDocumento, filtro.CodigoEstadoContrato,
                                                                        filtro.NumeroContrato, filtro.NumeroAdendaConcatenado, filtro.NumeroDocumentoProveedor, filtro.NombreProveedor,
                                                                        filtro.Descripcion, indicadorTodaUnidadOperativa, listaUnidadOperativaAsociadoTrabajador,
                                                                        filtro.CodigoEstadoEdicion, filtro.DescripcionContrato, codigoTrabajadorResponsable, filtro.NombreEstadio,
                                                                        filtro.IndicadorFinalizarAprobacion, montoAcumuladoInicio, montoAcumuladoFin, filtro.CodigoMoneda,
                                                                        filtro.UsuarioCreacion, filtro.ColumnaOrden, filtro.TipoOrden, filtro.NumeroPagina, filtro.RegistrosPagina
                                                                                        );


                resultado.Result = new List<ListadoContratoResponse>();
                foreach (var registro in listado)
                {
                    var listadoContrato = ListadoContratoAdapter.ObtenerListadoContratoPaginado(registro, resultadoTipoServicio, resultadoTipoRequerimiento, resultadoTipoDocumento, resultadoEstadoContrato, resultadoEstadoEdicion, resultadoTrabajador, resultadoUnidadOperativa);
                    resultado.Result.Add(listadoContrato);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(e.GetBaseException());
            }
            return resultado;
        }

        /// <summary>
        /// Realiza la búsqueda de contratos
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de contratos</returns>
        public ProcessResult<List<ListadoContratoResponse>> BuscarContrato(ListadoContratoRequest filtro)
        {
            ProcessResult<List<ListadoContratoResponse>> resultado = new ProcessResult<List<ListadoContratoResponse>>();
            List<Guid?> listaUnidadOperativaAsociadoTrabajador = null;

            try
            {

                if (filtro.Trabajador != null)
                {
                    var trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = entornoAplicacion.UsuarioSession }).Result.FirstOrDefault();

                    TrabajadorUnidadOperativaRequest trabajadaroUnidadOperativaRequest = new TrabajadorUnidadOperativaRequest();
                    trabajadaroUnidadOperativaRequest.CodigoUnidadOperativaMatriz = new Guid(trabajador.CodigoUnidadOperativaMatriz);
                    trabajadaroUnidadOperativaRequest.CodigoTrabajador = new Guid(trabajador.CodigoTrabajador);

                    listaUnidadOperativaAsociadoTrabajador = trabajadorService.ListarTrabajadorUnidadOperativa(trabajadaroUnidadOperativaRequest).Result.Select(x => x.CodigoUnidadOperativa).ToList();
                }

                List<ListadoContratoLogic> listado = listadoContratoLogicRepository.BuscarListadoContrato(null, null, null, filtro.CodigoTipoServicio,
                                                                                        filtro.CodigoTipoRequerimiento, filtro.CodigoTipoDocumento, filtro.CodigoEstadoContrato,
                                                                                        filtro.NumeroContrato, filtro.NumeroAdendaConcatenado, filtro.NumeroDocumentoProveedor, filtro.NombreProveedor,
                                                                                        filtro.Descripcion, true, listaUnidadOperativaAsociadoTrabajador,
                                                                                        filtro.CodigoEstadoEdicion, filtro.DescripcionContrato, null, filtro.NombreEstadio,
                                                                                        filtro.IndicadorFinalizarAprobacion, filtro.NumeroPagina, filtro.RegistrosPagina);

                resultado.Result = new List<ListadoContratoResponse>();
                foreach (var registro in listado)
                {
                    var listadoContrato = ListadoContratoAdapter.ObtenerBusquedaContrato(registro);
                    resultado.Result.Add(listadoContrato);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Registra o actualiza un contrato
        /// </summary>
        /// <param name="dataContrato">Datos a registrar de Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarContrato(ContratoRequest dataContrato)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();

            try
            {
                #region Nuevo
                if (dataContrato.CodigoContrato == null)
                {
                    var esAdendaContratoVencido = false;
                    dataContrato.IndicadorVersionOficial = false;

                    #region Adenda
                    if (dataContrato.CodigoTipoDocumento == DatosConstantes.TipoDocumento.Adenda)
                    {
                        #region Obtiene Datos Contrato y sus Adendas

                        var entidadContratoPrincipal = ObtieneContratoPorID(new Guid(dataContrato.CodigoContratoPrincipal.ToString())).Result;
                        DateTime fechaFinUltimaAdenda = DateTime.Now;

                        var listaAdendas = listadoContratoLogicRepository.BuscarContrato(null, dataContrato.CodigoContratoPrincipal, string.Empty, string.Empty, dataContrato.CodigoTipoDocumento, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty).OrderByDescending(a => a.NumeroAdenda).FirstOrDefault();
                        dataContrato.NumeroAdenda = (listaAdendas == null) ? 1 : listaAdendas.NumeroAdenda + 1;

                        if (dataContrato.NumeroAdenda > 1) fechaFinUltimaAdenda = listaAdendas.FechaFinVigencia;

                        dataContrato.NumeroAdendaConcatenado = string.Format(DatosConstantes.Formato.FormatoNumeroAdenda, entidadContratoPrincipal.NumeroContrato, dataContrato.NumeroAdenda);
                        dataContrato.NumeroContrato = entidadContratoPrincipal.NumeroContrato;

                        #endregion

                        #region Diferente a Historico.
                        if (dataContrato.CodigoTipoRequerimiento != DatosConstantes.TipoServicio.ContratoHistorico)
                        {
                            //Adenda 1
                            if (listaAdendas == null)
                            {
                                if (entidadContratoPrincipal.CodigoEstado == DatosConstantes.EstadoContrato.Vencido)
                                {
                                    #region Valida días vencido
                                    var diasParametro = parametroValorService.BuscarParametroValor(new ParametroValorRequest()
                                    {
                                        CodigoParametro = DatosConstantes.ParametroValor.DiasGeneracionAdendaVencido,
                                        CodigoSeccion = 1,
                                        EstadoRegistro = "1"
                                    }).Result.FirstOrDefault();

                                    if (diasParametro != null)
                                    {
                                        DateTime fechaComparativa = (dataContrato.NumeroAdenda > 1) ? fechaFinUltimaAdenda : (DateTime)entidadContratoPrincipal.FechaFinVigencia;

                                        DateTime fechaInicio = fechaComparativa;
                                        DateTime fechaFin = DateTime.Today;
                                        TimeSpan diferencia = (fechaFin - fechaInicio);

                                        var diasContrato = diferencia.Days;

                                        int valorDiasParametro = 0;
                                        bool validaDiasParametro = int.TryParse(diasParametro.RegistroCadena.First(x => x.Key == "1").Value, out valorDiasParametro);

                                        if (validaDiasParametro && diasContrato > valorDiasParametro)
                                        {
                                            resultado.IsSuccess = false;
                                            resultado.Exception = new ApplicationLayerException<ContratoService>(string.Format("La adenda supera los {0} días del período de gracia.", valorDiasParametro));
                                            return resultado;
                                        }
                                        else
                                        {
                                            esAdendaContratoVencido = true;
                                        }
                                    }
                                    #endregion
                                }
                                else if (entidadContratoPrincipal.CodigoEstado != DatosConstantes.EstadoContrato.Vigente
                                    && entidadContratoPrincipal.CodigoEstado != DatosConstantes.EstadoContrato.Vencido)
                                {
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<ContratoService>("El Contrato N° " + entidadContratoPrincipal.NumeroContrato + " no se encuentra en estado Vencido o Vigente.");
                                    return resultado;
                                }
                            }
                            //Adenda 2 o mas
                            else
                            {
                                if (listaAdendas.CodigoEstadoContrato == DatosConstantes.EstadoContrato.Vencido)
                                {
                                    #region Valida dias Vencido.
                                    var diasParametro = parametroValorService.BuscarParametroValor(new ParametroValorRequest()
                                    {
                                        CodigoParametro = DatosConstantes.ParametroValor.DiasGeneracionAdendaVencido,
                                        CodigoSeccion = 1,
                                        CodigoValor = 1,
                                        EstadoRegistro = "1"
                                    }).Result.FirstOrDefault();

                                    if (diasParametro != null)
                                    {
                                        DateTime fechaComparativa = (dataContrato.NumeroAdenda > 1) ? fechaFinUltimaAdenda : (DateTime)entidadContratoPrincipal.FechaFinVigencia;

                                        DateTime fechaInicio = fechaComparativa;
                                        DateTime fechaFin = DateTime.Today;
                                        TimeSpan diferencia = (fechaFin - fechaInicio);

                                        var diasContrato = diferencia.Days;

                                        int valorDiasParametro = 0;
                                        bool validaDiasParametro = int.TryParse(diasParametro.RegistroCadena.First(x => x.Key == "1").Value, out valorDiasParametro);

                                        if (validaDiasParametro && diasContrato > valorDiasParametro)
                                        {
                                            resultado.IsSuccess = false;
                                            resultado.Exception = new ApplicationLayerException<ContratoService>(string.Format("La adenda supera los {0} días del período de gracia.", valorDiasParametro));
                                            return resultado;
                                        }
                                        else
                                        {
                                            esAdendaContratoVencido = true;
                                        }
                                    }

                                    #endregion
                                }
                                else if (listaAdendas.CodigoEstadoContrato != DatosConstantes.EstadoContrato.Vencido
                                    && listaAdendas.CodigoEstadoContrato != DatosConstantes.EstadoContrato.Vigente)
                                {
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<ContratoService>("La Adenda N° " + listaAdendas.NumeroAdendaConcatenado + " no se encuentra en estado Vencido o Vigente.");
                                    return resultado;
                                }
                            }
                        }
                        #endregion

                        #region Igual a Historico
                        else
                        {
                            //Adenda 1
                            if (listaAdendas == null)
                            {
                                if (entidadContratoPrincipal.CodigoEstado != DatosConstantes.EstadoContrato.Vencido
                                    && entidadContratoPrincipal.CodigoEstado != DatosConstantes.EstadoContrato.Vigente)
                                {
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<ContratoService>("El Contrato N° " + entidadContratoPrincipal.NumeroContrato + " no se encuentra en estado Vigente o Vencido");
                                    return resultado;
                                }
                            }
                            //Adenda 2 o mas
                            else
                            {
                                if (listaAdendas.CodigoEstadoContrato != DatosConstantes.EstadoContrato.Vencido
                                    && listaAdendas.CodigoEstadoContrato != DatosConstantes.EstadoContrato.Vigente)
                                {
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<ContratoService>("La Adenda N° " + listaAdendas.NumeroAdendaConcatenado + " no se encuentra en estado Vigente o Vencido");
                                    return resultado;
                                }
                            }
                        }
                        #endregion

                    }
                    #endregion

                    #region Monto Acumulado
                    else
                    {
                        dataContrato.MontoAcumuladoString = dataContrato.MontoContratoString;
                    }
                    #endregion

                    dataContrato.CodigoEstado = DatosConstantes.EstadoContrato.Edicion;
                    dataContrato.CodigoEstadoEdicion = DatosConstantes.CodigoEstadoEdicion.EdicionParcial;

                    #region  Asignación de Plantilla                
                    var resultadoPlantilla = plantillaService.BuscarPlantilla(new PlantillaRequest()
                    {
                        CodigoTipoContrato = dataContrato.CodigoTipoServicio,
                        CodigoTipoDocumentoContrato = dataContrato.CodigoTipoDocumento,
                        IndicadorAdhesion = dataContrato.IndicadorAdhesion,
                        CodigoEstadoVigencia = DatosConstantes.EstadoVigencia.Vigente
                    }).Result.FirstOrDefault();
                    #endregion

                    if (resultadoPlantilla != null && dataContrato.CodigoFlujoAprobacion != null)
                    {
                        dataContrato.CodigoPlantilla = resultadoPlantilla.CodigoPlantilla;
                        //dataContrato.CodigoFlujoAprobacion = dataContrato.CodigoFlujoAprobacion;

                        ContratoEntity entidadContrato = ListadoContratoAdapter.RegistrarContrato(dataContrato);

                        var resultadoContrato = contratoEntityRepository.RegistrarContrato(entidadContrato);

                        if (resultadoContrato != 0)
                        {
                            #region Registro de Contrato Estadio
                            ContratoEstadioRequest dataContratoEstadio = new ContratoEstadioRequest();

                            var resultadoFlujoAprobacionEstadio = flujoAprobacionService.BuscarBandejaFlujoAprobacionEstadio(
                            null,
                            dataContrato.CodigoFlujoAprobacion
                            ).Result.OrderBy(x => x.Orden).FirstOrDefault();

                            if (resultadoFlujoAprobacionEstadio != null)
                            {
                                entidadContrato.CodigoEstadioActual = new Guid(resultadoFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio);
                            }

                            dataContratoEstadio.CodigoFlujoAprobacionEstadio = new Guid(resultadoFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio);
                            dataContratoEstadio.CodigoContrato = entidadContrato.CodigoContrato;
                            dataContratoEstadio.FechaIngreso = DateTime.Now.Date;

                            if (resultadoFlujoAprobacionEstadio.CodigoResponsable == null)
                            {
                                dataContratoEstadio.CodigoResponsable = null;
                            }
                            else
                            {
                                dataContratoEstadio.CodigoResponsable = Guid.Parse(resultadoFlujoAprobacionEstadio.CodigoResponsable);
                            }

                            dataContratoEstadio.CodigoEstadoContratoEstadio = DatosConstantes.CodigoEstadoContratoEstadio.Iniciado;
                            ContratoEstadioEntity entidadContratoEstadio = ContratoEstadioAdapter.RegistrarContratoEstadio(dataContratoEstadio);

                            contratoEstadioEntityRepository.RegistrarContratoEstadio(entidadContratoEstadio);
                            #endregion

                            #region Registrar adendas de contrato vencido en tabla temporal para notificación (envio de correo)
                            if (esAdendaContratoVencido == true)
                            {
                                contratoLogicRepository.RegistraAdendaContratoVencido((Guid)dataContrato.CodigoUnidadOperativa, dataContrato.NumeroContrato, dataContrato.Descripcion, dataContrato.NumeroAdenda, dataContrato.NumeroAdendaConcatenado);
                            }
                            #endregion

                            resultado.IsSuccess = true;
                            resultado.Result = entidadContrato.CodigoContrato;
                        }
                        else
                        {
                            throw new Exception(string.Empty);
                        }
                    }
                    else
                    {
                        throw new Exception("No se encontró ninguna plantilla asociada.");
                    }
                }
                #endregion

                #region Edición
                else
                {
                    NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
                    numberFormatInfo.NumberDecimalSeparator = ".";
                    numberFormatInfo.NumberGroupSeparator = ",";

                    var entidadContrato = contratoEntityRepository.GetById(Guid.Parse(dataContrato.CodigoContrato));

                    entidadContrato.FechaInicioVigencia = DateTime.ParseExact(dataContrato.FechaInicioVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
                    entidadContrato.FechaFinVigencia = DateTime.ParseExact(dataContrato.FechaFinVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
                    entidadContrato.CodigoMoneda = dataContrato.CodigoMoneda;
                    entidadContrato.MontoContrato = Decimal.Parse(dataContrato.MontoContratoString, numberFormatInfo);
                    entidadContrato.MontoAcumulado = (dataContrato.MontoAcumuladoString != null) ? Decimal.Parse(dataContrato.MontoAcumuladoString, numberFormatInfo) : 0;
                    entidadContrato.Descripcion = dataContrato.Descripcion;
                    entidadContrato.EsCorporativo = dataContrato.EsCorporativo;
                    entidadContrato.CodigoProveedor = dataContrato.CodigoProveedor;
                    entidadContrato.CodigoFlujoAprobacion = new Guid(dataContrato.CodigoFlujoAprobacion);

                    entidadContrato.CodigoRequerido = new Guid(dataContrato.CodigoRequerido);

                    contratoEntityRepository.Editar(entidadContrato, entornoActualAplicacion);
                    contratoEntityRepository.GuardarCambios();

                    contratoEntityRepository.Actualizar_Flujo_Contrato_Estadio(entidadContrato);

                    resultado.IsSuccess = true;
                    resultado.Result = entidadContrato.CodigoContrato;
                }
                #endregion
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene el tipo de Contrato segun la Unidad Operativa S11-SGC
        /// </summary>
        /// <param name="CodigoUnidadOperativa"></param>
        /// <returns></returns>
        public List<string> Obtener_Tipo_Contrato(Guid CodigoUnidadOperativa)
        {
            return listadoContratoLogicRepository.Listar_Contrato_Segun_Unidad_Operativa(CodigoUnidadOperativa);
        }

        /// <summary>
        /// Permite generar el número de contrato
        /// </summary>
        /// <param name="unidadOperativa">Unidad Operativa</param>
        /// <param name="codigoTipoServicio">Tipo de Servicio</param>
        /// <param name="abreviaturaTipoServicio">Abreviatura del servicio</param>
        /// <param name="tipoDocumento">Tipo de contrato</param>
        /// <returns>Número del Contrato</returns>
        private string GenerarNumeroContrato(UnidadOperativaResponse unidadOperativa, string codigoTipoServicio, string abreviaturaTipoServicio, string tipoDocumento)
        {
            var unidadOperativaSuperior = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = unidadOperativa.CodigoUnidadOperativaPadre.ToString() }).Result.FirstOrDefault();
            string anioActual = DateTime.Now.Year.ToString().Substring(2, 2);

            var listadoContrato = listadoContratoLogicRepository.BuscarCorrelativoContrato(unidadOperativa.CodigoUnidadOperativa, codigoTipoServicio, tipoDocumento);
            listadoContrato = listadoContrato.FindAll(item => item.NumeroContrato.Split(Convert.ToChar(DatosConstantes.Formato.SeparadorFormatoNumeroContrato)).ElementAt(3) == anioActual &&
                                                             item.NumeroContrato.Split(Convert.ToChar(DatosConstantes.Formato.SeparadorFormatoNumeroContrato)).ElementAt(2) == abreviaturaTipoServicio );

            var numeroMax = 0;
            List<int> numerosContrato = new List<int>();

            foreach (var item in listadoContrato)
            {
                var numeroContratoItem = item.NumeroContrato.Split(Convert.ToChar(DatosConstantes.Formato.SeparadorFormatoNumeroContrato));
                numerosContrato.Add(Convert.ToInt32(numeroContratoItem.ElementAt(4)));
            }
            if (numerosContrato.Count != 0)
            {
                numeroMax = numerosContrato.Max();
            }
            else
            {
                numeroMax = 1;
            }

            var ultimoContrato = listadoContrato.LastOrDefault();

            string numeroContrato = string.Format(DatosConstantes.Formato.FormatoNumeroContrato, unidadOperativaSuperior.CodigoIdentificacion, unidadOperativa.CodigoIdentificacion, abreviaturaTipoServicio, anioActual, string.Empty);

            int correlativo = 0;
            if (ultimoContrato != null && ultimoContrato.NumeroContrato != null)
            {
                string numeroContratoUltimoSinCorrelativo = string.Empty;
                var numeroContratoUltimoSperado = ultimoContrato.NumeroContrato.Split(Convert.ToChar(DatosConstantes.Formato.SeparadorFormatoNumeroContrato));

                for (var index = 0; index < numeroContratoUltimoSperado.Count() - 1; index++)
                {
                    numeroContratoUltimoSinCorrelativo += numeroContratoUltimoSperado[index] + ".";
                }

                if (numeroContratoUltimoSinCorrelativo == numeroContrato)
                {
                    correlativo = numeroMax;
                    //correlativo = Convert.ToInt32(numeroContratoUltimoSperado.LastOrDefault());
                }
            }
            correlativo++;

            numeroContrato += correlativo.ToString().PadLeft(3, '0');

            return numeroContrato;
        }

        /// <summary>
        /// Registra o actualiza un listado contrato
        /// </summary>
        /// <param name="dataContrato">Datos a registrar de Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarListadoContrato(ContratoRequest dataContrato)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            ContratoParrafoRequest dataContratoParrafo = new ContratoParrafoRequest();
            ContratoParrafoVariableRequest dataContratoParrafoVariable = new ContratoParrafoVariableRequest();
            ContratoBienRequest dataContratoBien = new ContratoBienRequest();
            ContratoFirmanteRequest dataContratoFirmante = new ContratoFirmanteRequest();

            UnidadOperativaResponse unidadOperativa = null;
            string codigoFormaEdicion, hayError = string.Empty;

            var valor = 0;
            string numeroContrato = "";

            try
            {
                var entidadContrato = ObtieneContratoPorID(new Guid(dataContrato.CodigoContrato)).Result;
                numeroContrato = entidadContrato.NumeroContrato;
                entidadContrato.IndicadorVersionOficial = false;

                #region  Generando contrato documento
                dataContrato.ContratoDocumento.CodigoContrato = dataContrato.CodigoContrato;
                dataContrato.ContratoDocumento.CodigoArchivo = 0;
                dataContrato.ContratoDocumento.RutaArchivoSharePoint = string.Empty;
                dataContrato.ContratoDocumento.IndicadorActual = true;
                dataContrato.ContratoDocumento.Version = 1;
                ContratoDocumentoEntity entidadContratoDocumento = ContratoDocumentoAdapter.RegistrarContratoDocumento(dataContrato.ContratoDocumento);
                #endregion

                #region Valida Numero Contrato
                if (entidadContrato.NumeroContrato == null || entidadContrato.NumeroContrato == "")
                {
                    unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = entidadContrato.CodigoUnidadOperativa.ToString() }).Result.FirstOrDefault();
                    var tipoRequerimiento = politicaService.ListarTipoServicioDinamico().Result.Where(p => p.Atributo1 == entidadContrato.CodigoTipoRequerimiento).FirstOrDefault();
                    numeroContrato = string.IsNullOrEmpty(entidadContrato.NumeroContrato) ? GenerarNumeroContrato(unidadOperativa, tipoRequerimiento.Atributo1, tipoRequerimiento.Atributo4, entidadContrato.CodigoTipoDocumento) : entidadContrato.NumeroContrato;

                    valor = contratoEntityRepository.ConsultaNumeroContrato(new ContratoEntity()
                    {
                        NumeroContrato = numeroContrato
                    });
                }
                #endregion

                if (valor != 3)
                {
                    #region Grabado

                    //Consulta si el grabado es parcial o total
                    if (dataContrato.TipoRegistro == DatosConstantes.TipoRegistro.Parcial)
                    {
                        codigoFormaEdicion = null;
                        entidadContrato.CodigoEstado = DatosConstantes.EstadoContrato.Edicion;
                        entidadContrato.CodigoEstadoEdicion = DatosConstantes.CodigoEstadoEdicion.EdicionParcial;
                    }
                    else
                    {
                        if (dataContrato.IndicadorSolicitarModificacion)
                        {
                            codigoFormaEdicion = DatosConstantes.FormaEdicion.Flexible;
                            entidadContrato.CodigoEstado = DatosConstantes.EstadoContrato.Edicion;
                            entidadContrato.CodigoEstadoEdicion = DatosConstantes.CodigoEstadoEdicion.SolicitudAutorizada;
                            entidadContrato.ComentarioModificacion = dataContrato.ComentarioModificacion;
                        }
                        else
                        {
                            codigoFormaEdicion = DatosConstantes.FormaEdicion.Cerrado;
                            entidadContrato.CodigoEstado = DatosConstantes.EstadoContrato.Aprobacion;
                            entidadContrato.CodigoEstadoEdicion = null;
                        }
                    }

                    dataContratoParrafo.CodigoContrato = entidadContrato.CodigoContrato.ToString();
                    List<ContratoParrafoEntity> entidadContratoParrafo = new List<ContratoParrafoEntity>();
                    List<ContratoParrafoVariableEntity> entidadContratoParrafoVariable = new List<ContratoParrafoVariableEntity>();
                    List<ContratoBienEntity> entidadContratoBien = new List<ContratoBienEntity>();
                    List<ContratoFirmanteEntity> entidadContratoFirmante = new List<ContratoFirmanteEntity>();


                    foreach (var item in dataContrato.ContratoDocumento.ListaContratoParrafo)
                    {
                        item.CodigoContrato = entidadContrato.CodigoContrato.ToString();
                        if (!entidadContratoParrafo.Any(itemAny => itemAny.CodigoPlantillaParrafo == new Guid(item.CodigoPlantillaParrafo)))
                        {
                            var objContratoParrafo = ContratoParrafoAdapter.RegistrarContratoParrafo(item);
                            entidadContratoParrafo.Add(objContratoParrafo);
                            dataContratoParrafoVariable.CodigoContratoParrafo = objContratoParrafo.CodigoContratoParrafo.ToString();
                        }

                        foreach (var itemVariable in item.ListaContratoParrafoVariable)
                        {
                            //Guardar en Contrato Párrafo Variable
                            if (!entidadContratoParrafoVariable.Any(itemAny => itemAny.CodigoContratoParrafo == new Guid(dataContratoParrafoVariable.CodigoContratoParrafo) && itemAny.CodigoVariable == new Guid(itemVariable.CodigoVariable)))
                            {
                                dataContratoParrafoVariable.CodigoVariable = itemVariable.CodigoVariable;
                                switch (itemVariable.CodigoTipoVariable)
                                {
                                    case DatosConstantes.TipoVariable.Texto:
                                        dataContratoParrafoVariable.ValorTexto = itemVariable.Valor;
                                        dataContratoParrafoVariable.ValorNumeroString = null;
                                        dataContratoParrafoVariable.ValorFechaString = null;
                                        dataContratoParrafoVariable.ValorImagen = null;
                                        dataContratoParrafoVariable.ValorTabla = null;
                                        dataContratoParrafoVariable.ValorBien = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Numero:
                                        dataContratoParrafoVariable.ValorNumeroString = itemVariable.Valor;
                                        dataContratoParrafoVariable.ValorTexto = null;
                                        dataContratoParrafoVariable.ValorFechaString = null;
                                        dataContratoParrafoVariable.ValorImagen = null;
                                        dataContratoParrafoVariable.ValorTabla = null;
                                        dataContratoParrafoVariable.ValorBien = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Fecha:
                                        dataContratoParrafoVariable.ValorFechaString = itemVariable.Valor;
                                        dataContratoParrafoVariable.ValorTexto = null;
                                        dataContratoParrafoVariable.ValorNumeroString = null;
                                        dataContratoParrafoVariable.ValorImagen = null;
                                        dataContratoParrafoVariable.ValorTabla = null;
                                        dataContratoParrafoVariable.ValorBien = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Imagen:
                                        if (!string.IsNullOrWhiteSpace(itemVariable.Valor))
                                        {
                                            itemVariable.Valor = itemVariable.Valor.Replace("data:image/png;base64,", string.Empty);
                                            itemVariable.Valor = itemVariable.Valor.Replace("data:image/jpg;base64,", string.Empty);
                                            itemVariable.Valor = itemVariable.Valor.Replace("data:image/jpeg;base64,", string.Empty);
                                            itemVariable.Valor = itemVariable.Valor.Replace("data:image/tiff;base64,", string.Empty);
                                            byte[] bytes = Convert.FromBase64String(itemVariable.Valor);
                                            dataContratoParrafoVariable.ValorImagen = bytes;
                                        }
                                        dataContratoParrafoVariable.ValorTexto = null;
                                        dataContratoParrafoVariable.ValorNumeroString = null;
                                        dataContratoParrafoVariable.ValorFechaString = null;
                                        dataContratoParrafoVariable.ValorTabla = null;
                                        dataContratoParrafoVariable.ValorBien = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Tabla:
                                        dataContratoParrafoVariable.ValorTabla = itemVariable.Valor;
                                        dataContratoParrafoVariable.ValorTablaEditable = itemVariable.ValorEditable;
                                        dataContratoParrafoVariable.ValorTexto = null;
                                        dataContratoParrafoVariable.ValorNumeroString = null;
                                        dataContratoParrafoVariable.ValorFechaString = null;
                                        dataContratoParrafoVariable.ValorImagen = null;
                                        dataContratoParrafoVariable.ValorBien = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Bien:
                                        dataContratoParrafoVariable.ValorBien = itemVariable.Valor;
                                        dataContratoParrafoVariable.ValorBienEditable = itemVariable.ValorEditable;
                                        dataContratoParrafoVariable.ValorTexto = null;
                                        dataContratoParrafoVariable.ValorNumeroString = null;
                                        dataContratoParrafoVariable.ValorFechaString = null;
                                        dataContratoParrafoVariable.ValorImagen = null;
                                        dataContratoParrafoVariable.ValorTabla = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Firmante:
                                        dataContratoParrafoVariable.ValorFirmante = itemVariable.Valor;
                                        dataContratoParrafoVariable.ValorFirmanteEditable = itemVariable.ValorEditable;
                                        dataContratoParrafoVariable.ValorTexto = null;
                                        dataContratoParrafoVariable.ValorNumeroString = null;
                                        dataContratoParrafoVariable.ValorFechaString = null;
                                        dataContratoParrafoVariable.ValorImagen = null;
                                        dataContratoParrafoVariable.ValorTabla = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Lista:
                                        dataContratoParrafoVariable.ValorLista = itemVariable.Valor;
                                        dataContratoParrafoVariable.ValorNumeroString = null;
                                        dataContratoParrafoVariable.ValorTexto = null;
                                        dataContratoParrafoVariable.ValorFechaString = null;
                                        dataContratoParrafoVariable.ValorImagen = null;
                                        dataContratoParrafoVariable.ValorTabla = null;
                                        break;
                                    default:
                                        dataContratoParrafoVariable.ValorTexto = null;
                                        dataContratoParrafoVariable.ValorNumeroString = null;
                                        dataContratoParrafoVariable.ValorFechaString = null;
                                        dataContratoParrafoVariable.ValorImagen = null;
                                        dataContratoParrafoVariable.ValorTabla = null;
                                        dataContratoParrafoVariable.ValorBien = null;
                                        break;
                                }

                                var dataContratoParrafoVariableEntity = ContratoParrafoVariableAdapter.RegistrarContratoParrafoVariable(dataContratoParrafoVariable);
                                entidadContratoParrafoVariable.Add(dataContratoParrafoVariableEntity);
                                if (itemVariable.CodigoTipoVariable == DatosConstantes.TipoVariable.Firmante)
                                {
                                    if (dataContrato.ListaContratoFirmante != null)
                                    {
                                        foreach (var firm in dataContrato.ListaContratoFirmante)
                                        {
                                            dataContratoFirmante.CodigoContratoParrafoVariable = dataContratoParrafoVariableEntity.CodigoContratoParrafoVariable.ToString();
                                            dataContratoFirmante.NombreFirmante = firm.NombreFirmante;
                                            dataContratoFirmante.DatoAdicional = firm.DatoAdicional;
                                            entidadContratoFirmante.Add(ContratoFirmanteAdapter.RegistrarContratoFirmante(dataContratoFirmante));
                                        }
                                    }
                                }
                            }
                        }
                    }

                    dataContratoBien.CodigoContrato = entidadContrato.CodigoContrato.ToString();
                    //INICIO: Agregado por Julio Carrera - Norma Contable
                    //if (dataContrato.ListaCodigoBien != null)
                    //{
                    //    foreach (var codigo in dataContrato.ListaCodigoBien)
                    //    {
                    //        dataContratoBien.CodigoBien = codigo;
                    //        entidadContratoBien.Add(ContratoBienAdapter.RegistrarContratoBien(dataContratoBien));
                    //    }
                    //}
                    if (dataContrato.ListaBienes != null)
                    {
                        foreach (var bien in dataContrato.ListaBienes)
                        {
                            dataContratoBien.CodigoBien = bien.CodigoBien.ToString();
                            dataContratoBien.TipoTarifa = bien.CodigoTipoTarifa;
                            dataContratoBien.TipoPeriodo = bien.CodigoPeriodoAlquiler;
                            dataContratoBien.HorasMinimas = bien.HorasMinimas;
                            dataContratoBien.Tarifa = bien.Tarifa;
                            dataContratoBien.MayorMenor = bien.MayorMenor;
                            entidadContratoBien.Add(ContratoBienAdapter.RegistrarContratoBien(dataContratoBien));
                        }
                    }
                    //FIN: Agregado por Julio Carrera - Norma Contable

                    int resultadoContratoDocumento = 0;
                    int resultadoContratoParrafo = 0;
                    int resultadoContratoParrafoVariable = 0;
                    int resultadoContratoBienVariable = 0;

                    using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                    {
                        try
                        {
                            contratoParrafoEntityRepository.EliminarContenidoContrato(new Guid(dataContrato.CodigoContrato));

                            if (dataContrato.TipoRegistro == DatosConstantes.TipoRegistro.Total)
                            {
                                resultadoContratoDocumento = contratoDocumentoEntityRepository.RegistrarContratoDocumento(entidadContratoDocumento);
                            }
                            else
                            {
                                resultadoContratoDocumento = 1;
                            }

                            if (resultadoContratoDocumento == 1)
                            {
                                resultado.Result = 1;

                                foreach (var entidad in entidadContratoParrafo)
                                {
                                    resultadoContratoParrafo = contratoParrafoEntityRepository.RegistrarContratoParrafo(entidad);
                                }

                                if (entidadContratoParrafoVariable.Count > 0)
                                {
                                    if (resultadoContratoParrafo == 1)
                                    {
                                        resultado.Result = 1;
                                        foreach (var entidad in entidadContratoParrafoVariable)
                                        {
                                            resultadoContratoParrafoVariable = contratoParrafoVariableEntityRepository.RegistrarContratoParrafoVariable(entidad);
                                        }

                                        //Inicio - Registrar Contrato Bien
                                        if (resultadoContratoParrafoVariable == 1)
                                        {
                                            resultado.Result = 1;

                                            foreach (var entidad in entidadContratoBien)
                                            {
                                                resultadoContratoBienVariable = contratoBienEntityRepository.RegistrarContratoBien(entidad);
                                            }

                                            if (entidadContratoFirmante != null && entidadContratoFirmante.Count > 0)
                                            {
                                                foreach (var item in entidadContratoFirmante)
                                                {
                                                    contratoFirmanteEntityRepository.Insertar(item);
                                                    contratoFirmanteEntityRepository.GuardarCambios();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            resultado.Result = 0;
                                            throw new Exception();
                                        }
                                    }
                                    else
                                    {
                                        resultado.Result = 0;
                                        throw new Exception();
                                    }
                                }
                            }
                            else
                            {
                                resultado.Result = 0;
                                throw new Exception();
                            }
                            scope.Complete();
                        }
                        catch (Exception ex)
                        {
                            LogBL.grabarLogError(ex);
                            resultado.IsSuccess = false;
                            scope.Dispose();
                        }
                    }

                    if (resultadoContratoParrafoVariable == 1 && dataContrato.TipoRegistro == DatosConstantes.TipoRegistro.Total)
                    {
                        //Registro de Número de Contrato
                        contratoEntityRepository.EditarContrato(new ContratoEntity()
                        {
                            CodigoContrato = entidadContrato.CodigoContrato.Value,
                            CodigoEstado = entidadContrato.CodigoEstado,
                            CodigoEstadoEdicion = entidadContrato.CodigoEstadoEdicion,
                            NumeroContrato = numeroContrato,
                            ComentarioModificacion = entidadContrato.ComentarioModificacion,
                            UsuarioModificacion = entornoActualAplicacion.UsuarioSession,
                            FechaModificacion = DateTime.Now,
                            TerminalModificacion = entornoActualAplicacion.Terminal,
                            EsFlexible = codigoFormaEdicion == DatosConstantes.FormaEdicion.Flexible ? true : false
                        });

                        if (!dataContrato.IndicadorSolicitarModificacion)
                        {
                            var contratoEstadio = contratoLogicRepository.ListarContratoEstadio(null, entidadContrato.CodigoContrato.Value).Where(item => item.CodigoEstadoContratoEstadio == DatosConstantes.CodigoEstadoContratoEstadio.Iniciado).OrderBy(item => item.FechaIngreso).LastOrDefault();
                            ApruebaContratoEstadio(entidadContrato.CodigoContrato.Value, contratoEstadio.CodigoContratoEstadio, "");
                        }
                    }
                    #endregion
                }
                else
                {
                    resultado.Result = 3;
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
        /// Registra el documento del contrato de adhesión
        /// </summary>
        /// <param name="dataContrato">Datos a registrar de Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarListadoContratoAdhesion(ContratoRequest dataContrato)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            //ContratoEstadioRequest dataContratoEstadio = new ContratoEstadioRequest();
            UnidadOperativaResponse unidadOperativa = null;
            string nombreFile, lsDirectorioDestino, listName, folderName, hayError = string.Empty;

            try
            {
                var entidadContrato = ObtieneContratoPorID(new Guid(dataContrato.CodigoContrato)).Result;

                entidadContrato.IndicadorVersionOficial = false;

                //Generando contrato documento
                dataContrato.ContratoDocumento.CodigoContrato = dataContrato.CodigoContrato;
                dataContrato.ContratoDocumento.CodigoArchivo = 0;
                dataContrato.ContratoDocumento.RutaArchivoSharePoint = "";
                dataContrato.ContratoDocumento.IndicadorActual = true;
                dataContrato.ContratoDocumento.Version = 1;
                ContratoDocumentoEntity entidadContratoDocumento = ContratoDocumentoAdapter.RegistrarContratoDocumento(dataContrato.ContratoDocumento);

                entidadContrato.CodigoEstado = DatosConstantes.EstadoContrato.Aprobacion;
                entidadContrato.CodigoEstadoEdicion = null;

                /*Registramos información del SharePoint*/
                unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = entidadContrato.CodigoUnidadOperativa.ToString() }).Result.FirstOrDefault();
                #region InformacionRepositorioSharePoint
                nombreFile = string.Format("{0}.{1}", entidadContratoDocumento.CodigoContratoDocumento.ToString(), dataContrato.ContratoDocumento.ExtencionArchivo);
                ProcessResult<string> miDirectorio = RetornaDirectorioFile(new Guid(dataContrato.CodigoContrato), unidadOperativa.Nombre, nombreFile, dataContrato.FechaInicioVigencia);
                lsDirectorioDestino = miDirectorio.Result.ToString();
                string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });
                listName = nivelCarpeta[0];
                folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                #endregion

                #region GrabarContenidoContratoSHP
                MemoryStream msFile = new MemoryStream(dataContrato.ContratoDocumento.Documento);
                if (msFile != null)
                {
                    var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, nombreFile, msFile);
                    if (Convert.ToInt32(regSHP.Result) > 0 && hayError == string.Empty)
                    {
                        entidadContratoDocumento.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                        entidadContratoDocumento.RutaArchivoSharePoint = lsDirectorioDestino;
                    }
                    else
                    {
                        if (Convert.ToInt32(regSHP.Result) > 0)
                        {
                            var fileShpDelete = sharePointService.EliminaArchivoSharePoint(new List<int>() { Convert.ToInt32(regSHP.Result) }, listName, ref hayError);
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
                    resultado.Exception = new ApplicationLayerException<ContratoService>("El documento presenta errores.");
                    LogBL.grabarLogError(new Exception("El documento presenta errores."));
                }

                #endregion

                int resultadoContratoDocumento = 0;
                using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    try
                    {
                        contratoParrafoEntityRepository.EliminarContenidoContrato(new Guid(dataContrato.CodigoContrato));//AUMENTANDO PARA QUE SALGA VERSION CORRECTA
                        resultadoContratoDocumento = contratoDocumentoEntityRepository.RegistrarContratoDocumento(entidadContratoDocumento);

                        if (resultadoContratoDocumento == 1)
                        {
                            resultado.Result = 1;
                        }
                        else
                        {
                            resultado.Result = 0;
                            throw new Exception();
                        }

                        scope.Complete();
                    }
                    catch (Exception ex)
                    {
                        LogBL.grabarLogError(ex);
                        resultado.IsSuccess = false;
                        scope.Dispose();
                    }
                }

                var tipoRequerimiento = politicaService.ListarTipoServicioDinamico().Result.Where(p => p.Atributo1 == entidadContrato.CodigoTipoRequerimiento).FirstOrDefault();

                //Registro de Número de Contrato(prueba)
                string numeroContrato = string.IsNullOrEmpty(entidadContrato.NumeroContrato) ? GenerarNumeroContrato(unidadOperativa, tipoRequerimiento.Atributo1, tipoRequerimiento.Atributo4, entidadContrato.CodigoTipoDocumento) : entidadContrato.NumeroContrato;
                //string numeroContrato = GenerarNumeroContrato(unidadOperativa, tipoRequerimiento.Atributo1, tipoRequerimiento.Atributo4, entidadContrato.CodigoTipoDocumento);

                contratoEntityRepository.EditarContrato(new ContratoEntity()
                {
                    CodigoContrato = entidadContrato.CodigoContrato.Value,
                    CodigoEstado = entidadContrato.CodigoEstado,
                    CodigoEstadoEdicion = entidadContrato.CodigoEstadoEdicion,
                    NumeroContrato = entidadContrato.CodigoTipoDocumento == DatosConstantes.TipoDocumento.Adenda ? entidadContrato.NumeroContrato : numeroContrato,
                    ComentarioModificacion = entidadContrato.ComentarioModificacion,
                    UsuarioModificacion = entornoActualAplicacion.UsuarioSession,
                    FechaModificacion = DateTime.Now,
                    TerminalModificacion = entornoActualAplicacion.Terminal
                });

                var contratoEstadio = contratoLogicRepository.ListarContratoEstadio(null, entidadContrato.CodigoContrato.Value).Where(item => item.CodigoEstadoContratoEstadio == DatosConstantes.CodigoEstadoContratoEstadio.Iniciado).OrderBy(item => item.FechaIngreso).LastOrDefault();
                ApruebaContratoEstadio(entidadContrato.CodigoContrato.Value, contratoEstadio.CodigoContratoEstadio, "");
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
        /// Realiza la búsqueda de listado contratos principales
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de contratos</returns>
        public ProcessResult<List<ListadoContratoResponse>> ListadoContratoPrincipal(ListadoContratoRequest filtro)
        {
            ProcessResult<List<ListadoContratoResponse>> resultado = new ProcessResult<List<ListadoContratoResponse>>();
            try
            {
                List<ListadoContratoLogic> listado = listadoContratoLogicRepository.ListadoContratoPrincipal(filtro.NumeroContrato, filtro.Descripcion, filtro.TipoServicioLC);
                resultado.Result = new List<ListadoContratoResponse>();
                foreach (var registro in listado)
                {
                    var listadoContrato = ListadoContratoAdapter.ObtenerListadoContratoPaginado(registro);
                    resultado.Result.Add(listadoContrato);
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
        /// Eliminar Contrato
        /// </summary>
        /// <param name="listaCodigoContrato">Lista de Códigos de Contrato a Eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> EliminarListadoContrato(List<object> listaCodigoContrato)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            try
            {
                foreach (var codigo in listaCodigoContrato)
                {
                    var llaveEntidad = new Guid(codigo.ToString());
                    contratoEntityRepository.EliminarEntorno(entornoActualAplicacion, llaveEntidad);
                }

                resultado.Result = contratoEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Actualizar Contrato
        /// </summary>
        /// <param name="CodigoContrato">Códigos de Contrato a Actualizar</param>
        /// <param name="TipoContrato"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> ActualizarContrato(Guid CodigoContrato, string TipoContrato)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            try
            {

                //var llaveEntidad = new Guid(listaCodigoContrato.CodigoContrato.ToString());
                ContratoEntity lista = new ContratoEntity();
                var entidadSincronizar = contratoEntityRepository.GetById(CodigoContrato);
                //lista.CodigoContrato = CodigoContrato;
                entidadSincronizar.CodigoTipoServicio = TipoContrato;
                contratoEntityRepository.EditarContrato(entidadSincronizar);
                resultado.Result = contratoEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Obtiene el Monto Acumulado del Contrato Principal más sus Adendas
        /// </summary>
        /// <param name="codigoContratoPrincipal">Código de Contrato Principal</param>
        /// <returns>Registro con el Monto Acumulado del Contrato Principal más sus Adendas</returns>
        public ProcessResult<List<ListadoContratoResponse>> ObtenerMontoAcumuladoContrato(string codigoContratoPrincipal)
        {
            ProcessResult<List<ListadoContratoResponse>> resultado = new ProcessResult<List<ListadoContratoResponse>>();
            try
            {
                List<ListadoContratoLogic> listado = listadoContratoLogicRepository.ObtenerMontoAcumuladoContrato(new Guid(codigoContratoPrincipal));
                resultado.Result = new List<ListadoContratoResponse>();

                foreach (var registro in listado)
                {
                    var listadoContratoResponse = new ListadoContratoResponse();
                    listadoContratoResponse.MontoAcumulado = registro.MontoAcumulado;
                    resultado.Result.Add(listadoContratoResponse);
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
        /// Obtiene listado de variables de los parrafos de  un contrato
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato</param>
        /// <returns>Lista de variables de parrafos de contrato</returns>
        public ProcessResult<List<ContratoParrafoVariableResponse>> ObtenerVariablesContratoParrafo(string codigoContrato)
        {
            ProcessResult<List<ContratoParrafoVariableResponse>> resultado = new ProcessResult<List<ContratoParrafoVariableResponse>>();
            try
            {
                List<ContratoParrafoVariableLogic> listado = listadoContratoLogicRepository.ObtenerVariablesContratoParrafo(new Guid(codigoContrato));

                resultado.Result = new List<ContratoParrafoVariableResponse>();

                foreach (var registro in listado)
                {
                    var contratoParrafoVariable = ListadoContratoAdapter.ObtenerContratoParrafoVariable(registro);

                    if (contratoParrafoVariable.CodigoTipo == DatosConstantes.TipoVariable.Bien)
                    {
                        contratoParrafoVariable.ListaContratoBien = new List<ContratoBienResponse>();

                        var ListaContratoBienLogic = listadoContratoLogicRepository.ObtenerBienesContrato(new Guid(codigoContrato));

                        foreach (var item in ListaContratoBienLogic)
                        {
                            var contratoBien = ListadoContratoAdapter.ObtenerContratoBienResponse(item);
                            contratoParrafoVariable.ListaContratoBien.Add(contratoBien);
                        }
                    }
                    else if (contratoParrafoVariable.CodigoTipo == DatosConstantes.TipoVariable.Firmante)
                    {
                        contratoParrafoVariable.ListaContratoFirmante = new List<ContratoFirmanteResponse>();

                        var ListaContratoFirmanteLogic = listadoContratoLogicRepository.ObtenerFirmantesContrato(new Guid(codigoContrato));

                        foreach (var item in ListaContratoFirmanteLogic)
                        {
                            var contratoFirmante = ListadoContratoAdapter.ObtenerContratoFirmanteResponse(item);
                            contratoParrafoVariable.ListaContratoFirmante.Add(contratoFirmante);
                        }
                    }
                    resultado.Result.Add(contratoParrafoVariable);
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
        /// Eliminar Contrato
        /// </summary>
        /// <param name="filtro">Datos del contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<string> EliminarContrato(ListadoContratoRequest filtro)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                resultado.Result = listadoContratoLogicRepository.EliminarContrato(new Guid(filtro.CodigoContrato), filtro.ComentarioModificacion, entornoActualAplicacion.UsuarioSession, entornoActualAplicacion.Terminal).ToString();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Registrar la copia de un contrato
        /// </summary>
        /// <param name="dataContrato">Datos del Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarCopiaContrato(ContratoRequest dataContrato)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();

            try
            {
                dataContrato.IndicadorVersionOficial = false;

                if (dataContrato.CodigoTipoDocumento == "C")
                {
                    dataContrato.MontoAcumuladoString = dataContrato.MontoContratoString;
                }

                var esAdendaContratoVencido = false;

                if (dataContrato.CodigoTipoDocumento == DatosConstantes.TipoDocumento.Adenda)
                {
                    var entidadContratoPrincipal = ObtieneContratoPorID(new Guid(dataContrato.CodigoContratoPrincipal.ToString())).Result;

                    var listaAdendas = listadoContratoLogicRepository.BuscarContrato(null, dataContrato.CodigoContratoPrincipal, string.Empty, string.Empty, dataContrato.CodigoTipoDocumento, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty).OrderByDescending(a => a.NumeroAdenda).FirstOrDefault();
                    dataContrato.NumeroAdenda = (listaAdendas == null) ? 1 : listaAdendas.NumeroAdenda + 1;

                    dataContrato.NumeroAdendaConcatenado = string.Format(DatosConstantes.Formato.FormatoNumeroAdenda, entidadContratoPrincipal.NumeroContrato, dataContrato.NumeroAdenda);
                    dataContrato.NumeroContrato = entidadContratoPrincipal.NumeroContrato;

                    if (listaAdendas != null && listaAdendas.CodigoEstadoContrato != DatosConstantes.EstadoContrato.Vigente)
                    {
                        resultado.IsSuccess = false;
                        resultado.Exception = new ApplicationLayerException<ContratoService>("La Adenda N° " + listaAdendas.NumeroAdendaConcatenado + " no se encuentra en estado Vigente");
                        return resultado;
                    }

                    if (entidadContratoPrincipal.CodigoEstado == DatosConstantes.EstadoContrato.Vencido && dataContrato.CodigoTipoRequerimiento != DatosConstantes.TipoServicio.ContratoHistorico)
                    {
                        var diasParametro = parametroValorService.BuscarParametroValor(new ParametroValorRequest()
                        {
                            CodigoParametro = DatosConstantes.ParametroValor.DiasGeneracionAdendaVencido,
                            CodigoSeccion = 1,
                            CodigoValor = 1,
                            EstadoRegistro = "1"
                        }).Result.FirstOrDefault();

                        if (diasParametro != null)
                        {
                            DateTime fechaInicio = (DateTime)entidadContratoPrincipal.FechaFinVigencia;
                            DateTime fechaFin = DateTime.Today;
                            TimeSpan diferencia = (fechaFin - fechaInicio);

                            var diasContrato = diferencia.Days;

                            int valorDiasParametro = 0;
                            bool validaDiasParametro = int.TryParse(diasParametro.Valor, out valorDiasParametro);

                            if (validaDiasParametro && diasContrato > valorDiasParametro)
                            {
                                resultado.IsSuccess = false;
                                resultado.Exception = new ApplicationLayerException<ContratoService>(string.Format("La adenda supera los {0} días del período de gracia.", valorDiasParametro));
                                return resultado;
                            }
                            else
                            {
                                esAdendaContratoVencido = true;
                            }
                        }
                    }

                }

                dataContrato.CodigoEstado = DatosConstantes.EstadoContrato.Edicion;
                dataContrato.CodigoEstadoEdicion = DatosConstantes.CodigoEstadoEdicion.EdicionParcial;

                //Asignación de Plantilla                
                var resultadoPlantilla = plantillaService.BuscarPlantilla(new PlantillaRequest()
                {
                    CodigoTipoContrato = dataContrato.CodigoTipoServicio,
                    CodigoTipoDocumentoContrato = dataContrato.CodigoTipoDocumento,
                    IndicadorAdhesion = dataContrato.IndicadorAdhesion,
                    CodigoEstadoVigencia = DatosConstantes.EstadoVigencia.Vigente
                }).Result.FirstOrDefault();

                if (resultadoPlantilla != null)
                {
                    dataContrato.CodigoPlantilla = resultadoPlantilla.CodigoPlantilla;
                    if (dataContrato.EsFlexible.Value && dataContrato.CodigoTipoDocumento != DatosConstantes.TipoDocumento.Adenda)
                    {
                        var tipoRequerimiento = politicaService.ListarTipoServicioDinamico().Result.Where(p => p.Atributo1 == dataContrato.CodigoTipoRequerimiento).FirstOrDefault();
                        UnidadOperativaResponse unidadOperativa = null;
                        unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = dataContrato.CodigoUnidadOperativa.ToString() }).Result.FirstOrDefault();
                        string numeroContrato = GenerarNumeroContrato(unidadOperativa, tipoRequerimiento.Atributo1, tipoRequerimiento.Atributo4, dataContrato.CodigoTipoDocumento);
                        dataContrato.NumeroContrato = numeroContrato;
                        dataContrato.CodigoEstado = "E";
                        dataContrato.CodigoEstadoEdicion = "EP";
                    }

                    ContratoEntity entidadContrato = ListadoContratoAdapter.RegistrarCopiaContrato(dataContrato);

                    var resultadoContrato = contratoEntityRepository.RegistrarContrato(entidadContrato);

                    if (resultadoContrato != 0)
                    {
                        if (dataContrato.EsFlexible.Value)
                        {
                            var doctos = DocumentosPorContrato(entidadContrato.CodigoContratoOriginal.Value);
                            if (doctos.Result != null && doctos.Result.Count > 0)
                            {
                                var contenido = doctos.Result[0];
                                ContratoDocumentoEntity entidadContratoDocumento = new ContratoDocumentoEntity();
                                entidadContratoDocumento.CodigoContratoDocumento = Guid.NewGuid();
                                entidadContratoDocumento.CodigoContrato = entidadContrato.CodigoContrato;
                                entidadContratoDocumento.CodigoArchivo = 0;
                                entidadContratoDocumento.RutaArchivoSharePoint = string.Empty;
                                entidadContratoDocumento.Contenido = contenido.Contenido;
                                entidadContratoDocumento.ContenidoBusqueda = string.Empty;
                                entidadContratoDocumento.IndicadorActual = true;
                                entidadContratoDocumento.Version = 1;
                                entidadContratoDocumento.FechaCreacion = DateTime.Now;
                                contratoDocumentoEntityRepository.RegistrarContratoDocumento(entidadContratoDocumento);
                            }
                        }
                        //Registro de Contrato Estadio
                        ContratoEstadioRequest dataContratoEstadio = new ContratoEstadioRequest();

                        var resultadoFlujoAprobacionEstadio = flujoAprobacionService.BuscarBandejaFlujoAprobacionEstadio(null, dataContrato.CodigoFlujoAprobacion)
                                                              .Result.OrderBy(x => x.Orden).FirstOrDefault();

                        if (resultadoFlujoAprobacionEstadio != null)
                        {
                            entidadContrato.CodigoEstadioActual = new Guid(resultadoFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio);
                        }

                        dataContratoEstadio.CodigoFlujoAprobacionEstadio = new Guid(resultadoFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio);
                        dataContratoEstadio.CodigoContrato = entidadContrato.CodigoContrato;
                        dataContratoEstadio.FechaIngreso = DateTime.Now.Date;

                        if (resultadoFlujoAprobacionEstadio.CodigoResponsable == null)
                        {
                            dataContratoEstadio.CodigoResponsable = null;
                        }
                        else
                        {
                            dataContratoEstadio.CodigoResponsable = Guid.Parse(resultadoFlujoAprobacionEstadio.CodigoResponsable);
                        }

                        dataContratoEstadio.CodigoEstadoContratoEstadio = DatosConstantes.CodigoEstadoContratoEstadio.Iniciado;
                        ContratoEstadioEntity entidadContratoEstadio = ContratoEstadioAdapter.RegistrarContratoEstadio(dataContratoEstadio);
                        contratoEstadioEntityRepository.RegistrarContratoEstadio(entidadContratoEstadio);

                        //Registrar adendas de contrato vencido en tabla temporal para notificación (envio de correo)
                        if (esAdendaContratoVencido == true)
                        {
                            contratoLogicRepository.RegistraAdendaContratoVencido((Guid)dataContrato.CodigoUnidadOperativa, dataContrato.NumeroContrato, dataContrato.Descripcion, dataContrato.NumeroAdenda, dataContrato.NumeroAdendaConcatenado);
                        }

                        resultado.IsSuccess = true;
                        resultado.Result = entidadContrato.CodigoContrato;
                    }
                    else
                    {
                        throw new Exception(string.Empty);
                    }
                }
                else
                {
                    throw new Exception("No se encontró ninguna plantilla asociada.");
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(e.Message);
            }
            return resultado;
        }

        /// <summary>
        /// Método para recuperar los registros ordenados de la bandeja de proceso.
        /// </summary>
        /// <param name="filtro">Objeto Contrato Request</param>
        /// <param name="lstTipoContrato">Lista de Tipos de Servicio</param>
        /// <param name="lstTipoServicio">Lista de Tipo de Requerimiento</param>
        /// <returns>Registros de bandeja de procesos</returns>                
        public ProcessResult<List<ContratoResponse>> BuscarBandejaProcesosContratoOrdenado(ContratoRequest filtro, List<CodigoValorResponse> lstTipoContrato = null, List<CodigoValorResponse> lstTipoServicio = null)
        {
            ProcessResult<List<ContratoLogic>> listaRegistros = new ProcessResult<List<ContratoLogic>>();
            ProcessResult<List<ContratoResponse>> rpta = new ProcessResult<List<ContratoResponse>>();
            List<CodigoValorResponse> listaTipoServicio;
            List<CodigoValorResponse> listaTipoRequerimiento;
            ContratoResponse itemRpta;
            try
            {
                if (lstTipoContrato != null)
                {
                    listaTipoServicio = lstTipoContrato;
                }
                else
                {
                    listaTipoServicio = politicaService.ListarTipoContrato().Result;
                }
                if (lstTipoServicio != null)
                {
                    listaTipoRequerimiento = lstTipoServicio;
                }
                else
                {
                    listaTipoRequerimiento = politicaService.ListarTipoServicio().Result;
                }

                var listaUO = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa());

                listaRegistros.Result = contratoLogicRepository.ListaBandejaContratosOrdenado(
                    (Guid)filtro.CodigoResponsable,
                    filtro.CodigoUnidadOperativa,
                    filtro.NombreProveedor,
                    filtro.NumeroDocProveedor,
                    filtro.CodigoTipoServicio,
                    filtro.CodigoTipoRequerimiento,
                    filtro.NombreEstadio,
                    filtro.IndicadorFinalizarAprobacion,
                    filtro.ColumnaOrden,
                    filtro.TipoOrden,
                    filtro.NumeroPagina,
                    filtro.RegistrosPagina
                    );

                rpta.Result = new List<ContratoResponse>();
                foreach (ContratoLogic itemLogic in listaRegistros.Result)
                {
                    itemRpta = new ContratoResponse();
                    itemRpta = ContratoAdapter.ObtenerContratoResponseDeLogic(itemLogic, listaUO.Result, listaTipoServicio, listaTipoRequerimiento);
                    rpta.Result.Add(itemRpta);
                }

            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Permite generar un pdf desde un html
        /// </summary>
        /// <param name="htmlCuerpo">script de html</param>
        /// <param name="htmlPie">script de html del pie de pagina</param>
        /// <param name="htmlCabecera">Cabecera de PDF</param>
        /// <param name="codigoContrato">Código de contrato</param>
        /// <param name="codigoPlantilla"></param>
        /// <param name="linksRef">links de referencia</param>
        /// <param name="listaFirmantesSGC">Listado de firmantes</param>
        /// <param name="listaResponsables">Listado de responsables</param>
        /// <param name="indicadorHtml">Indicador si cuerpo va a ser parseado como Html</param>
        /// <param name="urlLogo">Url logo</param>
        /// <param name="widthLogo">Ancho de logo</param>
        /// <param name="heightLogo">Alto de logo</param>
        /// <returns>Pdf en un arreglo de bytes</returns>
        public byte[] GenerarPdfDesdeHtml(string htmlCuerpo,
                                          string htmlPie,
                                          string htmlCabecera,
                                          Guid? codigoContrato,
                                          Guid? codigoPlantilla,
                                          List<TrabajadorResponse> listaFirmantesSGC,
                                          List<string> listaResponsables = null,
                                          string linksRef = null,
                                          bool indicadorHtml = false,
                                          string urlLogo = "",
                                          int widthLogo = 0,
                                          int heightLogo = 0)
        {
            var arregloByte = new byte[0];
            var visto = "";

            try
            {
                if (listaFirmantesSGC != null && listaFirmantesSGC.Count > 0)
                {
                    //Seteamos el valor del primer representante
                    htmlCuerpo = htmlCuerpo.Replace(DatosConstantes.IdentificadorVariableDefecto.PrimerRepresentanteEmpresa, listaFirmantesSGC[0].NombreCompleto);
                    htmlCuerpo = htmlCuerpo.Replace(DatosConstantes.IdentificadorVariableDefecto.DniPrimerRepresentanteEmpresa, listaFirmantesSGC[0].DescripcionTipoDocumentoIdentidad + " N° " + listaFirmantesSGC[0].NumeroDocumentoIdentidad);

                    //Seteamos el valor del segundo representante
                    htmlCuerpo = htmlCuerpo.Replace(DatosConstantes.IdentificadorVariableDefecto.SegundoRepresentanteEmpresa, listaFirmantesSGC[1].NombreCompleto);
                    htmlCuerpo = htmlCuerpo.Replace(DatosConstantes.IdentificadorVariableDefecto.DniSegundoRepresentanteEmpresa, listaFirmantesSGC[1].DescripcionTipoDocumentoIdentidad + " N° " + listaFirmantesSGC[1].NumeroDocumentoIdentidad);

                    if (listaResponsables != null)
                    {
                        if (listaResponsables.Count > 0)
                        {
                            var html_Visto = "<p><strong><span style='color:#A9A9A9'><span style='font-size:11px'><span style='font-family:arial,helvetica,sans-serif'>Revisado Por:<br>{0}</span></span></span></strong></p>";
                            for (int i = 0; i < listaResponsables.Count; i++)
                            {
                                visto = visto + "   " + listaResponsables[i];
                            }

                            htmlCuerpo = htmlCuerpo.Replace(DatosConstantes.IdentificadorVariableDefecto.vistos, string.Format(html_Visto, visto));
                        }
                    }

                    var formatoFirma = "<div style='width:100%; margin: auto;text-align: center; padding:120px 0px 0px 0px;font-family:arial,helvetica,sans-serif;font-size:11px'><p><b>..................................................</b></p><p style='margin: auto;font-family:arial,helvetica,sans-serif'>{0}</p></br><p style='margin: auto;font-family:arial,helvetica,sans-serif'>{1}</p></div>";

                    var firmas = "<table style='width:100%'>" +
                        "<tr><td style='width:50%'>" + string.Format(formatoFirma, listaFirmantesSGC[0].NombreCompleto, DatosConstantes.Recursos.RepresentanteLegal) + "</td>" +
                        "<td style='width:50%'>" + string.Format(formatoFirma, listaFirmantesSGC[1].NombreCompleto, DatosConstantes.Recursos.RepresentanteLegal) + "</td></tr>" +
                        "</table>";

                    htmlCuerpo = htmlCuerpo.Replace(DatosConstantes.IdentificadorVariableDefecto.FirmaSGC, firmas);

                }

                //htmlCuerpo = "<table style='width:100%'><tr><td style='width:50%'><div style='width:100%; margin: auto;text-align: center; padding:120px 0px 0px 0px;font-family:arial,helvetica,sans-serif;font-size:11px'><p><b>..................................................</b></p><p style='margin: auto;font-family:arial,helvetica,sans-serif'>John Tamayo Ortega</p><br></br><p style='margin: auto;font-family:arial,helvetica,sans-serif'>Representante Legal</p></div></td><td style='width:50%'><div style='width:100%; margin: auto;text-align: center; padding:120px 0px 0px 0px;font-family:arial,helvetica,sans-serif;font-size:11px'><p><b>..................................................</b></p><p style='margin: auto;font-family:arial,helvetica,sans-serif'>José Luis Del Corral Delgado</p><br></br><p style='margin: auto;font-family:arial,helvetica,sans-serif'>Representante Legal</p></div></td></tr></table></strong></span></span></p>\r\n\r\n<p style=\"text-align:center\">&nbsp;</p>\r\n\r\n<p style=\"text-align:center\"><span style=\"font-size:11px\"><span style=\"font-family:arial,helvetica,sans-serif\"><strong>EL ARRENDADOR</strong></span></span></p>\r\n\r\n<p style=\"text-align:center\"><span style=\"font-size:11px\"><span style=\"font-family:arial,helvetica,sans-serif\"><strong></strong></span></span></p><br></br><table style=\"width:100%\" class=\"firmanteContratoParrafo\" codigovariable=\"a7f0febd-502c-4bc6-bbee-bd20ad3ba379\" indicadorparrafo=\"7\" codigoplantillaparrafo=\"961c8079-da2a-4a4b-a87d-233e9dda18be\"> <tbody><tr><td style=\"width:50%\"><div style=\"width:100%; margin: auto;text-align: center; padding:120px 0px 0px 0px;font-family:arial,helvetica,sans-serif;font-size:11px\"><p><b>..................................................</b></p><p style=\"margin: auto;font-family:arial,helvetica,sans-serif\">.\r\nPablo Bustamante Bellido</p><br></br><p style=\"margin: auto;font-family:arial,helvetica,sans-serif\">Representante Legal</p></div></td></tr></tbody></table><p></p>\r\n\r\n<p>&nbsp;</p>";

                htmlCuerpo = "<div>" + htmlCuerpo + "</div>";

                //Inicio - Validaciones
                htmlCuerpo = htmlCuerpo.Replace("<table", "<br></br><table");
                //Fin - Validaciones

                //tratamiento de imágenes.
                int posImg = 0, posFin = 0;
                string imgBase64 = string.Empty;
                posImg = htmlCuerpo.IndexOf("<img name");
                while (posImg > 0)
                {
                    posFin = htmlCuerpo.IndexOf("\">", posImg);
                    imgBase64 = htmlCuerpo.Substring(posImg, (posFin + 2) - posImg);
                    if (posFin > 0)
                    {
                        htmlCuerpo = htmlCuerpo.Replace(imgBase64, imgBase64 + "</img>");
                    }
                    posImg = htmlCuerpo.IndexOf("<img name", posFin);
                }
                //
                posImg = 0;
                posFin = 0;
                imgBase64 = string.Empty;
                posImg = htmlCuerpo.IndexOf("<img src");
                while (posImg > 0)
                {
                    posFin = htmlCuerpo.IndexOf(">", posImg);
                    imgBase64 = htmlCuerpo.Substring(posImg, posFin - posImg);
                    if (posFin > 0)
                    {
                        htmlCuerpo = htmlCuerpo.Replace(imgBase64, imgBase64 + "></img>");
                    }
                    posImg = htmlCuerpo.IndexOf("<img src", posFin);
                }

                htmlCuerpo = htmlCuerpo.Replace("</img></img>", "");
                htmlCuerpo = htmlCuerpo.Replace("</img>/>", "</img>");
                htmlCuerpo = htmlCuerpo.Replace("</img>>", "</img>");
                htmlCuerpo = htmlCuerpo.Replace("/></img>", "</img>");


                //Inicio - Validaciones
                htmlCuerpo = htmlCuerpo.Replace("<br><br><br>", "</br>");
                htmlCuerpo = htmlCuerpo.Replace("<br><br>", "</br>");
                //Fin - Validaciones

                htmlCuerpo = htmlCuerpo.Replace("<br></br>", "</br>");
                htmlCuerpo = htmlCuerpo.Replace("<br>", "</br>");
                htmlCuerpo = htmlCuerpo.Replace("</br>", "<br></br>");
                htmlCuerpo = htmlCuerpo.Replace("\r\n</table>", "<tr><td></td></tr></table>");
                htmlCuerpo = htmlCuerpo.Replace(" </table>", "<tr><td></td></tr></table>");

                

                using (var document = new Document(PageSize.A4, 71, 71, 70, 150))    //Margen 2.5 cm
                {

                    //htmlCuerpo = "<div><br></br><p style='text-align: center;'><u><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong>Primera Adenda al Contrato de Arrendamiento de Vehículo</strong></span></span></u></p><p style='text-align: center;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'>Conste por el presente documento la Adenda al Contrato de Arrendamiento de Vehículo (la “Adenda”) que suscriben:</span></span></p><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong>STRACON S.A.</strong> con domicilio en Calle Las Begonias 415</span>, Torre Begonias, piso 13, distrito de San Isidro, Lima</span>?,<span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'> identificado con RUC Nº 20546121250, debidamente representada por el/la señor(a) John Tamayo Ortega, identificado/a con&nbsp;DNI: 10550218, y por el/la señor(a) José Luis Del Corral Delgado, identificado(a) con DNI: 09340022, ambos debidamente facultados según poderes inscritos en la Partida Electrónica Nº 12760430 del Registro de Personas Jurídicas de Lima, a quien en adelante se le denominará (<strong>“STRACON ”</strong>); y,</span></span></p><br></br><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong>GENERAL HOUSE DE COMERCIO INDUSTRIAL S.A .C.</strong>, con domicilio en Ca. Bat. Independencia N° 397, Dpto 202, La Victoria, Lima, con RUC N° 20213447611, debidamente representada por el señor Grimaldo Quispe Palomino, identificado con DNI N° 21288939 según poder inscrito en la Partida Electrónica N° 11260542 del Registro de Personas Jurídicas de Lima,,&nbsp;a quien en adelante se le denominará (el <strong>Arrendamiento de Vehículo</strong>).</span></span></p><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong>STRACON </strong>y el Arrendamiento de Vehículo&nbsp;podrán ser denominados de manera conjunta como las “Partes” e individualmente como la “Parte”.</span></span></p><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'>Las Partes suscriben la presente Adenda en los siguientes términos:</span></span></p><br></br><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><u><strong>PRIMERA:</strong></u>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<u><strong>ANTECEDENTES</strong></u></span></span></p><br></br><table style='width: 100%; border-collapse: collapse;' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'>Con fecha 31/07/2019, las Partes suscribieron el Contrato de Arrendamiento de Vehículo&nbsp;(en adelante, el “Contrato”), mediante el cual el ARRENDADOR se obliga a ceder temporalmente a STRACON el uso de un vehículo.</span></span></td></tr></tbody></table><br></br><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><u><strong>SEGUNDA:</strong></u>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<strong><u>OBJETO DEL CONTRATO</u></strong></span></span></p><br></br><table style='width: 100%; border-collapse: collapse;' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'>Por medio de la presente Adenda, las Partes acuerdan ampliar la vigencia del contrato a partir del 01 de enero del 2019 al 30 de junio del 2019.</span></span></td></tr></tbody></table><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><u><strong>TERCERA:&nbsp;</strong></u>&nbsp; &nbsp;<u><strong>RATIFICACION</strong></u></span></span></p><br></br><table style='width: 100%; border-collapse: collapse;' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'>Las partes acuerdan ratificar las demás cláusulas del Contrato que no hayan sido modificados en tanto no se opongan a la presente adenda, manteniendo vigentes e inalterables las condiciones restantes.</span></span></td></tr></tbody></table><br></br><table style='width: 100%; border-collapse: collapse;' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'>En señal de conformidad las Partes suscriben la presente Adenda por duplicado con fecha 28/12/2018.</span></span></p></td></tr></tbody></table><p style='text-align: center;'>&nbsp;</p><p style='text-align: center;'>&nbsp;</p><p style='text-align: center;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong>STRACON S.A.</strong></span></span></p><p style='text-align: center;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong><br></br><table style='width:100%'><tr><td style='width:50%'><div style='width:100%; margin: auto;text-align: center; padding:120px 0px 0px 0px;font-family:arial,helvetica,sans-serif;font-size:11px'><p><b>..................................................</b></p><p style='margin: auto;font-family:arial,helvetica,sans-serif'>Administración Plataforma 2</p><br></br><p style='margin: auto;font-family:arial,helvetica,sans-serif'>Representante Legal</p></div></td><td style='width:50%'><div style='width:100%; margin: auto;text-align: center; padding:120px 0px 0px 0px;font-family:arial,helvetica,sans-serif;font-size:11px'><p><b>..................................................</b></p><p style='margin: auto;font-family:arial,helvetica,sans-serif'>Administración Plataforma 2</p><br></br><p style='margin: auto;font-family:arial,helvetica,sans-serif'>Representante Legal</p></div></td></tr></table></strong></span></span></p><p>&nbsp;</p><p style='text-align: center;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong>EL ARRENDADOR</strong></span></span></p><p style='text-align: center;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong></strong></span></span><br></br><table class='firmanteContratoParrafo' style='width: 100%;' codigovariable='a7f0febd-502c-4bc6-bbee-bd20ad3ba379' codigoplantillaparrafo='2af90f43-2580-449b-8955-1f12f16da8a3' indicadorparrafo='3'> <tbody><tr><td style='width: 50%;'><div style='margin: auto; padding: 120px 0px 0px; width: 100%; text-align: center; font-family: arial,helvetica,sans-serif; font-size: 11px;'><p><b>..................................................</b></p><p style='margin: auto; font-family: arial,helvetica,sans-serif;'>Grimaldo Quispe Palomino</p><br></br><p style='margin: auto; font-family: arial,helvetica,sans-serif;'>Representante Legal</p></div></td><td style='width: 50%;'><div style='margin: auto; padding: 120px 0px 0px; width: 100%; text-align: center; font-family: arial,helvetica,sans-serif; font-size: 11px;'><p><b>..................................................</b></p><p style='margin: auto; font-family: arial,helvetica,sans-serif;'></p><br></br><p style='margin: auto; font-family: arial,helvetica,sans-serif;'></p></div></td></tr></tbody></table><p></p></p></div>";

                    TextReader xmlString = new StringReader(htmlCuerpo);
                    var memoryStream = new MemoryStream();
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                    writer.PageEvent = new Header(htmlCabecera, urlLogo, widthLogo, heightLogo);

                    document.Open();
                    //Obtiene las fuentes instaladas
                    FontFactory.RegisterDirectories();

                    var tagProcessors = (DefaultTagProcessorFactory)Tags.GetHtmlTagProcessorFactory();
                    tagProcessors.RemoveProcessor(HTML.Tag.IMG);
                    tagProcessors.AddProcessor(HTML.Tag.IMG, new CustomImageTagProcessor());//usando el nuevo procesador de imagenes

                    var htmlContext = new HtmlPipelineContext(null);
                    htmlContext.CharSet(Encoding.UTF8);
                    htmlContext.SetAcceptUnknown(true).AutoBookmark(true);
                    htmlContext.SetTagFactory(tagProcessors);

                    XMLWorkerHelper xmlWorker = XMLWorkerHelper.GetInstance();
                    ICSSResolver cssResolver = xmlWorker.GetDefaultCssResolver(false);
                    //Usar css
                    if (!string.IsNullOrWhiteSpace(linksRef))
                    {
                        cssResolver.AddCssFile(linksRef, true);
                    }
                        
                    // Genera el pdf
                    IPipeline pipeline = new CssResolverPipeline(cssResolver, new HtmlPipeline(htmlContext, new PdfWriterPipeline(document, writer)));
                    var worker = new XMLWorker(pipeline, true);
                    var xmlParse = new XMLParser(true, worker);

                    xmlParse.Parse(xmlString);

                    xmlParse.Flush();
                    writer.Flush();

                    document.Close();
                    document.Dispose();
                    arregloByte = memoryStream.GetBuffer();

                }

                if (codigoPlantilla != null)
                {
                    //SE AGREGÓ listaResponsables
                    arregloByte = AgregarNotasPie(arregloByte, htmlPie, listaResponsables, (Guid)codigoPlantilla);
                    //arregloByte = AgregarNotasPie(arregloByte, htmlPie, null , (Guid)codigoPlantilla);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return arregloByte;
        }


        private byte[] AgregarNotasPie(byte[] pdf, string htmlPie, List<string> listaResponsables, Guid codigoPlantilla)
        {
            byte[] all;

            using (MemoryStream ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4, 71, 71, 70, 150);

                PdfWriter writer = PdfWriter.GetInstance(doc, ms);

                doc.Open();
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page;

                PdfReader reader;
                reader = new PdfReader(pdf);
                int pages = reader.NumberOfPages;

                var nota = new StringBuilder();

                for (int i = 1; i <= pages; i++)
                {
                    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                    string currentText = PdfTextExtractor.GetTextFromPage(reader, i, strategy);

                    nota = GenerarNotasPie(nota, currentText, codigoPlantilla);

                    writer.PageEvent = new Footer(htmlPie, listaResponsables, nota.ToString(), i);

                    if (!string.IsNullOrEmpty(nota.ToString()))
                    {
                        nota.Clear();
                    }

                    doc.SetPageSize(PageSize.A4);
                    doc.NewPage();
                    page = writer.GetImportedPage(reader, i);
                    cb.AddTemplate(page, 0, 0);
                }

                doc.Close();
                all = ms.GetBuffer();
                ms.Flush();
                ms.Dispose();
            }

            return all;
        }

        private StringBuilder GenerarNotasPie(StringBuilder nota, string currentText, Guid codigoPlantilla)
        {
            var notasPie = plantillaLogicRepository.BuscarNotasPiePorPlantilla(null, codigoPlantilla, 1, -1);

            foreach (var item in notasPie)
            {
                if (currentText.Contains(item.Titulo))
                {
                    nota.AppendLine(item.Contenido);
                }
            }
            return nota;
        }

        /// <summary>
        /// Clase Footer para documento PDF
        /// </summary>
        public partial class Footer : PdfPageEventHelper
        {
            /// <summary>
            /// Contenido
            /// </summary>
            public string contenido;
            /// <summary>
            /// Lista de Responsables
            /// </summary>
            public List<string> listaResponsables;

            /// <summary>
            /// notaPie
            /// </summary>
            public string notaPie;

            /// <summary>
            /// Pagina
            /// </summary>
            public int pagina;

            /// <summary>
            /// Constructor del Footer
            /// </summary>
            /// <param name="contenidoFooter">Contenido</param>
            /// <param name="listaResponsables">Lista de Responsables</param>            
            /// <param name="notaPie"></param>
            /// <param name="pagina"></param>
            public Footer(string contenidoFooter, List<string> listaResponsables, string notaPie, int pagina)
            {
                this.contenido = contenidoFooter;
                this.listaResponsables = listaResponsables;
                this.notaPie = notaPie;
                this.pagina = pagina;
            }

            /// <summary>
            /// Propiedad del documento para el fin de página.
            /// </summary>
            /// <param name="writer">objeto PdfWriter</param>
            /// <param name="doc">Objeto Document</param>
            public override void OnEndPage(PdfWriter writer, Document doc)
            {
                /*Número de Página*/
                Paragraph parrafoNumeroPagina = new Paragraph(writer.PageNumber.ToString());
                parrafoNumeroPagina.Font.SetColor(100, 100, 100);
                parrafoNumeroPagina.Font.Size = 8;
                parrafoNumeroPagina.Alignment = Element.ALIGN_RIGHT;

                PdfPCell celdaNumeroPagina = new PdfPCell(parrafoNumeroPagina);
                celdaNumeroPagina.Border = 0;
                celdaNumeroPagina.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;

                /*Comentario de página*/
                Paragraph parrafoComentarioPagina = new Paragraph(this.contenido);
                parrafoComentarioPagina.Font.SetColor(200, 100, 100);
                parrafoComentarioPagina.Font.Size = 8;
                parrafoComentarioPagina.Alignment = Element.ALIGN_LEFT;

                PdfPCell celdaComentarioPagina = new PdfPCell(parrafoComentarioPagina);
                celdaComentarioPagina.Border = 0;

                List<PdfPCell> listaCellResponsable = new List<PdfPCell>();

                if (listaResponsables != null && listaResponsables.Count > 0)
                {

                    int numeroResponsable = 1;
                    foreach (var responsable in listaResponsables)
                    {
                        Paragraph parrafoResponsable = new Paragraph(responsable);
                        parrafoResponsable.Font.SetColor(100, 100, 100);
                        parrafoResponsable.Font.Size = 6;
                        var celdaResponsable = new PdfPCell(parrafoResponsable);

                        if ((numeroResponsable + 2) % 3 == 0)
                        {
                            celdaResponsable.HorizontalAlignment = Element.ALIGN_LEFT;
                        }
                        else if ((numeroResponsable + 1) % 3 == 0)
                        {
                            celdaResponsable.HorizontalAlignment = Element.ALIGN_CENTER;
                        }
                        else if (numeroResponsable % 3 == 0)
                        {
                            celdaResponsable.HorizontalAlignment = Element.ALIGN_RIGHT;
                        }

                        celdaResponsable.Border = 0;
                        listaCellResponsable.Add(celdaResponsable);
                        numeroResponsable++;
                    }

                    if ((listaCellResponsable.Count % 2) != 0)
                    {
                        var pdfCell = new PdfPCell(new Paragraph(""));
                        pdfCell.Border = 0;

                        listaCellResponsable.Add(pdfCell);
                    }
                }

                PdfPCell cellBlanco = new PdfPCell(new Paragraph(""));
                cellBlanco.Border = 0;

                /*Agregar la tabla*/
                float[] anchuras = { 1f, 1f, 1f };
                PdfPTable footerTbl = new PdfPTable(anchuras);
                footerTbl.TotalWidth = doc.PageSize.Width - doc.LeftMargin - doc.RightMargin;
                footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;

                //Agregar línea a inicio de pie de página
                Paragraph linea = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                PdfPCell cellLinea = new PdfPCell(linea);
                cellLinea.Border = 0;
                cellLinea.Colspan = 3;
                footerTbl.AddCell(cellLinea);

                if (writer.PageNumber == this.pagina)
                {

                    //if (!string.IsNullOrEmpty(this.contenido))
                    //{
                    footerTbl.AddCell(cellBlanco);
                    footerTbl.AddCell(cellBlanco);
                    footerTbl.AddCell(cellBlanco);

                    /*VALIDAR EL PIE DE PAGINA*/
                    footerTbl.AddCell(celdaComentarioPagina);
                    footerTbl.AddCell(cellBlanco);
                    footerTbl.AddCell(celdaNumeroPagina);
                    // }

                    if (!string.IsNullOrEmpty(notaPie))
                    {
                        PdfPCell cellNote = new PdfPCell();
                        cellNote.Border = 0;
                        cellNote.Colspan = 3;

                        string styles = "p { font-size: 7px; }";
                        foreach (IElement element in XMLWorkerHelper.ParseToElementList(notaPie, styles))
                        {
                            cellNote.AddElement(element);
                        }

                        footerTbl.AddCell(cellNote);
                    }

                    if (listaResponsables != null && listaResponsables.Count > 0)
                    {
                        /*Comentario de página*/
                        Paragraph revisadoPor = new Paragraph(DatosConstantes.Recursos.RevisadoPor);
                        revisadoPor.Font.SetColor(100, 100, 100);
                        revisadoPor.Font.Size = 6;
                        revisadoPor.Alignment = Element.ALIGN_LEFT;

                        PdfPCell cellRevisadoPor = new PdfPCell(revisadoPor);
                        cellRevisadoPor.Border = 0;

                        footerTbl.AddCell(cellRevisadoPor);
                        footerTbl.AddCell(cellBlanco);
                        footerTbl.AddCell(cellBlanco);

                        foreach (var cellResponsable in listaCellResponsable)
                        {
                            footerTbl.AddCell(cellResponsable);
                        }
                        footerTbl.AddCell(cellBlanco);
                        footerTbl.AddCell(cellBlanco);
                    }
                }

                footerTbl.WriteSelectedRows(0, -1, doc.LeftMargin, doc.PageSize.GetBottom(doc.BottomMargin * 0.8F), writer.DirectContent);
            }
        }

        /// <summary>
        /// Clase Header para documento PDF
        /// </summary>
        public partial class Header : PdfPageEventHelper
        {
            /// <summary>
            /// Contenido
            /// </summary>
            public string contenido;
            /// <summary>
            /// Logo Stracon GYM
            /// </summary>
            public string logo;
            /// <summary>
            /// Width del logo
            /// </summary>
            public int width;
            /// <summary>
            /// Height del logo
            /// </summary>
            public int height;

            /// <summary>
            /// Contenido del Header del documento.
            /// </summary>
            /// <param name="contenidoHeader">Contenido de la cabecera</param>
            /// <param name="urlLogo">Url del logo Stracon</param>
            /// <param name="width">Ancho del logo en pixeles</param>
            /// <param name="height">Largo del logo en pixeles</param>
            public Header(string contenidoHeader, string urlLogo, int width, int height)
            {
                this.contenido = contenidoHeader;
                this.logo = urlLogo;
                this.width = width;
                this.height = height;
            }
            /// <summary>
            /// Propiedad del documento para el inicio de página.
            /// </summary>
            /// <param name="writer">objeto PdfWriter</param>
            /// <param name="doc">Objeto Document</param>
            public override void OnStartPage(PdfWriter writer, Document doc)
            {
                /*Comentario de página*/
                Paragraph header = new Paragraph(this.contenido);
                header.Font.SetColor(100, 100, 100);
                header.Font.Size = 11;
                header.Font.SetFamily("Arial");
                header.Alignment = Element.ALIGN_RIGHT;

                PdfPCell cell = new PdfPCell(header);
                cell.Border = 0;
                cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                /*Logo*/
                //Header Image 
                doc.Add(new Paragraph(""));
                if (!string.IsNullOrEmpty(this.logo))
                {
                    iTextSharp.text.Image imghead = iTextSharp.text.Image.GetInstance(new Uri(this.logo));
                    imghead.SetAbsolutePosition(0, 0);
                    imghead.Alignment = Element.ALIGN_LEFT;
                    imghead.ScaleAbsoluteWidth(this.width);
                    imghead.ScaleAbsoluteHeight(this.height);

                    PdfContentByte cbhead = writer.DirectContent;
                    PdfTemplate tp = cbhead.CreateTemplate(2000, 200); // units are in pixels but I'm not sure if thats the correct units
                    tp.AddImage(imghead);
                    cbhead.AddTemplate(tp, doc.LeftMargin, 780);
                }

                /*Agregar la tabla*/
                float[] anchuras = { 1f };
                PdfPTable headerTbl = new PdfPTable(anchuras);
                headerTbl.TotalWidth = doc.PageSize.Width - doc.LeftMargin - doc.RightMargin;
                headerTbl.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTbl.AddCell(cell);
                headerTbl.WriteSelectedRows(0, -1, doc.LeftMargin, 800, writer.DirectContent);
                // headerTbl.WriteSelectedRows(0, -1, doc.LeftMargin, doc.PageSize.GetBottom(doc.BottomMargin * 11.5F), writer.DirectContent);
            }
        }
        /// <summary>
        /// Procesador de Imagenes
        /// </summary>
        public class CustomImageTagProcessor : iTextSharp.tool.xml.html.Image
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="ctx"></param>
            /// <param name="tag"></param>
            /// <param name="currentContent"></param>
            /// <returns></returns>
            public override IList<IElement> End(IWorkerContext ctx, Tag tag, IList<IElement> currentContent)
            {
                IDictionary<string, string> attributes = tag.Attributes;
                string src;
                if (!attributes.TryGetValue(HTML.Attribute.SRC, out src))
                    return new List<IElement>(1);

                if (string.IsNullOrEmpty(src))
                    return new List<IElement>(1);

                if (src.StartsWith("data:image/", StringComparison.InvariantCultureIgnoreCase))
                {
                    var base64Data = src.Substring(src.IndexOf(",") + 1);
                    var imagedata = Convert.FromBase64String(base64Data);
                    var image = iTextSharp.text.Image.GetInstance(imagedata);

                    var list = new List<IElement>();
                    var htmlPipelineContext = GetHtmlPipelineContext(ctx);
                    list.Add(GetCssAppliers().Apply(new Chunk((iTextSharp.text.Image)GetCssAppliers().Apply(image, tag, htmlPipelineContext), 0, 0, true), tag, htmlPipelineContext));
                    return list;
                }
                else
                {
                    return base.End(ctx, tag, currentContent);
                }
            }
        }
    }

    /// <summary>
    /// Parametros Notificación
    /// </summary>
    public class ParametrosNotificacion
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid codigoContratoEstadio { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TipoNotificacion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string> variables { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cuentaNotificar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cuentaCopiar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string profileCorreo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string asunto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string textoNotificar { get; set; }
    }
}
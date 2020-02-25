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
    /// Servicio que representa los Requerimientos
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150525 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class RequerimientoService : GenericService, IRequerimientoService
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
        /// Repositorio de manejo de listado Requerimiento logic
        /// </summary>
        public IListadoRequerimientoLogicRepository listadoRequerimientoLogicRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de Requerimiento entity
        /// </summary>
        public IRequerimientoEntityRepository RequerimientoEntityRepository { get; set; }
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
        /// Repositorio de manejo de Requerimiento documento entity
        /// </summary>
        public IRequerimientoDocumentoEntityRepository RequerimientoDocumentoEntityRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de Requerimiento estadio entity
        /// </summary>
        public IRequerimientoEstadioEntityRepository RequerimientoEstadioEntityRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de Requerimiento párrafo entity
        /// </summary>
        public IRequerimientoParrafoEntityRepository RequerimientoParrafoEntityRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de Requerimiento párrafo variable entity
        /// </summary>
        public IRequerimientoParrafoVariableEntityRepository RequerimientoParrafoVariableEntityRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de Requerimiento bien entity
        /// </summary>
        public IRequerimientoBienEntityRepository RequerimientoBienEntityRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de Requerimiento firmante entity
        /// </summary>
        public IRequerimientoFirmanteEntityRepository RequerimientoFirmanteEntityRepository { get; set; }
        /// <summary>
        /// Servicio de trabajador
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }
        /// <summary>
        /// Servicio de Plantillas
        /// </summary>
        public IPlantillaService plantillaService { get; set; }
        /// <summary>
        /// Interface para obtener información de la entidad Requerimiento.
        /// </summary>
        public IRequerimientoEntityRepository RequerimientoRepository { get; set; }
        /// <summary>
        /// Interfaz de comunicación para el Flujo de Aprobación Estadio.
        /// </summary>
        public IFlujoAprobacionEstadioEntityRepository flujoAprobacionEstadioRepository { get; set; }
        /// <summary>
        /// Interface para información de Requerimiento Estadio
        /// </summary>
        public IRequerimientoEstadioEntityRepository RequerimientoEstadioRepository { get; set; }
        /// <summary>
        /// Interfaz de comunicación para el Flujo de Aprobación Logic.
        /// </summary>
        public IFlujoAprobacionLogicRepository flujoAprobacionLogicRepository { get; set; }
        /// <summary>
        /// Servicio de manejo de Requerimientos
        /// </summary>
        public IRequerimientoLogicRepository RequerimientoLogicRepository { get; set; }
        /// <summary>
        /// Servicio de manejo de Requerimientos - Observaciones por Estadio
        /// </summary>
        public IRequerimientoEstadioObservacionEntityRepository RequerimientoEstadioObservacionRepository { get; set; }
        /// <summary>
        /// Servicio de manejo de Requerimientos - Consultas por Estadio
        /// </summary>
        public IRequerimientoEstadioConsultaEntityRepository RequerimientoEstadioConsultaRepository { get; set; }
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
        /// Interface para obtener información del logic del documento adjunto del Requerimiento.
        /// </summary>
        public IRequerimientoDocumentoAdjuntoLogicRepository RequerimientoDocumentoAdjuntoLogicRepository { get; set; }

        /// <summary>
        /// S09-SGC-01
        /// </summary>
        public IRequerimientoDocumentoAdjuntoResolucionLogicRepository RequerimientoDocumentoAdjuntoResolucionLogicRepository { get; set; }

        /// <summary>
        /// Interface para obtener información del entity del documento adjunto del Requerimiento.
        /// </summary>
        public IRequerimientoDocumentoAdjuntoEntityRepository RequerimientoDocumentoAdjuntoEntityRepository { get; set; }

        /// <summary>
        /// S09-SGC-01 
        /// </summary>
        public IRequerimientoDocumentoAdjuntoResolucionEntityRepository RequerimientoDocumentoAdjuntoResolucionEntityRepository { get; set; }

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
                var lstUOs = RequerimientoLogicRepository.ListarUnidadOperativaResponsable(codigoResponsable);
                foreach (var item in lstUOs)
                {
                    rpta.Result.Add(RequerimientoAdapter.ObtenerUnidadOperativaResponseDeLogic(item));
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Método para recuperar los registros de la bandeja de proceso.
        /// </summary>
        /// <param name="filtro">Objeto Requerimiento Request</param>
        /// <param name="lstTipoRequerimiento">Lista de Tipos de Servicio</param>
        /// <param name="lstTipoServicio">Lista de Tipo de Requerimiento</param>
        /// <returns>Registros de bandeja de procesos</returns>                
        public ProcessResult<List<RequerimientoResponse>> BuscarBandejaProcesosRequerimiento(RequerimientoRequest filtro,
                                                                                   List<CodigoValorResponse> lstTipoRequerimiento = null,
                                                                                   List<CodigoValorResponse> lstTipoServicio = null)
        {
            ProcessResult<List<RequerimientoLogic>> listaRegistros = new ProcessResult<List<RequerimientoLogic>>();
            ProcessResult<List<RequerimientoResponse>> rpta = new ProcessResult<List<RequerimientoResponse>>();
            List<CodigoValorResponse> listaTipoServicio;
            List<CodigoValorResponse> listaTipoRequerimiento;
            RequerimientoResponse itemRpta;
            try
            {
                if (lstTipoRequerimiento != null)
                {
                    listaTipoServicio = lstTipoRequerimiento;
                }
                else
                {
                    listaTipoServicio = politicaService.ListarTipoRequerimiento().Result;
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

                listaRegistros.Result = RequerimientoLogicRepository.ListaBandejaRequerimientos(
                    (Guid)filtro.CodigoResponsable,
                    filtro.CodigoUnidadOperativa,
                    filtro.NombreProveedor,
                    filtro.NumeroDocProveedor,
                    filtro.CodigoTipoServicio,
                    filtro.CodigoTipoRequerimiento,
                    filtro.NombreEstadio,
                    filtro.IndicadorFinalizarAprobacion);

                rpta.Result = new List<RequerimientoResponse>();
                foreach (RequerimientoLogic itemLogic in listaRegistros.Result)
                {
                    itemRpta = new RequerimientoResponse();
                    itemRpta = RequerimientoAdapter.ObtenerRequerimientoResponseDeLogic(itemLogic, listaUO.Result, listaTipoServicio, listaTipoRequerimiento);
                    rpta.Result.Add(itemRpta);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Método para recuperar los registros de la bandeja de proceso de Requerimientos con observaciones
        /// </summary>
        /// <param name="CodigoRequerimientoEstadio">Codigo de Requerimiento estadio.</param>
        /// <returns>Registro de bandeja de procesos de Requerimiento por observaciones</returns>
        public ProcessResult<List<RequerimientoEstadioObservacionResponse>> BuscarBandejaRequerimientosObservacion(Guid CodigoRequerimientoEstadio)
        {
            ProcessResult<List<RequerimientoEstadioObservacionLogic>> listaRegistros = new ProcessResult<List<RequerimientoEstadioObservacionLogic>>();
            ProcessResult<List<RequerimientoEstadioObservacionResponse>> rpta = new ProcessResult<List<RequerimientoEstadioObservacionResponse>>();
            RequerimientoEstadioObservacionResponse itemRpta;
            List<Guid?> filtroTrb = new List<Guid?>();
            try
            {
                listaRegistros.Result = RequerimientoLogicRepository.ListaBandejaRequerimientosObservacion(CodigoRequerimientoEstadio);
                foreach (RequerimientoEstadioObservacionLogic item in listaRegistros.Result)
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
                rpta.Result = new List<RequerimientoEstadioObservacionResponse>();
                var lstTrbajadores = trabajadorService.ListarTrabajadores(filtroTrb);
                var lstTipoRespuesta = politicaService.ListarTipoRespuestaObservacion();

                foreach (RequerimientoEstadioObservacionLogic itemLogic in listaRegistros.Result)
                {
                    itemRpta = new RequerimientoEstadioObservacionResponse();
                    itemRpta = RequerimientoAdapter.ObtenerRequerimientoEstadioResponseDeLogic(itemLogic, lstTrbajadores.Result, lstTipoRespuesta.Result);
                    rpta.Result.Add(itemRpta);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Método para recuperar los registros de la bandeja de proceso de Requerimientos con consultas
        /// </summary>
        /// <param name="CodigoRequerimientoEstadio">Codigo de Requerimiento estadio.</param>
        /// <returns>Registros de bandeja de procesos de Requerimiento</returns>
        public ProcessResult<List<RequerimientoEstadioConsultaResponse>> BuscarBandejaRequerimientosConsultas(Guid CodigoRequerimientoEstadio)
        {
            ProcessResult<List<RequerimientoEstadioConsultaLogic>> listaRegistros = new ProcessResult<List<RequerimientoEstadioConsultaLogic>>();
            ProcessResult<List<RequerimientoEstadioConsultaResponse>> rpta = new ProcessResult<List<RequerimientoEstadioConsultaResponse>>();
            RequerimientoEstadioConsultaResponse itemRpta;
            List<Guid?> filtroTrb = new List<Guid?>();
            try
            {
                listaRegistros.Result = RequerimientoLogicRepository.ListaBandejaRequerimientosConsultas(CodigoRequerimientoEstadio);

                foreach (RequerimientoEstadioConsultaLogic item in listaRegistros.Result)
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
                rpta.Result = new List<RequerimientoEstadioConsultaResponse>();
                foreach (RequerimientoEstadioConsultaLogic itemLogic in listaRegistros.Result)
                {
                    itemRpta = new RequerimientoEstadioConsultaResponse();
                    itemRpta = RequerimientoAdapter.ObtenerRequerimientoEstadioResponseDeLogic(itemLogic, lstTrbajadores.Result);
                    rpta.Result.Add(itemRpta);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Registra una Observación del Requerimiento por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request RequerimientoEstadioObservacionRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistraRequerimientoEstadioObservacion(RequerimientoEstadioObservacionRequest objParm)
        {
            ProcessResult<Object> rpta = new ProcessResult<Object>();
            ParametrosNotificacion objPrm = new ParametrosNotificacion();
            bool esNuevoRegistro = false;
            int esNotificado = 0;

            RequerimientoEstadioObservacionEntity entidad = RequerimientoAdapter.ObtenerRequerimientoEstadioObservacionEntityDeRequest(objParm);

            //Obtener el responsable del Requerimiento estadio
            var RequerimientoEstadio = RequerimientoLogicRepository.ListarRequerimientoEstadio(entidad.CodigoRequerimientoEstadio).FirstOrDefault();

            if (RequerimientoEstadio != null)
            {
                var codigoResponsable = RequerimientoLogicRepository.ObtenerResponsableRequerimientoEstadioEdicion(entidad.CodigoRequerimientoEstadio, (Guid)entidad.CodigoEstadioRetorno, (Guid)entidad.Destinatario);

                if (codigoResponsable != null)
                {
                    entidad.Destinatario = codigoResponsable;
                }
            }

            int resultadoNuevoRequerimientoEstadio = 0;
            try
            {
                RequerimientoDocumentoEntity entidadRequerimientoDocumento = null;

                if (objParm.IndicadorAdhesion && objParm.DocumentoRequerimiento != null && objParm.DocumentoRequerimiento.Count() > 0)
                {
                    //Generando Requerimiento documento                        
                    var RequerimientoDocumento = RequerimientoLogicRepository.ListarRequerimientoDocumento(objParm.CodigoRequerimiento.Value).OrderBy(item => item.Version).LastOrDefault();
                    entidad.CodigoArchivo = RequerimientoDocumento.CodigoArchivo;
                    entidad.RutaArchivoSharepoint = RequerimientoDocumento.RutaArchivoSharePoint;

                    entidadRequerimientoDocumento = RequerimientoDocumentoAdapter.RegistrarRequerimientoDocumento(new RequerimientoDocumentoRequest()
                    {
                        CodigoRequerimiento = objParm.CodigoRequerimiento.ToString(),
                        IndicadorActual = true,
                        Version = (short)(RequerimientoDocumento.Version + 1)
                    });

                    /*Registramos información del SharePoint*/
                    string nombreFile, lsDirectorioDestino, listName, folderName, hayError = string.Empty;

                    #region InformacionRepositorioSharePoint
                    var rutaArchivoSplit = RequerimientoDocumento.RutaArchivoSharePoint.Split('/').ToList();
                    string miDirectorio = string.Empty;

                    int i = 0;
                    while (i < rutaArchivoSplit.Count - 1)
                    {
                        miDirectorio += rutaArchivoSplit[i] + "/";
                        i++;
                    }
                    nombreFile = string.Format("{0}.{1}", entidadRequerimientoDocumento.CodigoRequerimientoDocumento.ToString(), objParm.ExtencionArchivo);
                    lsDirectorioDestino = miDirectorio;
                    string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });
                    listName = nivelCarpeta[0];
                    folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                    #endregion

                    #region GrabarContenidoRequerimientoSHP
                    MemoryStream msFile = new MemoryStream(objParm.DocumentoRequerimiento);
                    if (msFile != null)
                    {
                        var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, nombreFile, msFile);
                        if (Convert.ToInt32(regSHP.Result) > 0 && hayError == string.Empty)
                        {
                            entidadRequerimientoDocumento.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                            entidadRequerimientoDocumento.RutaArchivoSharePoint = lsDirectorioDestino;
                        }
                        else
                        {
                            if (Convert.ToInt32(regSHP.Result) > 0)
                            {
                                var fileShpDelete = sharePointService.EliminaArchivoSharePoint(new List<int>() { Convert.ToInt32(regSHP.Result) }, listName, ref hayError);
                            }
                            rpta.IsSuccess = false;
                            rpta.Exception = new ApplicationLayerException<RequerimientoService>("Ocurrió un problema al registra el archivo en el SharePoint: " + hayError);
                            LogBL.grabarLogError(new Exception(hayError));
                            return rpta;
                        }
                    }
                    else
                    {
                        rpta.IsSuccess = false;
                        rpta.Exception = new ApplicationLayerException<RequerimientoService>("El documento presenta errores.");
                        LogBL.grabarLogError(new Exception("El documento presenta errores."));
                        return rpta;
                    }
                    #endregion
                }

                using (TransactionScope tsc = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (entidadRequerimientoDocumento != null)
                    {
                        RequerimientoDocumentoEntityRepository.RegistrarRequerimientoDocumento(entidadRequerimientoDocumento);
                    }

                    var destinatario = (Guid)objParm.Destinatario;

                    Guid newCodigoRequerimientoEstadio = Guid.NewGuid();
                    resultadoNuevoRequerimientoEstadio = RequerimientoLogicRepository.ObservaEstadioRequerimiento(
                                    newCodigoRequerimientoEstadio,
                                    objParm.CodigoRequerimientoEstadio,
                                    (Guid)objParm.CodigoRequerimiento,
                                    (Guid)objParm.CodigoEstadioRetorno,
                                    destinatario,
                                    entornoAplicacion.UsuarioSession,
                                    entornoAplicacion.Terminal);
                    if (resultadoNuevoRequerimientoEstadio == 1)
                    {
                        if (entidad.CodigoRequerimientoEstadioObservacion == Guid.Empty)
                        {
                            entidad.CodigoRequerimientoEstadioObservacion = Guid.NewGuid();
                            entidad.CodigoRequerimientoEstadio = newCodigoRequerimientoEstadio;
                            entidad.FechaRegistro = DateTime.Now;
                            RequerimientoEstadioObservacionRepository.Insertar(entidad);
                            esNuevoRegistro = true;
                        }
                        else
                        {
                            var entidadUpdate = RequerimientoEstadioObservacionRepository.GetById(entidad.CodigoRequerimientoEstadioObservacion);
                            entidadUpdate.Descripcion = entidad.Descripcion;
                            entidadUpdate.CodigoRequerimientoParrafo = entidad.CodigoRequerimientoParrafo;
                            entidadUpdate.CodigoEstadioRetorno = entidad.CodigoEstadioRetorno;
                            entidadUpdate.Destinatario = entidad.Destinatario;
                            entidadUpdate.CodigoTipoRespuesta = entidad.CodigoTipoRespuesta;
                            entidadUpdate.Respuesta = entidad.Respuesta;
                            entidadUpdate.FechaRespuesta = entidad.FechaRespuesta;
                            RequerimientoEstadioObservacionRepository.Editar(entidadUpdate);
                        }
                        rpta.Result = RequerimientoEstadioObservacionRepository.GuardarCambios();
                    }
                    else
                    {
                        rpta.Result = "Problemas al registrar nuevo Estadío de Requerimiento ó el Requerimiento ya fue observado, por favor regrese a su bandeja de Requerimientos.";
                        rpta.IsSuccess = false;
                    }
                    tsc.Complete();
                }

                if (esNuevoRegistro)
                {
                    esNotificado = generaNotificacionCorreo(DatosConstantes.TipoNotificacion.RequerimientosObservado, entidad.CodigoRequerimientoEstadio, null, null, null, null, null, objParm.Destinatario, objParm.NotificacionObservadoCC);

                }
                else
                {
                    esNotificado = generaNotificacionCorreo(DatosConstantes.TipoNotificacion.ObservacionRechazada, entidad.CodigoRequerimientoEstadio);
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
        /// Responde la Observación del Requerimiento por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request RequerimientoEstadioObservacionRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RespondeRequerimientoEstadioObservacion(RequerimientoEstadioObservacionRequest objParm)
        {
            ProcessResult<Object> rpta = new ProcessResult<Object>();
            RequerimientoEstadioObservacionEntity entidad = RequerimientoAdapter.ObtenerRequerimientoEstadioObservacionEntityDeRequest(objParm);
            bool esNuevoRegistro = false, esNoAplica = false;
            int esNotificado = 0;
            try
            {
                using (TransactionScope tsc = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (entidad.CodigoRequerimientoEstadioObservacion == Guid.Empty)
                    {
                        entidad.CodigoRequerimientoEstadioObservacion = Guid.NewGuid();
                        entidad.FechaRegistro = DateTime.Now;
                        RequerimientoEstadioObservacionRepository.Insertar(entidad);
                        esNuevoRegistro = true;
                    }
                    else
                    {
                        var entidadUpdate = RequerimientoEstadioObservacionRepository.GetById(entidad.CodigoRequerimientoEstadioObservacion);
                        entidadUpdate.CodigoRequerimientoEstadio = entidad.CodigoRequerimientoEstadio;
                        entidadUpdate.Descripcion = entidad.Descripcion;
                        entidadUpdate.CodigoRequerimientoParrafo = entidad.CodigoRequerimientoParrafo;
                        entidadUpdate.CodigoEstadioRetorno = entidad.CodigoEstadioRetorno;
                        entidadUpdate.Destinatario = entidad.Destinatario;
                        entidadUpdate.CodigoTipoRespuesta = entidad.CodigoTipoRespuesta;
                        entidadUpdate.Respuesta = entidad.Respuesta;
                        entidadUpdate.FechaRespuesta = DateTime.Now;
                        RequerimientoEstadioObservacionRepository.Editar(entidadUpdate);

                        /*Si no Aplica, entonces retorna al estadio anterior.*/
                        if (entidad.CodigoTipoRespuesta.Equals(DatosConstantes.TipoRespuestaObservacion.NoAplica))
                        {
                            var RequerimientoEstadio = RequerimientoEstadioRepository.GetById(objParm.CodigoRequerimientoEstadio);
                            /*Obtenemos el estadio anterior.*/
                            var lsEstadioAnterior = RequerimientoLogicRepository.EstadoAnteriorRequerimientoEstadio(objParm.CodigoRequerimientoEstadio, RequerimientoEstadio.CodigoRequerimiento);
                            /*Obtenemos el código de Requerimiento.*/
                            if (lsEstadioAnterior != null && lsEstadioAnterior.Count > 0)
                            {
                                esNoAplica = true;
                                Guid newCodigoRequerimientoEstadio = Guid.NewGuid();
                                int resultadoNuevoRequerimientoEstadio = 0;
                                resultadoNuevoRequerimientoEstadio = RequerimientoLogicRepository.ObservaEstadioRequerimiento(
                                                newCodigoRequerimientoEstadio,
                                                objParm.CodigoRequerimientoEstadio,
                                                RequerimientoEstadio.CodigoRequerimiento,
                                                lsEstadioAnterior[0].CodigoFlujoAprobacionEstadio,
                                                lsEstadioAnterior[0].CodigoTrabajador.Value,
                                                entornoAplicacion.UsuarioSession,
                                                entornoAplicacion.Terminal);
                            }
                        }
                        rpta.Result = RequerimientoEstadioObservacionRepository.GuardarCambios();
                    }
                    tsc.Complete();
                }
                if (esNuevoRegistro)
                {
                    esNotificado = generaNotificacionCorreo(DatosConstantes.TipoNotificacion.RequerimientosObservado, entidad.CodigoRequerimientoEstadio);
                }
                else
                {
                    if (esNoAplica)
                    {
                        esNotificado = generaNotificacionCorreo(DatosConstantes.TipoNotificacion.ObservacionRechazada, entidad.CodigoRequerimientoEstadio);
                    }
                }
            }
            catch (Exception ex)
            {
                rpta.Result = ex.Message;
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Registra una Observación del Requerimiento por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request RequerimientoEstadioObservacionRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistraRequerimientoEstadioConsulta(RequerimientoEstadioConsultaRequest objParm)
        {
            ProcessResult<Object> rpta = new ProcessResult<Object>();
            bool esNuevoRegistro = false;
            //Thread procesoNotificar;
            try
            {
                RequerimientoEstadioConsultaEntity entidad = RequerimientoAdapter.ObtenerRequerimientoEstadioConsultEntityDeRequest(objParm);
                ParametrosNotificacion objPrm = new ParametrosNotificacion();
                if (entidad.CodigoRequerimientoEstadioConsulta == Guid.Empty)
                {
                    entidad.FechaRegistro = DateTime.Now;
                    entidad.FechaRespuesta = null;
                    entidad.CodigoRequerimientoEstadioConsulta = Guid.NewGuid();
                    RequerimientoEstadioConsultaRepository.Insertar(entidad);
                    esNuevoRegistro = true;
                    rpta.Result = RequerimientoEstadioConsultaRepository.GuardarCambios();
                }
                else
                {
                    //var entidadUpdate = RequerimientoEstadioConsultaRepository.GetById(entidad.CodigoRequerimientoEstadioConsulta);
                    //entidadUpdate.Descripcion = entidad.Descripcion;
                    //entidadUpdate.FechaRegistro = DateTime.Now; //DateTime.Now; // entidad.FechaRegistro;
                    //entidadUpdate.CodigoRequerimientoParrafo = entidad.CodigoRequerimientoParrafo;
                    //entidadUpdate.Destinatario = entidad.Destinatario;
                    //entidadUpdate.Respuesta = entidad.Respuesta;
                    //entidadUpdate.FechaRespuesta = DateTime.Now;
                    //RequerimientoEstadioConsultaRepository.Editar(entidadUpdate);

                    //entidad.UsuarioModificacion = entorno == null ? entornoActualAplicacion.UsuarioSession : entorno.UsuarioSession;
                    //entidad.FechaModificacion = DateTime.Now;
                    //entidad.TerminalModificacion = entorno == null ? entornoActualAplicacion.Terminal : entorno.Terminal;


                    int result = RequerimientoLogicRepository.Responder_Consulta(entidad.CodigoRequerimientoEstadioConsulta,entidad.Respuesta, entornoActualAplicacion.UsuarioSession, entornoActualAplicacion.Terminal);

                }
                
                if (esNuevoRegistro)
                {
                    int notificar = generaNotificacionCorreo(DatosConstantes.TipoNotificacion.NuevaConsulta, entidad.CodigoRequerimientoEstadio);
                }
                else
                {
                    //objPrm = obtieneParametrosCorreo(DatosConstantes.TipoNotificacion.RespuestaConsulta, entidad.CodigoRequerimientoEstadio);
                    //procesoNotificar = new Thread(NotificacionRequerimiento);
                    //procesoNotificar.Start(objPrm);
                    int notificar = generaNotificacionCorreo(DatosConstantes.TipoNotificacion.RespuestaConsulta, entidad.CodigoRequerimientoEstadio);
                }

            }
            catch (Exception ex)
            {
                rpta.Result = ex.Message;
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Registra una Observación del Requerimiento por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request RequerimientoEstadioObservacionRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistraRequerimientoEstadio(RequerimientoEstadioRequest objParm)
        {
            ProcessResult<Object> rpta = new ProcessResult<Object>();
            try
            {
                RequerimientoEstadioEntity entidad = RequerimientoAdapter.ObtenerRequerimientoEstadioEntityDeRequest(objParm);
                if (entidad.CodigoRequerimientoEstadio == Guid.Empty)
                {
                    entidad.CodigoRequerimientoEstadio = Guid.NewGuid();
                    RequerimientoEstadioRepository.Insertar(entidad);
                }
                else
                {
                    var entidadUpdate = RequerimientoEstadioRepository.GetById(entidad.CodigoRequerimientoEstadio);
                    entidadUpdate.FechaIngreso = entidad.FechaIngreso;
                    entidadUpdate.FechaFinalizacion = entidad.FechaFinalizacion;
                    entidadUpdate.CodigoResponsable = entidad.CodigoResponsable;
                    entidadUpdate.CodigoEstadoRequerimientoEstadio = entidad.CodigoEstadoRequerimientoEstadio;
                    entidadUpdate.FechaPrimeraNotificacion = entidad.FechaPrimeraNotificacion;
                    entidadUpdate.FechaUltimaNotificacion = entidad.FechaUltimaNotificacion;
                    RequerimientoEstadioRepository.Editar(entidadUpdate);
                }
                rpta.Result = RequerimientoEstadioRepository.GuardarCambios();
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Metodo para obtener datos de Requerimiento Estadio Observacion por el ID
        /// </summary>
        /// <param name="CodigoRequerimientoEstadioObservacion">Id del Codigo Requerimiento Estadio Observacion </param>
        /// <returns>Requerimiento de estadio por observación</returns>
        public RequerimientoEstadioObservacionResponse ObtieneRequerimientoEstadioObservacionPorID(Guid CodigoRequerimientoEstadioObservacion)
        {
            RequerimientoEstadioObservacionResponse rpta = new RequerimientoEstadioObservacionResponse();
            try
            {
                var result = RequerimientoEstadioObservacionRepository.GetById(CodigoRequerimientoEstadioObservacion);
                rpta = RequerimientoAdapter.ObtenerRequerimientoEstadioObservacionResponseDeEntity(result);
            }
            catch (Exception)
            {
                rpta = null;
            }
            return rpta;
        }
        /// <summary>
        /// Metodo para obtener datos de Requerimiento Estadio Consulta por el ID
        /// </summary>
        /// <param name="CodigoRequerimientoEstadioConsulta">Id del Codigo Requerimiento Estadio Consulta </param>
        /// <returns>Requerimiento estadio</returns>
        public RequerimientoEstadioConsultaResponse ObtieneRequerimientoEstadioConsultaPorID(Guid CodigoRequerimientoEstadioConsulta)
        {
            RequerimientoEstadioConsultaResponse rpta = new RequerimientoEstadioConsultaResponse();

            try
            {
                var result = RequerimientoEstadioConsultaRepository.GetById(CodigoRequerimientoEstadioConsulta);
                rpta = RequerimientoAdapter.ObtenerRequerimientoEstadioConsultaResponseDeEntity(result);
            }
            catch (Exception)
            {
                rpta = null;
            }
            return rpta;
        }

        /// <summary>
        /// Metodo para aprobar cada Requerimiento según su estadío.
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento </param>
        /// <param name="codigoRequerimientoEstadio">Código de Requerimiento Estadío</param>
        /// <param name="login"></param>
        /// <param name="MotivoAprobacion">Motivo de Aprobación</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> ApruebaRequerimientoEstadio(Guid codigoRequerimiento, Guid codigoRequerimientoEstadio, string MotivoAprobacion, string login = null)
        {
            ProcessResult<Object> rpta = new ProcessResult<Object>();
            int resultProcesoAprobacion = -1;
            string contenidoRequerimiento = string.Empty, NombreFile = string.Empty, listName = string.Empty, folderName = string.Empty,
                   lsDirectorioDestino = string.Empty, hayError = string.Empty;

            try
            {
                RequerimientoEntity entRequerimiento = RequerimientoRepository.GetById(codigoRequerimiento);
                PlantillaEntity entPlantilla = plantillaRepository.GetById(entRequerimiento.CodigoPlantilla);
                RequerimientoEstadioEntity entidadRequerimientoEstadio = RequerimientoEstadioRepository.GetById(codigoRequerimientoEstadio);
                FlujoAprobacionEstadioEntity entidadFlujoAprobacionEstadio = flujoAprobacionEstadioRepository.GetById(entidadRequerimientoEstadio.CodigoFlujoAprobacionEstadio);

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
                    var documentoFinal = RequerimientoLogicRepository.DocumentosPorRequerimiento(codigoRequerimiento).FirstOrDefault();

                    if (documentoFinal.FechaCreacion < entidadRequerimientoEstadio.FechaCreacion)
                    {
                        rpta.Result = "Debe de subir el Requerimiento antes de aprobar el mismo.";
                        rpta.IsSuccess = false;
                        rpta.Exception = new ApplicationLayerException<RequerimientoService>("Debe de subir el Requerimiento antes de aprobar el mismo.");
                        return rpta;
                    }
                }

                List<string> revisores = null;
                List<TrabajadorResponse> firmantes = null;

                if (entRequerimiento.IndicadorVersionOficial == false)
                {
                    revisores = ObtenerListaRevisoresStracon(entRequerimiento, entidadFlujoAprobacionEstadio, login).Result;

                    firmantes = ObtenerListaFirmantesStracon(new RequerimientoResponse() { CodigoRequerimiento = entRequerimiento.CodigoRequerimiento, CodigoFlujoAprobacion = entRequerimiento.CodigoFlujoAprobacion, CodigoProveedor = entRequerimiento.CodigoProveedor }).Result;

                }
                var entUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = entRequerimiento.CodigoUnidadOperativa.ToString() });

                var RepositorioSharePoint = politicaService.ListarRepositorioSharePointSGC(null, "3");
                string siteURLShp = sharePointService.RetornaSiteUrlSharePoint();
                Microsoft.SharePoint.Client.SharePointOnlineCredentials crdSHP = sharePointService.RetornaCredencialesServer();
              

                #region Cambio para Logo por Unidad Operativa
                var urlLogo = "";
                var entUnidadOperativa_logo = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = entRequerimiento.CodigoUnidadOperativa.ToString() });

                if (entUnidadOperativa_logo.Result[0].LogoUnidadOperativa == null)
                {

                    urlLogo = politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.UrlLogoStracon).FirstOrDefault().Atributo3;
                }
                else
                {
                    urlLogo = entUnidadOperativa_logo.Result[0].LogoUnidadOperativa;
                }


                #endregion

                //var urlLogo = politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.UrlLogoStracon).FirstOrDefault().Atributo3;
                var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.WidthLogo).FirstOrDefault().Atributo3);
                var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.HeightLogo).FirstOrDefault().Atributo3);

                var usuarioEstadio = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = entRequerimiento.UsuarioCreacion }).Result.FirstOrDefault();

                using (TransactionScope tsc = new TransactionScope(TransactionScopeOption.Required))
                {
                    resultProcesoAprobacion = RequerimientoLogicRepository.ApruebaRequerimientoEstadio(codigoRequerimientoEstadio,
                                                entUnidadOperativa.Result[0].CodigoIdentificacion,
                                                entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal, usuarioEstadio.CodigoTrabajador, MotivoAprobacion.Trim());

                    if (resultProcesoAprobacion == 1)
                    {
                        if (entidadFlujoAprobacionEstadio.IndicadorVersionOficial && !entPlantilla.IndicadorAdhesion)
                        {
                            List<RequerimientoDocumentoLogic> RequerimientoDocumento = RequerimientoLogicRepository.DocumentosPorRequerimiento(codigoRequerimiento);
                            //Esta lista contiene 2 registros, la ultima modificación y la anterior.
                            if (RequerimientoDocumento != null && RequerimientoDocumento.Count > 0)
                            {
                                #region InformacionRepositorioSharePoint
                                NombreFile = string.Format("{0}.{1}", RequerimientoDocumento[0].CodigoRequerimientoDocumento.ToString(), DatosConstantes.ArchivosRequerimiento.ExtensionValidaCarga);
                                ProcessResult<string> miDirectorio = RetornaDirectorioFile(codigoRequerimiento, entUnidadOperativa.Result[0].Nombre, NombreFile, entRequerimiento.FechaInicioVigencia, false, RepositorioSharePoint.Result);
                                lsDirectorioDestino = miDirectorio.Result.ToString();
                                /*Revisamos la estructura de las carpetas SharePoint*/
                                string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });
                                listName = nivelCarpeta[0];
                                folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                                #endregion

                                #region GrabarContenidoRequerimientoSHP

                                contenidoRequerimiento = RequerimientoDocumento[0].Contenido;
                                MemoryStream msFile = null;

                                ////MLV
                                var numeroCabecera = entRequerimiento.NumeroAdenda > 0 ? string.IsNullOrEmpty(entRequerimiento.NumeroAdendaConcatenado) ? entRequerimiento.NumeroRequerimiento : entRequerimiento.NumeroAdendaConcatenado : entRequerimiento.NumeroRequerimiento;
                                msFile = new MemoryStream(GenerarPdfDesdeHtml(contenidoRequerimiento, "", numeroCabecera, codigoRequerimiento, entRequerimiento.CodigoPlantilla, firmantes, revisores, null, false, urlLogo, widthLogo, heightLogo));

                                if (msFile != null)
                                {
                                    var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, NombreFile, msFile, siteURLShp, crdSHP);
                                    if (Convert.ToInt32(regSHP.Result) > 0)
                                    {
                                        RequerimientoDocumentoEntity conDocEnt = new RequerimientoDocumentoEntity();
                                        conDocEnt.CodigoRequerimientoDocumento = RequerimientoDocumento[0].CodigoRequerimientoDocumento;
                                        conDocEnt.CodigoRequerimiento = RequerimientoDocumento[0].CodigoRequerimiento;
                                        conDocEnt.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                                        conDocEnt.RutaArchivoSharePoint = lsDirectorioDestino;
                                        conDocEnt.Contenido = RequerimientoDocumento[0].Contenido;
                                        conDocEnt.IndicadorActual = true;
                                        conDocEnt.EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;
                                        conDocEnt.UsuarioCreacion = RequerimientoDocumento[0].UsuarioCreacion;
                                        conDocEnt.FechaCreacion = RequerimientoDocumento[0].FechaCreacion;
                                        conDocEnt.TerminalCreacion = RequerimientoDocumento[0].TerminalCreacion;
                                        conDocEnt.Version = RequerimientoDocumento[0].Version;
                                        RequerimientoDocumentoEntityRepository.Editar(conDocEnt, entornoAplicacion);
                                        int rptaCambios = RequerimientoDocumentoEntityRepository.GuardarCambios();
                                        if (rptaCambios != 1)
                                        {
                                            /*Borramos el documento subido al SHP.*/
                                            var fileShpDelete = sharePointService.EliminaArchivoSharePoint(new List<int>() { conDocEnt.CodigoArchivo }, listName, ref hayError);
                                            rpta.Result = "";
                                            rpta.IsSuccess = false;
                                            rpta.Exception = new ApplicationLayerException<RequerimientoService>("Problemas al registrar el Requerimiento Documento Entity: Requerimiento-Service : ApruebaRequerimientoEstadio"); ;
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
                                    rpta.Exception = new ApplicationLayerException<RequerimientoService>("No se pudo generar los bytes del contenido del Documento, verificar.");
                                    return rpta;
                                }

                                #endregion
                            }
                            else
                            {
                                rpta.Result = "No existe contenido del documento para generar información, verifique Requerimiento-Documento.";
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
                    List<RequerimientoDocumentoLogic> RequerimientoEstadio = RequerimientoLogicRepository.DocumentosPorRequerimiento(codigoRequerimiento);
                    if (RequerimientoEstadio != null && RequerimientoEstadio.Count > 0)
                    {
                        try
                        {
                            //Enviar notificación para Requerimientos históricos aprobados
                            if (entRequerimiento.CodigoTipoRequerimiento == DatosConstantes.TipoServicio.RequerimientoHistorico && entRequerimiento.CodigoEstado == DatosConstantes.EstadoRequerimiento.Aprobacion)
                            {
                                var RequerimientoEstadioEdicion = RequerimientoLogicRepository.ObtenerRequerimientoEstadioEdicion(codigoRequerimiento, entRequerimiento.CodigoFlujoAprobacion);
                                generaNotificacionCorreo(DatosConstantes.TipoNotificacion.AprobacionRequerimientoHistorico, RequerimientoEstadioEdicion, null, null, null, null, entRequerimiento.UsuarioCreacion);
                            }
                            else
                            {
                                if (esUltimoEstadio == false)
                                {
                                    var codigoResponsable = flujoAprobacionLogicRepository.ObtenerResponsableSiguienteEstadioFlujoAprobacion(entidadFlujoAprobacionEstadio.CodigoFlujoAprobacion, entidadFlujoAprobacionEstadio.Orden, entidadFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio, codigoRequerimientoEstadio);
                                    generaNotificacionCorreo(DatosConstantes.TipoNotificacion.NuevoRequerimientoBandeja, codigoRequerimientoEstadio, null, null, null, null, null, codigoResponsable);
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
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Método para retornar los párrafos por Requerimiento
        /// </summary>
        /// <param name="CodigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Parrafos de Requerimiento</returns>
        public ProcessResult<List<RequerimientoParrafoResponse>> RetornaParrafosPorRequerimiento(Guid CodigoRequerimiento)
        {
            ProcessResult<List<RequerimientoParrafoResponse>> rpta = new ProcessResult<List<RequerimientoParrafoResponse>>();
            try
            {
                List<RequerimientoParrafoLogic> result = RequerimientoLogicRepository.RetornaParrafosPorRequerimiento(CodigoRequerimiento);
                RequerimientoParrafoResponse objRsp;
                rpta.Result = new List<RequerimientoParrafoResponse>();
                foreach (RequerimientoParrafoLogic item in result)
                {
                    objRsp = new RequerimientoParrafoResponse();
                    objRsp = RequerimientoAdapter.ObtenerRequerimientoParrafoResponseDeLogic(item);
                    rpta.Result.Add(objRsp);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Método para retornar los párrafos por Requerimiento
        /// </summary>
        /// <param name="CodigoRequerimientoEstadio">Código de estadio de Requerimiento</param>
        /// <returns>Parrafos de Requerimiento</returns>
        public ProcessResult<List<FlujoAprobacionEstadioResponse>> RetornaEstadioRequerimientoObservacion(Guid CodigoRequerimientoEstadio)
        {
            ProcessResult<List<FlujoAprobacionEstadioResponse>> rpta = new ProcessResult<List<FlujoAprobacionEstadioResponse>>();
            try
            {
                List<FlujoAprobacionEstadioLogic> result = RequerimientoLogicRepository.RetornaEstadioRequerimientoObservacion(CodigoRequerimientoEstadio);
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
                    objRsp = RequerimientoAdapter.ObtenerFlujoAprobacionEstadioResponseDeLogic(item, lstTrbajadores.Result);
                    rpta.Result.Add(objRsp);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Método que retorna los responsable por flujo de aprobación.
        /// </summary>
        /// <param name="codigoFlujoAprobacion">código del flujo de aprobación.</param>
        /// <param name="codigoRequerimiento"></param>
        /// <returns>Responsables por flujo de aprobación</returns>
        public ProcessResult<List<TrabajadorResponse>> RetornaResponsablesFlujoEstadio(Guid codigoFlujoAprobacion, Guid codigoRequerimiento)
        {
            ProcessResult<List<TrabajadorResponse>> rpta = new ProcessResult<List<TrabajadorResponse>>();
            List<Guid?> filtroTrb = new List<Guid?>();
            try
            {
                //rpta.Result = new List<TrabajadorResponse>();
                rpta.Result = RequerimientoLogicRepository.RetornaResponsablesFlujoEstadio(codigoFlujoAprobacion, codigoRequerimiento);
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
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }
        /// <summary>
        /// Método para listar los documentos de la bandeja de solicitud.
        /// </summary>
        /// <param name="filtro">Información en el RequerimientoRequest</param>
        /// <returns>Documentos de bandeja de solicitud</returns>
        public ProcessResult<List<RequerimientoResponse>> ListaBandejaSolicitudRequerimientos(RequerimientoRequest filtro)
        {
            ProcessResult<List<RequerimientoLogic>> listaRegistros = new ProcessResult<List<RequerimientoLogic>>();
            ProcessResult<List<RequerimientoResponse>> rpta = new ProcessResult<List<RequerimientoResponse>>();
            RequerimientoResponse itemRpta;
            try
            {
                FiltroUnidadOperativa filtroUO = new FiltroUnidadOperativa();
                filtroUO.Nivel = DatosConstantes.Nivel.Proyecto;
                var listaUO = unidadOperativaService.BuscarUnidadOperativa(filtroUO);
                var listaEdicion = politicaService.ListarEstadoEdicion();
                var listaTipoDocumento = politicaService.ListarTipoDocumentoRequerimiento();

                listaRegistros.Result = RequerimientoLogicRepository.ListaBandejaSolicitudRequerimientos(filtro.NumeroRequerimiento,
                    filtro.CodigoUnidadOperativa,
                    filtro.NombreProveedor,
                    filtro.NumeroDocProveedor);

                rpta.Result = new List<RequerimientoResponse>();
                foreach (RequerimientoLogic itemLogic in listaRegistros.Result)
                {
                    itemRpta = new RequerimientoResponse();
                    itemRpta = RequerimientoAdapter.ObtenerRequerimientoResponseDeLogic(itemLogic, listaUO.Result, null, null,
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
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Método para listar los documentos de la bandeja de revisión de Requerimientos.
        /// </summary>
        /// <param name="filtro">Información en el RequerimientoRequest</param>
        /// <returns>Lista de Requerimientos para revisión</returns>
        public ProcessResult<List<RequerimientoResponse>> ListaBandejaRevisionRequerimientos(RequerimientoRequest filtro)
        {
            ProcessResult<List<RequerimientoLogic>> listaRegistros = new ProcessResult<List<RequerimientoLogic>>();
            ProcessResult<List<RequerimientoResponse>> rpta = new ProcessResult<List<RequerimientoResponse>>();
            RequerimientoResponse itemRpta;
            try
            {
                FiltroUnidadOperativa filtroUO = new FiltroUnidadOperativa();
                filtroUO.Nivel = DatosConstantes.Nivel.Proyecto;
                var listaUO = unidadOperativaService.BuscarUnidadOperativa(filtroUO);
                var listaEdicion = politicaService.ListarEstadoEdicion();
                var listaTipoDocumento = politicaService.ListarTipoDocumentoRequerimiento();

                listaRegistros.Result = RequerimientoLogicRepository.ListaBandejaRevisionRequerimientos(filtro.NumeroRequerimiento,
                    filtro.CodigoUnidadOperativa,
                    filtro.NombreProveedor,
                    filtro.NumeroDocProveedor);

                rpta.Result = new List<RequerimientoResponse>();
                foreach (RequerimientoLogic itemLogic in listaRegistros.Result)
                {
                    itemRpta = new RequerimientoResponse();
                    itemRpta = RequerimientoAdapter.ObtenerRequerimientoResponseDeLogic(itemLogic, listaUO.Result, null, null,
                                                                    listaEdicion.Result, listaTipoDocumento.Result);

                    var usuarioModificacion = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = itemRpta.UsuarioCreacion }).Result.FirstOrDefault();
                    itemRpta.UsuarioCreacion = usuarioModificacion.NombreCompleto;

                    rpta.Result.Add(itemRpta);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Metodo para obtener datos de Requerimiento Estadio Observacion por el ID
        /// </summary>
        /// <param name="codigoRequerimiento">Id del Codigo Requerimiento Estadio Observacion </param>
        /// <returns>Requerimientos de estadio</returns>
        public ProcessResult<RequerimientoResponse> ObtieneRequerimientoPorID(Guid codigoRequerimiento)
        {
            ProcessResult<RequerimientoResponse> rpta = new ProcessResult<RequerimientoResponse>();
            try
            {
                var result = RequerimientoRepository.GetById(codigoRequerimiento);
                rpta.Result = new RequerimientoResponse();
                rpta.Result = RequerimientoAdapter.ObtenerRequerimientoResponseDeEntity(result);
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Registra la Respuesta de la Solicitud de Modificación del Requerimiento
        /// </summary>
        /// <param name="objCtr">Objeto request de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistraRespuestaRequerimiento(RequerimientoRequest objCtr)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                var Requerimiento = RequerimientoRepository.GetById(new Guid(objCtr.CodigoRequerimiento));
                var entUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = Requerimiento.CodigoUnidadOperativa.ToString() });
                List<RequerimientoDocumentoLogic> RequerimientoDocumento = new List<RequerimientoDocumentoLogic>();

                var RepositorioSharePoint = politicaService.ListarRepositorioSharePointSGC(null, "3");
                string SiteURL = sharePointService.RetornaSiteUrlSharePoint();

                Microsoft.SharePoint.Client.SharePointOnlineCredentials crdSHP = sharePointService.RetornaCredencialesServer();
                var lstMontoMinimo = politicaService.ListarMontoMinimoControlDinamico().Result;
                var montoMinimoPrm = lstMontoMinimo.Where(a => a.Atributo4 == Requerimiento.CodigoMoneda).FirstOrDefault().Atributo3;
                if (montoMinimoPrm == null)
                {
                    montoMinimoPrm = 0;
                }
                int resultProcesoAprobacion = -1;

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.SolicitudAutorizada) ||
                        objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.SolicitudDenegada) ||
                        objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.Editada))
                {
                    Requerimiento.RespuestaModificacion = objCtr.RespuestaModificacion;
                }
                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionAprobada))
                {
                    Requerimiento.CodigoEstado = DatosConstantes.EstadoRequerimiento.Aprobacion;
                }
                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionRechazada))
                {
                    Requerimiento.RespuestaModificacion = objCtr.RespuestaModificacion;
                    Requerimiento.ComentarioModificacion = objCtr.ComentarioModificacion;
                }

                Requerimiento.CodigoEstadoEdicion = objCtr.CodigoEstadoEdicion;

                RequerimientoRepository.Editar(Requerimiento, entornoAplicacion);
                resultado.Result = RequerimientoRepository.GuardarCambios();

                var listaRevisores = ObtenerListaRevisoresStracon(Requerimiento).Result;
                var listaFirmantes = ObtenerListaFirmantesStracon(new RequerimientoResponse() { CodigoRequerimiento = Requerimiento.CodigoRequerimiento, CodigoFlujoAprobacion = Requerimiento.CodigoFlujoAprobacion, CodigoProveedor = Requerimiento.CodigoProveedor }).Result;

                var urlLogo = politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.UrlLogoStracon).FirstOrDefault().Atributo3;
                var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.WidthLogo).FirstOrDefault().Atributo3);
                var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.HeightLogo).FirstOrDefault().Atributo3);

                //Obtener el usuario de creación del Requerimiento para reemplazarlo como responsable en el flujo
                var usuarioEstadio = string.Empty;

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionAprobada))
                {
                    var trabajadorEdicion = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = Requerimiento.UsuarioCreacion }).Result;

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
                        Guid newCodigoRequerimientoDoc = Guid.NewGuid();
                        #region InformacionRepositorioSharePoint
                        string NombreFile = string.Format("{0}.{1}", newCodigoRequerimientoDoc.ToString(), DatosConstantes.ArchivosRequerimiento.ExtensionValidaCarga);
                        ProcessResult<string> miDirectorio = RetornaDirectorioFile(Requerimiento.CodigoRequerimiento, entUnidadOperativa.Result[0].Nombre, NombreFile, Requerimiento.FechaInicioVigencia, false, RepositorioSharePoint.Result);
                        string lsDirectorioDestino = miDirectorio.Result.ToString();
                        string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });
                        string listName = nivelCarpeta[0];
                        string folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                        string hayError = string.Empty;
                        #endregion

                        #region GrabarContenidoRequerimientoSHP
                        ////MLV
                        //MemoryStream msFile = new MemoryStream(GenerarPdfDesdeHtml(objCtr.ContenidoRequerimiento, "", Requerimiento.NumeroRequerimiento, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));
                        var numeroCabecera = Requerimiento.NumeroAdenda > 0 ? string.IsNullOrEmpty(Requerimiento.NumeroAdendaConcatenado) ? Requerimiento.NumeroRequerimiento : Requerimiento.NumeroAdendaConcatenado : Requerimiento.NumeroRequerimiento;
                        MemoryStream msFile = new MemoryStream(GenerarPdfDesdeHtml(objCtr.ContenidoRequerimiento, "", numeroCabecera, null, Requerimiento.CodigoPlantilla, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));

                        if (msFile != null)
                        {
                            var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, NombreFile, msFile, SiteURL, crdSHP);
                            if (Convert.ToInt32(regSHP.Result) > 0)
                            {
                                RequerimientoDocumentoLogic cdl = new RequerimientoDocumentoLogic();
                                cdl.CodigoRequerimientoDocumento = newCodigoRequerimientoDoc;
                                cdl.CodigoRequerimiento = Requerimiento.CodigoRequerimiento;
                                cdl.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                                cdl.RutaArchivoSharePoint = lsDirectorioDestino;
                                cdl.Contenido = objCtr.ContenidoRequerimiento;
                                //El procedimiento se encarga de registrar el nuevo CD, inactivando los anteriores.
                                int regCD = RequerimientoLogicRepository.RegistraRequerimientoDocumentoCargaArchivo(cdl, entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal);
                                if (regCD != 1)
                                {
                                    /*Borramos el documento subido al SHP.*/
                                    var fileShpDelete = sharePointService.EliminaArchivoSharePoint(new List<int>() { cdl.CodigoArchivo }, listName, ref hayError);
                                    resultado.Result = "";
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("Problemas al registrar el Requerimiento Documento Entity: Requerimiento-Service : RegistraRespuestaRequerimiento");
                                    return resultado;
                                }
                            }
                        }
                        else
                        {
                            resultado.Result = hayError;
                            resultado.IsSuccess = false;
                            resultado.Exception = new ApplicationLayerException<RequerimientoService>("Problemas al registrar nueva Version de Documento en SharePoint");
                            return resultado;
                        }
                        #endregion
                    }
                    if (Convert.ToInt32(resultado.Result) == 1 && objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionAprobada))
                    {
                        RequerimientoDocumento = RequerimientoLogicRepository.DocumentosPorRequerimiento(Requerimiento.CodigoRequerimiento);

                        if (RequerimientoDocumento != null && RequerimientoDocumento.Count > 0)
                        {
                            resultProcesoAprobacion = RequerimientoLogicRepository.ApruebaRequerimientoEstadio((Guid)RequerimientoDocumento[0].CodigoRequerimientoEstadio,
                                                                            entUnidadOperativa.Result[0].CodigoIdentificacion,
                                                                            entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal, usuarioEstadio, "");
                            if (resultProcesoAprobacion != 1)
                            {
                                resultado.Result = "Problemas al registrar la aprobación del Requerimiento.";
                                resultado.IsSuccess = false;
                                resultado.Exception = new ApplicationLayerException<RequerimientoService>("Problemas al registrar la aprobación del Requerimiento");
                                tsc.Dispose();
                            }
                        }
                        else
                        {
                            resultado.Result = "No se generó correctamente el Codigo del Requerimiento Estadío. Requerimiento Service - RegistraRespuestaRequerimiento.";
                            resultado.IsSuccess = false;
                            resultado.Exception = new ApplicationLayerException<RequerimientoService>("No se generó correctamente el Codigo del Requerimiento Estadío. Requerimiento Service - RegistraRespuestaRequerimiento.");
                            tsc.Dispose();
                        }
                    }
                    tsc.Complete();
                }

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionRechazada))
                {
                    var RequerimientoEstadioEdicion = RequerimientoLogicRepository.ObtenerRequerimientoEstadioEdicion(Requerimiento.CodigoRequerimiento, Requerimiento.CodigoFlujoAprobacion);
                    generaNotificacionCorreo(DatosConstantes.TipoNotificacion.RequerimientoRechazadoPorLegal, RequerimientoEstadioEdicion, null, null, null, null, Requerimiento.UsuarioCreacion);
                }
                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionAprobada))
                {
                    RequerimientoEstadioEntity entidadRequerimientoEstadio = RequerimientoEstadioRepository.GetById(RequerimientoDocumento[0].CodigoRequerimientoEstadio);
                    FlujoAprobacionEstadioEntity entidadFlujoAprobacionEstadio = flujoAprobacionEstadioRepository.GetById(entidadRequerimientoEstadio.CodigoFlujoAprobacionEstadio);

                    var codigoResponsable = flujoAprobacionLogicRepository.ObtenerResponsableSiguienteEstadioFlujoAprobacion((Guid)Requerimiento.CodigoFlujoAprobacion, entidadFlujoAprobacionEstadio.Orden, entidadFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio, entidadRequerimientoEstadio.CodigoRequerimientoEstadio);
                    generaNotificacionCorreo(DatosConstantes.TipoNotificacion.NuevoRequerimientoBandeja, entidadRequerimientoEstadio.CodigoRequerimientoEstadio, null, null, null, null, null, codigoResponsable);
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ProcessResult<List<ReporteRequerimientoObservadoAprobadoResponse>> BuscarNumeroRequerimiento(ReporteRequerimientoObservadoAprobadoRequest filtro)
        {
            ProcessResult<List<ReporteRequerimientoObservadoAprobadoResponse>> resultado = new ProcessResult<List<ReporteRequerimientoObservadoAprobadoResponse>>();

            try
            {

                List<RequerimientoLogic> listado = RequerimientoLogicRepository.BuscarNumeroRequerimiento(
                                                                                                 filtro.CodigoUnidadOperativa,
                                                                                                 filtro.NumeroRequerimiento,
                                                                                                 filtro.NumeroPagina,
                                                                                                 filtro.RegistrosPagina
                                                                                                 );

                resultado.Result = new List<ReporteRequerimientoObservadoAprobadoResponse>();

                foreach (var registro in listado)
                {
                    var Requerimiento = RequerimientoAdapter.ObtenerNumeroRequerimientoPaginado(registro);
                    resultado.Result.Add(Requerimiento);
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);

                //resultado.Result    = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }

            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ProcessResult<List<ReporteRequerimientoObservadoAprobadoResponse>> BuscarRequerimientoObservadoAprobado(ReporteRequerimientoObservadoAprobadoRequest filtro)
        {
            ProcessResult<List<ReporteRequerimientoObservadoAprobadoResponse>> resultado = new ProcessResult<List<ReporteRequerimientoObservadoAprobadoResponse>>();

            try
            {
                Guid? codigoUnidadOperativa = filtro.CodigoUnidadOperativa != null ? filtro.CodigoUnidadOperativa : (Guid?)null;
                Guid? codigoRequerimiento = filtro.CodigoRequerimiento != null ? filtro.CodigoRequerimiento : (Guid?)null;
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


                List<RequerimientoObservadoAprobadoLogic> listado = RequerimientoLogicRepository.BuscarRequerimientoObservadoAprobado(codigoUnidadOperativa,
                                                                                                                       codigoRequerimiento,
                                                                                                                       filtro.TipoAccionRequerimiento,
                                                                                                                       fechaInicioVigencia,
                                                                                                                       fechaFinVigencia,
                                                                                                                       nombreBaseDatoPolitica,
                                                                                                                       filtro.NumeroPagina,
                                                                                                                       filtro.RegistrosPagina);
                resultado.Result = new List<ReporteRequerimientoObservadoAprobadoResponse>();

                foreach (var registro in listado)
                {
                    var Requerimiento = RequerimientoAdapter.ObtenerRequerimientoObservadoAprobadoPaginado(registro);

                    if (Requerimiento.AccionPor != null && Requerimiento.AccionPor != "")
                    {
                        var usuarioAccion = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = Requerimiento.AccionPor }).Result.FirstOrDefault();
                        if (usuarioAccion != null)
                        {
                            Requerimiento.AccionPor = usuarioAccion.NombreCompleto;
                        }
                        else
                        {
                            Requerimiento.AccionPor = null;
                        }
                    }

                    if (Requerimiento.UsuarioRespuesta != null && Requerimiento.UsuarioRespuesta != "")
                    {
                        var usuarioRespuesta = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = Requerimiento.UsuarioRespuesta }).Result.FirstOrDefault();
                        if (usuarioRespuesta != null)
                        {
                            Requerimiento.UsuarioRespuesta = usuarioRespuesta.NombreCompleto;
                        }
                        else
                        {
                            Requerimiento.UsuarioRespuesta = null;
                        }
                    }
                    resultado.Result.Add(Requerimiento);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }


        /// <summary>
        /// Registra la Respuesta de la Solicitud de Modificación del Requerimiento para revisión
        /// </summary>
        /// <param name="objCtr">Objeto request de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistraRespuestaRequerimientoRevision(RequerimientoRequest objCtr)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                var Requerimiento = RequerimientoRepository.GetById(new Guid(objCtr.CodigoRequerimiento));
                var entUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = Requerimiento.CodigoUnidadOperativa.ToString() });
                List<RequerimientoDocumentoLogic> RequerimientoDocumento = new List<RequerimientoDocumentoLogic>();

                var RepositorioSharePoint = politicaService.ListarRepositorioSharePointSGC(null, "3");
                string SiteURL = sharePointService.RetornaSiteUrlSharePoint();

                Microsoft.SharePoint.Client.SharePointOnlineCredentials crdSHP = sharePointService.RetornaCredencialesServer();
                var lstMontoMinimo = politicaService.ListarMontoMinimoControlDinamico().Result;
                var montoMinimoPrm = lstMontoMinimo.Where(a => a.Atributo4 == Requerimiento.CodigoMoneda).FirstOrDefault().Atributo3;
                if (montoMinimoPrm == null)
                {
                    montoMinimoPrm = 0;
                }
                int resultProcesoAprobacion = -1;

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.SolicitudAutorizada) ||
                        objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.SolicitudDenegada) ||
                        objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.Editada))
                {
                    Requerimiento.RespuestaModificacion = objCtr.RespuestaModificacion;
                }
                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionAprobada))
                {
                    Requerimiento.CodigoEstado = DatosConstantes.EstadoRequerimiento.Revision;
                }
                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.RevisionAprobada))
                {
                    Requerimiento.CodigoEstado = DatosConstantes.EstadoRequerimiento.Aprobacion;
                }
                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionRechazada) || objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.RevisionRechazada))
                {
                    Requerimiento.RespuestaModificacion = objCtr.RespuestaModificacion;
                }

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionAprobada))
                {
                    Requerimiento.CodigoEstadoEdicion = DatosConstantes.CodigoEstadoEdicion.RevisionRevisada;
                }
                else
                {
                    Requerimiento.CodigoEstadoEdicion = objCtr.CodigoEstadoEdicion;
                }

                RequerimientoRepository.Editar(Requerimiento, entornoAplicacion);
                resultado.Result = RequerimientoRepository.GuardarCambios();

                var listaRevisores = ObtenerListaRevisoresStracon(Requerimiento).Result;
                var listaFirmantes = ObtenerListaFirmantesStracon(new RequerimientoResponse() { CodigoRequerimiento = Requerimiento.CodigoRequerimiento, CodigoFlujoAprobacion = Requerimiento.CodigoFlujoAprobacion, CodigoProveedor = Requerimiento.CodigoProveedor }).Result;

                var urlLogo = politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.UrlLogoStracon).FirstOrDefault().Atributo3;
                var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.WidthLogo).FirstOrDefault().Atributo3);
                var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.HeightLogo).FirstOrDefault().Atributo3);

                //Obtener el usuario de creación del Requerimiento para reemplazarlo como responsable en el flujo
                var usuarioEstadio = string.Empty;

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.RevisionAprobada))
                {
                    var trabajadorEdicion = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = Requerimiento.UsuarioCreacion }).Result;

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
                        Guid newCodigoRequerimientoDoc = Guid.NewGuid();
                        #region InformacionRepositorioSharePoint
                        string NombreFile = string.Format("{0}.{1}", newCodigoRequerimientoDoc.ToString(), DatosConstantes.ArchivosRequerimiento.ExtensionValidaCarga);
                        ProcessResult<string> miDirectorio = RetornaDirectorioFile(Requerimiento.CodigoRequerimiento, entUnidadOperativa.Result[0].Nombre, NombreFile, Requerimiento.FechaInicioVigencia, false, RepositorioSharePoint.Result);
                        string lsDirectorioDestino = miDirectorio.Result.ToString();
                        string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });
                        string listName = nivelCarpeta[0];
                        string folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                        string hayError = string.Empty;
                        #endregion

                        #region GrabarContenidoRequerimientoSHP
                        ////MLV
                        //MemoryStream msFile = new MemoryStream(GenerarPdfDesdeHtml(objCtr.ContenidoRequerimiento, "", Requerimiento.NumeroRequerimiento, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));
                        var numeroCabecera = Requerimiento.NumeroAdenda > 0 ? string.IsNullOrEmpty(Requerimiento.NumeroAdendaConcatenado) ? Requerimiento.NumeroRequerimiento : Requerimiento.NumeroAdendaConcatenado : Requerimiento.NumeroRequerimiento;
                        MemoryStream msFile = new MemoryStream(GenerarPdfDesdeHtml(objCtr.ContenidoRequerimiento, "", numeroCabecera, null, Requerimiento.CodigoPlantilla, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));

                        if (msFile != null)
                        {
                            var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, NombreFile, msFile, SiteURL, crdSHP);
                            if (Convert.ToInt32(regSHP.Result) > 0)
                            {
                                RequerimientoDocumentoLogic cdl = new RequerimientoDocumentoLogic();
                                cdl.CodigoRequerimientoDocumento = newCodigoRequerimientoDoc;
                                cdl.CodigoRequerimiento = Requerimiento.CodigoRequerimiento;
                                cdl.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                                cdl.RutaArchivoSharePoint = lsDirectorioDestino;
                                cdl.Contenido = objCtr.ContenidoRequerimiento;
                                //El procedimiento se encarga de registrar el nuevo CD, inactivando los anteriores.
                                int regCD = RequerimientoLogicRepository.RegistraRequerimientoDocumentoCargaArchivo(cdl, entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal);
                                if (regCD != 1)
                                {
                                    /*Borramos el documento subido al SHP.*/
                                    var fileShpDelete = sharePointService.EliminaArchivoSharePoint(new List<int>() { cdl.CodigoArchivo }, listName, ref hayError);
                                    resultado.Result = "";
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("Problemas al registrar el Requerimiento Documento Entity: Requerimiento-Service : RegistraRespuestaRequerimiento");
                                    return resultado;
                                }
                            }
                        }
                        else
                        {
                            resultado.Result = hayError;
                            resultado.IsSuccess = false;
                            resultado.Exception = new ApplicationLayerException<RequerimientoService>("Problemas al registrar nueva Version de Documento en SharePoint");
                            return resultado;
                        }
                        #endregion
                    }
                    if (Convert.ToInt32(resultado.Result) == 1 && objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.RevisionAprobada))
                    {
                        RequerimientoDocumento = RequerimientoLogicRepository.DocumentosPorRequerimiento(Requerimiento.CodigoRequerimiento);
                        if (RequerimientoDocumento != null && RequerimientoDocumento.Count > 0)
                        {
                            resultProcesoAprobacion = RequerimientoLogicRepository.ApruebaRequerimientoEstadio((Guid)RequerimientoDocumento[0].CodigoRequerimientoEstadio,
                                                                            entUnidadOperativa.Result[0].CodigoIdentificacion,
                                                                            entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal, usuarioEstadio, "");
                            if (resultProcesoAprobacion != 1)
                            {
                                resultado.Result = "Problemas al registrar la aprobación del Requerimiento.";
                                resultado.IsSuccess = false;
                                resultado.Exception = new ApplicationLayerException<RequerimientoService>("Problemas al registrar la aprobación del Requerimiento");
                                tsc.Dispose();
                            }
                        }
                        else
                        {
                            resultado.Result = "No se generó correctamente el Codigo del Requerimiento Estadío. Requerimiento Service - RegistraRespuestaRequerimiento.";
                            resultado.IsSuccess = false;
                            resultado.Exception = new ApplicationLayerException<RequerimientoService>("No se generó correctamente el Codigo del Requerimiento Estadío. Requerimiento Service - RegistraRespuestaRequerimiento.");
                            tsc.Dispose();
                        }
                    }
                    tsc.Complete();
                }

                if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.EdicionRechazada) || objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.RevisionRechazada))
                {
                    var RequerimientoEstadioEdicion = RequerimientoLogicRepository.ObtenerRequerimientoEstadioEdicion(Requerimiento.CodigoRequerimiento, Requerimiento.CodigoFlujoAprobacion);
                    generaNotificacionCorreo(DatosConstantes.TipoNotificacion.RequerimientoRechazadoPorLegal, RequerimientoEstadioEdicion, null, null, null, null, Requerimiento.UsuarioCreacion);
                }

                else if (objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.RevisionAprobada))
                {
                    RequerimientoEstadioEntity entidadRequerimientoEstadio = RequerimientoEstadioRepository.GetById(RequerimientoDocumento[0].CodigoRequerimientoEstadio);
                    FlujoAprobacionEstadioEntity entidadFlujoAprobacionEstadio = flujoAprobacionEstadioRepository.GetById(entidadRequerimientoEstadio.CodigoFlujoAprobacionEstadio);

                    var codigoResponsable = flujoAprobacionLogicRepository.ObtenerResponsableSiguienteEstadioFlujoAprobacion((Guid)Requerimiento.CodigoFlujoAprobacion, entidadFlujoAprobacionEstadio.Orden, entidadFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio, entidadRequerimientoEstadio.CodigoRequerimientoEstadio);
                    generaNotificacionCorreo(DatosConstantes.TipoNotificacion.NuevoRequerimientoBandeja, entidadRequerimientoEstadio.CodigoRequerimientoEstadio, null, null, null, null, null, codigoResponsable);
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Registra la Respuesta de la Soliitud de Modificacion del Requerimiento
        /// </summary>
        /// <param name="objCtr">Objeto request de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistrarRespuestaGrabarRequerimiento(RequerimientoRequest objCtr)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                var Requerimiento = RequerimientoRepository.GetById(new Guid(objCtr.CodigoRequerimiento));
                var entUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = Requerimiento.CodigoUnidadOperativa.ToString() });
                var RepositorioSharePoint = politicaService.ListarRepositorioSharePointSGC(null, "3");
                string SiteURL = sharePointService.RetornaSiteUrlSharePoint();

                Microsoft.SharePoint.Client.SharePointOnlineCredentials crdSHP = sharePointService.RetornaCredencialesServer();
                var lstMontoMinimo = politicaService.ListarMontoMinimoControlDinamico().Result;
                var montoMinimoPrm = lstMontoMinimo.Where(a => a.Atributo4 == Requerimiento.CodigoMoneda).FirstOrDefault().Atributo3;
                if (montoMinimoPrm == null)
                {
                    montoMinimoPrm = 0;
                }

                RequerimientoRepository.Editar(Requerimiento, entornoAplicacion);
                resultado.Result = RequerimientoRepository.GuardarCambios();
                //17-04-2017 FIN 
                var listaRevisores = ObtenerListaRevisoresStracon(Requerimiento).Result;
                var listaFirmantes = ObtenerListaFirmantesStracon(new RequerimientoResponse() { CodigoRequerimiento = Requerimiento.CodigoRequerimiento, CodigoFlujoAprobacion = Requerimiento.CodigoFlujoAprobacion, CodigoProveedor = Requerimiento.CodigoProveedor }).Result;

                var urlLogo = politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.UrlLogoStracon).FirstOrDefault().Atributo3;
                var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.WidthLogo).FirstOrDefault().Atributo3);
                var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.HeightLogo).FirstOrDefault().Atributo3);

                using (TransactionScope tsc = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (Convert.ToInt32(resultado.Result) == 1 && objCtr.CodigoEstadoEdicion.Equals(DatosConstantes.CodigoEstadoEdicion.Editada))
                    {
                        Guid newCodigoRequerimientoDoc = Guid.NewGuid();
                        #region InformacionRepositorioSharePoint
                        string NombreFile = string.Format("{0}.{1}", newCodigoRequerimientoDoc.ToString(), DatosConstantes.ArchivosRequerimiento.ExtensionValidaCarga);
                        ProcessResult<string> miDirectorio = RetornaDirectorioFile(Requerimiento.CodigoRequerimiento, entUnidadOperativa.Result[0].Nombre, NombreFile, Requerimiento.FechaInicioVigencia, false, RepositorioSharePoint.Result);
                        string lsDirectorioDestino = miDirectorio.Result.ToString();
                        string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });
                        string listName = nivelCarpeta[0];
                        string folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                        string hayError = string.Empty;
                        #endregion

                        #region GrabarContenidoRequerimientoSHP
                        //MLV
                        //MemoryStream msFile = new MemoryStream(GenerarPdfDesdeHtml(objCtr.ContenidoRequerimiento, "", Requerimiento.NumeroRequerimiento, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));
                        var numeroCabecera = Requerimiento.NumeroAdenda > 0 ? string.IsNullOrEmpty(Requerimiento.NumeroAdendaConcatenado) ? Requerimiento.NumeroRequerimiento : Requerimiento.NumeroAdendaConcatenado : Requerimiento.NumeroRequerimiento;
                        MemoryStream msFile = new MemoryStream(GenerarPdfDesdeHtml(objCtr.ContenidoRequerimiento, "", numeroCabecera, Requerimiento.CodigoRequerimiento, Requerimiento.CodigoPlantilla, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));

                        if (msFile != null)
                        {
                            var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, NombreFile, msFile, SiteURL, crdSHP);
                            if (Convert.ToInt32(regSHP.Result) > 0)
                            {
                                RequerimientoDocumentoLogic cdl = new RequerimientoDocumentoLogic();
                                cdl.CodigoRequerimientoDocumento = newCodigoRequerimientoDoc;
                                cdl.CodigoRequerimiento = Requerimiento.CodigoRequerimiento;
                                cdl.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                                cdl.RutaArchivoSharePoint = lsDirectorioDestino;
                                cdl.Contenido = objCtr.ContenidoRequerimiento;
                                //El procedimiento se encarga de registrar el nuevo CD, inactivando los anteriores.
                                int regCD = RequerimientoLogicRepository.RegistraRequerimientoDocumentoCargaArchivo(cdl, entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal);
                                if (regCD != 1)
                                {
                                    /*Borramos el documento subido al SHP.*/
                                    var fileShpDelete = sharePointService.EliminaArchivoSharePoint(new List<int>() { cdl.CodigoArchivo }, listName, ref hayError);
                                    resultado.Result = "";
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("Problemas al registrar el Requerimiento Documento Entity: Requerimiento-Service : RegistraRespuestaRequerimiento");
                                    return resultado;
                                }
                            }
                        }
                        else
                        {
                            resultado.Result = hayError;
                            resultado.IsSuccess = false;
                            resultado.Exception = new ApplicationLayerException<RequerimientoService>("Problemas al registrar nueva Version de Documento en SharePoint");
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
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }


        /// <summary>
        /// Método para retornar los documentos PDf por Requerimiento
        /// </summary>
        /// <param name="CodigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Documentos PDF</returns>
        public ProcessResult<List<RequerimientoDocumentoResponse>> DocumentosPorRequerimiento(Guid CodigoRequerimiento)
        {
            ProcessResult<List<RequerimientoDocumentoResponse>> rpta = new ProcessResult<List<RequerimientoDocumentoResponse>>();
            try
            {
                RequerimientoDocumentoResponse cdrEntidad;
                var result = RequerimientoLogicRepository.DocumentosPorRequerimiento(CodigoRequerimiento);
                rpta.Result = new List<RequerimientoDocumentoResponse>();
                foreach (RequerimientoDocumentoLogic item in result)
                {
                    cdrEntidad = RequerimientoAdapter.ObtenerRequerimientoDocumentoResponseDeLogic(item);
                    rpta.Result.Add(cdrEntidad);
                }
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Método para retornar los documentos adjuntos por Requerimiento
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al Requerimiento</returns>
        public ProcessResult<List<RequerimientoDocumentoAdjuntoResponse>> BuscarRequerimientoDocumentoAdjunto(RequerimientoDocumentoAdjuntoRequest request)
        {
            ProcessResult<List<RequerimientoDocumentoAdjuntoResponse>> resultado = new ProcessResult<List<RequerimientoDocumentoAdjuntoResponse>>();
            try
            {
                var result = RequerimientoDocumentoAdjuntoLogicRepository.BuscarRequerimientoDocumentoAdjunto(
                    request.CodigoRequerimientoDocumentoAdjunto,
                    request.CodigoRequerimiento,
                    request.CodigoArchivo,
                    request.NombreArchivo,
                    DatosConstantes.EstadoRegistro.Activo
                    );
                resultado.Result = new List<RequerimientoDocumentoAdjuntoResponse>();

                foreach (var item in result)
                {
                    resultado.Result.Add(RequerimientoAdapter.ObtenerRequerimientoDocumentoAdjuntoResponseDeLogic(item));
                }
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProcessResult<List<RequerimientoDocumentoAdjuntoResolucionResponse>> BuscarRequerimientoDocumentoAdjuntoResolucion(RequerimientoDocumentoAdjuntoResolucionRequest request)
        {
            ProcessResult<List<RequerimientoDocumentoAdjuntoResolucionResponse>> resultado = new ProcessResult<List<RequerimientoDocumentoAdjuntoResolucionResponse>>();
            try
            {
                var result = RequerimientoDocumentoAdjuntoResolucionLogicRepository.BuscarRequerimientoDocumentoAdjuntoResolucion(
                    request.CodigoRequerimientoDocumentoAdjuntoResolucion,
                    request.CodigoRequerimiento,
                    request.CodigoArchivo,
                    request.NombreArchivo,
                    DatosConstantes.EstadoRegistro.Activo
                    );
                resultado.Result = new List<RequerimientoDocumentoAdjuntoResolucionResponse>();

                foreach (var item in result)
                {
                    var trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = item.UsuarioCreacion }).Result.FirstOrDefault();

                    resultado.Result.Add(RequerimientoAdapter.ObtenerRequerimientoDocumentoAdjuntoResolucionResponseDeLogic(item, trabajador.NombreCompleto));
                }
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Método para registra los documentos adjuntos por Requerimiento
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al Requerimiento</returns>
        public ProcessResult<string> RegistrarRequerimientoDocumentoAdjunto(RequerimientoDocumentoAdjuntoRequest request)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                var RequerimientoEntity = RequerimientoRepository.GetById(request.CodigoRequerimiento.Value);

                if (!(RequerimientoEntity.CodigoEstado == DatosConstantes.EstadoRequerimiento.Edicion || RequerimientoEntity.CodigoEstado == DatosConstantes.EstadoRequerimiento.Aprobacion
                    || RequerimientoEntity.CodigoEstado == DatosConstantes.EstadoRequerimiento.Vencido || RequerimientoEntity.CodigoEstado == DatosConstantes.EstadoRequerimiento.Vigente))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("El Requerimiento no se encuentra en Estado de Edición, Aprobación, Vencido o Vigente");
                    return resultado;
                }

                //Registro de información
                string hayError = string.Empty;
                var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = request.CodigoUnidadOperativa.ToString() });

                request.CodigoRequerimientoDocumentoAdjunto = Guid.NewGuid();
                #region InformacionRepositorioSharePoint
                string nombreArchivo = string.Format("{0}.{1}", request.CodigoRequerimientoDocumentoAdjunto.ToString(), request.ExtencionArchivo);
                ProcessResult<string> miDirectorio = RetornaDirectorioFile(request.CodigoRequerimiento.Value, unidadOperativa.Result[0].Nombre, nombreArchivo, null, true);
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
                        resultado.Exception = new ApplicationLayerException<RequerimientoService>("Ocurrió un problema al registra el archivo en el SharePoint: " + hayError);
                        LogBL.grabarLogError(new Exception(hayError));
                        return resultado;
                    }
                }
                else
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("Ocurrió un problema al subir el documento.");
                    LogBL.grabarLogError(new Exception("Ocurrió un problema al subir el documento"));
                    return resultado;
                }
                #endregion

                #region Grabar registro del documento adjunto
                RequerimientoDocumentoAdjuntoEntityRepository.Insertar(RequerimientoAdapter.ObtenerRequerimientoDocumentoAdjuntoEntityDeRequest(request));
                RequerimientoDocumentoAdjuntoEntityRepository.GuardarCambios();
                #endregion
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Se registra el documento adjunto de resolución, de momento sólo guarda un archivo
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProcessResult<string> RegistrarRequerimientoDocumentoAdjuntoResolucion(RequerimientoDocumentoAdjuntoResolucionRequest request)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                var RequerimientoEntity = RequerimientoRepository.GetById(request.CodigoRequerimiento.Value);

                if (!(RequerimientoEntity.CodigoEstado == DatosConstantes.EstadoRequerimiento.Vigente))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("El Requerimiento no se encuentra en Estado de Vigente");
                    return resultado;
                }

                if (!(request.ValidacionResolucion == DatosConstantes.TipoValidacionRequerimientoResolucion.Cumple_Carga))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("Este Requerimiento ya fue anteriormente actualizado.");
                    return resultado;
                }

                String[] resolucion = request.FechaResolucionString.Split('/');
                String[] fecha_fin = request.FechaFinVigenciaString.Split('/');

                request.FechaResolucion = new DateTime(Convert.ToInt32(resolucion[2]), Convert.ToInt32(resolucion[1]), Convert.ToInt32(resolucion[0]));
                DateTime fechafin = new DateTime(Convert.ToInt32(fecha_fin[2]), Convert.ToInt32(fecha_fin[1]), Convert.ToInt32(fecha_fin[0]));

                if (request.FechaResolucion > fechafin)
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("La fecha de resolución no puede ser mayor a la fecha de fin de vigencia.");
                    return resultado;
                }

                //Registro de información
                string hayError = string.Empty;
                var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = request.CodigoUnidadOperativa.ToString() });

                request.CodigoRequerimientoDocumentoAdjuntoResolucion = Guid.NewGuid();
                #region InformacionRepositorioSharePoint
                string nombreArchivo = string.Format("{0}.{1}", request.CodigoRequerimientoDocumentoAdjuntoResolucion.ToString(), request.ExtencionArchivo);
                ProcessResult<string> miDirectorio = RetornaDirectorioFile(request.CodigoRequerimiento.Value, unidadOperativa.Result[0].Nombre, nombreArchivo, null, true);
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
                        resultado.Exception = new ApplicationLayerException<RequerimientoService>("Ocurrió un problema al registra el archivo en el SharePoint: " + hayError);
                        LogBL.grabarLogError(new Exception(hayError));
                        return resultado;
                    }
                }
                else
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("Ocurrió un problema al subir el documento.");
                    LogBL.grabarLogError(new Exception("Ocurrió un problema al subir el documento"));
                    return resultado;
                }
                #endregion

                #region Grabar registro del documento adjunto
                try
                {
                    var result = RequerimientoDocumentoAdjuntoResolucionLogicRepository.Insertar_Documento_Adjunto_Resolucion(
                        request.CodigoRequerimiento,
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
                    resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
                    LogBL.grabarLogError(new Exception("Ocurrió un problema al insertar en la tabla Documento Adjunto Resolución"));
                }
                return resultado;

                #endregion
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>("AAAA", ex);
                LogBL.grabarLogError(new Exception("Ocurrió un problema al validar los parametros de lógica"));
            }
            return resultado;
        }

        /// <summary>
        /// Método que elimina los documentos adjuntos al Requerimiento
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al Requerimiento</returns>
        public ProcessResult<string> EliminarRequerimientoDocumentoAdjunto(RequerimientoDocumentoAdjuntoRequest request)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                var RequerimientoDocumentoAdjuntoEntity = RequerimientoDocumentoAdjuntoEntityRepository.GetById(request.CodigoRequerimientoDocumentoAdjunto.Value);

                var RequerimientoEntity = RequerimientoRepository.GetById(RequerimientoDocumentoAdjuntoEntity.CodigoRequerimiento);

                if (!(RequerimientoEntity.CodigoEstado == DatosConstantes.EstadoRequerimiento.Edicion || RequerimientoEntity.CodigoEstado == DatosConstantes.EstadoRequerimiento.Aprobacion))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("El Requerimiento se encuentra en Estado de Edición o en Aprobación");
                    return resultado;
                }

                if (!(RequerimientoDocumentoAdjuntoEntity.UsuarioCreacion == entornoAplicacion.UsuarioSession))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("El documento adjunto solo puede ser eliminado por el propietario del mismo");
                    return resultado;
                }

                #region Grabar registro del documento adjunto
                RequerimientoDocumentoAdjuntoEntityRepository.Eliminar(request.CodigoRequerimientoDocumentoAdjunto);
                RequerimientoDocumentoAdjuntoEntityRepository.GuardarCambios();
                #endregion
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Elimina el adjunto de la resolución del Requerimiento S09-SGC-01
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProcessResult<string> EliminarRequerimientoDocumentoAdjuntoResolucion(RequerimientoDocumentoAdjuntoResolucionRequest request)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                var RequerimientoDocumentoAdjuntoResolucionEntity = RequerimientoDocumentoAdjuntoResolucionEntityRepository.GetById(request.CodigoRequerimientoDocumentoAdjuntoResolucion.Value);

                var RequerimientoEntity = RequerimientoRepository.GetById(RequerimientoDocumentoAdjuntoResolucionEntity.CodigoRequerimiento);

                if (!(RequerimientoEntity.CodigoEstado == DatosConstantes.EstadoRequerimiento.Edicion || RequerimientoEntity.CodigoEstado == DatosConstantes.EstadoRequerimiento.Aprobacion))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("El Requerimiento se encuentra en Estado de Edición o en Aprobación");
                    return resultado;
                }

                if (!(RequerimientoDocumentoAdjuntoResolucionEntity.UsuarioCreacion == entornoAplicacion.UsuarioSession))
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("El documento adjunto solo puede ser eliminado por el propietario del mismo");
                    return resultado;
                }

                #region Grabar registro del documento adjunto
                RequerimientoDocumentoAdjuntoResolucionEntityRepository.Eliminar(request.CodigoRequerimientoDocumentoAdjuntoResolucion);
                RequerimientoDocumentoAdjuntoResolucionEntityRepository.GuardarCambios();
                #endregion
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Retorna la ruta del directorio SharePoint para escribir el archivo.
        /// </summary>
        /// <param name="codigoRequerimiento">Código del Requerimiento</param>
        /// <param name="nombreUnidadOperativa">código de la unidad operativa</param>
        /// <param name="nombreFile">Nombre del archivo</param>
        /// <param name="fechaInicioVigencia">Fecha de Inicio de Vigencia</param>
        /// <param name="esAdjunto">Indica que un documento es adjunto</param>
        /// <param name="lstPrmRepositorioShp">Lista del repositorio de SharePoint</param>
        /// <returns>Ruta de directorio de sharepoint</returns>
        public ProcessResult<string> RetornaDirectorioFile(Guid codigoRequerimiento, string nombreUnidadOperativa,
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
                    var entRequerimiento = RequerimientoRepository.GetById(codigoRequerimiento);
                    Anio = entRequerimiento.FechaInicioVigencia.Year;
                    Mes = entRequerimiento.FechaInicioVigencia.Month;
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
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }
        /// <summary>
        /// Metodo para cargar un Archivo a un estadio de Requerimiento.
        /// </summary>
        /// <param name="objRsp">Objeto Requerimiento Documento Response</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> RegistraRequerimientoDocumentoCargaArchivo(RequerimientoDocumentoResponse objRsp)
        {
            ProcessResult<Object> objRpta = new ProcessResult<Object>();
            try
            {
                RequerimientoDocumentoLogic objLogic = RequerimientoAdapter.ObtenerRequerimientoDocumentoLogicDeResponse(objRsp);
                objRpta.Result = RequerimientoLogicRepository.RegistraRequerimientoDocumentoCargaArchivo(objLogic, entornoAplicacion.UsuarioSession, entornoAplicacion.Terminal);
            }
            catch (Exception ex)
            {
                objRpta.Result = -1;
                objRpta.IsSuccess = false;
                objRpta.Exception = new ApplicationLayerException<RequerimientoService>(ex.Message);
            }
            return objRpta;
        }

        /// <summary>
        /// Metodo que retorna los bytes para la generación del archivo PDF.
        /// </summary>
        /// <param name="request">Código del Requerimiento</param>
        /// <returns>Bytes para generar pdf</returns>
        public ProcessResult<RequerimientoDocumentoAdjuntoResponse> ObtenerArchivoAdjunto(RequerimientoDocumentoAdjuntoRequest request)
        {
            ProcessResult<RequerimientoDocumentoAdjuntoResponse> resultado = new ProcessResult<RequerimientoDocumentoAdjuntoResponse>();
            try
            {
                var RequerimientoDocumentoAdjuntoResponse = new RequerimientoDocumentoAdjuntoResponse();


                var documentoAdjunto = RequerimientoDocumentoAdjuntoEntityRepository.GetById(request.CodigoRequerimientoDocumentoAdjunto);

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
                    RequerimientoDocumentoAdjuntoResponse.NombreArchivo = documentoAdjunto.NombreArchivo;
                    RequerimientoDocumentoAdjuntoResponse.ContenidoArchivo = contenidoArchivo.Result;

                    resultado.Result = RequerimientoDocumentoAdjuntoResponse;
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                //resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene el archivo adjunto de resolución de Requerimiento S09-SGC-01
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ProcessResult<RequerimientoDocumentoAdjuntoResolucionResponse> ObtenerArchivoAdjuntoResolucion(RequerimientoDocumentoAdjuntoResolucionRequest request)
        {
            ProcessResult<RequerimientoDocumentoAdjuntoResolucionResponse> resultado = new ProcessResult<RequerimientoDocumentoAdjuntoResolucionResponse>();
            try
            {
                var RequerimientoDocumentoAdjuntoResponse = new RequerimientoDocumentoAdjuntoResolucionResponse();

                //var documentoAdjunto = RequerimientoDocumentoAdjuntoResolucionEntityRepository.GetById(request.CodigoRequerimientoDocumentoAdjuntoResolucion);

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
                    RequerimientoDocumentoAdjuntoResponse.NombreArchivo = request.NombreArchivo;
                    RequerimientoDocumentoAdjuntoResponse.ContenidoArchivo = contenidoArchivo.Result;

                    resultado.Result = RequerimientoDocumentoAdjuntoResponse;
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                //resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Metodo que retorna los bytes para la generación del archivo PDF.
        /// </summary>
        /// <param name="codigoRequerimiento">Código del Requerimiento</param>
        /// <param name="codigoRequerimientoEstadio">código del Requerimiento - estadio.</param>
        /// <param name="nombreArchivoRequerimiento">Nombre del archivo a descargar</param>
        /// <param name="linkFileCss"></param>
        /// <returns>Bytes para generar pdf</returns>
        public ProcessResult<Object> GenerarContenidoRequerimiento(Guid codigoRequerimiento, Guid? codigoRequerimientoEstadio, ref string nombreArchivoRequerimiento, string linkFileCss = null)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                /*Verificamos si el documento es la versión Oficial*/
                RequerimientoEntity objRequerimiento = RequerimientoRepository.GetById(codigoRequerimiento);

                PlantillaEntity plantillaEntity = plantillaEntityRepository.GetById(objRequerimiento.CodigoPlantilla);

                string extencionDocumento = DatosConstantes.ArchivosRequerimiento.ExtensionValidaCarga;
                long CodigoArchivo = 0;
                string MsgError = string.Empty;
                var listaDocumentoFinal = RequerimientoLogicRepository.DocumentosPorRequerimiento(codigoRequerimiento).ToList();

                //Para obtener el docuemento de tipo adhesion se ordena por la version
                var documentoFinal = plantillaEntity.IndicadorAdhesion ? listaDocumentoFinal.OrderBy(item => item.Version).LastOrDefault() : listaDocumentoFinal.FirstOrDefault();

                if (objRequerimiento.IndicadorVersionOficial || plantillaEntity.IndicadorAdhesion)
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
                        resultado.Result = GenerarRequerimientoLocal(codigoRequerimiento, objRequerimiento, documentoFinal.Contenido, linkFileCss);
                    }
                    else
                    {
                        resultado.Result = contenidoArchivo.Result;
                    }
                }
                else
                {

                    resultado.Result = GenerarRequerimientoLocal(codigoRequerimiento, objRequerimiento, documentoFinal.Contenido, linkFileCss);
                    //MLV SUBIR NUEVAMENTE DOCUMENTO AL SHAREPOINT*/
                    ////var objDocumento = RequerimientoDocumentoEntityRepository.GetById(documentoFinal.CodigoRequerimientoDocumento);
                    ////objDocumento.Contenido = contenido;
                    ////RequerimientoDocumentoEntityRepository.Editar(objDocumento);
                    ////RequerimientoDocumentoEntityRepository.GuardarCambios();
                    //var msFile = new MemoryStream(GenerarPdfDesdeHtml(contenido, "", numeroCabecera, listaFirmantes, listaRevisores, null, false, urlLogo, widthLogo, heightLogo));
                    //string siteURLShp = sharePointService.RetornaSiteUrlSharePoint();
                    //NetworkCredential crdSHP = sharePointService.RetornaCredencialesServer();
                    //string[] nivelCarpeta = "03.03.24 SGC 2017/02 Febrero/1726 ZANJA/f6ad2365-0dc7-4f4c-8258-2baa7e9b0429.pdf".Split(new char[] { '/' });
                    //string listName = nivelCarpeta[0];
                    //string folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                    //string hayError = string.Empty;
                    //string NombreFile = string.Format("{0}.{1}", "F6AD2365-0DC7-4F4C-8258-2BAA7E9B0429", DatosConstantes.ArchivosRequerimiento.ExtensionValidaCarga);
                    //var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, NombreFile, msFile, siteURLShp, crdSHP);
                }

                if (objRequerimiento.NumeroRequerimiento != null)
                {
                    nombreArchivoRequerimiento = string.Format("{0}.{1}", objRequerimiento.NumeroRequerimiento, extencionDocumento);
                }
                else
                {
                    nombreArchivoRequerimiento = string.Format("{0}.{1}", documentoFinal.CodigoRequerimiento, extencionDocumento);
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Devuelve bit para el filestream
        /// </summary>
        /// <param name="codigoRequerimiento"></param>
        /// <param name="objRequerimiento"></param>
        /// <param name="contenido_"></param>
        /// <param name="linkFileCss"></param>
        /// <returns></returns>
        public byte[] GenerarRequerimientoLocal(Guid codigoRequerimiento, RequerimientoEntity objRequerimiento, string contenido_, string linkFileCss)
        {
            List<RequerimientoEstadioLogic> RequerimientoEstadio = RequerimientoLogicRepository.ListarRequerimientoEstadio(null, codigoRequerimiento);
            var Requerimiento = RequerimientoEntityRepository.GetById(codigoRequerimiento);
            List<RequerimientoEstadioLogic> RequerimientoEstadioAux = new List<RequerimientoEstadioLogic>();
            DateTime fechaFinalizacion;
            string fechaFinal = string.Empty, piePagina = string.Empty;
            List<Guid?> lstTrabajador = new List<Guid?>();
            RequerimientoEstadioAux = RequerimientoEstadio.FindAll(x => x.CodigoEstadoRequerimientoEstadio.Equals(DatosConstantes.CodigoEstadoRequerimientoEstadio.Aprobado)).OrderByDescending(x => x.FechaFinalizacion).ToList();

            if (RequerimientoEstadioAux != null && RequerimientoEstadioAux.Count > 0)
            {
                fechaFinalizacion = (DateTime)RequerimientoEstadioAux[0].FechaFinalizacion;
                lstTrabajador.Add(RequerimientoEstadioAux[0].CodigoResponsable);
                fechaFinal = fechaFinalizacion.ToString(DatosConstantes.Formato.FormatoFecha);
            }

            piePagina = DatosConstantes.ContenidoPiePaginaRequerimiento.EtiquetaCopiaNoOficial;


            var datosTrabajador = trabajadorService.ListarTrabajadores(lstTrabajador);

            #region correción de HTML sino cierra todas las etiquetas(p)


            string htmllocal = contenido_;

            HtmlNode.ElementsFlags["p"] = HtmlElementFlag.Closed;
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmllocal);

            var nuevoContenido = doc.DocumentNode.OuterHtml;

            #endregion

            string contenido = nuevoContenido;

            var listaRevisores = ObtenerListaRevisoresStracon(objRequerimiento).Result;

            var listaFirmantes = ObtenerListaFirmantesStracon(new RequerimientoResponse() { CodigoRequerimiento = objRequerimiento.CodigoRequerimiento, CodigoFlujoAprobacion = objRequerimiento.CodigoFlujoAprobacion, CodigoProveedor = objRequerimiento.CodigoProveedor }).Result;

            #region Cambio para Logo por Unidad Operativa
            var urlLogo = "";
            var entUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = Requerimiento.CodigoUnidadOperativa.ToString() });

            if (entUnidadOperativa.Result[0].LogoUnidadOperativa == null)
            {

                urlLogo = politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.UrlLogoStracon).FirstOrDefault().Atributo3;
            }
            else
            {
                urlLogo = entUnidadOperativa.Result[0].LogoUnidadOperativa;
            }


            #endregion

            //var urlLogo = politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.UrlLogoStracon).FirstOrDefault().Atributo3;
            var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.WidthLogo).FirstOrDefault().Atributo3);
            var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.HeightLogo).FirstOrDefault().Atributo3);

            var numeroCabecera = objRequerimiento.NumeroAdenda > 0 ? string.IsNullOrEmpty(objRequerimiento.NumeroAdendaConcatenado) ? objRequerimiento.NumeroRequerimiento : objRequerimiento.NumeroAdendaConcatenado : objRequerimiento.NumeroRequerimiento;
            return GenerarPdfDesdeHtml(contenido, piePagina, numeroCabecera, codigoRequerimiento, Requerimiento.CodigoPlantilla, listaFirmantes, listaRevisores, linkFileCss, false, urlLogo, widthLogo, heightLogo);

            //var urlLogo = politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.UrlLogoStracon).FirstOrDefault().Atributo3;
            //var widthLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.WidthLogo).FirstOrDefault().Atributo3);
            //var heightLogo = Convert.ToInt32(politicaService.ListaConfiguracionGeneracionRequerimiento().Result.Where(p => p.Atributo1 == DatosConstantes.ConfiguracionGeneracionRequerimiento.HeightLogo).FirstOrDefault().Atributo3);

            //var numeroCabecera = objRequerimiento.NumeroAdenda > 0 ? string.IsNullOrEmpty(objRequerimiento.NumeroAdendaConcatenado) ? objRequerimiento.NumeroRequerimiento : objRequerimiento.NumeroAdendaConcatenado : objRequerimiento.NumeroRequerimiento;
            //return GenerarPdfDesdeHtml(contenido, piePagina, numeroCabecera, codigoRequerimiento, Requerimiento.CodigoPlantilla, listaFirmantes, listaRevisores, linkFileCss, false, urlLogo, widthLogo, heightLogo);



        }

        /// <summary>
        /// Metodo que retorna los bytes del Requerimiento reemplazado en la observación.
        /// </summary>
        /// <param name="codigoRequerimientoEstadioObservacion">Código de la observación del estadio Requerimiento</param>
        /// <param name="nombreArchivoRequerimiento">Nombre del archivo a descargar</param>
        /// <returns>Documento de Requerimiento que reemplazo la Observación</returns>
        public ProcessResult<Object> ObtenerRequerimientoAnteriorObservacion(Guid codigoRequerimientoEstadioObservacion, ref string nombreArchivoRequerimiento)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                var observacion = ObtieneRequerimientoEstadioObservacionPorID(codigoRequerimientoEstadioObservacion);

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

                nombreArchivoRequerimiento = string.Format("{0}.{1}", observacion.CodigoRequerimientoEstadioObservacion, extencionDocumento);

            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }
        /// <summary>
        /// Metodo que retorna los bytes del Requerimiento reemplzanate en la observación.
        /// </summary>
        /// <param name="codigoRequerimientoEstadioObservacion">Código de la observación del estadio Requerimiento</param>
        /// <param name="nombreArchivoRequerimiento">Nombre del archivo a descargar</param>
        /// <returns>Documento de Requerimiento que reemplazo la Observación</returns>
        public ProcessResult<Object> ObtenerRequerimientoReemplazanteObservacion(Guid codigoRequerimientoEstadioObservacion, ref string nombreArchivoRequerimiento)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                var observacion = ObtieneRequerimientoEstadioObservacionPorID(codigoRequerimientoEstadioObservacion);
                var RequerimientoEstadio = RequerimientoEstadioRepository.GetById(observacion.CodigoRequerimientoEstadio);

                return GenerarContenidoRequerimiento(RequerimientoEstadio.CodigoRequerimiento, null, ref nombreArchivoRequerimiento);

            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.Result = ex.Message;
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }
        /// <summary>
        /// Retorna información del Requerimiento.
        /// </summary>
        /// <param name="codigoRequerimiento">código de Requerimiento</param>
        /// <returns>Información del Requerimiento</returns>
        public ProcessResult<RequerimientoResponse> RetornaRequerimientoPorId(Guid codigoRequerimiento)
        {
            ProcessResult<RequerimientoResponse> rpta = new ProcessResult<RequerimientoResponse>();
            try
            {
                RequerimientoEntity entRequerimiento = RequerimientoRepository.GetById(codigoRequerimiento);

                ProveedorEntity proveedorEntity = proveedorEntityRepository.GetById(entRequerimiento.CodigoProveedor);

                rpta.Result = new RequerimientoResponse();
                rpta.Result = RequerimientoAdapter.ObtenerRequerimientoResponseDeEntity(entRequerimiento, proveedorEntity);
            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }

        //private void NotificacionRequerimiento(object objSend)
        //{
        //    ParametrosNotificacion oparamNot = (ParametrosNotificacion)objSend;
        //    int ejecutaEnvio = RequerimientoLogicRepository.NotificaBandejaRequerimientos(oparamNot.asunto,
        //                                                                            oparamNot.textoNotificar, oparamNot.cuentaNotificar,
        //                                                                            oparamNot.cuentaCopiar, oparamNot.profileCorreo);
        //}

        /// <summary>
        /// Genera Notificación de correo
        /// </summary>
        /// <param name="TipoNotificacion">Tipo de Notificación</param>
        /// <param name="codigoRequerimientoEstadio">Código de Requerimiento por Estadio</param>
        /// <param name="lstTrab">Lista de Trabajadores</param>
        /// <param name="listaUni">Lista de Unidad</param>
        /// <param name="lstProfile">Lista Profile</param>
        /// <param name="lstUrl">Lista Url</param>
        /// <param name="usuarioCreacion">Usuario de creación de Requerimiento</param>
        /// <param name="codigoResponsable"></param>
        /// <param name="codigos_con_copia"></param>
        /// <returns>Notificación de correo</returns>
        private int generaNotificacionCorreo(string TipoNotificacion, Guid codigoRequerimientoEstadio,
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

            var datosCorreo = RequerimientoLogicRepository.InformacionNotificacionRequerimientoEstadio(codigoRequerimientoEstadio, TipoNotificacion);

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
                if (datos.TipoNotificacion == DatosConstantes.TipoNotificacion.RequerimientosObservado ||
                    datos.TipoNotificacion == DatosConstantes.TipoNotificacion.ObservacionRechazada ||
                    datos.TipoNotificacion == DatosConstantes.TipoNotificacion.NuevoRequerimientoBandeja
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

                if (datos.TipoNotificacion == DatosConstantes.TipoNotificacion.RequerimientoRechazadoPorLegal)
                {
                    ls_url = string.Format("{0}{1}{2}{3}{4}{5}{6}", "<a href='", ls_url,
                                           DatosConstantes.UrlOpcionesSistema.RutaListadoRequerimiento, "'>", ls_url,
                                           DatosConstantes.UrlOpcionesSistema.RutaListadoRequerimiento, "</a>");
                }
                else
                {
                    ls_url = string.Format("{0}{1}{2}{3}{4}{5}{6}", "<a href='", ls_url,
                                            DatosConstantes.UrlOpcionesSistema.RutaBandejaRequerimiento, "'>", ls_url,
                                            DatosConstantes.UrlOpcionesSistema.RutaBandejaRequerimiento, "</a>");
                }

                datos.variables.Add("@numero_Requerimiento", datosCorreo[0].NumeroRequerimiento);
                datos.variables.Add("@nombre_proyecto", listaUnidades[0].Nombre);
                datos.variables.Add("@nombre_proveedor", datosCorreo[0].NombreProveedor);
                datos.variables.Add("@url_opcion_sistema.", ls_url);

                #region Parametros Adicionales para Notificación Observación y Nuevo Requerimiento en Bandeja.

                if (datos.TipoNotificacion == DatosConstantes.TipoNotificacion.RequerimientosObservado)
                {
                    datos.variables.Add("@observacion", datosCorreo[0].DescripcionObservacion);
                    datos.variables.Add("@descripcion", datosCorreo[0].DescripcionRequerimiento);
                }

                if (datos.TipoNotificacion == DatosConstantes.TipoNotificacion.NuevoRequerimientoBandeja)
                {
                    var trabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = datosCorreo[0].UsuarioCreacion }).Result.FirstOrDefault();
                    datos.variables.Add("@usuario_creacion", trabajador.NombreCompleto);
                    datos.variables.Add("@descripcion", datosCorreo[0].DescripcionRequerimiento);
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

                if (datos.TipoNotificacion == DatosConstantes.TipoNotificacion.AprobacionRequerimientoHistorico)
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
            int ejecutaEnvio = RequerimientoLogicRepository.NotificaBandejaRequerimientos(datos.asunto, datos.textoNotificar, datos.cuentaNotificar, datos.cuentaCopiar, datos.profileCorreo);
            return ejecutaEnvio;
        }


        ///// <summary>
        ///// Método para listar Requerimiento estadio responsable
        ///// </summary>
        ///// <param name="filtro">Filtro</param>
        ///// <returns>Listado de Requerimiento estadio responsable</returns>
        //public ProcessResult<List<RequerimientoEstadioResponse>> ListaRequerimientoEstadioResponsable(RequerimientoRequest filtro)
        //{
        //    ProcessResult<List<RequerimientoEstadioResponse>> resultado = new ProcessResult<List<RequerimientoEstadioResponse>>();
        //    try
        //    {
        //        var result = RequerimientoLogicRepository.ListadoRequerimientoEstadioResponsable(new Guid(filtro.CodigoRequerimiento));
        //        resultado.Result = new List<RequerimientoEstadioResponse>();

        //        foreach (var item in result)
        //        {
        //            resultado.Result.Add(RequerimientoAdapter.ObtenerRequerimientoEstadioResponsableResponseDeLogic(item));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado.IsSuccess = false;
        //        resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
        //    }
        //    return resultado;
        //}

        /// <summary>
        /// Obtiene la lista de revisores del Requerimiento
        /// </summary>
        /// <param name="Requerimiento">Entidad del Requerimiento</param>
        /// <param name="entidadFlujoAprobacionEstadio">Codigo de Requerimiento estadio</param>
        /// <param name="login">Usuario actual</param>
        /// <returns>Lista de revisores</returns>
        public ProcessResult<List<string>> ObtenerListaRevisoresStracon(RequerimientoEntity Requerimiento, FlujoAprobacionEstadioEntity entidadFlujoAprobacionEstadio = null, string login = "")
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
                //Lista de revisores que ya han aprobado el Requerimiento
                var listaRevisores = RequerimientoLogicRepository.ListadoRequerimientoEstadioResponsable(Requerimiento.CodigoRequerimiento).ToList();

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
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Obtiene la lista de firmantes del Requerimiento
        /// </summary>
        /// <param name="Requerimiento">Requerimiento</param>
        /// <returns>Lista de firmantes</returns>
        public ProcessResult<List<TrabajadorResponse>> ObtenerListaFirmantesStracon(RequerimientoResponse Requerimiento)
        {
            ProcessResult<List<TrabajadorResponse>> rpta = new ProcessResult<List<TrabajadorResponse>>();

            try
            {
                List<TrabajadorResponse> listaFirmantes = new List<TrabajadorResponse>();

                var listaRepFirmantesStracon = flujoAprobacionService.BuscarBandejaFlujoAprobacion(new FlujoAprobacionRequest() { CodigoFlujoAprobacion = Requerimiento.CodigoFlujoAprobacion.ToString() }).Result.FirstOrDefault();

                var empresaVinculada = RequerimientoLogicRepository.ObtenerEmpresaVinculadaPorProveedor(Requerimiento.CodigoProveedor);

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
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
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
                var empresaVinculada = RequerimientoLogicRepository.ObtenerEmpresaVinculadaPorProveedor(codigoProveedor);

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
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Realiza la búsqueda de listado Requerimiento
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de Requerimientos</returns>
        public ProcessResult<List<ListadoRequerimientoResponse>> BuscarListadoRequerimiento(ListadoRequerimientoRequest filtro)
        {
            ProcessResult<List<ListadoRequerimientoResponse>> resultado = new ProcessResult<List<ListadoRequerimientoResponse>>();
            List<CodigoValorResponse> resultadoTipoServicio = null;
            List<CodigoValorResponse> resultadoTipoRequerimiento = null;
            List<CodigoValorResponse> resultadoTipoDocumento = null;
            List<CodigoValorResponse> resultadoEstadoRequerimiento = null;
            List<CodigoValorResponse> resultadoEstadoEdicion = null;
            List<UnidadOperativaResponse> resultadoUnidadOperativa = null;

            List<Guid?> listaUnidadOperativaAsociadoTrabajador = null;

            try
            {
                resultadoTipoServicio = politicaService.ListarTipoRequerimiento().Result;
                resultadoTipoRequerimiento = politicaService.ListarTipoServicio().Result;
                resultadoTipoDocumento = politicaService.ListarTipoDocumentoRequerimiento().Result;
                resultadoEstadoRequerimiento = politicaService.ListarEstadoRequerimiento().Result;
                resultadoEstadoEdicion = politicaService.ListarEstadoEdicion().Result;
                resultadoUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa()).Result;

                Guid? codigoRequerimiento = filtro.CodigoRequerimiento != null ? new Guid(filtro.CodigoRequerimiento) : (Guid?)null;
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
                decimal? montoRequerimiento = null;

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

                if (!string.IsNullOrWhiteSpace(filtro.MontoRequerimientoString))
                {
                    montoRequerimiento = Decimal.Parse(filtro.MontoRequerimientoString, numberFormatInfo);
                }
                else
                {
                    montoRequerimiento = null;
                }
                var resultadoTrabajador = trabajadorService.BuscarTrabajadorDatoMinimo(new TrabajadorRequest()).Result;

                List<ListadoRequerimientoLogic> listado = listadoRequerimientoLogicRepository.BuscarListadoRequerimiento(codigoRequerimiento, codigoUnidadOperativa, null, filtro.CodigoTipoServicio,
                                                                                        filtro.CodigoTipoRequerimiento, filtro.CodigoTipoDocumento, filtro.CodigoEstadoRequerimiento,
                                                                                        filtro.NumeroRequerimiento, filtro.NumeroAdendaConcatenado, filtro.NumeroDocumentoProveedor, filtro.NombreProveedor,
                                                                                        filtro.Descripcion, indicadorTodaUnidadOperativa, listaUnidadOperativaAsociadoTrabajador,
                                                                                        filtro.CodigoEstadoEdicion, filtro.DescripcionRequerimiento, codigoTrabajadorResponsable, filtro.NombreEstadio,
                                                                                        filtro.IndicadorFinalizarAprobacion, filtro.NumeroPagina, filtro.RegistrosPagina);

                resultado.Result = new List<ListadoRequerimientoResponse>();
                foreach (var registro in listado)
                {

                    var listadoRequerimiento = ListadoRequerimientoAdapter.ObtenerListadoRequerimientoPaginado(registro, resultadoTipoServicio, resultadoTipoRequerimiento, resultadoTipoDocumento, resultadoEstadoRequerimiento, resultadoEstadoEdicion, resultadoTrabajador, resultadoUnidadOperativa);
                    resultado.Result.Add(listadoRequerimiento);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ProcessResult<List<ListadoRequerimientoResponse>> BuscarListadoRequerimientoOrden(ListadoRequerimientoRequest filtro)
        {
            ProcessResult<List<ListadoRequerimientoResponse>> resultado = new ProcessResult<List<ListadoRequerimientoResponse>>();
            List<CodigoValorResponse> resultadoTipoServicio = null;
            List<CodigoValorResponse> resultadoTipoRequerimiento = null;
            List<CodigoValorResponse> resultadoTipoDocumento = null;
            List<CodigoValorResponse> resultadoEstadoRequerimiento = null;
            List<CodigoValorResponse> resultadoEstadoEdicion = null;
            List<UnidadOperativaResponse> resultadoUnidadOperativa = null;

            List<Guid?> listaUnidadOperativaAsociadoTrabajador = null;

            try
            {
                resultadoTipoServicio = politicaService.ListarTipoRequerimiento().Result;
                resultadoTipoRequerimiento = politicaService.ListarTipoServicio().Result;
                resultadoTipoDocumento = politicaService.ListarTipoDocumentoRequerimiento().Result;
                resultadoEstadoRequerimiento = politicaService.ListarEstadoRequerimiento().Result;
                resultadoEstadoEdicion = politicaService.ListarEstadoEdicion().Result;
                resultadoUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa()).Result;

                Guid? codigoRequerimiento = filtro.CodigoRequerimiento != null ? new Guid(filtro.CodigoRequerimiento) : (Guid?)null;
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
                decimal? montoRequerimiento = null;

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

                if (!string.IsNullOrWhiteSpace(filtro.MontoRequerimientoString))
                {
                    montoRequerimiento = Decimal.Parse(filtro.MontoRequerimientoString, numberFormatInfo);
                }
                else
                {
                    montoRequerimiento = null;
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

                List<ListadoRequerimientoLogic> listado = listadoRequerimientoLogicRepository.BuscarListadoRequerimientoOrden(
                                                                        codigoRequerimiento, codigoUnidadOperativa, null, 
                                                                        //filtro.CodigoTipoServicio,
                                                                        //filtro.CodigoTipoRequerimiento, 
                                                                        filtro.CodigoTipoDocumento, filtro.CodigoEstadoRequerimiento,filtro.NumeroRequerimiento,
                                                                        //filtro.NumeroAdendaConcatenado, 
                                                                        //filtro.NumeroDocumentoProveedor, filtro.NombreProveedor,
                                                                        filtro.Descripcion, indicadorTodaUnidadOperativa, listaUnidadOperativaAsociadoTrabajador,
                                                                        filtro.CodigoEstadoEdicion, filtro.DescripcionRequerimiento, codigoTrabajadorResponsable,
                                                                        filtro.NombreEstadio, filtro.IndicadorFinalizarAprobacion, montoAcumuladoInicio,
                                                                        montoAcumuladoFin, filtro.CodigoMoneda, filtro.UsuarioCreacion,
                                                                        filtro.ColumnaOrden, filtro.TipoOrden, filtro.NumeroPagina, filtro.RegistrosPagina
                                                                                        );


                resultado.Result = new List<ListadoRequerimientoResponse>();
                foreach (var registro in listado)
                {
                    var listadoRequerimiento = ListadoRequerimientoAdapter.ObtenerListadoRequerimientoPaginado(registro, resultadoTipoServicio, resultadoTipoRequerimiento, resultadoTipoDocumento, resultadoEstadoRequerimiento, resultadoEstadoEdicion, resultadoTrabajador, resultadoUnidadOperativa);
                    resultado.Result.Add(listadoRequerimiento);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(e.GetBaseException());
            }
            return resultado;
        }

        /// <summary>
        /// Realiza la búsqueda de Requerimientos
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de Requerimientos</returns>
        public ProcessResult<List<ListadoRequerimientoResponse>> BuscarRequerimiento(ListadoRequerimientoRequest filtro)
        {
            ProcessResult<List<ListadoRequerimientoResponse>> resultado = new ProcessResult<List<ListadoRequerimientoResponse>>();
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

                List<ListadoRequerimientoLogic> listado = listadoRequerimientoLogicRepository.BuscarListadoRequerimiento(null, null, null, filtro.CodigoTipoServicio,
                                                                                        filtro.CodigoTipoRequerimiento, filtro.CodigoTipoDocumento, filtro.CodigoEstadoRequerimiento,
                                                                                        filtro.NumeroRequerimiento, filtro.NumeroAdendaConcatenado, filtro.NumeroDocumentoProveedor, filtro.NombreProveedor,
                                                                                        filtro.Descripcion, true, listaUnidadOperativaAsociadoTrabajador,
                                                                                        filtro.CodigoEstadoEdicion, filtro.DescripcionRequerimiento, null, filtro.NombreEstadio,
                                                                                        filtro.IndicadorFinalizarAprobacion, filtro.NumeroPagina, filtro.RegistrosPagina);

                resultado.Result = new List<ListadoRequerimientoResponse>();
                foreach (var registro in listado)
                {
                    var listadoRequerimiento = ListadoRequerimientoAdapter.ObtenerBusquedaRequerimiento(registro);
                    resultado.Result.Add(listadoRequerimiento);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Registra o actualiza un Requerimiento
        /// </summary>
        /// <param name="dataRequerimiento">Datos a registrar de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarRequerimiento(RequerimientoRequest dataRequerimiento)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();

            try
            {
                #region Nuevo
                if (dataRequerimiento.CodigoRequerimiento == null)
                {
                    var esAdendaRequerimientoVencido = false;
                    dataRequerimiento.IndicadorVersionOficial = false;

                    #region Adenda
                    if (dataRequerimiento.CodigoTipoDocumento == DatosConstantes.TipoDocumento.Adenda)
                    {
                        #region Obtiene Datos Requerimiento y sus Adendas

                        var entidadRequerimientoPrincipal = ObtieneRequerimientoPorID(new Guid(dataRequerimiento.CodigoRequerimientoPrincipal.ToString())).Result;
                        DateTime fechaFinUltimaAdenda = DateTime.Now;

                        var listaAdendas = listadoRequerimientoLogicRepository.BuscarRequerimiento(null, dataRequerimiento.CodigoRequerimientoPrincipal, string.Empty, string.Empty, dataRequerimiento.CodigoTipoDocumento, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty).OrderByDescending(a => a.NumeroAdenda).FirstOrDefault();
                        dataRequerimiento.NumeroAdenda = (listaAdendas == null) ? 1 : listaAdendas.NumeroAdenda + 1;

                        if (dataRequerimiento.NumeroAdenda > 1) fechaFinUltimaAdenda = listaAdendas.FechaFinVigencia;

                        dataRequerimiento.NumeroAdendaConcatenado = string.Format(DatosConstantes.Formato.FormatoNumeroAdenda, entidadRequerimientoPrincipal.NumeroRequerimiento, dataRequerimiento.NumeroAdenda);
                        dataRequerimiento.NumeroRequerimiento = entidadRequerimientoPrincipal.NumeroRequerimiento;

                        #endregion

                        #region Diferente a Historico.
                        if (dataRequerimiento.CodigoTipoRequerimiento != DatosConstantes.TipoServicio.RequerimientoHistorico)
                        {
                            //Adenda 1
                            if (listaAdendas == null)
                            {
                                if (entidadRequerimientoPrincipal.CodigoEstado == DatosConstantes.EstadoRequerimiento.Vencido)
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
                                        DateTime fechaComparativa = (dataRequerimiento.NumeroAdenda > 1) ? fechaFinUltimaAdenda : (DateTime)entidadRequerimientoPrincipal.FechaFinVigencia;

                                        DateTime fechaInicio = fechaComparativa;
                                        DateTime fechaFin = DateTime.Today;
                                        TimeSpan diferencia = (fechaFin - fechaInicio);

                                        var diasRequerimiento = diferencia.Days;

                                        int valorDiasParametro = 0;
                                        bool validaDiasParametro = int.TryParse(diasParametro.RegistroCadena.First(x => x.Key == "1").Value, out valorDiasParametro);

                                        if (validaDiasParametro && diasRequerimiento > valorDiasParametro)
                                        {
                                            resultado.IsSuccess = false;
                                            resultado.Exception = new ApplicationLayerException<RequerimientoService>(string.Format("La adenda supera los {0} días del período de gracia.", valorDiasParametro));
                                            return resultado;
                                        }
                                        else
                                        {
                                            esAdendaRequerimientoVencido = true;
                                        }
                                    }
                                    #endregion
                                }
                                else if (entidadRequerimientoPrincipal.CodigoEstado != DatosConstantes.EstadoRequerimiento.Vigente
                                    && entidadRequerimientoPrincipal.CodigoEstado != DatosConstantes.EstadoRequerimiento.Vencido)
                                {
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("El Requerimiento N° " + entidadRequerimientoPrincipal.NumeroRequerimiento + " no se encuentra en estado Vencido o Vigente.");
                                    return resultado;
                                }
                            }
                            //Adenda 2 o mas
                            else
                            {
                                if (listaAdendas.CodigoEstadoRequerimiento == DatosConstantes.EstadoRequerimiento.Vencido)
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
                                        DateTime fechaComparativa = (dataRequerimiento.NumeroAdenda > 1) ? fechaFinUltimaAdenda : (DateTime)entidadRequerimientoPrincipal.FechaFinVigencia;

                                        DateTime fechaInicio = fechaComparativa;
                                        DateTime fechaFin = DateTime.Today;
                                        TimeSpan diferencia = (fechaFin - fechaInicio);

                                        var diasRequerimiento = diferencia.Days;

                                        int valorDiasParametro = 0;
                                        bool validaDiasParametro = int.TryParse(diasParametro.RegistroCadena.First(x => x.Key == "1").Value, out valorDiasParametro);

                                        if (validaDiasParametro && diasRequerimiento > valorDiasParametro)
                                        {
                                            resultado.IsSuccess = false;
                                            resultado.Exception = new ApplicationLayerException<RequerimientoService>(string.Format("La adenda supera los {0} días del período de gracia.", valorDiasParametro));
                                            return resultado;
                                        }
                                        else
                                        {
                                            esAdendaRequerimientoVencido = true;
                                        }
                                    }

                                    #endregion
                                }
                                else if (listaAdendas.CodigoEstadoRequerimiento != DatosConstantes.EstadoRequerimiento.Vencido
                                    && listaAdendas.CodigoEstadoRequerimiento != DatosConstantes.EstadoRequerimiento.Vigente)
                                {
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("La Adenda N° " + listaAdendas.NumeroAdendaConcatenado + " no se encuentra en estado Vencido o Vigente.");
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
                                if (entidadRequerimientoPrincipal.CodigoEstado != DatosConstantes.EstadoRequerimiento.Vencido
                                    && entidadRequerimientoPrincipal.CodigoEstado != DatosConstantes.EstadoRequerimiento.Vigente)
                                {
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("El Requerimiento N° " + entidadRequerimientoPrincipal.NumeroRequerimiento + " no se encuentra en estado Vigente o Vencido");
                                    return resultado;
                                }
                            }
                            //Adenda 2 o mas
                            else
                            {
                                if (listaAdendas.CodigoEstadoRequerimiento != DatosConstantes.EstadoRequerimiento.Vencido
                                    && listaAdendas.CodigoEstadoRequerimiento != DatosConstantes.EstadoRequerimiento.Vigente)
                                {
                                    resultado.IsSuccess = false;
                                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("La Adenda N° " + listaAdendas.NumeroAdendaConcatenado + " no se encuentra en estado Vigente o Vencido");
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
                        dataRequerimiento.MontoAcumuladoString = dataRequerimiento.MontoRequerimientoString;
                    }
                    #endregion

                    dataRequerimiento.CodigoEstado = DatosConstantes.EstadoRequerimiento.Edicion;
                    dataRequerimiento.CodigoEstadoEdicion = DatosConstantes.CodigoEstadoEdicion.EdicionParcial;

                    #region  Asignación de Plantilla                
                    var resultadoPlantilla = plantillaService.BuscarPlantilla(new PlantillaRequest()
                    {
                        CodigoTipoRequerimiento = dataRequerimiento.CodigoTipoServicio,
                        CodigoTipoDocumentoRequerimiento = dataRequerimiento.CodigoTipoDocumento,
                        IndicadorAdhesion = dataRequerimiento.IndicadorAdhesion,
                        CodigoEstadoVigencia = DatosConstantes.EstadoVigencia.Vigente
                    }).Result.FirstOrDefault();
                    #endregion

                    if (resultadoPlantilla != null && dataRequerimiento.CodigoFlujoAprobacion != null)
                    {
                        dataRequerimiento.CodigoPlantilla = resultadoPlantilla.CodigoPlantilla;
                        //dataRequerimiento.CodigoFlujoAprobacion = dataRequerimiento.CodigoFlujoAprobacion;

                        RequerimientoEntity entidadRequerimiento = ListadoRequerimientoAdapter.RegistrarRequerimiento(dataRequerimiento);

                        var resultadoRequerimiento = RequerimientoEntityRepository.RegistrarRequerimiento(entidadRequerimiento);

                        if (resultadoRequerimiento != 0)
                        {
                            #region Registro de Requerimiento Estadio
                            RequerimientoEstadioRequest dataRequerimientoEstadio = new RequerimientoEstadioRequest();

                            var resultadoFlujoAprobacionEstadio = flujoAprobacionService.BuscarBandejaFlujoAprobacionEstadio(
                            null,
                            dataRequerimiento.CodigoFlujoAprobacion
                            ).Result.OrderBy(x => x.Orden).FirstOrDefault();

                            if (resultadoFlujoAprobacionEstadio != null)
                            {
                                entidadRequerimiento.CodigoEstadioActual = new Guid(resultadoFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio);
                            }

                            dataRequerimientoEstadio.CodigoFlujoAprobacionEstadio = new Guid(resultadoFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio);
                            dataRequerimientoEstadio.CodigoRequerimiento = entidadRequerimiento.CodigoRequerimiento;
                            dataRequerimientoEstadio.FechaIngreso = DateTime.Now.Date;

                            if (resultadoFlujoAprobacionEstadio.CodigoResponsable == null)
                            {
                                dataRequerimientoEstadio.CodigoResponsable = null;
                            }
                            else
                            {
                                dataRequerimientoEstadio.CodigoResponsable = Guid.Parse(resultadoFlujoAprobacionEstadio.CodigoResponsable);
                            }

                            dataRequerimientoEstadio.CodigoEstadoRequerimientoEstadio = DatosConstantes.CodigoEstadoRequerimientoEstadio.Iniciado;
                            RequerimientoEstadioEntity entidadRequerimientoEstadio = RequerimientoEstadioAdapter.RegistrarRequerimientoEstadio(dataRequerimientoEstadio);

                            RequerimientoEstadioEntityRepository.RegistrarRequerimientoEstadio(entidadRequerimientoEstadio);
                            #endregion

                            #region Registrar adendas de Requerimiento vencido en tabla temporal para notificación (envio de correo)
                            if (esAdendaRequerimientoVencido == true)
                            {
                                RequerimientoLogicRepository.RegistraAdendaRequerimientoVencido((Guid)dataRequerimiento.CodigoUnidadOperativa, dataRequerimiento.NumeroRequerimiento, dataRequerimiento.Descripcion, dataRequerimiento.NumeroAdenda, dataRequerimiento.NumeroAdendaConcatenado);
                            }
                            #endregion

                            resultado.IsSuccess = true;
                            resultado.Result = entidadRequerimiento.CodigoRequerimiento;
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

                    var entidadRequerimiento = RequerimientoEntityRepository.GetById(Guid.Parse(dataRequerimiento.CodigoRequerimiento));

                    entidadRequerimiento.FechaInicioVigencia = DateTime.ParseExact(dataRequerimiento.FechaInicioVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
                    entidadRequerimiento.FechaFinVigencia = DateTime.ParseExact(dataRequerimiento.FechaFinVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
                    entidadRequerimiento.CodigoMoneda = dataRequerimiento.CodigoMoneda;
                    entidadRequerimiento.MontoRequerimiento = Decimal.Parse(dataRequerimiento.MontoRequerimientoString, numberFormatInfo);
                    entidadRequerimiento.MontoAcumulado = (dataRequerimiento.MontoAcumuladoString != null) ? Decimal.Parse(dataRequerimiento.MontoAcumuladoString, numberFormatInfo) : 0;
                    entidadRequerimiento.Descripcion = dataRequerimiento.Descripcion;
                    entidadRequerimiento.EsCorporativo = dataRequerimiento.EsCorporativo;
                    entidadRequerimiento.CodigoProveedor = dataRequerimiento.CodigoProveedor;
                    entidadRequerimiento.CodigoFlujoAprobacion = new Guid(dataRequerimiento.CodigoFlujoAprobacion);

                    entidadRequerimiento.CodigoRequerido = new Guid(dataRequerimiento.CodigoRequerido);

                    RequerimientoEntityRepository.Editar(entidadRequerimiento, entornoActualAplicacion);
                    RequerimientoEntityRepository.GuardarCambios();

                    RequerimientoEntityRepository.Actualizar_Flujo_Requerimiento_Estadio(entidadRequerimiento);

                    resultado.IsSuccess = true;
                    resultado.Result = entidadRequerimiento.CodigoRequerimiento;
                }
                #endregion
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene el tipo de Requerimiento segun la Unidad Operativa S11-SGC
        /// </summary>
        /// <param name="CodigoUnidadOperativa"></param>
        /// <returns></returns>
        public List<string> Obtener_Tipo_Requerimiento(Guid CodigoUnidadOperativa)
        {
            return listadoRequerimientoLogicRepository.Listar_Requerimiento_Segun_Unidad_Operativa(CodigoUnidadOperativa);
        }

        /// <summary>
        /// Permite generar el número de Requerimiento
        /// </summary>
        /// <param name="unidadOperativa">Unidad Operativa</param>
        /// <param name="codigoTipoServicio">Tipo de Servicio</param>
        /// <param name="abreviaturaTipoServicio">Abreviatura del servicio</param>
        /// <param name="tipoDocumento">Tipo de Requerimiento</param>
        /// <returns>Número del Requerimiento</returns>
        private string GenerarNumeroRequerimiento(UnidadOperativaResponse unidadOperativa, string codigoTipoServicio, string abreviaturaTipoServicio, string tipoDocumento)
        {
            var unidadOperativaSuperior = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = unidadOperativa.CodigoUnidadOperativaPadre.ToString() }).Result.FirstOrDefault();
            string anioActual = DateTime.Now.Year.ToString().Substring(2, 2);

            var listadoRequerimiento = listadoRequerimientoLogicRepository.BuscarCorrelativoRequerimiento(unidadOperativa.CodigoUnidadOperativa, codigoTipoServicio, tipoDocumento);
            listadoRequerimiento = listadoRequerimiento.FindAll(item => item.NumeroRequerimiento.Split(Convert.ToChar(DatosConstantes.Formato.SeparadorFormatoNumeroRequerimiento)).ElementAt(3) == anioActual &&
                                                             item.NumeroRequerimiento.Split(Convert.ToChar(DatosConstantes.Formato.SeparadorFormatoNumeroRequerimiento)).ElementAt(2) == abreviaturaTipoServicio );

            var numeroMax = 0;
            List<int> numerosRequerimiento = new List<int>();

            foreach (var item in listadoRequerimiento)
            {
                var numeroRequerimientoItem = item.NumeroRequerimiento.Split(Convert.ToChar(DatosConstantes.Formato.SeparadorFormatoNumeroRequerimiento));
                numerosRequerimiento.Add(Convert.ToInt32(numeroRequerimientoItem.ElementAt(4)));
            }
            if (numerosRequerimiento.Count != 0)
            {
                numeroMax = numerosRequerimiento.Max();
            }
            else
            {
                numeroMax = 1;
            }

            var ultimoRequerimiento = listadoRequerimiento.LastOrDefault();

            string numeroRequerimiento = string.Format(DatosConstantes.Formato.FormatoNumeroRequerimiento, unidadOperativaSuperior.CodigoIdentificacion, unidadOperativa.CodigoIdentificacion, abreviaturaTipoServicio, anioActual, string.Empty);

            int correlativo = 0;
            if (ultimoRequerimiento != null && ultimoRequerimiento.NumeroRequerimiento != null)
            {
                string numeroRequerimientoUltimoSinCorrelativo = string.Empty;
                var numeroRequerimientoUltimoSperado = ultimoRequerimiento.NumeroRequerimiento.Split(Convert.ToChar(DatosConstantes.Formato.SeparadorFormatoNumeroRequerimiento));

                for (var index = 0; index < numeroRequerimientoUltimoSperado.Count() - 1; index++)
                {
                    numeroRequerimientoUltimoSinCorrelativo += numeroRequerimientoUltimoSperado[index] + ".";
                }

                if (numeroRequerimientoUltimoSinCorrelativo == numeroRequerimiento)
                {
                    correlativo = numeroMax;
                    //correlativo = Convert.ToInt32(numeroRequerimientoUltimoSperado.LastOrDefault());
                }
            }
            correlativo++;

            numeroRequerimiento += correlativo.ToString().PadLeft(3, '0');

            return numeroRequerimiento;
        }

        /// <summary>
        /// Registra o actualiza un listado Requerimiento
        /// </summary>
        /// <param name="dataRequerimiento">Datos a registrar de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarListadoRequerimiento(RequerimientoRequest dataRequerimiento)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            RequerimientoParrafoRequest dataRequerimientoParrafo = new RequerimientoParrafoRequest();
            RequerimientoParrafoVariableRequest dataRequerimientoParrafoVariable = new RequerimientoParrafoVariableRequest();
            RequerimientoBienRequest dataRequerimientoBien = new RequerimientoBienRequest();
            RequerimientoFirmanteRequest dataRequerimientoFirmante = new RequerimientoFirmanteRequest();

            UnidadOperativaResponse unidadOperativa = null;
            string codigoFormaEdicion, hayError = string.Empty;

            var valor = 0;
            string numeroRequerimiento = "";

            try
            {
                var entidadRequerimiento = ObtieneRequerimientoPorID(new Guid(dataRequerimiento.CodigoRequerimiento)).Result;
                numeroRequerimiento = entidadRequerimiento.NumeroRequerimiento;
                entidadRequerimiento.IndicadorVersionOficial = false;

                #region  Generando Requerimiento documento
                dataRequerimiento.RequerimientoDocumento.CodigoRequerimiento = dataRequerimiento.CodigoRequerimiento;
                dataRequerimiento.RequerimientoDocumento.CodigoArchivo = 0;
                dataRequerimiento.RequerimientoDocumento.RutaArchivoSharePoint = string.Empty;
                dataRequerimiento.RequerimientoDocumento.IndicadorActual = true;
                dataRequerimiento.RequerimientoDocumento.Version = 1;
                RequerimientoDocumentoEntity entidadRequerimientoDocumento = RequerimientoDocumentoAdapter.RegistrarRequerimientoDocumento(dataRequerimiento.RequerimientoDocumento);
                #endregion

                #region Valida Numero Requerimiento
                if (entidadRequerimiento.NumeroRequerimiento == null || entidadRequerimiento.NumeroRequerimiento == "")
                {
                    unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = entidadRequerimiento.CodigoUnidadOperativa.ToString() }).Result.FirstOrDefault();
                    var tipoRequerimiento = politicaService.ListarTipoServicioDinamico().Result.Where(p => p.Atributo1 == entidadRequerimiento.CodigoTipoRequerimiento).FirstOrDefault();
                    numeroRequerimiento = string.IsNullOrEmpty(entidadRequerimiento.NumeroRequerimiento) ? GenerarNumeroRequerimiento(unidadOperativa, tipoRequerimiento.Atributo1, tipoRequerimiento.Atributo4, entidadRequerimiento.CodigoTipoDocumento) : entidadRequerimiento.NumeroRequerimiento;

                    valor = RequerimientoEntityRepository.ConsultaNumeroRequerimiento(new RequerimientoEntity()
                    {
                        NumeroRequerimiento = numeroRequerimiento
                    });
                }
                #endregion

                if (valor != 3)
                {
                    #region Grabado

                    //Consulta si el grabado es parcial o total
                    if (dataRequerimiento.TipoRegistro == DatosConstantes.TipoRegistro.Parcial)
                    {
                        codigoFormaEdicion = null;
                        entidadRequerimiento.CodigoEstado = DatosConstantes.EstadoRequerimiento.Edicion;
                        entidadRequerimiento.CodigoEstadoEdicion = DatosConstantes.CodigoEstadoEdicion.EdicionParcial;
                    }
                    else
                    {
                        if (dataRequerimiento.IndicadorSolicitarModificacion)
                        {
                            codigoFormaEdicion = DatosConstantes.FormaEdicion.Flexible;
                            entidadRequerimiento.CodigoEstado = DatosConstantes.EstadoRequerimiento.Edicion;
                            entidadRequerimiento.CodigoEstadoEdicion = DatosConstantes.CodigoEstadoEdicion.SolicitudAutorizada;
                            entidadRequerimiento.ComentarioModificacion = dataRequerimiento.ComentarioModificacion;
                        }
                        else
                        {
                            codigoFormaEdicion = DatosConstantes.FormaEdicion.Cerrado;
                            entidadRequerimiento.CodigoEstado = DatosConstantes.EstadoRequerimiento.Aprobacion;
                            entidadRequerimiento.CodigoEstadoEdicion = null;
                        }
                    }

                    dataRequerimientoParrafo.CodigoRequerimiento = entidadRequerimiento.CodigoRequerimiento.ToString();
                    List<RequerimientoParrafoEntity> entidadRequerimientoParrafo = new List<RequerimientoParrafoEntity>();
                    List<RequerimientoParrafoVariableEntity> entidadRequerimientoParrafoVariable = new List<RequerimientoParrafoVariableEntity>();
                    List<RequerimientoBienEntity> entidadRequerimientoBien = new List<RequerimientoBienEntity>();
                    List<RequerimientoFirmanteEntity> entidadRequerimientoFirmante = new List<RequerimientoFirmanteEntity>();


                    foreach (var item in dataRequerimiento.RequerimientoDocumento.ListaRequerimientoParrafo)
                    {
                        item.CodigoRequerimiento = entidadRequerimiento.CodigoRequerimiento.ToString();
                        if (!entidadRequerimientoParrafo.Any(itemAny => itemAny.CodigoPlantillaParrafo == new Guid(item.CodigoPlantillaParrafo)))
                        {
                            var objRequerimientoParrafo = RequerimientoParrafoAdapter.RegistrarRequerimientoParrafo(item);
                            entidadRequerimientoParrafo.Add(objRequerimientoParrafo);
                            dataRequerimientoParrafoVariable.CodigoRequerimientoParrafo = objRequerimientoParrafo.CodigoRequerimientoParrafo.ToString();
                        }

                        foreach (var itemVariable in item.ListaRequerimientoParrafoVariable)
                        {
                            //Guardar en Requerimiento Párrafo Variable
                            if (!entidadRequerimientoParrafoVariable.Any(itemAny => itemAny.CodigoRequerimientoParrafo == new Guid(dataRequerimientoParrafoVariable.CodigoRequerimientoParrafo) && itemAny.CodigoVariable == new Guid(itemVariable.CodigoVariable)))
                            {
                                dataRequerimientoParrafoVariable.CodigoVariable = itemVariable.CodigoVariable;
                                switch (itemVariable.CodigoTipoVariable)
                                {
                                    case DatosConstantes.TipoVariable.Texto:
                                        dataRequerimientoParrafoVariable.ValorTexto = itemVariable.Valor;
                                        dataRequerimientoParrafoVariable.ValorNumeroString = null;
                                        dataRequerimientoParrafoVariable.ValorFechaString = null;
                                        dataRequerimientoParrafoVariable.ValorImagen = null;
                                        dataRequerimientoParrafoVariable.ValorTabla = null;
                                        dataRequerimientoParrafoVariable.ValorBien = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Numero:
                                        dataRequerimientoParrafoVariable.ValorNumeroString = itemVariable.Valor;
                                        dataRequerimientoParrafoVariable.ValorTexto = null;
                                        dataRequerimientoParrafoVariable.ValorFechaString = null;
                                        dataRequerimientoParrafoVariable.ValorImagen = null;
                                        dataRequerimientoParrafoVariable.ValorTabla = null;
                                        dataRequerimientoParrafoVariable.ValorBien = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Fecha:
                                        dataRequerimientoParrafoVariable.ValorFechaString = itemVariable.Valor;
                                        dataRequerimientoParrafoVariable.ValorTexto = null;
                                        dataRequerimientoParrafoVariable.ValorNumeroString = null;
                                        dataRequerimientoParrafoVariable.ValorImagen = null;
                                        dataRequerimientoParrafoVariable.ValorTabla = null;
                                        dataRequerimientoParrafoVariable.ValorBien = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Imagen:
                                        if (!string.IsNullOrWhiteSpace(itemVariable.Valor))
                                        {
                                            itemVariable.Valor = itemVariable.Valor.Replace("data:image/png;base64,", string.Empty);
                                            itemVariable.Valor = itemVariable.Valor.Replace("data:image/jpg;base64,", string.Empty);
                                            itemVariable.Valor = itemVariable.Valor.Replace("data:image/jpeg;base64,", string.Empty);
                                            itemVariable.Valor = itemVariable.Valor.Replace("data:image/tiff;base64,", string.Empty);
                                            byte[] bytes = Convert.FromBase64String(itemVariable.Valor);
                                            dataRequerimientoParrafoVariable.ValorImagen = bytes;
                                        }
                                        dataRequerimientoParrafoVariable.ValorTexto = null;
                                        dataRequerimientoParrafoVariable.ValorNumeroString = null;
                                        dataRequerimientoParrafoVariable.ValorFechaString = null;
                                        dataRequerimientoParrafoVariable.ValorTabla = null;
                                        dataRequerimientoParrafoVariable.ValorBien = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Tabla:
                                        dataRequerimientoParrafoVariable.ValorTabla = itemVariable.Valor;
                                        dataRequerimientoParrafoVariable.ValorTablaEditable = itemVariable.ValorEditable;
                                        dataRequerimientoParrafoVariable.ValorTexto = null;
                                        dataRequerimientoParrafoVariable.ValorNumeroString = null;
                                        dataRequerimientoParrafoVariable.ValorFechaString = null;
                                        dataRequerimientoParrafoVariable.ValorImagen = null;
                                        dataRequerimientoParrafoVariable.ValorBien = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Bien:
                                        dataRequerimientoParrafoVariable.ValorBien = itemVariable.Valor;
                                        dataRequerimientoParrafoVariable.ValorBienEditable = itemVariable.ValorEditable;
                                        dataRequerimientoParrafoVariable.ValorTexto = null;
                                        dataRequerimientoParrafoVariable.ValorNumeroString = null;
                                        dataRequerimientoParrafoVariable.ValorFechaString = null;
                                        dataRequerimientoParrafoVariable.ValorImagen = null;
                                        dataRequerimientoParrafoVariable.ValorTabla = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Firmante:
                                        dataRequerimientoParrafoVariable.ValorFirmante = itemVariable.Valor;
                                        dataRequerimientoParrafoVariable.ValorFirmanteEditable = itemVariable.ValorEditable;
                                        dataRequerimientoParrafoVariable.ValorTexto = null;
                                        dataRequerimientoParrafoVariable.ValorNumeroString = null;
                                        dataRequerimientoParrafoVariable.ValorFechaString = null;
                                        dataRequerimientoParrafoVariable.ValorImagen = null;
                                        dataRequerimientoParrafoVariable.ValorTabla = null;
                                        break;
                                    case DatosConstantes.TipoVariable.Lista:
                                        dataRequerimientoParrafoVariable.ValorLista = itemVariable.Valor;
                                        dataRequerimientoParrafoVariable.ValorNumeroString = null;
                                        dataRequerimientoParrafoVariable.ValorTexto = null;
                                        dataRequerimientoParrafoVariable.ValorFechaString = null;
                                        dataRequerimientoParrafoVariable.ValorImagen = null;
                                        dataRequerimientoParrafoVariable.ValorTabla = null;
                                        break;
                                    default:
                                        dataRequerimientoParrafoVariable.ValorTexto = null;
                                        dataRequerimientoParrafoVariable.ValorNumeroString = null;
                                        dataRequerimientoParrafoVariable.ValorFechaString = null;
                                        dataRequerimientoParrafoVariable.ValorImagen = null;
                                        dataRequerimientoParrafoVariable.ValorTabla = null;
                                        dataRequerimientoParrafoVariable.ValorBien = null;
                                        break;
                                }

                                var dataRequerimientoParrafoVariableEntity = RequerimientoParrafoVariableAdapter.RegistrarRequerimientoParrafoVariable(dataRequerimientoParrafoVariable);
                                entidadRequerimientoParrafoVariable.Add(dataRequerimientoParrafoVariableEntity);
                                if (itemVariable.CodigoTipoVariable == DatosConstantes.TipoVariable.Firmante)
                                {
                                    if (dataRequerimiento.ListaRequerimientoFirmante != null)
                                    {
                                        foreach (var firm in dataRequerimiento.ListaRequerimientoFirmante)
                                        {
                                            dataRequerimientoFirmante.CodigoRequerimientoParrafoVariable = dataRequerimientoParrafoVariableEntity.CodigoRequerimientoParrafoVariable.ToString();
                                            dataRequerimientoFirmante.NombreFirmante = firm.NombreFirmante;
                                            dataRequerimientoFirmante.DatoAdicional = firm.DatoAdicional;
                                            entidadRequerimientoFirmante.Add(RequerimientoFirmanteAdapter.RegistrarRequerimientoFirmante(dataRequerimientoFirmante));
                                        }
                                    }
                                }
                            }
                        }
                    }

                    dataRequerimientoBien.CodigoRequerimiento = entidadRequerimiento.CodigoRequerimiento.ToString();
                    //INICIO: Agregado por Julio Carrera - Norma Contable
                    //if (dataRequerimiento.ListaCodigoBien != null)
                    //{
                    //    foreach (var codigo in dataRequerimiento.ListaCodigoBien)
                    //    {
                    //        dataRequerimientoBien.CodigoBien = codigo;
                    //        entidadRequerimientoBien.Add(RequerimientoBienAdapter.RegistrarRequerimientoBien(dataRequerimientoBien));
                    //    }
                    //}
                    if (dataRequerimiento.ListaBienes != null)
                    {
                        foreach (var bien in dataRequerimiento.ListaBienes)
                        {
                            dataRequerimientoBien.CodigoBien = bien.CodigoBien.ToString();
                            dataRequerimientoBien.TipoTarifa = bien.CodigoTipoTarifa;
                            dataRequerimientoBien.TipoPeriodo = bien.CodigoPeriodoAlquiler;
                            dataRequerimientoBien.HorasMinimas = bien.HorasMinimas;
                            dataRequerimientoBien.Tarifa = bien.Tarifa;
                            dataRequerimientoBien.MayorMenor = bien.MayorMenor;
                            entidadRequerimientoBien.Add(RequerimientoBienAdapter.RegistrarRequerimientoBien(dataRequerimientoBien));
                        }
                    }
                    //FIN: Agregado por Julio Carrera - Norma Contable

                    int resultadoRequerimientoDocumento = 0;
                    int resultadoRequerimientoParrafo = 0;
                    int resultadoRequerimientoParrafoVariable = 0;
                    int resultadoRequerimientoBienVariable = 0;

                    using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                    {
                        try
                        {
                            RequerimientoParrafoEntityRepository.EliminarContenidoRequerimiento(new Guid(dataRequerimiento.CodigoRequerimiento));

                            if (dataRequerimiento.TipoRegistro == DatosConstantes.TipoRegistro.Total)
                            {
                                resultadoRequerimientoDocumento = RequerimientoDocumentoEntityRepository.RegistrarRequerimientoDocumento(entidadRequerimientoDocumento);
                            }
                            else
                            {
                                resultadoRequerimientoDocumento = 1;
                            }

                            if (resultadoRequerimientoDocumento == 1)
                            {
                                resultado.Result = 1;

                                foreach (var entidad in entidadRequerimientoParrafo)
                                {
                                    resultadoRequerimientoParrafo = RequerimientoParrafoEntityRepository.RegistrarRequerimientoParrafo(entidad);
                                }

                                if (entidadRequerimientoParrafoVariable.Count > 0)
                                {
                                    if (resultadoRequerimientoParrafo == 1)
                                    {
                                        resultado.Result = 1;
                                        foreach (var entidad in entidadRequerimientoParrafoVariable)
                                        {
                                            resultadoRequerimientoParrafoVariable = RequerimientoParrafoVariableEntityRepository.RegistrarRequerimientoParrafoVariable(entidad);
                                        }

                                        //Inicio - Registrar Requerimiento Bien
                                        if (resultadoRequerimientoParrafoVariable == 1)
                                        {
                                            resultado.Result = 1;

                                            foreach (var entidad in entidadRequerimientoBien)
                                            {
                                                resultadoRequerimientoBienVariable = RequerimientoBienEntityRepository.RegistrarRequerimientoBien(entidad);
                                            }

                                            if (entidadRequerimientoFirmante != null && entidadRequerimientoFirmante.Count > 0)
                                            {
                                                foreach (var item in entidadRequerimientoFirmante)
                                                {
                                                    RequerimientoFirmanteEntityRepository.Insertar(item);
                                                    RequerimientoFirmanteEntityRepository.GuardarCambios();
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

                    if (resultadoRequerimientoParrafoVariable == 1 && dataRequerimiento.TipoRegistro == DatosConstantes.TipoRegistro.Total)
                    {
                        //Registro de Número de Requerimiento
                        RequerimientoEntityRepository.EditarRequerimiento(new RequerimientoEntity()
                        {
                            CodigoRequerimiento = entidadRequerimiento.CodigoRequerimiento.Value,
                            CodigoEstado = entidadRequerimiento.CodigoEstado,
                            CodigoEstadoEdicion = entidadRequerimiento.CodigoEstadoEdicion,
                            NumeroRequerimiento = numeroRequerimiento,
                            ComentarioModificacion = entidadRequerimiento.ComentarioModificacion,
                            UsuarioModificacion = entornoActualAplicacion.UsuarioSession,
                            FechaModificacion = DateTime.Now,
                            TerminalModificacion = entornoActualAplicacion.Terminal,
                            EsFlexible = codigoFormaEdicion == DatosConstantes.FormaEdicion.Flexible ? true : false
                        });

                        if (!dataRequerimiento.IndicadorSolicitarModificacion)
                        {
                            var RequerimientoEstadio = RequerimientoLogicRepository.ListarRequerimientoEstadio(null, entidadRequerimiento.CodigoRequerimiento.Value).Where(item => item.CodigoEstadoRequerimientoEstadio == DatosConstantes.CodigoEstadoRequerimientoEstadio.Iniciado).OrderBy(item => item.FechaIngreso).LastOrDefault();
                            ApruebaRequerimientoEstadio(entidadRequerimiento.CodigoRequerimiento.Value, RequerimientoEstadio.CodigoRequerimientoEstadio, "");
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
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }

            return resultado;
        }

        /// <summary>
        /// Registra el documento del Requerimiento de adhesión
        /// </summary>
        /// <param name="dataRequerimiento">Datos a registrar de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarListadoRequerimientoAdhesion(RequerimientoRequest dataRequerimiento)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            //RequerimientoEstadioRequest dataRequerimientoEstadio = new RequerimientoEstadioRequest();
            UnidadOperativaResponse unidadOperativa = null;
            string nombreFile, lsDirectorioDestino, listName, folderName, hayError = string.Empty;

            try
            {
                var entidadRequerimiento = ObtieneRequerimientoPorID(new Guid(dataRequerimiento.CodigoRequerimiento)).Result;

                entidadRequerimiento.IndicadorVersionOficial = false;

                //Generando Requerimiento documento
                dataRequerimiento.RequerimientoDocumento.CodigoRequerimiento = dataRequerimiento.CodigoRequerimiento;
                dataRequerimiento.RequerimientoDocumento.CodigoArchivo = 0;
                dataRequerimiento.RequerimientoDocumento.RutaArchivoSharePoint = "";
                dataRequerimiento.RequerimientoDocumento.IndicadorActual = true;
                dataRequerimiento.RequerimientoDocumento.Version = 1;
                RequerimientoDocumentoEntity entidadRequerimientoDocumento = RequerimientoDocumentoAdapter.RegistrarRequerimientoDocumento(dataRequerimiento.RequerimientoDocumento);

                entidadRequerimiento.CodigoEstado = DatosConstantes.EstadoRequerimiento.Aprobacion;
                entidadRequerimiento.CodigoEstadoEdicion = null;

                /*Registramos información del SharePoint*/
                unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = entidadRequerimiento.CodigoUnidadOperativa.ToString() }).Result.FirstOrDefault();
                #region InformacionRepositorioSharePoint
                nombreFile = string.Format("{0}.{1}", entidadRequerimientoDocumento.CodigoRequerimientoDocumento.ToString(), dataRequerimiento.RequerimientoDocumento.ExtencionArchivo);
                ProcessResult<string> miDirectorio = RetornaDirectorioFile(new Guid(dataRequerimiento.CodigoRequerimiento), unidadOperativa.Nombre, nombreFile, dataRequerimiento.FechaInicioVigencia);
                lsDirectorioDestino = miDirectorio.Result.ToString();
                string[] nivelCarpeta = lsDirectorioDestino.Split(new char[] { '/' });
                listName = nivelCarpeta[0];
                folderName = string.Format("{0}/{1}", nivelCarpeta[1], nivelCarpeta[2]);
                #endregion

                #region GrabarContenidoRequerimientoSHP
                MemoryStream msFile = new MemoryStream(dataRequerimiento.RequerimientoDocumento.Documento);
                if (msFile != null)
                {
                    var regSHP = sharePointService.RegistraArchivoSharePoint(ref hayError, listName, folderName, nombreFile, msFile);
                    if (Convert.ToInt32(regSHP.Result) > 0 && hayError == string.Empty)
                    {
                        entidadRequerimientoDocumento.CodigoArchivo = Convert.ToInt32(regSHP.Result);
                        entidadRequerimientoDocumento.RutaArchivoSharePoint = lsDirectorioDestino;
                    }
                    else
                    {
                        if (Convert.ToInt32(regSHP.Result) > 0)
                        {
                            var fileShpDelete = sharePointService.EliminaArchivoSharePoint(new List<int>() { Convert.ToInt32(regSHP.Result) }, listName, ref hayError);
                        }
                        resultado.IsSuccess = false;
                        resultado.Exception = new ApplicationLayerException<RequerimientoService>("Ocurrió un problema al registra el archivo en el SharePoint: " + hayError);
                        LogBL.grabarLogError(new Exception(hayError));
                        return resultado;
                    }
                }
                else
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<RequerimientoService>("El documento presenta errores.");
                    LogBL.grabarLogError(new Exception("El documento presenta errores."));
                }

                #endregion

                int resultadoRequerimientoDocumento = 0;
                using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    try
                    {
                        RequerimientoParrafoEntityRepository.EliminarContenidoRequerimiento(new Guid(dataRequerimiento.CodigoRequerimiento));//AUMENTANDO PARA QUE SALGA VERSION CORRECTA
                        resultadoRequerimientoDocumento = RequerimientoDocumentoEntityRepository.RegistrarRequerimientoDocumento(entidadRequerimientoDocumento);

                        if (resultadoRequerimientoDocumento == 1)
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

                var tipoRequerimiento = politicaService.ListarTipoServicioDinamico().Result.Where(p => p.Atributo1 == entidadRequerimiento.CodigoTipoRequerimiento).FirstOrDefault();

                //Registro de Número de Requerimiento(prueba)
                string numeroRequerimiento = string.IsNullOrEmpty(entidadRequerimiento.NumeroRequerimiento) ? GenerarNumeroRequerimiento(unidadOperativa, tipoRequerimiento.Atributo1, tipoRequerimiento.Atributo4, entidadRequerimiento.CodigoTipoDocumento) : entidadRequerimiento.NumeroRequerimiento;
                //string numeroRequerimiento = GenerarNumeroRequerimiento(unidadOperativa, tipoRequerimiento.Atributo1, tipoRequerimiento.Atributo4, entidadRequerimiento.CodigoTipoDocumento);

                RequerimientoEntityRepository.EditarRequerimiento(new RequerimientoEntity()
                {
                    CodigoRequerimiento = entidadRequerimiento.CodigoRequerimiento.Value,
                    CodigoEstado = entidadRequerimiento.CodigoEstado,
                    CodigoEstadoEdicion = entidadRequerimiento.CodigoEstadoEdicion,
                    NumeroRequerimiento = entidadRequerimiento.CodigoTipoDocumento == DatosConstantes.TipoDocumento.Adenda ? entidadRequerimiento.NumeroRequerimiento : numeroRequerimiento,
                    ComentarioModificacion = entidadRequerimiento.ComentarioModificacion,
                    UsuarioModificacion = entornoActualAplicacion.UsuarioSession,
                    FechaModificacion = DateTime.Now,
                    TerminalModificacion = entornoActualAplicacion.Terminal
                });

                var RequerimientoEstadio = RequerimientoLogicRepository.ListarRequerimientoEstadio(null, entidadRequerimiento.CodigoRequerimiento.Value).Where(item => item.CodigoEstadoRequerimientoEstadio == DatosConstantes.CodigoEstadoRequerimientoEstadio.Iniciado).OrderBy(item => item.FechaIngreso).LastOrDefault();
                ApruebaRequerimientoEstadio(entidadRequerimiento.CodigoRequerimiento.Value, RequerimientoEstadio.CodigoRequerimientoEstadio, "");
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la búsqueda de listado Requerimientos principales
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de Requerimientos</returns>
        public ProcessResult<List<ListadoRequerimientoResponse>> ListadoRequerimientoPrincipal(ListadoRequerimientoRequest filtro)
        {
            ProcessResult<List<ListadoRequerimientoResponse>> resultado = new ProcessResult<List<ListadoRequerimientoResponse>>();
            try
            {
                List<ListadoRequerimientoLogic> listado = listadoRequerimientoLogicRepository.ListadoRequerimientoPrincipal(filtro.NumeroRequerimiento, filtro.Descripcion, filtro.TipoServicioLC);
                resultado.Result = new List<ListadoRequerimientoResponse>();
                foreach (var registro in listado)
                {
                    var listadoRequerimiento = ListadoRequerimientoAdapter.ObtenerListadoRequerimientoPaginado(registro);
                    resultado.Result.Add(listadoRequerimiento);
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Eliminar Requerimiento
        /// </summary>
        /// <param name="listaCodigoRequerimiento">Lista de Códigos de Requerimiento a Eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> EliminarListadoRequerimiento(List<object> listaCodigoRequerimiento)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            try
            {
                foreach (var codigo in listaCodigoRequerimiento)
                {
                    var llaveEntidad = new Guid(codigo.ToString());
                    RequerimientoEntityRepository.EliminarEntorno(entornoActualAplicacion, llaveEntidad);
                }

                resultado.Result = RequerimientoEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Actualizar Requerimiento
        /// </summary>
        /// <param name="CodigoRequerimiento">Códigos de Requerimiento a Actualizar</param>
        /// <param name="TipoRequerimiento"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> ActualizarRequerimiento(Guid CodigoRequerimiento, string TipoRequerimiento)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();
            try
            {

                //var llaveEntidad = new Guid(listaCodigoRequerimiento.CodigoRequerimiento.ToString());
                RequerimientoEntity lista = new RequerimientoEntity();
                var entidadSincronizar = RequerimientoEntityRepository.GetById(CodigoRequerimiento);
                //lista.CodigoRequerimiento = CodigoRequerimiento;
                entidadSincronizar.CodigoTipoServicio = TipoRequerimiento;
                RequerimientoEntityRepository.EditarRequerimiento(entidadSincronizar);
                resultado.Result = RequerimientoEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Obtiene el Monto Acumulado del Requerimiento Principal más sus Adendas
        /// </summary>
        /// <param name="codigoRequerimientoPrincipal">Código de Requerimiento Principal</param>
        /// <returns>Registro con el Monto Acumulado del Requerimiento Principal más sus Adendas</returns>
        public ProcessResult<List<ListadoRequerimientoResponse>> ObtenerMontoAcumuladoRequerimiento(string codigoRequerimientoPrincipal)
        {
            ProcessResult<List<ListadoRequerimientoResponse>> resultado = new ProcessResult<List<ListadoRequerimientoResponse>>();
            try
            {
                List<ListadoRequerimientoLogic> listado = listadoRequerimientoLogicRepository.ObtenerMontoAcumuladoRequerimiento(new Guid(codigoRequerimientoPrincipal));
                resultado.Result = new List<ListadoRequerimientoResponse>();

                foreach (var registro in listado)
                {
                    var listadoRequerimientoResponse = new ListadoRequerimientoResponse();
                    listadoRequerimientoResponse.MontoAcumulado = registro.MontoAcumulado;
                    resultado.Result.Add(listadoRequerimientoResponse);
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene listado de variables de los parrafos de  un Requerimiento
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Lista de variables de parrafos de Requerimiento</returns>
        public ProcessResult<List<RequerimientoParrafoVariableResponse>> ObtenerVariablesRequerimientoParrafo(string codigoRequerimiento)
        {
            ProcessResult<List<RequerimientoParrafoVariableResponse>> resultado = new ProcessResult<List<RequerimientoParrafoVariableResponse>>();
            try
            {
                List<RequerimientoParrafoVariableLogic> listado = listadoRequerimientoLogicRepository.ObtenerVariablesRequerimientoParrafo(new Guid(codigoRequerimiento));

                resultado.Result = new List<RequerimientoParrafoVariableResponse>();

                foreach (var registro in listado)
                {
                    var RequerimientoParrafoVariable = ListadoRequerimientoAdapter.ObtenerRequerimientoParrafoVariable(registro);

                    if (RequerimientoParrafoVariable.CodigoTipo == DatosConstantes.TipoVariable.Bien)
                    {
                        RequerimientoParrafoVariable.ListaRequerimientoBien = new List<RequerimientoBienResponse>();

                        var ListaRequerimientoBienLogic = listadoRequerimientoLogicRepository.ObtenerBienesRequerimiento(new Guid(codigoRequerimiento));

                        foreach (var item in ListaRequerimientoBienLogic)
                        {
                            var RequerimientoBien = ListadoRequerimientoAdapter.ObtenerRequerimientoBienResponse(item);
                            RequerimientoParrafoVariable.ListaRequerimientoBien.Add(RequerimientoBien);
                        }
                    }
                    else if (RequerimientoParrafoVariable.CodigoTipo == DatosConstantes.TipoVariable.Firmante)
                    {
                        RequerimientoParrafoVariable.ListaRequerimientoFirmante = new List<RequerimientoFirmanteResponse>();

                        var ListaRequerimientoFirmanteLogic = listadoRequerimientoLogicRepository.ObtenerFirmantesRequerimiento(new Guid(codigoRequerimiento));

                        foreach (var item in ListaRequerimientoFirmanteLogic)
                        {
                            var RequerimientoFirmante = ListadoRequerimientoAdapter.ObtenerRequerimientoFirmanteResponse(item);
                            RequerimientoParrafoVariable.ListaRequerimientoFirmante.Add(RequerimientoFirmante);
                        }
                    }
                    resultado.Result.Add(RequerimientoParrafoVariable);
                }
            }
            catch (Exception ex)
            {
                LogBL.grabarLogError(ex);
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return resultado;
        }

        /// <summary>
        /// Eliminar Requerimiento
        /// </summary>
        /// <param name="filtro">Datos del Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<string> EliminarRequerimiento(ListadoRequerimientoRequest filtro)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                resultado.Result = listadoRequerimientoLogicRepository.EliminarRequerimiento(new Guid(filtro.CodigoRequerimiento), filtro.ComentarioModificacion, entornoActualAplicacion.UsuarioSession, entornoActualAplicacion.Terminal).ToString();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Registrar la copia de un Requerimiento
        /// </summary>
        /// <param name="dataRequerimiento">Datos del Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<object> RegistrarCopiaRequerimiento(RequerimientoRequest dataRequerimiento)
        {
            ProcessResult<object> resultado = new ProcessResult<object>();

            try
            {
                dataRequerimiento.IndicadorVersionOficial = false;

                if (dataRequerimiento.CodigoTipoDocumento == "C")
                {
                    dataRequerimiento.MontoAcumuladoString = dataRequerimiento.MontoRequerimientoString;
                }

                var esAdendaRequerimientoVencido = false;

                if (dataRequerimiento.CodigoTipoDocumento == DatosConstantes.TipoDocumento.Adenda)
                {
                    var entidadRequerimientoPrincipal = ObtieneRequerimientoPorID(new Guid(dataRequerimiento.CodigoRequerimientoPrincipal.ToString())).Result;

                    var listaAdendas = listadoRequerimientoLogicRepository.BuscarRequerimiento(null, dataRequerimiento.CodigoRequerimientoPrincipal, string.Empty, string.Empty, dataRequerimiento.CodigoTipoDocumento, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty).OrderByDescending(a => a.NumeroAdenda).FirstOrDefault();
                    dataRequerimiento.NumeroAdenda = (listaAdendas == null) ? 1 : listaAdendas.NumeroAdenda + 1;

                    dataRequerimiento.NumeroAdendaConcatenado = string.Format(DatosConstantes.Formato.FormatoNumeroAdenda, entidadRequerimientoPrincipal.NumeroRequerimiento, dataRequerimiento.NumeroAdenda);
                    dataRequerimiento.NumeroRequerimiento = entidadRequerimientoPrincipal.NumeroRequerimiento;

                    if (listaAdendas != null && listaAdendas.CodigoEstadoRequerimiento != DatosConstantes.EstadoRequerimiento.Vigente)
                    {
                        resultado.IsSuccess = false;
                        resultado.Exception = new ApplicationLayerException<RequerimientoService>("La Adenda N° " + listaAdendas.NumeroAdendaConcatenado + " no se encuentra en estado Vigente");
                        return resultado;
                    }

                    if (entidadRequerimientoPrincipal.CodigoEstado == DatosConstantes.EstadoRequerimiento.Vencido && dataRequerimiento.CodigoTipoRequerimiento != DatosConstantes.TipoServicio.RequerimientoHistorico)
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
                            DateTime fechaInicio = (DateTime)entidadRequerimientoPrincipal.FechaFinVigencia;
                            DateTime fechaFin = DateTime.Today;
                            TimeSpan diferencia = (fechaFin - fechaInicio);

                            var diasRequerimiento = diferencia.Days;

                            int valorDiasParametro = 0;
                            bool validaDiasParametro = int.TryParse(diasParametro.Valor, out valorDiasParametro);

                            if (validaDiasParametro && diasRequerimiento > valorDiasParametro)
                            {
                                resultado.IsSuccess = false;
                                resultado.Exception = new ApplicationLayerException<RequerimientoService>(string.Format("La adenda supera los {0} días del período de gracia.", valorDiasParametro));
                                return resultado;
                            }
                            else
                            {
                                esAdendaRequerimientoVencido = true;
                            }
                        }
                    }

                }

                dataRequerimiento.CodigoEstado = DatosConstantes.EstadoRequerimiento.Edicion;
                dataRequerimiento.CodigoEstadoEdicion = DatosConstantes.CodigoEstadoEdicion.EdicionParcial;

                //Asignación de Plantilla                
                var resultadoPlantilla = plantillaService.BuscarPlantilla(new PlantillaRequest()
                {
                    CodigoTipoRequerimiento = dataRequerimiento.CodigoTipoServicio,
                    CodigoTipoDocumentoRequerimiento = dataRequerimiento.CodigoTipoDocumento,
                    IndicadorAdhesion = dataRequerimiento.IndicadorAdhesion,
                    CodigoEstadoVigencia = DatosConstantes.EstadoVigencia.Vigente
                }).Result.FirstOrDefault();

                if (resultadoPlantilla != null)
                {
                    dataRequerimiento.CodigoPlantilla = resultadoPlantilla.CodigoPlantilla;
                    if (dataRequerimiento.EsFlexible.Value && dataRequerimiento.CodigoTipoDocumento != DatosConstantes.TipoDocumento.Adenda)
                    {
                        var tipoRequerimiento = politicaService.ListarTipoServicioDinamico().Result.Where(p => p.Atributo1 == dataRequerimiento.CodigoTipoRequerimiento).FirstOrDefault();
                        UnidadOperativaResponse unidadOperativa = null;
                        unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { CodigoUnidadOperativa = dataRequerimiento.CodigoUnidadOperativa.ToString() }).Result.FirstOrDefault();
                        string numeroRequerimiento = GenerarNumeroRequerimiento(unidadOperativa, tipoRequerimiento.Atributo1, tipoRequerimiento.Atributo4, dataRequerimiento.CodigoTipoDocumento);
                        dataRequerimiento.NumeroRequerimiento = numeroRequerimiento;
                        dataRequerimiento.CodigoEstado = "E";
                        dataRequerimiento.CodigoEstadoEdicion = "EP";
                    }

                    RequerimientoEntity entidadRequerimiento = ListadoRequerimientoAdapter.RegistrarCopiaRequerimiento(dataRequerimiento);

                    var resultadoRequerimiento = RequerimientoEntityRepository.RegistrarRequerimiento(entidadRequerimiento);

                    if (resultadoRequerimiento != 0)
                    {
                        if (dataRequerimiento.EsFlexible.Value)
                        {
                            var doctos = DocumentosPorRequerimiento(entidadRequerimiento.CodigoRequerimientoOriginal.Value);
                            if (doctos.Result != null && doctos.Result.Count > 0)
                            {
                                var contenido = doctos.Result[0];
                                RequerimientoDocumentoEntity entidadRequerimientoDocumento = new RequerimientoDocumentoEntity();
                                entidadRequerimientoDocumento.CodigoRequerimientoDocumento = Guid.NewGuid();
                                entidadRequerimientoDocumento.CodigoRequerimiento = entidadRequerimiento.CodigoRequerimiento;
                                entidadRequerimientoDocumento.CodigoArchivo = 0;
                                entidadRequerimientoDocumento.RutaArchivoSharePoint = string.Empty;
                                entidadRequerimientoDocumento.Contenido = contenido.Contenido;
                                entidadRequerimientoDocumento.ContenidoBusqueda = string.Empty;
                                entidadRequerimientoDocumento.IndicadorActual = true;
                                entidadRequerimientoDocumento.Version = 1;
                                entidadRequerimientoDocumento.FechaCreacion = DateTime.Now;
                                RequerimientoDocumentoEntityRepository.RegistrarRequerimientoDocumento(entidadRequerimientoDocumento);
                            }
                        }
                        //Registro de Requerimiento Estadio
                        RequerimientoEstadioRequest dataRequerimientoEstadio = new RequerimientoEstadioRequest();

                        var resultadoFlujoAprobacionEstadio = flujoAprobacionService.BuscarBandejaFlujoAprobacionEstadio(null, dataRequerimiento.CodigoFlujoAprobacion)
                                                              .Result.OrderBy(x => x.Orden).FirstOrDefault();

                        if (resultadoFlujoAprobacionEstadio != null)
                        {
                            entidadRequerimiento.CodigoEstadioActual = new Guid(resultadoFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio);
                        }

                        dataRequerimientoEstadio.CodigoFlujoAprobacionEstadio = new Guid(resultadoFlujoAprobacionEstadio.CodigoFlujoAprobacionEstadio);
                        dataRequerimientoEstadio.CodigoRequerimiento = entidadRequerimiento.CodigoRequerimiento;
                        dataRequerimientoEstadio.FechaIngreso = DateTime.Now.Date;

                        if (resultadoFlujoAprobacionEstadio.CodigoResponsable == null)
                        {
                            dataRequerimientoEstadio.CodigoResponsable = null;
                        }
                        else
                        {
                            dataRequerimientoEstadio.CodigoResponsable = Guid.Parse(resultadoFlujoAprobacionEstadio.CodigoResponsable);
                        }

                        dataRequerimientoEstadio.CodigoEstadoRequerimientoEstadio = DatosConstantes.CodigoEstadoRequerimientoEstadio.Iniciado;
                        RequerimientoEstadioEntity entidadRequerimientoEstadio = RequerimientoEstadioAdapter.RegistrarRequerimientoEstadio(dataRequerimientoEstadio);
                        RequerimientoEstadioEntityRepository.RegistrarRequerimientoEstadio(entidadRequerimientoEstadio);

                        //Registrar adendas de Requerimiento vencido en tabla temporal para notificación (envio de correo)
                        if (esAdendaRequerimientoVencido == true)
                        {
                            RequerimientoLogicRepository.RegistraAdendaRequerimientoVencido((Guid)dataRequerimiento.CodigoUnidadOperativa, dataRequerimiento.NumeroRequerimiento, dataRequerimiento.Descripcion, dataRequerimiento.NumeroAdenda, dataRequerimiento.NumeroAdendaConcatenado);
                        }

                        resultado.IsSuccess = true;
                        resultado.Result = entidadRequerimiento.CodigoRequerimiento;
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
                resultado.Exception = new ApplicationLayerException<RequerimientoService>(e.Message);
            }
            return resultado;
        }

        /// <summary>
        /// Método para recuperar los registros ordenados de la bandeja de proceso.
        /// </summary>
        /// <param name="filtro">Objeto Requerimiento Request</param>
        /// <param name="lstTipoRequerimiento">Lista de Tipos de Servicio</param>
        /// <param name="lstTipoServicio">Lista de Tipo de Requerimiento</param>
        /// <returns>Registros de bandeja de procesos</returns>                
        public ProcessResult<List<RequerimientoResponse>> BuscarBandejaProcesosRequerimientoOrdenado(RequerimientoRequest filtro, List<CodigoValorResponse> lstTipoRequerimiento = null, List<CodigoValorResponse> lstTipoServicio = null)
        {
            ProcessResult<List<RequerimientoLogic>> listaRegistros = new ProcessResult<List<RequerimientoLogic>>();
            ProcessResult<List<RequerimientoResponse>> rpta = new ProcessResult<List<RequerimientoResponse>>();
            List<CodigoValorResponse> listaTipoServicio;
            List<CodigoValorResponse> listaTipoRequerimiento;
            RequerimientoResponse itemRpta;
            try
            {
                if (lstTipoRequerimiento != null)
                {
                    listaTipoServicio = lstTipoRequerimiento;
                }
                else
                {
                    listaTipoServicio = politicaService.ListarTipoRequerimiento().Result;
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

                listaRegistros.Result = RequerimientoLogicRepository.ListaBandejaRequerimientosOrdenado(
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

                rpta.Result = new List<RequerimientoResponse>();
                foreach (RequerimientoLogic itemLogic in listaRegistros.Result)
                {
                    itemRpta = new RequerimientoResponse();
                    itemRpta = RequerimientoAdapter.ObtenerRequerimientoResponseDeLogic(itemLogic, listaUO.Result, listaTipoServicio, listaTipoRequerimiento);
                    rpta.Result.Add(itemRpta);
                }

            }
            catch (Exception ex)
            {
                rpta.IsSuccess = false;
                rpta.Exception = new ApplicationLayerException<RequerimientoService>(ex);
            }
            return rpta;
        }

        /// <summary>
        /// Permite generar un pdf desde un html
        /// </summary>
        /// <param name="htmlCuerpo">script de html</param>
        /// <param name="htmlPie">script de html del pie de pagina</param>
        /// <param name="htmlCabecera">Cabecera de PDF</param>
        /// <param name="codigoRequerimiento">Código de Requerimiento</param>
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
                                          Guid? codigoRequerimiento,
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

                //htmlCuerpo = "<table style='width:100%'><tr><td style='width:50%'><div style='width:100%; margin: auto;text-align: center; padding:120px 0px 0px 0px;font-family:arial,helvetica,sans-serif;font-size:11px'><p><b>..................................................</b></p><p style='margin: auto;font-family:arial,helvetica,sans-serif'>John Tamayo Ortega</p><br></br><p style='margin: auto;font-family:arial,helvetica,sans-serif'>Representante Legal</p></div></td><td style='width:50%'><div style='width:100%; margin: auto;text-align: center; padding:120px 0px 0px 0px;font-family:arial,helvetica,sans-serif;font-size:11px'><p><b>..................................................</b></p><p style='margin: auto;font-family:arial,helvetica,sans-serif'>José Luis Del Corral Delgado</p><br></br><p style='margin: auto;font-family:arial,helvetica,sans-serif'>Representante Legal</p></div></td></tr></table></strong></span></span></p>\r\n\r\n<p style=\"text-align:center\">&nbsp;</p>\r\n\r\n<p style=\"text-align:center\"><span style=\"font-size:11px\"><span style=\"font-family:arial,helvetica,sans-serif\"><strong>EL ARRENDADOR</strong></span></span></p>\r\n\r\n<p style=\"text-align:center\"><span style=\"font-size:11px\"><span style=\"font-family:arial,helvetica,sans-serif\"><strong></strong></span></span></p><br></br><table style=\"width:100%\" class=\"firmanteRequerimientoParrafo\" codigovariable=\"a7f0febd-502c-4bc6-bbee-bd20ad3ba379\" indicadorparrafo=\"7\" codigoplantillaparrafo=\"961c8079-da2a-4a4b-a87d-233e9dda18be\"> <tbody><tr><td style=\"width:50%\"><div style=\"width:100%; margin: auto;text-align: center; padding:120px 0px 0px 0px;font-family:arial,helvetica,sans-serif;font-size:11px\"><p><b>..................................................</b></p><p style=\"margin: auto;font-family:arial,helvetica,sans-serif\">.\r\nPablo Bustamante Bellido</p><br></br><p style=\"margin: auto;font-family:arial,helvetica,sans-serif\">Representante Legal</p></div></td></tr></tbody></table><p></p>\r\n\r\n<p>&nbsp;</p>";

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

                    //htmlCuerpo = "<div><br></br><p style='text-align: center;'><u><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong>Primera Adenda al Requerimiento de Arrendamiento de Vehículo</strong></span></span></u></p><p style='text-align: center;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'>Conste por el presente documento la Adenda al Requerimiento de Arrendamiento de Vehículo (la “Adenda”) que suscriben:</span></span></p><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong>STRACON S.A.</strong> con domicilio en Calle Las Begonias 415</span>, Torre Begonias, piso 13, distrito de San Isidro, Lima</span>?,<span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'> identificado con RUC Nº 20546121250, debidamente representada por el/la señor(a) John Tamayo Ortega, identificado/a con&nbsp;DNI: 10550218, y por el/la señor(a) José Luis Del Corral Delgado, identificado(a) con DNI: 09340022, ambos debidamente facultados según poderes inscritos en la Partida Electrónica Nº 12760430 del Registro de Personas Jurídicas de Lima, a quien en adelante se le denominará (<strong>“STRACON ”</strong>); y,</span></span></p><br></br><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong>GENERAL HOUSE DE COMERCIO INDUSTRIAL S.A .C.</strong>, con domicilio en Ca. Bat. Independencia N° 397, Dpto 202, La Victoria, Lima, con RUC N° 20213447611, debidamente representada por el señor Grimaldo Quispe Palomino, identificado con DNI N° 21288939 según poder inscrito en la Partida Electrónica N° 11260542 del Registro de Personas Jurídicas de Lima,,&nbsp;a quien en adelante se le denominará (el <strong>Arrendamiento de Vehículo</strong>).</span></span></p><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong>STRACON </strong>y el Arrendamiento de Vehículo&nbsp;podrán ser denominados de manera conjunta como las “Partes” e individualmente como la “Parte”.</span></span></p><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'>Las Partes suscriben la presente Adenda en los siguientes términos:</span></span></p><br></br><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><u><strong>PRIMERA:</strong></u>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<u><strong>ANTECEDENTES</strong></u></span></span></p><br></br><table style='width: 100%; border-collapse: collapse;' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'>Con fecha 31/07/2019, las Partes suscribieron el Requerimiento de Arrendamiento de Vehículo&nbsp;(en adelante, el “Requerimiento”), mediante el cual el ARRENDADOR se obliga a ceder temporalmente a STRACON el uso de un vehículo.</span></span></td></tr></tbody></table><br></br><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><u><strong>SEGUNDA:</strong></u>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<strong><u>OBJETO DEL CONTRATO</u></strong></span></span></p><br></br><table style='width: 100%; border-collapse: collapse;' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'>Por medio de la presente Adenda, las Partes acuerdan ampliar la vigencia del Requerimiento a partir del 01 de enero del 2019 al 30 de junio del 2019.</span></span></td></tr></tbody></table><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><u><strong>TERCERA:&nbsp;</strong></u>&nbsp; &nbsp;<u><strong>RATIFICACION</strong></u></span></span></p><br></br><table style='width: 100%; border-collapse: collapse;' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'>Las partes acuerdan ratificar las demás cláusulas del Requerimiento que no hayan sido modificados en tanto no se opongan a la presente adenda, manteniendo vigentes e inalterables las condiciones restantes.</span></span></td></tr></tbody></table><br></br><table style='width: 100%; border-collapse: collapse;' border='0' cellspacing='0' cellpadding='0'><tbody><tr><td><p style='text-align: justify;'>&nbsp;</p><p style='text-align: justify;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'>En señal de conformidad las Partes suscriben la presente Adenda por duplicado con fecha 28/12/2018.</span></span></p></td></tr></tbody></table><p style='text-align: center;'>&nbsp;</p><p style='text-align: center;'>&nbsp;</p><p style='text-align: center;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong>STRACON S.A.</strong></span></span></p><p style='text-align: center;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong><br></br><table style='width:100%'><tr><td style='width:50%'><div style='width:100%; margin: auto;text-align: center; padding:120px 0px 0px 0px;font-family:arial,helvetica,sans-serif;font-size:11px'><p><b>..................................................</b></p><p style='margin: auto;font-family:arial,helvetica,sans-serif'>Administración Plataforma 2</p><br></br><p style='margin: auto;font-family:arial,helvetica,sans-serif'>Representante Legal</p></div></td><td style='width:50%'><div style='width:100%; margin: auto;text-align: center; padding:120px 0px 0px 0px;font-family:arial,helvetica,sans-serif;font-size:11px'><p><b>..................................................</b></p><p style='margin: auto;font-family:arial,helvetica,sans-serif'>Administración Plataforma 2</p><br></br><p style='margin: auto;font-family:arial,helvetica,sans-serif'>Representante Legal</p></div></td></tr></table></strong></span></span></p><p>&nbsp;</p><p style='text-align: center;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong>EL ARRENDADOR</strong></span></span></p><p style='text-align: center;'><span style='font-size: 11px;'><span style='font-family: arial,helvetica,sans-serif;'><strong></strong></span></span><br></br><table class='firmanteRequerimientoParrafo' style='width: 100%;' codigovariable='a7f0febd-502c-4bc6-bbee-bd20ad3ba379' codigoplantillaparrafo='2af90f43-2580-449b-8955-1f12f16da8a3' indicadorparrafo='3'> <tbody><tr><td style='width: 50%;'><div style='margin: auto; padding: 120px 0px 0px; width: 100%; text-align: center; font-family: arial,helvetica,sans-serif; font-size: 11px;'><p><b>..................................................</b></p><p style='margin: auto; font-family: arial,helvetica,sans-serif;'>Grimaldo Quispe Palomino</p><br></br><p style='margin: auto; font-family: arial,helvetica,sans-serif;'>Representante Legal</p></div></td><td style='width: 50%;'><div style='margin: auto; padding: 120px 0px 0px; width: 100%; text-align: center; font-family: arial,helvetica,sans-serif; font-size: 11px;'><p><b>..................................................</b></p><p style='margin: auto; font-family: arial,helvetica,sans-serif;'></p><br></br><p style='margin: auto; font-family: arial,helvetica,sans-serif;'></p></div></td></tr></tbody></table><p></p></p></div>";

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
    public class ParametrosNotificacionReq
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid codigoRequerimientoEstadio { get; set; }
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
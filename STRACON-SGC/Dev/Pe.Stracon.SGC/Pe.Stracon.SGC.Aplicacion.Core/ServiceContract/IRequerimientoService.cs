using System;
using System.Collections.Generic;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Aplicacion.Core.ServiceContract
{
    /// <summary>
    /// Servicio que representa los Requerimientos
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150525 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IRequerimientoService : IGenericService
    {
        /// <summary>
        /// lista las unidades operativas por responsable
        /// </summary>
        /// <param name="codigoResponsable">código de responsable</param>
        /// <returns>Lista con el resultado de la operación</returns>
        ProcessResult<List<UnidadOperativaResponse>> ListarUnidadOperativaResponsable(Guid codigoResponsable);

        /// <summary>
        /// Método para recuperar los registros de la bandeja de proceso.
        /// </summary>
        /// <param name="filtro">Objeto Requerimiento Request</param>
        /// <param name="lstTipoServicio">Lista de Tipos de Servicio</param>
        /// <param name="lstTipoRqto">Lista de Tipo de Requerimiento</param>
        /// <returns>Lista con el resultado de la operación</returns>
        ProcessResult<List<RequerimientoResponse>> BuscarBandejaProcesosRequerimiento(RequerimientoRequest filtro,
                                                                            List<CodigoValorResponse> lstTipoServicio = null,
                                                                            List<CodigoValorResponse> lstTipoRqto = null);

        /// <summary>
        /// Método para recuperar los registros de la bandeja de proceso de Requerimientos con observaciones
        /// </summary>
        /// <param name="CodigoRequerimientoEstadio">Codigo de Requerimiento estadio.</param>
        /// <returns>Lista con el resultado de la operación</returns>
        ProcessResult<List<RequerimientoEstadioObservacionResponse>> BuscarBandejaRequerimientosObservacion(Guid CodigoRequerimientoEstadio);

        /// <summary>
        /// Registra una Observación del Requerimiento por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request RequerimientoEstadioObservacionRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RegistraRequerimientoEstadioObservacion(RequerimientoEstadioObservacionRequest objParm);

        /// <summary>
        /// Responde la Observación del Requerimiento por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request RequerimientoEstadioObservacionRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RespondeRequerimientoEstadioObservacion(RequerimientoEstadioObservacionRequest objParm);

        /// <summary>
        /// Registra una Consulta del Requerimiento por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request RequerimientoEstadioConsultaRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RegistraRequerimientoEstadioConsulta(RequerimientoEstadioConsultaRequest objParm);

        /// <summary>
        /// Método para recuperar los registros de la bandeja de proceso de Requerimientos con consultas
        /// </summary>
        /// <param name="CodigoRequerimientoEstadio">Codigo de Requerimiento estadio.</param>
        /// <returns>Lista con el resultado de la operación</returns>
        ProcessResult<List<RequerimientoEstadioConsultaResponse>> BuscarBandejaRequerimientosConsultas(Guid CodigoRequerimientoEstadio);

        /// <summary>
        /// Metodo para obtener datos de Requerimiento Estadio Observacion por el ID
        /// </summary>
        /// <param name="CodigoRequerimientoEstadioObservacion">Id del Codigo Requerimiento Estadio Observacion </param>
        /// <returns>Indicador con el resultado de la operación</returns>
        RequerimientoEstadioObservacionResponse ObtieneRequerimientoEstadioObservacionPorID(Guid CodigoRequerimientoEstadioObservacion);

        /// <summary>
        /// Metodo para obtener datos de Requerimiento Estadio Consulta por el ID
        /// </summary>
        /// <param name="CodigoRequerimientoEstadioConsulta">Id del Codigo Requerimiento Estadio Consulta </param>
        /// <returns>Indicador con el resultado de la operación</returns>
        RequerimientoEstadioConsultaResponse ObtieneRequerimientoEstadioConsultaPorID(Guid CodigoRequerimientoEstadioConsulta);

        /// <summary>
        /// Metodo para aprobar cada Requerimiento según su estadío.
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento </param>
        /// <param name="codigoRequerimientoEstadio">Código de Requerimiento Estadío</param>
        /// <param name="login"></param>
        /// <param name="MotivoAprobacion">Motivo de Aprobación</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> ApruebaRequerimientoEstadio(Guid codigoRequerimiento, Guid codigoRequerimientoEstadio, string MotivoAprobacion, string login = null);

        /// <summary>
        /// Método para retornar los párrafos por Requerimiento
        /// </summary>
        /// <param name="CodigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Parrafos por Requerimiento</returns>
        ProcessResult<List<RequerimientoParrafoResponse>> RetornaParrafosPorRequerimiento(Guid CodigoRequerimiento);

        /// <summary>
        /// Registra una Observación del Requerimiento por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request RequerimientoEstadioObservacionRequest</param>
        /// <returns></returns> 
        ProcessResult<Object> RegistraRequerimientoEstadio(RequerimientoEstadioRequest objParm);

        /// <summary>
        /// Método para retornar los párrafos por Requerimiento
        /// </summary>
        /// <param name="CodigoRequerimientoEstadio">Código de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<List<FlujoAprobacionEstadioResponse>> RetornaEstadioRequerimientoObservacion(Guid CodigoRequerimientoEstadio);

        /// <summary>
        /// Método que retorna los responsable por flujo de aprobación.
        /// </summary>
        /// <param name="codigoFlujoAprobacion">código del flujo de aprobación.</param>
        /// <param name="codigoRequerimiento"></param>
        /// <returns>Responsable por flujo de aprobación</returns>
        ProcessResult<List<TrabajadorResponse>> RetornaResponsablesFlujoEstadio(Guid codigoFlujoAprobacion, Guid codigoRequerimiento);

        /// <summary>
        /// Método para listar los documentos de la bandeja de solicitud.
        /// </summary>
        /// <param name="filtro">filtro </param>
        /// <returns>Lista con el resultado de la operación</returns>
        ProcessResult<List<RequerimientoResponse>> ListaBandejaSolicitudRequerimientos(RequerimientoRequest filtro);

        /// <summary>
        /// Metodo para obtener datos de Requerimiento Estadio Observacion por el ID
        /// </summary>
        /// <param name="codigoRequerimiento">Id del Codigo Requerimiento Estadio Observacion </param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<RequerimientoResponse> ObtieneRequerimientoPorID(Guid codigoRequerimiento);

        /// <summary>
        /// Registra la Respuesta de la Solicitud de Modificacion del Requerimiento
        /// </summary>
        /// <param name="objRequerimiento">Objeto request de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RegistraRespuestaRequerimiento(RequerimientoRequest objRequerimiento);

        /// <summary>
        /// Registra la Respuesta de la Solicitud de Modificacion del Requerimiento para pasar a revisión
        /// </summary>
        /// <param name="objRequerimiento">Objeto request de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RegistraRespuestaRequerimientoRevision(RequerimientoRequest objRequerimiento);

        /// <summary>
        /// Registra la Respuesta de la Soliitud de Modificacion del Requerimiento
        /// </summary>
        /// <param name="objRequerimiento">Objeto request de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RegistrarRespuestaGrabarRequerimiento(RequerimientoRequest objRequerimiento);

        /// <summary>
        /// Método para retornar los documentos PDf por Requerimiento
        /// </summary>
        /// <param name="CodigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Documentos PDF por Requerimiento</returns>
        ProcessResult<List<RequerimientoDocumentoResponse>> DocumentosPorRequerimiento(Guid CodigoRequerimiento);

        /// <summary>
        /// Método para retornar los documentos adjuntos por Requerimiento
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al Requerimiento</returns>
        ProcessResult<List<RequerimientoDocumentoAdjuntoResponse>> BuscarRequerimientoDocumentoAdjunto(RequerimientoDocumentoAdjuntoRequest request);

        /// <summary>
        /// Metodo que retorna los bytes para la generación del archivo PDF.
        /// </summary>
        /// <param name="request">Request del adjunto</param>
        /// <returns>Bytes para generar pdf</returns>
        ProcessResult<RequerimientoDocumentoAdjuntoResponse> ObtenerArchivoAdjunto(RequerimientoDocumentoAdjuntoRequest request);

        /// <summary>
        /// Método para retornar los documentos adjuntos por Requerimiento
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al Requerimiento</returns>
        ProcessResult<string> RegistrarRequerimientoDocumentoAdjunto(RequerimientoDocumentoAdjuntoRequest request);

        /// <summary>
        /// Método que elimina los documentos adjuntos al Requerimiento
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al Requerimiento</returns>
        ProcessResult<string> EliminarRequerimientoDocumentoAdjunto(RequerimientoDocumentoAdjuntoRequest request);

        /// <summary>
        /// Método para retornar los documentos adjuntos por Requerimiento
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al Requerimiento</returns>
        ProcessResult<List<RequerimientoDocumentoAdjuntoResolucionResponse>> BuscarRequerimientoDocumentoAdjuntoResolucion(RequerimientoDocumentoAdjuntoResolucionRequest request);

        /// <summary>
        /// Metodo que retorna los bytes para la generación del archivo PDF.
        /// </summary>
        /// <param name="request">Request del adjunto</param>
        /// <returns>Bytes para generar pdf</returns>
        ProcessResult<RequerimientoDocumentoAdjuntoResolucionResponse> ObtenerArchivoAdjuntoResolucion(RequerimientoDocumentoAdjuntoResolucionRequest request);

        /// <summary>
        /// Método para retornar los documentos adjuntos por Requerimiento
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al Requerimiento</returns>
        ProcessResult<string> RegistrarRequerimientoDocumentoAdjuntoResolucion(RequerimientoDocumentoAdjuntoResolucionRequest request);


        /// <summary>
        /// Método que elimina los documentos adjuntos al Requerimiento
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al Requerimiento</returns>
        ProcessResult<string> EliminarRequerimientoDocumentoAdjuntoResolucion(RequerimientoDocumentoAdjuntoResolucionRequest request);

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
        ProcessResult<string> RetornaDirectorioFile(Guid codigoRequerimiento, string nombreUnidadOperativa,
                                                           string nombreFile, DateTime? fechaInicioVigencia = null,
                                                            bool esAdjunto = false, List<CodigoValorResponse> lstPrmRepositorioShp = null);
        /// <summary>
        /// Metodo para cargar un Archivo a un estadio de Requerimiento.
        /// </summary>
        /// <param name="objRsp">Objeto Requerimiento Documento Response</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RegistraRequerimientoDocumentoCargaArchivo(RequerimientoDocumentoResponse objRsp);

        /// <summary>
        /// Metodo que retorna los bytes para la generación del archivo PDF.
        /// </summary>
        /// <param name="codigoRequerimiento">Código del Requerimiento</param>
        /// <param name="NombreArchivoRequerimiento">Nombre del archivo a descargar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> GenerarContenidoRequerimiento(Guid codigoRequerimiento, Guid? codigoRequerimientoEstadio, ref string NombreArchivoRequerimiento, string linkFileCss = null);

        /// <summary>
        /// Retorna información del Requerimiento.
        /// </summary>
        /// <param name="codigoRequerimiento">código de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<RequerimientoResponse> RetornaRequerimientoPorId(Guid codigoRequerimiento);

        /// <summary>
        /// Metodo que retorna los bytes del Requerimiento reemplazado en la observación.
        /// </summary>
        /// <param name="codigoRequerimientoEstadioObservacion">Código de la observación del estadio Requerimiento</param>
        /// <param name="nombreArchivoRequerimiento">Nombre del archivo a descargar</param>
        /// <returns>Documento de Requerimiento que reemplazo la Observación</returns>
        ProcessResult<Object> ObtenerRequerimientoAnteriorObservacion(Guid codigoRequerimientoEstadioObservacion, ref string nombreArchivoRequerimiento);

        /// <summary>
        /// Metodo que retorna los bytes del Requerimiento reemplazante en la observación.
        /// </summary>
        /// <param name="codigoRequerimientoEstadioObservacion">Código de la observación del estadio Requerimiento</param>
        /// <param name="nombreArchivoRequerimiento">Nombre del archivo a descargar</param>
        /// <returns>Documento de Requerimiento que reemplazo la Observación</returns>
        ProcessResult<Object> ObtenerRequerimientoReemplazanteObservacion(Guid codigoRequerimientoEstadioObservacion, ref string nombreArchivoRequerimiento);

        ///// <summary>
        ///// Método para listar Requerimiento estadio responsable
        ///// </summary>
        ///// <param name="filtro">Filtro</param>
        ///// <returns>Listado de Requerimiento estadio responsable</returns>
        //ProcessResult<List<RequerimientoEstadioResponse>> ListaRequerimientoEstadioResponsable(RequerimientoRequest filtro);

        /// <summary>
        /// Obtiene la lista de revisores del Requerimiento
        /// </summary>
        /// <param name="Requerimiento">Entidad del Requerimiento</param>
        /// <param name="entidadFlujoAprobacionEstadio">Entidad flujo aprobacion estadio</param>
        /// <param name="login">Usuario actual</param>
        /// <returns>Lista de revisores</returns>
        ProcessResult<List<string>> ObtenerListaRevisoresStracon(RequerimientoEntity Requerimiento, FlujoAprobacionEstadioEntity entidadFlujoAprobacionEstadio = null, string login = "");
        /// <summary>
        /// Obtiene la lista de firmantes del Requerimiento
        /// </summary>
        /// <param name="Requerimiento">Entidad Requerimiento</param>
        /// <returns>Lista de firmantes</returns>
        ProcessResult<List<TrabajadorResponse>> ObtenerListaFirmantesStracon(RequerimientoResponse Requerimiento);

        /// <summary>
        /// Realiza la búsqueda del listado de Requerimientos
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de Requerimientos</returns>
        ProcessResult<List<ListadoRequerimientoResponse>> BuscarListadoRequerimiento(ListadoRequerimientoRequest filtro);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        ProcessResult<List<ListadoRequerimientoResponse>> BuscarListadoRequerimientoOrden(ListadoRequerimientoRequest filtro);

        /// <summary>
        /// Registra o actualiza un Requerimiento general
        /// </summary>
        /// <param name="dataRequerimiento">Datos a registrar de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> RegistrarRequerimiento(RequerimientoRequest dataRequerimiento);

        /// <summary>
        /// Registra o actualiza un listado Requerimiento
        /// </summary>
        /// <param name="dataRequerimiento">Datos a registrar de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> RegistrarListadoRequerimiento(RequerimientoRequest dataRequerimiento);

        /// <summary>
        /// Registra el documento del Requerimiento de adhesión
        /// </summary>
        /// <param name="dataRequerimiento">Datos a registrar de Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> RegistrarListadoRequerimientoAdhesion(RequerimientoRequest dataRequerimiento);

        /// <summary>
        /// Eliminar uno o muchos listado Requerimiento
        /// </summary>
        /// <param name="listaCodigoRequerimiento">Lista de Códigos de Requerimientos</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> EliminarListadoRequerimiento(List<object> listaCodigoRequerimiento);

        /// <summary>
        /// Realiza la búsqueda de listado Requerimientos principales
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de Requerimientos</returns>
        ProcessResult<List<ListadoRequerimientoResponse>> ListadoRequerimientoPrincipal(ListadoRequerimientoRequest filtro);

        /// <summary>
        /// Obtiene el Monto Acumulado del Requerimiento Principal más sus Adendas
        /// </summary>
        /// <param name="codigoRequerimientoPrincipal">Código de Requerimiento Principal</param>
        /// <returns>Registro con el Monto Acumulado del Requerimiento Principal más sus Adendas</returns>
        ProcessResult<List<ListadoRequerimientoResponse>> ObtenerMontoAcumuladoRequerimiento(string codigoRequerimientoPrincipal);

        /// <summary>
        /// Eliminar Requerimiento
        /// </summary>
        /// <param name="filtro">Datos del Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<string> EliminarRequerimiento(ListadoRequerimientoRequest filtro);

        /// <summary>
        /// Realiza la búsqueda de Requerimientos
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de Requerimientos</returns>
        ProcessResult<List<ListadoRequerimientoResponse>> BuscarRequerimiento(ListadoRequerimientoRequest filtro);

        /// <summary>
        /// Registrar la copia de un Requerimiento
        /// </summary>
        /// <param name="dataRequerimiento">Datos del Requerimiento</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> RegistrarCopiaRequerimiento(RequerimientoRequest dataRequerimiento);

        /// <summary>
        /// Obtiene el tipo de Requerimiento segun la Unidad Operativa S11-SGC
        /// </summary>
        /// <param name="CodigoUnidadOperativa"></param>
        /// <returns></returns>
        List<string> Obtener_Tipo_Requerimiento(Guid CodigoUnidadOperativa);

        /// <summary>
        /// Método para recuperar los registros ordenados de la bandeja de proceso.
        /// </summary>
        /// <param name="filtro">Objeto Requerimiento Request</param>
        /// <param name="lstTipoRequerimiento">Lista de Tipos de Servicio</param>
        /// <param name="lstTipoServicio">Lista de Tipo de Requerimiento</param>
        /// <returns>Registros de bandeja de procesos</returns>                
        ProcessResult<List<RequerimientoResponse>> BuscarBandejaProcesosRequerimientoOrdenado(RequerimientoRequest filtro,
                                                                                   List<CodigoValorResponse> lstTipoRequerimiento = null,
                                                                                   List<CodigoValorResponse> lstTipoServicio = null);

        /// <summary>
        /// Obtiene listado de variables de los parrafos de  un Requerimiento
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Lista de variables de parrafos de Requerimiento</returns>
        ProcessResult<List<RequerimientoParrafoVariableResponse>> ObtenerVariablesRequerimientoParrafo(string codigoRequerimiento);
        /// <summary>
        /// Permite generar un pdf desde un html
        /// </summary>
        /// <param name="htmlCuerpo">script de html</param>
        /// <param name="htmlPie">script de html del pie de pagina</param>
        /// <param name="codigoRequerimiento">Código Requerimiento</param>
        /// <param name="linksRef">links de referencia</param>
        /// <param name="indicadorHtml">Indicador si cuerpo va a ser parseado como Html</param>
        /// <returns>Pdf en un arreglo de bytes</returns>
        byte[] GenerarPdfDesdeHtml(string htmlCuerpo, string htmlPie, string htmlCabecera, Guid? codigoRequerimiento, Guid? codigoPlantilla, List<TrabajadorResponse> listaFirmantesSGC, List<string> listaResponsables = null, string linksRef = null, bool indicadorHtml = false, string urlLogo = "", int widthLogo = 0, int heightLogo = 0);

        /// <summary>
        /// Obtiene la empresa vinculada por proveedor
        /// </summary>
        /// <param name="codigoProveedor">Código del proveedor</param>
        /// <returns>Empresa vinculada por proveedor</returns>
        ProcessResult<EmpresaVinculadaResponse> ObtenerEmpresaVinculadaPorProveedor(Guid? codigoProveedor);

        /// <summary>
        /// Método para listar los documentos de la bandeja de revisión de Requerimientos.
        /// </summary>
        /// <param name="NumeroRequerimiento">número del Requerimiento</param>
        /// <param name="UnidadOperativa">unidad operativa</param>
        /// <param name="NombreProveedor">nombre del proveedor</param>
        /// <param name="NumdocPrv">numero documento del proveedor</param>
        /// <returns>Lista de Requerimientos para revisión</returns>
        ProcessResult<List<RequerimientoResponse>> ListaBandejaRevisionRequerimientos(RequerimientoRequest filtro);
        /// <summary>
        /// Actualizar Requerimiento
        /// </summary>
        /// <param name="CodigoRequerimiento"></param>
        /// <param name="TipoRequerimiento"></param>
        /// <returns></returns>
        ProcessResult<object> ActualizarRequerimiento(Guid CodigoRequerimiento, string TipoRequerimiento);

        /// <summary>
        /// Realiza la búsqueda de Proveedores
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de Proveedores</returns>
        ProcessResult<List<ReporteRequerimientoObservadoAprobadoResponse>> BuscarNumeroRequerimiento(ReporteRequerimientoObservadoAprobadoRequest filtro);

        /// <summary>
        /// Realiza la búsqueda de Proveedores
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de Proveedores</returns>
        ProcessResult<List<ReporteRequerimientoObservadoAprobadoResponse>> BuscarRequerimientoObservadoAprobado(ReporteRequerimientoObservadoAprobadoRequest filtro);
    }
}

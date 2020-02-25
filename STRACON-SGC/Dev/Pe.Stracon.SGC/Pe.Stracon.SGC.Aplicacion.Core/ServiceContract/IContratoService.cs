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
    /// Servicio que representa los Contratos
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150525 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IContratoService : IGenericService
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
        /// <param name="filtro">Objeto Contrato Request</param>
        /// <param name="lstTipoServicio">Lista de Tipos de Servicio</param>
        /// <param name="lstTipoRqto">Lista de Tipo de Requerimiento</param>
        /// <returns>Lista con el resultado de la operación</returns>
        ProcessResult<List<ContratoResponse>> BuscarBandejaProcesosContrato(ContratoRequest filtro,
                                                                            List<CodigoValorResponse> lstTipoServicio = null,
                                                                            List<CodigoValorResponse> lstTipoRqto = null);

        /// <summary>
        /// Método para recuperar los registros de la bandeja de proceso de contratos con observaciones
        /// </summary>
        /// <param name="CodigoContratoEstadio">Codigo de Contrato estadio.</param>
        /// <returns>Lista con el resultado de la operación</returns>
        ProcessResult<List<ContratoEstadioObservacionResponse>> BuscarBandejaContratosObservacion(Guid CodigoContratoEstadio);

        /// <summary>
        /// Registra una Observación del Contrato por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request ContratoEstadioObservacionRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RegistraContratoEstadioObservacion(ContratoEstadioObservacionRequest objParm);

        /// <summary>
        /// Responde la Observación del Contrato por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request ContratoEstadioObservacionRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RespondeContratoEstadioObservacion(ContratoEstadioObservacionRequest objParm);

        /// <summary>
        /// Registra una Consulta del Contrato por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request ContratoEstadioConsultaRequest</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RegistraContratoEstadioConsulta(ContratoEstadioConsultaRequest objParm);

        /// <summary>
        /// Método para recuperar los registros de la bandeja de proceso de contratos con consultas
        /// </summary>
        /// <param name="CodigoContratoEstadio">Codigo de Contrato estadio.</param>
        /// <returns>Lista con el resultado de la operación</returns>
        ProcessResult<List<ContratoEstadioConsultaResponse>> BuscarBandejaContratosConsultas(Guid CodigoContratoEstadio);

        /// <summary>
        /// Metodo para obtener datos de Contrato Estadio Observacion por el ID
        /// </summary>
        /// <param name="CodigoContratoEstadioObservacion">Id del Codigo Contrato Estadio Observacion </param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ContratoEstadioObservacionResponse ObtieneContratoEstadioObservacionPorID(Guid CodigoContratoEstadioObservacion);

        /// <summary>
        /// Metodo para obtener datos de Contrato Estadio Consulta por el ID
        /// </summary>
        /// <param name="CodigoContratoEstadioConsulta">Id del Codigo Contrato Estadio Consulta </param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ContratoEstadioConsultaResponse ObtieneContratoEstadioConsultaPorID(Guid CodigoContratoEstadioConsulta);

        /// <summary>
        /// Metodo para aprobar cada contrato según su estadío.
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato </param>
        /// <param name="codigoContratoEstadio">Código de Contrato Estadío</param>
        /// <param name="login"></param>
        /// <param name="MotivoAprobacion">Motivo de Aprobación</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> ApruebaContratoEstadio(Guid codigoContrato, Guid codigoContratoEstadio, string MotivoAprobacion, string login = null);

        /// <summary>
        /// Método para retornar los párrafos por contrato
        /// </summary>
        /// <param name="CodigoContrato">Código de Contrato</param>
        /// <returns>Parrafos por contrato</returns>
        ProcessResult<List<ContratoParrafoResponse>> RetornaParrafosPorContrato(Guid CodigoContrato);

        /// <summary>
        /// Registra una Observación del Contrato por Estadío.
        /// </summary>
        /// <param name="objParm">Objeto request ContratoEstadioObservacionRequest</param>
        /// <returns></returns> 
        ProcessResult<Object> RegistraContratoEstadio(ContratoEstadioRequest objParm);

        /// <summary>
        /// Método para retornar los párrafos por contrato
        /// </summary>
        /// <param name="CodigoContrato">Código de Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<List<FlujoAprobacionEstadioResponse>> RetornaEstadioContratoObservacion(Guid CodigoContratoEstadio);

        /// <summary>
        /// Método que retorna los responsable por flujo de aprobación.
        /// </summary>
        /// <param name="codigoFlujoAprobacion">código del flujo de aprobación.</param>
        /// <param name="codigoContrato"></param>
        /// <returns>Responsable por flujo de aprobación</returns>
        ProcessResult<List<TrabajadorResponse>> RetornaResponsablesFlujoEstadio(Guid codigoFlujoAprobacion, Guid codigoContrato);

        /// <summary>
        /// Método para listar los documentos de la bandeja de solicitud.
        /// </summary>
        /// <param name="filtro">filtro </param>
        /// <returns>Lista con el resultado de la operación</returns>
        ProcessResult<List<ContratoResponse>> ListaBandejaSolicitudContratos(ContratoRequest filtro);

        /// <summary>
        /// Metodo para obtener datos de Contrato Estadio Observacion por el ID
        /// </summary>
        /// <param name="codigoContrato">Id del Codigo Contrato Estadio Observacion </param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<ContratoResponse> ObtieneContratoPorID(Guid codigoContrato);

        /// <summary>
        /// Registra la Respuesta de la Solicitud de Modificacion del Contrato
        /// </summary>
        /// <param name="objContrato">Objeto request de Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RegistraRespuestaContrato(ContratoRequest objContrato);

        /// <summary>
        /// Registra la Respuesta de la Solicitud de Modificacion del Contrato para pasar a revisión
        /// </summary>
        /// <param name="objContrato">Objeto request de Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RegistraRespuestaContratoRevision(ContratoRequest objCtr);

        /// <summary>
        /// Registra la Respuesta de la Soliitud de Modificacion del Contrato
        /// </summary>
        /// <param name="objContrato">Objeto request de Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RegistrarRespuestaGrabarContrato(ContratoRequest objContrato);

        /// <summary>
        /// Método para retornar los documentos PDf por Contrato
        /// </summary>
        /// <param name="CodigoContrato">Código de Contrato</param>
        /// <returns>Documentos PDF por Contrato</returns>
        ProcessResult<List<ContratoDocumentoResponse>> DocumentosPorContrato(Guid CodigoContrato);

        /// <summary>
        /// Método para retornar los documentos adjuntos por Contrato
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        ProcessResult<List<ContratoDocumentoAdjuntoResponse>> BuscarContratoDocumentoAdjunto(ContratoDocumentoAdjuntoRequest request);

        /// <summary>
        /// Metodo que retorna los bytes para la generación del archivo PDF.
        /// </summary>
        /// <param name="request">Request del adjunto</param>
        /// <returns>Bytes para generar pdf</returns>
        ProcessResult<ContratoDocumentoAdjuntoResponse> ObtenerArchivoAdjunto(ContratoDocumentoAdjuntoRequest request);

        /// <summary>
        /// Método para retornar los documentos adjuntos por Contrato
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        ProcessResult<string> RegistrarContratoDocumentoAdjunto(ContratoDocumentoAdjuntoRequest request);

        /// <summary>
        /// Método que elimina los documentos adjuntos al Contrato
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        ProcessResult<string> EliminarContratoDocumentoAdjunto(ContratoDocumentoAdjuntoRequest request);

        /// <summary>
        /// Método para retornar los documentos adjuntos por Contrato
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        ProcessResult<List<ContratoDocumentoAdjuntoResolucionResponse>> BuscarContratoDocumentoAdjuntoResolucion(ContratoDocumentoAdjuntoResolucionRequest request);

        /// <summary>
        /// Metodo que retorna los bytes para la generación del archivo PDF.
        /// </summary>
        /// <param name="request">Request del adjunto</param>
        /// <returns>Bytes para generar pdf</returns>
        ProcessResult<ContratoDocumentoAdjuntoResolucionResponse> ObtenerArchivoAdjuntoResolucion(ContratoDocumentoAdjuntoResolucionRequest request);

        /// <summary>
        /// Método para retornar los documentos adjuntos por Contrato
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        ProcessResult<string> RegistrarContratoDocumentoAdjuntoResolucion(ContratoDocumentoAdjuntoResolucionRequest request);


        /// <summary>
        /// Método que elimina los documentos adjuntos al Contrato
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        ProcessResult<string> EliminarContratoDocumentoAdjuntoResolucion(ContratoDocumentoAdjuntoResolucionRequest request);

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
        ProcessResult<string> RetornaDirectorioFile(Guid codigoContrato, string nombreUnidadOperativa,
                                                           string nombreFile, DateTime? fechaInicioVigencia = null,
                                                            bool esAdjunto = false, List<CodigoValorResponse> lstPrmRepositorioShp = null);
        /// <summary>
        /// Metodo para cargar un Archivo a un estadio de contrato.
        /// </summary>
        /// <param name="objRsp">Objeto Contrato Documento Response</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> RegistraContratoDocumentoCargaArchivo(ContratoDocumentoResponse objRsp);

        /// <summary>
        /// Metodo que retorna los bytes para la generación del archivo PDF.
        /// </summary>
        /// <param name="codigoContrato">Código del Contrato</param>
        /// <param name="NombreArchivoContrato">Nombre del archivo a descargar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> GenerarContenidoContrato(Guid codigoContrato, Guid? codigoContratoEstadio, ref string NombreArchivoContrato, string linkFileCss = null);

        /// <summary>
        /// Retorna información del contrato.
        /// </summary>
        /// <param name="codigoContrato">código de contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<ContratoResponse> RetornaContratoPorId(Guid codigoContrato);

        /// <summary>
        /// Metodo que retorna los bytes del contrato reemplazado en la observación.
        /// </summary>
        /// <param name="codigoContratoEstadioObservacion">Código de la observación del estadio Contrato</param>
        /// <param name="nombreArchivoContrato">Nombre del archivo a descargar</param>
        /// <returns>Documento de contrato que reemplazo la Observación</returns>
        ProcessResult<Object> ObtenerContratoAnteriorObservacion(Guid codigoContratoEstadioObservacion, ref string nombreArchivoContrato);

        /// <summary>
        /// Metodo que retorna los bytes del contrato reemplazante en la observación.
        /// </summary>
        /// <param name="codigoContratoEstadioObservacion">Código de la observación del estadio Contrato</param>
        /// <param name="nombreArchivoContrato">Nombre del archivo a descargar</param>
        /// <returns>Documento de contrato que reemplazo la Observación</returns>
        ProcessResult<Object> ObtenerContratoReemplazanteObservacion(Guid codigoContratoEstadioObservacion, ref string nombreArchivoContrato);

        ///// <summary>
        ///// Método para listar contrato estadio responsable
        ///// </summary>
        ///// <param name="filtro">Filtro</param>
        ///// <returns>Listado de contrato estadio responsable</returns>
        //ProcessResult<List<ContratoEstadioResponse>> ListaContratoEstadioResponsable(ContratoRequest filtro);

        /// <summary>
        /// Obtiene la lista de revisores del contrato
        /// </summary>
        /// <param name="contrato">Entidad del contrato</param>
        /// <param name="entidadFlujoAprobacionEstadio">Entidad flujo aprobacion estadio</param>
        /// <param name="login">Usuario actual</param>
        /// <returns>Lista de revisores</returns>
        ProcessResult<List<string>> ObtenerListaRevisoresStracon(ContratoEntity contrato, FlujoAprobacionEstadioEntity entidadFlujoAprobacionEstadio = null, string login = "");
        /// <summary>
        /// Obtiene la lista de firmantes del contrato
        /// </summary>
        /// <param name="contrato">Entidad Contrato</param>
        /// <returns>Lista de firmantes</returns>
        ProcessResult<List<TrabajadorResponse>> ObtenerListaFirmantesStracon(ContratoResponse contrato);

        /// <summary>
        /// Realiza la búsqueda del listado de contratos
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de contratos</returns>
        ProcessResult<List<ListadoContratoResponse>> BuscarListadoContrato(ListadoContratoRequest filtro);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        ProcessResult<List<ListadoContratoResponse>> BuscarListadoContratoOrden(ListadoContratoRequest filtro);

        /// <summary>
        /// Registra o actualiza un contrato general
        /// </summary>
        /// <param name="dataContrato">Datos a registrar de Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> RegistrarContrato(ContratoRequest dataContrato);

        /// <summary>
        /// Registra o actualiza un listado contrato
        /// </summary>
        /// <param name="dataContrato">Datos a registrar de Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> RegistrarListadoContrato(ContratoRequest dataContrato);

        /// <summary>
        /// Registra el documento del contrato de adhesión
        /// </summary>
        /// <param name="dataContrato">Datos a registrar de Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> RegistrarListadoContratoAdhesion(ContratoRequest dataContrato);

        /// <summary>
        /// Eliminar uno o muchos listado contrato
        /// </summary>
        /// <param name="listaCodigoContrato">Lista de Códigos de Contratos</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> EliminarListadoContrato(List<object> listaCodigoContrato);

        /// <summary>
        /// Realiza la búsqueda de listado contratos principales
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de contratos</returns>
        ProcessResult<List<ListadoContratoResponse>> ListadoContratoPrincipal(ListadoContratoRequest filtro);

        /// <summary>
        /// Obtiene el Monto Acumulado del Contrato Principal más sus Adendas
        /// </summary>
        /// <param name="codigoContratoPrincipal">Código de Contrato Principal</param>
        /// <returns>Registro con el Monto Acumulado del Contrato Principal más sus Adendas</returns>
        ProcessResult<List<ListadoContratoResponse>> ObtenerMontoAcumuladoContrato(string codigoContratoPrincipal);

        /// <summary>
        /// Eliminar Contrato
        /// </summary>
        /// <param name="filtro">Datos del contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<string> EliminarContrato(ListadoContratoRequest filtro);

        /// <summary>
        /// Realiza la búsqueda de contratos
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de contratos</returns>
        ProcessResult<List<ListadoContratoResponse>> BuscarContrato(ListadoContratoRequest filtro);

        /// <summary>
        /// Registrar la copia de un contrato
        /// </summary>
        /// <param name="dataContrato">Datos del Contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> RegistrarCopiaContrato(ContratoRequest dataContrato);

        /// <summary>
        /// Obtiene el tipo de Contrato segun la Unidad Operativa S11-SGC
        /// </summary>
        /// <param name="CodigoUnidadOperativa"></param>
        /// <returns></returns>
        List<string> Obtener_Tipo_Contrato(Guid CodigoUnidadOperativa);

        /// <summary>
        /// Método para recuperar los registros ordenados de la bandeja de proceso.
        /// </summary>
        /// <param name="filtro">Objeto Contrato Request</param>
        /// <param name="lstTipoContrato">Lista de Tipos de Servicio</param>
        /// <param name="lstTipoServicio">Lista de Tipo de Requerimiento</param>
        /// <returns>Registros de bandeja de procesos</returns>                
        ProcessResult<List<ContratoResponse>> BuscarBandejaProcesosContratoOrdenado(ContratoRequest filtro,
                                                                                   List<CodigoValorResponse> lstTipoContrato = null,
                                                                                   List<CodigoValorResponse> lstTipoServicio = null);

        /// <summary>
        /// Obtiene listado de variables de los parrafos de  un contrato
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato</param>
        /// <returns>Lista de variables de parrafos de contrato</returns>
        ProcessResult<List<ContratoParrafoVariableResponse>> ObtenerVariablesContratoParrafo(string codigoContrato);
        /// <summary>
        /// Permite generar un pdf desde un html
        /// </summary>
        /// <param name="htmlCuerpo">script de html</param>
        /// <param name="htmlPie">script de html del pie de pagina</param>
        /// <param name="codigoContrato">Código contrato</param>
        /// <param name="linksRef">links de referencia</param>
        /// <param name="indicadorHtml">Indicador si cuerpo va a ser parseado como Html</param>
        /// <returns>Pdf en un arreglo de bytes</returns>
        byte[] GenerarPdfDesdeHtml(string htmlCuerpo, string htmlPie, string htmlCabecera, Guid? codigoContrato, Guid? codigoPlantilla, List<TrabajadorResponse> listaFirmantesSGC, List<string> listaResponsables = null, string linksRef = null, bool indicadorHtml = false, string urlLogo = "", int widthLogo = 0, int heightLogo = 0);

        /// <summary>
        /// Obtiene la empresa vinculada por proveedor
        /// </summary>
        /// <param name="codigoProveedor">Código del proveedor</param>
        /// <returns>Empresa vinculada por proveedor</returns>
        ProcessResult<EmpresaVinculadaResponse> ObtenerEmpresaVinculadaPorProveedor(Guid? codigoProveedor);

        /// <summary>
        /// Método para listar los documentos de la bandeja de revisión de contratos.
        /// </summary>
        /// <param name="NumeroContrato">número del contrato</param>
        /// <param name="UnidadOperativa">unidad operativa</param>
        /// <param name="NombreProveedor">nombre del proveedor</param>
        /// <param name="NumdocPrv">numero documento del proveedor</param>
        /// <returns>Lista de contratos para revisión</returns>
        ProcessResult<List<ContratoResponse>> ListaBandejaRevisionContratos(ContratoRequest filtro);
        /// <summary>
        /// Actualizar contrato
        /// </summary>
        /// <param name="CodigoContrato"></param>
        /// <param name="TipoContrato"></param>
        /// <returns></returns>
        ProcessResult<object> ActualizarContrato(Guid CodigoContrato, string TipoContrato);

        /// <summary>
        /// Realiza la búsqueda de Proveedores
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de Proveedores</returns>
        ProcessResult<List<ReporteContratoObservadoAprobadoResponse>> BuscarNumeroContrato(ReporteContratoObservadoAprobadoRequest filtro);

        /// <summary>
        /// Realiza la búsqueda de Proveedores
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de Proveedores</returns>
        ProcessResult<List<ReporteContratoObservadoAprobadoResponse>> BuscarContratoObservadoAprobado(ReporteContratoObservadoAprobadoRequest filtro);
    }
}

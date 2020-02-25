using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using System.Collections.Generic;

namespace Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract
{
    /// <summary>
    /// Definición de servicios para Politica
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150617 <br />
    /// Modificación:            <br />
    /// </remarks>
    public interface IPoliticaService : IGenericService
    {
        /// <summary>
        /// Método para lista el nivel de unidad operativa dinámico
        /// </summary>
        /// <param name="filtro">Filtro</param>        
        /// <returns>Lista de nivel de unidad operativa</returns>
        ProcessResult<List<dynamic>> ListarNivelUnidadOperativaDinamico(ParametroValorRequest filtro=null);

        /// <summary>
        /// Método para Listar el nivel de unidad operativa
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <param name="seccion">Sección</param>        
        /// <returns>Lista de nivel de unidad operativa</returns>
        ProcessResult<List<CodigoValorResponse>> ListarNivelUnidadOperativa(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar el tipo de unidad operativa dinámico 
        /// </summary>
        /// <param name="filtro">Filtro</param>        
        /// <returns>Lista de nivel de unidad operativa dinamica</returns>
        ProcessResult<List<dynamic>> ListarTipoUnidadOperativaDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar de tipo unidad opeativa
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <param name="seccion">Sección</param>        
        /// <returns>Lista tipo unidad operativa</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoUnidadOperativa(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Méotodo para buscar el tipo de unidad operativa por código de nivel
        /// </summary>
        /// <param name="codigoNivel">Código de nivel</param>    
        /// <returns>Lista unidad operativa por codigo nivel</returns>
        ProcessResult<List<CodigoValorResponse>> BuscarTipoUnidadOperativaPorCodigoNivel(string codigoNivel);

        /// <summary>
        /// Método para listar el tipo de documento de identidad dinámico
        /// </summary>
        /// <param name="filtro">Filtro</param>  
        /// <returns>Lista de nivel de unidad operativa</returns>
        ProcessResult<List<dynamic>> ListarTipoDocumentoIdentidadDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para lista el tipo de documento de identidad
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <param name="seccion">Sección</param>    
        /// <returns>Lista tipo de documento identidad</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoDocumentoIdentidad(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para lista el tipo de archivo dinámico
        /// </summary>
        /// <param name="filtro">Filtro</param>     
        /// <returns>Lista de tipo de archivo dinamico</returns>
        ProcessResult<List<dynamic>> ListarTipoArchivoDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para Listar detipo de archivo
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <param name="seccion">Sección</param>    
        /// <returns>Lista de tipo de archivo</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoArchivo(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Méotodo para Listar la forma de generación dinámico
        /// </summary>
        /// <param name="filtro">Filtro</param>     
        /// <returns>Lista de forma generacion dinamica</returns>
        ProcessResult<List<dynamic>> ListarFormaGeneracionDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar la forma de gneración
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <param name="seccion">Sección</param>
        /// <returns>Lista de forma de generación</returns>
        ProcessResult<List<CodigoValorResponse>> ListarFormaGeneracion(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar de sistemas de integración dinámico
        /// </summary>
        /// <param name="filtro">Filtro</param>       
        /// <returns>Lista de sistema integracion dinamico</returns>
        ProcessResult<List<dynamic>> ListarSistemasIntegracionDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para Listar los sistemas de integración
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <param name="seccion">Sección</param>
        /// <returns>Lista sistemas de integración</returns>
        ProcessResult<List<CodigoValorResponse>> ListarSistemasIntegracion(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para Listar operación de integración tipo dinámico
        /// </summary>
        /// <param name="filtro">Filtro</param>      
        /// <returns>Lista operacion integracion dinamica</returns>
        ProcessResult<List<dynamic>> ListarOperacionIntegracionDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar la operación
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <param name="seccion">Sección</param>
        /// <returns>Lista con operacion</returns>
        ProcessResult<List<CodigoValorResponse>> ListarOperacionIntegracion(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para buscar la operación 
        /// </summary>
        /// <param name="codigoFuenteIntegracion">Código de fuente de integración</param>
        /// <returns>Lista operacion</returns>
        ProcessResult<List<CodigoValorResponse>> BuscarOperacionIntegracionPorCodigoFuenteIntegracion(string codigoFuenteIntegracion);

        /// <summary>
        /// Método para listar el tipo de evidencia dínamico
        /// </summary>
        /// <param name="filtro">Filtro</param>        
        /// <returns>Lista tipo evidencia dinamico</returns>
        ProcessResult<List<dynamic>> ListarTipoEvidenciaDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método de Listar el tipo de Evidencia
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <param name="seccion">Sección</param>
        /// <returns>Lista tipo evidencia</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoEvidencia(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar el tipo de actividad dinamico
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <returns>Lista tipo actividad dinamica</returns>
        ProcessResult<List<dynamic>> ListarTipoActividadDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar el tipo de actividad
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <param name="seccion">Sección</param>
        /// <returns>Lista tipo actividad</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoActividad(ParametroValorRequest filtro, string seccion = "2");

        /// <summary>
        /// Método para listar de manera dinámica los Estados de Calendarización
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista estado calendarizacion dinamica</returns>
        ProcessResult<List<dynamic>> ListarEstadoCalendarizacionDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Calendarización
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista estado calendarizacion</returns>
        ProcessResult<List<CodigoValorResponse>> ListarEstadoCalendarizacion(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar de manera dinámica los Estados de Actividades
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista estado actividad dinamica</returns>
        ProcessResult<List<dynamic>> ListarEstadoActividadDinamico(ParametroValorRequest filtro = null);


        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Actividades
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista estado actividad</returns>
        ProcessResult<List<CodigoValorResponse>> ListarEstadoActividad(ParametroValorRequest filtro = null, string seccion = "2");
        
        /// <summary>
        /// Método para listar de manera dinámica los Estados de Cumplimiento de las Actividades
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista estado cumplimiento dinamico</returns>
        ProcessResult<List<dynamic>> ListarEstadoCumplimientoDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Cumplimiento de las Actividades
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista estado de cumplimiento</returns>
         ProcessResult<List<CodigoValorResponse>> ListarEstadoCumplimiento(ParametroValorRequest filtro = null, string seccion = "2");
        
        /// <summary>
        /// Método para listar de manera dinámica los Estados de Evidencias
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
         /// <returns>Lista estado evidencia dinamico</returns>
        ProcessResult<List<dynamic>> ListarEstadoEvidenciaDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Evidencias
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista estado evidencia</returns>
        ProcessResult<List<CodigoValorResponse>> ListarEstadoEvidencia(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar de manera dinámica los Tipos de Servicio.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista tipo servicio dinamico</returns>
        ProcessResult<List<dynamic>> ListarTipoContratoDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de los Tipos de Servicio.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista tipo servicio</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoContrato(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar Código y Descripción de los Documentos Adjuntos.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista tipo servicio</returns>
        ProcessResult<List<CodigoValorResponse>> ListarDocAdjunto(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar Código y Descripción de las Modalidades de Contratación.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista tipo servicio</returns>
        ProcessResult<List<CodigoValorResponse>> ListarModCon(ParametroValorRequest filtro = null, string seccion = "2");


        /// <summary>
        /// Método para listar Código y Descripción de los Tipos de Servicio.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista tipo servicio</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoRequerimiento(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar de manera dinámica los Tipos de Requerimiento.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista con tipos de requerimientos</returns>
        ProcessResult<List<dynamic>> ListarTipoServicioDinamico(string tipoContrato = null, ParametroValorRequest filtro = null);
        
        /// <summary>
        /// Método para listar Código y Descripción de los Tipos de Requerimiento.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista código y descripción de los tipos de requerimiento</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoServicio(string tipoContrato = null, ParametroValorRequest filtro = null, string seccion = "2");

        ProcessResult<List<CodigoValorResponse>> ListarUnidadOperativa(string tipoContrato = null, ParametroValorRequest filtro = null, string seccion = "2");


        /// <summary>
        /// Método para listar de manera dinámica las Formas de Contrato.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista forma contrato dinamico</returns>
        ProcessResult<List<dynamic>> ListarFormaContratoDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de las Formas de Contrato.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista formato contrato</returns>
        ProcessResult<List<CodigoValorResponse>> ListarFormaContrato(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar de manera dinámica los Dominios de las empresas.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista dominio de empresa de forma dinamica</returns>
        ProcessResult<List<dynamic>> ListarDominioEmpresaDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de los Dominios de las empresas.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista de dominios de empresa</returns>
        ProcessResult<List<CodigoValorResponse>> ListarDominioEmpresa(ParametroValorRequest filtro = null, string seccion = "3");

        /// <summary>
        /// Método para listar de manera dinámica las Rutas de los Repositorios de SharePoint.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista de repositorios de sharepoint de forma dinamica </returns>
        ProcessResult<List<dynamic>> ListarRepositorioSharePointDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de las Rutas de los Repositorios de SharePoint.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista de repositorios sharepoint</returns>
        ProcessResult<List<CodigoValorResponse>> ListarRepositorioSharePoint(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar de manera dinámica los Tipos de Notificación de SCC.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista tipos de notificaciones contable de forma dinamica</returns>
        ProcessResult<List<dynamic>> ListarTipoNotificacionContableDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de los Tipos de Notificación de SCC.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista tipos de notificaciones contable</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoNotificacionContable(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar de manera dinámica la configuraciones de SharePoint.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista configuraciones de sharepoint de forma dinamica</returns> 
        ProcessResult<List<dynamic>> ListarConfiguracionSharePointDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de la configuraciones de SharePoint.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista configuraciones de sharepoint</returns>
        ProcessResult<List<CodigoValorResponse>> ListarConfiguracionSharePoint(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar de manera dinámica Credenciales de Acceso.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista credenciales de forma dinamica</returns>
        ProcessResult<List<dynamic>> ListarCredencialesAccesoDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de las Credenciales de Acceso.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista credenciales de acceso</returns>
        ProcessResult<List<CodigoValorResponse>> ListarCredencialesAcceso(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar de manera dinámica Tipos de Documentos de Contratos.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista tipos de documentos de contratos dinamicos</returns>
        ProcessResult<List<dynamic>> ListarTipoDocumentoContratoDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de los Tipos de Documentos de Contratos.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista tipos de documento de contrato de forma dinamica</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoDocumentoContrato(ParametroValorRequest filtro = null, string seccion = "2");


        /// <summary>
        /// Método para listar de manera dinámica Tipos de Documentos de Requerimientos.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista tipos de documentos de contratos dinamicos</returns>
        ProcessResult<List<dynamic>> ListarTipoDocumentoRequerimientoDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de los Tipos de Documentos de Requerimientos.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista tipos de documento de contrato de forma dinamica</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoDocumentoRequerimiento(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar de manera dinámica Estados de Vigencia.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista estado de vigencia de forma dinamica</returns>
        ProcessResult<List<dynamic>> ListarEstadoVigenciaDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Vigencia.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista estado de vigencia</returns>
        ProcessResult<List<CodigoValorResponse>> ListarEstadoVigencia(ParametroValorRequest filtro = null, string seccion = "2");


        /// <summary>
        /// Método para listar de manera dinámica Estados de Vigencia.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista estado de vigencia de forma dinamica</returns>
        ProcessResult<List<dynamic>> ListarEstadoVigenciaRequerimientoDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Vigencia.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista estado de vigencia</returns>
        ProcessResult<List<CodigoValorResponse>> ListarEstadoVigenciaRequerimiento(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// ListarTipoRespuestaObservacionDinamico: método dinámico para listar Tipos de Respuesta de Observacion
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista tipo de respuesta de observación de forma dinamica</returns>
        ProcessResult<List<dynamic>> ListarTipoRespuestaObservacionDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// ListarTipoRespuestaObservacion: método para listar Tipos de Respuesta de Observacion
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista tipo de respuesta de observación</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoRespuestaObservacion(ParametroValorRequest filtro = null, string seccion = "2");
        
        /// <summary>
        /// ListarMontoMinimoControlDinamico: método dinámico para listar los montos mínimos del control de flujo de aprobación.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista Monto minimo del control de flujo de aprobación</returns>
        ProcessResult<List<dynamic>> ListarMontoMinimoControlDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// ListarMontoMinimoControl: método para listar los montos mínimos del control de flujo de aprobación.
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista monto minimo de control</returns>
        ProcessResult<List<CodigoValorResponse>> ListarMontoMinimoControl(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar de manera dinámica Estados de Contrato.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista estados de contrato de manera dinamica</returns>
        ProcessResult<List<dynamic>> ListarEstadoContratoDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Contrato.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista de estado de contrato</returns>
        ProcessResult<List<CodigoValorResponse>> ListarEstadoContrato(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Requerimiento.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista de estado de contrato</returns>
        ProcessResult<List<CodigoValorResponse>> ListarEstadoRequerimiento(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar de manera dinámica Estados de Edición.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista con estados de edicion de forma dinamica</returns>
        ProcessResult<List<dynamic>> ListarEstadoEdicionDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Edición.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista de estados de edición</returns>
        ProcessResult<List<CodigoValorResponse>> ListarEstadoEdicion(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// Método para listar de manera dinámica Moneda.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista moneda de manera dinamica</returns>
        ProcessResult<List<dynamic>> ListarMonedaDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de la Moneda.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista codigo y descripcion de moneda</returns>
        ProcessResult<List<CodigoValorResponse>> ListarMoneda(ParametroValorRequest filtro = null, string seccion = "2");
        
        /// <summary>
        /// Método para listar de manera dinámica las Rutas de los Repositorios de SharePoint de SGC.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista rutas de repositorios de sharepoint de forma dinamica</returns>
        ProcessResult<List<dynamic>> ListarRepositorioSharePointDinamicoSGC(ParametroValorRequest filtro = null);

        /// <summary>
        /// Método para listar Código y Descripción de las Rutas de los Repositorios de SharePoint de SGC.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista codigo y descripcion de rutas de repositorio sharepoint</returns>
        ProcessResult<List<CodigoValorResponse>> ListarRepositorioSharePointSGC(ParametroValorRequest filtro = null, string seccion = "2");



        /// <summary>
        /// ListarAlertaVencimientoContratoDinamico: método dinámico para listar Alertas de Vencimiento de Contrato
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de Alertas con vencimientos de contrato</returns>
        ProcessResult<List<dynamic>> ListarAlertaVencimientoContratoDinamico(ParametroValorRequest filtro = null);
        

        /// <summary>
        /// ListarAlertaVencimientoContrato: método que lista Alertas de Vencimiento de Contrato
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de Alertas con vencimientos de contrato</returns>
        ProcessResult<List<CodigoValorResponse>> ListarAlertaVencimientoContrato(ParametroValorRequest filtro = null, string seccion = "2");
       

        /// <summary>
        /// ListarTipoOrdenDinamico: método dinámico para listar Tipo de Orden
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de Tipo Orden</returns>
        ProcessResult<List<dynamic>> ListarTipoOrdenDinamico(ParametroValorRequest filtro = null);
        

        /// <summary>
        /// ListarTipoOrden: método que lista Tipo Orden
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de Tipo Orden</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoOrden(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// ListarMontoAcumuladoParaContratoDinamico: método dinámico para listar Monto Acumulado para contrato
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de monto acumulado para contrato</returns>
        ProcessResult<List<dynamic>> ListarMontoAcumuladoParaContratoDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// ListarMontoAcumuladoParaContrato: método que lista los Montos acumulados para contrato
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de monto acumulado para contrato</returns>
        ProcessResult<List<CodigoValorResponse>> ListarMontoAcumuladoParaContrato(ParametroValorRequest filtro = null, string seccion = "2");
        

        /// <summary>
        /// ListaCuentaNotificacionSGC: método que lista las configuraciones de cuenta de correo
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de Cuenta de Notificacion SGC</returns>
        ProcessResult<List<CodigoValorResponse>> ListaCuentaNotificacionSGC(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// ListaCuentaNotificacionSGCDinamico: método dinámico que lista las configuraciones de cuenta de correo
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de Cuenta de Notificacion SGC</returns>
        ProcessResult<List<dynamic>> ListaCuentaNotificacionSGCDinamico(ParametroValorRequest filtro = null);
        
        /// <summary>
        /// ListaCuentaNotificacionSCC: método que lista las configuraciones de cuenta de correo
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de Cuenta de Notificacion SGC</returns>
        ProcessResult<List<CodigoValorResponse>> ListaCuentaNotificacionSCC(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// ListaCuentaNotificacionSCCDinamico: método dinámico que lista las configuraciones de cuenta de correo
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de Cuenta de Notificacion SGC</returns>
        ProcessResult<List<dynamic>> ListaCuentaNotificacionSCCDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// ListaUrlSistemas: método que lista las URL de los sistemas
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de de URLS de los Sistemas/returns>
        ProcessResult<List<CodigoValorResponse>> ListaUrlSistemas(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// ListaUrlSistemasDinamico: método dinámico que lista las URL de los sistemas
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de URLS de los Sistemas</returns>
        ProcessResult<List<dynamic>> ListaUrlSistemasDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// ListaTipoTarifaBien: método que lista los Tipos de Tarifa de un bien.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de los Tipos de Tarifa de un bien/returns>
        ProcessResult<List<CodigoValorResponse>> ListaTipoTarifaBien(ParametroValorRequest filtro = null, string seccion = "2");
        
        /// <summary>
        /// ListaTipoTarifaBienDinamico: método dinámico que lista los Tipos de Tarifa de un bien.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de URLS de los Sistemas</returns>
        ProcessResult<List<dynamic>> ListaTipoTarifaBienDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// ListaPeriodoAlquilerBien: método que lista los periodos de alquiler de un bien.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista los periodos de alquiler de un bien/returns>
        ProcessResult<List<CodigoValorResponse>> ListaPeriodoAlquilerBien(ParametroValorRequest filtro = null, string seccion = "2");
        
        /// <summary>
        /// ListaPeriodoAlquilerDinamico: método dinámico que lista los periodos de alquiler de un bien.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista los periodos de alquiler de un bien</returns>
        ProcessResult<List<dynamic>> ListaPeriodoAlquilerDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// ListaTipoBien: método que lista los tipos de un bien.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista los tipos de un bien</returns>
        ProcessResult<List<CodigoValorResponse>> ListaTipoBien(ParametroValorRequest filtro = null, string seccion = "2");
        
        /// <summary>
        /// ListaTipoBienDinamico: método dinámico que lista los tipos de un bien.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista los tipos de un bien</returns>
        ProcessResult<List<dynamic>> ListaTipoBienDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// ListaConfiguracionGeneracionContrato: método dinámico que lista las configuraciones en la generación de contratos.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de configuraciones en la generación de Contratos.</returns>
        ProcessResult<List<dynamic>> ListaConfiguracionGeneracionContrato(ParametroValorRequest filtro = null);

        /// <summary>
        /// ListaConfiguracionGeneracionRequerimiento: método dinámico que lista las configuraciones en la generación de requerimientos.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de configuraciones en la generación de Requerimientos.</returns>
        ProcessResult<List<dynamic>> ListaConfiguracionGeneracionRequerimiento(ParametroValorRequest filtro = null);

        /// <summary>
        /// ListaConfiguracionGeneracionContrato: método dinámico que lista los valores.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de valores.</returns>
        ProcessResult<List<dynamic>> ListaValor(ParametroValorRequest filtro = null);

         /// <summary>
        /// ListarTipoConsultaDinamico: método dinámico para listar Jerarquías de Tipo de consulta
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista Dinamica Tipo Consulta</returns>
        ProcessResult<List<dynamic>> ListarTipoConsultaDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// ListarTipoConsulta: método para listar tipo de consulta
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista Unidad Operativa</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoConsulta(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// ListarAreaDinamico: método dinámico para listar las áreas
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista Dinamica área</returns>
        ProcessResult<List<dynamic>> ListarAreaDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// ListarArea: método para listar áreas
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista Unidad Operativa</returns>
        ProcessResult<List<CodigoValorResponse>> ListarArea(ParametroValorRequest filtro = null, string seccion = "2");

        /// <summary>
        /// ListarEstadoConsultaDinamico: método dinámico para listar los estados de consulta
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista Dinamica área</returns>
        ProcessResult<List<dynamic>> ListarEstadoConsultaDinamico(ParametroValorRequest filtro = null);

        /// <summary>
        /// ListarEstadoConsulta: método para listar los estados de consulta
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista Unidad Operativa</returns>
        ProcessResult<List<CodigoValorResponse>> ListarEstadoConsulta(ParametroValorRequest filtro = null, string seccion = "2");
    }
}

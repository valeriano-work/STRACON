using System.Collections.Generic;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.Service.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;
using System;

namespace Pe.Stracon.Politicas.Aplicacion.Service.General
{
    /// <summary>
    /// Implementación de servicios para Politica
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PoliticaService : GenericService, IPoliticaService
    {
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary>        
        public IParametroValorService parametroValorService { get; set; }

        /// <summary>
        /// ListarNivelUnidadOperativaDinamico: método dinámico para listar Jerarquías de Unidad Operativa
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista Dinamica Unidad Operativa</returns>
        public ProcessResult<List<dynamic>> ListarNivelUnidadOperativaDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoNivel = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.CodigoNivel;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.IndicadorEmpresa = true;
            resultadoNivel = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoNivel;
        }

        /// <summary>
        /// ListarNivelUnidadOperativa: método para listar Jerarquías de Unidad Operativa
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista Unidad Operativa</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarNivelUnidadOperativa(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarNivelUnidadOperativaDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }
         
        /// <summary>
        /// ListarTipoUnidadOperativaDinamico: método dinámico para listar de Tipos de Unidad Operativa
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista Tipo Unidad Operativa Dinamica</returns>
        public ProcessResult<List<dynamic>> ListarTipoUnidadOperativaDinamico(ParametroValorRequest filtro = null)
        {
            ProcessResult<List<dynamic>> resultadoNivel = null;
            filtro = filtro ?? new ParametroValorRequest();
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.TipoUnidadOperativa;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.IndicadorEmpresa = true;
            resultadoNivel = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoNivel;
        }

        /// <summary>
        /// ListarTipoUnidadOperativa: método para listar de Tipos de Unidad Operativa
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista Tipo Unidad Operativa</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoUnidadOperativa(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarTipoUnidadOperativaDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// Busca los tipo de unidad operativa en base al nivel
        /// </summary>
        /// <param name="codigoNivel">Filtro codigo Nivel</param>
        /// <returns>Resultado de busqueda</returns>
        public ProcessResult<List<CodigoValorResponse>> BuscarTipoUnidadOperativaPorCodigoNivel(string codigoNivel)
        {
            ProcessResult<List<dynamic>> listaDinamica = ListarTipoUnidadOperativaDinamico();
            var listaFiltrada = listaDinamica.Result.Where(d => d.Atributo3 == codigoNivel).ToList();
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaFiltrada, "2");
            return resultado;
        }

        /// <summary>
        /// ListarTipoDocumentoIdentidadDinamico: método dinámico para Lista de Tipos de Documento de Identidad
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista Tipo Documento Identidad Dinamica</returns>
        public ProcessResult<List<dynamic>> ListarTipoDocumentoIdentidadDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoNivel = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.TipoDocumentoIdentidad;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.IndicadorEmpresa = true;
            resultadoNivel = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoNivel;
        }

        /// <summary>
        /// ListarTipoDocumentoIdentidad: método para listar de Tipos de Documento de Identidad
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista de Tipo Documento de identidad</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoDocumentoIdentidad(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarTipoDocumentoIdentidadDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarTipoArchivoDinamico: método dinámico para listar Formatos de Archivo Permitido
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista de Tipo archivo dinamico</returns>
        public ProcessResult<List<dynamic>> ListarTipoArchivoDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoNivel = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.TipoArchivoPermitido;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSCC;
            filtro.IndicadorEmpresa = false;
            resultadoNivel = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoNivel;
        }

        /// <summary>
        /// ListarTipoArchivo: método para listar Formatos de Archivo Permitido
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Resultado de busqueda</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoArchivo(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarTipoArchivoDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarFormaGeneracionDinamico: método dinámico para listar formas de generación de tareas
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista Forma Gneracion Dinamico</returns>
        public ProcessResult<List<dynamic>> ListarFormaGeneracionDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoNivel = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.FormaGeneracion;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSCC;
            filtro.IndicadorEmpresa = false;
            resultadoNivel = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoNivel;
        }

        /// <summary>
        /// ListarFormaGeneracion: método para listar formas de generación de tareas
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista de Forma de generación</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarFormaGeneracion(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarFormaGeneracionDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarSistemasIntegracionDinamico: método dinámico para listar de Sistemas con los que SCC se puede integrar
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista de Sistemas de integracion Dinamica</returns>
        public ProcessResult<List<dynamic>> ListarSistemasIntegracionDinamico(ParametroValorRequest filtro = null)
        {
            ProcessResult<List<dynamic>> resultadoNivel = null;
            filtro = filtro ?? new ParametroValorRequest();
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.SistemaIntegracion;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSCC;
            filtro.IndicadorEmpresa = false;
            resultadoNivel = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoNivel;
        }

        /// <summary>
        /// ListarSistemasIntegracion: método para listar de Sistemas con los que SCC se puede integrar
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista de Sistemas de integración</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarSistemasIntegracion(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarSistemasIntegracionDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarOperacionIntegracionDinamico: método dinámico para Lista de Operaciones por cada Sistemas con los que SCC se puede integrar
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista de Operaciones de integracion dinamica</returns>
        public ProcessResult<List<dynamic>> ListarOperacionIntegracionDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoNivel = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.OperacionIntegracion;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSCC;
            filtro.IndicadorEmpresa = false;
            resultadoNivel = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoNivel;
        }

        /// <summary>
        /// ListarTipoEvidencia: método para Lista de Operaciones por cada Sistemas con los que SCC se puede integrar
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista de operación integración</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarOperacionIntegracion(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarOperacionIntegracionDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// Busca los tipo de operación de integración en base a la fuente de integración
        /// </summary>
        /// <param name="codigoFuenteIntegracion">Filtro de codigo fuente de integración</param>
        /// <returns>Lista con resultados de busqueda</returns>
        public ProcessResult<List<CodigoValorResponse>> BuscarOperacionIntegracionPorCodigoFuenteIntegracion(string codigoFuenteIntegracion)
        {
            ProcessResult<List<dynamic>> listaDinamica = ListarOperacionIntegracionDinamico();
            var listaFiltrada = listaDinamica.Result.Where(d => d.Atributo3 == codigoFuenteIntegracion).ToList();
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaFiltrada, "2");
            return resultado;
        }

        /// <summary>
        /// ListarTipoEvidenciaDinamico: método dinámico para listar Tipos de Evidencia
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista de Tipo evidencia dinamico</returns>
        public ProcessResult<List<dynamic>> ListarTipoEvidenciaDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoNivel = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.TipoEvidencia;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSCC;
            filtro.IndicadorEmpresa = false;
            resultadoNivel = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoNivel;
        }

        /// <summary>
        /// ListarTipoEvidencia: método que lista los Tipos de Evidencia
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista de tipos de evidencia</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoEvidencia(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarTipoEvidenciaDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarTipoActividadDinamico: método dinámico para listar Tipos de Actividad
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista Tipo Actividad dinamica</returns>
        public ProcessResult<List<dynamic>> ListarTipoActividadDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoNivel = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.TipoActividad;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSCC;
            filtro.IndicadorEmpresa = false;
            resultadoNivel = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoNivel;
        }

        /// <summary>
        /// ListarTipoActividad: método que retorna los Tipos de Actividad
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista Tipo Actividad</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoActividad(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarTipoActividadDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// Método para listar de manera dinámica los Estados de Calendarización
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista de estado calendarizacion dinamica</returns>
        public ProcessResult<List<dynamic>> ListarEstadoCalendarizacionDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.EstadoCalendarizacion, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSCC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Calendarización
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista de estado de calendarización</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarEstadoCalendarizacion(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarEstadoCalendarizacionDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica los Estados de Actividades
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista con estado actividad dinamica</returns>
        public ProcessResult<List<dynamic>> ListarEstadoActividadDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.EstadoActividad, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSCC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Actividades
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista con estado de actividad</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarEstadoActividad(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarEstadoActividadDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica los Estados de Cumplimiento de las Actividades
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Resultado de Listas con estado de cumplimiento de actividades</returns>
        public ProcessResult<List<dynamic>> ListarEstadoCumplimientoDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.EstadoCumplimiento, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSCC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Cumplimiento de las Actividades
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista Codigo y Descripción de los estados de cumplimiento de actividades</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarEstadoCumplimiento(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarEstadoCumplimientoDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica los Estados de Evidencias
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista estados de evidencia</returns>
        public ProcessResult<List<dynamic>> ListarEstadoEvidenciaDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.EstadoEvidencia, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSCC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Evidencias
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista Codigo y descripción de los estados de evidencia</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarEstadoEvidencia(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarEstadoEvidenciaDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica los Tipos de Servicio.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista los tipos de servicio</returns>
        public ProcessResult<List<dynamic>> ListarTipoContratoDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.TipoContrato, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSGC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar de manera dinámica los Documentos Adjuntos.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista los tipos de servicio</returns>
        public ProcessResult<List<dynamic>> ListarDocAdjunto(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.DocAdjunto, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSGC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de los Documentos Adjuntos.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista Codigo y descripción de los tipos de servicio</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarDocAdjunto(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarDocAdjunto(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }


        /// <summary>
        /// Método para listar de manera dinámica los Documentos Adjuntos.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista los tipos de servicio</returns>
        public ProcessResult<List<dynamic>> ListarModCon(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.ModCon, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSGC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de los Documentos Adjuntos.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista Codigo y descripción de los tipos de servicio</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarModCon(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarModCon(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar Código y Descripción de los Tipos de Servicio.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista Codigo y descripción de los tipos de servicio</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoContrato(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarTipoContratoDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }



        /// <summary>
        /// Método para listar Código y Descripción de los Tipos de Servicio.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista Codigo y descripción de los tipos de servicio</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoRequerimiento(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarTipoContratoDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica los Tipos de Requerimiento.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista con tipos de requerimientos</returns>
        public ProcessResult<List<dynamic>> ListarTipoServicioDinamico(string tipoContrato = null, ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.TipoServicio, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSGC);
            var resultado = parametroValorService.BuscarParametroValorDinamico(filtro);
            if (tipoContrato != null)
            {
                resultado.Result = resultado.Result.Where(item => Convert.ToString(item.Atributo3) == tipoContrato).ToList();
            }

            return resultado;
        }

      
        public ProcessResult<List<CodigoValorResponse>> ListarUnidadOperativa(string tipoContrato = null, ParametroValorRequest filtro = null, string seccion = "2")
        {
    

            var listaDinamica = ListarTipoServicioDinamico(tipoContrato, filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar Código y Descripción de los Tipos de Requerimiento.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista código y descripción de los tipos de requerimiento</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoServicio(string tipoContrato = null,ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarTipoServicioDinamico(tipoContrato, filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica las Formas de Contrato.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista las formas de contrato</returns>
        public ProcessResult<List<dynamic>> ListarFormaContratoDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.FormaContrato, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSGC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de las Formas de Contrato.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista con código y descripcíón</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarFormaContrato(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarFormaContratoDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica los Dominios de las empresas.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista dominios de empresas</returns>
        public ProcessResult<List<dynamic>> ListarDominioEmpresaDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.DominioEmpresa, DatosConstantes.Empresa.CodigoStracon, null, true);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de los Dominios de las empresas.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Lista código y descripción</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarDominioEmpresa(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarDominioEmpresaDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica las Rutas de los Repositorios de SharePoint.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<dynamic>> ListarRepositorioSharePointDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.RepositorioSharePoint, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSCC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de las Rutas de los Repositorios de SharePoint.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarRepositorioSharePoint(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarRepositorioSharePointDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica los Tipos de Notificación de SCC.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<dynamic>> ListarTipoNotificacionContableDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.TipoNotificacionSCC, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSCC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de los Tipos de Notificación de SCC.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoNotificacionContable(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarTipoNotificacionContableDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica la configuraciones de SharePoint.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<dynamic>> ListarConfiguracionSharePointDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.ConfiguracionSharePoint, DatosConstantes.Empresa.CodigoStracon, null, true);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de la configuraciones de SharePoint.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarConfiguracionSharePoint(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarConfiguracionSharePointDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica Credenciales de Acceso.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<dynamic>> ListarCredencialesAccesoDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.CredencialAcceso, DatosConstantes.Empresa.CodigoStracon, null, true);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de las Credenciales de Acceso.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarCredencialesAcceso(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarCredencialesAccesoDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica Tipos de Documentos de Contratos.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<dynamic>> ListarTipoDocumentoContratoDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.TipoDocumentoContrato, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSGC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de las Credenciales de Acceso.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoDocumentoContrato(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarTipoDocumentoContratoDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        

        /// <summary>
        /// Método para listar de manera dinámica Tipos de Documentos de Contratos.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<dynamic>> ListarTipoDocumentoRequerimientoDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.TipoDocumentoRequerimiento, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSGC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de las Credenciales de Acceso.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoDocumentoRequerimiento(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarTipoDocumentoRequerimientoDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica Estados de Vigencia.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<dynamic>> ListarEstadoVigenciaDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.EstadoVigencia, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSGC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Vigencia.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarEstadoVigencia(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarEstadoVigenciaDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para listar de manera dinámica Estados de Vigencia de Requerimiento.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<dynamic>> ListarEstadoVigenciaRequerimientoDinamico(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.EstadoVigenciaRequerimiento, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSGC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de los Estados de Vigencia de Requerimiento. 
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarEstadoVigenciaRequerimiento(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarEstadoVigenciaRequerimientoDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// Método para crear el filtro de parámetro general
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="codigoIdentificador">Código de Identificación del Parámetro General</param>
        /// <param name="codigoSistema">Código del Sistema al que pertenece el parámetro</param>
        /// <param name="indicadorGlobal">Indica si el parámetro es global (de todos los sistemas)</param>
        /// <returns>Filtro de Parámetro Valor</returns>
        public ParametroValorRequest ObtenerFiltroParametro(ParametroValorRequest filtro = null, string codigoIdentificador = null, string codigoEmpresa = null, string codigoSistema = null, bool? indicadorGlobal = false)
        {
            filtro = filtro ?? new ParametroValorRequest();
            filtro.CodigoIdentificador = codigoIdentificador;
            filtro.CodigoEmpresa = codigoEmpresa;
            filtro.CodigoSistema = codigoSistema;
            filtro.IndicadorEmpresa = indicadorGlobal;

            return filtro;
        }

        /// <summary>
        /// ProcesaListaDinamica: método que procesa las lista dinámicas y filtra de acuerdo a seccion.
        /// </summary>
        /// <param name="listaDinamica"> Lista dinámica con información de parámetros. </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista dinamica</returns>
        private ProcessResult<List<CodigoValorResponse>> ProcesaListaDinamica(List<dynamic> listaDinamica, string seccion)
        {
            ProcessResult<List<CodigoValorResponse>> resultado = new ProcessResult<List<CodigoValorResponse>>();
            resultado.Result = listaDinamica.Select(d => new CodigoValorResponse()
            {
                Codigo = d.Atributo1,
                Valor = ((IDictionary<string, object>)d)["Atributo" + seccion]
            }).ToList();

            return resultado;
        }

        /// <summary>
        /// ListarTipoRespuestaObservacionDinamico: método dinámico para listar Tipos de Respuesta de Observacion
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista tipos de respuesta de observación</returns>
        public ProcessResult<List<dynamic>> ListarTipoRespuestaObservacionDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoNivel = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.TipoRespuestaObservacion;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSGC;
            filtro.IndicadorEmpresa = false;
            resultadoNivel = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoNivel;
        }

        /// <summary>
        /// ListarTipoRespuestaObservacion: método para listar Tipos de Respuesta de Observacion
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista de respuesta de observación</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoRespuestaObservacion(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarTipoRespuestaObservacionDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarMontoMinimoControlDinamico: método dinámico para listar los montos mínimos del control de flujo de aprobación.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista con montos minimos del control de flujo de aprobación</returns>
        public ProcessResult<List<dynamic>> ListarMontoMinimoControlDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoNivel = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.MontoMinimoControl;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSGC;
            filtro.IndicadorEmpresa = false;
            resultadoNivel = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoNivel;
        }

        /// <summary>
        /// ListarMontoMinimoControl: método para listar los montos mínimos del control de flujo de aprobación.
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista con montos minimos del control de flujo de aprobacion</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarMontoMinimoControl(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarMontoMinimoControlDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarEstadoContratoDinamico: método dinámico para listar Estados de Contrato
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de Estados de Contrato</returns>
        public ProcessResult<List<dynamic>> ListarEstadoContratoDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoEstadoContrato = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.EstadoContrato;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSGC;
            filtro.IndicadorEmpresa = false;
            resultadoEstadoContrato = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoEstadoContrato;
        }

        /// <summary>
        /// ListarEstadoRequerimientoDinamico: método dinámico para listar Estados de Contrato
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de Estados de Contrato</returns>
        public ProcessResult<List<dynamic>> ListarEstadoRequerimientoDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoEstadoContrato = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.EstadoContrato;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSGC;
            filtro.IndicadorEmpresa = false;
            resultadoEstadoContrato = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoEstadoContrato;
        }

        /// <summary>
        /// ListarEstadoContrato: método que lista los Estados de Contrato
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de Estados de Contrato</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarEstadoContrato(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarEstadoContratoDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarEstadoRequerimiento: método que lista los Estados de Contrato
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de Estados de Contrato</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarEstadoRequerimiento(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarEstadoRequerimientoDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarEstadoEdicionDinamico: método dinámico para listar Estados de Edición
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de Estados de Edición</returns>
        public ProcessResult<List<dynamic>> ListarEstadoEdicionDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoEstadoEdicion = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.EstadoEdicion;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSGC;
            filtro.IndicadorEmpresa = false;
            resultadoEstadoEdicion = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoEstadoEdicion;
        }

        /// <summary>
        /// ListarEstadoEdicion: método que lista los Estados de Edición
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de Estados de Edición</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarEstadoEdicion(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarEstadoEdicionDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarMonedaDinamico: método dinámico para listar Moneda
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de Monedas</returns>
        public ProcessResult<List<dynamic>> ListarMonedaDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.Moneda;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = null;
            filtro.IndicadorEmpresa = true;
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// ListarMoneda: método que lista Moneda
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de Monedas</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarMoneda(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarMonedaDinamico(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion); 
        }

        /// <summary>
        /// Método para listar de manera dinámica las Rutas de los Repositorios de SharePoint de SGC.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<dynamic>> ListarRepositorioSharePointDinamicoSGC(ParametroValorRequest filtro = null)
        {
            filtro = ObtenerFiltroParametro(filtro, DatosConstantes.ParametrosGenerales.RepositorioSharePointSGC, DatosConstantes.Empresa.CodigoStracon, DatosConstantes.Sistema.CodigoSGC);
            return parametroValorService.BuscarParametroValorDinamico(filtro);
        }

        /// <summary>
        /// Método para listar Código y Descripción de las Rutas de los Repositorios de SharePoint de SGC.
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <param name="seccion">Sección a mostrar</param>
        /// <returns>Resultado del Proceso</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarRepositorioSharePointSGC(ParametroValorRequest filtro = null, string seccion = "2")
        {
            var listaDinamica = ListarRepositorioSharePointDinamicoSGC(filtro);
            return ProcesaListaDinamica(listaDinamica.Result, seccion);
        }

        /// <summary>
        /// ListarAlertaVencimientoContratoDinamico: método dinámico para listar Alertas de Vencimiento de Contrato
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de Alertas con vencimientos de contrato</returns>
        public ProcessResult<List<dynamic>> ListarAlertaVencimientoContratoDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoAlertaVencimientoContrato = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.AlertaVencimientoContrato;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSGC;
            filtro.IndicadorEmpresa = false;
            resultadoAlertaVencimientoContrato = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoAlertaVencimientoContrato;
        }

        /// <summary>
        /// ListarAlertaVencimientoContrato: método que lista Alertas de Vencimiento de Contrato
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de Alertas con vencimientos de contrato</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarAlertaVencimientoContrato(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarAlertaVencimientoContratoDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarTipoOrdenDinamico: método dinámico para listar Tipo de Orden
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de Tipo Orden</returns>
        public ProcessResult<List<dynamic>> ListarTipoOrdenDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoTipoOrden = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.TipoOrden;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSGC;
            filtro.IndicadorEmpresa = false;
            resultadoTipoOrden = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoTipoOrden;
        }

        /// <summary>
        /// ListarTipoOrden: método que lista Tipo Orden
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de Tipo Orden</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoOrden(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarTipoOrdenDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarMontoAcumuladoParaContratoDinamico: método dinámico para listar Monto Acumulado para contrato
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de monto acumulado para contrato</returns>
        public ProcessResult<List<dynamic>> ListarMontoAcumuladoParaContratoDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoMontoAcumuladoParaContrato = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.MontoAcumuladoParaContrato;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSGC;
            filtro.IndicadorEmpresa = false;
            resultadoMontoAcumuladoParaContrato = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoMontoAcumuladoParaContrato;
        }

        /// <summary>
        /// ListarMontoAcumuladoParaContrato: método que lista los Montos acumulados para contrato
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de monto acumulado para contrato</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarMontoAcumuladoParaContrato(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarMontoAcumuladoParaContratoDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }
        
        /// <summary>
        /// ListaCuentaNotificacionSGC: método que lista las configuraciones de cuenta de correo
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de Cuenta de Notificacion SGC</returns>
        public ProcessResult<List<CodigoValorResponse>> ListaCuentaNotificacionSGC(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListaCuentaNotificacionSGCDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListaCuentaNotificacionSGCDinamico: método dinámico que lista las configuraciones de cuenta de correo
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de Cuenta de Notificacion SGC</returns>
        public ProcessResult<List<dynamic>> ListaCuentaNotificacionSGCDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoCuentaNotificacion = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.CuentaNotificacionSGC;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSGC;
            filtro.IndicadorEmpresa = false;
            resultadoCuentaNotificacion = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoCuentaNotificacion;
        }

        /// <summary>
        /// ListaCuentaNotificacionSCC: método que lista las configuraciones de cuenta de correo
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de Cuenta de Notificacion SGC</returns>
        public ProcessResult<List<CodigoValorResponse>> ListaCuentaNotificacionSCC(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListaCuentaNotificacionSCCDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListaCuentaNotificacionSCCDinamico: método dinámico que lista las configuraciones de cuenta de correo
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de Cuenta de Notificacion SGC</returns>
        public ProcessResult<List<dynamic>> ListaCuentaNotificacionSCCDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoCuentaNotificacion = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.CuentaNotificacionSCC;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoSCC;
            filtro.IndicadorEmpresa = false;
            resultadoCuentaNotificacion = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoCuentaNotificacion;
        }

        /// <summary>
        /// ListaUrlSistemas: método que lista las URL de los sistemas
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de de URLS de los Sistemas/returns>
        public ProcessResult<List<CodigoValorResponse>> ListaUrlSistemas(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListaUrlSistemasDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListaUrlSistemasDinamico: método dinámico que lista las URL de los sistemas
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de URLS de los Sistemas</returns>
        public ProcessResult<List<dynamic>> ListaUrlSistemasDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoUrlSistemas = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.URLSistemas;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;            
            filtro.IndicadorEmpresa = true;
            resultadoUrlSistemas = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoUrlSistemas;
        }

        /// <summary>
        /// ListaTipoTarifaBien: método que lista los Tipos de Tarifa de un bien.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista de los Tipos de Tarifa de un bien/returns>
        public ProcessResult<List<CodigoValorResponse>> ListaTipoTarifaBien(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListaTipoTarifaBienDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListaTipoTarifaBienDinamico: método dinámico que lista los Tipos de Tarifa de un bien.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de URLS de los Sistemas</returns>
        public ProcessResult<List<dynamic>> ListaTipoTarifaBienDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoUrlSistemas = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.TipoTarifaBien;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.IndicadorEmpresa = false;
            resultadoUrlSistemas = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoUrlSistemas;
        }
        /// <summary>
        /// ListaPeriodoAlquilerBien: método que lista los periodos de alquiler de un bien.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista los periodos de alquiler de un bien/returns>
        public ProcessResult<List<CodigoValorResponse>> ListaPeriodoAlquilerBien(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListaPeriodoAlquilerDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListaPeriodoAlquilerDinamico: método dinámico que lista los periodos de alquiler de un bien.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista los periodos de alquiler de un bien</returns>
        public ProcessResult<List<dynamic>> ListaPeriodoAlquilerDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoUrlSistemas = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.PeriodoAlquilerBien;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.IndicadorEmpresa = false;
            resultadoUrlSistemas = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoUrlSistemas;
        }
        /// <summary>
        /// ListaTipoBien: método que lista los tipos de un bien.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <param name="seccion">Por defecto la sección 2, se puede cambiar de valor caso sea necesario.</param>
        /// <returns>Lista los tipos de un bien</returns>
        public ProcessResult<List<CodigoValorResponse>> ListaTipoBien(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListaTipoBienDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListaTipoBienDinamico: método dinámico que lista los tipos de un bien.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista los tipos de un bien</returns>
        public ProcessResult<List<dynamic>> ListaTipoBienDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultadoUrlSistemas = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.TipoDeBien;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.IndicadorEmpresa = false;
            resultadoUrlSistemas = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultadoUrlSistemas;
        }

        /// <summary>
        /// ListaConfiguracionGeneracionContrato: método dinámico que lista las configuraciones en la generación de contratos.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de configuraciones en la generación de Contratos.</returns>
        public ProcessResult<List<dynamic>> ListaConfiguracionGeneracionContrato(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultado = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.ConfiguracionGeneracionContratos;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.IndicadorEmpresa = false;
            resultado = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultado;
        }

        /// <summary>
        /// ListaConfiguracionGeneracionContrato: método dinámico que lista las configuraciones en la generación de contratos.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de configuraciones en la generación de Contratos.</returns>
        public ProcessResult<List<dynamic>> ListaConfiguracionGeneracionRequerimiento(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultado = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.ConfiguracionGeneracionContratos;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.IndicadorEmpresa = false;
            resultado = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultado;
        }

        /// <summary>
        /// ListaConfiguracionGeneracionContrato: método dinámico que lista los valores.
        /// </summary>
        /// <param name="filtro">Filtro de Parámetro Valor</param>
        /// <returns>Lista dinámica de valores.</returns>
        public ProcessResult<List<dynamic>> ListaValor(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultado = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.Valor;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.CodigoSistema = DatosConstantes.Sistema.CodigoTRA;
            filtro.IndicadorEmpresa = false;
            resultado = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultado;
        }

        /// <summary>
        /// ListarTipoConsultaDinamico: método dinámico para listar Jerarquías de Tipo de consulta
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista Dinamica Tipo Consulta</returns>
        public ProcessResult<List<dynamic>> ListarTipoConsultaDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultado = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.TipoConsulta;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.IndicadorEmpresa = true;
            resultado = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultado;
        }

        /// <summary>
        /// ListarNivelUnidadOperativa: método para listar Jerarquías de Unidad Operativa
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista Unidad Operativa</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarTipoConsulta(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarTipoConsultaDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarAreaDinamico: método dinámico para listar las áreas
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista Dinamica área</returns>
        public ProcessResult<List<dynamic>> ListarAreaDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultado = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.Area;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.IndicadorEmpresa = true;
            resultado = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultado;
        }

        /// <summary>
        /// ListarArea: método para listar areas
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista Unidad Operativa</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarArea(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarAreaDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }

        /// <summary>
        /// ListarEstadoConsultaDinamico: método dinámico para listar los estados de consulta
        /// </summary>
        /// <param name="filtro">filtro de Parámetro Valor</param>
        /// <returns>Lista Dinamica área</returns>
        public ProcessResult<List<dynamic>> ListarEstadoConsultaDinamico(ParametroValorRequest filtro = null)
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> resultado = null;
            filtro.CodigoIdentificador = DatosConstantes.ParametrosGenerales.EstadoConsulta;
            filtro.CodigoEmpresa = DatosConstantes.Empresa.CodigoStracon;
            filtro.IndicadorEmpresa = true;
            resultado = parametroValorService.BuscarParametroValorDinamico(filtro);
            return resultado;
        }

        /// <summary>
        /// ListarEstadoConsulta: método para listar los estados de consulta
        /// </summary>
        /// <param name="filtro"> filtro de Parámetro Valor  </param>
        /// <param name="seccion"> por defecto la sección 2, se puede cambiar de valor caso sea necesario. </param>
        /// <returns>Lista Unidad Operativa</returns>
        public ProcessResult<List<CodigoValorResponse>> ListarEstadoConsulta(ParametroValorRequest filtro = null, string seccion = "2")
        {
            filtro = filtro ?? new ParametroValorRequest();
            ProcessResult<List<dynamic>> listaDinamica = ListarEstadoConsultaDinamico(filtro);
            ProcessResult<List<CodigoValorResponse>> resultado = ProcesaListaDinamica(listaDinamica.Result, seccion);
            return resultado;
        }
    }
}
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using System;
using System.Collections.Generic;

namespace Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract
{
    /// <summary>
    /// Definición del servicio de aplicación UnidadOperativaService
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22150326 <br />
    /// Modificación:            <br />
    /// </remarks>
    public interface IUnidadOperativaService : IGenericService
    {
        /// <summary>
        /// Realiza la busqueda de unidades operativas
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <returns>Listado de Unidad Operativa</returns>
        ProcessResult<List<UnidadOperativaResponse>> BuscarUnidadOperativa(FiltroUnidadOperativa filtro);

        /// <summary>
        /// Realiza la busqueda de unidades operativas SAP
        /// </summary>
        /// <param name="filtro">Filtro</param>
        /// <returns>Listado de Unidad Operativa</returns>
        ProcessResult<List<UnidadOperativaResponse>> BuscarUnidadOperativaSAP(FiltroUnidadOperativa filtro);

        /// <summary>
        /// Realiza la busqueda de unidades operativas de nivel proyecto por Empresa Matriz
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de Unidad Operativa de nivel proyecto por Empresa Matriz</returns>
        ProcessResult<List<UnidadOperativaResponse>> BuscarUnidadOperativaProyectoPorEmpresaMatriz(FiltroUnidadOperativa filtro);

        /// <summary>
        /// Lista registros de Unidades Operativas a partir de códigos.
        /// </summary>
        /// <param name="listaCodigos">Lista de códigos de Unidades Operativas</param>
        ProcessResult<List<UnidadOperativaResponse>> ListarUnidadesOperativas(List<Guid?> listaCodigos);

        /// <summary>
        /// Lista las Unidades Operativas por persona responsable.
        /// </summary>
        /// <param name="loginResponsable">Código de Identificación del Responsable</param>
        ProcessResult<List<UnidadOperativaResponse>> ListarUnidadesOperativasPorResponsable(string loginResponsable);

        /// <summary>
        /// Lista las unidades operativas de un nivel superior al indicado como parámetro.
        /// </summary>
        /// <param name="codigoNivelUnidadOperativa">Codigo de Nivel de la Unidad Operativa</param>
        /// <returns>Listado de unidad operativas encontrados</returns>
        ProcessResult<List<UnidadOperativaResponse>> BuscarUnidadOperativaNivelSuperior(string codigoNivelUnidadOperativa);

        /// <summary>
        /// Realiza la insercion de la unidad operativa
        /// </summary>
        /// <param name="data">Data</param>
        ProcessResult<DataUnidadOperativaRequest> RegistrarUnidadOperativa(DataUnidadOperativaRequest data);

        /// <summary>
        /// Eliminar el registro de la unidad operativa
        /// </summary>
        /// <param name="entidad">Filtro</param>
        ProcessResult<DataUnidadOperativaRequest> EliminarUnidadOperativa(DataUnidadOperativaRequest entidad);

        /// <summary>
        /// Método para eliminar masivamente Unidades Operativas.
        /// </summary>
        /// <param name="listaCodigos">Lista de Códigos de Unidades Operativas</param>
        ProcessResult<List<string>> EliminarUnidadesOperativas(List<string> listaCodigos);

        /// <summary>
        /// Realiza la busqueda de unidades operativas staff
        /// </summary>
        /// <param name="nombre">Nombre entidad buscar</param>
        /// <returns>Listado de unidad operativas encontrados</returns>
        ProcessResult<List<UnidadOperativaStaffResponse>> BuscarUnidadOperativaStaff(FiltroUnidadOperativa filtro);

        /// <summary>
        /// Registra una unidad operativa staff
        /// </summary>
        /// <param name="data">Parámetros de Búsqueda</param>
        /// <returns>Resultado del Proceso</returns>
        ProcessResult<DataUnidadOperativaStaffRequest> RegistrarUnidadOperativaStaff(DataUnidadOperativaStaffRequest data);

        /// <summary>
        /// Eliminar staff de unidad operativa
        /// </summary>
        /// <param name="data">Datos de equipo de unidad operativa</param>
        /// <returns></returns>
        ProcessResult<string> EliminarUnidadOperativaStaff(DataUnidadOperativaStaffRequest data);

        /// <summary>
        /// Obtener la unidad operativa superior de un nivel específico
        /// </summary>
        /// <param name="filtro">Obtener código de Unidad Operativa y nivel</param>      
        /// <returns>Unidad operativa matriz o superior</returns>
        ProcessResult<UnidadOperativaResponse> ObtenerUnidadOperativaPorNivelSuperior(FiltroUnidadOperativa filtro);

        /// <summary>
        /// Registra el usuario de consulta de la unidad operativa
        /// </summary>
        /// <param name="data">Parámetros de Búsqueda</param>
        /// <returns>Resultado del Proceso</returns>
        ProcessResult<DataUnidadOperativaUsuarioConsultaRequest> RegistrarUnidadOperativaUsuarioConsulta(DataUnidadOperativaUsuarioConsultaRequest data);

        /// <summary>
        /// Método para eliminar el usuario de consulta de la Unidad Operativa
        /// </summary>
        /// <param name="filtro">Datos de la unidad operativa usuario consulta</param>
        /// <returns>Resultado de la Operación</returns>
        ProcessResult<string> EliminarUnidadOperativaUsuarioConsulta(DataUnidadOperativaUsuarioConsultaRequest filtro);

        /// <summary>
        /// Realiza la búsqueda de los usuarios de consulta de la Unidad Operativa
        /// </summary>
        /// <param name="filtro">Código de la Unidad Operativa</param>
        /// <returns>Listado de usuarios de consulta</returns>
        ProcessResult<List<UnidadOperativaUsuarioConsultaResponse>> BuscarUsuariosConsultaUnidadOperativa(FiltroUnidadOperativa filtro);

        /// <summary>
        /// Obtener los responsables por unidad operativa y sus niveles superiores
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de la unidad operativa</param>
        /// <param name="nombreUnidadOperativa">Nombre de la unidad operativa</param>
        /// <returns>Unidades y responsables de niveles superiores</returns>
        ProcessResult<UnidadOperativaNivelResponse> ObtenerResponsablesUnidadOperativaPorNivel(string codigoUnidadOperativa, string nombreUnidadOperativa);

        /// <summary>
        /// Obtener las unidades operativas para consulta de un trabajador
        /// </summary>
        /// <param name="codigoTrabajador">Código del trabajador</param>
        /// <returns>Listado de unidades operativas</returns>
        ProcessResult<List<UnidadOperativaUsuarioConsultaResponse>> ListarUnidadesOperativasConsultaPorTrabajador(Guid codigoTrabajador);
    }
}

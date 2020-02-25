using System;
using System.Collections.Generic;
using Pe.Stracon.Politicas.Infraestructura.Core.Base;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;

namespace Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General
{
    /// <summary>
    /// Definición del repositorio UnidadOperativaLogic
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22150326 <br />
    /// Modificación:            <br />
    /// </remarks>
    public interface IUnidadOperativaLogicRepository : IQueryRepository<UnidadOperativaLogic>
    {
        /// <summary>
        /// Realiza la busqueda de unidades operativas
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de Unidad Operativa</param>
        /// <param name="nombre">Nombre a buscar</param>
        /// <param name="nivel">Nivel asociado</param>
        /// <param name="unidadPadre">Unidad perativa superior</param>
        /// <param name="estado">Estado del registro</param>
        /// <returns>Listado de unidad operativas encontrados</returns>
        List<UnidadOperativaLogic> BuscarUnidadOperativa(Guid? codigoUnidadOperativa, string nombre, string nivel, Guid? unidadPadre, string indicador, int numeroPagina, int registrosPagina);

        /// <summary>
        /// Realiza la busqueda de unidades operativas SAP
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de Unidad Operativa</param>
        /// <param name="nombre">Nombre a buscar</param>
        /// <param name="nivel">Nivel asociado</param>
        /// <param name="unidadPadre">Unidad perativa superior</param>
        /// <param name="estado">Estado del registro</param>
        /// <returns>Listado de unidad operativas encontrados</returns>
        List<UnidadOperativaLogic> BuscarUnidadOperativaSAP(Guid? codigoUnidadOperativa, string nombre, string nivel, Guid? unidadPadre, string indicador, int numeroPagina, int registrosPagina);

        /// <summary>
        /// Realiza la busqueda de unidades operativas de nivel proyecto por Empresa Matriz
        /// </summary>
        /// <param name="codigoUnidadOperativaMatriz">Código de Unidad Operativa Matriz</param>
        /// <returns>Listado de Unidad Operativa de nivel proyecto por Empresa Matriz</returns>
        List<UnidadOperativaLogic> BuscarUnidadOperativaProyectoPorEmpresaMatriz(Guid codigoUnidadOperativaMatriz);

        /// <summary>
        /// Lista registros de Unidades Operativas a partir de códigos.
        /// </summary>
        /// <param name="listaCodigos">Lista de códigos de Unidades Operativas</param>
        /// <returns>Lista unidades operativas</returns>
        List<UnidadOperativaLogic> ListarUnidadesOperativas(List<Guid?> listaCodigos);
        
        /// <summary>
        /// Lista las unidades operativas de un nivel superior al indicado como parámetro.
        /// </summary>
        /// <param name="codigoNivelUnidadOperativa">Codigo de Nivel de la Unidad Operativa</param>
        /// <returns>Listado de unidad operativas encontrados</returns>
        List<UnidadOperativaLogic> BuscarUnidadOperativaNivelSuperior(string codigoNivelUnidadOperativa);
        
        /// <summary>
        /// Lista las Unidades Operativas según el Responsable.
        /// </summary>
        /// <param name="loginResponsable">Código de Identificación del Responsable</param>
        /// <returns>Lista las Unidades Operativas</returns>
        List<UnidadOperativaLogic> ListarUnidadesOperativasPorResponsable(string loginResponsable);


        /// <summary>
        /// Valida Registro Codigo Identificacion
        /// </summary>
        /// <param name="codigoIdentificacion">Código de Identificacion</param>
        /// <param name="orden">Orden</param>
        /// <returns>Identificador con resultado</returns>
        List<UnidadOperativaLogic> RepiteCI(
            string codigoIdentificacion
        );

        /// <summary>
        /// Valida registro de Nombre
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <returns>Identificador con el resultado</returns>
        List<UnidadOperativaLogic> RepiteNombre(
            string nombre
        );

        /// <summary>
        /// Realiza la busqueda de unidades operativas staff
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de Unidad Operativa</param>
        /// <returns>Listado de unidad operativas encontrados</returns>
        List<UnidadOperativaStaffLogic> BuscarUnidadOperativaStaff(Guid? codigoUnidadOperativa, int numeroPagina = 1, int registrosPagina = -1);

        /// <summary>
        /// Obtener la unidad operativa superior de un nivel específico
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de Unidad Operativa</param>
        /// <param name="nivel">Código de nivel que se desea obtener</param>       
        /// <returns>Unidad operativa matriz o superior</returns>
        UnidadOperativaLogic ObtenerUnidadOperativaPorNivelSuperior(Guid? codigoUnidadOperativa, string nivel);

        /// <summary>
        /// Realiza la búsqueda de usuarios de consulta de la Unidad Operativa
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de la Unidad Operativa</param>
        /// <returns>Listado de usuarios de consulta</returns>
        List<UnidadOperativaUsuarioConsultaLogic> BuscarUsuariosConsultaUnidadOperativa(Guid? codigoUnidadOperativa);         

        /// <summary>
        /// Obtener los responsables de la unidad operativa y sus niveles superiores por el código o nombre de la Unidad Operativa
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de la Unidad Operativa</param>
        /// <param name="nombreUnidadOperativa">Nombre de la Unidad Operativa</param>
        /// <returns></returns>
        UnidadOperativaNivelLogic ObtenerResponsablesUnidadOperativaPorNivelSuperior(Guid? codigoUnidadOperativa, string nombreUnidadOperativa);

        /// <summary>
        /// Realiza la búsqueda de unidades operativas de consulta por trabajador
        /// </summary>
        /// <param name="codigoTrabajador">Código del trabajador</param>
        /// <returns>Listado unidades operativas de consulta del trabajador</returns>
        List<UnidadOperativaUsuarioConsultaLogic> ObtenerUnidadesOperativasConsultaPorTrabajador(Guid codigoTrabajador);
    }
}

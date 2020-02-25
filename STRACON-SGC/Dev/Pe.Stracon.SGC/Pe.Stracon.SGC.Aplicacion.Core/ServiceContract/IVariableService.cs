using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using System;
using System.Collections.Generic;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;

namespace Pe.Stracon.SGC.Aplicacion.Core.ServiceContract
{
    /// <summary>
    /// Interfaz que define el servicio de variable
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150527 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IVariableService : IGenericService
    {
        /// <summary>
        /// Realiza la busqueda de variables 
        /// </summary>
        /// <param name="filtro">Campo por el cual filtrar</param>
        /// <returns>Lista de variables</returns>
        ProcessResult<List<VariableResponse>> BuscarVariable(VariableRequest filtro);

        /// <summary>
        /// Realiza la busqueda de indicadores del sistema
        /// </summary>
        /// <param name="filtro">Campo por el cual filtrar</param>
        /// <param name="unidadOperativa">Unidad Operativa</param>
        /// <returns>Registro con resultados</returns>
        ProcessResult<string> ObtenerValorDefecto(ValorPorDefectoRequest filtro, UnidadOperativaResponse unidadOperativa);
    
        /// <summary>
        /// Registrar Variable
        /// </summary>
        /// <param name="filtro">Variable a registrar</param>
        /// <returns>Indicador de conformidad
        /// 0: Registro satisfactorio
        /// 2: Identificador repetido
        /// 3: Nombre repetido
        /// -1: Ocurrio un Error Inesperado</returns>
        ProcessResult<string> RegistrarVariable(VariableRequest filtro);

        /// <summary>
        /// Eliminar una o muchas actividades de Variable plantilla
        /// </summary>
        /// <param name="listaCodigoFlujoAprobacionEstadio">Lista de códigos a eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> EliminarVariablePlantilla(List<Object> listaCodigoFlujoAprobacionEstadio);
        
        /// <summary>
        /// Lista los tipos de variable definidos para las plantillas
        /// </summary>
        /// <returns>Lista de Tipos de Variable</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoVariable();
        
        /// <summary>
        /// Realiza la búsqueda de Campos de Variable
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Lista de Campos de Variable</returns>
        ProcessResult<List<VariableCampoResponse>> BuscarVariableCampo(VariableCampoRequest filtro);

        /// <summary>
        /// Registra los datos del Campo de Variable
        /// </summary>
        /// <param name="datos">Datos del Campo a Registrar</param>
        /// <returns>Código de resultado de operación</returns>
        ProcessResult<string> RegistrarVariableCampo(VariableCampoRequest datos);

        /// <summary>
        /// Método para eliminar campos de variable
        /// </summary>
        /// <param name="listaCodigos">Lista de Códigos de Campos de Variable</param>
        /// <returns>Código de resultado de operación</returns>
        ProcessResult<object> EliminarVariableCampo(List<VariableCampoRequest> listaCodigos);

        /// <summary>
        /// Lista los tipos de alineamiento definidos para las columnas de un tabla
        /// </summary>
        /// <returns>Lista de Tipos de Alineamiento</returns>
        ProcessResult<List<CodigoValorResponse>> ListarTipoAlineamiento();

        /// <summary>
        /// Registra los datos del Lista de Variable
        /// </summary>
        /// <param name="datos">Datos del Lista a Registrar</param>
        /// <returns>Código de resultado de operación</returns>
        ProcessResult<string> RegistrarVariableLista(VariableListaRequest datos);

        /// <summary>
        /// Método para eliminar lista de variable
        /// </summary>
        /// <param name="listaCodigos">Lista de Códigos de Lista de Variable</param>
        /// <returns>Código de resultado de operación</returns>
        ProcessResult<object> EliminarVariableLista(List<VariableListaRequest> listaCodigos);

        /// <summary>
        /// Realiza la búsqueda de Lista de Variable
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Lista de Variable Lista</returns>
        ProcessResult<List<VariableListaResponse>> BuscarVariableLista(VariableListaRequest filtro);
    }
}

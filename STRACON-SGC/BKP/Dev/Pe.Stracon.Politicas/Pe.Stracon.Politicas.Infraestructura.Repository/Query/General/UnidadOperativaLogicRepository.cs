using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using Pe.Stracon.Politicas.Infraestructura.Repository.Base;
using Pe.Stracon.PoliticasCross.Core.Extension;

namespace Pe.Stracon.Politicas.Infraestructura.Repository.Query.General
{
    /// <summary>
    /// Implementación del repositorio Unidad Operativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaLogicRepository : QueryRepository<UnidadOperativaLogic>, IUnidadOperativaLogicRepository
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
        public List<UnidadOperativaLogic> BuscarUnidadOperativa(Guid? codigoUnidadOperativa, string nombre, string nivel, Guid? codigoUnidadPadre, string indicador, int numeroPagina = 1, int registrosPagina = -1)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA", SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value },
                new SqlParameter("NOMBRE", SqlDbType.NVarChar) { Value = (object)nombre ?? DBNull.Value },
                new SqlParameter("CODIGO_NIVEL", SqlDbType.NVarChar) { Value = (object)nivel ?? DBNull.Value },
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA_PADRE", SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadPadre ?? DBNull.Value },
                new SqlParameter("INDICADOR_ACTIVA", SqlDbType.NVarChar){ Value = (object)indicador ?? DBNull.Value },
                new SqlParameter("NUMERO_PAGINA", SqlDbType.Int) { Value = numeroPagina },
                new SqlParameter("TAMANIO_PAGINA", SqlDbType.Int) { Value = registrosPagina }
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaLogic>("GRL.USP_UNIDAD_OPERATIVA_SEL", parametros).ToList();

            return result;
        }

        public List<UnidadOperativaLogic> BuscarUnidadOperativaSAP(Guid? codigoUnidadOperativa, string nombre, string nivel, Guid? codigoUnidadPadre, string indicador, int numeroPagina = 1, int registrosPagina = -1)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA", SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value },
                new SqlParameter("NOMBRE", SqlDbType.NVarChar) { Value = (object)nombre ?? DBNull.Value },
                new SqlParameter("CODIGO_NIVEL", SqlDbType.NVarChar) { Value = (object)nivel ?? DBNull.Value },
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA_PADRE", SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadPadre ?? DBNull.Value },
                new SqlParameter("INDICADOR_ACTIVA", SqlDbType.NVarChar){ Value = (object)indicador ?? DBNull.Value },
                new SqlParameter("NUMERO_PAGINA", SqlDbType.Int) { Value = numeroPagina },
                new SqlParameter("TAMANIO_PAGINA", SqlDbType.Int) { Value = registrosPagina }
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaLogic>("GRL.USP_UNIDAD_OPERATIVASAP_SEL", parametros).ToList();

            return result;
        }
        /// <summary>
        /// Lista registros de Unidades Operativas a partir de códigos.
        /// </summary>
        /// <param name="listaCodigos">Lista de códigos de Unidades Operativas</param>
        /// <returns>Lista de unidades operativas</returns>
        public List<UnidadOperativaLogic> ListarUnidadesOperativas(List<Guid?> listaCodigos)
        {
            try
            {
                var lista = listaCodigos.Select(c => new { CODIGO = c }).ToList();

                SqlParameter[] parametros = new SqlParameter[]
                {
                new SqlParameter("CODIGOS_UNIDAD_OPERATIVA", SqlDbType.Structured) { Value = lista.ToDataTable(), TypeName = "LISTA_GUID_TYPE"}
                };

                var resultado = this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaLogic>("GRL.USP_UNIDAD_OPERATIVA_LISTA_SEL", parametros).ToList();

                return resultado;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        /// <summary>
        /// Lista las unidades operativas de un nivel superior al indicado como parámetro.
        /// </summary>
        /// <param name="codigoNivelUnidadOperativa">Codigo de Nivel de la Unidad Operativa</param>
        /// <returns>Listado de unidad operativas encontrados</returns>
        public List<UnidadOperativaLogic> BuscarUnidadOperativaNivelSuperior(string codigoNivelUnidadOperativa)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_NIVEL_JERARQUIA", SqlDbType.NVarChar) { Value = (object)codigoNivelUnidadOperativa ?? DBNull.Value }
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaLogic>("GRL.USP_UNIDADES_OPERATIVAS_SUPERIORES_SEL", parametros).ToList();

            return result;
        }

        /// <summary>
        /// Lista las Unidades Operativas según el Responsable.
        /// </summary>
        /// <param name="loginResponsable">Código de Identificación del Responsable</param>
        /// <returns>Lista las Unidades Operativas</returns>
        public List<UnidadOperativaLogic> ListarUnidadesOperativasPorResponsable(string loginResponsable)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_IDENTIFICACION", SqlDbType.NVarChar, 50) { Value = (object)loginResponsable ?? DBNull.Value }
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaLogic>("GRL.USP_UNIDADES_OPERATIVAS_POR_RESPONSABLE_SEL", parametros).ToList();

            return result;
        }

        /// <summary>
        /// Verifica si existe el codigo de identificación
        /// </summary>
        /// <param name="codigoIdentificacion">codigo de identificación a buscar</param>
        /// <returns>Lista con repetidos</returns>
        public List<UnidadOperativaLogic> RepiteCI(string codigoIdentificacion)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_IDENTIFICACION",SqlDbType.NVarChar) { Value = (object)codigoIdentificacion ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaLogic>("GRL.USP_UNIDAD_OPERATIVA_CI_EXISTE_SEL", parametros).ToList();
            return result;
        }
        /// <summary>
        /// Verifica si existe nombre repetido
        /// </summary>
        /// <param name="nombre">Nombre a verificar</param>
        /// <returns>Identificador de nombre</returns>
        public List<UnidadOperativaLogic> RepiteNombre(string nombre)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("NOMBRE",SqlDbType.NVarChar) { Value = (object)nombre ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaLogic>("GRL.USP_UNIDAD_OPERATIVA_NOMBRE_EXISTE_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Realiza la busqueda de unidades operativas staff
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de Unidad Operativa</param>
        /// <returns>Listado de unidad operativas encontrados</returns>
        public List<UnidadOperativaStaffLogic> BuscarUnidadOperativaStaff(Guid? codigoUnidadOperativa, int numeroPagina = 1, int registrosPagina = -1)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA", SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value },
                new SqlParameter("NUMERO_PAGINA", SqlDbType.Int) { Value = numeroPagina },
                new SqlParameter("TAMANIO_PAGINA", SqlDbType.Int) { Value = registrosPagina }
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaStaffLogic>("GRL.USP_UNIDAD_OPERATIVA_STAFF_SEL", parametros).ToList();

            return result;
        }

        /// <summary>
        /// Realiza la busqueda de unidades operativas de nivel proyecto por Empresa Matriz
        /// </summary>
        /// <param name="codigoUnidadOperativaMatriz">Código de Unidad Operativa Matriz</param>
        /// <returns>Listado de Unidad Operativa de nivel proyecto por Empresa Matriz</returns>
        public List<UnidadOperativaLogic> BuscarUnidadOperativaProyectoPorEmpresaMatriz(Guid codigoUnidadOperativaMatriz)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA_MATRIZ", SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativaMatriz ?? DBNull.Value },
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaLogic>("GRL.USP_UNIDAD_OPERATIVA_PROYECTO_POR_EMPRESA_MATRIZ_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Obtener la unidad operativa superior de un nivel específico
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de Unidad Operativa</param>
        /// <param name="nivel">Código de nivel que se desea obtener</param>       
        /// <returns>Unidad operativa matriz o superior</returns>
        public UnidadOperativaLogic ObtenerUnidadOperativaPorNivelSuperior(Guid? codigoUnidadOperativa, string nivel)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA", SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value },
                new SqlParameter("CODIGO_NIVEL_JERARQUIA", SqlDbType.NVarChar) { Value = (object)nivel ?? DBNull.Value }              
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaLogic>("GRL.USP_UNIDAD_OPERATIVA_PADRE_POR_NIVEL_SEL", parametros).FirstOrDefault();

            return result;
        }

        /// <summary>
        /// Realiza la búsqueda de usuarios de consulta de la Unidad Operativa
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de la Unidad Operativa</param>
        /// <returns>Listado de usuarios de consulta</returns>
        public List<UnidadOperativaUsuarioConsultaLogic> BuscarUsuariosConsultaUnidadOperativa(Guid? codigoUnidadOperativa)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA", SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value },             
            };

            return this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaUsuarioConsultaLogic>("GRL.USP_UNIDAD_OPERATIVA_USUARIO_CONSULTA_SEL", parametros).ToList();
        }
    
        /// <summary>
        /// Obtener los responsables de la unidad operativa y sus niveles superiores por el código o nombre de la Unidad Operativa
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de la Unidad Operativa</param>
        /// <param name="nombreUnidadOperativa">Nombre de la Unidad Operativa</param>
        /// <returns></returns>
        public UnidadOperativaNivelLogic ObtenerResponsablesUnidadOperativaPorNivelSuperior(Guid? codigoUnidadOperativa, string nombreUnidadOperativa)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA", SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value },
                new SqlParameter("NOMBRE_UNIDAD_OPERATIVA", SqlDbType.NVarChar) { Value = (object)nombreUnidadOperativa ?? DBNull.Value }              
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaNivelLogic>("GRL.USP_UNIDAD_OPERATIVA_RESPONSABLES_POR_NIVEL_SEL", parametros).FirstOrDefault();

            return result;
        }


        /// <summary>
        /// Realiza la búsqueda de unidades operativas de consulta por trabajador
        /// </summary>
        /// <param name="codigoTrabajador">Código del trabajador</param>
        /// <returns>Listado unidades operativas de consulta del trabajador</returns>
        public List<UnidadOperativaUsuarioConsultaLogic> ObtenerUnidadesOperativasConsultaPorTrabajador(Guid codigoTrabajador)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_TRABAJADOR", SqlDbType.UniqueIdentifier) { Value = (object)codigoTrabajador ?? DBNull.Value },             
            };

            return this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaUsuarioConsultaLogic>("GRL.USP_UNIDAD_OPERATIVA_USUARIO_CONSULTA_POR_TRABAJADOR_SEL", parametros).ToList();
        }
    }
}

using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Query.Contractual
{
    /// <summary>
    /// Implementación del repositorio Plantilla
    /// </summary>
    public class PlantillaLogicRepository : QueryRepository<PlantillaLogic>, IPlantillaLogicRepository
    {
        /// <summary>
        /// Permite la búsqueda de plantillas
        /// </summary>
        /// <param name="codigoPlantilla">Código de Plantilla</param>
        /// <param name="descripcion">Descripción</param>
        /// <param name="codigoTipoServicio">Código de Tipo de Servicio</param>
        /// <param name="codigoTipoRequerimiento">Código de Tipo de Requerimiento</param>
        /// <param name="codigoTipoDocumentoContrato">Código de Tipo de Documento de Contrato</param>
        /// <param name="codigoEstadoVigencia">Código de Estado de Vigencia</param>
        /// <param name="indicadorAdhesion">Indicador de Adhesión</param>
        /// <param name="fechaInicioVigencia">Fecha de Inicio de Vigencia</param>
        /// <param name="fechaFinVigencia">Fecha de Fin de Vigencia</param>
        /// <param name="numeroPagina">Total de Páginas</param>
        /// <param name="registroPagina">Total de Registros por Página</param>
        /// <returns>Lista de plantillas</returns>
        public List<PlantillaLogic> BuscarPlantilla(Guid? codigoPlantilla, string descripcion, string codigoTipoServicio,
                                                    string codigoTipoDocumentoContrato, string codigoEstadoVigencia, bool? indicadorAdhesion,
                                                    DateTime? fechaInicioVigencia, DateTime? fechaFinVigencia, int numeroPagina, int registroPagina)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PLANTILLA",SqlDbType.UniqueIdentifier) { Value = (object)codigoPlantilla ?? DBNull.Value},
                new SqlParameter("DESCRIPCION",SqlDbType.NVarChar) { Value = (object)descripcion ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_CONTRATO",SqlDbType.NVarChar) { Value = (object)codigoTipoServicio ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)codigoTipoDocumentoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADO",SqlDbType.NVarChar) { Value = (object)codigoEstadoVigencia ?? DBNull.Value},
                new SqlParameter("INDICADOR_ADHESION",SqlDbType.Bit) { Value = (object)indicadorAdhesion ?? DBNull.Value},
                new SqlParameter("FECHA_INICIO_VIGENCIA",SqlDbType.DateTime) { Value = (object)fechaInicioVigencia ?? DBNull.Value},
                new SqlParameter("FECHA_FIN_VIGENCIA",SqlDbType.DateTime) { Value = (object)fechaFinVigencia ?? DBNull.Value},
                new SqlParameter("PageNo",SqlDbType.Int) { Value = (object)numeroPagina ?? DBNull.Value},
                new SqlParameter("PageSize",SqlDbType.Int) { Value = (object)registroPagina ?? DBNull.Value}
            };
            
            var result = this.dataBaseProvider.ExecuteStoreProcedure<PlantillaLogic>("CTR.USP_PLANTILLA_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Realiza la búsqueda de plantillas de acuerdo a los tipos de servicios, requerimientos y documentos de contrato
        /// </summary>
        /// <param name="tipoContrato">Código de Tipo de Servicio</param>
        /// <param name="tipoRequerimiento">Código de Tipo de Requerimiento</param>
        /// <param name="tipoDocumentoContrato">Código de Tipo de Documento de Contrato</param>
        /// <param name="indicadorAdhesion">Indicador de Adhesión</param>
        /// <returns>Lista de plantillas de acuerdo a los tipos de servicios, requerimientos, documentos de contrato y adhesión</returns>
        public List<PlantillaLogic> BuscarPlantillaTipo(string tipoContrato, string tipoDocumentoContrato, bool indicadorAdhesion)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_TIPO_CONTRATO",SqlDbType.NVarChar) { Value = (object)tipoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)tipoDocumentoContrato ?? DBNull.Value},
                new SqlParameter("INDICADOR_ADHESION",SqlDbType.Bit) { Value = (object)indicadorAdhesion ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<PlantillaLogic>("CTR.USP_PLANTILLA_TIPO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Permite la búsqueda de plantilla párrafo
        /// </summary>
        /// <param name="codigoPlantillaParrafo">Código de Plantilla Párrafo</param>
        /// <param name="codigoPlantilla">Código de Plantilla</param>
        /// <param name="orden">Orden</param>
        /// <param name="titulo">Título</param>
        /// <param name="contenido">Contenido</param>
        /// <param name="numeroPagina">Total de Páginas</param>
        /// <param name="registroPagina">Total de Registros por Página</param>
        /// <returns>Lista de plantilla párrafo</returns>
        public List<PlantillaParrafoLogic> BuscarPlantillaParrafo(Guid? codigoPlantillaParrafo, Guid? codigoPlantilla, byte? orden,
                                                                  string titulo,string contenido, int numeroPagina, int registroPagina)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PLANTILLA_PARRAFO",SqlDbType.UniqueIdentifier) { Value = (object)codigoPlantillaParrafo ?? DBNull.Value},
                new SqlParameter("CODIGO_PLANTILLA",SqlDbType.UniqueIdentifier) { Value = (object)codigoPlantilla ?? DBNull.Value},
                new SqlParameter("ORDEN",SqlDbType.TinyInt) { Value = (object)orden ?? DBNull.Value},
                new SqlParameter("TITULO",SqlDbType.NVarChar) { Value = (object)titulo ?? DBNull.Value},
                new SqlParameter("CONTENIDO",SqlDbType.NVarChar) { Value = (object)contenido ?? DBNull.Value},
                new SqlParameter("PageNo",SqlDbType.Int) { Value = (object)numeroPagina ?? DBNull.Value},
                new SqlParameter("PageSize",SqlDbType.Int) { Value = (object)registroPagina ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<PlantillaParrafoLogic>("CTR.USP_PLANTILLA_PARRAFO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Permite la búsqueda de párrafos de una plantilla de acuerdo al orden y título
        /// </summary>
        /// <param name="codigoPlantilla">Código de Plantilla</param>
        /// <param name="orden">Orden</param>
        /// <param name="titulo">Título</param>
        /// <returns>Lista de párrafos de una plantilla de acuerdo al orden y título</returns>
        public List<PlantillaParrafoLogic> BuscarPlantillaParrafoOrdenTitulo(Guid codigoPlantilla, byte orden, string titulo)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PLANTILLA",SqlDbType.UniqueIdentifier) { Value = (object)codigoPlantilla ?? DBNull.Value},
                new SqlParameter("ORDEN",SqlDbType.TinyInt) { Value = (object)orden ?? DBNull.Value},
                new SqlParameter("TITULO",SqlDbType.NVarChar) { Value = (object)titulo ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO",SqlDbType.Char) { Value = (object)DatosConstantes.EstadoRegistro.Activo ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<PlantillaParrafoLogic>("CTR.USP_PLANTILLA_PARRAFO_ORDEN_TITULO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Permite la búsqueda de variables de un párrafo de acuerdo al código de plantilla párrafo
        /// </summary>
        /// <param name="codigoPlantillaParrafo">Código de Plantilla Párrafo</param>
        /// <returns>Lista de variables de un párrafo de acuerdo al código de párrafo</returns>
        public List<PlantillaParrafoVariableLogic> BuscarPlantillaParrafoVariableCodigoPlantillaParrafo(Guid codigoPlantillaParrafo)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PLANTILLA_PARRAFO",SqlDbType.UniqueIdentifier) { Value = (object)codigoPlantillaParrafo ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO",SqlDbType.Char) { Value = (object)DatosConstantes.EstadoRegistro.Activo ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<PlantillaParrafoVariableLogic>("CTR.USP_PLANTILLA_PARRAFO_VARIABLE_CODIGO_PLANTILLA_PARRAFO_SEL", parametros).ToList();
            return result;
        }
               
        /// <summary>
        /// Obtener notas al pie por contrato
        /// </summary>
        /// <param name="codigoContrato">Código de contrato</param>
        /// <returns>Lista de notas al pie</returns>
        //public List<PlantillaNotaPieLogic> ObtenerNotasPiePorContrato(Guid codigoPlantilla)
        //{
        //    SqlParameter[] parametros = new SqlParameter[]
        //    {
        //        new SqlParameter("CODIGO_PLANTILLA",SqlDbType.UniqueIdentifier) { Value = (object)codigoPlantilla ?? DBNull.Value}               
        //    };

        //    var result = this.dataBaseProvider.ExecuteStoreProcedure<PlantillaNotaPieLogic>("CTR.USP_PLANTILLA_NOTA_PIE_POR_CONTRATO_SEL", parametros).ToList();
        //    return result;
        //}

        /// <summary>
        /// Permite la búsqueda de notas al pie por plantilla
        /// </summary> 
        /// <param name="codigoPlantillaNotaPie">Código plantilla nota pie</param>
        /// <param name="codigoPlantilla">Código de Plantilla</param>    
        /// <param name="numeroPagina">Total de Páginas</param>
        /// <param name="registroPagina">Total de Registros por Página</param>
        /// <returns>Lista de plantilla párrafo</returns>
        public List<PlantillaNotaPieLogic> BuscarNotasPiePorPlantilla(Guid? codigoPlantillaNotaPie, Guid? codigoPlantilla, int numeroPagina, int registroPagina)
        {
            SqlParameter[] parametros = new SqlParameter[]
            { 
                new SqlParameter("CODIGO_PLANTILLA_NOTA_PIE",SqlDbType.UniqueIdentifier) { Value = (object)codigoPlantillaNotaPie ?? DBNull.Value},
                new SqlParameter("CODIGO_PLANTILLA",SqlDbType.UniqueIdentifier) { Value = (object)codigoPlantilla ?? DBNull.Value},             
                new SqlParameter("PageNo",SqlDbType.Int) { Value = (object)numeroPagina ?? DBNull.Value},
                new SqlParameter("PageSize",SqlDbType.Int) { Value = (object)registroPagina ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<PlantillaNotaPieLogic>("CTR.USP_PLANTILLA_NOTA_PIE_SEL", parametros).ToList();
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using Pe.Stracon.Politicas.Infraestructura.Repository.Base;

namespace Pe.Stracon.Politicas.Infraestructura.Repository.Query.General
{
    /// <summary>
    /// Implementación del repositorio de Parametro Valor
    /// </summary>
    /// <remarks>
    /// Creación:   GMD <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroSeccionLogicRepository : QueryRepository<ParametroSeccionLogic>, IParametroSeccionLogicRepository
    {
        /// <summary>
        /// Realiza la busqueda de Parámetro Seccion
        /// </summary>
        /// <param name="codigoParametro">Código de Parámetro</param>        
        /// <param name="codigoSeccion">Código de Sección</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="codigoTipoDato">Código de Tipo de Dato</param>
        /// <param name="indicadorPermiteModificar">Identificador de Permite Modificar</param>
        /// <param name="indicadorObligatorio">Indicador de Sección Obligatorio</param>
        /// <param name="indicadorSistema">Indicador de Sistema</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista de secciones de parametro</returns>
        public List<ParametroSeccionLogic> BuscarParametroSeccion(int? codigoParametro, int? codigoSeccion, string nombre, string codigoTipoDato, bool? indicadorPermiteModificar, bool? indicadorObligatorio, bool? indicadorSistema, string estadoRegistro)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int)             { Value = (object)codigoParametro ?? DBNull.Value },               
                new SqlParameter("CODIGO_SECCION", SqlDbType.Int)               { Value = (object)codigoSeccion ?? DBNull.Value },
                new SqlParameter("NOMBRE", SqlDbType.NVarChar)                  { Value = (object)nombre ?? DBNull.Value },
                new SqlParameter("CODIGO_TIPO_DATO", SqlDbType.Char)            { Value = (object)codigoTipoDato ?? DBNull.Value },
                new SqlParameter("INDICADOR_PERMITE_MODIFICAR", SqlDbType.Bit)  { Value = (object)indicadorPermiteModificar ?? DBNull.Value },
                new SqlParameter("INDICADOR_OBLIGATORIO", SqlDbType.Bit)        { Value = (object)indicadorObligatorio ?? DBNull.Value },
                new SqlParameter("INDICADOR_SISTEMA", SqlDbType.Bit)            { Value = (object)indicadorSistema ?? DBNull.Value },
                new SqlParameter("ESTADO_REGISTRO", SqlDbType.VarChar)          { Value = (object)estadoRegistro ?? DBNull.Value }
            };
            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<ParametroSeccionLogic>("GRL.USP_PARAMETRO_SECCION_SEL", parametros).ToList();

            return resultado;
        }
    }
}
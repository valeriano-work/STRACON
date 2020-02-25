using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using Pe.Stracon.Politicas.Infraestructura.Repository.Base;
using Pe.Stracon.Politicas.Cross.Core.Base;

namespace Pe.Stracon.Politicas.Infraestructura.Repository.Query.General
{
    /// <summary>
    /// Implementación del repositorio de Parametro Valor
    /// </summary>
    /// <remarks>
    /// Creación:   GMD <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroValorLogicRepository : QueryRepository<ParametroValorLogic>, IParametroValorLogicRepository
    {
        /// <summary>
        /// Entorno de Aplicación Actual
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        /// <summary>
        /// Realiza la busqueda de Parametro Valor
        /// </summary>
        /// <param name="codigoParametro">Código de Parametro</param>
        /// <param name="indicadorEmpresa">Indicador Empresa</param>
        /// <param name="codigoEmpresa">Código de Empresa</param>
        /// <param name="codigoSistema">Código de Sistema</param>
        /// <param name="codigoIdentificador">Código Identificador</param>
        /// <param name="tipoParametro">Tipo de Parámetro</param>
        /// <param name="codigoSeccion">Código de Sección</param>
        /// <param name="codigoValor">Código de Valor</param>
        /// <param name="valor">Valor</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista de valores de parametro</returns>
        public List<ParametroValorLogic> BuscarParametroValor(int? codigoParametro, bool? indicadorEmpresa, Guid? codigoEmpresa, Guid? codigoSistema, string codigoIdentificador, string tipoParametro, int? codigoSeccion, int? codigoValor, string valor, string estadoRegistro)
        {

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int)             { Value = (object)codigoParametro ?? DBNull.Value },
                new SqlParameter("INDICADOR_EMPRESA", SqlDbType.Bit)            { Value = (object)indicadorEmpresa ?? DBNull.Value },
                new SqlParameter("CODIGO_EMPRESA", SqlDbType.UniqueIdentifier)  { Value = (object)codigoEmpresa ?? DBNull.Value },
                new SqlParameter("CODIGO_SISTEMA", SqlDbType.UniqueIdentifier)  { Value = (object)codigoSistema ?? DBNull.Value },
                new SqlParameter("CODIGO_IDENTIFICADOR", SqlDbType.VarChar)     { Value = (object)codigoIdentificador ?? DBNull.Value },                
                new SqlParameter("TIPO_PARAMETRO", SqlDbType.Char)              { Value = (object)tipoParametro ?? DBNull.Value },
                new SqlParameter("CODIGO_SECCION", SqlDbType.Int)               { Value = (object)codigoSeccion ?? DBNull.Value },
                new SqlParameter("CODIGO_VALOR", SqlDbType.Int)                 { Value = (object)codigoValor ?? DBNull.Value },
                new SqlParameter("VALOR", SqlDbType.VarChar)                    { Value = (object)valor ?? DBNull.Value },
                new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char)             { Value = (object)estadoRegistro ?? DBNull.Value }
            };
            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<ParametroValorLogic>("GRL.USP_PARAMETRO_VALOR_SEL", parametros).ToList();

            return resultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoParametro"></param>
        /// <param name="indicadorEmpresa"></param>
        /// <param name="codigoEmpresa"></param>
        /// <param name="codigoSistema"></param>
        /// <param name="codigoIdentificador"></param>
        /// <param name="tipoParametro"></param>
        /// <param name="codigoSeccion"></param>
        /// <param name="codigoValor"></param>
        /// <param name="valor"></param>
        /// <param name="estadoRegistro"></param>
        /// <returns></returns>
        public DataTable BuscarParametroValorMejorado(int? codigoParametro, bool? indicadorEmpresa, Guid? codigoEmpresa, Guid? codigoSistema, string codigoIdentificador, string tipoParametro, int? codigoSeccion, int? codigoValor, string valor, string estadoRegistro)
        {
            DataTable dt = new DataTable();
            SqlConnection sc = (SqlConnection)this.dataBaseProvider.DataBase.Connection;
            try
            {
                if (sc.State != ConnectionState.Open)
                    sc.Open();
                using (var cmd = sc.CreateCommand())
                {
                    cmd.CommandTimeout = int.MaxValue;
                    cmd.CommandText = "GRL.USP_PARAMETRO_VALOR_MEJORADO_SEL";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("CODIGO_PARAMETRO", (object)codigoParametro ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("INDICADOR_EMPRESA", (object)indicadorEmpresa ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("CODIGO_EMPRESA", (object)codigoEmpresa ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("CODIGO_SISTEMA", (object)codigoSistema ?? DBNull.Value));

                    cmd.Parameters.Add(new SqlParameter("CODIGO_IDENTIFICADOR", (object)codigoIdentificador ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("TIPO_PARAMETRO", (object)tipoParametro ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("CODIGO_SECCION", (object)codigoSeccion ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("CODIGO_VALOR", (object)codigoValor ?? DBNull.Value));

                    cmd.Parameters.Add(new SqlParameter("VALOR", (object)valor ?? DBNull.Value));
                    cmd.Parameters.Add(new SqlParameter("ESTADO_REGISTRO", (object)estadoRegistro ?? DBNull.Value));
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sc.State != ConnectionState.Open)
                    sc.Close();
            }
            return dt;
        }

        /// <summary>
        /// Realiza el registro de un parametro valor
        /// </summary>
        /// <param name="parametroValorLogic">Entidad logica de parametro valor</param>
        /// <returns>Cantidad de registros registrados</returns>
        public int RegistrarParametroValor(ParametroValorLogic parametroValorLogic)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int)             { Value = parametroValorLogic.CodigoParametro },                             
                new SqlParameter("CODIGO_SECCION", SqlDbType.Int)               { Value = parametroValorLogic.CodigoSeccion },
                new SqlParameter("CODIGO_VALOR", SqlDbType.Int)                 { Value = parametroValorLogic.CodigoValor },
                new SqlParameter("VALOR", SqlDbType.NVarChar)                   { Value = parametroValorLogic.Valor },
                new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char)             { Value = parametroValorLogic.EstadoRegistro },
                new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar)        { Value = entornoActualAplicacion.UsuarioSession },
                new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar)       { Value = entornoActualAplicacion.Terminal }
            };
            var resultado = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("GRL.USP_PARAMETRO_VALOR_INS", parametros);

            return resultado;
        }

        /// <summary>
        /// Realiza la modificación de un parametro valor
        /// </summary>
        /// <param name="parametroValorLogic">Entidad logica de parametro valor</param>
        /// <returns>Cantidad de registros modificados</returns>
        public int ModificarParametroValor(ParametroValorLogic parametroValorLogic)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PARAMETRO", SqlDbType.Int)             { Value = parametroValorLogic.CodigoParametro },                             
                new SqlParameter("CODIGO_SECCION", SqlDbType.Int)               { Value = parametroValorLogic.CodigoSeccion },
                new SqlParameter("CODIGO_VALOR", SqlDbType.Int)                 { Value = parametroValorLogic.CodigoValor },
                new SqlParameter("VALOR", SqlDbType.NVarChar)                   { Value = (object) parametroValorLogic.Valor ?? DBNull.Value },
                new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char)             { Value = (object) parametroValorLogic.EstadoRegistro ?? DBNull.Value },
                new SqlParameter("USUARIO_MODIFICACION", SqlDbType.NVarChar)    { Value = entornoActualAplicacion.UsuarioSession },
                new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.NVarChar)   { Value = entornoActualAplicacion.Terminal }
            };
            var resultado = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("GRL.USP_PARAMETRO_VALOR_UPD", parametros);

            return resultado;
        }
    }
}
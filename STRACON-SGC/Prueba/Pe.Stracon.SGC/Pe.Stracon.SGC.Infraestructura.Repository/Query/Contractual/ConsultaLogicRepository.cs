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
    /// Implementación del repositorio de Consulta
    /// </summary>
    public class ConsultaLogicRepository : QueryRepository<ConsultaLogic>, IConsultaLogicRepository
    {
        /// <summary>
        /// Retorna la lista de consulta.
        /// </summary>
        /// <param name="codigoRemitente">Codigo de Remitente</param>
        /// <param name="codigoDestinatario">Código de destinatario</param>
        /// <param name="CodigoTipoConsulta">Código de tipo de consulta</param>
        /// <param name="codigoUnidadOperativa">Código de unidad operativa</param>
        /// <param name="codigoArea">Código de área</param>
        /// <param name="codigoConsulta">Código de consulta</param>
        /// <param name="codigoUsuarioSesion">Código de usuario de sesion</param>
        /// <returns>Lista de consultas</returns>
        public List<ConsultaLogic> ListaConsulta(Guid? codigoRemitente, Guid? codigoDestinatario, string CodigoTipoConsulta, Guid? codigoUnidadOperativa, string codigoArea, Guid? codigoConsulta, Guid? codigoUsuarioSesion, string estadoConsulta, int numeroPagina, int registroPagina)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_REMITENTE",SqlDbType.UniqueIdentifier) { Value = (object)codigoRemitente ?? DBNull.Value},
                new SqlParameter("CODIGO_DESTINATARIO",SqlDbType.UniqueIdentifier) { Value = (object)codigoDestinatario ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_CONSULTA",SqlDbType.NVarChar) { Value = (object)CodigoTipoConsulta ?? DBNull.Value},
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value},
                new SqlParameter("CODIGO_AREA",SqlDbType.NVarChar) { Value = (object)codigoArea ?? DBNull.Value},
                new SqlParameter("CODIGO_CONSULTA",SqlDbType.UniqueIdentifier) { Value = (object)codigoConsulta ?? DBNull.Value},
                new SqlParameter("ESTADO_CONSULTA",SqlDbType.VarChar) { Value = (object)estadoConsulta ?? DBNull.Value},
                new SqlParameter("CODIGO_USUARIO_SESSION",SqlDbType.UniqueIdentifier) { Value = (object)codigoUsuarioSesion ?? DBNull.Value},
                new SqlParameter("PageNo",SqlDbType.Int) { Value = (object)numeroPagina ?? DBNull.Value},
                new SqlParameter("PageSize",SqlDbType.Int) { Value = (object)registroPagina ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ConsultaLogic>("CTR.USP_CONSULTA_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Envia correo de consulta
        /// </summary>
        /// <param name="asunto">Asunto</param>
        /// <param name="textoNotificar">Texto a notificar</param>
        /// <param name="cuentaNotificar">Cuenta a notificar</param>
        /// <param name="cuentasCopias">Cuentas a copiar en el correo</param>
        /// <param name="profileCorreo">Perfil del correo</param>
        public int NotificarConsulta(string asunto, string textoNotificar, string cuentaNotificar, string cuentasCopias, string profileCorreo)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {                
                new SqlParameter("ASUNTO",SqlDbType.NVarChar) { Value = (object)asunto ?? DBNull.Value},
                new SqlParameter("TEXTO_NOTIFICAR",SqlDbType.NVarChar) { Value = (object)textoNotificar ?? DBNull.Value},
                new SqlParameter("CUENTA_NOTIFICAR",SqlDbType.NVarChar) { Value = (object)cuentaNotificar ?? DBNull.Value},
                new SqlParameter("CUENTAS_COPIAS",SqlDbType.NVarChar) { Value = (object)cuentasCopias ?? DBNull.Value},
                new SqlParameter("PROFILE_CORREO",SqlDbType.NVarChar) { Value = (object)profileCorreo ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<int>("CTR.USP_ENVIAR_CORREO_CONSULTA", parametros).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Retorna la lista de consulta.
        /// </summary>
        /// <param name="codigoRemitente">Codigo de Remitente</param>
        /// <param name="codigoDestinatario">Código de destinatario</param>
        /// <param name="CodigoTipoConsulta">Código de tipo de consulta</param>
        /// <param name="codigoUnidadOperativa">Código de unidad operativa</param>
        /// <param name="codigoArea">Código de área</param>
        /// <param name="codigoConsulta">Código de consulta</param>
        /// <param name="codigoUsuarioSesion">Código de usuario de sesion</param>
        /// <returns>Lista de consultas</returns>
        public List<ConsultaLogic> ListaConsultaSimple(Guid? codigoRemitente, Guid? codigoDestinatario, string CodigoTipoConsulta, Guid? codigoUnidadOperativa, string codigoArea, Guid? codigoConsulta, string estadoConsulta)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_REMITENTE",SqlDbType.UniqueIdentifier) { Value = (object)codigoRemitente ?? DBNull.Value},
                new SqlParameter("CODIGO_DESTINATARIO",SqlDbType.UniqueIdentifier) { Value = (object)codigoDestinatario ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_CONSULTA",SqlDbType.NVarChar) { Value = (object)CodigoTipoConsulta ?? DBNull.Value},
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value},
                new SqlParameter("CODIGO_AREA",SqlDbType.NVarChar) { Value = (object)codigoArea ?? DBNull.Value},
                new SqlParameter("CODIGO_CONSULTA",SqlDbType.UniqueIdentifier) { Value = (object)codigoConsulta ?? DBNull.Value},
                new SqlParameter("ESTADO_CONSULTA",SqlDbType.VarChar) { Value = (object)estadoConsulta ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ConsultaLogic>("CTR.USP_LISTAR_CONSULTA_SEL", parametros).ToList();
            return result;
        }
    }
}

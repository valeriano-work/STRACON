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
    /// Implementación del repositorio Consulta Adjunto
    /// </summary>
    public class ConsultaAdjuntoLogicRepository : QueryRepository<ConsultaAdjuntoLogic>, IConsultaAdjuntoLogicRepository
    {
        /// <summary>
        /// Permite buscar los documentos adjuntos de una consulta
        /// </summary>
        /// <param name="codigoContratoDocumentoAdjunto">Código del Documento adjunto al contrato</param>
        /// <param name="codigoContrato">Código del Contrato</param>
        /// <param name="codigoArchivo">Código de Archivo</param>
        /// <param name="nombreArchivo">Nombre de Archivo</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista documentos adjuntos del contrato</returns>
        public List<ConsultaAdjuntoLogic> BuscarConsultaAdjunto(Guid? codigoConsultaAdjunto, Guid? codigoConsulta, int? codigoArchivo, string nombreArchivo, string estadoRegistro)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONSULTA_ADJUNTO",SqlDbType.UniqueIdentifier) { Value = (object)codigoConsultaAdjunto ?? DBNull.Value},
                new SqlParameter("CODIGO_CONSULTA",SqlDbType.UniqueIdentifier) { Value = (object)codigoConsulta ?? DBNull.Value},
                new SqlParameter("CODIGO_ARCHIVO",SqlDbType.Int) { Value = (object)codigoArchivo ?? DBNull.Value},
                new SqlParameter("NOMBRE_ARCHIVO",SqlDbType.NVarChar) { Value = (object)nombreArchivo ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO",SqlDbType.Char) { Value = (object)estadoRegistro ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ConsultaAdjuntoLogic>("CTR.USP_CONSULTA_ADJUNTO_SEL", parametros).ToList();
            return result;
        }
    }
}

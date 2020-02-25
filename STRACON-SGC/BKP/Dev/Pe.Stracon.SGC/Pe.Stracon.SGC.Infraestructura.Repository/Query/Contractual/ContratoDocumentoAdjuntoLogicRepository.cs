using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
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
    /// Implementación del repositorio Contrato Documento Adjunto
    /// </summary>
    public class ContratoDocumentoAdjuntoLogicRepository : QueryRepository<ContratoDocumentoAdjuntoLogic>, IContratoDocumentoAdjuntoLogicRepository
    {
        /// <summary>
        /// Permite buscar los documentos adjuntos de un contrato
        /// </summary>
        /// <param name="codigoContratoDocumentoAdjunto">Código del Documento adjunto al contrato</param>
        /// <param name="codigoContrato">Código del Contrato</param>
        /// <param name="codigoArchivo">Código de Archivo</param>
        /// <param name="nombreArchivo">Nombre de Archivo</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista documentos adjuntos del contrato</returns>
        public List<ContratoDocumentoAdjuntoLogic> BuscarContratoDocumentoAdjunto(Guid? codigoContratoDocumentoAdjunto, Guid? codigoContrato, int? codigoArchivo, string nombreArchivo, string estadoRegistro)
        {            
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_DOCUMENTO_ADJUNTO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContratoDocumentoAdjunto ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_ARCHIVO",SqlDbType.Int) { Value = (object)codigoArchivo ?? DBNull.Value},
                new SqlParameter("NOMBRE_ARCHIVO",SqlDbType.NVarChar) { Value = (object)nombreArchivo ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO",SqlDbType.Char) { Value = (object)estadoRegistro ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoDocumentoAdjuntoLogic>("CTR.USP_CONTRATO_DOCUMENTO_ADJUNTO_SEL", parametros).ToList();
            return result;
        }
    }
}

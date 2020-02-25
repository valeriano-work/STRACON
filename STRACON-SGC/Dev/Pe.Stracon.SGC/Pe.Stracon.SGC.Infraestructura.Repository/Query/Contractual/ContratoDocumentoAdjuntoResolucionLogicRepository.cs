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
    public class ContratoDocumentoAdjuntoResolucionLogicRepository : QueryRepository<ContratoDocumentoAdjuntoResolucionLogic>, IContratoDocumentoAdjuntoResolucionLogicRepository
    {
        /// <summary>
        /// Permite buscar los documentos adjuntos de un contrato
        /// </summary>
        /// <param name="codigoContratoDocumentoAdjuntoResolucion">Código del Documento adjunto al contrato</param>
        /// <param name="codigoContrato">Código del Contrato</param>
        /// <param name="codigoArchivo">Código de Archivo</param>
        /// <param name="nombreArchivo">Nombre de Archivo</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista documentos adjuntos del contrato</returns>
        public List<ContratoDocumentoAdjuntoResolucionLogic> BuscarContratoDocumentoAdjuntoResolucion(Guid? codigoContratoDocumentoAdjuntoResolucion, Guid? codigoContrato, int? codigoArchivo, string nombreArchivo, string estadoRegistro)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION",SqlDbType.UniqueIdentifier) { Value = (object)codigoContratoDocumentoAdjuntoResolucion ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_ARCHIVO",SqlDbType.Int) { Value = (object)codigoArchivo ?? DBNull.Value},
                new SqlParameter("NOMBRE_ARCHIVO",SqlDbType.NVarChar) { Value = (object)nombreArchivo ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO",SqlDbType.Char) { Value = (object)estadoRegistro ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoDocumentoAdjuntoResolucionLogic>("CTR.USP_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION_SEL", parametros).ToList();
            return result;
        }

        public int Insertar_Documento_Adjunto_Resolucion(Guid? codigoContrato, int? codigoArchivo, string nombreArchivo, string rutaArchivoSharepoint, string usuarioCreacion, string terminalCreacion, DateTime fechaResolucion)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_ARCHIVO",SqlDbType.Int) { Value = (object)codigoArchivo ?? DBNull.Value},
                new SqlParameter("NOMBRE_ARCHIVO",SqlDbType.NVarChar) { Value = (object)nombreArchivo ?? DBNull.Value},
                new SqlParameter("RUTA_ARCHIVO_SHAREPOINT",SqlDbType.NVarChar) { Value = (object)rutaArchivoSharepoint ?? DBNull.Value},
                new SqlParameter("USUARIO_CREACION",SqlDbType.NVarChar) { Value = (object)usuarioCreacion ?? DBNull.Value},
                new SqlParameter("TERMINAL_CREACION",SqlDbType.NVarChar) { Value = (object)terminalCreacion ?? DBNull.Value},
                new SqlParameter("FECHA_RESOLUCION",SqlDbType.DateTime) { Value = (object)fechaResolucion ?? DBNull.Value}
            };
            int result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.INSERTAR_CONTRATO_DOCUMENTO_ADJUNTO_RESOLUCION", parametros);
            return result;
        }


    }
}
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.Repository.Base;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Command.Contractual
{
    /// <summary>
    /// Implementación del Repositorio de Contrato Documento
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150611 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ContratoDocumentoEntityRepository : ComandRepository<ContratoDocumentoEntity>, IContratoDocumentoEntityRepository
    {
        /// <summary>
        /// Interfaz para el manejo de auditoría
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        /// <summary>
        /// Realiza la inserción de registros de Contrato Documento
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int RegistrarContratoDocumento(ContratoDocumentoEntity data)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_DOCUMENTO",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContratoDocumento ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_ARCHIVO",SqlDbType.Int) { Value = (object)data.CodigoArchivo ?? DBNull.Value},
                new SqlParameter("RUTA_ARCHIVO_SHAREPOINT",SqlDbType.NVarChar) { Value = (object)data.RutaArchivoSharePoint ?? DBNull.Value},
                new SqlParameter("CONTENIDO",SqlDbType.NVarChar) { Value = (object)data.Contenido ?? DBNull.Value},
                new SqlParameter("CONTENIDO_BUSQUEDA",SqlDbType.NVarChar) { Value = (object)data.ContenidoBusqueda ?? DBNull.Value},
                new SqlParameter("INDICADOR_ACTUAL",SqlDbType.Bit) { Value = (object)data.IndicadorActual ?? DBNull.Value},
                new SqlParameter("VERSION",SqlDbType.TinyInt) { Value = (object)data.Version ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char){Value = (object)DatosConstantes.EstadoRegistro.Activo ?? DBNull.Value},
                new SqlParameter("USUARIO_CREACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.UsuarioSession ?? DBNull.Value},
                new SqlParameter("FECHA_CREACION",SqlDbType.DateTime) { Value = (object)data.FechaCreacion ?? DBNull.Value},
                new SqlParameter("TERMINAL_CREACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.Terminal ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_CONTRATO_DOCUMENTO_INS", parametros);
            return result;
        }
    }
}
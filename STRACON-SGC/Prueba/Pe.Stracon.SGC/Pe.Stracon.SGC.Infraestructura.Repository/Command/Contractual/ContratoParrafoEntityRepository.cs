using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Command.Contractual
{
    /// <summary>
    /// Implementación del Repositorio de Contrato Párrafo
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150612 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ContratoParrafoEntityRepository : ComandRepository<ContratoParrafoEntity>, IContratoParrafoEntityRepository
    {
        /// <summary>
        /// Interfaz para el manejo de auditoría
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        /// <summary>
        /// Realiza la inserción de registros de Contrato Párrafo
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int RegistrarContratoParrafo(ContratoParrafoEntity data)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_PARRAFO",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContratoParrafo ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_PLANTILLA_PARRAFO",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoPlantillaParrafo ?? DBNull.Value},
                new SqlParameter("CONTENIDO", SqlDbType.NVarChar) { Value = (object)data.ContenidoParrafo ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char){Value = (object)DatosConstantes.EstadoRegistro.Activo ?? DBNull.Value},
                new SqlParameter("USUARIO_CREACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.UsuarioSession ?? DBNull.Value},
                new SqlParameter("FECHA_CREACION",SqlDbType.DateTime) { Value = (object)data.FechaCreacion ?? DBNull.Value},
                new SqlParameter("TERMINAL_CREACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.Terminal ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_CONTRATO_PARRAFO_INS", parametros);
            return result;
        }

        /// <summary>
        /// Elimina el contenido de un contrato
        /// </summary>
        /// <param name="CodigoContrato">Código de contrato</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int EliminarContenidoContrato(Guid CodigoContrato)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)CodigoContrato ?? DBNull.Value},
                new SqlParameter("USER_CREACION",SqlDbType.NVarChar) { Value = entornoActualAplicacion.UsuarioSession},
                new SqlParameter("TERMINAL_CREACION",SqlDbType.NVarChar) { Value = entornoActualAplicacion.Terminal}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_ELIMINAR_CONTENIDO_CONTRATO_DEL", parametros);
            return result;
        }
    }
}
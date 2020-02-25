using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Implementación del repositorio Flujo Aprobacion
    /// </summary>
    public class ProcesoAuditoriaLogicRepository : QueryRepository<ProcesoAuditoriaLogic>, IProcesoAuditoriaLogicRepository
    {
        /// <summary>
        /// Realiza la busqueda de Proceso Auditoria
        /// </summary>
        /// <param name="codigoAuditoria">Código de auditoria</param>
        /// <param name="codigoUnidadOperativa">Código de unidad operativa</param>
        /// <param name="fechaPlanificada">Fecha planificada</param>
        /// <param name="fechaEjecucion">Fecha de Ejecución</param>
        /// <param name="estadoRegistro">Estado de registro</param>
        /// <returns>Procesos de Auditoria</returns>
        public List<ProcesoAuditoriaLogic> BuscarBandejaProcesoAuditoria(
                Guid? codigoAuditoria,
                Guid? codigoUnidadOperativa,
                DateTime? fechaPlanificada,
                DateTime? fechaEjecucion,
                string estadoRegistro
        )
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_AUDITORIA",SqlDbType.UniqueIdentifier) { Value = (object)codigoAuditoria ?? DBNull.Value},
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value},
                new SqlParameter("FECHA_PLANIFICADA",SqlDbType.DateTime) { Value = (object)fechaPlanificada ?? DBNull.Value},
                new SqlParameter("FECHA_EJECUCION",SqlDbType.DateTime) { Value = (object)fechaEjecucion ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO",SqlDbType.NVarChar) { Value = (object)estadoRegistro ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ProcesoAuditoriaLogic>("CTR.USP_AUDITORIA_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Verifica si se repite un proceso de Auditoria
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de Unidad Operativa</param>
        /// <param name="fechaPlanificada">Fecha Planificada</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public List<ProcesoAuditoriaLogic> RepiteProcesoAuditoria(
                Guid codigoUnidadOperativa,
                DateTime fechaPlanificada
        )
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value},
                new SqlParameter("FECHA_PLANIFICADA",SqlDbType.DateTime) { Value = (object)fechaPlanificada ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ProcesoAuditoriaLogic>("CTR.USP_AUDITORIA_EXISTE_SEL", parametros).ToList();
            return result;
        }

    }
}

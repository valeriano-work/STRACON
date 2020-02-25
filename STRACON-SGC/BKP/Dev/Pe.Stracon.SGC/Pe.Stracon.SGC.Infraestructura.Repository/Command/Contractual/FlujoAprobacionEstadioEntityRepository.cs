using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Command.Contractual
{
    /// <summary>
    /// Implementación del Repositorio de Flujo Aprobación Estadio
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150612 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class FlujoAprobacionEstadioEntityRepository : ComandRepository<FlujoAprobacionEstadioEntity>, IFlujoAprobacionEstadioEntityRepository
    {
        /// <summary>
        /// Actualiza indicador version oficial
        /// </summary>
        /// <param name="codigoFlujoAprobacion">Código flujo aprobación</param>
        /// <returns>lista con registros</returns>
        public int ActualizaIndicadorVersionOficial(
            Guid codigoFlujoAprobacion
        ){
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_FLUJO_APROBACION",SqlDbType.UniqueIdentifier) { Value = codigoFlujoAprobacion},
                new SqlParameter("USUARIO_MODIFICACION",SqlDbType.NVarChar) { Value = entornoActualAplicacion.UsuarioSession},
                new SqlParameter("TERMINAL_MODIFICACION",SqlDbType.NVarChar) { Value = entornoActualAplicacion.Terminal}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_INDICADOR_VERSION_OFICIAL_UPDATE", parametros);
            return result;
        }
        /// <summary>
        /// Actualiza indicador número contrato
        /// </summary>
        /// <param name="codigoFlujoAprobacion">Código flujo aprobación</param>
        /// <returns>lista con registros</returns>
        public int ActualizaIndicadorNumeroContrato(
            Guid codigoFlujoAprobacion
        )
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_FLUJO_APROBACION",SqlDbType.UniqueIdentifier) { Value = codigoFlujoAprobacion},
                new SqlParameter("USUARIO_MODIFICACION",SqlDbType.NVarChar) { Value = entornoActualAplicacion.UsuarioSession},
                new SqlParameter("TERMINAL_MODIFICACION",SqlDbType.NVarChar) { Value = entornoActualAplicacion.Terminal}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_INDICADOR_NUMERO_CONTRATO_UPD", parametros);
            return result;
        }

        /// <summary>
        /// Desplaza orden de registro
        /// </summary>
        /// <param name="entidad">Entidad</param>
        /// <param name="flagRegistrarregistrar">Flag registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int DesplazarOrden(FlujoAprobacionEstadioEntity entidad, string flagRegistrar)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_FLUJO_APROBACION_ESTADIO",SqlDbType.UniqueIdentifier) { Value = entidad.CodigoFlujoAprobacionEstadio},
                new SqlParameter("CODIGO_FLUJO_APROBACION",SqlDbType.UniqueIdentifier) { Value = entidad.CodigoFlujoAprobacion },
                new SqlParameter("ORDEN",SqlDbType.TinyInt) { Value = entidad.Orden},
                new SqlParameter("USUARIO_PROCESO",SqlDbType.NVarChar) { Value = entornoActualAplicacion.UsuarioSession },
                new SqlParameter("TERMINAL_PROCESO",SqlDbType.NVarChar) { Value = entornoActualAplicacion.Terminal },
                new SqlParameter("ACCION",SqlDbType.NVarChar) { Value = flagRegistrar }
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_FLUJO_APROBACION_ESTADIO_PRE_INS_UDP", parametros);
            return result;
        }
    }
}

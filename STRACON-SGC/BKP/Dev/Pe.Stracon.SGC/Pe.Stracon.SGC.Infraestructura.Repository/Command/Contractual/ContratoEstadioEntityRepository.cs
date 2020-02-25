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
    /// Implementación del Repositorio de Contrato Estadio
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150529 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ContratoEstadioEntityRepository : ComandRepository<ContratoEstadioEntity>, IContratoEstadioEntityRepository
    {
        /// <summary>
        /// Interfaz para el manejo de auditoría
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        /// <summary>
        /// Realiza la inserción de registros de Contrato Estadio
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operacion</returns>
        public int RegistrarContratoEstadio(ContratoEstadioEntity data)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_ESTADIO",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContratoEstadio ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_FLUJO_APROBACION_ESTADIO",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoFlujoAprobacionEstadio ?? DBNull.Value},
                new SqlParameter("FECHA_INGRESO",SqlDbType.DateTime) { Value = (object)data.FechaIngreso ?? DBNull.Value},
                new SqlParameter("FECHA_FINALIZACION",SqlDbType.DateTime) { Value = (object)data.FechaFinalizacion ?? DBNull.Value},
                new SqlParameter("CODIGO_RESPONSABLE",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoResponsable ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADO_CONTRATO_ESTADIO",SqlDbType.NVarChar) { Value = (object)data.CodigoEstadoContratoEstadio ?? DBNull.Value},
                new SqlParameter("FECHA_PRIMERA_NOTIFICACION",SqlDbType.DateTime) { Value = (object)data.FechaPrimeraNotificacion ?? DBNull.Value},
                new SqlParameter("FECHA_ULTIMA_NOTIFICACION",SqlDbType.DateTime) { Value = (object)data.FechaUltimaNotificacion ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char){Value = (object)DatosConstantes.EstadoRegistro.Activo ?? DBNull.Value},
                new SqlParameter("USUARIO_CREACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.UsuarioSession ?? DBNull.Value},
                new SqlParameter("FECHA_CREACION",SqlDbType.DateTime) { Value = (object)data.FechaCreacion ?? DBNull.Value},
                new SqlParameter("TERMINAL_CREACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.Terminal ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_CONTRATO_ESTADIO_INS", parametros);
            return result;
        }
    }
}

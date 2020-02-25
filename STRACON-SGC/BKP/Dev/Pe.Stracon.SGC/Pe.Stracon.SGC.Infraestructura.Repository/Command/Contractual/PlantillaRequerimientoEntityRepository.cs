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
    /// Implementación del Repositorio de Plantilla
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150519 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class PlantillaRequerimientoEntityRepository : ComandRepository<PlantillaRequerimientoEntity>, IPlantillaRequerimientoEntityRepository
                                         
    {
        /// <summary>
        /// Interfaz para el manejo de auditoría
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        /// <summary>
        /// Realiza la actualización del Estado de Vigencia de la Plantilla
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int ActualizarPlantillaEstadoVigencia()
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("USUARIO_MODIFICACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.UsuarioSession ?? DBNull.Value},
                new SqlParameter("TERMINAL_MODIFICACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.Terminal ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_PLANTILLA_REQUERIMIENTO_VIGENCIA_UPD", parametros);
            return result;
        }

        /// <summary>
        /// Copia una plantilla
        /// </summary>
        /// <param name="codigoPlantillaCopiar">Código de la plantilla a copiar</param>
        /// <param name="descripcion">Descripción de la nueva plantilla</param>
        /// <param name="fechaInicioVigencia">Fecha de inicio de vigencia</param>
        /// <param name="usuarioCreacion">Usuario de creación</param>
        /// <param name="terminalCreacion">Terminal de creación</param>
        /// <returns></returns>
        public int CopiarPlantilla(Guid codigoPlantillaCopiar, string descripcion, DateTime fechaInicioVigencia, string usuarioCreacion, string terminalCreacion)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PLANTILLA_COPIAR",SqlDbType.UniqueIdentifier) { Value = (object)codigoPlantillaCopiar ?? DBNull.Value},
                new SqlParameter("DESCRIPCION",SqlDbType.NVarChar) { Value = (object)descripcion ?? DBNull.Value},             
                new SqlParameter("FECHA_INICIO_VIGENCIA",SqlDbType.DateTime) { Value = (object)fechaInicioVigencia ?? DBNull.Value},
                new SqlParameter("USUARIO_CREACION",SqlDbType.NVarChar) { Value = (object)usuarioCreacion ?? DBNull.Value},
                new SqlParameter("TERMINAL_CREACION",SqlDbType.NVarChar) { Value = (object)terminalCreacion ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_COPIAR_PLANTILLA", parametros);
            return result;
        }

    }
}

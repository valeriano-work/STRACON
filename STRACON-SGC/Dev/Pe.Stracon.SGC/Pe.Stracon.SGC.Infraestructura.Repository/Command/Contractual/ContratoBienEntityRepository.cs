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
    /// Implementación del Repositorio de Contrato Bien
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150803 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ContratoBienEntityRepository : ComandRepository<ContratoBienEntity>, IContratoBienEntityRepository
    {
        /// <summary>
        /// Interfaz para el manejo de auditoría
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        /// <summary>
        /// Realiza la inserción de registros de Contrato Bien
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int RegistrarContratoBien(ContratoBienEntity data)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_BIEN",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContratoBien ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_BIEN",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoBien ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char){Value = (object)DatosConstantes.EstadoRegistro.Activo ?? DBNull.Value},
                new SqlParameter("USUARIO_CREACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.UsuarioSession ?? DBNull.Value},
                new SqlParameter("FECHA_CREACION",SqlDbType.DateTime) { Value = (object)data.FechaCreacion ?? DBNull.Value},
                new SqlParameter("TERMINAL_CREACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.Terminal ?? DBNull.Value},
                //INICIO: Agregado por Julio Carrera - Norma Contable
                new SqlParameter("TIPO_TARIFA",SqlDbType.Char) { Value = (object)data.CodigoTipoTarifa ?? DBNull.Value},
                new SqlParameter("TIPO_PERIODO",SqlDbType.Char) { Value = (object)data.CodigoTipoPeriodo ?? DBNull.Value},
                new SqlParameter("HORAS_MINIMAS",SqlDbType.Int) { Value = (object)data.HorasMinimas ?? DBNull.Value},
                new SqlParameter("TARIFA",SqlDbType.Decimal) { Value = (object)data.Tarifa ?? DBNull.Value},
                new SqlParameter("MAYORMENOR",SqlDbType.VarChar) { Value = (object)data.MayorMenor ?? DBNull.Value},
                //FIN: Agregado por Julio Carrera - Norma Contable
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_CONTRATO_BIEN_INS", parametros);
            return result;
        }
    }
}

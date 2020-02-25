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
    /// Implementación del Repositorio de Contrato Párrafo Variable
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150612 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ContratoParrafoVariableEntityRepository : ComandRepository<ContratoParrafoVariableEntity>, IContratoParrafoVariableEntityRepository
    {
        /// <summary>
        /// Interfaz para el manejo de auditoría
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        /// <summary>
        /// Realiza la inserción de registros de Contrato Párrafo Variable
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int RegistrarContratoParrafoVariable(ContratoParrafoVariableEntity data)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_PARRAFO_VARIABLE",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContratoParrafoVariable ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO_PARRAFO",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContratoParrafo ?? DBNull.Value},
                new SqlParameter("CODIGO_VARIABLE",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoVariable ?? DBNull.Value},
                new SqlParameter("VALOR_TEXTO",SqlDbType.NVarChar) { Value = (object)data.ValorTexto ?? DBNull.Value},
                new SqlParameter("VALOR_NUMERO", SqlDbType.Decimal) { Value = (object)data.ValorNumero ?? DBNull.Value},
                new SqlParameter("VALOR_FECHA", SqlDbType.DateTime) { Value = (object)data.ValorFecha ?? DBNull.Value},
                new SqlParameter("VALOR_IMAGEN", SqlDbType.VarBinary) { Value = (object)data.ValorImagen ?? DBNull.Value},
                new SqlParameter("VALOR_TABLA",SqlDbType.NVarChar) { Value = (object)data.ValorTabla ?? DBNull.Value},
                new SqlParameter("VALOR_TABLA_EDITABLE",SqlDbType.NVarChar) { Value = (object)data.ValorTablaEditable ?? DBNull.Value},
                new SqlParameter("VALOR_BIEN",SqlDbType.NVarChar) { Value = (object)data.ValorBien ?? DBNull.Value},
                new SqlParameter("VALOR_BIEN_EDITABLE",SqlDbType.NVarChar) { Value = (object)data.ValorBienEditable ?? DBNull.Value},
                new SqlParameter("VALOR_FIRMANTE",SqlDbType.NVarChar) { Value = (object)data.ValorFirmante ?? DBNull.Value},
                new SqlParameter("VALOR_FIRMANTE_EDITABLE",SqlDbType.NVarChar) { Value = (object)data.ValorFirmanteEditable ?? DBNull.Value},
                new SqlParameter("VALOR_LISTA",SqlDbType.UniqueIdentifier) { Value = (object)data.ValorLista ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char){Value = (object)DatosConstantes.EstadoRegistro.Activo ?? DBNull.Value},
                new SqlParameter("USUARIO_CREACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.UsuarioSession ?? DBNull.Value},
                new SqlParameter("FECHA_CREACION",SqlDbType.DateTime) { Value = (object)data.FechaCreacion ?? DBNull.Value},
                new SqlParameter("TERMINAL_CREACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.Terminal ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_CONTRATO_PARRAFO_VARIABLE_INS", parametros);
            return result;
        }
    }
}

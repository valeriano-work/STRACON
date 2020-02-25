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
    /// Implementación del Repositorio de Contrato 
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150527 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ContratoEntityRepository : ComandRepository<ContratoEntity>, IContratoEntityRepository
    {
        /// <summary>
        /// Interfaz para el manejo de auditoría
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        /// <summary>
        /// Realiza la inserción de contratos
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int RegistrarContrato(ContratoEntity data)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoUnidadOperativa ?? DBNull.Value},
                new SqlParameter("CODIGO_PROVEEDOR",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoProveedor ?? DBNull.Value},
                new SqlParameter("NUMERO_CONTRATO",SqlDbType.NVarChar) { Value = (object)data.NumeroContrato ?? DBNull.Value},
                new SqlParameter("DESCRIPCION",SqlDbType.NVarChar) { Value = (object)data.Descripcion ?? DBNull.Value},
                new SqlParameter("NUMERO_ADENDA",SqlDbType.NVarChar) { Value = (object)data.NumeroAdenda ?? DBNull.Value},
                new SqlParameter("NUMERO_ADENDA_CONCATENADO",SqlDbType.NVarChar) { Value = (object)data.NumeroAdendaConcatenado ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_SERVICIO",SqlDbType.NVarChar) { Value = (object)data.CodigoTipoServicio ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_REQUERIMIENTO",SqlDbType.NVarChar) { Value = (object)data.CodigoTipoRequerimiento ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)data.CodigoTipoDocumento ?? DBNull.Value},
                new SqlParameter("INDICADOR_VERSION_OFICIAL",SqlDbType.Bit) { Value = (object)data.IndicadorVersionOficial ?? DBNull.Value},
                new SqlParameter("FECHA_INICIO_VIGENCIA",SqlDbType.DateTime) { Value = (object)data.FechaInicioVigencia ?? DBNull.Value},
                new SqlParameter("FECHA_FIN_VIGENCIA",SqlDbType.DateTime) { Value = (object)data.FechaFinVigencia ?? DBNull.Value},
                new SqlParameter("CODIGO_MONEDA",SqlDbType.NVarChar) { Value = (object)data.CodigoMoneda ?? DBNull.Value},
                new SqlParameter("MONTO_CONTRATO",SqlDbType.Decimal) { Value = (object)data.MontoContrato ?? DBNull.Value},
                new SqlParameter("MONTO_ACUMULADO",SqlDbType.Decimal) { Value = (object)data.MontoAcumulado ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADO", SqlDbType.NVarChar){Value = (object)data.CodigoEstado ?? DBNull.Value},
                new SqlParameter("CODIGO_PLANTILLA", SqlDbType.UniqueIdentifier){Value = (object)data.CodigoPlantilla ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO_PRINCIPAL",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContratoPrincipal ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADO_EDICION", SqlDbType.NVarChar){Value = (object)data.CodigoEstadoEdicion ?? DBNull.Value},
                new SqlParameter("COMENTARIO_MODIFICACION", SqlDbType.VarChar){Value = (object)data.ComentarioModificacion ?? DBNull.Value},
                new SqlParameter("RESPUESTA_MODIFICACION", SqlDbType.NVarChar){Value = (object)data.RespuestaModificacion ?? DBNull.Value},
                new SqlParameter("CODIGO_FLUJO_APROBACION", SqlDbType.UniqueIdentifier){Value = (object)data.CodigoFlujoAprobacion ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADIO_ACTUAL", SqlDbType.UniqueIdentifier){Value = (object)data.CodigoEstadioActual ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO", SqlDbType.Char){Value = (object)DatosConstantes.EstadoRegistro.Activo ?? DBNull.Value},
                new SqlParameter("USUARIO_CREACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.UsuarioSession ?? DBNull.Value},
                new SqlParameter("FECHA_CREACION",SqlDbType.DateTime) { Value = (object)data.FechaCreacion ?? DBNull.Value},
                new SqlParameter("TERMINAL_CREACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.Terminal ?? DBNull.Value},
                new SqlParameter("ES_FLEXIBLE",SqlDbType.Bit) { Value = (object)data.EsFlexible ?? DBNull.Value},
                new SqlParameter("ES_CORPORATIVO",SqlDbType.Bit) { Value = (object)data.EsCorporativo ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO_ORIGINAL",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContratoOriginal ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_CONTRATO_INS", parametros);
            return result;
        }

        /// <summary>
        /// Realiza la edición de un contrato
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int EditarContrato(ContratoEntity data)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADO", SqlDbType.NVarChar){Value = (object)data.CodigoEstado ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADO_EDICION", SqlDbType.NVarChar){Value = (object)data.CodigoEstadoEdicion ?? DBNull.Value},
                new SqlParameter("NUMERO_CONTRATO", SqlDbType.NVarChar){Value = (object)data.NumeroContrato ?? DBNull.Value},
                new SqlParameter("COMENTARIO_MODIFICACION", SqlDbType.VarChar){Value = (object)data.ComentarioModificacion ?? DBNull.Value},
                new SqlParameter("USUARIO_MODIFICACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.UsuarioSession ?? DBNull.Value},
                new SqlParameter("FECHA_MODIFICACION",SqlDbType.DateTime) { Value = (object)data.FechaModificacion ?? DBNull.Value},
                new SqlParameter("TERMINAL_MODIFICACION",SqlDbType.NVarChar) { Value = (object)entornoActualAplicacion.Terminal ?? DBNull.Value},
                new SqlParameter("ES_FLEXIBLE",SqlDbType.Bit) { Value = (object)data.EsFlexible ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_CONTRATO_UPD", parametros);
            return result;
        }

        /// <summary>
        /// Metodo para consultar si el numero de contrato ya existe.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public int ConsultaNumeroContrato(ContratoEntity data)
        {
            //int valorNumero = 0;

            //SqlParameter[] parametros = new SqlParameter[]
            //{
            //    new SqlParameter("NUMERO_CONTRATO", SqlDbType.NVarChar) {Value = (object)data.NumeroContrato ?? DBNull.Value},
            //    new SqlParameter("VALOR_NUMERO",SqlDbType.Int)          { Value = (object)valorNumero ?? DBNull.Value},
            //};

            //this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_NUMERO_CONTRATO_VALIDA_SEL", parametros);
            //var result = Convert.ToInt32(valorNumero);
            //return result;


            int valorNumero = 0;
            SqlParameter pIdUsuario = new SqlParameter("@VALOR_NUMERO", valorNumero);
            pIdUsuario.Direction = System.Data.ParameterDirection.Output;

            this.dataBaseProvider.ExecuteStoreProcedureNonQuery("EXEC CTR.USP_NUMERO_CONTRATO_VALIDA_SEL @NUMERO_CONTRATO, @VALOR_NUMERO output"
                , new SqlParameter("NUMERO_CONTRATO", data.NumeroContrato)
                , pIdUsuario
            );

            var result = Convert.ToInt32(pIdUsuario.Value);
            return result;

        }


        public int Actualizar_Flujo_Contrato_Estadio(ContratoEntity data)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_FLUJO_APROBACION", SqlDbType.UniqueIdentifier){Value = (object)data.CodigoFlujoAprobacion ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADIO_ACTUAL", SqlDbType.UniqueIdentifier){Value = (object)data.CodigoEstadioActual ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_ACTUALIZAR_FLUJO_APROBACION_ESTADIO", parametros);
            return result;
        }

    }
}

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
    public class FlujoAprobacionLogicRepository : QueryRepository<FlujoAprobacionLogic>, IFlujoAprobacionLogicRepository
    {
        /// <summary>
        /// Realiza la búsqueda de Flujo Aprobacion
        /// </summary>
        /// <param name="codigoFlujoAprobacion">codigo Flujo Aprobacion</param>
        /// <param name="codigoUnidadOperativa">codigo Unidad Operativa</param>
        /// <param name="codigoFormaEdicion"><codigo Forma Edicion/param>
        /// <param name="codigoTipoRequerimiento">codigo Tipo Requerimiento</param>
        /// <param name="estadoRegistro">estado Registro</param>
        /// <returns>registros Flujo aprobacion con los datos de busqueda</returns>
        public List<FlujoAprobacionLogic> BuscarBandejaFlujoAprobacion(
            Guid? codigoFlujoAprobacion,
            Guid? codigoUnidadOperativa,
            bool? indicadorAplicaMontoMinimo,
            string estadoRegistro
        )
        {

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_FLUJO_APROBACION",SqlDbType.UniqueIdentifier) { Value = (object)codigoFlujoAprobacion ?? DBNull.Value},
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value},
                new SqlParameter("INDICADOR_APLICA_MONTO_MINIMO",SqlDbType.Bit) { Value = (object)indicadorAplicaMontoMinimo ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO",SqlDbType.NVarChar) { Value = (object)estadoRegistro ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<FlujoAprobacionLogic>("CTR.USP_FLUJO_APROBACION_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Realiza la búsqueda de Flujo Aprobacion Estadio
        /// </summary>
        /// <param name="codigoFlujoAprobacionEstadio">Codigo Flujo Aprobacion Estadio</param>
        /// <param name="codigoFlujoAprobacion">Codigo Flujo Aprobacion</param>
        /// <returns>registros Flujo aprobacion con los datos de busqueda</returns>
        public List<FlujoAprobacionEstadioLogic> BuscarBandejaFlujoAprobacionEstadio(
            Guid? codigoFlujoAprobacionEstadio,
            Guid? codigoFlujoAprobacion
        )
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_FLUJO_APROBACION_ESTADIO",SqlDbType.UniqueIdentifier) { Value = (object)codigoFlujoAprobacionEstadio ?? DBNull.Value},
                new SqlParameter("CODIGO_FLUJO_APROBACION",SqlDbType.UniqueIdentifier) { Value = (object)codigoFlujoAprobacion ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<FlujoAprobacionEstadioLogic>("CTR.USP_FLUJO_APROBACION_ESTADIO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Elimina Participante 
        /// </summary>
        /// <param name="codigoFlujoAprobacionEstadio">codigo Flujo Aprobacion Estadio</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int EliminaParticipante(
            Guid codigoFlujoAprobacionEstadio
        )
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_FLUJO_APROBACION_ESTADIO",SqlDbType.UniqueIdentifier) { Value = (object)codigoFlujoAprobacionEstadio ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_FLUJO_APROBACION_PARTICIPANTE_DEL", parametros);
            return result;
        }

        /// <summary>
        /// Valida Registro o edicion de campo Orden
        /// </summary>
        /// <param name="CodigoFlujoAprobacion">Codigo Flujo Aprobacion</param>
        /// <param name="orden">orden</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public List<FlujoAprobacionEstadioLogic> RepiteFlujoAprobacionEstadioOrden(
            Guid CodigoFlujoAprobacion,
            byte orden
        )
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_FLUJO_APROBACION",SqlDbType.UniqueIdentifier) { Value = (object)CodigoFlujoAprobacion ?? DBNull.Value},
                new SqlParameter("ORDEN",SqlDbType.TinyInt) { Value = (object)orden ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<FlujoAprobacionEstadioLogic>("CTR.USP_FLUJO_APROBACION_ESTADIO_ORDEN_EXISTE_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Valida Registro o edicion de campo Descripcion
        /// </summary>
        /// <param name="CodigoFlujoAprobacion">Codigo Flujo Aprobacion</param>
        /// <param name="descripcion">descripcion</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public List<FlujoAprobacionEstadioLogic> RepiteFlujoAprobacionEstadioDescripcion(
            Guid CodigoFlujoAprobacion,
            string descripcion
        )
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_FLUJO_APROBACION",SqlDbType.UniqueIdentifier) { Value = (object)CodigoFlujoAprobacion ?? DBNull.Value},
                new SqlParameter("DESCRIPCION",SqlDbType.NVarChar) { Value = (object)descripcion ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<FlujoAprobacionEstadioLogic>("CTR.USP_FLUJO_APROBACION_ESTADIO_DESCRIPCION_EXISTE_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Copia estadios
        /// </summary>
        /// <param name="codigoFlujoAprobacionHasta">codigo Flujo Aprobacion Hasta</param>
        /// <param name="codigoFlujoAprobacionADesde">codigo Flujo AprobacionA Desde</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int CopiarEstadio(
            Guid codigoFlujoAprobacionHasta,
            Guid codigoFlujoAprobacionADesde,
            string usuario,
            string terminal
        )
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_FLUJO_APROBACION_ORIGEN",SqlDbType.UniqueIdentifier) { Value = codigoFlujoAprobacionADesde},
                new SqlParameter("CODIGO_FLUJO_APROBACION_DESTINO",SqlDbType.UniqueIdentifier) { Value = codigoFlujoAprobacionHasta},
                new SqlParameter("USUARIO",SqlDbType.NVarChar) { Value = usuario},
                new SqlParameter("TERMINAL",SqlDbType.NVarChar) { Value = terminal}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_COPIAR_ESTADIOS", parametros);
            return result;
        }

        /// <summary>
        /// Realiza la búsqueda de Flujo Aprobación Tipo de Servicio
        /// </summary>
        /// <param name="codigoFlujoAprobacionTipoServicio">Código Flujo Aprobación Tipo de Servicio</param>
        /// <param name="codigoFlujoAprobacion">Código de Flujo de Aprobación</param>
        /// <param name="codigoTipoServicio">Código de Tipo de Servicio</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista de Flujo Aprobación Tipo de Servicio</returns>
        public List<FlujoAprobacionTipoServicioLogic> BuscarFlujoAprobacionTipoServicio(
            Guid? codigoFlujoAprobacionTipoServicio,
            Guid? codigoFlujoAprobacion,
            string codigoTipoServicio,
            string estadoRegistro
        )
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_FLUJO_APROBACION_TIPO_SERVICIO",SqlDbType.UniqueIdentifier)    { Value = (object)codigoFlujoAprobacionTipoServicio ?? DBNull.Value},
                new SqlParameter("CODIGO_FLUJO_APROBACION",SqlDbType.UniqueIdentifier)                  { Value = (object)codigoFlujoAprobacion ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_SERVICIO",SqlDbType.NVarChar)                             { Value = (object)codigoTipoServicio ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO",SqlDbType.Char)                                      { Value = (object)estadoRegistro ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<FlujoAprobacionTipoServicioLogic>("CTR.USP_FLUJO_APROBACION_TIPO_SERVICIO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Realiza la búsqueda de Flujo Aprobacion Participante
        /// </summary>
        /// <param name="CodigoFlujoAprobacion">Codigo Flujo Aprobacion</param>
        /// <returns>registros Flujo aprobacion con los datos de busqueda</returns>
        public List<FlujoAprobacionParticipanteLogic> BuscarFlujoAprobacionParticipante(
            Guid? codigoFlujoAprobacion
        )
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_FLUJO_APROBACION",SqlDbType.UniqueIdentifier) { Value = (object)codigoFlujoAprobacion ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<FlujoAprobacionParticipanteLogic>("CTR.USP_FLUJO_APROBACION_PARTICIPANTE_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Realiza la búsqueda de Estadios de Flujo de Aprobación Estadio
        /// </summary>
        /// <param name="descripcion">Descripción de Estadio</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista de Estadios de Flujo de Aprobación Estadio</returns>
        public List<FlujoAprobacionEstadioLogic> BuscarFlujoAprobacionEstadioDescripcion(
            string descripcion,
            string estadoRegistro)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("DESCRIPCION",SqlDbType.NVarChar) { Value = (object)descripcion ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO",SqlDbType.Char) { Value = (object)estadoRegistro ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<FlujoAprobacionEstadioLogic>("CTR.USP_FLUJO_APROBACION_ESTADIO_DESCRIPCION_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Actualiza el reemplazo al trabajador original
        /// </summary>
        /// <param name="codigoTrabajador">Codigo de trabajador</param>
        public void ActualizarTrabajadorOriginalFlujo(Guid codigoTrabajador)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_TRABAJADOR",SqlDbType.UniqueIdentifier) { Value = (object)codigoTrabajador ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<int>("CTR.USP_FLUJO_APROBACION_PARTICIPANTE2_DTS_UPD", parametros).ToList();
        }

        /// <summary>
        /// Realiza la búsqueda de Flujo Aprobación Tipo de Contrato
        /// </summary>
        /// <param name="codigoFlujoAprobacionTipoContrato">Código Flujo Aprobación Tipo de contrato</param>
        /// <param name="codigoFlujoAprobacion">Código de Flujo de Aprobación</param>
        /// <param name="codigoTipoContrato">Código de Tipo de Contrato</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista de Flujo Aprobación Tipo de Contrato</returns>
        public List<FlujoAprobacionTipoContratoLogic> BuscarFlujoAprobacionTipoContrato(
            Guid? codigoFlujoAprobacionTipoContrato,
            Guid? codigoFlujoAprobacion,
            string codigoTipoContrato,
            string estadoRegistro
        )
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_FLUJO_APROBACION_TIPO_CONTRATO",SqlDbType.UniqueIdentifier)    { Value = (object)codigoFlujoAprobacionTipoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_FLUJO_APROBACION",SqlDbType.UniqueIdentifier)                  { Value = (object)codigoFlujoAprobacion ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_CONTRATO",SqlDbType.NVarChar)                             { Value = (object)codigoTipoContrato ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO",SqlDbType.Char)                                      { Value = (object)estadoRegistro ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<FlujoAprobacionTipoContratoLogic>("CTR.USP_FLUJO_APROBACION_TIPO_CONTRATO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Obtener el responsable del siguiente estadio de flujo de aprobación
        /// </summary>
        /// <param name="codigoFlujoAprobacion">Codigo Flujo Aprobacion</param>
        /// <param name="orden">orden</param>        
        /// <param name="codigoFlujoAprobacionEstadio">Código flujo de aprobación estadio</param>
        /// <param name="codigoContratoEstadio">Código contrato estadio</param>
        /// <returns>Código de responsable</returns>
        public Guid ObtenerResponsableSiguienteEstadioFlujoAprobacion(
            Guid codigoFlujoAprobacion,
            byte orden, 
            Guid codigoFlujoAprobacionEstadio,
            Guid codigoContratoEstadio
        )
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_FLUJO_APROBACION",SqlDbType.UniqueIdentifier) { Value = (object)codigoFlujoAprobacion ?? DBNull.Value},
                new SqlParameter("ORDEN",SqlDbType.TinyInt) { Value = (object)orden ?? DBNull.Value},
                new SqlParameter("CODIGO_FLUJO_APROBACION_ESTADIO",SqlDbType.UniqueIdentifier) { Value = (object)codigoFlujoAprobacionEstadio ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO_ESTADIO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContratoEstadio ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<Guid>("CTR.USP_FLUJO_APROBACION_PARTICIPANTE_OBTENER_RESPONSABLE_SIGUIENTE_ESTADIO", parametros).FirstOrDefault();
            return result;
        }
    }
}

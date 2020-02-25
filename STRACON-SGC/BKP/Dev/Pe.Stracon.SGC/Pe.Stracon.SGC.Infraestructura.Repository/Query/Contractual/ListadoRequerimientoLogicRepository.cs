using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Pe.Stracon.SGC.Cross.Core.Extension;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Query.Contractual
{
    /// <summary>
    /// Implementación del repositorio Requerimiento
    /// </summary>
    public class ListadoRequerimientoLogicRepository : QueryRepository<ListadoRequerimientoLogic>, IListadoRequerimientoLogicRepository
    {
        /// <summary>
        /// Realiza la búsqueda de Requerimientos
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento</param>
        /// <param name="codigoUnidadOperativa">Código de unidad operativa</param>
        /// <param name="codigoPlantilla">Código de plantilla</param>
        /// <param name="codigoTipoServicio">Código de Tipo de Servicio</param>
        /// <param name="codigoTipoRequerimiento">Código de Tipo de Requerimiento</param>
        /// <param name="codigoTipoDocumento">Código de Tipo de Documento</param>
        /// <param name="codigoEstadoVigencia">Código de Estado de Vigencia</param>
        /// <param name="numeroRequerimiento">Número de Requerimiento</param>
        /// <param name="numeroAdendaConcatenado">Número de adenda concatenado</param>
        /// <param name="numeroDocumento">Número de Documento</param>
        /// <param name="nombreProveedor">Nombre de Proveedor</param>
        /// <param name="descripcion">Descripción de Requerimiento</param>
        /// <param name="indicadorTodaUnidadOperativa">Indicador toda unidad operativa</param>
        /// <param name="listaUnidadOperativaAcceso">Lista de unidades operativas en acceso</param>
        /// <param name="codigoEstadoEdicion">Estado de Edición</param>
        /// <param name="codigoTrabajadorResponsable">Código de Trabajador Responsable</param>
        /// <param name="nombreEstadio">Nombre de Estadio</param>
        /// <param name="indicadorFinalizarAprobacion">Indicador de Finalizar Aprobación</param>
        /// <param name="numeroPagina">Total de Páginas</param>
        /// <param name="registroPagina">Total de Registros por Página</param>
        /// <returns>Lista de contratos</returns>
        public List<ListadoRequerimientoLogic> BuscarListadoRequerimiento(
            Guid? codigoRequerimiento,
            Guid? codigoUnidadOperativa,
            Guid? codigoPlantilla,
            string codigoTipoServicio,
            string codigoTipoRequerimiento,
            string codigoTipoDocumento,
            string codigoEstadoVigencia,
            string numeroRequerimiento,
            string numeroAdendaConcatenado,
            string numeroDocumento,
            string nombreProveedor,
            string descripcion,
            bool? indicadorTodaUnidadOperativa,
            List<Guid?> listaUnidadOperativaAcceso,
            string codigoEstadoEdicion,
            string descripcionRequerimiento,
            Guid? codigoTrabajadorResponsable,
            string nombreEstadio,
            string indicadorFinalizarAprobacion,
            int numeroPagina,
            int registroPagina)
        {

            var lista = (listaUnidadOperativaAcceso != null) ? listaUnidadOperativaAcceso.Select(c => new { CODIGO = c }).ToList() : null;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoRequerimiento ?? DBNull.Value},
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value},
                new SqlParameter("CODIGO_PLANTILLA",SqlDbType.UniqueIdentifier) { Value = (object)codigoPlantilla ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_SERVICIO",SqlDbType.NVarChar) { Value = (object)codigoTipoServicio ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_REQUERIMIENTO",SqlDbType.NVarChar) { Value = (object)codigoTipoRequerimiento ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)codigoTipoDocumento ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADO",SqlDbType.NVarChar) { Value = (object)codigoEstadoVigencia ?? DBNull.Value},
                new SqlParameter("NUMERO_CONTRATO",SqlDbType.NVarChar) { Value = (object)numeroRequerimiento ?? DBNull.Value},
                new SqlParameter("NUMERO_ADENDA_CONCATENADO",SqlDbType.NVarChar) { Value = (object)numeroAdendaConcatenado ?? DBNull.Value},
                new SqlParameter("NUMERO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)numeroDocumento ?? DBNull.Value},
                new SqlParameter("NOMBRE",SqlDbType.NVarChar) { Value = (object)nombreProveedor ?? DBNull.Value},
                new SqlParameter("DESCRIPCION",SqlDbType.NVarChar) { Value = (object)descripcion ?? DBNull.Value},
                new SqlParameter("INDICADOR_TODA_UNIDAD_OPERATIVA",SqlDbType.Bit) { Value = (object)indicadorTodaUnidadOperativa ?? DBNull.Value},
                new SqlParameter("LISTA_UNIDAD_OPERATIVA_ACCESO",SqlDbType.Structured) {Value = ((lista != null) ? lista.ToDataTable() : null), TypeName = "CTR.LISTA_GUID"},
                new SqlParameter("CODIGO_ESTADO_EDICION",SqlDbType.NVarChar) { Value = (object)codigoEstadoEdicion ?? DBNull.Value},
                new SqlParameter("CONTENIDO_CONTRATO",SqlDbType.NVarChar) { Value = (object)descripcionRequerimiento ?? DBNull.Value},
                new SqlParameter("CODIGO_TRABAJADOR_RESPONSABLE",SqlDbType.UniqueIdentifier) { Value = (object)codigoTrabajadorResponsable ?? DBNull.Value},
                new SqlParameter("NOMBRE_ESTADIO",SqlDbType.NVarChar) { Value = (object)nombreEstadio ?? DBNull.Value},
                new SqlParameter("INDICADOR_FINALIZAR_APROBACION",SqlDbType.NVarChar) { Value = (object)indicadorFinalizarAprobacion ?? DBNull.Value},
                new SqlParameter("PageNo",SqlDbType.Int) { Value = (object)numeroPagina ?? DBNull.Value},
                new SqlParameter("PageSize",SqlDbType.BigInt) { Value = (object)registroPagina ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<ListadoRequerimientoLogic>("CTR.USP_CONTRATO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoRequerimiento"></param>
        /// <param name="codigoUnidadOperativa"></param>
        /// <param name="codigoPlantilla"></param>
        /// <param name="codigoTipoServicio"></param>
        /// <param name="codigoTipoRequerimiento"></param>
        /// <param name="codigoTipoDocumento"></param>
        /// <param name="codigoEstadoVigencia"></param>
        /// <param name="numeroRequerimiento"></param>
        /// <param name="numeroAdendaConcatenado"></param>
        /// <param name="numeroDocumento"></param>
        /// <param name="nombreProveedor"></param>
        /// <param name="descripcion"></param>
        /// <param name="indicadorTodaUnidadOperativa"></param>
        /// <param name="listaUnidadOperativaAcceso"></param>
        /// <param name="codigoEstadoEdicion"></param>
        /// <param name="descripcionRequerimiento"></param>
        /// <param name="codigoTrabajadorResponsable"></param>
        /// <param name="nombreEstadio"></param>
        /// <param name="indicadorFinalizarAprobacion"></param>
        /// <param name="columnaOrden"></param>
        /// <param name="tipoOrden"></param>
        /// <param name="numeroPagina"></param>
        /// <param name="registroPagina"></param>
        /// <returns></returns>
        public List<ListadoRequerimientoLogic> BuscarListadoRequerimientoOrden(
          Guid? codigoRequerimiento,
          Guid? codigoUnidadOperativa,
          Guid? codigoPlantilla,
          //string codigoTipoServicio,
          //string codigoTipoRequerimiento,
          string codigoTipoDocumento,
          string codigoEstadoVigencia,
          string numeroRequerimiento,
          //string numeroAdendaConcatenado,
          //string numeroDocumento,
          //string nombreProveedor,
          string descripcion,
          bool? indicadorTodaUnidadOperativa,
          List<Guid?> listaUnidadOperativaAcceso,
          string codigoEstadoEdicion,
          string descripcionRequerimiento,
          Guid? codigoTrabajadorResponsable,
          string nombreEstadio,
          string indicadorFinalizarAprobacion,
          decimal? montoAcumuladoInicio,
          decimal? montoAcumuladoFin,
          string codigoMoneda,
          string usuarioCreacion,
          string columnaOrden,
          string tipoOrden,
          int numeroPagina,
          int registroPagina)
        {

            var lista = (listaUnidadOperativaAcceso != null) ? listaUnidadOperativaAcceso.Select(c => new { CODIGO = c }).ToList() : null;

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_REQUERIMIENTO",SqlDbType.UniqueIdentifier) { Value = (object)codigoRequerimiento ?? DBNull.Value},
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value},
                new SqlParameter("CODIGO_PLANTILLA",SqlDbType.UniqueIdentifier) { Value = (object)codigoPlantilla ?? DBNull.Value},
                //new SqlParameter("CODIGO_TIPO_SERVICIO",SqlDbType.NVarChar) { Value = (object)codigoTipoServicio ?? DBNull.Value},
                //new SqlParameter("CODIGO_TIPO_REQUERIMIENTO",SqlDbType.NVarChar) { Value = (object)codigoTipoRequerimiento ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)codigoTipoDocumento ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADO",SqlDbType.NVarChar) { Value = (object)codigoEstadoVigencia ?? DBNull.Value},
                new SqlParameter("NUMERO_REQUERIMIENTO",SqlDbType.NVarChar) { Value = (object)numeroRequerimiento ?? DBNull.Value},
                //new SqlParameter("NUMERO_ADENDA_CONCATENADO",SqlDbType.NVarChar) { Value = (object)numeroAdendaConcatenado ?? DBNull.Value},
                //new SqlParameter("NUMERO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)numeroDocumento ?? DBNull.Value},
                //new SqlParameter("NOMBRE",SqlDbType.NVarChar) { Value = (object)nombreProveedor ?? DBNull.Value},
                new SqlParameter("DESCRIPCION",SqlDbType.NVarChar) { Value = (object)descripcion ?? DBNull.Value},
                new SqlParameter("INDICADOR_TODA_UNIDAD_OPERATIVA",SqlDbType.Bit) { Value = (object)indicadorTodaUnidadOperativa ?? DBNull.Value},
                new SqlParameter("LISTA_UNIDAD_OPERATIVA_ACCESO",SqlDbType.Structured) {Value = ((lista != null) ? lista.ToDataTable() : null), TypeName = "CTR.LISTA_GUID"},
                new SqlParameter("CODIGO_ESTADO_EDICION",SqlDbType.NVarChar) { Value = (object)codigoEstadoEdicion ?? DBNull.Value},
                //new SqlParameter("CONTENIDO_CONTRATO",SqlDbType.NVarChar) { Value = (object)descripcionRequerimiento ?? DBNull.Value},
                new SqlParameter("CODIGO_TRABAJADOR_RESPONSABLE",SqlDbType.UniqueIdentifier) { Value = (object)codigoTrabajadorResponsable ?? DBNull.Value},
                new SqlParameter("NOMBRE_ESTADIO",SqlDbType.NVarChar) { Value = (object)nombreEstadio ?? DBNull.Value},
                new SqlParameter("INDICADOR_FINALIZAR_APROBACION",SqlDbType.NVarChar) { Value = (object)indicadorFinalizarAprobacion ?? DBNull.Value},
                
                new SqlParameter("MONTO_INICIO",SqlDbType.Decimal) { Value = (object)montoAcumuladoInicio ?? DBNull.Value},
                new SqlParameter("MONTO_FIN",SqlDbType.Decimal) { Value = (object)montoAcumuladoFin ?? DBNull.Value},
                new SqlParameter("CODIGO_MONEDA",SqlDbType.NVarChar) { Value = (object)codigoMoneda ?? DBNull.Value},
                
                new SqlParameter("USUARIO_CREACION",SqlDbType.VarChar) { Value = (object)usuarioCreacion ?? DBNull.Value},
                new SqlParameter("COLUMNA_ORDEN",SqlDbType.VarChar) { Value = (object)columnaOrden ?? DBNull.Value},
                new SqlParameter("TIPO_ORDEN",SqlDbType.VarChar) { Value = (object)tipoOrden ?? DBNull.Value},
                new SqlParameter("NUMERO_PAGINA",SqlDbType.Int) { Value = (object)numeroPagina ?? DBNull.Value},
                new SqlParameter("TAMANIO_PAGINA",SqlDbType.BigInt) { Value = (object)registroPagina ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<ListadoRequerimientoLogic>("CTR.USP_REQUERIMIENTO_ORDENADO_SEL", parametros).ToList();
            return result;
        }
        /// <summary>
        /// Realiza la búsqueda de Requerimientos principales
        /// </summary>
        /// <param name="numeroRequerimiento">Número de Requerimiento</param>
        /// <param name="descripcion">Descripción de Requerimiento</param>
        /// <returns>Lista de Requerimientos</returns>
        public List<ListadoRequerimientoLogic> ListadoRequerimientoPrincipal(string numeroRequerimiento, string descripcion, string TipoServicioLC)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("NUMERO_CONTRATO",SqlDbType.NVarChar) { Value = (object)numeroRequerimiento ?? DBNull.Value},
                new SqlParameter("DESCRIPCION",SqlDbType.NVarChar) { Value = (object)descripcion ?? DBNull.Value},
                new SqlParameter("TIPO_SERVICIO_LC",SqlDbType.NVarChar) { Value = (object)TipoServicioLC ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ListadoRequerimientoLogic>("CTR.USP_CONTRATO_PRINCIPAL_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Obtiene el Monto Acumulado del Requerimiento Principal más sus Adendas
        /// </summary>
        /// <param name="codigoRequerimientoPrincipal">Código de Requerimiento Principal</param>
        /// <returns>Registro con el Monto Acumulado del Requerimiento Principal más sus Adendas</returns>
        public List<ListadoRequerimientoLogic> ObtenerMontoAcumuladoRequerimiento(Guid codigoRequerimientoPrincipal)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_PRINCIPAL",SqlDbType.UniqueIdentifier) { Value = (object)codigoRequerimientoPrincipal ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<ListadoRequerimientoLogic>("CTR.USP_CONTRATO_OBTENER_MONTO_ACUMULADO", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Obtiene las variables del parrafo
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Lista de variables de los parrafos de un contrato</returns>
        public List<RequerimientoParrafoVariableLogic> ObtenerVariablesRequerimientoParrafo(Guid codigoRequerimiento)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoRequerimiento ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<RequerimientoParrafoVariableLogic>("CTR.USP_CONTRATO_PARRAFO_VARIABLE_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Obtiene los bienes de un contrato
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Lista de variables de los parrafos de un contrato</returns>
        public List<RequerimientoBienLogic> ObtenerBienesRequerimiento(Guid codigoRequerimiento)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoRequerimiento ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<RequerimientoBienLogic>("CTR.USP_CONTRATO_BIEN_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Obtiene los firmantes de un contrato
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Lista de firmantes de los parrafos de un contrato</returns>
        public List<RequerimientoFirmanteLogic> ObtenerFirmantesRequerimiento(Guid codigoRequerimiento)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoRequerimiento ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<RequerimientoFirmanteLogic>("CTR.USP_CONTRATO_FIRMANTE_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Realiza la búsqueda de Requerimientos sin paginación
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento</param>
        /// <param name="codigoTipoServicio">Código de Tipo de Servicio</param>
        /// <param name="codigoTipoRequerimiento">Código de Tipo de Requerimiento</param>
        /// <param name="codigoTipoDocumento">Código de Tipo de Documento</param>
        /// <param name="codigoEstadoVigencia">Código de Estado de Vigencia</param>
        /// <param name="numeroRequerimiento">Número de Requerimiento</param>
        /// <param name="numeroDocumento">Número de Documento</param>
        /// <param name="nombreProveedor">Nombre de Proveedor</param>
        /// <param name="descripcion">Descripción de Requerimiento</param>
        /// <returns>Lista de contratos</returns>
        public List<ListadoRequerimientoLogic> BuscarRequerimiento(Guid? codigoRequerimiento, Guid? codigoRequerimientoPrincipal, string codigoTipoServicio, string codigoTipoRequerimiento,
                                                                string codigoTipoDocumento, string codigoEstadoVigencia, string numeroRequerimiento,
                                                                string numeroDocumento, string nombreProveedor, string descripcion)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoRequerimiento ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO_PRINCIPAL",SqlDbType.UniqueIdentifier) { Value = (object)codigoRequerimientoPrincipal ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_SERVICIO",SqlDbType.NVarChar) { Value = (object)codigoTipoServicio ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_REQUERIMIENTO",SqlDbType.NVarChar) { Value = (object)codigoTipoRequerimiento ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)codigoTipoDocumento ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADO",SqlDbType.NVarChar) { Value = (object)codigoEstadoVigencia ?? DBNull.Value},
                new SqlParameter("NUMERO_CONTRATO",SqlDbType.NVarChar) { Value = (object)numeroRequerimiento ?? DBNull.Value},
                new SqlParameter("NUMERO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)numeroDocumento ?? DBNull.Value},
                new SqlParameter("NOMBRE",SqlDbType.NVarChar) { Value = (object)nombreProveedor ?? DBNull.Value},
                new SqlParameter("DESCRIPCION",SqlDbType.NVarChar) { Value = (object)descripcion ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<ListadoRequerimientoLogic>("CTR.USP_CONTRATO_NOT_NUMBERED_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Buscar contratos correlativos
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código unidad operativa</param>
        /// <param name="codigoTipoRequerimiento">Código tipo de requerimiento</param>
        /// <param name="codigoTipoDocumento">Código tipo de documento</param>
        /// <returns>Listado de contratos</returns>
        public List<ListadoRequerimientoLogic> BuscarCorrelativoRequerimiento(Guid? codigoUnidadOperativa, string codigoTipoRequerimiento, string codigoTipoDocumento)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_REQUERIMIENTO",SqlDbType.VarChar) { Value = (object)codigoTipoRequerimiento ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_DOCUMENTO",SqlDbType.VarChar) { Value = (object)codigoTipoDocumento ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ListadoRequerimientoLogic>("CTR.USP_CORRELATIVO_CONTRATO_SEL", parametros).ToList();
            return result;
        }

        public List<string> Listar_Requerimiento_Segun_Unidad_Operativa(Guid? codigoUnidadOperativa)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<String>("CTR.USP_OBTENER_TIPO_CONTRATO_SEGUN_UNIDAD_OPERATIVA", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Eliminar un contrato
        /// </summary>
        /// <param name="codigoRequerimiento">Código de contrato</param>     
        /// <param name="motivoEliminacion">Motivo de eliminación</param>
        /// <param name="usuarioSesion">Nombre de usuario</param>
        /// <param name="terminal">Terminal de usuario</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int EliminarRequerimiento(Guid codigoRequerimiento, string motivoEliminacion, string usuarioSesion, string terminal)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoRequerimiento ?? DBNull.Value},             
                new SqlParameter("MOTIVO_ELIMINACION", SqlDbType.VarChar){Value = (object)motivoEliminacion ?? DBNull.Value},
                new SqlParameter("USUARIO_MODIFICACION",SqlDbType.NVarChar) { Value = (object)usuarioSesion ?? DBNull.Value},             
                new SqlParameter("TERMINAL_MODIFICACION",SqlDbType.NVarChar) { Value = (object)terminal ?? DBNull.Value},
             
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_CONTRATO_ELIMINAR_UPD", parametros);
            return result;
        }

    }
}
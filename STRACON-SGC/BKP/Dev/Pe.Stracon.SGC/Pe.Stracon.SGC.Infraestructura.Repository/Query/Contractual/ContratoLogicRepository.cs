using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Query.Contractual
{
    /// <summary>
    /// Implementación del repositorio de Contrato
    /// </summary>  
    public class ContratoLogicRepository : QueryRepository<ContratoLogic>, IContratoLogicRepository
    {
        /// <summary>
        /// Metodo para listar los contrato por usuario.
        /// </summary>
        /// <param name="CodigoResponsable">Codigo de trabajador que consulta</param>
        /// <param name="UnidadOperativa">Código de Unidad Operativa</param>
        /// <param name="NombreProveedor">Nombre del proveedor</param>
        /// <param name="NumdocPrv">Número de documento del proveedor</param>
        /// <param name="TipoServicio">Tipo de Servicio</param>
        /// <param name="TipoReq">Tipo de Requerimiento</param>
        /// <returns>Lista de bandeja de contratos</returns>
        public List<ContratoLogic> ListaBandejaContratos(
            Guid CodigoResponsable,
            Guid? UnidadOperativa,
            string NombreProveedor,
            string NumdocPrv,
            string TipoServicio,
            string TipoReq,
            string nombreEstadio,
            string indicadorFinalizarAprobacion)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CodigoResponsable",SqlDbType.UniqueIdentifier) { Value = (object)CodigoResponsable ?? DBNull.Value},
                new SqlParameter("UnidadOperativa",SqlDbType.UniqueIdentifier) { Value = (object)UnidadOperativa ?? DBNull.Value},
                new SqlParameter("NombreProveedor",SqlDbType.NVarChar) { Value = (object)NombreProveedor ?? DBNull.Value},
                new SqlParameter("NumeroDocumentoPrv",SqlDbType.NVarChar) { Value = (object)NumdocPrv ?? DBNull.Value},
                new SqlParameter("TipoServicio",SqlDbType.NVarChar) { Value = (object)TipoServicio ?? DBNull.Value},
                new SqlParameter("TipoRequerimiento",SqlDbType.NVarChar) { Value = (object)TipoReq ?? DBNull.Value},
                new SqlParameter("NombreEstadio",SqlDbType.NVarChar) { Value = (object)nombreEstadio ?? DBNull.Value},
                new SqlParameter("IndicadorFinalizarAprobacion",SqlDbType.NVarChar) { Value = (object)indicadorFinalizarAprobacion ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoLogic>("CTR.USP_BANDEJA_CONTRATOS_SEL", parametros).ToList();
            return result;
        }


        /// <summary>
        /// Metodo para listar las Observaciones por Contrato por Estadio.
        /// </summary>
        /// <param name="CodigoContratoEstadio">Código de Contrato Estadio</param>
        /// <returns>Lista de bandeja de contratos por observaciones</returns>
        public List<ContratoEstadioObservacionLogic> ListaBandejaContratosObservacion(Guid CodigoContratoEstadio)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CodigoContratoEstadio",SqlDbType.UniqueIdentifier) { Value = (object)CodigoContratoEstadio ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoEstadioObservacionLogic>("CTR.USP_BANDEJA_OBSERVACIONES_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Metodo para listar las Consultas por Contrato por Estadio.
        /// </summary>
        /// <param name="CodigoContratoEstadio">Código de Contrato Estadio</param>
        /// <returns>Lista de consultas por contrato</returns>
        public List<ContratoEstadioConsultaLogic> ListaBandejaContratosConsultas(Guid CodigoContratoEstadio)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CodigoContratoEstadio",SqlDbType.UniqueIdentifier) { Value = (object)CodigoContratoEstadio ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoEstadioConsultaLogic>("CTR.USP_BANDEJA_CONSULTAS_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Método para aprobar cada contrato según su estadío.
        /// </summary>
        /// <param name="codigoContratoEstadio">Código de Contrato Estadío</param>
        /// <param name="codigoIdentificacionUO">Código de Identificación UO</param>
        /// <param name="UserUpdate">Usuario que actualiza</param>
        /// <param name="TerminalUpdate">Terminal desde donde se ejecuta.</param>
        /// <param name="codigoUsuarioCreacionContrato">Código usuario creación de contrato</param>
        /// <param name="MotivoAprobacion"></param>
        /// <returns>Lista de estadios aprobados</returns>
        public int ApruebaContratoEstadio(Guid codigoContratoEstadio, string codigoIdentificacionUO, string UserUpdate, string TerminalUpdate, string codigoUsuarioCreacionContrato, string MotivoAprobacion)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_ESTADIO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContratoEstadio ?? DBNull.Value},
                new SqlParameter("CODIGO_IDENTIFICACION_UO",SqlDbType.NVarChar) { Value = (object)codigoIdentificacionUO ?? DBNull.Value},
                new SqlParameter("USUARIO_CREACION",SqlDbType.NVarChar) { Value = (object)UserUpdate ?? DBNull.Value},
                new SqlParameter("TERMINAL_CREACION",SqlDbType.NVarChar) { Value = (object)TerminalUpdate ?? DBNull.Value},
                new SqlParameter("CodigoUsuarioCreacionContrato",SqlDbType.UniqueIdentifier) { Value = codigoUsuarioCreacionContrato == string.Empty ? (object)Guid.Empty : (object)new Guid(codigoUsuarioCreacionContrato) ?? DBNull.Value},
                new SqlParameter("motivo_aprobacion",SqlDbType.VarChar) { Value = (object)MotivoAprobacion ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<int>("CTR.USP_APRUEBA_CONTRATO_ESTADIO", parametros).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// Método para retornar los párrafos por contrato
        /// </summary>
        /// <param name="CodigoContrato">Código de Contrato</param>
        /// <returns>Parrafos por contrato</returns>
        public List<ContratoParrafoLogic> RetornaParrafosPorContrato(Guid CodigoContrato)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)CodigoContrato ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoParrafoLogic>("CTR.USP_CONTRATO_PARRAFO_SEL", parametros).ToList();
            return result;
        }
        /// <summary>
        /// Método que retorna los estadio del contrato para su observación.
        /// </summary>
        /// <param name="CodigoContratoEstadio">Código del Estadío del Contrato</param>
        /// <returns>Estadios de contrato</returns>
        public List<FlujoAprobacionEstadioLogic> RetornaEstadioContratoObservacion(Guid CodigoContratoEstadio)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CodigoContratoEstadio",SqlDbType.UniqueIdentifier) { Value = (object)CodigoContratoEstadio ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<FlujoAprobacionEstadioLogic>("CTR.USP_ESTADIOS_CONTRATO_OBSERVACION", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Responder la Consulta que me han hecho
        /// </summary>
        /// <param name="codigoContratoEstadioConsulta"></param>
        /// <param name="Respuesta"></param>
        /// <param name="UsuarioModificacion"></param>
        /// <param name="TerminalModificacion"></param>
        /// <returns></returns>
        public int Responder_Consulta(Guid codigoContratoEstadioConsulta,string Respuesta,  string UsuarioModificacion, string TerminalModificacion)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_ESTADIO_CONSULTA",SqlDbType.UniqueIdentifier) { Value = (object)codigoContratoEstadioConsulta ?? DBNull.Value},
                new SqlParameter("RESPUESTA",SqlDbType.VarChar) { Value = (object)Respuesta ?? DBNull.Value},
                new SqlParameter("USUARIO_MODIFICACION",SqlDbType.VarChar) { Value = (object)UsuarioModificacion ?? DBNull.Value},
                new SqlParameter("TERMINAL_MODIFICACION",SqlDbType.VarChar) { Value = (object)TerminalModificacion ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<int>("CTR.USP_RESPONDER_CONSULTA", parametros).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Método para generar un nuevo Estadio de contrato cada vez que es observado.
        /// </summary>
        /// <param name="codigoContratoEstadio"></param>
        /// <param name="codigoContratoEstadioObservado">Código de Contrato Estadio Observado</param>
        /// <param name="codigoContrato"> Código de Contrato </param>
        /// <param name="codigoFlujoEstadioRetorno">Código Flujo Estadio Retorno </param>
        /// <param name="codigoResponsable">Código de Responsable </param>
        /// <param name="UserUpdate">Usuario que actualiza</param>
        /// <param name="TerminalUpdate">Terminal desde donde de actualiza</param>
        /// <returns>Estadios de contrato segun observación</returns>
        public int ObservaEstadioContrato(Guid codigoContratoEstadio, Guid codigoContratoEstadioObservado, Guid codigoContrato, Guid codigoFlujoEstadioRetorno,
                                          Guid codigoResponsable, string UserUpdate, string TerminalUpdate)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_ESTADIO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContratoEstadio ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO_ESTADIO_OBSERVADO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContratoEstadioObservado ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_FLUJO_ESTADIO_RETORNO",SqlDbType.UniqueIdentifier) { Value = (object)codigoFlujoEstadioRetorno ?? DBNull.Value},
                new SqlParameter("CODIGO_RESPONSABLE",SqlDbType.UniqueIdentifier) { Value = (object)codigoResponsable ?? DBNull.Value},
                new SqlParameter("USER_CREATION",SqlDbType.NVarChar) { Value = (object)UserUpdate ?? DBNull.Value},
                new SqlParameter("TERMINAL_CREATION",SqlDbType.NVarChar) { Value = (object)TerminalUpdate ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<int>("CTR.USP_OBSERVA_ESTADIO_CONTRATO_UPD", parametros).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Método que retorna los responsable por flujo de aprobación.
        /// </summary>
        /// <param name="codigoFlujoAprobacion">código del flujo de aprobación.</param>
        /// <param name="codigoContrato"></param>
        /// <returns>Responsable del flujo del estadio</returns>
        public List<TrabajadorResponse> RetornaResponsablesFlujoEstadio(Guid codigoFlujoAprobacion, Guid codigoContrato)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CodigoFlujoAprobacion",SqlDbType.UniqueIdentifier) { Value = (object)codigoFlujoAprobacion ?? DBNull.Value},
                new SqlParameter("CodigoContrato",SqlDbType.UniqueIdentifier) { Value = (object)codigoContrato ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<TrabajadorResponse>("CTR.USP_RESPONSABLES_FLUJO_ESTADIO", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Método para listar los documentos de la bandeja de solicitud.
        /// </summary>
        /// <param name="NumeroContrato">número del contrato</param>
        /// <param name="UnidadOperativa">unidad operativa</param>
        /// <param name="NombreProveedor">nombre del proveedor</param>
        /// <param name="NumdocPrv">numero documento del proveedor</param>
        /// <returns>Documentos de la bandeja de solicitud</returns>
        public List<ContratoLogic> ListaBandejaSolicitudContratos(string NumeroContrato, Guid? UnidadOperativa, string NombreProveedor, string NumdocPrv)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("NumeroContrato",SqlDbType.NVarChar) { Value = (object)NumeroContrato ?? DBNull.Value},
                new SqlParameter("UnidadOperativa",SqlDbType.UniqueIdentifier) { Value = (object)UnidadOperativa ?? DBNull.Value},
                new SqlParameter("NombreProveedor",SqlDbType.NVarChar) { Value = (object)NombreProveedor ?? DBNull.Value},
                new SqlParameter("NumeroDocumentoPrv",SqlDbType.NVarChar) { Value = (object)NumdocPrv ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoLogic>("CTR.USP_BANDEJA_SOLICITUD_CONTRATO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Método para retornar los documentos PDf por Contrato
        /// </summary>
        /// <param name="CodigoContrato">Código de Contrato</param>
        /// <returns>Documentos pdf por contrato</returns>
        public List<ContratoDocumentoLogic> DocumentosPorContrato(Guid CodigoContrato)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CodigoContrato",SqlDbType.UniqueIdentifier) { Value = (object)CodigoContrato ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoDocumentoLogic>("CTR.USP_DOCUMENTO_POR_CONTRATO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Metodo para cargar un Archivo a un estadio de contrato.
        /// </summary>
        /// <param name="objLogic">Objeto Contrato Documento Logic</param>
        /// <param name="User">Usuario que ejecuta la transaccion</param>
        /// <param name="Terminal">Terminal desde donde se ejecuta la transaccion</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public int RegistraContratoDocumentoCargaArchivo(ContratoDocumentoLogic objLogic, string User, string Terminal)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_DOCUMENTO",SqlDbType.UniqueIdentifier) { Value = (object)objLogic.CodigoContratoDocumento ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)objLogic.CodigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_ARCHIVO",SqlDbType.Int ) { Value = (object)objLogic.CodigoArchivo ?? DBNull.Value},
                new SqlParameter("RUTA_ARCHIVOSHP",SqlDbType.NVarChar) { Value = (object)objLogic.RutaArchivoSharePoint ?? DBNull.Value},
                new SqlParameter("CONTENIDO",SqlDbType.NVarChar) { Value = (object)objLogic.Contenido ?? DBNull.Value},
                new SqlParameter("USER_CREACION",SqlDbType.VarChar) { Value = (object)User ?? DBNull.Value},
                new SqlParameter("TERMINAL_CREACION",SqlDbType.VarChar) { Value = (object)Terminal ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<int>("CTR.USP_REGISTRA_CONTRATODOC_CARGA_ARCHIVO", parametros).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Método para retornar registros de Contrato Documento
        /// </summary>
        /// <param name="CodigoContrato">Llave primaria código contrato</param>
        /// <returns>Lista de registros</returns>
        public List<ContratoDocumentoLogic> ListarContratoDocumento(Guid codigoContrato)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContrato ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoDocumentoLogic>("CTR.USP_CONTRATO_DOCUMENTO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Lista los Estadios de los Contratos
        /// </summary>
        /// <param name="codigoContratoEstadio">Codigo de Contrato Estadio</param>
        /// <param name="codigoContrato">Código de contrato</param>
        /// <param name="codigoFlujoAprobEsta">Código de flujo de aprobación</param>
        /// <param name="fechaIngreso">Fecha de ingreso</param>
        /// <param name="fechaFinaliz">Fecha de finalización</param>
        /// <param name="codigoResponsable">Código de responsable</param>
        /// <param name="codigoEstadoContratoEst">Código de Estados de Contrato Estadio</param>
        /// <param name="fechaPrimera">Fecha de primera notificación</param>
        /// <param name="fechaUltima">Fecha de última notificación</param>
        /// <param name="PageNumero">número de página</param>
        /// <param name="PageSize">tamaño por página</param>
        /// <returns>Estadios de los contratos</returns>        
        public List<ContratoEstadioLogic> ListarContratoEstadio(Guid? codigoContratoEstadio = null, Guid? codigoContrato = null,
                                                                Guid? codigoFlujoAprobEsta = null, DateTime? fechaIngreso = null,
                                                                DateTime? fechaFinaliz = null, Guid? codigoResponsable = null,
                                                                string codigoEstadoContratoEst = null,
                                                                DateTime? fechaPrimera = null, DateTime? fechaUltima = null,
                                                                int PageNumero = 1, int PageSize = -1)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_ESTADIO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContratoEstadio ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_FLUJO_APROBACION_ESTADIO",SqlDbType.UniqueIdentifier) { Value = (object)codigoFlujoAprobEsta ?? DBNull.Value},
                new SqlParameter("FECHA_INGRESO",SqlDbType.DateTime) { Value = (object)fechaIngreso ?? DBNull.Value},
                new SqlParameter("FECHA_FINALIZACION",SqlDbType.DateTime) { Value = (object)fechaFinaliz ?? DBNull.Value},
                new SqlParameter("CODIGO_RESPONSABLE",SqlDbType.UniqueIdentifier) { Value = (object)codigoResponsable ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADO_CONTRATO_ESTADIO",SqlDbType.NVarChar) { Value = (object)codigoEstadoContratoEst ?? DBNull.Value},
                new SqlParameter("FECHA_PRIMERA_NOTIFICACION",SqlDbType.DateTime) { Value = (object)fechaPrimera ?? DBNull.Value},
                new SqlParameter("FECHA_ULTIMA_NOTIFICACION",SqlDbType.DateTime) { Value = (object)fechaUltima ?? DBNull.Value},
                new SqlParameter("PageNo",SqlDbType.Int) { Value = (object)PageNumero ?? DBNull.Value},
                new SqlParameter("PageSize",SqlDbType.Int) { Value = (object)PageSize ?? DBNull.Value},

            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoEstadioLogic>("CTR.USP_CONTRATO_ESTADIO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Método para retornar las unidades operativas del responsable.
        /// </summary>
        /// <param name="codigoTrabajador">Código del Trabjador</param>
        /// <returns>Lista de registros</returns>
        public List<UnidadOperativaLogic> ListarUnidadOperativaResponsable(Guid codigoTrabajador)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_TRABAJADOR",SqlDbType.UniqueIdentifier) { Value = (object)codigoTrabajador ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<UnidadOperativaLogic>("CTR.USP_LISTAR_UO_POR_PARTICIPANTE_RESPONSABLE", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Retorna el participante y el codigo del flujo de aprobacion anterior del contrato estadio.
        /// </summary>
        /// <param name="codigoContratoEstadio">Codigo de Contrato Estadio</param>
        /// <param name="codigoContrato">Código de contrato</param>
        /// <returns>Participante y el código del flujo de aprobación</returns>        
        public List<FlujoAprobacionParticipanteLogic> EstadoAnteriorContratoEstadio(Guid codigoContratoEstadio, Guid codigoContrato)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_ESTADIO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContratoEstadio ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContrato ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<FlujoAprobacionParticipanteLogic>("CTR.USP_ESTADIO_ANTERIOR_CONTRATO_ESTADIO", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Notifica las acciones de contratos.
        /// </summary>        
        /// <param name="asunto">Asunto de la notificación</param>
        /// <param name="textoNotificar">contenido de la notificación</param>
        /// <param name="cuentaNotificar">cuentas destino a notificar</param>
        /// <param name="cuentaCopias">cuentas de copia del correo</param>
        /// <param name="profileCorreo">profile de la configuración de correo</param>
        /// <returns>Acciones del contrato</returns>
        public int NotificaBandejaContratos(string asunto, string textoNotificar, string cuentaNotificar, string cuentaCopias, string profileCorreo)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("ASUNTO",SqlDbType.NVarChar) { Value = (object)asunto ?? DBNull.Value},
                new SqlParameter("TEXTO_NOTIFICAR",SqlDbType.NVarChar ) { Value = (object)textoNotificar ?? DBNull.Value},
                new SqlParameter("CUENTA_NOTIFICAR",SqlDbType.NVarChar) { Value = (object)cuentaNotificar ?? DBNull.Value},
                new SqlParameter("CUENTAS_COPIAS",SqlDbType.NVarChar) { Value = (object)cuentaCopias ?? DBNull.Value},
                new SqlParameter("PROFILE_CORREO",SqlDbType.NVarChar) { Value = (object)profileCorreo ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<int>("CTR.USP_NOTIFICACION_BANDEJA_CONTRATOS", parametros).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Retorna los parámetros necesarios para enviar la notificación
        /// </summary>
        /// <param name="codigoContratoEstadio">Código de Contrato estadio</param>
        /// <param name="TipoNotificacion">Tipo de notificación</param>
        /// <returns>Parametros necesarios para enviar la notifación</returns>     
        public List<ContratoEstadioLogic> InformacionNotificacionContratoEstadio(Guid codigoContratoEstadio, string TipoNotificacion)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_ESTADIO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContratoEstadio ?? DBNull.Value},
                new SqlParameter("TIPO_NOTIFICACION",SqlDbType.NVarChar) { Value = (object)TipoNotificacion ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoEstadioLogic>("CTR.USP_INF_NOTIFICACION_CONTRATO_ESTADIO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Lista de contratos estadios por responsable
        /// </summary>        
        /// <param name="codigoContrato">Codigo de Contrato</param>
        /// <returns>Listado de contrato estadio</returns>
        public List<ContratoEstadioLogic> ListadoContratoEstadioResponsable(Guid codigoContrato)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContrato ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoEstadioLogic>("CTR.USP_CONTRATO_ESTADIO_RESPONSABLE_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Registrar adenda con contrato vencido
        /// </summary>
        /// <param name="unidadOperativa">Código Unidad Operativa</param>
        /// <param name="numeroContrato">Número contrato</param>
        /// <param name="descripcion">Descripción</param>
        /// <param name="numeroAdenda">Número de adenda</param>
        /// <param name="numeroAdendaConcatenado">Número de adenda concatenado</param>
        /// <returns>Registro de adenda en tabla temporal</returns>
        public int RegistraAdendaContratoVencido(Guid unidadOperativa, string numeroContrato, string descripcion, int numeroAdenda, string numeroAdendaConcatenado)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier) { Value = (object)unidadOperativa ?? DBNull.Value},
                new SqlParameter("NUMERO_CONTRATO",SqlDbType.NVarChar) { Value = (object)numeroContrato ?? DBNull.Value},
                new SqlParameter("DESCRIPCION",SqlDbType.NVarChar) { Value = (object)descripcion ?? DBNull.Value},
                new SqlParameter("NUMERO_ADENDA",SqlDbType.Int) { Value = (object)numeroAdenda ?? DBNull.Value},
                new SqlParameter("NUMERO_ADENDA_CONCATENADO",SqlDbType.NVarChar) { Value = (object)numeroAdendaConcatenado ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedureNonQuery("CTR.USP_ADENDAS_CONTRATO_VENCIDO_INS", parametros);
            return result;
        }


        /// <summary>
        /// Método para listar los contrato por usuario.
        /// </summary>
        /// <param name="CodigoResponsable">Codigo de trabajador que consulta</param>
        /// <param name="UnidadOperativa">Código de Unidad Operativa</param>
        /// <param name="NombreProveedor">Nombre del proveedor</param>
        /// <param name="NumdocPrv">Número de documento del proveedor</param>
        /// <param name="TipoServicio">Tipo de Servicio</param>
        /// <param name="TipoReq">Tipo de Requerimiento</param>
        /// <param name="nombreEstadio">Nombre de estadio</param>
        /// <param name="indicadorFinalizarAprobacion">Indicador de finalizar aprobación</param>
        /// <param name="columnaOrden">Columna para ordenar</param>
        /// <param name="tipoOrden">Tipo de ordenamiento</param>
        /// <param name="numeroPagina">Número de página</param>
        /// <param name="registroPagina">Número de registros por página</param>
        /// <returns>Lista de bandeja de contratos</returns>
        public List<ContratoLogic> ListaBandejaContratosOrdenado(
            Guid CodigoResponsable,
            Guid? UnidadOperativa,
            string NombreProveedor,
            string NumdocPrv,
            string TipoServicio,
            string TipoReq,
            string nombreEstadio,
            string indicadorFinalizarAprobacion,
            string columnaOrden,
            string tipoOrden,
            int numeroPagina,
            int registroPagina)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CodigoResponsable",SqlDbType.UniqueIdentifier) { Value = (object)CodigoResponsable ?? DBNull.Value},
                new SqlParameter("UnidadOperativa",SqlDbType.UniqueIdentifier) { Value = (object)UnidadOperativa ?? DBNull.Value},
                new SqlParameter("NombreProveedor",SqlDbType.NVarChar) { Value = (object)NombreProveedor ?? DBNull.Value},
                new SqlParameter("NumeroDocumentoPrv",SqlDbType.NVarChar) { Value = (object)NumdocPrv ?? DBNull.Value},
                new SqlParameter("TipoServicio",SqlDbType.NVarChar) { Value = (object)TipoServicio ?? DBNull.Value},
                new SqlParameter("TipoRequerimiento",SqlDbType.NVarChar) { Value = (object)TipoReq ?? DBNull.Value},
                new SqlParameter("NombreEstadio",SqlDbType.NVarChar) { Value = (object)nombreEstadio ?? DBNull.Value},
                new SqlParameter("IndicadorFinalizarAprobacion",SqlDbType.NVarChar) { Value = (object)indicadorFinalizarAprobacion ?? DBNull.Value},
                new SqlParameter("COLUMNA_ORDEN",SqlDbType.VarChar) { Value = (object)columnaOrden ?? DBNull.Value},
                new SqlParameter("TIPO_ORDEN",SqlDbType.VarChar) { Value = (object)tipoOrden ?? DBNull.Value},
                new SqlParameter("NUMERO_PAGINA",SqlDbType.Int) { Value = (object)numeroPagina ?? DBNull.Value},
                new SqlParameter("TAMANIO_PAGINA",SqlDbType.BigInt) { Value = (object)registroPagina ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoLogic>("CTR.USP_BANDEJA_CONTRATOS_ORDENADO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Metodo para obtener el estadio de edición de un flujo de aprobación de un contrato
        /// </summary>
        /// <param name="codigoContrato">Código contrato</param>
        /// <param name="codigoFlujoAprobacion">Código flujo de aprobación</param>     
        /// <returns>Código de contrato estadio de edición</returns>
        public Guid ObtenerContratoEstadioEdicion(Guid codigoContrato, Guid? codigoFlujoAprobacion)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContrato ?? DBNull.Value},
                new SqlParameter("CODIGO_FLUJO_APROBACION",SqlDbType.UniqueIdentifier ) { Value = (object)codigoFlujoAprobacion ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<Guid>("CTR.USP_CONTRATO_ESTADIO_OBTENER_ESTADIO_EDICION", parametros).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Metodo para obtener el responsable de edición de un estadio
        /// </summary>
        /// <param name="codigoContratoEstadio">Código contrato estadio</param>
        /// <param name="codigoEstadioRetorno">Código estadio retorno</param>   
        /// <param name="codigoResposable">Código responsale</param>   
        /// <returns>Código responsable de estadio de edición</returns>
        public Guid ObtenerResponsableContratoEstadioEdicion(Guid codigoContratoEstadio, Guid codigoEstadioRetorno, Guid codigoResposable)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_CONTRATO_ESTADIO",SqlDbType.UniqueIdentifier) { Value = (object)codigoContratoEstadio ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADIO_RETORNO",SqlDbType.UniqueIdentifier ) { Value = (object)codigoEstadioRetorno ?? DBNull.Value},
                new SqlParameter("CODIGO_RESPONSABLE",SqlDbType.UniqueIdentifier ) { Value = (object)codigoResposable ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<Guid>("CTR.USP_CONTRATO_ESTADIO_OBTENER_RESPONSABLE_EDICION", parametros).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Método para obtener la empresa vinculada por proveedor
        /// </summary>
        /// <param name="codigoProveedor">Código de proveedor</param>       
        /// <returns>Datos de empresa vinculada</returns>
        public EmpresaVinculadaLogic ObtenerEmpresaVinculadaPorProveedor(Guid? codigoProveedor)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PROVEEDOR",SqlDbType.UniqueIdentifier) { Value = (object)codigoProveedor ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<EmpresaVinculadaLogic>("CTR.USP_EMPRESA_VINCULADA_POR_PROVEEDOR", parametros).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// Método para listar los contratos aprobados en la solicitud de modificación.
        /// </summary>
        /// <param name="NumeroContrato">número del contrato</param>
        /// <param name="UnidadOperativa">unidad operativa</param>
        /// <param name="NombreProveedor">nombre del proveedor</param>
        /// <param name="NumdocPrv">numero documento del proveedor</param>
        /// <returns>Listado de contratos para revisión</returns>
        public List<ContratoLogic> ListaBandejaRevisionContratos(string NumeroContrato, Guid? UnidadOperativa, string NombreProveedor, string NumdocPrv)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("NumeroContrato",SqlDbType.NVarChar) { Value = (object)NumeroContrato ?? DBNull.Value},
                new SqlParameter("UnidadOperativa",SqlDbType.UniqueIdentifier) { Value = (object)UnidadOperativa ?? DBNull.Value},
                new SqlParameter("NombreProveedor",SqlDbType.NVarChar) { Value = (object)NombreProveedor ?? DBNull.Value},
                new SqlParameter("NumeroDocumentoPrv",SqlDbType.NVarChar) { Value = (object)NumdocPrv ?? DBNull.Value},
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoLogic>("CTR.USP_BANDEJA_REVISION_CONTRATO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoUnidadOperativa"></param>
        /// <param name="numeroContrato"></param>
        /// <param name="numeroPagina"></param>
        /// <param name="registroPagina"></param>
        /// <returns></returns>
        public List<ContratoLogic> BuscarNumeroContrato(Guid? codigoUnidadOperativa,
                                                         string numeroContrato,
                                                         int numeroPagina,
                                                         int registroPagina)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier)     { Value = (object)codigoUnidadOperativa ?? DBNull.Value},
                new SqlParameter("NUMERO_CONTRATO",SqlDbType.NVarChar)                     { Value = (object)numeroContrato ?? DBNull.Value},
                new SqlParameter("PageNo",SqlDbType.Int)                                   { Value = (object)numeroPagina ?? DBNull.Value},
                new SqlParameter("PageSize",SqlDbType.Int)                                 { Value = (object)registroPagina ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoLogic>("CTR.USP_NUMERO_CONTRATO_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Reporte Observado Aprobado
        /// </summary>
        /// <param name="codigoUnidadOperativa"></param>
        /// <param name="codigoContrato"></param>
        /// <param name="tipoAccion"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <param name="nombreBaseDatoPolitica"></param>
        /// <param name="numeroPagina"></param>
        /// <param name="registroPagina"></param>
        /// <returns></returns>
        public List<ContratoObservadoAprobadoLogic> BuscarContratoObservadoAprobado(Guid? codigoUnidadOperativa,
                                                                                         Guid? codigoContrato,
                                                                                         string tipoAccion,
                                                                                         DateTime? fechaInicio,
                                                                                         DateTime? fechaFin,
                                                                                         string nombreBaseDatoPolitica,
                                                                                         int numeroPagina,
                                                                                         int registroPagina)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier)     { Value = (object)codigoUnidadOperativa ?? DBNull.Value},
                new SqlParameter("CODIGO_CONTRATO",SqlDbType.UniqueIdentifier)             { Value = (object)codigoContrato ?? DBNull.Value},
                new SqlParameter("TIPO_ACCION_CONTRATO",SqlDbType.NVarChar)                { Value = (object)tipoAccion ?? DBNull.Value},
                new SqlParameter("FECHA_INICIO",SqlDbType.DateTime)                        { Value = (object)fechaInicio ?? DBNull.Value},
                new SqlParameter("FECHA_FIN",SqlDbType.DateTime)                           { Value = (object)fechaFin ?? DBNull.Value},
                new SqlParameter("NAME_DATABASE",SqlDbType.NVarChar)                       { Value = (object)nombreBaseDatoPolitica ?? DBNull.Value},
                new SqlParameter("PageNo",SqlDbType.Int)                                   { Value = (object)numeroPagina ?? DBNull.Value},
                new SqlParameter("PageSize",SqlDbType.Int)                                 { Value = (object)registroPagina ?? DBNull.Value}
            };

                var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoObservadoAprobadoLogic>("CTR.USP_CONTRATO_OBSERVACIONES_APROBADAS_RPT", parametros).ToList();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;

namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    public interface IContratoLogicRepository : IQueryRepository<ContratoLogic>
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
        /// <param name="nombreEstadio">Nombre de Estadio</param>
        /// <param name="indicadorFinalizarAprobacion">Indicador de Finalizar Aprobación</param>
        /// <returns>Lista de bandeja de contratos</returns>
        List<ContratoLogic> ListaBandejaContratos(
            Guid CodigoResponsable,
            Guid? UnidadOperativa,
            string NombreProveedor,
            string NumdocPrv,
            string TipoServicio,
            string TipoReq,
            string nombreEstadio,
            string indicadorFinalizarAprobacion);

        /// <summary>
        /// Metodo para listar las Observaciones por Contrato por Estadio.
        /// </summary>
        /// <param name="CodigoContratoEstadio">Código de Contrato Estadio</param>
        /// <returns>Lista de bandeja de contratos por observaciones</returns>
        List<ContratoEstadioObservacionLogic> ListaBandejaContratosObservacion(Guid CodigoContratoEstadio);

        /// <summary>
        /// Metodo para listar las Consultas por Contrato por Estadio.
        /// </summary>
        /// <param name="CodigoContratoEstadio">Código de Contrato Estadio</param>
        /// <returns>Lista de consultas por contrato</returns>
        List<ContratoEstadioConsultaLogic> ListaBandejaContratosConsultas(Guid CodigoContratoEstadio);

        /// <summary>
        /// Metodo para aprobar cada contrato según su estadío.
        /// </summary>
        /// <param name="codigoContratoEstadio">Código de Contrato Estadío</param>
        /// <param name="codigoIdentificacionUO">Código de Identificación UO</param>
        /// <param name="UserUpdate">Usuario que actualiza</param>
        /// <param name="TerminalUpdate">Terminal desde donde se ejecuta.</param>
        /// <param name="codigoUsuarioCreacionContrato">Código de Usuario de creación de contrato</param>
        /// <param name="MotivoAprobacion"></param>
        /// <returns>Lista de estadios aprobados</returns>
        int ApruebaContratoEstadio(Guid codigoContratoEstadio, string codigoIdentificacionUO, string UserUpdate, string TerminalUpdate, string codigoUsuarioCreacionContrato, string MotivoAprobacion);

        /// <summary>
        /// Método para retornar los párrafos por contrato
        /// </summary>
        /// <param name="CodigoContrato">Código de Contrato</param>
        /// <returns>Parrafos por contrato</returns>
        List<ContratoParrafoLogic> RetornaParrafosPorContrato(Guid CodigoContrato);

        /// <summary>
        /// Método que retorna los estadio del contrato para su observación.
        /// </summary>
        /// <param name="CodigoContratoEstadio">Código del Estadío del Contrato</param>
        /// <returns>Estadios de contrato</returns>
        List<FlujoAprobacionEstadioLogic> RetornaEstadioContratoObservacion(Guid CodigoContratoEstadio);

        /// <summary>
        /// Responder la Consulta que me han hecho
        /// </summary>
        /// <param name="codigoContratoEstadioConsulta"></param>
        /// <param name="Respuesta"></param>
        /// <param name="UsuarioModificacion"></param>
        /// <param name="TerminalModificacion"></param>
        /// <returns></returns>
        int Responder_Consulta(Guid codigoContratoEstadioConsulta, string Respuesta, string UsuarioModificacion,string TerminalModificacion);

        /// <summary>
        /// Método para generar un nuevo Estadio de contrato cada vez que es observado.
        /// </summary>
        /// <param name="codigoContratoEstadioObservado">Código de Contrato Estadio Observado</param>
        /// <param name="codigoContrato"> Código de Contrato </param>
        /// <param name="codigoFlujoEstadioRetorno">Código Flujo Estadio Retorno </param>
        /// <param name="codigoResponsable">Código de Responsable </param>
        /// <param name="UserUpdate">Usuario que actualiza</param>
        /// <param name="TerminalUpdate">Terminal desde donde de actualiza</param>
        /// <returns>Estadios de contrato segun observación</returns>
        int ObservaEstadioContrato(Guid codigoContratoEstadio, Guid codigoContratoEstadioObservado, Guid codigoContrato, Guid codigoFlujoEstadioRetorno,
                                    Guid codigoResponsable, string UserUpdate, string TerminalUpdate);

        /// <summary>
        /// Método que retorna los responsable por flujo de aprobación.
        /// </summary>
        /// <param name="codigoFlujoAprobacion">código del flujo de aprobación.</param>
        /// <param name="codigoContrato"></param>
        /// <returns>Responsable del flujo del estadio</returns>
        List<TrabajadorResponse> RetornaResponsablesFlujoEstadio(Guid codigoFlujoAprobacion, Guid codigoContrato);

        /// <summary>
        /// Método para listar los documentos de l bandeja de solicitud.
        /// </summary>
        /// <param name="NumeroContrato">número del contrato</param>
        /// <param name="UnidadOperativa">unidad operativa</param>
        /// <param name="NombreProveedor">nombre del proveedor</param>
        /// <param name="NumdocPrv">numero documento del proveedor</param>
        /// <returns>Documentos de la bandeja de solicitud</returns>
        List<ContratoLogic> ListaBandejaSolicitudContratos(string NumeroContrato, Guid? UnidadOperativa, string NombreProveedor, string NumdocPrv);

        /// <summary>
        /// Método para retornar los documentos PDf por Contrato
        /// </summary>
        /// <param name="CodigoContrato">Código de Contrato</param>
        /// <returns>Documentos pdf por contrato</returns>
        List<ContratoDocumentoLogic> DocumentosPorContrato(Guid CodigoContrato);

        /// <summary>
        /// Metodo para cargar un Archivo a un estadio de contrato.
        /// </summary>
        /// <param name="objLogic">Objeto Contrato Documento Logic</param>
        /// <param name="User">Usuario que ejecuta la transaccion</param>
        /// <param name="Terminal">Terminal desde donde se ejecuta la transaccion</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int RegistraContratoDocumentoCargaArchivo(ContratoDocumentoLogic objLogic, string User, string Terminal);

        /// <summary>
        /// Método para retornar registros de Contrato Documento
        /// </summary>
        /// <param name="CodigoContrato">Llave primaria código contrato</param>
        /// <returns>Lista de registros</returns>
        List<ContratoDocumentoLogic> ListarContratoDocumento(Guid codigoContrato);


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
        List<ContratoEstadioLogic> ListarContratoEstadio(Guid? codigoContratoEstadio = null, Guid? codigoContrato = null,
                                                                Guid? codigoFlujoAprobEsta = null, DateTime? fechaIngreso = null,
                                                                DateTime? fechaFinaliz = null, Guid? codigoResponsable = null,
                                                                string codigoEstadoContratoEst = null,
                                                                DateTime? fechaPrimera = null, DateTime? fechaUltima = null,
                                                                int PageNumero = 1, int PageSize = -1);

        /// <summary>
        /// Método para retornar las unidades operativas del responsable.
        /// </summary>
        /// <param name="codigoTrabajador">Código del Trabjador</param>
        /// <returns>Lista de registros</returns>
        List<UnidadOperativaLogic> ListarUnidadOperativaResponsable(Guid codigoTrabajador);

        /// <summary>
        /// Retorna el participante y el codigo del flujo de aprobacion anterior del contrato estadio.
        /// </summary>
        /// <param name="codigoContratoEstadio">Codigo de Contrato Estadio</param>
        /// <param name="codigoContrato">Código de contrato</param>
        /// <returns>Participante y el código del flujo de aprobación</returns>           
        List<FlujoAprobacionParticipanteLogic> EstadoAnteriorContratoEstadio(Guid codigoContratoEstadio, Guid codigoContrato);

        /// <summary>
        /// Notifica las acciones de contratos.
        /// </summary>        
        /// <param name="asunto">Asunto de la notificación</param>
        /// <param name="textoNotificar">contenido de la notificación</param>
        /// <param name="cuentaNotificar">cuentas destino a notificar</param>
        /// <param name="cuentaCopias">cuentas de copia del correo</param>
        /// <param name="profileCorreo">profile de la configuración de correo</param>
        /// <returns>Acciones del contrato</returns>
        int NotificaBandejaContratos(string asunto, string textoNotificar, string cuentaNotificar, string cuentaCopias, string profileCorreo);

        /// <summary>
        /// Retorna los parámetros necesarios para enviar la notificación
        /// </summary>
        /// <param name="codigoContratoEstadio">Código de Contrato estadio</param>
        /// <param name="TipoNotificacion">Tipo de notificación</param>
        /// <returns>Parametros necesarios para enviar la notifación</returns>   
        List<ContratoEstadioLogic> InformacionNotificacionContratoEstadio(Guid codigoContratoEstadio, string TipoNotificacion);

        /// <summary>
        /// Listado de contratos por estadio responsable
        /// </summary>
        /// <param name="codigoContrato">Código de contrato</param>
        /// <returns>Listado de contrato estadio</returns>
        List<ContratoEstadioLogic> ListadoContratoEstadioResponsable(Guid codigoContrato);


        /// <summary>
        /// Registrar adenda con contrato vencido
        /// </summary>
        /// <param name="unidadOperativa">Código Unidad Operativa</param>
        /// <param name="numeroContrato">Número contrato</param>
        /// <param name="descripcion">Descripción</param>
        /// <param name="numeroAdenda">Número de adenda</param>
        /// <param name="numeroAdendaConcatenado">Número de adenda concatenado</param>
        /// <returns>Registro de adenda en tabla temporal</returns>
        int RegistraAdendaContratoVencido(Guid unidadOperativa, string numeroContrato, string descripcion, int numeroAdenda, string numeroAdendaConcatenado);

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
        List<ContratoLogic> ListaBandejaContratosOrdenado(
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
            int registroPagina);

        /// <summary>
        /// Metodo para obtener el estadio de edición de un flujo de aprobación de un contrato
        /// </summary>
        /// <param name="codigoContrato">Código contrato</param>
        /// <param name="codigoFlujoAprobacion">Código flujo de aprobación</param>     
        /// <returns>Código de contrato estadio de edición</returns>
        Guid ObtenerContratoEstadioEdicion(Guid codigoContrato, Guid? codigoFlujoAprobacion);

        /// <summary>
        /// Metodo para obtener el responsable de edición de un estadio
        /// </summary>
        /// <param name="codigoContratoEstadio">Código contrato estadio</param>
        /// <param name="codigoEstadioRetorno">Código estadio retorno</param>   
        /// <param name="codigoResposable">Código responsale</param>   
        /// <returns>Código responsable de estadio de edición</returns>
        Guid ObtenerResponsableContratoEstadioEdicion(Guid codigoContratoEstadio, Guid codigoEstadioRetorno, Guid codigoResposable);

        /// <summary>
        /// Método para obtener la empresa vinculada por proveedor
        /// </summary>
        /// <param name="codigoProveedor">Código de proveedor</param>       
        /// <returns>Datos de empresa vinculada</returns>
        EmpresaVinculadaLogic ObtenerEmpresaVinculadaPorProveedor(Guid? codigoProveedor);


        /// <summary>
        /// Método para listar los contratos aprobados en la solicitud de modificación.
        /// </summary>
        /// <param name="NumeroContrato">número del contrato</param>
        /// <param name="UnidadOperativa">unidad operativa</param>
        /// <param name="NombreProveedor">nombre del proveedor</param>
        /// <param name="NumdocPrv">numero documento del proveedor</param>
        /// <returns>Listado de contratos para revisión</returns>
        List<ContratoLogic> ListaBandejaRevisionContratos(string NumeroContrato, Guid? UnidadOperativa, string NombreProveedor, string NumdocPrv);

        /// <summary>
        /// AutoComplete Numero Contrato
        /// </summary>
        /// <param name="codigoUnidadOperativa"></param>
        /// <param name="numeroContrato"></param>
        /// <param name="numeroPagina"></param>
        /// <param name="registroPagina"></param>
        /// <returns></returns>
        List<ContratoLogic> BuscarNumeroContrato(Guid? codigoUnidadOperativa, string numeroContrato, int numeroPagina, int registroPagina);

        /// <summary>
        /// Reporte Contrato Observado Aprobado
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
        List<ContratoObservadoAprobadoLogic> BuscarContratoObservadoAprobado(Guid? codigoUnidadOperativa,
                                                                             Guid? codigoContrato,
                                                                             string tipoAccion,
                                                                             DateTime? fechaInicio,
                                                                             DateTime? fechaFin,
                                                                             string nombreBaseDatoPolitica,
                                                                             int numeroPagina,
                                                                             int registroPagina);
    }
}

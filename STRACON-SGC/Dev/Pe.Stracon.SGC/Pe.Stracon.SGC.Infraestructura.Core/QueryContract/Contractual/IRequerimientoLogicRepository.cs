using System;
using System.Collections.Generic;
using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;

namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    public interface IRequerimientoLogicRepository : IQueryRepository<RequerimientoLogic>
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
        List<RequerimientoLogic> ListaBandejaRequerimientos(
            Guid CodigoResponsable,
            Guid? UnidadOperativa,
            string NombreProveedor,
            string NumdocPrv,
            string TipoServicio,
            string TipoReq,
            string nombreEstadio,
            string indicadorFinalizarAprobacion);

        /// <summary>
        /// Metodo para listar las Observaciones por Requerimiento por Estadio.
        /// </summary>
        /// <param name="CodigoRequerimientoEstadio">Código de Requerimiento Estadio</param>
        /// <returns>Lista de bandeja de contratos por observaciones</returns>
        List<RequerimientoEstadioObservacionLogic> ListaBandejaRequerimientosObservacion(Guid CodigoRequerimientoEstadio);

        /// <summary>
        /// Metodo para listar las Consultas por Requerimiento por Estadio.
        /// </summary>
        /// <param name="CodigoRequerimientoEstadio">Código de Requerimiento Estadio</param>
        /// <returns>Lista de consultas por contrato</returns>
        List<RequerimientoEstadioConsultaLogic> ListaBandejaRequerimientosConsultas(Guid CodigoRequerimientoEstadio);

        /// <summary>
        /// Metodo para aprobar cada contrato según su estadío.
        /// </summary>
        /// <param name="codigoRequerimientoEstadio">Código de Requerimiento Estadío</param>
        /// <param name="codigoIdentificacionUO">Código de Identificación UO</param>
        /// <param name="UserUpdate">Usuario que actualiza</param>
        /// <param name="TerminalUpdate">Terminal desde donde se ejecuta.</param>
        /// <param name="codigoUsuarioCreacionRequerimiento">Código de Usuario de creación de contrato</param>
        /// <param name="MotivoAprobacion"></param>
        /// <returns>Lista de estadios aprobados</returns>
        int ApruebaRequerimientoEstadio(Guid codigoRequerimientoEstadio, string codigoIdentificacionUO, string UserUpdate, string TerminalUpdate, string codigoUsuarioCreacionRequerimiento, string MotivoAprobacion);

        /// <summary>
        /// Método para retornar los párrafos por contrato
        /// </summary>
        /// <param name="CodigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Parrafos por contrato</returns>
        List<RequerimientoParrafoLogic> RetornaParrafosPorRequerimiento(Guid CodigoRequerimiento);

        /// <summary>
        /// Método que retorna los estadio del contrato para su observación.
        /// </summary>
        /// <param name="CodigoRequerimientoEstadio">Código del Estadío del Requerimiento</param>
        /// <returns>Estadios de contrato</returns>
        List<FlujoAprobacionEstadioLogic> RetornaEstadioRequerimientoObservacion(Guid CodigoRequerimientoEstadio);

        /// <summary>
        /// Responder la Consulta que me han hecho
        /// </summary>
        /// <param name="codigoRequerimientoEstadioConsulta"></param>
        /// <param name="Respuesta"></param>
        /// <param name="UsuarioModificacion"></param>
        /// <param name="TerminalModificacion"></param>
        /// <returns></returns>
        int Responder_Consulta(Guid codigoRequerimientoEstadioConsulta, string Respuesta, string UsuarioModificacion,string TerminalModificacion);

        /// <summary>
        /// Método para generar un nuevo Estadio de contrato cada vez que es observado.
        /// </summary>
        /// <param name="codigoRequerimientoEstadioObservado">Código de Requerimiento Estadio Observado</param>
        /// <param name="codigoRequerimiento"> Código de Requerimiento </param>
        /// <param name="codigoFlujoEstadioRetorno">Código Flujo Estadio Retorno </param>
        /// <param name="codigoResponsable">Código de Responsable </param>
        /// <param name="UserUpdate">Usuario que actualiza</param>
        /// <param name="TerminalUpdate">Terminal desde donde de actualiza</param>
        /// <returns>Estadios de contrato segun observación</returns>
        int ObservaEstadioRequerimiento(Guid codigoRequerimientoEstadio, Guid codigoRequerimientoEstadioObservado, Guid codigoRequerimiento, Guid codigoFlujoEstadioRetorno,
                                    Guid codigoResponsable, string UserUpdate, string TerminalUpdate);

        /// <summary>
        /// Método que retorna los responsable por flujo de aprobación.
        /// </summary>
        /// <param name="codigoFlujoAprobacion">código del flujo de aprobación.</param>
        /// <param name="codigoRequerimiento"></param>
        /// <returns>Responsable del flujo del estadio</returns>
        List<TrabajadorResponse> RetornaResponsablesFlujoEstadio(Guid codigoFlujoAprobacion, Guid codigoRequerimiento);

        /// <summary>
        /// Método para listar los documentos de l bandeja de solicitud.
        /// </summary>
        /// <param name="NumeroRequerimiento">número del contrato</param>
        /// <param name="UnidadOperativa">unidad operativa</param>
        /// <param name="NombreProveedor">nombre del proveedor</param>
        /// <param name="NumdocPrv">numero documento del proveedor</param>
        /// <returns>Documentos de la bandeja de solicitud</returns>
        List<RequerimientoLogic> ListaBandejaSolicitudRequerimientos(string NumeroRequerimiento, Guid? UnidadOperativa, string NombreProveedor, string NumdocPrv);

        /// <summary>
        /// Método para retornar los documentos PDf por Requerimiento
        /// </summary>
        /// <param name="CodigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Documentos pdf por contrato</returns>
        List<RequerimientoDocumentoLogic> DocumentosPorRequerimiento(Guid CodigoRequerimiento);

        /// <summary>
        /// Metodo para cargar un Archivo a un estadio de contrato.
        /// </summary>
        /// <param name="objLogic">Objeto Requerimiento Documento Logic</param>
        /// <param name="User">Usuario que ejecuta la transaccion</param>
        /// <param name="Terminal">Terminal desde donde se ejecuta la transaccion</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int RegistraRequerimientoDocumentoCargaArchivo(RequerimientoDocumentoLogic objLogic, string User, string Terminal);

        /// <summary>
        /// Método para retornar registros de Requerimiento Documento
        /// </summary>
        /// <param name="CodigoRequerimiento">Llave primaria código contrato</param>
        /// <returns>Lista de registros</returns>
        List<RequerimientoDocumentoLogic> ListarRequerimientoDocumento(Guid CodigoRequerimiento);


        /// <summary>
        /// Lista los Estadios de los Requerimientos
        /// </summary>
        /// <param name="codigoRequerimientoEstadio">Codigo de Requerimiento Estadio</param>
        /// <param name="codigoRequerimiento">Código de contrato</param>
        /// <param name="codigoFlujoAprobEsta">Código de flujo de aprobación</param>
        /// <param name="fechaIngreso">Fecha de ingreso</param>
        /// <param name="fechaFinaliz">Fecha de finalización</param>
        /// <param name="codigoResponsable">Código de responsable</param>
        /// <param name="codigoEstadoRequerimientoEst">Código de Estados de Requerimiento Estadio</param>
        /// <param name="fechaPrimera">Fecha de primera notificación</param>
        /// <param name="fechaUltima">Fecha de última notificación</param>
        /// <param name="PageNumero">número de página</param>
        /// <param name="PageSize">tamaño por página</param>
        /// <returns>Estadios de los contratos</returns>  
        List<RequerimientoEstadioLogic> ListarRequerimientoEstadio(Guid? codigoRequerimientoEstadio = null, Guid? codigoRequerimiento = null,
                                                                Guid? codigoFlujoAprobEsta = null, DateTime? fechaIngreso = null,
                                                                DateTime? fechaFinaliz = null, Guid? codigoResponsable = null,
                                                                string codigoEstadoRequerimientoEst = null,
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
        /// <param name="codigoRequerimientoEstadio">Codigo de Requerimiento Estadio</param>
        /// <param name="codigoRequerimiento">Código de contrato</param>
        /// <returns>Participante y el código del flujo de aprobación</returns>           
        List<FlujoAprobacionParticipanteLogic> EstadoAnteriorRequerimientoEstadio(Guid codigoRequerimientoEstadio, Guid codigoRequerimiento);

        /// <summary>
        /// Notifica las acciones de contratos.
        /// </summary>        
        /// <param name="asunto">Asunto de la notificación</param>
        /// <param name="textoNotificar">contenido de la notificación</param>
        /// <param name="cuentaNotificar">cuentas destino a notificar</param>
        /// <param name="cuentaCopias">cuentas de copia del correo</param>
        /// <param name="profileCorreo">profile de la configuración de correo</param>
        /// <returns>Acciones del contrato</returns>
        int NotificaBandejaRequerimientos(string asunto, string textoNotificar, string cuentaNotificar, string cuentaCopias, string profileCorreo);

        /// <summary>
        /// Retorna los parámetros necesarios para enviar la notificación
        /// </summary>
        /// <param name="codigoRequerimientoEstadio">Código de Requerimiento estadio</param>
        /// <param name="TipoNotificacion">Tipo de notificación</param>
        /// <returns>Parametros necesarios para enviar la notifación</returns>   
        List<RequerimientoEstadioLogic> InformacionNotificacionRequerimientoEstadio(Guid codigoRequerimientoEstadio, string TipoNotificacion);

        /// <summary>
        /// Listado de contratos por estadio responsable
        /// </summary>
        /// <param name="codigoRequerimiento">Código de contrato</param>
        /// <returns>Listado de contrato estadio</returns>
        List<RequerimientoEstadioLogic> ListadoRequerimientoEstadioResponsable(Guid codigoRequerimiento);


        /// <summary>
        /// Registrar adenda con contrato vencido
        /// </summary>
        /// <param name="unidadOperativa">Código Unidad Operativa</param>
        /// <param name="numeroRequerimiento">Número contrato</param>
        /// <param name="descripcion">Descripción</param>
        /// <param name="numeroAdenda">Número de adenda</param>
        /// <param name="numeroAdendaConcatenado">Número de adenda concatenado</param>
        /// <returns>Registro de adenda en tabla temporal</returns>
        int RegistraAdendaRequerimientoVencido(Guid unidadOperativa, string numeroRequerimiento, string descripcion, int numeroAdenda, string numeroAdendaConcatenado);

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
        List<RequerimientoLogic> ListaBandejaRequerimientosOrdenado(
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
        /// <param name="codigoRequerimiento">Código contrato</param>
        /// <param name="codigoFlujoAprobacion">Código flujo de aprobación</param>     
        /// <returns>Código de contrato estadio de edición</returns>
        Guid ObtenerRequerimientoEstadioEdicion(Guid codigoRequerimiento, Guid? codigoFlujoAprobacion);

        /// <summary>
        /// Metodo para obtener el responsable de edición de un estadio
        /// </summary>
        /// <param name="codigoRequerimientoEstadio">Código contrato estadio</param>
        /// <param name="codigoEstadioRetorno">Código estadio retorno</param>   
        /// <param name="codigoResposable">Código responsale</param>   
        /// <returns>Código responsable de estadio de edición</returns>
        Guid ObtenerResponsableRequerimientoEstadioEdicion(Guid codigoRequerimientoEstadio, Guid codigoEstadioRetorno, Guid codigoResposable);

        /// <summary>
        /// Método para obtener la empresa vinculada por proveedor
        /// </summary>
        /// <param name="codigoProveedor">Código de proveedor</param>       
        /// <returns>Datos de empresa vinculada</returns>
        EmpresaVinculadaLogic ObtenerEmpresaVinculadaPorProveedor(Guid? codigoProveedor);


        /// <summary>
        /// Método para listar los contratos aprobados en la solicitud de modificación.
        /// </summary>
        /// <param name="NumeroRequerimiento">número del contrato</param>
        /// <param name="UnidadOperativa">unidad operativa</param>
        /// <param name="NombreProveedor">nombre del proveedor</param>
        /// <param name="NumdocPrv">numero documento del proveedor</param>
        /// <returns>Listado de contratos para revisión</returns>
        List<RequerimientoLogic> ListaBandejaRevisionRequerimientos(string NumeroRequerimiento, Guid? UnidadOperativa, string NombreProveedor, string NumdocPrv);

        /// <summary>
        /// AutoComplete Numero Requerimiento
        /// </summary>
        /// <param name="codigoUnidadOperativa"></param>
        /// <param name="numeroRequerimiento"></param>
        /// <param name="numeroPagina"></param>
        /// <param name="registroPagina"></param>
        /// <returns></returns>
        List<RequerimientoLogic> BuscarNumeroRequerimiento(Guid? codigoUnidadOperativa, string numeroRequerimiento, int numeroPagina, int registroPagina);

        /// <summary>
        /// Reporte Requerimiento Observado Aprobado
        /// </summary>
        /// <param name="codigoUnidadOperativa"></param>
        /// <param name="codigoRequerimiento"></param>
        /// <param name="tipoAccion"></param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <param name="nombreBaseDatoPolitica"></param>
        /// <param name="numeroPagina"></param>
        /// <param name="registroPagina"></param>
        /// <returns></returns>
        List<RequerimientoObservadoAprobadoLogic> BuscarRequerimientoObservadoAprobado(Guid? codigoUnidadOperativa,
                                                                             Guid? codigoRequerimiento,
                                                                             string tipoAccion,
                                                                             DateTime? fechaInicio,
                                                                             DateTime? fechaFin,
                                                                             string nombreBaseDatoPolitica,
                                                                             int numeroPagina,
                                                                             int registroPagina);
    }
}

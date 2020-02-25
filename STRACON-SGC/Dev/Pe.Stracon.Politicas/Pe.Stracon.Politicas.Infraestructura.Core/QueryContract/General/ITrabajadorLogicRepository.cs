using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using Pe.Stracon.Politicas.Infraestructura.Core.Base;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using System;
using System.Collections.Generic;

namespace Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General
{
    /// <summary>
    /// Definición del Repositorio de Trabajador
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150401 <br />
    /// Modificación :           <br />
    /// </remarks>    
    public interface ITrabajadorLogicRepository : IQueryRepository<TrabajadorLogic>
    {
        /// <summary>
        /// Buscar Trabajador
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellidoPaterno">Apellido Paterno</param>
        /// <param name="apellidoMaterno">Apellido Materno</param>
        /// <param name="tipoDocumento">Tipo Documento</param>
        /// <param name="numeroDocumento">Número de Documento</param>
        /// <returns>Lista con datos de trabajadores</returns>
        List<TrabajadorLogic> BuscarTrabajador(Guid? codigoTrabajador, string codigoIdentificacion, string dominio, string codigoTipoDocumentoIdentidad, string numeroDocumentoIdentidad, string nombres, int numeroPagina = 1, int registrosPagina = -1);

        /// <summary>
        /// Lista trabajadores
        /// </summary>
        /// <param name="listaCodigos">Lista de códigos de trabajadores</param>
        /// <returns>Lista de registros encontrados</returns>
        List<TrabajadorLogic> ListarTrabajadores(List<Guid?> listaCodigos);

        /// <summary>
        /// Registrar Trabajador
        /// </summary>
        /// <param name="data">Trabajador Entity</param>
        /// <returns>Identificador con el resultado</returns>
        int RegistrarTrabajador(TrabajadorEntity data);

        /// <summary>
        /// Actualizar Trabajador
        /// </summary>
        /// <param name="data">Trabajador Entity</param>
        /// <returns>Identificador con el resultado</returns>
        int ActualizarTrabajador(TrabajadorEntity data);

        /// <summary>
        /// Lista de Trabajadores con información mínima.
        /// </summary>
        /// <param name="dominio">dominio del trabajador</param>
        /// <param name="codigoIdentificacion">codigo identificador del trabajador</param>
        /// <param name="NombreCompleto">nombre completo del trabajador</param>
        /// <param name="correoElectronico">correo electrónico del trabajador</param>
        /// <returns>Lista con resultados</returns>
        List<TrabajadorLogic> BuscarTrabajadorDatoMinimo(string dominio, string codigoIdentificacion, string NombreCompleto, string correoElectronico);

        /// <summary>
        /// Obtener la firma del trabajador.
        /// </summary>
        /// <param name="trabajador">Trabajador Entity</param>
        /// <returns>Lista de registros encontrados</returns>
        TrabajadorLogic BuscarFirmaTrabajador(TrabajadorEntity trabajador);
        
        /// <summary>
        /// Notificar inicios y cierres de periodo.
        /// </summary>
        /// <param name="listaTrabajadores">Lista de trabajaores</param>
        /// <param name="CodigoNotificar">tipo de notificacion</param>
        /// <param name="AnioPeriodo">Anio de Periodo</param>
        /// <param name="MesPeriodo"> Mes del Periodo </param>
        /// <param name="codigoSistema">Código del sistema</param>
        /// <param name="profileCorreo">Perfil de la cuenta que ejecuta la notificación.</param>
        /// <returns>Identificador de proceso</returns>
        int NotificaParticipanteCalendarizacion(List<Guid?> listaTrabajadores, string CodigoNotificar, string AnioPeriodo, string MesPeriodo,
                                                        string NombreActividad, Guid codigoSistema, string profileCorreo);

        /// <summary>
        /// Lista trabajadoreUnidadOperativa
        /// </summary>
        /// <param name="codigoUnidadOperativaMatriz">Código de Unidad Operativa Matriz</param>
        /// <param name="codigoTrabajador">Código de trabajador</param>
        /// <returns>Lista de trabajadorUndiadOperativa</returns>
        List<TrabajadorUnidadOperativaLogic> ListarTrabajadorUnidadOperativa(Guid? codigoUnidadOperativaMatriz, Guid? codigoTrabajador);

        /// <summary>
        /// Lista trabajadoreUnidadOperativa SAP
        /// </summary>
        /// <param name="codigoUnidadOperativaMatriz">Código de Unidad Operativa Matriz</param>
        /// <param name="codigoTrabajador">Código de trabajador</param>
        /// <returns>Lista de trabajadorUndiadOperativa</returns>
        List<TrabajadorUnidadOperativaLogic> ListarTrabajadorUnidadOperativaSAP(Guid? codigoUnidadOperativaMatriz, Guid? codigoTrabajador);

        /// <summary>
        /// Lista trabajador suplente
        /// </summary>
        /// <param name="codigoTrabajador">Código de trabajador</param>
        /// <returns>Lista de trabajador suplente</returns>
        List<TrabajadorSuplenteLogic> ListarTrabajadorSuplente(Guid codigoTrabajador);

        /// <summary>
        /// Enviar notificacion fin de reemplazo
        /// </summary>
        /// <param name="codigoTrabajador">Codigo de Trabajador</param>
        /// <param name="codigoSuplente">Código de suplente</param>
        /// <param name="profileCorreo">Perfil de correo</param>
        void EnviarNotificacionFinReemplazo(Guid codigoTrabajador, Guid codigoSuplente, string profileCorreo);


        #region Trabajador Suplente

        /// <summary>
        /// Registrar Trabajador Suplente
        /// </summary>
        /// <param name="data">Trabajador Suplente Entity</param>
        /// <returns>Identificador con el resultado</returns>
        int RegistrarSuplenteTrabajador(TrabajadorSuplenteEntity data);

        /// <summary>
        /// Actualizar Trabajador
        /// </summary>
        /// <param name="data">Trabajador Suplente Entity</param>
        /// <returns>Identificador con el resultado</returns>
        int ActualizarSuplenteTrabajador(TrabajadorSuplenteEntity data);

        #endregion
    }
}

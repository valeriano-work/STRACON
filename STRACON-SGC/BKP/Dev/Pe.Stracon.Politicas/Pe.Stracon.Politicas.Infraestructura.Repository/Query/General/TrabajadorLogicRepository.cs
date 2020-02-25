using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using Pe.Stracon.Politicas.Infraestructura.Repository.Base;
using Pe.Stracon.PoliticasCross.Core.Extension;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Pe.Stracon.Politicas.Infraestructura.Repository.Query.General
{
    /// <summary>
    /// Implementación del Repositorio de Trabajador
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150401 <br />
    /// Modificación :           <br />
    /// </remarks>    
    public class TrabajadorLogicRepository : QueryRepository<TrabajadorLogic>, ITrabajadorLogicRepository
    {

        /// <summary>
        /// Busca al trabajador
        /// </summary>
        /// <param name="codigoTrabajador"></param>
        /// <param name="codigoIdentificacion"></param>
        /// <param name="dominio"></param>
        /// <param name="codigoTipoDocumentoIdentidad"></param>
        /// <param name="numeroDocumentoIdentidad"></param>
        /// <param name="nombres"></param>
        /// <param name="numeroPagina"></param>
        /// <param name="registrosPagina"></param>
        /// <returns></returns>
        public List<TrabajadorLogic> BuscarTrabajador(Guid? codigoTrabajador, string codigoIdentificacion, string dominio, string codigoTipoDocumentoIdentidad, string numeroDocumentoIdentidad, string nombres, int numeroPagina = 1, int registrosPagina = -1)
        {
            //codigoTrabajador = null;
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_TRABAJADOR", SqlDbType.UniqueIdentifier) { Value = (object)codigoTrabajador ?? DBNull.Value },
                new SqlParameter("CODIGO_IDENTIFICACION", SqlDbType.VarChar) { Value = (object)codigoIdentificacion ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_DOCUMENTO_IDENTIDAD", SqlDbType.VarChar) { Value = (object)codigoTipoDocumentoIdentidad ?? DBNull.Value},
                new SqlParameter("DOMINIO", SqlDbType.VarChar) { Value = (object)dominio ?? DBNull.Value},
                new SqlParameter("NUMERO_DOCUMENTO_IDENTIDAD", SqlDbType.VarChar) { Value = (object)numeroDocumentoIdentidad ?? DBNull.Value},
                new SqlParameter("NOMBRES", SqlDbType.VarChar) { Value = (object)nombres ?? DBNull.Value},
                new SqlParameter("NUMERO_PAGINA", SqlDbType.Int) { Value = numeroPagina },
                new SqlParameter("TAMANIO_PAGINA", SqlDbType.Int) { Value = registrosPagina }
            };

            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<TrabajadorLogic>("GRL.USP_TRABAJADOR_SEL", parametros).ToList();
            return resultado;
        }


        public List<TrabajadorLogic> BuscarTrabajador1(Guid? codigoTrabajador, string codigoIdentificacion, string dominio, string codigoTipoDocumentoIdentidad, string numeroDocumentoIdentidad, string nombres, int numeroPagina = 1, int registrosPagina = -1)
        {
            //codigoTrabajador = null;
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_TRABAJADOR", SqlDbType.UniqueIdentifier) { Value = (object)codigoTrabajador ?? DBNull.Value },
                new SqlParameter("CODIGO_IDENTIFICACION", SqlDbType.VarChar) { Value = (object)codigoIdentificacion ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_DOCUMENTO_IDENTIDAD", SqlDbType.VarChar) { Value = (object)codigoTipoDocumentoIdentidad ?? DBNull.Value},
                new SqlParameter("DOMINIO", SqlDbType.VarChar) { Value = (object)dominio ?? DBNull.Value},
                new SqlParameter("NUMERO_DOCUMENTO_IDENTIDAD", SqlDbType.VarChar) { Value = (object)numeroDocumentoIdentidad ?? DBNull.Value},
                new SqlParameter("NOMBRES", SqlDbType.VarChar) { Value = (object)nombres ?? DBNull.Value},
                new SqlParameter("NUMERO_PAGINA", SqlDbType.Int) { Value = numeroPagina },
                new SqlParameter("TAMANIO_PAGINA", SqlDbType.Int) { Value = registrosPagina }
            };

            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<TrabajadorLogic>("GRL.USP_TRABAJADOR_SEL", parametros).ToList();
            return resultado;
        }

        /// <summary>
        /// Lista trabajadores
        /// </summary>
        /// <param name="listaCodigos">Lista de códigos de trabajadores</param>
        /// <returns>Lista de trabajadores</returns>
        public List<TrabajadorLogic> ListarTrabajadores(List<Guid?> listaCodigos)
        {
            var lista = listaCodigos.Select(c => new { CODIGO = c }).ToList();

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGOS_TRABAJADORES", SqlDbType.Structured) { Value = lista.ToDataTable(), TypeName = "LISTA_GUID_TYPE"}
            };

            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<TrabajadorLogic>("GRL.USP_TRABAJADOR_LISTA_SEL", parametros).ToList();
            return resultado;
        }

        /// <summary>
        /// Lista trabajadoreUnidadOperativa
        /// </summary>
        /// <param name="codigoUnidadOperativaMatriz"></param>
        /// <param name="codigoTrabajador">Código de trabajador</param>
        /// <returns>Lista de trabajadorUndiadOperativa</returns>
        public List<TrabajadorUnidadOperativaLogic> ListarTrabajadorUnidadOperativa(Guid? codigoUnidadOperativaMatriz, Guid? codigoTrabajador)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA_MATRIZ", SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativaMatriz ?? DBNull.Value },
                new SqlParameter("CODIGO_TRABAJADOR", SqlDbType.UniqueIdentifier) { Value = (object)codigoTrabajador ?? DBNull.Value },
            };

            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<TrabajadorUnidadOperativaLogic>("GRL.USP_TRABAJADOR_UNIDAD_OPERATIVA_SEL", parametros).ToList();
            return resultado;
        }

        /// <summary>
        /// Lista trabajadoreUnidadOperativa
        /// </summary>
        /// <param name="codigoUnidadOperativaMatriz"></param>
        /// <param name="codigoTrabajador">Código de trabajador</param>
        /// <returns>Lista de trabajadorUndiadOperativa</returns>
        public List<TrabajadorUnidadOperativaLogic> ListarTrabajadorUnidadOperativaSAP(Guid? codigoUnidadOperativaMatriz, Guid? codigoTrabajador)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA_MATRIZ", SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativaMatriz ?? DBNull.Value },
                new SqlParameter("CODIGO_TRABAJADOR", SqlDbType.UniqueIdentifier) { Value = (object)codigoTrabajador ?? DBNull.Value },
            };

            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<TrabajadorUnidadOperativaLogic>("GRL.USP_TRABAJADOR_UNIDAD_OPERATIVASAP_SEL", parametros).ToList();
            return resultado;
        }

        /// <summary>
        /// Registrar Trabajador
        /// </summary>
        /// <param name="data">Trabajador Entity</param>
        /// <returns>Identificador con resultado</returns>
        public int RegistrarTrabajador(TrabajadorEntity data)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_TRABAJADOR", SqlDbType.UniqueIdentifier) { Value = (object)data.Codigo ?? DBNull.Value},
                new SqlParameter("CODIGO_IDENTIFICACION", SqlDbType.VarChar) { Value = (object)data.CodigoIdentificacion ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_DOCUMENTO_IDENTIDAD", SqlDbType.VarChar) { Value = (object)data.CodigoTipoDocumentoIdentidad ?? DBNull.Value},
                new SqlParameter("NUMERO_DOCUMENTO_IDENTIDAD", SqlDbType.VarChar) { Value = (object)data.NumeroDocumentoIdentidad ?? DBNull.Value},
                new SqlParameter("APELLIDO_PATERNO", SqlDbType.VarChar) { Value = (object)data.ApellidoPaterno ?? DBNull.Value},
                new SqlParameter("APELLIDO_MATERNO", SqlDbType.VarChar) { Value = (object)data.ApellidoMaterno ?? DBNull.Value},
                new SqlParameter("NOMBRES", SqlDbType.VarChar) { Value = (object)data.Nombres ?? DBNull.Value},
                new SqlParameter("NOMBRE_COMPLETO", SqlDbType.VarChar) { Value = (object)data.NombreCompleto ?? DBNull.Value},
                new SqlParameter("ORGANIZACION", SqlDbType.VarChar) { Value = (object)data.Organizacion ?? DBNull.Value},
                new SqlParameter("DEPARTAMENTO", SqlDbType.VarChar) { Value = (object)data.Departamento ?? DBNull.Value},
                new SqlParameter("CARGO", SqlDbType.VarChar) { Value = (object)data.Cargo ?? DBNull.Value},
                new SqlParameter("TELEFONO_TRABAJO", SqlDbType.VarChar) { Value = (object)data.TelefonoTrabajo ?? DBNull.Value},
                new SqlParameter("ANEXO", SqlDbType.VarChar) { Value = (object)data.Anexo ?? DBNull.Value},
                new SqlParameter("TELEFONO_MOVIL", SqlDbType.VarChar) { Value = (object)data.TelefonoMovil ?? DBNull.Value},
                new SqlParameter("TELEFONO_PERSONAL", SqlDbType.VarChar) { Value = (object)data.TelefonoPersonal ?? DBNull.Value},
                new SqlParameter("CORREO_ELECTRONICO", SqlDbType.VarChar) { Value = (object)data.CorreoElectronico ?? DBNull.Value},
                new SqlParameter("USUARIO_MODIFICACION", SqlDbType.VarChar) { Value = (object)data.UsuarioModificacion ?? DBNull.Value},
                new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.VarChar) { Value = (object)data.TerminalModificacion ?? DBNull.Value}
            };
            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<int>("GRL.USP_TRABAJADOR_INS", parametros).FirstOrDefault();
            return resultado;
        }

        /// <summary>
        /// Actualizar Trabajador
        /// </summary>
        /// <param name="data">Trabajador Entity</param>
        /// <returns>Identificador con resultado</returns>
        public int ActualizarTrabajador(TrabajadorEntity data)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_TRABAJADOR", SqlDbType.UniqueIdentifier) { Value = (object)data.Codigo ?? DBNull.Value},
                new SqlParameter("CODIGO_IDENTIFICACION", SqlDbType.VarChar) { Value = (object)data.CodigoIdentificacion ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_DOCUMENTO_IDENTIDAD", SqlDbType.VarChar) { Value = (object)data.CodigoTipoDocumentoIdentidad ?? DBNull.Value},
                new SqlParameter("NUMERO_DOCUMENTO_IDENTIDAD", SqlDbType.VarChar) { Value = (object)data.NumeroDocumentoIdentidad ?? DBNull.Value},
                new SqlParameter("APELLIDO_PATERNO", SqlDbType.VarChar) { Value = (object)data.ApellidoPaterno ?? DBNull.Value},
                new SqlParameter("APELLIDO_MATERNO", SqlDbType.VarChar) { Value = (object)data.ApellidoMaterno ?? DBNull.Value},
                new SqlParameter("NOMBRES", SqlDbType.VarChar) { Value = (object)data.Nombres ?? DBNull.Value},
                new SqlParameter("NOMBRE_COMPLETO", SqlDbType.VarChar) { Value = (object)data.NombreCompleto ?? DBNull.Value},
                new SqlParameter("ORGANIZACION", SqlDbType.VarChar) { Value = (object)data.Organizacion ?? DBNull.Value},
                new SqlParameter("DEPARTAMENTO", SqlDbType.VarChar) { Value = (object)data.Departamento ?? DBNull.Value},
                new SqlParameter("CARGO", SqlDbType.VarChar) { Value = (object)data.Cargo ?? DBNull.Value},
                new SqlParameter("TELEFONO_TRABAJO", SqlDbType.VarChar) { Value = (object)data.TelefonoTrabajo ?? DBNull.Value},
                new SqlParameter("ANEXO", SqlDbType.VarChar) { Value = (object)data.Anexo ?? DBNull.Value},
                new SqlParameter("TELEFONO_MOVIL", SqlDbType.VarChar) { Value = (object)data.TelefonoMovil ?? DBNull.Value},
                new SqlParameter("TELEFONO_PERSONAL", SqlDbType.VarChar) { Value = (object)data.TelefonoPersonal ?? DBNull.Value},
                new SqlParameter("CORREO_ELECTRONICO", SqlDbType.VarChar) { Value = (object)data.CorreoElectronico ?? DBNull.Value},
                new SqlParameter("ESTADO_REGISTRO", SqlDbType.VarChar) { Value = (object)data.EstadoRegistro ?? DBNull.Value},
                new SqlParameter("USUARIO_MODIFICACION", SqlDbType.VarChar) { Value = (object)data.UsuarioModificacion ?? DBNull.Value},
                new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.VarChar) { Value = (object)data.TerminalModificacion ?? DBNull.Value}
            };
            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<int>("GRL.USP_TRABAJADOR_UPD", parametros).FirstOrDefault();
            return resultado;
        }

        /// <summary>
        /// Lista de Trabajadores con información mínima.
        /// </summary>
        /// <param name="dominio">dominio del trabajador</param>
        /// <param name="codigoIdentificacion">codigo identificador del trabajador</param>
        /// <param name="NombreCompleto">nombre completo del trabajador</param>
        /// <param name="correoElectronico">correo electrónico del trabajador</param>
        /// <returns>Lista con resultados</returns>
        public List<TrabajadorLogic> BuscarTrabajadorDatoMinimo(string dominio, string codigoIdentificacion, string NombreCompleto, string correoElectronico)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("DOMINIO", SqlDbType.VarChar) { Value = (object)dominio ?? DBNull.Value},
                new SqlParameter("CODIGO_IDENTIFICACION", SqlDbType.VarChar) { Value = (object)codigoIdentificacion ?? DBNull.Value},
                new SqlParameter("NOMBRE_COMPLETO", SqlDbType.VarChar) { Value = (object)NombreCompleto ?? DBNull.Value},
                new SqlParameter("CORREO_ELECTRONICO", SqlDbType.VarChar) { Value = (object)correoElectronico ?? DBNull.Value}
            };

            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<TrabajadorLogic>("GRL.USP_TRABAJADOR_DATOMINIMO_SEL", parametros).ToList();
            return resultado;
        }

        /// <summary>
        /// Obtiene la firma del trabajadores.
        /// </summary>
        /// <param name="trabajador">TrabajadorEntity</param>
        /// <returns>Lista con resultados</returns>
        public TrabajadorLogic BuscarFirmaTrabajador(TrabajadorEntity trabajador)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_TRABAJADOR", SqlDbType.UniqueIdentifier) { Value = (object) trabajador.Codigo ?? DBNull.Value},
            };
            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<TrabajadorLogic>("GRL.USP_TRABAJADOR_FIRMA_POR_TRABAJADOR_SEL", parametros).ToList();
            return resultado.FirstOrDefault();
        }
        /// <summary>
        /// Notificar inicios y cierres de periodo.
        /// </summary>
        /// <param name="listaTrabajadores">Lista de trabajaores</param>
        /// <param name="codigoNotificar">tipo de notificacion</param>
        /// <param name="anioPeriodo">Anio de Periodo</param>
        /// <param name="mesPeriodo"> Mes del Periodo </param>
        /// <param name="nombreActividad"></param>
        /// <param name="codigoSistema">Código del sistema</param>
        /// <param name="profileCorreo">Perfil de la cuenta que ejecuta la notificación.</param>
        /// <returns>Identificador de proceso</returns>
        public int NotificaParticipanteCalendarizacion(List<Guid?> listaTrabajadores, string codigoNotificar, string anioPeriodo, string mesPeriodo,
                                                        string nombreActividad, Guid codigoSistema, string profileCorreo)
        {
            var lista = listaTrabajadores.Select(c => new { CODIGO = c }).ToList();

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGOS_TRABAJADORES", SqlDbType.Structured) { Value = lista.ToDataTable(), TypeName = "LISTA_GUID_TYPE"},
                new SqlParameter("CODIGO_NOTIFICACION", SqlDbType.VarChar) { Value = (object)codigoNotificar ?? DBNull.Value},
                new SqlParameter("ANIO_PERIODO", SqlDbType.VarChar) { Value = (object)anioPeriodo ?? DBNull.Value},
                new SqlParameter("MES_PERIODO", SqlDbType.VarChar) { Value = (object)mesPeriodo ?? DBNull.Value},
                new SqlParameter("NOMBRE_ACTIVIDAD", SqlDbType.VarChar) { Value = (object)nombreActividad ?? DBNull.Value},
                new SqlParameter("CODIGO_SISTEMA", SqlDbType.UniqueIdentifier) { Value = (object)codigoSistema ?? DBNull.Value},
                new SqlParameter("PROFILE_CORREO", SqlDbType.VarChar) { Value = (object)profileCorreo ?? DBNull.Value}
            };
            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<int>("GRL.USP_NOTIFICAR_CALENDARIZACION", parametros).FirstOrDefault();
            return resultado;
        }

        /// <summary>
        /// Lista trabajador suplente
        /// </summary>
        /// <param name="codigoTrabajador">Código de trabajador</param>
        /// <returns>Lista de trabajador suplente</returns>
        public List<TrabajadorSuplenteLogic> ListarTrabajadorSuplente(Guid codigoTrabajador)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_TRABAJADOR", SqlDbType.UniqueIdentifier) { Value = (object)codigoTrabajador ?? DBNull.Value },
            };

            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<TrabajadorSuplenteLogic>("GRL.USP_TRABAJADOR_SUPLENTE_SEL", parametros).ToList();
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoTrabajador"></param>
        /// <param name="codigoSuplente"></param>
        /// <param name="profileCorreo"></param>
        public void EnviarNotificacionFinReemplazo(Guid codigoTrabajador, Guid codigoSuplente, string profileCorreo)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_TRABAJADOR",SqlDbType.UniqueIdentifier) { Value = (object)codigoTrabajador ?? DBNull.Value},
                new SqlParameter("CODIGO_SUPLENTE",SqlDbType.UniqueIdentifier) { Value = (object)codigoSuplente ?? DBNull.Value},
                new SqlParameter("PROFILE_CORREO",SqlDbType.VarChar) { Value = (object)profileCorreo ?? DBNull.Value}
            };
            var result = this.dataBaseProvider.ExecuteStoreProcedure<int>("GRL.USP_ENVIAR_NOTIFICACION_FIN_REEMPLAZO_SEL", parametros).ToList();
        }

        #region Trabajador Suplente

        /// <summary>
        /// Registrar Trabajador Suplente
        /// </summary>
        /// <param name="data">Trabajador Entity</param>
        /// <returns>Identificador con resultado</returns>
        public int RegistrarSuplenteTrabajador(TrabajadorSuplenteEntity data)
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("CODIGO_TRABAJADOR", SqlDbType.UniqueIdentifier) { Value = (object)data.CodigoTrabajador ?? DBNull.Value},
                    new SqlParameter("CODIGO_SUPLENTE", SqlDbType.UniqueIdentifier)   { Value = (object)data.CodigoSuplente ?? DBNull.Value},
                    new SqlParameter("FECHA_INICIO", SqlDbType.DateTime)              { Value = (object)data.FechaInicio ?? DBNull.Value},
                    new SqlParameter("FECHA_FIN", SqlDbType.DateTime)                 { Value = (object)data.FechaFin ?? DBNull.Value},
                    new SqlParameter("ACTIVO", SqlDbType.Bit)                         { Value = (object)data.Activo ?? DBNull.Value},
                    new SqlParameter("EJECUTADO", SqlDbType.Bit)                      { Value = (object)data.Ejecutado ?? DBNull.Value},
                    new SqlParameter("PERFILES_AGREGADOS", SqlDbType.VarChar)         { Value = (object)data.PerfilesAgregados ?? DBNull.Value},
                    new SqlParameter("USUARIO_CREACION", SqlDbType.NVarChar)          { Value = (object)data.UsuarioCreacion ?? DBNull.Value},
                    new SqlParameter("TERMINAL_CREACION", SqlDbType.NVarChar)        { Value = (object)data.TerminalCreacion ?? DBNull.Value}
                };

                var resultado = this.dataBaseProvider.ExecuteStoreProcedure<int>("[GRL].[USP_TRABAJADOR_SUPLENTE_INS]", parametros).FirstOrDefault();
                return resultado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Actualizar Trabajador Suplente
        /// </summary>
        /// <param name="data">Trabajador Suplente Entity</param>
        /// <returns>Identificador con resultado</returns>
        public int ActualizarSuplenteTrabajador(TrabajadorSuplenteEntity data)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_TRABAJADOR", SqlDbType.UniqueIdentifier)   { Value = (object)data.CodigoTrabajador ?? DBNull.Value},
                new SqlParameter("CODIGO_SUPLENTE", SqlDbType.UniqueIdentifier)     { Value = (object)data.CodigoSuplente ?? DBNull.Value},
                new SqlParameter("FECHA_INICIO", SqlDbType.DateTime)                { Value = (object)data.FechaInicio ?? DBNull.Value},
                new SqlParameter("FECHA_FIN", SqlDbType.DateTime)                   { Value = (object)data.FechaFin ?? DBNull.Value},
                new SqlParameter("ACTIVO", SqlDbType.Bit)                           { Value = (object)data.Activo ?? DBNull.Value},
                new SqlParameter("EJECUTADO", SqlDbType.Bit)                        { Value = (object)data.Ejecutado ?? DBNull.Value},
                new SqlParameter("PERFILES_AGREGADOS", SqlDbType.VarChar)           { Value = (object)data.PerfilesAgregados ?? DBNull.Value},
                new SqlParameter("USUARIO_MODIFICACION", SqlDbType.NVarChar)        { Value = (object)data.UsuarioModificacion ?? DBNull.Value},
                new SqlParameter("TERMINAL_MODIFICACION", SqlDbType.NVarChar)       { Value = (object)data.TerminalModificacion ?? DBNull.Value}
            };
            var resultado = this.dataBaseProvider.ExecuteStoreProcedure<int>("[GRL].[USP_TRABAJADOR_SUPLENTE_UPD]", parametros).FirstOrDefault();
            return resultado;
        }



        #endregion

    }
}

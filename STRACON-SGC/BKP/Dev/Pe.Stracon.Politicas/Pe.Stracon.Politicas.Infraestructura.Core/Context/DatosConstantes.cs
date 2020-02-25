
using System.Configuration;
namespace Pe.Stracon.Politicas.Infraestructura.Core.Context
{
    /// <summary>
    /// Clase de datos constantes de la Base datos
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20140310 <br />
    /// Modificación:            <br />
    /// </remarks> 
    public sealed class DatosConstantes
    {
        /// <summary>
        /// Constantes de parametros generales
        /// </summary>
        public sealed class ParametrosGenerales 
        {
            /// <summary>
            /// Código de parametro general tipo nivel
            /// </summary>
            public const string CodigoNivel = "00001";
            public const string TipoUnidadOperativa = "00002";
            public const string TipoDocumentoIdentidad = "00003";
            public const string TipoArchivoPermitido = "00004";
            public const string FormaGeneracion = "00005";
            public const string SistemaIntegracion = "00006";
            public const string OperacionIntegracion = "00007";
            public const string TipoEvidencia = "00008";
            public const string TipoActividad = "";
            public const string EstadoCalendarizacion = "00009";
            public const string EstadoActividad = "00010";
            public const string EstadoCumplimiento = "00011";
            public const string EstadoEvidencia = "00012";
            public const string TipoServicio = "00013";
            public const string TipoContrato = "00014";
            public const string DocAdjunto = "00050";
            public const string ModCon = "00051";
            public const string FormaContrato = "00015";
            public const string RepositorioSharePoint = "00016";
            public const string TipoNotificacionSCC = "00017";
            public const string CuentaNotificacionSCC = "00018";
            public const string DominioEmpresa = "00019";
            public const string ConfiguracionSharePoint = "00020";
            public const string CredencialAcceso = "00021";
            public const string TipoDocumentoContrato = "00022";
            public const string TipoDocumentoRequerimiento = "00048";
            public const string EstadoVigencia = "00023";
            public const string EstadoVigenciaRequerimiento = "00049";
            public const string TipoRespuestaObservacion = "00025";
            public const string MontoMinimoControl = "00026";
            public const string EstadoContrato = "00027";
            public const string EstadoEdicion = "00028";
            public const string Moneda = "00029";
            public const string RepositorioSharePointSGC = "00030";
            public const string AlertaVencimientoContrato = "00031";
            public const string TipoOrden = "00032";
            public const string MontoAcumuladoParaContrato = "00033";
            public const string CuentaNotificacionSGC = "00034";
            public const string URLSistemas = "00035";
            public const string TipoTarifaBien = "00036";
            public const string PeriodoAlquilerBien = "00037";
            public const string TipoDeBien = "00038";
            public const string ConfiguracionGeneracionContratos = "00039";
            public const string TipoNotificacion = "00040";
            public const string Valor = "00041";
            public const string TipoConsulta = "00042";
            public const string Area = "00043";
            public const string EstadoConsulta = "00044";
        }

        /// <summary>
        /// Constantes de Empresa
        /// </summary>
        public sealed class Empresa
        {
            /// <summary>
            /// Codigo de la Stracon
            /// </summary>
            public const string CodigoStracon = "190E8EF5-11E2-45C7-BC4F-8A673B4640B5";
        }

        /// <summary>
        /// Constantes de Sistema
        /// </summary>
        public sealed class Sistema
        {
            /// <summary>
            /// Codigo del Sistema SCC
            /// </summary>
            public const string CodigoSCC = "9DE41BC7-3A1C-481B-821B-FFE44AD9F0D5";
            /// <summary>
            /// Codigo del Sistema SGC
            /// </summary>
            public const string CodigoSGC = "A4C353EF-A593-4E59-8366-CA1BEC446115";
            /// <summary>
            /// Codigo del Sistema Trasciende
            /// </summary>
            public const string CodigoTRA = "390480EE-2D28-456D-98FE-05BC82316B8C";
        }

        /// <summary>
        /// Constantes de Estado de Registro
        /// </summary>
        public sealed class EstadoRegistro
        {
            /// <summary>
            /// Estado de Activo
            /// </summary>
            public const string Activo = "1";
            /// <summary>
            /// Estado de Inactivo
            /// </summary>
            public const string Inactivo = "0";
        }

        /// <summary>
        /// Constantes Formato
        /// </summary>
        public sealed class Formato
        {
            /// <summary>
            /// Formato de Fecha
            /// </summary>
            public const string FormatoFecha = "dd/MM/yyyy";

            /// <summary>
            /// Formato de Fecha de Selector
            /// </summary>
            public const string FormatoFechaSelector = "dd/mm/yy";

            /// <summary>
            /// Formato de Fecha de Mascara
            /// </summary>
            public const string FormatoFechaMascara = "00/00/0000";
        }

        /// <summary>
        /// Constantes de Tipo de Parámetro
        /// </summary>
        public sealed class TipoParametro
        {
            /// <summary>
            /// Tipo de Parámetro Común
            /// </summary>
            public const string Comun = "C";
            /// <summary>
            /// Tipo de Parámetro Sistema
            /// </summary>
            public const string Sistema = "S";
            /// <summary>
            /// Tipo de Parámetro Funcional
            /// </summary>
            public const string Funcional = "F";
        }

        /// <summary>
        /// Constantes de Tipo de Dato
        /// </summary>
        public sealed class TipoDato
        {
            /// <summary>
            /// Tipo Decimal
            /// </summary>
            public const string Decimal = "DEC";
            /// <summary>
            /// Tipo Encriptado
            /// </summary>
            public const string Encriptado = "ENC";
            /// <summary>
            /// Tipo Entero
            /// </summary>
            public const string Entero = "ENT";
            /// <summary>
            /// Tipo Fecha
            /// </summary>
            public const string Fecha = "FEC";
            /// <summary>
            /// Tipo Texto
            /// </summary>
            public const string Texto = "TEX";
        }

        /// <summary>
        /// Tipo de Visualización de Unidad Operativa
        /// </summary>
        public sealed class TipoVisualizacionUnidadOperativa
        {
            /// <summary>
            /// Responsable
            /// </summary>
            public const string Responsable = "RES";
            /// <summary>
            /// Representantes y Dirección
            /// </summary>
            public const string RepresentanteDireccion = "REPDIR";
        }

        /// <summary>
        /// Tipo de Documento de Identidad
        /// </summary>
        public sealed class TipoDocumentoIdentidad
        {
            /// <summary>
            /// Tipo Dni
            /// </summary>
            public const string Dni = "01";
            /// <summary>
            /// Tipo RUC
            /// </summary>
            public const string Ruc = "02";
        }

        /// <summary>
        /// Constantes de Niveles
        /// </summary>
        public sealed class Nivel
        {
            /// <summary>
            /// Nivel de Empresa Matriz
            /// </summary>
            public static readonly string EmpresaMatriz = "01";
            /// <summary>
            /// Nivel de Empresa
            /// </summary>
            public static readonly string Empresa = "02";
            /// <summary>
            /// Nivel de Proyecto
            /// </summary>
            public static readonly string Proyecto = "03";
        }
        /// <summary>
        /// Configuración de la capa de presentación
        /// </summary>
        public sealed class ConfiguracionPresentacion
        {
            /// <summary>
            /// Titulo de la aplicación
            /// </summary>
            public static readonly string TituloAplicacion = ConfigurationManager.AppSettings["TitloSistema"];
        }
        /// <summary>
        /// Configuración de file server
        /// </summary>
        public sealed class ConfiguracionFileServer
        {
            /// <summary>
            /// Ubicacion de fotos del colaborador
            /// </summary>
            public static readonly string UbicacionFotoColaborador = ConfigurationManager.AppSettings["FileServerUbicacionFotoColaborador"];
        }

        /// <summary>
        /// Configuración de la Nombre DataBase Politicas
        /// </summary>
        public sealed class ConfiguracionNombreDataBasePoliticas
        {
            /// <summary>
            /// Nombre Base Datos
            /// </summary>
            public static readonly string NombreBaseDatosPoliticas = ConfigurationManager.AppSettings["NombreBaseDatosPoliticas"];
        }
    }
}
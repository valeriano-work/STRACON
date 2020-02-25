using System.Collections.Generic;
using System.Configuration;
namespace Pe.Stracon.SGC.Infraestructura.Core.Context
{
    /// <summary>
    /// Clase de datos constantes de la Base datos
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150424 <br />
    /// Modificación:            <br />
    /// </remarks> 
    public class DatosConstantes
    {
        /// <summary>
        /// Constantes de Estado de Registro
        /// </summary>
        public sealed class EstadoRegistro
        {
            /// <summary>
            /// Estado de Registro
            /// </summary>
            public static readonly string Activo = "1";

            /// <summary>
            /// Estado Inactivo
            /// </summary>
            public static readonly string Inactivo = "0";
        }

        /// <summary>
        /// Constantes de Estado de Vigencia
        /// </summary>
        public sealed class EstadoVigencia
        {
            /// <summary>
            /// Estado Vigente
            /// </summary>
            public static readonly string Vigente = "V";

            /// <summary>
            /// Estado Próximo
            /// </summary>
            public static readonly string Proximo = "P";

            /// <summary>
            /// Estado Histórico
            /// </summary>
            public static readonly string Historico = "H";
        }

        /// <summary>
        /// Constantes Formato
        /// </summary>
        public sealed class Formato
        {
            /// <summary>
            /// Formato de Fecha
            /// </summary>
            public static readonly string FormatoFecha = "dd/MM/yyyy";

            /// <summary>
            /// Formato de Fecha de Selector
            /// </summary>
            public static readonly string FormatoFechaSelector = "dd/mm/yy";

            /// <summary>
            /// Formato de Fecha de Mascara
            /// </summary>
            public static readonly string FormatoFechaMascara = "00/00/0000";

            /// <summary>
            /// Formato de Hora
            /// </summary>
            public static readonly string FormatoHora = "hh:mm tt";

            /// <summary>
            /// Formato de Número Entero
            /// </summary>
            public static readonly string FormatoNumeroEntero = "#,##0";

            /// <summary>
            /// Formato de Número Decimal
            /// </summary>
            public static readonly string FormatoNumeroDecimal = "#,##0.00";
            /// <summary>
            /// Formato de número de contrato
            /// </summary>
            public static readonly string FormatoNumeroContrato = "{0}.{1}.{2}.{3}.{4}";
            /// <summary>
            /// Formato de número de contrato
            /// </summary>
            public static readonly string SeparadorFormatoNumeroContrato = ".";
            /// <summary>
            /// Formato de número de adenda
            /// </summary>
            public static readonly string FormatoNumeroAdenda = "{0}-A{1}";
        }

        /// <summary>
        /// Constantes del metodo de obtener proveedor del servicio de oracle
        /// </summary>
        public sealed class OperacionObtenerProveedorServicioOracle
        {
            /// <summary>
            /// Columna Ruc
            /// </summary>
            public const string ColumnaRuc = "RUC";

            /// <summary>
            /// Formato de Fecha de Selector
            /// </summary>
            public const string ColumnaNombre = "NOMBRE";
        }

        /// <summary>
        /// Constantes de Niveles
        /// </summary>
        public sealed class Nivel
        {
            /// <summary>
            /// Nivel de Proyecto
            /// </summary>
            public static readonly string Proyecto = "03";
        }

        /// <summary>
        /// Constantes de Sesiones
        /// </summary>
        public sealed class Sesiones
        {
            /// <summary>
            /// Sesión para Parrafos por Contrato
            /// </summary>
            public static readonly string SessionParrafoContrato = "SessionParrafosPorContrato";
            /// <summary>
            /// Sesión para los tipos de servicio de contrato
            /// </summary>
            public static readonly string SessionTipoServicio = "SessionTipoServicio";
            /// <summary>
            /// Sesión para los tipos de requerimiento del contrato
            /// </summary>
            public static readonly string SessionTipoRequerimiento = "SessionTipoRequerimiento";
            /// <summary>
            /// Sesión para Tipos de Bien
            /// </summary>
            public static readonly string SessionTipoBien = "SessionTipoBien";
            /// <summary>
            /// Sesión para tipos de tarifa
            /// </summary>
            public static readonly string SessionTipoTarifaBien = "SessionTipoTarifaBien";
            /// <summary>
            /// Sesión para Periodo de Alquiler
            /// </summary>
            public static readonly string SessionPeriodoAlquilerBien = "SessionPeriodoAlquilerBien";
            /// <summary>
            /// Sesión para Periodo de Alquiler
            /// </summary>
            public static readonly string SessionMonedaBien = "SessionMonedaBien";
            /// <summary>
            /// Sesión para el tipo de contenido de datos del bien
            /// </summary>
            public static readonly string SessionContenidoBien = "SessionContenidoBien";

        }

        /// <summary>
        /// Constantes de Tipos de Documentos
        /// </summary>
        public sealed class TipoDocumento
        {
            /// <summary>
            /// Tipo de Documento Contrato
            /// </summary>
            public static readonly string Contrato = "C";

            /// <summary>
            /// Tipo de Documento Adenda
            /// </summary>
            public static readonly string Adenda = "A";
        }
        /// <summary>
        /// Constantes de Tipos de Variables
        /// </summary>
        public sealed class TipoVariable
        {
            /// <summary>
            /// Variable de Tipo Texto
            /// </summary>
            public const string Texto = "T";

            /// <summary>
            /// Variable de Tipo Número
            /// </summary>
            public const string Numero = "N";

            /// <summary>
            /// Variable de Tipo Fecha
            /// </summary>
            public const string Fecha = "F";

            /// <summary>
            /// Variable de Tipo Imagen
            /// </summary>
            public const string Imagen = "I";

            /// <summary>
            /// Variable de Tipo Lista
            /// </summary>
            public const string Lista = "L";

            /// <summary>
            /// Variable de Tipo Lista de Equipos
            /// </summary>
            public const string ListaEquipo = "LE";

            /// <summary>
            /// Variable de Tipo Tabla
            /// </summary>
            public const string Tabla = "TBL";

            /// <summary>
            /// Variable de Tipo Bien
            /// </summary>
            public const string Bien = "BN";

            /// <summary>
            /// Variable de tipo firmante
            /// </summary>
            public const string Firmante = "FIR";

            /// <summary>
            /// Variable de tipo firmante Stracon
            /// </summary>
            public const string FirmanteStracon = "FIRS";
        }

        /// <summary>
        /// Constantes de Descripción de Tipos de Variables
        /// </summary>
        public sealed class DescripcionTipoVariable
        {
            /// <summary>
            /// Descripción de Variable de Tipo Texto
            /// </summary>
            public const string Texto = "Texto";

            /// <summary>
            /// Descripción de Variable de Tipo Número
            /// </summary>
            public const string Numero = "Número";

            /// <summary>
            /// Descripción de Variable de Tipo Fecha
            /// </summary>
            public const string Fecha = "Fecha";

            /// <summary>
            /// Descripción de Variable de Tipo Imagen
            /// </summary>
            public const string Imagen = "Imagen";

            /// <summary>
            /// Descripción de Variable de Tipo Lista
            /// </summary>
            public const string Lista = "Lista";

            /// <summary>
            /// Descripción de Variable de Tipo Lista de Equipos
            /// </summary>
            public const string ListaEquipo = "Lista de Equipos";

            /// <summary>
            /// Descripción de Variable de Tipo Tabla
            /// </summary>
            public const string Tabla = "Tabla";

            /// <summary>
            /// Descripción de Variable de Tipo Bien
            /// </summary>
            public const string Bien = "Bien";

            /// <summary>
            /// Descripción de variable de Tipo Firmante
            /// </summary>
            public const string Firmante = "Firmante";

            /// <summary>
            /// Descripción de variable de Tipo Firmante stracon
            /// </summary>
            public const string FirmanteStracon = "Firmante Stracon";
        }

        /// <summary>
        /// Constantes de Estados de Edición de Contratos
        /// </summary>
        public sealed class CodigoEstadoEdicion
        {
            /// <summary>
            /// Codigo de Estado de Edición Creación
            /// </summary>
            public static string Creacion = "C";

            /// <summary>
            /// Código de Estado de Edición Solicitada
            /// </summary>
            public static string Solicitada = "S";
            
            /// <summary>
            /// Código de Estado de Edición Solicitud Autorizada
            /// </summary>
            public static string SolicitudAutorizada = "SA";

            /// <summary>
            /// Código de Estado de Edición Solicitud Denegada
            /// </summary>
            public static string SolicitudDenegada = "SD";

            /// <summary>
            /// Código de Estado de Edición Editada
            /// </summary>
            public static string Editada = "E";
            
            /// <summary>
            /// Código de Estado de Edición Aprobada
            /// </summary>
            public static readonly string EdicionAprobada = "EA";
            
            /// <summary>
            /// Código de Estado de Edición Rechazada
            /// </summary>
            public static readonly string EdicionRechazada = "ER";

            /// <summary>
            /// Código de Estado de Edición Apelar Rechazo
            /// </summary>
            public static readonly string ApelarRechazo = "AR";

            /// <summary>
            /// Código de Estado de Edición parcial
            /// </summary>
            public static string EdicionParcial = "EP";

            /// <summary>
            /// Código de Estado de Revisión Revisada
            /// </summary>
            public static readonly string RevisionRevisada = "R";

            /// <summary>
            /// Código de Estado de Revisión Aprobada
            /// </summary>
            public static readonly string RevisionAprobada = "RA";

            /// <summary>
            /// Código de Estado de Revisión Rechazada
            /// </summary>
            public static readonly string RevisionRechazada = "RR";
        }
        /// <summary>
        /// Características de los archivos del contrato
        /// </summary>
        public sealed class ArchivosContrato
        {
            /// <summary>
            /// Extension de archivo
            /// </summary>
            public static readonly string ExtensionValidaCarga = "pdf";

            /// <summary>
            /// Descripción de la biblioteca de Documentos
            /// </summary>
            public static readonly string DescripcionBibliotecaSHP = "Biblioteca para archivos de Sistema Gestión Contractual";
        }
        /// <summary>
        /// Etiquetas HTML del contenido del Footer
        /// </summary>
        public sealed class ContenidoPiePaginaContrato
        {
            /// <summary>
            /// Contenido del Responsable
            /// </summary>
            public static readonly string EtiquetaResponsable = "Último Aprobador: {0}";
            /// <summary>
            /// Contenido de la fecha de aprobación.
            /// </summary>
            public static readonly string EtiquetaFechaAprobacion = "Fecha de Última Aprobación: {0}";
            /// <summary>
            /// Etiqueta COPIA NO OFICIAL
            /// </summary>
            public static readonly string EtiquetaCopiaNoOficial = "COPIA NO OFICIAL";
            /// <summary>
            /// Clase HTML que contiene al párrafo de pie de página del contrato.
            /// </summary>
            public static readonly string ClassDivPiePagina = "footerPdf";
        }
        /// <summary>
        /// Constantes de los Estados de Contratos Estadio
        /// </summary>
        public sealed class CodigoEstadoContratoEstadio
        {
            /// <summary>
            /// Estado de Aprobado
            /// </summary>
            public static readonly string Aprobado = "A";

            /// <summary>
            /// Estado de Iniciado
            /// </summary>
            public static readonly string Iniciado = "I";
        }

        /// <summary>
        /// Constantes de las Formas de Edición de Contrato
        /// </summary>
        public sealed class FormaEdicion
        {
            /// <summary>
            /// Forma de Edición Flexible
            /// </summary>
            public const string Flexible = "F";

            /// <summary>
            /// Forma de Edición Cerrado
            /// </summary>
            public const string Cerrado = "C";
        }

        /// <summary>
        /// Constantes de los Estados de Contratos
        /// </summary>
        public sealed class EstadoContrato
        {
            /// <summary>
            /// Estado de Edición
            /// </summary>
            public static string Edicion = "E";

            /// <summary>
            /// Estado de Aprobación
            /// </summary>
            public static string Aprobacion = "A";

            /// <summary>
            /// Estado Vigente
            /// </summary>
            public static string Vigente = "V";

            /// <summary>
            /// Estado Terminado
            /// </summary>
            public static string Terminado = "T";

            /// <summary>
            /// Estado Vencido
            /// </summary>
            public static string Vencido = "C";

            /// <summary>
            /// Estado de Revisión
            /// </summary>
            public static string Revision = "R";

            /// <summary>
            /// Estado Agregado desde el 01/08/2018
            /// </summary>
            public static string Resuelto = "RS";
        }

        public sealed class TipoValidacionContratoResolucion
        {
            public static int No_Cumple = 0;

            public static int Cumple_Carga = 1;

            public static int Cargado_Modo_Lectura = 2;
        }

        /// <summary>
        /// Constantes de los Tipos de Documentos de Identificación
        /// </summary>
        public sealed class TipoDocumentoIdentificacion
        {
            /// <summary>
            /// Tipo de Documento Ruc
            /// </summary>
            public static string Ruc = "02";
        }

        /// <summary>
        /// Constantes de los Montos Mínimos de Control
        /// </summary>
        public sealed class MontoMinimoControl
        {
            /// <summary>
            /// Monto Mínimo en Dólares
            /// </summary>
            public static string Dolares = "01";

            /// <summary>
            /// Monto Mínimo en Soles
            /// </summary>
            public static string Soles = "02";
        }

        /// <summary>
        /// Constantes de Tipo de Tarifa
        /// </summary>
        public sealed class TipoTarifa
        {
            /// <summary>
            /// Escalonado
            /// </summary>
            public static string Escalonado = "E";

            /// <summary>
            /// Fijo
            /// </summary>
            public static string Fijo = "F";
        }
        /// <summary>
        /// Constantes de Identificador de variables
        /// </summary>
        public sealed class IdentificadorVariable
        {
            /// <summary>
            /// Almohadilla
            /// </summary>
            public static string Almohadilla = "##";
        }

        /// <summary>
        /// Clase de enumerado que contiene los nombres de archivo para los reportes del sistema
        /// </summary>
        public static class ReporteNombreArchivo
        {
            /// <summary>
            /// Nombre del Reporte de Tiempos de Atención
            /// </summary>
            public static readonly string ReporteTiempoAtencion = "TiempoAtencion";
            /// <summary>
            /// Nombre del Reporte de Hoja de Ruta
            /// </summary>
            public static readonly string ReporteHojaRuta = "HojaRuta";
            /// <summary>
            /// Nombre del Reporte de Estadio Actual de Contrato
            /// </summary>
            public static readonly string ReporteEstadioActualContrato = "EstadioActualContrato";
            /// <summary>
            /// Nombre del Reporte de Contrato Pendiente de Elaborar
            /// </summary>
            public static readonly string ReporteContratoPendienteElaborar = "ContratoPendienteElaborar";
            /// <summary>
            /// Nombre del Reporte de Contrato por Vencer
            /// </summary>
            public static readonly string ReporteContratoPorVencer = "ContratoPorVencer";
            /// <summary>
            /// Nombre del Reporte de Contrato por Estadio
            /// </summary>
            public static readonly string ReporteContratoPorEstadio = "ContratoPorEstadio";
            /// <summary>
            /// Nombre del Reporte de Bienes
            /// </summary>
            public static readonly string ReporteBienesContrato = "BienesContrato";
            /// <summary>
            /// Nombre del Reporte Listado de Contrato
            /// </summary>
            public static readonly string ReporteListadoContrato = "ListadoContrato";
            /// <summary>
            /// Nombre del Reporte de Contrato por Finalizar
            /// </summary>
            public static readonly string ReporteContratoPorFinalizar = "ContratoPorFinalizar";
            /// <summary>
            /// Nombre del Reporte de Consultas
            /// </summary>
            public static readonly string ReporteConsulta = "Consulta";
            /// <summary>
            /// Nombre del Reporte de Contratos Eliminados
            /// </summary>
            public static readonly string ReporteContratosEliminados = "ContratoEliminado";
            /// <summary>
            /// ContratoObservadoAprobado
            /// </summary>
            public static readonly string ReporteContratoObservadoAprobado = "ContratoObservadoAprobado";
        }

        /// <summary>
        /// Constantes de los Identificadores de las Variables por Defecto
        /// </summary>
        public static class IdentificadorVariableDefecto
        {
            /// <summary>
            /// Identificador para Nombre de Proyecto
            /// </summary>
            public const string NombreProyecto = "##nombre_proyecto";
            /// <summary>
            /// Identificador para Número de Contrato
            /// </summary>
            public const string NumeroContrato = "##numero_contrato";
            /// <summary>
            /// Identificador para Nombre de Empresa
            /// </summary>
            public const string NombreEmpresa = "##nombre_empresa";
            /// <summary>
            /// Identificador para DNI del Primer Representante de Empresa
            /// </summary>
            public const string DniPrimerRepresentanteEmpresa = "##dni_primer_representante_empresa";
            /// <summary>
            /// Identificador para Primer Representante de Empresa
            /// </summary>
            public const string PrimerRepresentanteEmpresa = "##primer_representante_empresa";
            /// <summary>
            /// Identificador para DNI del Segundo Representante de Empresa
            /// </summary>
            public const string DniSegundoRepresentanteEmpresa = "##dni_segundo_representante_empresa";
            /// <summary>
            /// Identificador para Segundo Representante de Empresa
            /// </summary>
            public const string SegundoRepresentanteEmpresa = "##segundo_representante_empresa";
            /// <summary>
            /// Identificador para RUC de Proveedor
            /// </summary>
            public const string RucProveedor = "##ruc_proveedor";
            /// <summary>
            /// Identificador para Nombre de Proveedor
            /// </summary>
            public const string NombreProveedor = "##nombre_proveedor";
            /// <summary>
            /// Identificador para Nombre de Proveedor
            /// </summary>
            public const string ProveedorNombre = "##proveedor_nombre";
            /// <summary>
            /// Identificador para Moneda del Contrato
            /// </summary>
            public const string MonedaContrato = "##moneda_contrato";
            /// <summary>
            /// Identificador para Monto del Contrato
            /// </summary>
            public const string MontoContrato = "##monto_maximo";
            /// <summary>
            /// Identificador para Fecha de Inicio de Contrato
            /// </summary>
            public const string FechaInicioContrato = "##contrato_fecha_inicio";
            /// <summary>
            /// Identificador para Fecha de Fin de Contrato
            /// </summary>
            public const string FechaFinContrato = "##contrato_fecha_fin";
            /// <summary>
            /// Identificador para Fecha Actual
            /// </summary>
            public const string FechaActual = "##fecha_actual";
            /// <summary>
            /// Identificador para Fecha Actual en Letras
            /// </summary>
            public const string FechaActualLetra = "##fecha_actual_letras";
            /// <summary>
            /// Identificador para Dirección de Empresa
            /// </summary>
            public const string DireccionEmpresa = "##direccion_empresa";
            /// <summary>
            /// Identificador para Dirección de Proyecto
            /// </summary>
            public const string DireccionProyecto = "##direccion_proyecto";
            /// <summary>
            /// Identificador para los firmantes por defecto de STRACON
            /// </summary>
            public const string FirmaSGC = "##firma_stracon";
            /// <summary>
            /// Identificador para plazo de vigencia desde
            /// </summary>
            public const string PlazoVigenciaDesde = "##plazo_vigencia_desde";
            /// <summary>
            /// Identificador para plazo de vigencia hasta
            /// </summary>
            public const string PlazoVigenciaHasta = "##plazo_vigencia_hasta";
            /// <summary>
            /// Identificador para el domicilio del proveedor
            /// </summary>
            public const string ProveedorDomicilio = "##proveedor_domicilio";

            /// <summary>
            /// Identificador para el locador domicilio
            /// </summary>
            public const string LocadorDomicilio = "##locador_domicilio";

            public const string vistos = "##vistos";
        }

        /// <summary>
        /// Constantes de las culturas de país
        /// </summary>
        public static class Iternacionalizacion
        {
            /// <summary>
            /// Cultura para Perú
            /// </summary>
            public const string ES_PE = "ES-PE";
        }

        /// <summary>
        /// Clase de enumerado que contiene los códigos de tipos de respuesta observación
        /// </summary>
        public static class TipoRespuestaObservacion
        {
            /// <summary>
            /// Observación Aplica
            /// </summary>
            public static readonly string Aplica = "A";
            /// <summary>
            /// Observación No Aplica
            /// </summary>
            public static readonly string NoAplica = "N";
        }

        /// <summary>
        /// Clase enumerado que contiene los códigos de los tipos de notificación
        /// </summary>
        public static class TipoNotificacion
        {
            /// <summary>
            /// [SGC] Contratos por Vencer
            /// </summary>
            public static readonly string ContratosPorVencer = "01";
            /// <summary>
            /// [SGC] Nuevo Contrato en Bandeja
            /// </summary>
            public static readonly string NuevoContratoBandeja = "02";
            /// <summary>
            /// [SGC] Nueva Consulta
            /// </summary>
            public static readonly string NuevaConsulta = "03";
            /// <summary>
            /// [SGC] Respuesta de Consulta
            /// </summary>
            public static readonly string RespuestaConsulta = "04";
            /// <summary>
            /// [SGC] Contrato Observado
            /// </summary>
            public static readonly string ContratosObservado = "05";
            /// <summary>
            /// [SGC] Observación Rechazada
            /// </summary>
            public static readonly string ObservacionRechazada = "06";
            /// <summary>
            /// [SGC] Contratos por Generar
            /// </summary>
            public static readonly string ContratosPorGenerar = "07";
            /// <summary>
            /// [SGC] Registro o reenvio de Consulta
            /// </summary>
            public static readonly string RegistroConsultas = "13";
            /// <summary>
            /// [SGC] Respuesta de Consulta
            /// </summary>
            public static readonly string RespuestaConsultas = "14";
            /// <summary>
            /// [SGC] Aprobación Contrato/Adenda Histórica
            /// </summary>
            public static readonly string AprobacionContratoHistorico = "18";

            /// <summary>
            /// [SGC] Contrato rechazado por legal
            /// </summary>
            public static readonly string ContratoRechazadoPorLegal = "19";
        }
        
        /// <summary>
        /// Clase enumerado que contiene los códigos de los sistemas
        /// </summary>
        public sealed class IdentificadorSistema
        {
            /// <summary>
            /// Codigo del Identificador SGC
            /// </summary>
            public const string IdentificadorSGC = "SGC";
        }
        /// <summary>
        /// Clase enumerado que las rutas de Opciones de la Aplicación
        /// </summary>
        public sealed class UrlOpcionesSistema
        {
            /// <summary>
            /// Codigo del Identificador SGC
            /// </summary>
            public const string RutaBandejaContrato = "/Contractual/BandejaContrato";

            /// <summary>
            /// Codigo del Identificador SGC
            /// </summary>
            public const string RutaConsulta = "/Contractual/Consulta";

            /// <summary>
            /// Codigo del Identificador SGC
            /// </summary>
            public const string RutaListadoContrato = "/Contractual/ListadoContrato";

        }
        /// <summary>
        /// Clase de enumerado que contiene los códigos de color para la alerta del contrato
        /// </summary>
        public static class AlertaVencimientoContrato
        {
            /// <summary>
            /// Código Color Ámbar
            /// </summary>
            public static readonly string Ambar = "01";
            /// <summary>
            /// Código Color Rojo
            /// </summary>
            public static readonly string Rojo = "02";
        }

        /// <summary>
        /// Clase enumerado que contiene los Tipos del Contenio Bien Registro
        /// </summary>
        public static class TipoContenidoBienRegistro
        {
            /// <summary>
            /// Tipo número de serie
            /// </summary>
            public static readonly string NumeroSerie = "NSR";
            /// <summary>
            /// Tipo Descripción
            /// </summary>
            public static readonly string Descripcion = "DSC";
            /// <summary>
            /// Tipo de Marca
            /// </summary>
            public static readonly string Marca = "MRC";
            /// <summary>
            /// Tipo de Modelo
            /// </summary>
            public static readonly string Modelo = "MDL";
        }

        /// <summary>
        /// Clase de enumerado que contiene los códigos de moneda
        /// </summary>
        public static class Moneda
        {
            /// <summary>
            /// Código de Moneda Soles
            /// </summary>
            public static readonly string Soles = "PEN";
            /// <summary>
            /// Código de Moneda Dólares
            /// </summary>
            public static readonly string Dolares = "USD";
        }

        /// <summary>
        /// Clase de enumerado que contiene los tipos de registro de un contrato
        /// </summary>
        public static class TipoRegistro
        {
            /// <summary>
            /// Tipo de guardado parcial
            /// </summary>
            public static readonly string Parcial = "PARCIAL";
            /// <summary>
            /// Tipo de guardado Total
            /// </summary>
            public static readonly string Total = "TOTAL";
        }

        /// <summary>
        /// Clase de enumerado que contiene el orden de los firmantes
        /// </summary>
        public static class OrdenFirmante
        {
            /// <summary>
            /// Primer Representante
            /// </summary>
            public static readonly int PrimerFirmante = 1;
            /// <summary>
            /// Segundo Representante
            /// </summary>
            public static readonly int SegundoFirmante = 2;
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
        /// Clase de enumerado que contiene el orden de los firmantes
        /// </summary>
        public static class Recursos
        {
            /// <summary>
            /// Representante Legal
            /// </summary>
            public static readonly string RepresentanteLegal = "Representante Legal";
            /// <summary>
            /// Revisado por
            /// </summary>
            public static readonly string RevisadoPor = "Revisado por:";
        }

        /// <summary>
        /// Clase de enumerado que contiene las configuraciones de generación de contratos
        /// </summary>
        public static class ConfiguracionGeneracionContrato
        {
            /// <summary>
            /// Intervalo de Tiempo de Autoguardado
            /// </summary>
            public static readonly string IntervaloTiempoAutoguardado = "ASA";
            /// <summary>
            /// Url del logo de STRACON
            /// </summary>
            public static readonly string UrlLogoStracon = "URL";
            /// <summary>
            /// Width del logo STRACON
            /// </summary>
            public static readonly string WidthLogo = "WLOG";
            /// <summary>
            /// Height de Logo STRACON
            /// </summary>
            public static readonly string HeightLogo = "HLOG";
        }
        /// <summary>
        /// Estados de la consulta
        /// </summary>
        public sealed class EstadoConsulta
        {
            /// <summary>
            /// Enviado
            /// </summary>
            public static readonly string Enviado = "EN";
            /// <summary>
            /// Reenviado
            /// </summary>
            public static readonly string Reenviado = "RE";
            /// <summary>
            /// Contestado
            /// </summary>
            public static readonly string Contestado = "CO";
            /// <summary>
            /// No aplica
            /// </summary>
            public static readonly string NoAplica = "NA";
        }
        /// <summary>
        /// Tipo de usuario
        /// </summary>
        public sealed class TipoUsuario
        {
            /// <summary>
            /// Enviado
            /// </summary>
            public static readonly string Destinatario = "D";
            /// <summary>
            /// Reenviado
            /// </summary>
            public static readonly string Remitente = "R";
        }

        /// <summary>
        /// Clase de enumerado que contiene los parametros valor
        /// </summary>
        public static class ParametroValor
        {
            /// <summary>
            /// Días de generación de adendas para contratos vencidos
            /// </summary>
            public static readonly int DiasGeneracionAdendaVencido = 46;

            /// <summary>
            /// Configuración para Equipos de AMT
            /// </summary>
            public static readonly int ConfiguracionEquiposAmt = 47;
        }

        /// <summary>
        /// Clase de enumerado que contiene los parametros valor sección de configuración AMT
        /// </summary>
        public static class ParametroConfiguracionAmtValorSeccion
        {
            /// <summary>
            /// Tiempo de vida
            /// </summary>
            public static readonly int TiempoVida = 1;

            /// <summary>
            /// Valor residual
            /// </summary>
            public static readonly int ValorResidual = 2;

            /// <summary>
            /// Código tipo tarifa
            /// </summary>
            public static readonly int CodigoTipoTarifa = 3;

            /// <summary>
            /// Código período alquiler
            /// </summary>
            public static readonly int CodigoPeriodoAlquiler = 4;

            /// <summary>
            /// Valor alquiler
            /// </summary>
            public static readonly int ValorAlquiler = 5;

            /// <summary>
            /// Código moneda
            /// </summary>
            public static readonly int CodigoMoneda = 6;

            /// <summary>
            /// Código tipo bien
            /// </summary>
            public static readonly int CodigoTipoBien = 7;
        }

        /// <summary>
        /// Constantes de Flujo Aprobación Tipo Participante
        /// </summary>
        public sealed class FlujoAprobacionTipoParticipante
        {
            /// <summary>
            /// Tipo Responsable
            /// </summary>
            public static readonly string Responsable = "R";

            /// <summary>
            /// Tipo Informado
            /// </summary>
            public static readonly string Informado = "I";

            /// <summary>
            /// Tipo Responsable Vinculadas
            /// </summary>
            public static readonly string ResponsableVinculadas = "V";
        }


        /// <summary>
        /// Constantes Tipo de Servicio
        /// </summary>
        public sealed class TipoServicio
        {
            /// <summary>
            /// Contrato Histórico
            /// </summary>
            public static readonly string ContratoHistorico = "OCH";
        
        }

        /// <summary>
        /// Constantes Tipo de Ordemaniendo
        /// </summary>
        public sealed class TipoOrdenamiento
        {
            /// <summary>
            /// Ascendente
            /// </summary>
            public static readonly string Ascendente = "asc";

            /// <summary>
            /// Descendente
            /// </summary>
            public static readonly string Descendente = "desc";           
        }

        /// <summary>
        /// Columnas listado de contratos
        /// </summary>
        public sealed class ColumnaListadoContrato
        {
            /// <summary>
            /// Unidad Organizacional
            /// </summary>
            public static readonly string UnidadOperativa = "NombreUnidadOperativa";

            /// <summary>
            /// Tipo de contrato
            /// </summary>
            public static readonly string TipoContrato = "DescripcionTipoServicio";

            /// <summary>
            /// Tipo de servicio
            /// </summary>
            public static readonly string TipoServicio = "DescripcionTipoRequerimiento";

            /// <summary>
            /// Estado de edición
            /// </summary>
            public static readonly string EstadoEdicion = "DescripcionEstadoEdicion";

            /// <summary>
            /// En bandeja de
            /// </summary>
            public static readonly string NombreTrabajadorResponsable = "NombreTrajadorResponsable";

            /// <summary>
            /// Días vencimiento
            /// </summary>
            public static readonly string DiasVencimiento = "DiasVencimiento";

            /// <summary>
            /// Días en bandeja
            /// </summary>
            public static readonly string DiasBandeja = "DiasEnBandeja";
        }

        /// <summary>
        /// Columnas Bandeja de contratos
        /// </summary>
        public sealed class ColumnaBandejaContrato
        {
            /// <summary>
            /// Unidad Organizacional
            /// </summary>
            public static readonly string UnidadOperativa = "NombreUnidadOperativa";

            /// <summary>
            /// Tipo de contrato
            /// </summary>
            public static readonly string TipoContrato = "NombreTipoServicio";

            /// <summary>
            /// Tipo de servicio
            /// </summary>
            public static readonly string TipoServicio = "NombreTipoRequerimiento";
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

        /// <summary>
        /// Configuración Mensaje Error Carga - Menú
        /// </summary>
        public sealed class Mensaje
        {
            /// <summary>
            /// Mensaje Error
            /// </summary>
            public static readonly string MensajeError = "Error";
        }
        /// <summary>
        /// Formato Reporte
        /// </summary>
        public sealed class ReporteFormato
        {
            /// <summary>
            /// 
            /// </summary>
            public const string PDF = "pdf";

            /// <summary>
            /// 
            /// </summary>
            public const string EXCEL = "excel";

            /// <summary>
            /// 
            /// </summary>
            public const string EXCELOPENXML = "EXCELOPENXML";

            /// <summary>
            /// 
            /// </summary>
            public const string WORD = "word";

            /// <summary>
            /// 
            /// </summary>
            public const string WORDOPENXML = "WORDOPENXML";
        }

        /// <summary>
        /// Extesion Reporte
        /// </summary>
        public static Dictionary<string, string> ObtenerExtensionReporte
        {
            get
            {
                var formatExtension = new Dictionary<string, string>
                {
                    {ReporteFormato.PDF, ".pdf"},
                    {ReporteFormato.EXCEL, ".xls"},
                    {ReporteFormato.EXCELOPENXML, ".xlsx"},
                    {ReporteFormato.WORD, ".doc"},
                    {ReporteFormato.WORDOPENXML, ".docx"},

                };
                return formatExtension;
            }
        }
    }
}
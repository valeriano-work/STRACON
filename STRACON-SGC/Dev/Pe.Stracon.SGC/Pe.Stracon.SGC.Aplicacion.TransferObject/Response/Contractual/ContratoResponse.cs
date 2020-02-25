using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Base;
using System;
using System.Collections.Generic;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;


namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Contratos
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150518 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ContratoResponse : BaseResponse
    {
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid? CodigoContrato { get; set; }
        /// <summary>
        /// Codigo de UnidadOperativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Nombre de UnidadOperativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }
        /// <summary>
        /// Codigo de Proveedor
        /// </summary>
        public Guid? CodigoProveedor { get; set; }
        /// <summary>
        /// Numero de Contrato
        /// </summary>
        public string NumeroContrato { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Codigo Tipo de Servicio
        /// </summary>
        public string CodigoTipoServicio { get; set; }
        /// <summary>
        /// Codigo Tipo de Servicio
        /// </summary>
        public string NombreTipoServicio { get; set; }
        /// <summary>
        /// Codigo Tipo de Requerimiento
        /// </summary>
        public string NombreTipoRequerimiento { get; set; }
        /// <summary>
        /// Codigo Tipo de Requerimiento
        /// </summary>
        public string CodigoTipoRequerimiento { get; set; }
        /// <summary>
        /// Indicador de si Carga del Estadio 
        /// </summary>
        public bool IndicadorPermiteCarga { get; set; }
        /// <summary>
        /// Codigo Tipo de Documento
        /// </summary>
        public string CodigoTipoDocumento { get; set; }
        /// <summary>
        /// Nombre Tipo de Documento
        /// </summary>
        public string NombreTipoDocumento { get; set; }
        /// <summary>
        /// Indicador versión oficial
        /// </summary>
        public bool IndicadorVersionOficial { get; set; }
        /// <summary>
        /// Fecha Inicio de Vigencia
        /// </summary>
        public DateTime? FechaInicioVigencia { get; set; }
        /// <summary>
        /// Fecha Inicio de Vigencia
        /// </summary>
        public string FechaInicioVigenciaString { get; set; }
        /// <summary>
        /// Fecha Fin de Vigencia
        /// </summary>
        public DateTime? FechaFinVigencia { get; set; }
        /// <summary>
        /// Fecha Fin de Vigencia
        /// </summary>
        public string FechaFinVigenciaString { get; set; }
        /// <summary>
        /// Codigo de Moneda
        /// </summary>
        public string CodigoMoneda { get; set; }
        /// <summary>
        /// Monto de Contrato
        /// </summary>
        public decimal MontoContrato { get; set; }
        /// <summary>
        /// Monto de Contrato en cadena de texto
        /// </summary>
        public string MontoContratoString { get; set; }
        /// <summary>
        /// Monto acumulado de Contrato
        /// </summary>
        public decimal MontoAcumulado { get; set; }
        /// <summary>
        /// Monto acumulado de Contrato en cadena de texto
        /// </summary>
        public string MontoAcumuladoString { get; set; }
        /// <summary>
        /// Codigo de Estado
        /// </summary>
        public string CodigoEstado { get; set; }
        /// <summary>
        /// Codigo de Plantilla
        /// </summary>
        public Guid? CodigoPlantilla { get; set; }
        /// <summary>
        /// Codigo Contrato de Principal
        /// </summary>
        public Guid? CodigoContratoPrincipal { get; set; }
        /// <summary>
        /// Codigo de Estado de Edicion
        /// </summary>
        public string CodigoEstadoEdicion { get; set; }
        /// <summary>
        /// Nombre del Estado de Edicion
        /// </summary>
        public string NombreEstadoEdicion { get; set; }
        /// <summary>
        /// Comentario de Modificacion
        /// </summary>
        public string ComentarioModificacion { get; set; }
        /// <summary>
        /// Respuesta de Modificacion
        /// </summary>
        public string RespuestaModificacion { get; set; }
        /// <summary>
        /// Código de Flujo de aprobación
        /// </summary>
        public Guid? CodigoFlujoAprobacion { get; set; }
        /// <summary>
        /// Código de Estadio de Actual
        /// </summary>
        public Guid? CodigoEstadioActual { get; set; }
        /// <summary>
        /// Nombre de Estadio Actual
        /// </summary>
        public string NombreEstadioActual { get; set; }
        /// <summary>
        /// Días pendiente para procesar contrato
        /// </summary>
        public int DiasPendiente { get; set; }
        /// <summary>
        /// Nombre del Proveedor
        /// </summary>
        public string NombreProveedor { get; set; }
        /// <summary>
        /// Código de Contrato de Estadio
        /// </summary>
        public Guid? CodigoContratoEstadio { get; set; }
        /// <summary>
        /// Código de Flujo de aprobación estadio
        /// </summary>
        public Guid? CodigoFlujoAprobacionEstadio { get; set; }
        /// <summary>
        /// Fecha de Ingreso
        /// </summary>
        public string FechaIngreso { get; set; }
        /// <summary>
        /// Fecha de última notificación
        /// </summary>
        public string FechaUltimaNotificacion { get; set; }
        /// <summary>
        /// Flag que indica si el contrato es por Consulta o para aprobación
        /// </summary>
        public string EstadioPropioConsulta { get; set; }
        /// <summary>
        /// Descripción del contrato
        /// </summary>
        public string DescripcionContrato { get; set; }
        /// <summary>
        /// Estado de registro
        /// </summary>
        public string EstadoRegistro { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NumeroAdendaConcatenado { get; set; }

        /// <summary>
        /// Indicador si contrato Es Flexible
        /// </summary>
        public bool EsFlexible { get; set; }

        /// <summary>
        /// Si el contrato es corporativo
        /// </summary>
        public bool? EsCorporativo { get; set; }

        /// <summary>
        /// Indicador Adhesion
        /// </summary>
        public bool? IndicadorAdhesion { get; set; }

        /// <summary>
        /// Código de Contrato Original
        /// </summary>
        public Guid? CodigoContratoOriginal { get; set; }

        /// <summary>
        /// Fecha de modificación del contrato
        /// </summary>
        public string FechaModificacion { get; set; }

        /// <summary>
        /// Usuario de creación
        /// </summary>
        public string UsuarioCreacion { get; set; }

        //INICIO: Agregado por Julio Carrera -Norma Contable
        /// <summary>
        /// Indica si un contrato es de tipo arrendamiento de equipo mayor o menor
        /// </summary>
        public bool EsMayorMenor { get; set; }
        //FIN: Agregado por Julio Carrera -Norma Contable

        /// <summary>
        /// Requerido
        /// </summary>
        public string CodigoRequerido { get; set; }

        /// <summary>
        /// Lista Requerido
        /// </summary>
        public Dictionary<string, string> ListaRequerido { get; set; }
    }
}

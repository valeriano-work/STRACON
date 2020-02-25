using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Listado de Requerimientos
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150601 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ListadoRequerimientoLogic : Logic 
    {
        /// <summary>
        /// Código de Requerimiento
        /// </summary>
        public Guid CodigoRequerimiento { get; set; }
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public Guid CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Proveedor
        /// </summary>
        public Guid CodigoProveedor { get; set; }
        /// <summary>
        /// Número de Documento de Proveedor
        /// </summary>
        public string NumeroDocumentoProveedor { get; set; }
        /// <summary>
        /// Nombre de Proveedor
        /// </summary>
        public string NombreProveedor { get; set; }
        /// <summary>
        /// Número de Requerimiento
        /// </summary>
        public string NumeroRequerimiento { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Código de Tipo de Servicio
        /// </summary>
        public string CodigoTipoServicio { get; set; }
        /// <summary>
        /// Código de Tipo de Requerimiento
        /// </summary>
        public string CodigoTipoRequerimiento { get; set; }
        /// <summary>
        /// Código de Tipo de Documento
        /// </summary>
        public string CodigoTipoDocumento { get; set; }
        /// <summary>
        /// Fecha de Inicio de Vigencia
        /// </summary>
        public DateTime FechaInicioVigencia { get; set; }
        /// <summary>
        /// Fecha de Inicio de Vigencia en cadena de texto
        /// </summary>
        public string FechaInicioVigenciaString { get; set; }
        /// <summary>
        /// Fecha de Fin de Vigencia
        /// </summary>
        public DateTime FechaFinVigencia { get; set; }
        /// <summary>
        /// Fecha de Fin de Vigencia en cadena de texto
        /// </summary>
        public string FechaFinVigenciaString { get; set; }
        /// <summary>
        /// Código de Moneda
        /// </summary>
        public string CodigoMoneda { get; set; }
        /// <summary>
        /// Monto de Requerimiento
        /// </summary>
        public decimal MontoRequerimiento { get; set; }
        /// <summary>
        /// Monto de Requerimiento en cadena de texto
        /// </summary>
        public string MontoRequerimientoString { get; set; }
        /// <summary>
        /// Monto Acumulado
        /// </summary>
        public decimal MontoAcumulado { get; set; }
        /// <summary>
        /// Monto Acumulado en cadena de texto
        /// </summary>
        public string MontoAcumuladoString { get; set; }
        /// <summary>
        /// Código de Estado de Requerimiento
        /// </summary>
        public string CodigoEstadoRequerimiento { get; set; }
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public Guid? CodigoPlantilla { get; set; }
        /// <summary>
        /// Código de Requerimiento Principal
        /// </summary>
        public Guid? CodigoRequerimientoPrincipal { get; set; }
        /// <summary>
        /// Código de Estado de Edición
        /// </summary>
        public string CodigoEstadoEdicion { get; set; }
        /// <summary>
        /// Comentario de Modificación
        /// </summary>
        public string ComentarioModificacion { get; set; }
        /// <summary>
        /// Respuesta de Modificación
        /// </summary>
        public string RespuestaModificacion { get; set; }
        /// <summary>
        /// Código de Estadio Actual
        /// </summary>
        public Guid? CodigoEstadioActual { get; set; }
        /// <summary>
        /// Código de Trabajador de Responsable
        /// </summary>
        public Guid? CodigoTrabajadorResponsable { get; set; }
        /// <summary>
        /// Número de correlativo de adenda
        /// </summary>
        public int NumeroAdenda { get; set; }
        /// <summary>
        /// Número de adenda concatenado
        /// </summary>
        public string NumeroAdendaConcatenado { get; set; }
        /// <summary>
        /// Cantidad de adendas
        /// </summary>
        public int CantidadAdenda { get; set; }
        /// <summary>
        /// Indicador Adhesión
        /// </summary>
        public bool? IndicadorAdhesion { get; set; }
        /// <summary>
        /// Fecha de Creación
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Fecha de Creación string
        /// </summary>
        public DateTime FechaCreacionString { get; set; }
        /// <summary>
        /// Usuario de creación
        /// </summary>
        public string UsuarioCreacion { get; set; }
        /// <summary>
        /// Fecha registro actual
        /// </summary>
        public DateTime? FechaCreacionEstadioActual { get; set; }
        /// <summary>
        /// Nombre de estadio actual
        /// </summary>
        public string NombreEstadioActual { get; set; }
        /// <summary>
        /// Si el contrato es Flexible
        /// </summary>
        public bool EsFlexible { get; set; }

        /// <summary>
        /// La fecha de resolución cuando el estado pasa a Resuelto
        /// </summary>
        public DateTime FechaResolucion { get; set; }

        /// <summary>
        /// La fecha de resolución pero convertido a String
        /// </summary>
        public string FechaResolucionString { get; set; }

        /// <summary>
        /// Esta validación debe cumplir lo solicitado y proviene desde un Proc en BBDD CTR.USP_CONTRATO_ORDENADO_SEL
        /// </summary>
        public int ValidacionResolucion { get; set; }

        /// <summary>
        /// Usuario que Requiere el Requerimiento
        /// </summary>
        public Guid? Requerido { get; set; }
    }
}

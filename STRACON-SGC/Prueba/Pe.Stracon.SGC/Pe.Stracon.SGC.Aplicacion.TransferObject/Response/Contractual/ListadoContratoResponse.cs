using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Listado Contrato
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150601 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ListadoContratoResponse : BaseResponse
    {
        /// <summary>
        /// Código de Contrato
        /// </summary>
        public Guid? CodigoContrato { get; set; }
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public Guid CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Proveedor
        /// </summary>
        public Guid CodigoProveedor { get; set; }
        /// <summary>
        /// Nombre de Unidad Operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }
        /// <summary>
        /// Número de Documento de Proveedor
        /// </summary>
        public string NumeroDocumentoProveedor { get; set; }
        /// <summary>
        /// Nombre de Proveedor
        /// </summary>
        public string NombreProveedor { get; set; }
        /// <summary>
        /// Número de Contrato
        /// </summary>
        public string NumeroContrato { get; set; }
        /// <summary>
        /// Número de Adenda
        /// </summary>
        public string NumeroAdenda { get; set; }
        /// <summary>
        /// Número de adenda Concatenado
        /// </summary>
        public string NumeroAdendaConcatenado { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Código de Tipo de Servicio
        /// </summary>
        public string CodigoTipoServicio { get; set; }
        /// <summary>
        /// Descripción de Tipo de Servicio
        /// </summary>
        public string DescripcionTipoServicio { get; set; }
        /// <summary>
        /// Código de Tipo de Requerimiento
        /// </summary>
        public string CodigoTipoRequerimiento { get; set; }
        /// <summary>
        /// Descripción de Tipo de Requerimiento
        /// </summary>
        public string DescripcionTipoRequerimiento { get; set; }
        /// <summary>
        /// Código de Tipo de Documento
        /// </summary>
        public string CodigoTipoDocumento { get; set; }
        /// <summary>
        /// Descripción de Tipo de Documento
        /// </summary>
        public string DescripcionTipoDocumento { get; set; }
        /// <summary>
        /// Código de Estado de Contrato
        /// </summary>
        public string CodigoEstadoContrato { get; set; }
        /// <summary>
        /// Descripción de Estado de Contrato
        /// </summary>
        public string DescripcionEstadoContrato { get; set; }
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
        /// Días de Vencimiento
        /// </summary>
        public int DiasVencimiento { get; set; }
        /// <summary>
        /// Días de Vencimiento en cadena de texto
        /// </summary>
        public string DiasVencimientoString { get; set; }
        /// <summary>
        /// Código de Moneda
        /// </summary>
        public string CodigoMoneda { get; set; }
        /// <summary>
        /// Descripción de Moneda
        /// </summary>
        public string DescripcionMoneda { get; set; }
        /// <summary>
        /// Monto de Contrato
        /// </summary>
        public decimal MontoContrato { get; set; }
        /// <summary>
        /// Monto de Contrato en cadena de texto
        /// </summary>
        public string MontoContratoString { get; set; }
        /// <summary>
        /// Monto Acumulado
        /// </summary>
        public decimal MontoAcumulado { get; set; }
        /// <summary>
        /// Monto Acumulado en cadena de texto
        /// </summary>
        public string MontoAcumuladoString { get; set; }
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public Guid? CodigoPlantilla { get; set; }
        /// <summary>
        /// Código de Contrato Principal
        /// </summary>
        public Guid? CodigoContratoPrincipal { get; set; }
        /// <summary>
        /// Código de Estado de Edición
        /// </summary>
        public string CodigoEstadoEdicion { get; set; }
        /// <summary>
        /// Descripción de Estado de Edición
        /// </summary>
        public string DescripcionEstadoEdicion { get; set; }
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
        /// Código de trabajador responsable actual
        /// </summary>
        public Guid? CodigoTrabajadorResponsable { get; set; }
        /// <summary>
        /// Nombre de trabajador responsable actual
        /// </summary>
        public string NombreTrajadorResponsable { get; set; }
        /// <summary>
        /// Indica si el contrato esta pendiente de finalizar, sigue en edición
        /// </summary>
        public bool? IndicadorPendienteFinalizarEdicion { get; set; }
        /// <summary>
        /// Cantidad de adendas
        /// </summary>
        public int CantidadAdenda { get; set; }
        /// <summary>
        /// Indicador Adhesión
        /// </summary>
        public bool? IndicadorAdhesion { get; set; }
        /// <summary>
        /// Fecha de creación
        /// </summary>
        public string FechaCreacionString { get; set; }
        /// <summary>
        /// Usuario de creación
        /// </summary>
        public string UsuarioCreacion { get; set; }
        /// <summary>
        /// Días en bandeja
        /// </summary>
        public int DiasEnBandeja { get; set; }
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
    }
}

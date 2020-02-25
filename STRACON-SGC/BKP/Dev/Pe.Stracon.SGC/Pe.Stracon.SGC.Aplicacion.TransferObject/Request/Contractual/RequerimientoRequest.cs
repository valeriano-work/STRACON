using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request del contrato
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150525 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class RequerimientoRequest : Filtro
    {
        /// <summary>
        /// Código de Requerimiento
        /// </summary>
        public string CodigoRequerimiento { get; set; }
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Proveedor
        /// </summary>
        public Guid CodigoProveedor { get; set; }
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
        /// Indicador de Versión Oficial
        /// </summary>
        public bool? IndicadorVersionOficial { get; set; }
        /// <summary>
        /// Fecha de Inicio de Vigencia
        /// </summary>
        public DateTime? FechaInicioVigencia { get; set; }
        /// <summary>
        /// Fecha de Fin de Vigencia
        /// </summary>
        public DateTime? FechaFinVigencia { get; set; }
        /// <summary>
        /// Fecha de Inicio de Vigencia en cadena de texto
        /// </summary>
        public string FechaInicioVigenciaString { get; set; }
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
        public string CodigoEstado { get; set; }
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
        /// Indicador de Solicitar Modificación
        /// </summary>
        public bool IndicadorSolicitarModificacion { get; set; }
        /// <summary>
        /// Comentario de Modificación
        /// </summary>
        public string ComentarioModificacion { get; set; }
        /// <summary>
        /// Respuesta de Modificación
        /// </summary>
        public string RespuestaModificacion { get; set; }
        /// <summary>
        /// Código de Flujo de Aprobación
        /// </summary>
        public string CodigoFlujoAprobacion { get; set; }
        /// <summary>
        /// Código de Estadio Actual
        /// </summary>
        public Guid? CodigoEstadioActual { get; set; }
        /// <summary>
        /// Código de Responsable
        /// </summary>
        public Guid? CodigoResponsable { get; set; }
        /// <summary>
        /// Nombre de Proveedor
        /// </summary>
        public string NombreProveedor { get; set; }
        /// <summary>
        /// Número de Documento de Proveedor
        /// </summary>
        public string NumeroDocProveedor { get; set; }
        /// <summary>
        /// Contenido del contrato.
        /// </summary>
        public string ContenidoRequerimiento { get; set; }
        /// <summary>
        /// Request de Requerimiento Documento
        /// </summary>
        public RequerimientoDocumentoRequest RequerimientoDocumento { get; set; }
        /// <summary>
        /// Lista de Códigos de Bienes
        /// </summary>
        public List<string> ListaCodigoBien { get; set; }
        //INICIO: Agregado por Julio Carrera - Norma Contable
        /// <summary>
        /// Lista de Bienes
        /// </summary>
        public List<BienRequest> ListaBienes { get; set; }
        //FIN: Agregado por Julio Carrera - Norma Contable
        /// <summary>
        /// Tipo de Registro (PARCIAL / TOTAL)
        /// </summary>
        public string TipoRegistro { get; set; }
        /// <summary>
        /// Numero correlativo de Adenda
        /// </summary>
        public int NumeroAdenda { get; set; }
        /// <summary>
        /// Numero de Adenda Concatenado
        /// </summary>
        public string NumeroAdendaConcatenado { get; set; }
        /// <summary>
        /// Indicador de Adhesión
        /// </summary>
        public bool? IndicadorAdhesion { get; set; }
        /// <summary>
        /// Lista Requerimiento Firmante
        /// </summary>
        public List<RequerimientoFirmanteRequest> ListaRequerimientoFirmante { get; set; }

        /// <summary>
        /// Nombre de Estadio
        /// </summary>
        public string NombreEstadio { get; set; }
        /// <summary>
        /// Indicador de Finalizar Aprobación
        /// </summary>
        public string IndicadorFinalizarAprobacion { get; set; }

        /// <summary>
        /// Si el contrato es corporativo
        /// </summary>
        public bool? EsCorporativo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool? EsFlexible { get; set; }
        /// <summary>
        /// Valor de Edicion
        /// </summary>
        public string ValorEdicion { get; set; }

        /// <summary>
        /// Requerido
        /// </summary>
        public string CodigoRequerido { get; set; }
    }
}

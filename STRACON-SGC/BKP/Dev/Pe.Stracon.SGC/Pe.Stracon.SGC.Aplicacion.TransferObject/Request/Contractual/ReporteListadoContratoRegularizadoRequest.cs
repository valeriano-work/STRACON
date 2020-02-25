using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Reporte de Listado de contrato
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150625 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteListadoContratoRegularizadoRequest
    {
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Nombre de Unidad Operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }
        /// <summary>
        /// Tipo de Servicio
        /// </summary>
        public string CodigoTipoServicio { get; set; }
        /// <summary>
        /// Nombre del Tipo de Servicio
        /// </summary>
        public string NombreTipoServicio { get; set; }
        /// <summary>
        /// Tipo de Requerimiento
        /// </summary>
        public string CodigoTipoRequerimiento { get; set; }
        /// <summary>
        /// Nombre Tipo de Requerimiento
        /// </summary>
        public string NombreTipoRequerimiento { get; set; }
        /// <summary>
        /// Tipo de Documento
        /// </summary>
        public string CodigoTipoDocumento { get; set; }
        /// <summary>
        /// Nombre de Tipo de Documento
        /// </summary>
        public string NombreTipoDocumento { get; set; }
        /// <summary>
        /// Código de Estado de Contrato
        /// </summary>
        public string CodigoEstadoContrato { get; set; }
        /// <summary>
        /// Estado de Contrato
        /// </summary>
        public string NombreEstadoContrato { get; set; }
        /// <summary>
        /// Número de Contrato
        /// </summary>
        public string NumeroContrato { get; set; }
        /// <summary>
        /// Ruc del proveedor
        /// </summary>
        public string NumeroDocumentoProveedor { get; set; }
        /// <summary>
        /// Razón Social
        /// </summary>
        public string RazonSocial { get; set; }
        /// <summary>
        /// Fecha de Consulta Desde en cadena de texto
        /// </summary>
        public string FechaConsultaDesdeString { get; set; }
        /// <summary>
        /// Fecha de Consulta Hasta en cadena de texto
        /// </summary>
        public string FechaConsultaHastaString { get; set; }
        /// <summary>
        /// Contenido del contrato
        /// </summary>
        public string ContenidoContrato { get; set; }

        /// <summary>
        /// Código de Trabajador Responsable
        /// </summary>
        public string CodigoTrabajadorResponsable { get; set; }
        /// <summary>
        /// Nombre de Trabajador Responsable
        /// </summary>
        public string NombreTrabajadorResponsable { get; set; }
        /// <summary>
        /// Nombre de Estadio
        /// </summary>
        public string NombreEstadio { get; set; }
        /// <summary>
        /// Indicador de Finalizar Aprobación
        /// </summary>
        public string IndicadorFinalizarAprobacion { get; set; }
        /// <summary>
        /// Monto Acumulado Inicio
        /// </summary>
         public string MontoAcumuladoInicio { get; set; } 
        //public decimal? MontoAcumuladoInicio { get; set; }
        /// <summary>
        /// Monto Acumulado Fin
        /// </summary>
        //public decimal? MontoAcumuladoFin { get; set; }
        public string MontoAcumuladoFin { get; set; }
        /// <summary>
        /// Codigo Moneda
        /// </summary>
        public string CodigoMoneda { get; set; }
    }
}

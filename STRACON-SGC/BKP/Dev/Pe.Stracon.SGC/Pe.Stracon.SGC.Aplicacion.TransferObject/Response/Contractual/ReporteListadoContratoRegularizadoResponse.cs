using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Reporte de Listado Contrato
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150625 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteListadoContratoRegularizadoResponse
    {
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Número de Contrato
        /// </summary>
        public string NumeroContrato { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Tipo de Servicio
        /// </summary>
        public string TipoServicio { get; set; }
        /// <summary>
        /// Tipo de Requerimiento
        /// </summary>
        public string TipoRequerimiento { get; set; }
        /// <summary>
        /// Tipo de Documento
        /// </summary>
        public string TipoDocumento { get; set; }
        /// <summary>
        /// Estado de Contrato
        /// </summary>
        public string EstadoContrato { get; set; }
        /// <summary>
        /// Ruc del proveedor
        /// </summary>
        public string NumeroDocumento { get; set; }
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
        public decimal? MontoAcumuladoInicio { get; set; }
        /// <summary>
        /// Monto Acumulado Fin
        /// </summary>
        public decimal? MontoAcumuladoFin { get; set; }
    }
}

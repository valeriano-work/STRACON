using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Flujo Aprobacion
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ProcesoAuditoriaLogic : Logic
    {
        /// <summary>
        /// Codigo Auditoria
        /// </summary>
        public Guid CodigoAuditoria { get; set; }
        /// <summary>
        /// Codigo Unidad Operativa
        /// </summary>
        public Guid CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Fecha Planificada
        /// </summary>
        public DateTime FechaPlanificada { get; set; }
        /// <summary>
        /// Fecha Planificada String
        /// </summary>
        public string FechaPlanificadaString { get; set; }
        /// <summary>
        /// Fecha Ejecucion String
        /// </summary>
        public DateTime? FechaEjecucion { get; set; }
        /// <summary>
        /// Fecha Ejecucion String
        /// </summary>
        public string FechaEjecucionString { get; set; }
        /// <summary>
        /// Cantidad Auditadas
        /// </summary>
        public Int16? CantidadAuditadas { get; set; }
        /// <summary>
        /// Cantidad Observadas
        /// </summary>
        public Int16? CantidadObservadas { get; set; }
        /// <summary>
        /// Resultado Auditoria
        /// </summary>
        public string ResultadoAuditoria { get; set; }  
    }
}

using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Flujo Aprobacion
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150508 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ProcesoAuditoriaEntity : Entity
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
        /// Fecha Ejecucion
        /// </summary>
        public DateTime? FechaEjecucion { get; set; }
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

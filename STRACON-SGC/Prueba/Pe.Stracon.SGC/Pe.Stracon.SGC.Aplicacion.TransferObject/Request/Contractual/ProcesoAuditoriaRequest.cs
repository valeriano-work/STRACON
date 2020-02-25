using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Proceso Auditoria
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150520 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ProcesoAuditoriaRequest : Filtro
    {
        /// <summary>
        /// Constructor de clase
        /// </summary>
        public ProcesoAuditoriaRequest()
        {
            EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;
        }
        /// <summary>
        /// Codigo Auditoria
        /// </summary>
        public string CodigoAuditoria { get; set; }
        /// <summary>
        /// Codigo Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Fecha Planificada
        /// </summary>
        public DateTime? FechaPlanificada { get; set; }
        /// <summary>
        /// Fecha Planificada
        /// </summary>
        public string FechaPlanificadaString { get; set; }
        /// <summary>
        /// Fecha Ejecucion
        /// </summary>
        public DateTime? FechaEjecucion { get; set; }
        /// <summary>
        /// Fecha Ejecucion
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
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
    }
}

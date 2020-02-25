using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Reporte de Estadio Actual de Contrato
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150624 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteEstadioActualContratoResponse
    {
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Generados Desde en cadena de texto
        /// </summary>
        public string GeneradosDesdeString { get; set; }
        /// <summary>
        /// Generados Hasta en cadena de texto
        /// </summary>
        public string GeneradosHastaString { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Reporte de Estadio Actual de Contrato
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150624 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteEstadioActualContratoRequest
    {
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Nombre de Unidad Operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }
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

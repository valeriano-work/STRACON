using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Reporte de Tiempo de Atención
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150625 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteTiempoAtencionResponse
    {
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Fecha de Consulta Desde en cadena de texto
        /// </summary>
        public string FechaConsultaDesdeString { get; set; }
        /// <summary>
        /// Fecha de Consulta Hasta en cadena de texto
        /// </summary>
        public string FechaConsultaHastaString { get; set; }
        /// <summary>
        /// Número de Contrato
        /// </summary>
        public string NumeroContrato { get; set; }
    }
}

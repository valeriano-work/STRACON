using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Reporte de Contrato Por Vencer
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150630 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteContratoPorVencerRequest
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
        /// Fecha de Vencimieto Desde en cadena de texto
        /// </summary>
        public string VencimientoDesdeString { get; set; }
        /// <summary>
        /// Fecha de Vencimieto Hasta en cadena de texto
        /// </summary>
        public string VencimientoHastaString { get; set; }
        /// <summary>
        /// Código de Estado del Contrato
        /// </summary>
        public string CodigoEstadoContrato { get; set; }
        /// <summary>
        /// Descripción de Estado del Contrato
        /// </summary>
        public string DescripcionEstadoContrato { get; set; }
        /// <summary>
        /// Número para Color Rojo 
        /// </summary>
        public string NumeroDiaRojo { get; set; }
        /// <summary>
        /// Número para Color Ámbar
        /// </summary>
        public string NumeroDiaAmbar { get; set; }
    }
}

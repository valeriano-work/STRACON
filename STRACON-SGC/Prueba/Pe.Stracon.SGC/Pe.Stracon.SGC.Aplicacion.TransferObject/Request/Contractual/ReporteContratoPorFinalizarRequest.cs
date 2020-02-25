using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Reporte de Contrato Por Finalizar
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20160623 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteContratoPorFinalizarRequest
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
        /// Código de Tipo de Contrato
        /// </summary>
        public string CodigoTipoContrato { get; set; }
        /// <summary>
        /// Descripción de Tipo de Contrato
        /// </summary>
        public string DescripcionTipoContrato { get; set; }
        /// <summary>
        /// Código de Tipo de Servicio
        /// </summary>
        public string CodigoTipoServicio { get; set; }
        /// <summary>
        /// Descripción de Tipo de Servicio
        /// </summary>
        public string DescripcionTipoServicio { get; set; }
        /// <summary>
        /// Número de Contrato
        /// </summary>
        public string NumeroContrato { get; set; }
        /// <summary>
        /// Indicador de último Estadio Aprobado
        /// </summary>
        public string IndicadorUltimoEstadioAprobado { get; set; }
        /// <summary>
        /// Descripción del Indicador de Último Estadio Aprobados
        /// </summary>
        public string DescripcionIndicadorUltimoEstadioAprobado { get; set; }
    }
}

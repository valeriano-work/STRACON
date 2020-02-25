using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Reporte de Requerimientos eliminados
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20170628 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteRequerimientoObservadoAprobadoRequest
    {
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Nombre de Unidad Operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }
        /// <summary>
        /// CodigoRequerimiento
        /// </summary>
        public Guid? CodigoRequerimiento { get; set; }
        /// <summary>
        /// Número de Requerimiento
        /// </summary>
        public string NumeroRequerimiento { get; set; }
        /// <summary>
        /// Tipo Accion Requerimiento
        /// </summary>
        public string TipoAccionRequerimiento { get; set; }
        /// <summary>
        /// Fecha de Consulta Desde en cadena de texto
        /// </summary>
        public DateTime FechaConsultaDesde { get; set; }
        /// <summary>
        /// Fecha de Consulta Hasta en cadena de texto
        /// </summary>
        public DateTime FechaConsultaHasta { get; set; }
        /// <summary>
        /// Fecha de Consulta Desde en cadena de texto
        /// </summary>
        public string FechaConsultaDesdeString { get; set; }
        /// <summary>
        /// Fecha de Consulta Hasta en cadena de texto
        /// </summary>
        public string FechaConsultaHastaString { get; set; }

        /// <summary>
        /// Pagina solicitada
        /// </summary>
        public int NumeroPagina { get; set; }
        /// <summary>
        /// Registros por Pagina
        /// </summary>
        public int RegistrosPagina { get; set; }

    }
}

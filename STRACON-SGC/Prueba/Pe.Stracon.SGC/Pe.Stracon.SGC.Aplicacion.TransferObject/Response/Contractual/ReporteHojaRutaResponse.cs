using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Hoja de Ruta
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150630 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteHojaRutaResponse
    {
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Tipo de Servicio
        /// </summary>
        public string CodigoTipoServicio { get; set; }
        /// <summary>
        /// Código de Tipo de Requerimiento
        /// </summary>
        public string CodigoTipoRequerimiento { get; set; }
        /// <summary>
        /// Indicador de Monto Minimo
        /// </summary>
        public string IndicadorMontoMinimo { get; set; }
        /// <summary>
        /// Código de Flujo de Aprobación
        /// </summary>
        public string CodigoFlujoAprobacion { get; set; }
        /// <summary>
        /// Generados Desde en cadena de texto
        /// </summary>
        public string GeneradosDesdeString { get; set; }
        /// <summary>
        /// Generados Hasta en cadena de texto
        /// </summary>
        public string GeneradosHastaString { get; set; }
        /// <summary>
        /// Número de Contrato
        /// </summary>
        public string NumeroContrato { get; set; }
    }
}

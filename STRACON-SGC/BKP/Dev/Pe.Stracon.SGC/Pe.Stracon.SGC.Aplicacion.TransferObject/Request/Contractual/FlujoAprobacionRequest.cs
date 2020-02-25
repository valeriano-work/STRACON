using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using System.Collections.Generic;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Flujo Aprobacion 
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class FlujoAprobacionRequest : Filtro
    {
        /// <summary>
        /// Constructor de clase
        /// </summary>
        public FlujoAprobacionRequest()
        {
            EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;
        }

        /// <summary>
        /// Codigo Flujo Aprobacion
        /// </summary>
        public string CodigoFlujoAprobacion { get; set; }
        /// <summary>
        /// Codigo Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Indicador de Aplica Monto Mínimo
        /// </summary>
        public bool? IndicadorAplicaMontoMinimo { get; set; }

        /// <summary>
        /// Lista de Códigos de Tipo de Servicio
        /// </summary>
        public List<string> ListaTipoServicio { get; set; }
        
        /// <summary>
        /// Indicador que determina si se traen las descripciones, aplica solo en busquedas
        /// </summary>
        public bool IndicadorObtenerDescripcion { get; set; }

        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }

        /// <summary>
        /// Orden de firmante
        /// </summary>
        public int OrdenFirmante { get; set; }

        /// <summary>
        /// Código de Primer Firmante
        /// </summary>
        public string CodigoPrimerFirmante { get; set; }

        /// <summary>
        /// Código de Segundo Firmante
        /// </summary>
        public string CodigoSegundoFirmante { get; set; }

        /// <summary>
        /// Código de Primer Firmante Vinculada
        /// </summary>
        public string CodigoPrimerFirmanteVinculada { get; set; }

        /// <summary>
        /// Código de Segundo Firmante Vinculada
        /// </summary>
        public string CodigoSegundoFirmanteVinculada { get; set; }
    }
}

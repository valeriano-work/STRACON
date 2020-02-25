using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Flujo Aprobacion
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class FlujoAprobacionLogic : Logic
    {
        /// <summary>
        /// Codigo Flujo Aprobacion
        /// </summary>
        public Guid CodigoFlujoAprobacion { get; set; }
        /// <summary>
        /// Codigo Unidad Operativa
        /// </summary>
        public Guid CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Indicador de Aplica Monto Mínimo
        /// </summary>
        public bool IndicadorAplicaMontoMinimo { get; set; }
        /// <summary>
        /// Código Primer Firmante
        /// </summary>
        public Guid? CodigoPrimerFirmante { get; set; }
        /// <summary>
        /// Código Segundo Firmante
        /// </summary>
        public Guid? CodigoSegundoFirmante { get; set; }

        /// <summary>
        /// Código Primer Firmante Vinculada
        /// </summary>
        public Guid? CodigoPrimerFirmanteVinculada { get; set; }
        /// <summary>
        /// Código Segundo Firmante Vinculada
        /// </summary>
        public Guid? CodigoSegundoFirmanteVinculada { get; set; }
    }
}

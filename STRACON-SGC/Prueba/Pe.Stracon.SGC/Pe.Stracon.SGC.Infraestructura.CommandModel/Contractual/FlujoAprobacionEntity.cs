using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Flujo Aprobacion
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150508 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class FlujoAprobacionEntity : Entity
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
        /// Código de primer firmante
        /// </summary>
        public Guid? CodigoPrimerFirmante { get; set; }
        /// <summary>
        /// Código de Segundo Firmante
        /// </summary>
        public Guid? CodigoSegundoFirmante { get; set; }
        /// <summary>
        /// Código de primer firmante Original
        /// </summary>
        public Guid? CodigoPrimerFirmanteOriginal { get; set; }
        /// <summary>
        /// Código de Segundo Firmante Original
        /// </summary>
        public Guid? CodigoSegundoFirmanteOriginal { get; set; }

        /// <summary>
        /// Código de primer firmante Vinculada
        /// </summary>
        public Guid? CodigoPrimerFirmanteVinculada { get; set; }
        /// <summary>
        /// Código de Segundo firmante Vinculada
        /// </summary>
        public Guid? CodigoSegundoFirmanteVinculada { get; set; }
    }
}

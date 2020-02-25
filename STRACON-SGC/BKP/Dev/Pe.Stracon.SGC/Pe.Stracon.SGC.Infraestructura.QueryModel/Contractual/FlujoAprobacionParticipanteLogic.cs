using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Flujo Aprobacion Participante
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150701 <br />
    /// Modificación : <br />
    /// </remarks>
    public class FlujoAprobacionParticipanteLogic : Logic
    {
        /// <summary>
        /// Codigo Flujo Aprobacion Estadio
        /// </summary>
        public Guid CodigoFlujoAprobacionEstadio { get; set; }
        /// <summary>
        /// Codigo de trabajador responsable de estadio.
        /// </summary>
        public Guid? CodigoTrabajador { get; set; }
        /// <summary>
        /// Código del Tipo de Participante.
        /// </summary>
        public string CodigoTipoParticipante { get; set; }
        /// <summary>
        /// Indicador de incluir visto
        /// </summary>
        public bool? IndicadorIncluirVisto { get; set; }
        /// <summary>
        /// Indicador si es firmante
        /// </summary>
        public bool? IndicadorEsFirmante { get; set; }
        /// <summary>
        /// Orden Firmante
        /// </summary>
        public int? OrdenFirmante { get; set; }
    }
}

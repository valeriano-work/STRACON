using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto response de Flujo Aprobacion Participante
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class FlujoAprobacionParticipanteResponse : Paginado
    {
        /// <summary>
        /// Codigo Flujo Aprobacion Participante
        /// </summary>
        public string CodigoFlujoAprobacionParticipante { get; set; }
        /// <summary>
        /// Codigo Flujo Aprobacion Estadio
        /// </summary>
        public string CodigoFlujoAprobacionEstadio { get; set; }
        /// <summary>
        /// Codigo Trabajador
        /// </summary>
        public Guid? CodigoTrabajador { get; set; }
        /// <summary>
        /// Codigo Tipo Participante
        /// </summary>
        public string CodigoTipoParticipante { get; set; }
        /// <summary>
        /// Orden firmante
        /// </summary>
        public int? OrdenFirmante { get; set; }
        /// <summary>
        /// Indicador si es firmante
        /// </summary>
        public bool? IndicadorEsFirmante { get; set; }
    }
}

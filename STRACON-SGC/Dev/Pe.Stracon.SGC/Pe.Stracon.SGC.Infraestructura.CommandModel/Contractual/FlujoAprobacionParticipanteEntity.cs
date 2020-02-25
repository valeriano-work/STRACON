using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Flujo Aprobacion Participante
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150508 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class FlujoAprobacionParticipanteEntity : Entity
    {
        /// <summary>
        /// Codigo Flujo Aprobacion Participante
        /// </summary>
        public Guid CodigoFlujoAprobacionParticipante { get; set; }
        /// <summary>
        /// Codigo Flujo Aprobacion Estadio
        /// </summary>
        public Guid CodigoFlujoAprobacionEstadio { get; set; }
        /// <summary>
        /// Codigo Trabajador
        /// </summary>
        public Guid CodigoTrabajador { get; set; }
        /// <summary>
        /// Codigo Tipo Participante
        /// </summary>
        public string CodigoTipoParticipante { get; set; }
        /// <summary>
        /// Codigo Participante Original
        /// </summary>
        public Guid CodigoTrabajadorOriginal { get; set; }     
    }
}

using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Flujo Aprobacion Participante
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class FlujoAprobacionParticipanteRequest : Filtro
    {
        /// <summary>
        /// Constructor de clase
        /// </summary>
        public FlujoAprobacionParticipanteRequest()
        {
            EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;
        }

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
        public string CodigoTrabajador { get; set; }
        /// <summary>
        /// Codigo Tipo Participante
        /// </summary>
        public string CodigoTipoParticipante { get; set; } 
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
        /// <summary>
        /// Codigo  Participante Original
        /// </summary>
        public string CodigoTrabajadorOriginal { get; set; }    
    }
}

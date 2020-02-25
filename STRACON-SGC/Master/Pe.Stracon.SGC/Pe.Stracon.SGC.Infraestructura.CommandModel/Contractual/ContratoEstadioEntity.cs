using System;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Contrato Estadio
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150511 <br />
    /// Modificación :           <br />
    /// </remarks>  
    public class ContratoEstadioEntity : Entity
    {
        /// <summary>
        /// Codigo de Contrato de Estadio
        /// </summary>
        public Guid CodigoContratoEstadio { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid CodigoContrato { get; set; }
        /// <summary>
        /// Codigo Flujo de Aprobacion Estadio
        /// </summary>
        public Guid CodigoFlujoAprobacionEstadio { get; set; }
        /// <summary>
        /// Fecha de Ingreso
        /// </summary>
        public DateTime FechaIngreso { get; set; }
        /// <summary>
        /// Fecha de Finalizacion
        /// </summary>
        public DateTime? FechaFinalizacion { get; set; }
        /// <summary>
        /// Codigo de Responsable
        /// </summary>
        public Guid? CodigoResponsable { get; set; }
        /// <summary>
        /// Estado del Contrato Estadio.
        /// </summary>
        public string CodigoEstadoContratoEstadio { get; set; }
        /// <summary>
        /// Fecha de Primera Notificacion
        /// </summary>
        public DateTime? FechaPrimeraNotificacion { get; set; }
        /// <summary>
        /// Fecha de Ultima Notificacion
        /// </summary>
        public DateTime? FechaUltimaNotificacion { get; set; } 
    }
}

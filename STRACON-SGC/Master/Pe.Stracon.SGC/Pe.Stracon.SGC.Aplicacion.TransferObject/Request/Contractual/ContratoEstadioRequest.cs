using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request del contrato
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150529 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ContratoEstadioRequest : Filtro
    {
        /// <summary>
        /// Codigo de Contrato Estadio
        /// </summary>
        public Guid? CodigoContratoEstadio { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid? CodigoContrato { get; set; }
        /// <summary>
        /// Codigo Flujo Aprobacion de Estadio
        /// </summary>
        public Guid? CodigoFlujoAprobacionEstadio { get; set; }
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
        /// Codigo Estado de Contrato Estadio
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

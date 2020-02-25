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
    public class RequerimientoEstadioRequest : Filtro
    {
        /// <summary>
        /// Codigo de Contrato Estadio
        /// </summary>
        public Guid? CodigoRequerimientoEstadio { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid? CodigoRequerimiento { get; set; }
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
        public string CodigoEstadoRequerimientoEstadio { get; set; }
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

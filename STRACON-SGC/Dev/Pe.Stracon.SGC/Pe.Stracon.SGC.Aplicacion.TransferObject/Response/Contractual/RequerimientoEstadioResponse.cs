using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Requerimiento Estadio
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150608 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class RequerimientoEstadioResponse
    {
        /// <summary>
        /// CodigoRequerimientoEstadio
        /// </summary>
        public Guid CodigoRequerimientoEstadio { get; set; }
        /// <summary>
        /// CodigoRequerimiento
        /// </summary>
        public Guid CodigoRequerimiento { get; set; }
        /// <summary>
        /// CodigoFlujoAprobacionEstadio
        /// </summary>
        public Guid CodigoFlujoAprobacionEstadio { get; set; }
        /// <summary>
        /// FechaIngreso
        /// </summary>
        public DateTime FechaIngreso { get; set; }
        /// <summary>
        /// FechaFinalizacion
        /// </summary>
        public DateTime? FechaFinalizacion { get; set; }
        /// <summary>
        /// CodigoResponsable
        /// </summary>
        public Guid? CodigoResponsable { get; set; }
        /// <summary>
        /// CodigoEstadoRequerimientoEstadio
        /// </summary>
        public string CodigoEstadoRequerimientoEstadio { get; set; }
        /// <summary>
        /// FechaPrimeraNotificacion
        /// </summary>
        public DateTime? FechaPrimeraNotificacion { get; set; }
        /// <summary>
        /// FechaUltimaNotificacion
        /// </summary>
        public DateTime? FechaUltimaNotificacion { get; set; }
        /// <summary>
        /// Número de Requerimiento
        /// </summary>
        public string NumeroRequerimiento { get; set; }
        /// <summary>
        /// Codigo de Unidad de Operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Nombre de Proveedor
        /// </summary>
        public string NombreProveedor { get; set; }
        /// <summary>
        /// Informados
        /// </summary>
        public string Informados { get; set; }
    }
}

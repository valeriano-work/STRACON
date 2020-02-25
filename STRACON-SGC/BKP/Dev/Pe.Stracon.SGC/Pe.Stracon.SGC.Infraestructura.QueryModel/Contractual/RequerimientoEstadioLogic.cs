using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;
using System;
namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Requerimiento Estadio
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class RequerimientoEstadioLogic : Logic
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

        /// <summary>
        /// Descripción de LA observación
        /// </summary>
        public string DescripcionObservacion { get; set; }

        /// <summary>
        /// Descripción del Requerimiento
        /// </summary>
        public string DescripcionRequerimiento { get; set; }

        /// <summary>
        /// Usuario Creación del Requerimiento
        /// </summary>
        public string UsuarioCreacion { get; set; }
    }
}

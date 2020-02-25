using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;
using System;
namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Contrato Estadio
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ContratoEstadioLogic : Logic
    {
        /// <summary>
        /// CodigoContratoEstadio
        /// </summary>
        public Guid CodigoContratoEstadio { get; set; }
        /// <summary>
        /// CodigoContrato
        /// </summary>
        public Guid CodigoContrato { get; set; }
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
        /// CodigoEstadoContratoEstadio
        /// </summary>
        public string CodigoEstadoContratoEstadio { get; set; }
        /// <summary>
        /// FechaPrimeraNotificacion
        /// </summary>
        public DateTime? FechaPrimeraNotificacion { get; set; }
        /// <summary>
        /// FechaUltimaNotificacion
        /// </summary>
        public DateTime? FechaUltimaNotificacion { get; set; }
        /// <summary>
        /// Número de Contrato
        /// </summary>
        public string NumeroContrato { get; set; }
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
        /// Descripción del Contrato
        /// </summary>
        public string DescripcionContrato { get; set; }

        /// <summary>
        /// Usuario Creación del Contrato
        /// </summary>
        public string UsuarioCreacion { get; set; }
    }
}

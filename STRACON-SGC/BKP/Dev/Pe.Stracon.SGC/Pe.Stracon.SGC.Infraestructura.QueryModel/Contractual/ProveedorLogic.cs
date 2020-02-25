using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;
using System;
namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Proveedor
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ProveedorLogic : Logic
    {
        /// <summary>
        /// Codigo Proveedor
        /// </summary>
        public Guid CodigoProveedor { get; set; }
        /// <summary>
        /// Codigo Identificacion
        /// </summary>
        public string CodigoIdentificacion { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Nombre Comercial
        /// </summary>
        public string NombreComercial { get; set; }
        /// <summary>
        /// Tipo Documento
        /// </summary>
        public string TipoDocumento { get; set; }
        /// <summary>
        /// Numero Documento
        /// </summary>
        public string NumeroDocumento { get; set; } 


    }
}

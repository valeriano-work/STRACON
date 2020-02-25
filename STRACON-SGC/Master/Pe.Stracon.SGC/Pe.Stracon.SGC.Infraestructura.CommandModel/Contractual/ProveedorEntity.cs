using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;


namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Proveedor
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150511 <br />
    /// Modificación :           <br />
    /// </remarks> 
    public class ProveedorEntity : Entity
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

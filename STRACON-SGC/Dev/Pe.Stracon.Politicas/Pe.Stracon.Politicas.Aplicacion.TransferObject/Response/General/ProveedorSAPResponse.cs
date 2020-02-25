using System;
namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Representa el objeto response de Proveedores
    /// </summary>
    /// <remarks>
    /// Creación:   QUALISW 20191112 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ProveedorSAPResponse
    {
        /// <summary>
        /// Código Proveedor
        /// </summary>
        public string CodigoProveedor { get; set; }
        /// <summary>
        /// Nombre Proveedor
        /// </summary>        
        public string NombreCompleto { get; set; }        
    }
}

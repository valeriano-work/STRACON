using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Base
{
    /// <summary>
    /// Representa el objeto response de Proveedor
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150602 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ProveedorResponse
    {
        /// <summary>
        /// Código de Proveedor
        /// </summary>
        public Guid? CodigoProveedor { get; set; }
        /// <summary>
        /// Código de Identificación
        /// </summary>
        public string CodigoIdentificacion { get; set; }
        /// <summary>
        /// Nombre del Proveedor
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Nombre Comercial
        /// </summary>
        public string NombreComercial { get; set; }
        /// <summary>
        /// Tipo de Documento
        /// </summary>
        public string TipoDocumento { get; set; }
        /// <summary>
        /// Número de Documento
        /// </summary>
        public string NumeroDocumento { get; set; }
    }
}

using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;
using System;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General
{
    /// <summary>
    /// Representa el objeto request de Trabajador
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150401 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ProveedorSAPRequest : Filtro
    {
        /// <summary>
        /// Código de Trabajador
        /// </summary>
        public string CodigoProveedor { get; set; }
        /// <summary>
        /// Código de Identificación
        /// </summary>      
        public string Nombres { get; set; }
        /// <summary>
        /// Nombre Completo
        /// </summary>
        public string NombreCompleto { get; set; }             
    }
}

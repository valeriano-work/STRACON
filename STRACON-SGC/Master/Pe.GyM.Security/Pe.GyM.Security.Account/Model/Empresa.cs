using System;
using System.Collections.Generic;

namespace Pe.GyM.Security.Account.Model
{
    /// <summary>
    /// Objecto que representa una Empresa
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    [Serializable]
    public class Empresa
    {
        /// <summary>
        /// IdCompany
        /// </summary>
        public int IdCompany { get; set; }
        /// <summary>
        /// IdPais
        /// </summary>
        public int IdPais { get; set; }
        /// <summary>
        /// IdArea
        /// </summary>
        public int IdArea { get; set; }
        /// <summary>
        /// Ruc
        /// </summary>
        public string Ruc { get; set; }
        /// <summary>
        /// Direccion
        /// </summary>
        public string Direccion { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Nombre Empresa
        /// </summary>
        public string NombreEmpresa { get; set; }
        /// <summary>
        /// Area Negocio
        /// </summary>
        public string AreaNegocio { get; set; }
       
        
    }    
}

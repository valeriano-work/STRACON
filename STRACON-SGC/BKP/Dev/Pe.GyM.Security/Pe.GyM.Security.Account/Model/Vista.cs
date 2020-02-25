using System;
using System.Collections.Generic;

namespace Pe.GyM.Security.Account.Model
{
    /// <summary>
    /// Objecto que representa una vista de módulo
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    [Serializable]
    public class Vista
    {
        /// <summary>
        /// Código de identificación
        /// </summary>
        public int Codigo { get; set; }
        /// <summary>
        /// Nombre 
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// URL de acceso
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// Indicado si es vista principal  
        /// </summary>
        public bool EsPrincipal { get; set; }
        /// <summary>
        /// Lista de controles asignados
        /// </summary>
        public List<Control> Controles { get; set; }
    }
}

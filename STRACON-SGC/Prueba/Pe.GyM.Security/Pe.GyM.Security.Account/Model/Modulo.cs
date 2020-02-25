using System;
using System.Collections.Generic;
using System.Linq;

namespace Pe.GyM.Security.Account.Model
{
    /// <summary>
    /// Objecto que representa un modulo de sistema
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    [Serializable]
    public class Modulo
    {
        /// <summary>
        /// Código de identificación
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// Código de sistema
        /// </summary>
        public string CodigoSistema { get; set; }
        /// <summary>
        /// Nombre 
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Icono
        /// </summary>
        public string Icono { get; set; }
        /// <summary>
        /// Modulo hijos asignados
        /// </summary>
        public List<Modulo> SubModulos { get; set; }
        /// <summary>
        /// Vistas asignadas
        /// </summary>
        public List<Vista> Vistas { get; set; }    
        /// <summary>
        /// Indica si se encuenta como modulo actual
        /// </summary>
        public bool EsActual { get; set; }
        /// <summary>
        /// Obtiene la vista inicial del modulo
        /// </summary>
        /// <returns></returns>
        public Vista GetPrincipalView()
        {
            Vista result = null;

            if (Vistas != null && Vistas.Any())
            {
                result = Vistas.FirstOrDefault(v => v.EsPrincipal);
                result = result ?? Vistas.OrderBy(v => v.Nombre).First();
            }

            return result;
        }
    }
}

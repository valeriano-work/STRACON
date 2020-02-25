using Pe.Stracon.SGC.Cross.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Cross.Core.Security
{
    /// <summary>
    /// Objecto que representa un entorno de usuario en la aplicación
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public class EntornoActualAplicacion : IEntornoActualAplicacion
    {
        /// <summary>
        /// Alias del usaurio en sesión
        /// </summary>
        public string UsuarioSession { get; set; }
        /// <summary>
        /// Terminal de donde se accedio
        /// </summary>
        public string Terminal { get; set; }
        /// <summary>
        /// Codigo actual del sistema
        /// </summary>
        public string CodigoSistema { get; set; }
        /// <summary>
        /// Codigo actual de la empresa del sistema
        /// </summary>
        public string CodigoEmpresa { get; set; }
    }
}

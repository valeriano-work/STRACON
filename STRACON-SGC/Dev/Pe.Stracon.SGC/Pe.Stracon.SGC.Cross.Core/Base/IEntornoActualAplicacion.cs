using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Cross.Core.Base
{
    /// <summary>
    /// Objecto que representa un entorno de usuario en la aplicación
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public interface IEntornoActualAplicacion
    {
        /// <summary>
        /// Alias del usaurio en sesión
        /// </summary>
        string UsuarioSession { get; set; }
        /// <summary>
        /// Terminal de donde se accedio
        /// </summary>
        string Terminal { get; set; }
        /// <summary>
        /// Codigo actual del sistema
        /// </summary>
        string CodigoSistema { get; set; }
        /// <summary>
        /// Codigo actual de la empresa del sistema
        /// </summary>
        string CodigoEmpresa { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Variable Lista
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150527 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class VariableListaResponse
    {
        /// <summary>
        /// Codigo de variable lista
        /// </summary>
        public Guid CodigoVariableLista { get; set; }
        /// <summary>
        /// Codigo de variable
        /// </summary>
        public Guid CodigoVariable { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
    }
}

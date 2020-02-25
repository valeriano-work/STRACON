using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Implementación de la entidad para Lista de Variable
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150627 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class VariableListaEntity : Entity
    {
        /// <summary>
        /// Código de Lista
        /// </summary>
        public Guid CodigoVariableLista { get; set; }
        /// <summary>
        /// Código de Variable
        /// </summary>
        public Guid CodigoVariable { get; set; }
        /// <summary>
        /// Nombre de Campo
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        
    }
}

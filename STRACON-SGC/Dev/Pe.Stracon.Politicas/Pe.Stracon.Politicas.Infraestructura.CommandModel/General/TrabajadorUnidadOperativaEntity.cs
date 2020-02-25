using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad trabajadorUnidadOperativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorUnidadOperativaEntity : Entity
    {
        /// <summary>
        /// Código de TrabajadorUnidadOperativa
        /// </summary>
        public Guid? CodigoTrabajadorUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Unidad Operativa Matriz
        /// </summary>
        public Guid CodigoUnidadOperativaMatriz { get; set; }
        /// <summary>
        /// Código de Trabajador
        /// </summary>
        public Guid? CodigoTrabajador { get; set; }
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
    }
}

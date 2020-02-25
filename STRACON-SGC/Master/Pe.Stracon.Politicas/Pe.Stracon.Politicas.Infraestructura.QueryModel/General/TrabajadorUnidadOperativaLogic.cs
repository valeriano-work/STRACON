using Pe.Stracon.Politicas.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Infraestructura.QueryModel.General
{
    /// <summary>
    /// Representa los datos de TrabajadorUnidadOperativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22150326 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorUnidadOperativaLogic : Logic
    {
        /// <summary>
        /// Código de TrabajadorUnidadOperativa
        /// </summary>
        public Guid? CodigoTrabajadorUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Unidad Operativa Matriz
        /// </summary>
        public Guid? CodigoUnidadOperativaMatriz { get; set; }
        /// <summary>
        /// Código de trabajador
        /// </summary>
        public Guid? CodigoTrabajador { get; set; }
        /// <summary>
        /// Código unidad operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Estado de registro
        /// </summary>
        public string EstadoRegistro { get; set; }
        /// <summary>
        /// Nombre de unidad operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }
        /// <summary>
        /// Fecha de creacion
        /// </summary>
        public DateTime FechaCreacion { get; set; }
       
    }
}

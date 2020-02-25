using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General
{
    /// <summary>
    /// Representa el objeto request de TrabajadorUnidadOperativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150401 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorUnidadOperativaRequest : Filtro
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
        public Guid CodigoTrabajador { get; set; }
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public Guid CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
    }
}

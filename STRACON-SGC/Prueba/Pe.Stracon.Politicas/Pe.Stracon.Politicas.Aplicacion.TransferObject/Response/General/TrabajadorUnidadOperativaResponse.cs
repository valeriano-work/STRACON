using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Datos generales de trabajadorUnidadOperativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorUnidadOperativaResponse
    {
        /// <summary>
        /// Código de trabajador unidad operativa
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
        /// Codigo de unidad operativa 
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Nombre de unidad operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }
        /// <summary>
        /// Estado actual del registro
        /// </summary>
        public string EstadoRegistro { get; set; }
        /// <summary>
        /// Fecha de registro
        /// </summary>
        public DateTime FechaCreacion { get; set; }
    }
}

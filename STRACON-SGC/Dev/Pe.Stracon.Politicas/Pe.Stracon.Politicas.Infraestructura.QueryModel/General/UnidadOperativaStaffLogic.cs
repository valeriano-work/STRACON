using Pe.Stracon.Politicas.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Infraestructura.QueryModel.General
{
    /// <summary>
    /// Representa los datos generales de la unidad operativa staff
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22150326 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaStaffLogic : Logic
    {
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Identificación de la unidad operativa Staff
        /// </summary>
        public Guid? CodigoUnidadOperativaStaff { get; set; }
        /// <summary>
        /// Nivel asociado
        /// </summary>
        public Guid? CodigoSistema { get; set; }
        /// <summary>
        /// CodigoTrabajador
        /// </summary>
        public Guid? CodigoTrabajador { get; set; }
        /// <summary>
        /// NombreCompleto
        /// </summary>
        public string NombreCompleto { get; set; }
        /// <summary>
        /// Descripción del Nivel asociado
        /// </summary>
        public string NombreSistema { get; set; }
        /// <summary>
        /// Descripción del Nivel asociado
        /// </summary>
        public string EstadoRegistro { get; set; }
    }
}

using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad de unidad operativa staff
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaStaffEntity : Entity
    {
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Identificación de la unidad operativa
        /// </summary>
        public Guid? CodigoUnidadOperativaStaff { get; set; }     
        /// <summary>
        /// CodigoSistema
        /// </summary>
        public Guid? CodigoSistema { get; set; }
        /// <summary>
        /// CodigoTrabajador
        /// </summary>
        public Guid? CodigoTrabajador { get; set; }
    }
}

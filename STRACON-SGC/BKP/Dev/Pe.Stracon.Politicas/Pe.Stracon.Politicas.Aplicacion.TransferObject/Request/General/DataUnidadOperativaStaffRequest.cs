using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General
{
    public class DataUnidadOperativaStaffRequest
    {
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Identificación de la unidad operativa
        /// </summary>
        public string CodigoUnidadOperativaStaff { get; set; }
        /// <summary>
        /// CodigoSistema
        /// </summary>
        public string CodigoSistema { get; set; }
        /// <summary>
        /// CodigoTrabajador
        /// </summary>
        public string CodigoTrabajador { get; set; }
    }
}

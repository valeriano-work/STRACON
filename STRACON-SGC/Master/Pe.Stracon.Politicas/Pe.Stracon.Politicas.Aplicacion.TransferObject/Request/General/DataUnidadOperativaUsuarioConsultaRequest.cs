using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General
{
    /// <summary>
    /// Representa el objeto de filtro a aplicar a la Data Unidad Operativa Usuario consulta
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20161122 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class DataUnidadOperativaUsuarioConsultaRequest
    {
        /// <summary>
        /// Código de Identificación del usuario de consulta de una unidad operativa
        /// </summary>
        public string CodigoUnidadUsuarioConsulta { get; set; }   
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }             
        /// <summary>
        /// CodigoTrabajador
        /// </summary>
        public string CodigoTrabajador { get; set; }
    }
}

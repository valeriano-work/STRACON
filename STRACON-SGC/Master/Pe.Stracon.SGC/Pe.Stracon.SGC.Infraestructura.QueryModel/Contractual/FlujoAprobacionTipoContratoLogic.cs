using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Flujo Aprobación Tipo de Contrato
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20170621 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class FlujoAprobacionTipoContratoLogic
    {
        /// <summary>
        /// Código de Flujo de Aprobación Tipo de Contrato
        /// </summary>
        public Guid CodigoFlujoAprobacionTipoContrato { get; set; }
        /// <summary>
        /// Código de Flujo de Aprobación
        /// </summary>
        public Guid CodigoFlujoAprobacion { get; set; }
        /// <summary>
        /// Código de Tipo de Contrato
        /// </summary>
        public string CodigoTipoContrato { get; set; }
        /// <summary>
        /// Estadro de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
    }
}

using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Flujo Aprobación Tipo de Contrato
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20170621 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class FlujoAprobacionTipoContratoEntity : Entity
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
        /// Código de Tipo de Servicio
        /// </summary>
        public string CodigoTipoContrato { get; set; }
    }
}

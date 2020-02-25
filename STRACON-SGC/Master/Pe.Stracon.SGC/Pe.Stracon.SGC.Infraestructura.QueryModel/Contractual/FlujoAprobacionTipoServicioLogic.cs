using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Flujo Aprobación Tipo de Servicio
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20151124 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class FlujoAprobacionTipoServicioLogic : Logic
    {
        /// <summary>
        /// Código de Flujo de Aprobación Tipo de Servicio
        /// </summary>
        public Guid CodigoFlujoAprobacionTipoServicio { get; set; }
        /// <summary>
        /// Código de Flujo de Aprobación
        /// </summary>
        public Guid CodigoFlujoAprobacion { get; set; }
        /// <summary>
        /// Código de Tipo de Servicio
        /// </summary>
        public string CodigoTipoServicio { get; set; }
        /// <summary>
        /// Estadro de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
    }
}

using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad consulta
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150710 <br />
    /// Modificación: <br />
    /// </remarks>
    public class ConsultaTrazabilidadEntity : Entity
    {
        /// <summary>
        /// Codigo de consulta Trazabilidad
        /// </summary>
        public Guid CodigoConsultaTrazabilidad { get; set; }
        /// <summary>
        /// Código de consulta
        /// </summary>
        public Guid CodigoConsulta { get; set; }
        /// <summary>
        /// Código de Remitente
        /// </summary>
        public Guid CodigoRemitente { get; set; }
        /// <summary>
        /// Código de destinatario
        /// </summary>
        public Guid CodigoDestinatario { get; set; }
        /// <summary>
        /// Fecha de envío
        /// </summary>
        public DateTime FechaEnvio { get; set; }
    }
}

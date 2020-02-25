using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    public class ConsultaTrazabilidadLogic : Logic
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

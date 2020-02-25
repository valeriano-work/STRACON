using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Requerimiento Firmante
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150710 <br />
    /// Modificación: <br />
    /// </remarks>
    public class RequerimientoFirmanteEntity : Entity
    {
        /// <summary>
        /// Código contrato firmante
        /// </summary>
        public Guid CodigoRequerimientoFirmante { get; set; }
        /// <summary>
        /// Código de contrato párrafo variable
        /// </summary>
        public Guid CodigoRequerimientoParrafoVariable { get; set; }
        /// <summary>
        /// Nombre de firmante
        /// </summary>
        public string NombreFirmante { get; set; }
        /// <summary>
        /// Datos adicionales del firmante
        /// </summary>
        public string DatoAdicional { get; set; }

    }
}

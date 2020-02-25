using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa los datos de firmantes de un contrato
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20151020 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class RequerimientoFirmanteLogic : Logic
    {
        /// <summary>
        /// Codigo Requerimiento Firmante
        /// </summary>
        public Guid CodigoRequerimientoFirmante { get; set; }
        /// <summary>
        /// Codigo Requerimiento parrafo firmante
        /// </summary>
        public Guid CodigoRequerimientoParrafoVariable { get; set; }
        /// <summary>
        /// Nombre de firmante
        /// </summary>
        public string NombreFirmante { get; set; }
        /// <summary>
        /// Dato adicional
        /// </summary>
        public string DatoAdicional { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public char EstadoRegistro { get; set; }
    }
}

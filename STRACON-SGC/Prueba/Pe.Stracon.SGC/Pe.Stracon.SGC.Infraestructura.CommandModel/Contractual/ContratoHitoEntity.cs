using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Flujo Contrato-Hito
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150525 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ContratoHitoEntity : Entity
    {
        /// <summary>
        /// Codigo Contrato Hito
        /// </summary>
        public Guid CodigoContratoHito { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid CodigoContrato { get; set; }
        /// <summary>
        /// Codigo Tipo de Hito
        /// </summary>
        public string CodigoTipoHito { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Fecha Limite
        /// </summary>
        public DateTime FechaLimite { get; set; } 

    }
}

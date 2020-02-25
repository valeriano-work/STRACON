using System;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Contrato Bien
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150511 <br />
    /// Modificación :           <br />
    /// </remarks>  
    public class ContratoBienEntity : Entity
    {
        /// <summary>
        /// Codigo de Contrato de Bien
        /// </summary>
        public Guid CodigoContratoBien { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid CodigoContrato { get; set; }
        /// <summary>
        /// Codigo de Bien
        /// </summary>
        public Guid CodigoBien { get; set; }
        //INICIO: Agregado por Julio Carrera - Norma Contable
        /// <summary>
        /// Codigo tarifa
        /// </summary>
        public string CodigoTipoTarifa { get; set; }
        /// <summary>
        /// Codigo periodo
        /// </summary>
        public string CodigoTipoPeriodo { get; set; }
        /// <summary>
        /// Horas Minimas
        /// </summary>
        public int? HorasMinimas { get; set; }
        /// <summary>
        /// Tarifa
        /// </summary>
        public decimal Tarifa { get; set; }
        /// <summary>
        /// Es mayor o Menor
        /// </summary>
        public string MayorMenor { get; set; }
        //FIN: Agregado por Julio Carrera - Norma Contable
    }
}

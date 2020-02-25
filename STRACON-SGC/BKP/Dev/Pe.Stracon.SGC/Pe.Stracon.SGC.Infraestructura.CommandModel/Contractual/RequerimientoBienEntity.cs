using System;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Requerimiento Bien
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150511 <br />
    /// Modificación :           <br />
    /// </remarks>  
    public class RequerimientoBienEntity : Entity
    {
        /// <summary>
        /// Codigo de Requerimiento de Bien
        /// </summary>
        public Guid CodigoRequerimientoBien { get; set; }
        /// <summary>
        /// Codigo de Requerimiento
        /// </summary>
        public Guid CodigoRequerimiento { get; set; }
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

using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de contrato bien
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150803 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class RequerimientoBienRequest : Filtro
    {
        /// <summary>
        /// Código de Requerimiento Bien
        /// </summary>
        public string CodigoRequerimientoBien { get; set; }
        /// <summary>
        /// Código de Requerimiento
        /// </summary>
        public string CodigoRequerimiento { get; set; }
        /// <summary>
        /// Código de Bien
        /// </summary>
        public string CodigoBien { get; set; }
        //INICIO: Agregado por Julio Carrera - Norma Contable
        /// <summary>
        /// Tipo de tarifa
        /// </summary>
        public string TipoTarifa { get; set; }
        /// <summary>
        /// Tipo de periodo
        /// </summary>
        public string TipoPeriodo { get; set; }
        /// <summary>
        /// Horas minimas
        /// </summary>
        public int? HorasMinimas { get; set; }
        /// <summary>
        /// Tarifa
        /// </summary>
        public decimal Tarifa { get; set; }
        /// <summary>
        /// Equipo mayor o menor
        /// </summary>
        public string MayorMenor { get; set; }
        //FIN: Agregado por Julio Carrera - Norma Contable


    }
}

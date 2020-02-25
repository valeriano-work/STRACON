using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Base
{
    /// <summary>
    /// Entity Logic
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class Logic
    {
        /// <summary>
        /// Pagina solicitada
        /// </summary>
        public int NumeroPagina { get; set; }
        /// <summary>
        /// Registros por Pagina
        /// </summary>
        public int RegistrosPagina { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int64 TotalRegistro { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int64 NumeroRegistro { get; set; }
    }
}

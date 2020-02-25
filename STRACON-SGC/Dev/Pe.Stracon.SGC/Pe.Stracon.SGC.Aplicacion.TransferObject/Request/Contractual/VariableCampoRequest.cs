using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Variable Campo
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class VariableCampoRequest : Filtro
    {
        /// <summary>
        /// Codigo del Campo de Variable
        /// </summary>
        public string CodigoVariableCampo { get; set; }
        /// <summary>
        /// Codigo de Variable
        /// </summary>
        public string CodigoVariable { get; set; }
        /// <summary>
        /// Nombre del Campo
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Orden de la Variable
        /// </summary>
        public byte? Orden { get; set; }
        /// <summary>
        /// Tipo de Alineamiento
        /// </summary>
        public string TipoAlineamiento { get; set; }
        /// <summary>
        /// Tamaño de Columna
        /// </summary>
        public decimal? Tamanio { get; set; }
    }
}

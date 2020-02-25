using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de campo de variable
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150527 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class VariableCampoResponse
    {
        /// <summary>
        /// Código de Campo de Variable
        /// </summary>
        public Guid CodigoVariableCampo { get; set; }
        /// <summary>
        /// Código de Variable
        /// </summary>
        public Guid CodigoVariable { get; set; }
        /// <summary>
        /// Nombre del Campo
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Orden de la Variable
        /// </summary>
        public byte Orden { get; set; }
        /// <summary>
        /// Tipo de Alineamiento
        /// </summary>
        public string TipoAlineamiento { get; set; }
        /// <summary>
        /// Descripción de Tipo de Alineamiento
        /// </summary>
        public string DescripcionTipoAlineamiento { get; set; }
        /// <summary>
        /// Tamaño de Columna
        /// </summary>
        public decimal Tamanio { get; set; }
    }
}

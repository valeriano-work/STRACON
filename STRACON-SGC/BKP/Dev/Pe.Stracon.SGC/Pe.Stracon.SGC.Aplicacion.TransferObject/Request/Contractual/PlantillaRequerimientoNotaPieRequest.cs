using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de plantilla nota al pie
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20170821 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class PlantillaRequerimientoNotaPieRequest : Filtro
    {
        /// <summary>
        /// Código de Plantilla Nota Pie
        /// </summary>
        public string CodigoPlantillaNotaPie { get; set; }
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public string CodigoPlantilla { get; set; }
        /// <summary>
        /// Orden
        /// </summary>
        public byte? Orden { get; set; }
        /// <summary>
        /// Título
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Contenido de Tipo Html
        /// </summary>
        public string Contenido { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de plantilla párrafo
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150520 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class PlantillaRequerimientoParrafoResponse
    {
        /// <summary>
        /// Código de Plantilla Párrafo
        /// </summary>
        public Guid? CodigoPlantillaParrafo { get; set; }
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public Guid? CodigoPlantilla { get; set; }
        /// <summary>
        /// Orden
        /// </summary>
        public byte Orden { get; set; }
        /// <summary>
        /// Título
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Contenido
        /// </summary>
        public string Contenido { get; set; }
        /// <summary>
        /// Lista de variables del parrafo de la plantilla
        /// </summary>
        public List<PlantillaRequerimientoParrafoVariableResponse> ListaPlantillaParrafoVariable { get; set; }
    }
}

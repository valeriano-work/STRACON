using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de plantilla párrafo
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150520 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class PlantillaParrafoRequest : Filtro
    {
        /// <summary>
        /// Código de Plantilla Párrafo
        /// </summary>
        public string CodigoPlantillaParrafo { get; set; }
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
        /// <summary>
        /// Contenido de Tipo Cadena
        /// </summary>
        public string ContenidoCadena { get; set; }
        /// <summary>
        /// Indicador Obtener Lista Variable
        /// </summary>
        public bool IndicadorObtenerListaVariable { get; set; }
    }
}

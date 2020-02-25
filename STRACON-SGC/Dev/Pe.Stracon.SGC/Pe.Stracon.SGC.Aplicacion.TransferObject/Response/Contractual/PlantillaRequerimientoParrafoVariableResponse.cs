using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de plantilla párrafo variable
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150603 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class PlantillaRequerimientoParrafoVariableResponse

    {
        /// <summary>
        /// Código de Plantilla Párrafo Variable
        /// </summary>
        public Guid CodigoPlantillaParrafoVariable { get; set; }
        /// <summary>
        /// Código de Plantilla Párrafo
        /// </summary>
        public Guid CodigoPlantillaParrafo { get; set; }
        /// <summary>
        /// Código de Variable
        /// </summary>
        public Guid CodigoVariable { get; set; }
        /// <summary>
        /// Orden
        /// </summary>
        public Int16 Orden { get; set; }
        /// <summary>
        /// Código de Tipo de Variable
        /// </summary>
        public string CodigoTipoVariable { get; set; }
        /// <summary>
        /// Nombre de Variable
        /// </summary>
        public string NombreVariable { get; set; }
        /// <summary>
        /// Descripcion de Variable
        /// </summary>
        public string DescripcionVariable { get; set; }
        /// <summary>
        /// Identificador de Variable
        /// </summary>
        public string IdentificadorVariable { get; set; }
        /// <summary>
        /// Lista de opciones de la variable si es de tipo lista
        /// </summary>
        public List<VariableListaResponse> ListaOpcionesVariable { get; set; }
    }
}

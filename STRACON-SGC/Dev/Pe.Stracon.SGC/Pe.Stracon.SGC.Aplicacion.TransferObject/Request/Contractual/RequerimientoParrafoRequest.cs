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
    /// Representa el objeto request de Requerimiento Párrafo
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150609 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class RequerimientoParrafoRequest : Filtro
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public RequerimientoParrafoRequest()
        {
            ListaRequerimientoParrafoVariable = new List<RequerimientoParrafoVariableRequest>();
        }
        /// <summary>
        /// Código de Requerimiento Párrafo
        /// </summary>
        public string CodigoRequerimientoParrafo { get; set; }
        /// <summary>
        /// Código de Requerimiento
        /// </summary>
        public string CodigoRequerimiento { get; set; }
        /// <summary>
        /// Código de Plantilla Párrafo
        /// </summary>
        public string CodigoPlantillaParrafo { get; set; }
        /// <summary>
        /// Contenido
        /// </summary>
        public string ContenidoParrafo { get; set; }

        /// <summary>
        /// Lista de Requerimiento Párrafo Variable
        /// </summary>
        public List<RequerimientoParrafoVariableRequest> ListaRequerimientoParrafoVariable { get; set; }
    }
}

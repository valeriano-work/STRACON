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
    /// Representa el objeto request de Contrato Párrafo
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150609 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ContratoParrafoRequest : Filtro
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ContratoParrafoRequest()
        {
            ListaContratoParrafoVariable = new List<ContratoParrafoVariableRequest>();
        }
        /// <summary>
        /// Código de Contrato Párrafo
        /// </summary>
        public string CodigoContratoParrafo { get; set; }
        /// <summary>
        /// Código de Contrato
        /// </summary>
        public string CodigoContrato { get; set; }
        /// <summary>
        /// Código de Plantilla Párrafo
        /// </summary>
        public string CodigoPlantillaParrafo { get; set; }
        /// <summary>
        /// Contenido
        /// </summary>
        public string ContenidoParrafo { get; set; }

        /// <summary>
        /// Lista de Contrato Párrafo Variable
        /// </summary>
        public List<ContratoParrafoVariableRequest> ListaContratoParrafoVariable { get; set; }
    }
}

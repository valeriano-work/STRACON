using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de variable
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150527 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class VariableResponse
    {
        /// <summary>
        /// Código de Variable
        /// </summary>
        public Guid? CodigoVariable { get; set; }
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public Guid? CodigoPlantilla { get; set; }
        /// <summary>
        /// Descripción codigo plantilla
        /// </summary>
        public string DescripcionCodigoPlantilla { get; set; }
        /// <summary>
        /// Identificador
        /// </summary>
        public string Identificador { get; set; }
        /// <summary>
        /// Identificador sin Almohadilla
        /// </summary>
        public string IdentificadorSinAlmohadilla { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Código de Tipo de Variable
        /// </summary>
        public string CodigoTipo { get; set; }
        /// <summary>
        /// Descripcion Codigo Tipo
        /// </summary>
        public string DescripcionCodigoTipo { get; set; }
        /// <summary>
        /// Descripción de Tipo de Variable
        /// </summary>
        public string DescripcionTipoVariable { get; set; }
        /// <summary>
        /// Indicador de Variable Global
        /// </summary>
        public bool? IndicadorGlobal { get; set; }
        /// <summary>
        /// Indicador de Variable de Sistema
        /// </summary>
        public bool IndicadorVariableSistema { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
    }
}

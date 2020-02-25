using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa los datos de la Variable
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150527 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class VariableLogic : Logic
    {
        /// <summary>
        /// Código de Variable
        /// </summary>
        public Guid CodigoVariable { get; set; }
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public Guid? CodigoPlantilla { get; set; }
        /// <summary>
        /// Identificador
        /// </summary>
        public string Identificador { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Código de Tipo de Variable
        /// </summary>
        public string CodigoTipo { get; set; }
        /// <summary>
        /// Indicador de Variable Global
        /// </summary>
        public bool? IndicadorGlobal { get; set; }
        /// <summary>
        /// Descripción de Tipo de Variable
        /// </summary>
        public string DescripcionTipoVariable { get; set; }        
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

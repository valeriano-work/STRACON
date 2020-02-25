using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Representa un objeto response de Resultado
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150401 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ResultResponse : Paginado
    {
        /// <summary>
        /// Indicador de Exito
        /// </summary>
        public int IndicadorExito { get; set; }
    }
}

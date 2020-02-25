using Pe.Stracon.PoliticasCross.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.PoliticasCross.Core.Exception
{
    /// <summary>
    /// Infrastructure Exception
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class InfrastructureLayerException<T> : GenericException<T>
        where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public InfrastructureLayerException(string message, System.Exception e) : base(message, e) { }
    }
}

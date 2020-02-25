using log4net;

namespace Pe.Stracon.PoliticasCross.Core.Base
{
    /// <summary>
    /// Exception base
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public abstract class GenericException<T> : System.Exception, IGenericException
        where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(typeof(T));
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        protected GenericException(string message, System.Exception e)
            : base(message, e.GetBaseException())
        {
            log.Error(message,e.GetBaseException());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected GenericException(System.Exception e)
            : base("Error : " + typeof(T).Name + " , see more detail.(view innerException)", e.GetBaseException())
        {

            log.Error("Error : " + typeof(T).Name + " , see more detail.(view innerException)", e.GetBaseException());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        protected GenericException(string message)
            : base(message)
        {
            log.Error(message);
        }
    }
}

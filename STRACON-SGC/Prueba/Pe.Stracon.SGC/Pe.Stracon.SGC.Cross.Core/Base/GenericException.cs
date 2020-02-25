using log4net;

namespace Pe.Stracon.SGC.Cross.Core.Base
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
        private static readonly ILog log = LogManager.GetLogger(typeof(T));

        protected GenericException(string message, System.Exception e)
            : base(message, e)
        {
            log.Error(message, e);
        }

        protected GenericException(System.Exception e)
            : base("Error : " + typeof(T).Name + " , see more detail.(view innerException)", e)
        {

            log.Error("Error : " + typeof(T).Name + " , see more detail.(view innerException)", e);
        }

        protected GenericException(string message)
            : base(message)
        {
            log.Error(message);
        }
    }
}

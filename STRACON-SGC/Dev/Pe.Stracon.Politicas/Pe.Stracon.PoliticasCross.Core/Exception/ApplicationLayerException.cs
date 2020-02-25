using Pe.Stracon.PoliticasCross.Core.Base;

namespace Pe.Stracon.PoliticasCross.Core.Exception
{
    /// <summary>
    /// Application Exception
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ApplicationLayerException<T> : GenericException<T>
        where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsCustomException { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public ApplicationLayerException(string message, System.Exception e) : base(message, e) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public ApplicationLayerException(System.Exception e) : base(e) { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public ApplicationLayerException(string message)
            : base(message)
        {
            this.IsCustomException = true;
        }
    }
}

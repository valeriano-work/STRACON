using Pe.Stracon.SGC.Cross.Core.Base;

namespace Pe.Stracon.SGC.Cross.Core.Exception
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
        public bool IsCustomException { get; set; }
        public ApplicationLayerException(string message, System.Exception e) : base(message, e) { }
        public ApplicationLayerException(System.Exception e) : base(e) { }
        public ApplicationLayerException(string message)
            : base(message)
        {
            this.IsCustomException = true;
        }
    }
}

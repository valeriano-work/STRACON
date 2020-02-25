using Pe.Stracon.SGC.Cross.Core.Base;

namespace Pe.Stracon.SGC.Cross.Core.Exception
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
        public InfrastructureLayerException(string message, System.Exception e) : base(message, e) { }
    }
}

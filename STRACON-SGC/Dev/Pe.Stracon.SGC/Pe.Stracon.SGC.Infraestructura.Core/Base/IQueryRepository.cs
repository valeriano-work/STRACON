using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;
using System;

namespace Pe.Stracon.SGC.Infraestructura.Core.Base
{
    /// <summary>
    /// Repository contract: for Read a DTO.
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public interface IQueryRepository<T> : IDisposable
         where T : Logic
    {
    }
}

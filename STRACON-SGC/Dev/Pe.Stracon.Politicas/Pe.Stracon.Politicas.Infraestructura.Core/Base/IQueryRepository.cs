using Pe.Stracon.Politicas.Infraestructura.QueryModel.Base;
using System;

namespace Pe.Stracon.Politicas.Infraestructura.Core.Base
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

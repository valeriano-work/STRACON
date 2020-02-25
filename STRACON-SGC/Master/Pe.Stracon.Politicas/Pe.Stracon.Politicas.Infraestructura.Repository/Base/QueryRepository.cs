using Pe.Stracon.Politicas.Infraestructura.Core.Base;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.Politicas.Infraestructura.Repository.Base
{
    /// <summary>
    /// Se encarga de realizar consultas a la base de datos
    /// </summary>
    /// <typeparam name="T">Parametro T</typeparam>
    public class QueryRepository<T> : IQueryRepository<T>
        where T : Logic
    {
        /// <summary>
        /// data Base Provider
        /// </summary>
        public IDbContextProvider dataBaseProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (this.dataBaseProvider != null)
            {
                this.dataBaseProvider.Dispose();
            }
        }
    }
}

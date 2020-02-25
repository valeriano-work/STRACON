using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Base
{
    public class QueryRepository<T> : IQueryRepository<T>
        where T : Logic
    {
        public IDbContextProvider dataBaseProvider { get; set; }

        public void Dispose()
        {
            if (this.dataBaseProvider != null)
            {
                this.dataBaseProvider.Dispose();
            }
        }
    }
}

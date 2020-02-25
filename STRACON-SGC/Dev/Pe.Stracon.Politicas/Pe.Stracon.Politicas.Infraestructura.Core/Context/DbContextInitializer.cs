
using System.Data.Entity;

namespace Pe.Stracon.Politicas.Infraestructura.Core.Context
{
    // DropCreateDatabaseIfModelChanges<DeliveryContext> // DropCreateDatabaseAlways //CreateDatabaseIfNotExists<GenericDBContext>

    /// <summary>
    /// Inicialización del contexto Entity Framework
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class DbContextInitializer : CreateDatabaseIfNotExists<PoliticaDbContextProvider>
    {
        protected override void Seed(PoliticaDbContextProvider context)
        {
        }
    }
}

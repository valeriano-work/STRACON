using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Core.Context
{
    /// <summary>
    /// Proveedor de contexto
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public interface IDbContextProvider : IDisposable
    {
        /// <summary>
        /// Indicador de carga perezosa
        /// </summary>
        bool LazyLoadingEnabled { get; set; }
        /// <summary>
        /// Inidicador de implementación de proxy
        /// </summary>
        bool ProxyCreationEnabled { get; set; }
        /// <summary>
        /// Base de datos asociado al contexto
        /// </summary>
        Database DataBase { get; }
        /// <summary>
        /// Cadena de conexión
        /// </summary>
        string ConnectionString { get; set; }
        /// <summary>
        /// genera el DbSet de una entidad
        /// </summary>
        /// <typeparam name="T">entidad asociada</typeparam>
        /// <returns>DbSet de la entidad asociada</returns>
        IDbSet<T> DbSet<T>() where T : Entity;
        /// <summary>
        /// Setea el estado de la entidad a modificado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="entidad">Entidad</param>
        /// <returns>Entidad modificada</returns>
        T Modified<T>(T entidad) where T : Entity;
        /// <summary>
        /// Persiste los cambios
        /// </summary>
        /// <returns>Registros afectados</returns>
        int Persist();
        /// <summary>
        /// Ejecuta un store procedure del tipo consulta
        /// </summary>
        /// <typeparam name="T">Tipo de entidad de resultado</typeparam>
        /// <param name="query">Nombre del store procedure</param>
        /// <param name="parameters">Parametros</param>
        /// <returns>Resultado</returns>
        IEnumerable<T> ExecuteStoreProcedure<T>(string query, params object[] parameters);
        /// <summary>
        /// Ejecuta un store procedure del tipo escalar
        /// </summary>
        /// <param name="query">Nombre del store procedure</param>
        /// <param name="parameters">Parametros</param>
        /// <returns>Resultado</returns>
        T ExecuteStoreProcedureScalar<T>(string query, params object[] parameters);
        /// <summary>
        /// Ejecuta un store procedure del tipo transacción
        /// </summary>
        /// <param name="query">Nombre del store procedure</param>
        /// <param name="parameters">Parametros</param>
        /// <returns>Resultado</returns>
        int ExecuteStoreProcedureNonQuery(string query, params object[] parameters);
    }
}

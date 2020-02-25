using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace Pe.Stracon.SGC.Infraestructura.Core.Context
{
    /// <summary>
    /// Proveedor del contexto de base de datos de auditoria
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class SGCAuditDbContextProvider : DbContext, IDbContextProvider
    {
        /// <summary>
        /// Constructor por defecto de implementación de la clase
        /// </summary>
        public SGCAuditDbContextProvider()
            : base("SGCAuditDbContextProvider")
        {

        }

        /// <summary>
        /// Establece la configuración de creación de la base de datos
        /// </summary>
        /// <param name="modelBuilder">contructor del modelo de base de datos</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            this.MapEntitiesFromMappingConfigurations(modelBuilder);

        }
        /// <summary>
        /// Permite inicializar el mapping de cada entidad
        /// </summary>
        /// <param name="modelBuilder">contructor del modelo de base de datos</param>
        private void MapEntitiesFromMappingConfigurations(DbModelBuilder modelBuilder)
        {
            string assemblyName = ConfigurationManager.AppSettings["SGCModelAssembly"];

            if (!string.IsNullOrEmpty(assemblyName))
            {
                Assembly assemblyModel = Assembly.Load(assemblyName);

                List<Type> list = assemblyModel.GetTypes()
                    .Where(type =>
                        type.BaseType != null &&
                        type.BaseType.IsGenericType &&
                        type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityMapping<>))
                    .ToList<Type>();

                list.ForEach(type =>
                {
                    object obj = Activator.CreateInstance(type);
                    var methot = obj.GetType().GetMethod("ConfigureAuditMapping");
                    bool hasAudit = (bool)methot.Invoke(obj, new object[] { true });
                    if (hasAudit)
                    {
                        modelBuilder.Configurations.Add((dynamic)obj);
                    }

                });
            }
        }
        /// <summary>
        /// Indicador de carga perezosa
        /// </summary>
        public bool LazyLoadingEnabled
        {
            get { return this.Configuration.LazyLoadingEnabled; }
            set { this.Configuration.LazyLoadingEnabled = value; }
        }
        /// <summary>
        /// Inidicador de implementación de proxy
        /// </summary>
        public bool ProxyCreationEnabled
        {
            get { return this.Configuration.ProxyCreationEnabled; }
            set { this.Configuration.ProxyCreationEnabled = value; }
        }
        /// <summary>
        /// Cadena de conexión
        /// </summary>
        public string ConnectionString
        {
            get { return this.Database.Connection.ConnectionString; }
            set { this.Database.Connection.ConnectionString = value; }
        }
        /// <summary>
        /// Base de datos asociado al contexto
        /// </summary>
        public Database DataBase
        {
            get { return this.Database; }
        }
        /// <summary>
        /// genera el DbSet de una entidad
        /// </summary>
        /// <typeparam name="T">entidad asociada</typeparam>
        /// <returns>DbSet de la entidad asociada</returns>
        public IDbSet<T> DbSet<T>() where T : CommandModel.Base.Entity
        {
            return this.Set<T>();
        }
        /// <summary>
        /// Setea el estado de la entidad a modificado
        /// </summary>
        /// <typeparam name="T">Tipo entidad</typeparam>
        /// <param name="entidad">Entidad</param>
        /// <returns>Entidad modificada</returns>
        public T Modified<T>(T entity) where T : CommandModel.Base.Entity
        {
            this.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return entity;
        }
        /// <summary>
        /// Persiste los cambios
        /// </summary>
        /// <returns>Registros afectados</returns>
        public int Persist()
        {
            return this.SaveChanges();
        }
        /// <summary>
        /// Ejecuta un store procedure del tipo consulta
        /// </summary>
        /// <typeparam name="T">Tipo de entidad de resultado</typeparam>
        /// <param name="query">Nombre del store procedure</param>
        /// <param name="parameters">Parametros</param>
        /// <returns>Resultado</returns>
        public IEnumerable<T> ExecuteStoreProcedure<T>(string query, params object[] parameters)
        {
            query = this.GenerateQueryString(query, parameters);
            return this.Database.SqlQuery<T>(query, parameters);
        }
        /// <summary>
        /// Ejecuta un store procedure del tipo escalar
        /// </summary>
        /// <param name="query">Nombre del store procedure</param>
        /// <param name="parameters">Parametros</param>
        /// <returns>Resultado</returns>
        public T ExecuteStoreProcedureScalar<T>(string query, params object[] parameters)
        {
            T result = this.ExecuteStoreProcedure<T>(query, parameters).FirstOrDefault();
            return result;
        }
        /// <summary>
        /// Ejecuta un store procedure del tipo transacción
        /// </summary>
        /// <param name="query">Nombre del store procedure</param>
        /// <param name="parameters">Parametros</param>
        /// <returns>Resultado</returns>
        public int ExecuteStoreProcedureNonQuery(string query, params object[] parameters)
        {
            query = this.GenerateQueryString(query, parameters);
            return this.Database.ExecuteSqlCommand(query, parameters);
        }
        /// <summary>
        /// Permite generar la sentencia a ejecutar
        /// </summary>
        /// <param name="query">nombre de store procedure</param>
        /// <param name="parameters">parametros de entrada del store procedure</param>
        /// <returns>Sentencia a ejecutar</returns>
        private string GenerateQueryString(string query, params object[] parameters)
        {
            if (!query.Contains("@"))
            {
                for (var i = 0; i < parameters.Length; i++)
                {
                    if (i == 0)
                    {
                        query += " @" + ((System.Data.SqlClient.SqlParameter)(parameters[i])).ParameterName;
                    }
                    else
                    {
                        query += ", @" + ((System.Data.SqlClient.SqlParameter)(parameters[i])).ParameterName;
                    }
                }
            }
            return query;
        }
    }
}

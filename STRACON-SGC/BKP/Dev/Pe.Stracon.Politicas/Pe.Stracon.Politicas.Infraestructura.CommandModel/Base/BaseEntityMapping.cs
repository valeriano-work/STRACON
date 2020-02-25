using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq.Expressions;
using System.Reflection;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.Base
{
    /// <summary>
    /// Clase base para el mapping de entidades
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public abstract class BaseEntityMapping<T> : EntityTypeConfiguration<T>
        where T : Entity
    {
        private static readonly string PROPERTY_KEY_AUDIT = "IdAudit";
        /// <summary>
        /// Permite configurar los atributos del registro de auditoria.
        /// </summary>
        /// <param name="isAuditContex">Indicador si es un contexto de auditoria</param>
        /// <returns>Indicador si la entidad tiene registro de auditoria</returns>
        public bool ConfigureAuditMapping(bool isAuditContex)
        {
            var keyAudit = typeof(T).GetProperty(PROPERTY_KEY_AUDIT, BindingFlags.NonPublic | BindingFlags.Instance);
            var hasAudit = false;
            if (keyAudit != null)
            {
                var hasTraceAudit = typeof(T).GetCustomAttribute<TraceAuditAttribute>();

                ParameterExpression arg = Expression.Parameter(typeof(T), "x");
                Expression expr = arg;

                expr = Expression.Property(expr, keyAudit);
                LambdaExpression lambda = Expression.Lambda(expr, arg);
                Expression<Func<T, int>> expression = (Expression<Func<T, int>>)lambda;
                if (isAuditContex && hasTraceAudit != null)
                {
                    HasKey(expression);
                    Property(expression)
                   .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                    hasAudit = true;
                }
            }
            return hasAudit;
        }
    }
}

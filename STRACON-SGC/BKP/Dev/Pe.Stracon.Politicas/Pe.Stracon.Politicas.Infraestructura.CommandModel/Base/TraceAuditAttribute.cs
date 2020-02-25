using System;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.Base
{
    /// <summary>
    /// Define si una entidad va registrar auditoria o no
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TraceAuditAttribute : Attribute
    {
        /// <summary>
        /// Constructor de TraceAuditAttribute
        /// </summary>
        public TraceAuditAttribute() { }
    }
}

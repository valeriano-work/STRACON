using System;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.Politicas.Infraestructura.QueryModel.General
{
    /// <summary>
    /// Representa los datos de la unidad operativa usuario consulta
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20161122 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaUsuarioConsultaLogic : Logic
    {
        /// <summary>
        /// Código de Identificación de la unidad operativa usuario consulta
        /// </summary>
        public Guid? CodigoUnidadUsuarioConsulta { get; set; }
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }   
        /// <summary>
        /// Código del trabajador
        /// </summary>
        public Guid? CodigoTrabajador { get; set; }
        /// <summary>
        /// Nombre completo del trabajador
        /// </summary>
        public string NombreCompleto { get; set; }        
        /// <summary>
        /// Estado del registro
        /// </summary>
        public string EstadoRegistro { get; set; }
        /// <summary>
        /// Nombre de la unidad operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }        
    }
}

using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Datos generales del Usuario consulta de la Unidad Operativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22112016 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaUsuarioConsultaResponse
    {
        /// <summary>
        /// Código de Identificación de la unidad operativa responsable
        /// </summary>
        public Guid? CodigoUnidadUsuarioConsulta { get; set; }
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }        
        /// <summary>
        /// Código Trabajador
        /// </summary>
        public Guid? CodigoTrabajador { get; set; }
        /// <summary>
        /// Estado del registro
        /// </summary>
        public string EstadoRegistro { get; set; }
        /// <summary>
        /// Descripción del Nombre completo del trabajador
        /// </summary>
        public string NombreCompleto { get; set; }
        /// <summary>
        /// Nombre de la unidad operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }
    }
}

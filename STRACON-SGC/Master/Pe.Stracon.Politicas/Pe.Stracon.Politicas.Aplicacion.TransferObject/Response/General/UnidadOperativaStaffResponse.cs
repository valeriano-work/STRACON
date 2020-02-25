using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Datos generales de la unidad operativa staff
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaStaffResponse : Paginado
    {
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Identificación de la unidad operativa
        /// </summary>
        public Guid? CodigoUnidadOperativaStaff { get; set; }
        /// <summary>
        /// Código Sistema
        /// </summary>
        public Guid? CodigoSistema { get; set; }
        /// <summary>
        /// Código Trabajador
        /// </summary>
        public Guid? CodigoTrabajador { get; set; }

        /// <summary>
        /// Descripción del Nivel asociado
        /// </summary>
        public string EstadoRegistro { get; set; }
        /// <summary>
        /// Descripción del Nombre Completo
        /// </summary>
        public string NombreCompleto { get; set; }
        /// <summary>
        /// Descripción del Nombre Sistema
        /// </summary>
        public string NombreSistema { get; set; }

    }
}

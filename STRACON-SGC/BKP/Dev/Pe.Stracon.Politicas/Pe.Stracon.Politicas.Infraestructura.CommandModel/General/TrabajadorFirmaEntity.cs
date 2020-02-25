using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using System;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad trabajador firma.
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorFirmaEntity : Entity
    {
        /// <summary>
        /// Código de Firma del Trabajador.
        /// </summary>
        public Guid? Codigo { get; set; }
        /// <summary>
        /// Código de Trabajador.
        /// </summary>
        public Guid? CodigoTrabajador { get; set; }
        /// <summary>
        /// Firma de Trabajador.
        /// </summary>
        public Byte[] Firma { get; set; }
    }
}

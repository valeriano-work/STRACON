using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General
{
    /// <summary>
    /// Representa el objeto de filtro a aplicar a la busqueda de trabajador
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class FiltroTrabajador : Filtro
    {
        /// <summary>
        /// Código de trabajador
        /// </summary>
        public string CodigoTrabajador { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Código de identifiación
        /// </summary>
        public string CodigoIdentifiacion { get; set; }
        /// <summary>
        /// Código tipo documento de identidad
        /// </summary>
        public string CodigoTipoDocumentoIdentidad { get; set; }
        /// <summary>
        /// Número documento de identidad
        /// </summary>
        public string NumeroDocumentoIdentidad { get; set; }

    }
}

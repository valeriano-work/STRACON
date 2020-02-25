using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Representa el objeto response de TrabajadorSuplente
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150401 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorSuplenteResponse
    {
        /// <summary>
        /// Codigo del trabajador
        /// </summary>
        public Guid CodigoTrabajador { get; set; }
        /// <summary>
        /// Código de Suplente
        /// </summary>
        public Guid CodigoSuplente { get; set; }
        /// <summary>
        /// Fecha de Inicio
        /// </summary>
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// Fecha de Inicio en cadena
        /// </summary>
        public string FechaInicioString { get; set; }
        /// <summary>
        /// Fecha Fin
        /// </summary>
        public DateTime FechaFin { get; set; }
        /// <summary>
        /// Fecha Fin en cadena
        /// </summary>
        public string FechaFinString { get; set; }
        /// <summary>
        /// Es Activo
        /// </summary>
        public bool Activo { get; set; }
        /// <summary>
        /// Ejecutado
        /// </summary>
        public bool? Ejecutado { get; set; }
        /// <summary>
        /// Diccionario de suplente
        /// </summary>
        public Dictionary<string, string> ListaSuplente { get; set; }
        /// <summary>
        /// Perfiles agregados al suplente al SRA
        /// </summary>
        public string PerfilAgregados { get; set; }
    }
}

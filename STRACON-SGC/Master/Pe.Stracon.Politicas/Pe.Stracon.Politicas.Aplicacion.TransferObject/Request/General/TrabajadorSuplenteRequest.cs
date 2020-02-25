using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General
{
    /// <summary>
    /// Representa el objeto request de TrabajadorSuplente
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150401 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorSuplenteRequest : Filtro
    {
        /// <summary>
        /// Código de trabajador
        /// </summary>
        public Guid CodigoTrabajador { get; set; }
        /// <summary>
        /// Código de Suplente
        /// </summary>
        public Guid? CodigoSuplente { get; set; }
        /// <summary>
        /// Fecha de inicio
        /// </summary>
        public string FechaInicio { get; set; }
        /// <summary>
        /// Fecha fin 
        /// </summary>
        public string FechaFin { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }
        /// <summary>
        /// Ejecutado
        /// </summary>
        public bool? Ejecutado { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
        /// <summary>
        /// Perfiles agregados temporales al ser reemplazo
        /// </summary>
        public string PerfilesAgregados { get; set; }
        /// <summary>
        /// Usuario de Sesion
        /// </summary>
        public string UsuarioSession { get; set; }
        /// <summary>
        /// Terminal
        /// </summary>
        public string Terminal { get; set; }
    }
}

using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad trabajador suplente
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorSuplenteEntity : Entity
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
        public DateTime FechaInicio { get; set; }
        /// <summary>
        /// Fecha fin 
        /// </summary>
        public DateTime FechaFin { get; set; }
        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }
        /// <summary>
        /// Ejecutado
        /// </summary>
        public bool? Ejecutado { get; set; }
        /// <summary>
        /// Perfiles agregados temporales al ser reemplazo
        /// </summary>
        public string PerfilesAgregados { get; set; }
    }
}

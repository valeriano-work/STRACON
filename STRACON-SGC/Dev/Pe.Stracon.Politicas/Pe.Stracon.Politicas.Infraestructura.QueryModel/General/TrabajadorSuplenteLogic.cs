using Pe.Stracon.Politicas.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Infraestructura.QueryModel.General
{
    public class TrabajadorSuplenteLogic : Logic
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
        /// Fecha Fin
        /// </summary>
        public DateTime FechaFin { get; set; }
        /// <summary>
        /// Es Activo
        /// </summary>
        public bool Activo { get; set; }
        /// <summary>
        /// Ejecutado
        /// </summary>
        public bool? Ejecutado { get; set; }
        /// <summary>
        /// Perfiles agregados al suplente al SRA
        /// </summary>
        public string PerfilAgregados { get; set; }
    }
}

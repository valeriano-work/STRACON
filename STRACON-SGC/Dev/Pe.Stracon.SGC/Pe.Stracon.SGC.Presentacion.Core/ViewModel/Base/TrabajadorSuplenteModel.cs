using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base
{
    /// <summary>
    /// Modelo de vista para el formulario TrabajadorSuplente
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public class TrabajadorSuplenteModel : GenericViewModel
    {
        public TrabajadorSuplenteModel(TrabajadorResponse trabajador)
        {
            this.TrabajadorSuplente = new TrabajadorSuplenteResponse();
            this.TrabajadorSuplente.ListaSuplente = new Dictionary<string, string>();
            this.Trabajador = trabajador;
        }
        /// <summary>
        /// Constructor del Modelo
        /// </summary>
        /// <param name="trabajadorSuplente">TrabajadorSuplente</param>
        /// <param name="trabajador">Trabajador</param>
        public TrabajadorSuplenteModel(TrabajadorSuplenteResponse trabajadorSuplente, TrabajadorResponse trabajador)
        {
            this.TrabajadorSuplente = trabajadorSuplente;
            this.Trabajador = trabajador;
        }

        #region Propiedades
        /// <summary>
        /// TrabajadorSuplente
        /// </summary>
        public TrabajadorSuplenteResponse TrabajadorSuplente { get; set; }
        /// <summary>
        /// Trabajador
        /// </summary>
        public TrabajadorResponse Trabajador { get; set; }
        #endregion
    }
}

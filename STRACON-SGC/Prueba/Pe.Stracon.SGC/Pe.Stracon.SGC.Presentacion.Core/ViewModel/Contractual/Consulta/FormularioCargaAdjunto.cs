using Pe.GyM.Security.Account.Model;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Consulta
{
    /// <summary>
    /// Modelo de vista de Formulario de Carga de adjunto de consulta
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150602 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class FormularioCargaAdjunto : GenericViewModel
    {
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public FormularioCargaAdjunto()
        {
            this.ControlPermisos = new Control();
        }

        /// <summary>
        /// Datos del Contrato
        /// </summary>
        public ConsultaResponse Consulta { get; set; }
        /// <summary>
        /// Usuario de Sesión
        /// </summary>
        public string UsuarioSession { get; set; }
        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }
    }
}

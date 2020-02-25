using Pe.GyM.Security.Account.Model;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ArchivoAdjuntoContratoResolucion
{
    /// <summary>
    /// Modelo de vista de documento adjunto de contrato
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ArchivoAdjuntoContratoResolucionFormulario
    {
        /// <summary>
        /// Contructor de la clase
        /// </summary>
        public ArchivoAdjuntoContratoResolucionFormulario()
        {
            this.ControlPermisos = new Control();
        }

        /// <summary>
        /// Datos del Contrato
        /// </summary>
        public ListadoContratoResponse Contrato { get; set; }
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
using Pe.GyM.Security.Account.Model;
using Pe.GyM.Security.Account.SSOAuthenticateService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.GyM.Security.Account.Adapter
{
    /// <summary>
    /// Objecto que representa un control de una vista
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public sealed class CuentaUsuarioAdapter
    {
        /// <summary>
        /// Genera un objeto CuentaUsuario desde una objeto Web user del SSO
        /// </summary>
        /// <param name="webUser">Parametro webUser</param>
        /// <returns>Cuenta de Usuario</returns>
        public static CuentaUsuario ObtenerCuentaUsuario(WebUser webUser)
        {
            CuentaUsuario resultado = null;
            if (webUser != null)
            {
                resultado = new CuentaUsuario()
                {
                    Codigo = webUser.ID_USER,
                    Dominio = webUser.S_DOMAIN_RED,
                    Alias = webUser.S_LOGIN,
                    Nombre = webUser.S_NAME,
                    //ApellidoPaterno = webUser.S_LAST_NAME,
                    ApellidoPaterno = webUser.S_LAST_NAME_1,
                    ApellidoMaterno = webUser.S_LAST_NAME_2,
                    CorreoElectronico = webUser.S_EMAIL,
                    Imagen = webUser.B_PHOTO_USER
                };
            }

            return resultado;
        }
    }
}

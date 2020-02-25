using System;
using System.Configuration;

namespace Pe.GyM.SGC.Cross.Core.Base
{
    /// <summary>
    /// Clase My Credencial
    /// </summary>
    [Serializable]
    public class ReporteCredencial : Microsoft.Reporting.WebForms.IReportServerCredentials
    {

        private static readonly string Usuario  = ConfigurationManager.AppSettings["SrvReportingUser"];
        public static readonly string Clave     = ConfigurationManager.AppSettings["SrvReportingPassword"];
        public static readonly string Domain    = ConfigurationManager.AppSettings["SrvReportingDomain"];

        /// <summary>
        /// Método pa obtener las credenciales de forma
        /// </summary>
        /// <param name="authCookie">Creador de la cookie</param>
        /// <param name="userName">Nombre del usuario</param>
        /// <param name="password">Contraseña</param>
        /// <param name="authority">Cargo</param>
        /// <returns>Verdadero o Falso</returns>
        public bool GetFormsCredentials(out System.Net.Cookie authCookie, out string userName, out string password, out string authority)
        {
            authCookie = null;
            userName = null;
            password = null;
            authority = null;
            return false;
        }

        /// <summary>
        /// ImpersonationUser
        /// </summary>
        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }

        /// <summary>
        /// NetworkCredentials
        /// </summary>
        public System.Net.ICredentials NetworkCredentials
        {
            get { return new System.Net.NetworkCredential(Usuario, Clave, Domain); }
        }
    }
}

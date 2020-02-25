using Pe.GyM.Security.Account.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pe.Stracon.PoliticasCross.Core.Util
{
    /// <summary>
    /// Clase Utilitaria
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>

    public class Utilitario
    {
        /// <summary>
        /// Obtiene los permisos de Lectura, Escritura y Control Total de la Opción seleccionada
        /// </summary>
        /// <param name="user">Cuenta de usuario de la sesión</param>
        /// <param name="url">Dirección Url de la opción seleccionada</param>
        /// <returns>Permisos de Lectura, Escritura y Control Total de la Opción seleccionada</returns>
        public static Control ObtenerControlPermisos(CuentaUsuario user, string url)
        {
            Control controles = new Control();

            bool lectura = true;
            bool escritura = true;
            bool controlTotal = true;
            bool urlEncontrada = false;

            foreach (var modulo in user.Modulos)
            {
                foreach (var subModulo in modulo.SubModulos)
                {
                    if (subModulo.Vistas.Exists(x => x.URL.EndsWith(url)))
                    {
                        if (subModulo.Vistas.Where(x => x.URL.EndsWith(url)).FirstOrDefault().Controles != null)
                        {
                            lectura = subModulo.Vistas.Where(x => x.URL.EndsWith(url)).FirstOrDefault().Controles.FirstOrDefault().Lectura;
                            escritura = subModulo.Vistas.Where(x => x.URL.EndsWith(url)).FirstOrDefault().Controles.FirstOrDefault().Escritura;
                            controlTotal = subModulo.Vistas.Where(x => x.URL.EndsWith(url)).FirstOrDefault().Controles.FirstOrDefault().ControlTotal;
                            urlEncontrada = true;
                        }
                        else
                        {
                            lectura = true;
                            escritura = true;
                            controlTotal = true;
                            urlEncontrada = true;
                        }
                        break;
                    }
                }

                if (urlEncontrada)
                {
                    break;
                }
            }

            //Asignando los Permisos
            controles.ControlTotal = controlTotal;
            controles.Escritura = escritura;
            controles.Lectura = lectura;


            return controles;
        }
    }
}

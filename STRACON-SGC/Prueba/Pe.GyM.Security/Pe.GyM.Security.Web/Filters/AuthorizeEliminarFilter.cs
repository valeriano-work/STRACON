using Pe.GyM.Security.Account.Model;
using Pe.GyM.Security.Web.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.GyM.Security.Web.Filters
{
    /// <summary>
    /// Filtro de validación de Permisos de Eliminación
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 08062016 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class AuthorizeEliminarFilter : AuthorizeAttribute
    {
        /// <summary>
        /// Metodo aplicado para la autotización del usuario para eliminar
        /// </summary>
        /// <param name="filterContext">Contexto actual de la petición</param>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            CuentaUsuario user = HttpGyMSessionContext.CurrentAccount();

            bool lectura = false;
            bool escritura = false;
            bool controlTotal = false;
            string url = filterContext.HttpContext.Request.UrlReferrer.AbsolutePath;

            if (filterContext.HttpContext.Request.UrlReferrer.Segments.Count() == 5)
            {
                url = filterContext.HttpContext.Request.UrlReferrer.Segments[0] + filterContext.HttpContext.Request.UrlReferrer.Segments[1] +
                    filterContext.HttpContext.Request.UrlReferrer.Segments[2] + filterContext.HttpContext.Request.UrlReferrer.Segments[3];
            }

            bool urlEncontrada = false;

            foreach (var modulo in user.Modulos)
            {
                foreach (var subModulo in modulo.SubModulos)
                {
                    if (subModulo.Vistas.Exists(x => x.URL.EndsWith(url)))
                    {
                        lectura = subModulo.Vistas.Where(x => x.URL.EndsWith(url)).FirstOrDefault().Controles.FirstOrDefault().Lectura;
                        escritura = subModulo.Vistas.Where(x => x.URL.EndsWith(url)).FirstOrDefault().Controles.FirstOrDefault().Escritura;
                        controlTotal = subModulo.Vistas.Where(x => x.URL.EndsWith(url)).FirstOrDefault().Controles.FirstOrDefault().ControlTotal;
                        urlEncontrada = true;
                        break;
                    }
                }

                if (urlEncontrada)
                {
                    break;
                }
            }

            if (!controlTotal)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                filterContext.Result.ExecuteResult(filterContext);
            }
        }
    }
}

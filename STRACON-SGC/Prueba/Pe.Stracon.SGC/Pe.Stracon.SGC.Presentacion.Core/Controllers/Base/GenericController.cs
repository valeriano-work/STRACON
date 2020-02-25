using Pe.GyM.Security.Account.Model;
using Pe.GyM.Security.Account.SRASecurityService;
using Pe.GyM.Security.Web.Filters;
using Pe.GyM.Security.Web.Session;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using System.Linq;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Base
{
    /// <summary>
    /// Controladora web base
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150107
    /// Modificación:   
    /// </remarks>
    [AuthorizeFilter]
    public class GenericController : Controller
    {
       
    }
}

using System.Configuration;
using System.Web.Mvc;
using Pe.GyM.Security.Web.Session;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using System.Linq;
using Pe.GyM.Security.Account.Model;
using Pe.GyM.Security.Account.SRASecurityService;
using System.Collections.Generic;
using Pe.Stracon.SGC.Presentacion.Core.Helpers;
using Pe.Stracon.SGC.Aplicacion.Core.Base;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Base
{
    /// <summary>
    /// Controladora Principal
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150318
    /// Modificación:
    /// </remarks>
    public class PrincipalController : GenericController
    {
        #region Propiedades
        /// <summary>
        /// Servicio de trabajadores
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }
        #endregion

        #region Vistas
        /// <summary>
        /// Muestra La Vista Principal
        /// </summary>
        /// <returns>Vista Index</returns>
        public ActionResult Index()
        {
            var cuenta = HttpGyMSessionContext.CurrentAccount();

            //Descomentar para entrar con un usuario con privilegios
            //cuenta.Alias = "cynthia.cayo";
            //cuenta.ApellidoPaterno = "Cayo";
            //cuenta.ApellidoMaterno = "";
            //cuenta.Nombre = "Cynthia";

            if (cuenta != null)
            {
                cuenta.CodigoEmpresa = ConfigurationManager.AppSettings["CODIGO_EMPRESA"];
                cuenta.CodigoSistema = ConfigurationManager.AppSettings["CODIGO_SISTEMA"];

                if (!string.IsNullOrEmpty(cuenta.Alias))
                {
                    var trabajadorSel = trabajadorService.BuscarTrabajador(new TrabajadorRequest() { CodigoIdentificacion = cuenta.Alias }).Result;

                    if (trabajadorSel != null)
                    {
                        var trabajador = trabajadorSel.FirstOrDefault();

                        if (trabajador != null)
                        {
                            cuenta.CodigoTrabajador = trabajador.CodigoTrabajador;
                            cuenta.CodigoUnidadOperativaMatriz = trabajador.CodigoUnidadOperativaMatriz;
                        }
                    }
                }

            }
            return View();
        }

        /// <summary>
        /// Obtiene los permisos asignados al usuario segun sistema
        /// </summary>
        /// <param name="usuario">Usuario</param>
        /// <param name="codigoSistema">Código del Sistema</param>
        /// <returns>Cuenta de Usuario</returns>
        public JsonResult ObtenerPermisos(string perfiles)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();

            var refrescar = false;
            var usuario = HttpGyMSessionContext.CurrentAccount();
            var codigoSistema = ConfigurationManager.AppSettings["CLIENT_SITE_TOKEN"];
            SeguridadServiceClient seguridadService = new SeguridadServiceClient();
            var lsSystem = seguridadService.List_SystemSRA_x_Token(codigoSistema, usuario.Codigo);
            if (lsSystem.Length > 0)
            {
                var sistema = lsSystem.FirstOrDefault();
                var perfile = seguridadService.GetUserAccessService(usuario.Alias, 0, sistema.N_ID_SYSTEM);
                usuario.Perfil = perfile.S_NAME_PROFILE;
                usuario.CodigoSistemaSra = sistema.N_ID_SYSTEM;

                usuario.Modulos = new List<Modulo>();
                var modulo = new Modulo();
                var vistasPermisos = new List<Vista>();
                modulo.Vistas = vistasPermisos;

                usuario.Modulos.Add(modulo);

                foreach (var rol in perfile.ROLES)
                {
                    foreach (var permiso in rol.PERMISOS)
                    {
                        var listaAgrupadoPorOpcion = rol.PERMISOS.Where(x => x.N_ID_OPTION == permiso.E_OptionM.N_ID_OPTION).ToList();
                        bool lectura = false;
                        bool escritura = false;
                        bool controlTotal = false;

                        foreach (var item in listaAgrupadoPorOpcion)
                        {
                            switch (item.N_ID_ACTION)
                            {
                                case 1:
                                    lectura = true;
                                    break;
                                case 2:
                                    escritura = true;
                                    break;
                                case 3:
                                    controlTotal = true;
                                    break;
                            }
                        }

                        var controles = new List<Control>();
                        controles.Add(new Control()
                        {
                            Lectura = lectura,
                            Escritura = escritura,
                            ControlTotal = controlTotal
                        });

                        vistasPermisos.Add(new Vista()
                        {
                            Nombre = permiso.S_NAME,
                            URL = permiso.E_OptionM.S_URL_OPTION,
                            Controles = controles
                        });
                    }
                }
            }

            if (usuario != null)
            {
                HttpGyMSessionContext.SetAccount(usuario);
                CustomHtmlHelper.AplicarMenu(usuario);
            }

            //Obtenemos los perfiles
            var usuarioSRA = seguridadService.GetUserByLoginAD(usuario.Alias, usuario.Dominio);
            if (usuarioSRA != null)
            {
                var perfilesOriginal = usuarioSRA.PERFILES.Where(p => p.S_TOKEN == ConfigurationManager.AppSettings["CLIENT_SITE_TOKEN"].ToString()).ToList();

                if (!string.IsNullOrEmpty(perfiles))
                {
                    string[] perfilesArray = perfiles.Split(',');

                    foreach (var item in perfilesArray)
                    {
                        if (perfilesOriginal.Where(x => x.N_ID_PROFILE.ToString() == item).FirstOrDefault() != null)
                        {
                            refrescar = true;
                        }
                    }

                    if (refrescar == false)
                    {
                        foreach (var item in perfilesArray)
                        {
                            if (item.Trim() == usuarioSRA.ID_USER.ToString())
                            {
                                refrescar = true;
                            }
                        }
                    }
                }
            }

            resultado.IsSuccess = true;
            resultado.Result = refrescar.ToString();
            return Json(resultado);
        }

        #endregion

        #region Vistas Parciales

        #endregion

        #region Json

        #endregion
    }
}

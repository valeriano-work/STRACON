using Pe.GyM.Security.Account.Model;
using Pe.GyM.Security.Account.Service;
using Pe.GyM.Security.Account.SRASecurityService;
using Pe.GyM.Security.Web.Session;
using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Presentacion.Core.Helpers;
using Pe.Stracon.Politicas.Presentacion.Recursos.Base;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Core.Controllers.Base
{
    /// <summary>
    /// Controladora de Usuario de Active Directory
    /// </summary>
    /// <remarks>
    /// Creación: 	GMD 20140508 <br />
    /// Modificación: 	 <br />
    /// </remarks>
    public class UsuarioADController : GenericController
    {
        /// <summary>
        /// Servicio de política
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult FormularioBusquedaUsuarioAD()
        {
            var ListaDominiosDinamico = politicaService.ListarDominioEmpresaDinamico();
            //this.DominiosEmpresas = GenericViewModel.GenerarListadoOpcioneGenericoFiltro(listaDominios);
            //Listar de Parametro
            List<SelectListItem> ListaParametro = new List<SelectListItem>();
            ListaParametro.Add(new SelectListItem { Value = "", Text = GenericoResource.EtiquetaSeleccionar });
            ListaParametro.AddRange(ListaDominiosDinamico.Result.Select(item => new SelectListItem
                        {
                            Value = item.Atributo3.ToString(),
                            Text = item.Atributo2.ToString()
                        }).ToList()
                    );
            ViewBag.ListaDominios = ListaParametro;
            return PartialView();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="Dominio"></param>
        /// <returns></returns>
        public JsonResult BuscarUsuarioAD(string Usuario, string Dominio)
        {
            var resultado = new ProcessResult<List<CuentaUsuario>>();
            CuentaUsuarioService icta = new CuentaUsuarioService();
            resultado.Result = icta.getUsuarioDeDirectorioActivo(Dominio, "04", Usuario);
            return Json(resultado);
        }

        #region Propiedades
        /// <summary>
        /// Dominios de empresas.
        /// </summary>
        public List<SelectListItem> DominiosEmpresas { get; set; }

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

        #endregion Propiedades
    }
}
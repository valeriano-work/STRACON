using System.Collections.Generic;
using Pe.GyM.Security.Account.Model;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using Pe.GyM.Security.Account.SSOAuthenticateService;
using Pe.GyM.Security.Account.Adapter;
using Pe.GyM.Security.Account.SRASecurityService;
using System.Linq;

namespace Pe.GyM.Security.Account.Service
{
    /// <summary>
    /// Servicio que maneja las funcionalidades asociadas a una cuenta de usuario
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public class CuentaUsuarioService
    {
        /// <summary>
        /// Valida el inicio de sesión de un usuario y si es satisfactorio obtiene sus acceso
        /// </summary>
        /// <param name="alias">alias de logueo</param>
        /// <param name="clave">Contraseña</param>
        /// <returns>Cuenta de Usuario</returns>
        public CuentaUsuario IniciarSession(string alias, string clave)
        {
            CuentaUsuario resultado = null;

            return resultado;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public CuentaUsuario IniciarSessionPorToken(string token, string codigoSistema)
        {
            CuentaUsuario resultado = this.ObtenerUsuarioPorToken(token);
            if (resultado != null)
            {
                resultado = this.ObtenerPermisos(resultado, codigoSistema);
            }
            return resultado;
        }

        /// <summary>
        /// Obtiene la cuenta de usuario asociado al token generado
        /// </summary>
        /// <param name="token">Token generado</param>
        /// <returns>Cuenta de Usuario</returns>
        public CuentaUsuario ObtenerUsuarioPorToken(string token)
        {

            CuentaUsuario resultado = null;
            if (token != null)
            {
                AuthenticateServiceClient service = new AuthenticateServiceClient();
                WebUser oWebUser = service.GetUserByToken(token);
                resultado = CuentaUsuarioAdapter.ObtenerCuentaUsuario(oWebUser);
            }
            return resultado;
        }
        /// <summary>
        /// Obtiene los permisos asignados al usuario segun sistema
        /// </summary>
        /// <param name="usuario">Usuario</param>
        /// <param name="codigoSistema">Código del Sistema</param>
        /// <returns>Cuenta de Usuario</returns>
        public CuentaUsuario ObtenerPermisos(CuentaUsuario usuario, string codigoSistema)
        {
            SeguridadServiceClient seguridadService = new SeguridadServiceClient();
            var lsSystem = seguridadService.List_SystemSRA_x_Token(codigoSistema, usuario.Codigo);
            if (lsSystem.Length > 0)
            {
                var sistema = lsSystem.FirstOrDefault();
                var perfile = seguridadService.GetUserAccessService(usuario.Alias, 0, sistema.N_ID_SYSTEM);
                var listCompanyUser = seguridadService.List_CompanyXsLogin(usuario.Alias);

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
                            Nombre    = permiso.E_OptionM.S_NAME, //Asi es lo correcto.
                            URL       = permiso.E_OptionM.S_URL_OPTION,
                            Controles = controles
                        });
                    }
                }

                usuario.ListEmpresa = new List<Empresa>();
                foreach (var item in listCompanyUser)
                {
                    Empresa obj = new Empresa();
                    obj.NombreEmpresa = item.S_NAME;
                    obj.Ruc = item.N_RUC;
                    obj.AreaNegocio = item.S_NAME_SHORT;
                    usuario.ListEmpresa.Add(obj);
                }

            }
            return usuario;
        }
        /// <summary>
        /// Valida el acceso a la url especifica
        /// </summary>
        /// <param name="url">url a validar</param>
        /// <returns>Si tiene acceso</returns>
        public bool ValidarAcceso(string url)
        {
            bool resultado = true;
            return resultado;
        }

        //Usuario desde AD
        #region AD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dominio"></param>
        /// <param name="tipoFiltro"></param>
        /// <param name="criterio"></param>
        /// <returns></returns>
        public List<CuentaUsuario> getUsuarioDeDirectorioActivo(string dominio, string tipoFiltro, string criterio)
        {
            string rutaDominio;
            List<CuentaUsuario> listaUsuario = new List<CuentaUsuario>();
            rutaDominio = this.getRutaDominio(dominio);
            DirectoryEntry oDirectorioEntrada = new DirectoryEntry(rutaDominio);
            string filtroDirectorio = getLDAPFilter(tipoFiltro, criterio);
            DirectorySearcher oBuscaDirectorio = new DirectorySearcher(oDirectorioEntrada, filtroDirectorio);
            oBuscaDirectorio.PageSize = 10;
            oBuscaDirectorio.PropertiesToLoad.Add("givenName");
            oBuscaDirectorio.PropertiesToLoad.Add("samaccountname");
            oBuscaDirectorio.PropertiesToLoad.Add("mail");
            oBuscaDirectorio.PropertiesToLoad.Add("company");
            oBuscaDirectorio.PropertiesToLoad.Add("title");
            oBuscaDirectorio.PropertiesToLoad.Add("sn");
            oBuscaDirectorio.PropertiesToLoad.Add("mobile");
            oBuscaDirectorio.PropertiesToLoad.Add("telephoneNumber");
            oBuscaDirectorio.PropertiesToLoad.Add("c");
            oBuscaDirectorio.PropertiesToLoad.Add("physicalDeliveryOfficeName");
            oBuscaDirectorio.PropertiesToLoad.Add("department");
            oBuscaDirectorio.PropertiesToLoad.Add("userPassword");
            oBuscaDirectorio.PropertiesToLoad.Add("postalCode");
            
            CuentaUsuario oCuentaUsuario;
            SearchResultCollection Data = oBuscaDirectorio.FindAll();
            foreach (SearchResult oResultado in Data)
            {
                oCuentaUsuario = new CuentaUsuario();
                if (oResultado.Properties["givenName"].Count > 0)
                    oCuentaUsuario.Nombre = (string)oResultado.Properties["givenName"][0];

                if (oResultado.Properties["samaccountname"].Count > 0)
                    oCuentaUsuario.Alias = (string)oResultado.Properties["samaccountname"][0];

                if (oResultado.Properties["mail"].Count > 0)
                    oCuentaUsuario.CorreoElectronico = (string)oResultado.Properties["mail"][0];

                if (oResultado.Properties["company"].Count > 0)
                    oCuentaUsuario.Organizacion = (string)oResultado.Properties["company"][0];

                if (oResultado.Properties["title"].Count > 0)
                    oCuentaUsuario.Cargo = (string)oResultado.Properties["title"][0];

                if (oResultado.Properties["sn"].Count > 0)
                {
                    oCuentaUsuario.ApellidoPaterno = (string)oResultado.Properties["sn"][0];
                    string[] apellidos = oCuentaUsuario.ApellidoPaterno.Split(' ');
                    if (apellidos.Length > 1)
                    {
                        oCuentaUsuario.ApellidoPaterno = apellidos[0];
                        oCuentaUsuario.ApellidoMaterno = apellidos[1];
                    }
                }

                if (oResultado.Properties["mobile"].Count > 0)
                    oCuentaUsuario.TelefonoMovil = (string)oResultado.Properties["mobile"][0];

                if (oResultado.Properties["telephoneNumber"].Count > 0)
                    oCuentaUsuario.TelefonoTrabajo = (string)oResultado.Properties["telephoneNumber"][0];

                if (oResultado.Properties["c"].Count > 0)
                    oCuentaUsuario.Pais = (string)oResultado.Properties["c"][0];

                if (oResultado.Properties["userPassword"].Count > 0)
                    oCuentaUsuario.Clave = (string)oResultado.Properties["userPassword"][0];

                if (oResultado.Properties["physicalDeliveryOfficeName"].Count > 0)
                    oCuentaUsuario.Ubigeo = (string)oResultado.Properties["physicalDeliveryOfficeName"][0];

                if (oResultado.Properties["department"].Count > 0)
                    oCuentaUsuario.Area = (string)oResultado.Properties["department"][0];

                if (oResultado.Properties["postalCode"].Count > 0)
                   oCuentaUsuario.NumeroDocumento = (string)oResultado.Properties["postalCode"][0];
                oCuentaUsuario.Dominio = dominio;

                listaUsuario.Add(oCuentaUsuario);
            }
            return listaUsuario;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Domain"></param>
        /// <returns></returns>
        private string getRutaDominio(string Domain)
        {
            string str = "LDAP://" + Domain.Trim() + "/";
           foreach (string str2 in Domain.Split(new char[] { '.' }))
            {
                str = str + "DC=" + str2 + ", ";
            }
            return str.Trim().Substring(0, str.Length - 2);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Filter"></param>
        /// <returns></returns>
        private string getLDAPFilter(string Type, string Filter)
        {
            Filter = Filter.Replace("&", "");
            Filter = Filter.Replace("|", "");
            Filter = Filter.Replace("*", "");
            string FilterByName = string.Empty;
            string filtro = string.Empty;
            switch (Type)
            {
                case "01":
                    FilterByName = "(displayname=*{0}*)";
                    filtro = "(|(&(objectCategory=person)(objectClass=user){0})(&(objectCategory=Group){0}))";
                    break;
                case "02":
                    filtro = "(&(objectCategory=Group){0})";
                    break;
                case "03":
                    filtro = "(|(&(objectCategory=person)(objectClass=user){0})(&(objectCategory=Group){0}))";
                    break;
                case "04":
                    FilterByName = "(samaccountName=*{0}*)";
                    filtro = "(&(objectCategory=person)(objectClass=user){0})";
                    break;
            }
            if (Filter == string.Empty)
            {
                return string.Format(filtro, string.Empty);
            }
            else
            {
                return string.Format(filtro, string.Format(FilterByName, Filter));
            }
        }
        #endregion
    }
}

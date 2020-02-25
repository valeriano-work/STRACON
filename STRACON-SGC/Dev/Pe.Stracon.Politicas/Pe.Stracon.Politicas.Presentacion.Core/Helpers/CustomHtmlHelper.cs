using Pe.GyM.Security.Account.Model;
using Pe.GyM.Security.Web.Session;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace Pe.Stracon.Politicas.Presentacion.Core.Helpers
{
    /// <summary>
    /// Helpers personalizados
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public static class CustomHtmlHelper
    {
        /// <summary>
        /// Renderiza los archivos js optimizados segun la vista actual
        /// </summary>
        /// <param name="scriptView">Vista del script</param>
        /// <returns>Indicador</returns>
        public static IHtmlString RenderViewJs(string scriptView = null)
        {
            if (string.IsNullOrWhiteSpace(scriptView))
            {
                var actionName = HttpContext.Current.Request.RequestContext.RouteData.Values["action"] ?? "";
                var controllerName = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"] ?? "";
                var area = HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"] ?? "";
                scriptView = area.ToString().ToLower() + controllerName.ToString().ToLower() + actionName.ToString().ToLower();
            }

            scriptView = "~/Scripts/" + scriptView;

            var exists = BundleTable.Bundles.GetRegisteredBundles().Any(b => b.Path == scriptView);
            IHtmlString result = null;
            if (exists)
            {
                result = Scripts.Render(scriptView);
            }

            return result;
        }
        /// <summary>
        /// Renderiza el componente Menú
        /// </summary>
        /// <returns>Html generado para el menú</returns>
        public static MvcHtmlString RenderMenu()
        {
            CuentaUsuario user = HttpGyMSessionContext.CurrentAccount();
            string htmlMenu = "";
            if (user != null)
            {
                
                TagBuilder wrap = new TagBuilder("div");
                wrap.Attributes.Add("data-script", "asideSlide");
                wrap.Attributes.Add("data-element", "slide");
                wrap.AddCssClass("nav-Wrap");

                TagBuilder nav = new TagBuilder("nav");
                nav.AddCssClass("nav-GmdNavMain");


                TagBuilder ul = new TagBuilder("ul");
                string innerHtmlUl = "";

                if (user.Modulos != null)
                {
                    SetActiveModule(user.Modulos);
                    foreach (var module in user.Modulos)
                    {
                        string link = CreateItemLinkModule(module);

                        innerHtmlUl += link;
                    }
                }
                ul.InnerHtml = innerHtmlUl;
                nav.InnerHtml = ul.ToString();
                wrap.InnerHtml = "<div class='bl-slide'></div>" + nav;
                htmlMenu = wrap.ToString();
            }
            return MvcHtmlString.Create(htmlMenu);
        }

        /// <summary>
        /// Crea el item para el modulo
        /// </summary>
        /// <param name="module">modulo</param>
        /// <returns>modulo</returns>
        private static string CreateItemLinkModule(Modulo module)
        {
            StringBuilder modulo = new StringBuilder();
            string active = module.EsActual ? "active" : "";
            modulo.Append("<li class='GmdNavMain-menuDropdown " + active + "' data-menu='dropdown'>");
            modulo.Append("<a href='#' data-element='button-dropdown'>");
            modulo.Append("<span class='wrap-icon'>");
            modulo.Append("<i class='fa " + module.Icono + "'></i></span><span class='wrap-text'>");
            modulo.Append("<span class='text'>" + module.Nombre + "</span><i class='fa fa-bars'></i></span></a>");
            modulo.Append("<ul class='GmdNavMain-subMenu'>");
            modulo.Append("<li class='title'>");
            modulo.Append(module.Nombre);
            modulo.Append("</li>");
            if (module.SubModulos != null && module.SubModulos.Any())
            {
                string subModulo = CreateContentModule(module);
                modulo.Append(subModulo);
            }
            modulo.Append("</ul>");
            modulo.Append("</li>");
            return modulo.ToString();
        }

        /// <summary>
        /// Crea el contenido del módulo
        /// </summary>
        /// <param name="module">Módulo</param>
        /// <returns>Módulo</returns>
        private static string CreateContentModule(Modulo module)
        {
            StringBuilder menuUl = new StringBuilder();

            if (module.SubModulos != null && module.SubModulos.Any())
            {

                foreach (var subModule in module.SubModulos)
                {
                    var mainView = subModule.GetPrincipalView();
                    string active = subModule.EsActual ? "active" : "";
                    UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                    string url = mainView.URL.ToLower().StartsWith("http") ? "" : urlHelper.Content("~/");
                    menuUl.Append("<li><a class='" + active + "' href='" + url + mainView.URL + "' >");//data-navAjax="true"
                    menuUl.Append("<span class='wrap-text-inner'>");
                    menuUl.Append("<span class='text'>");
                    menuUl.Append(subModule.Nombre);
                    menuUl.Append("</span>");
                    menuUl.Append("</span></a></li>");
                }

            }

            return menuUl.ToString();
        }

        /// <summary>
        /// Método que permite obtener establecer el módulo activo
        /// </summary>
        /// <param name="menu">Menu</param>
        private static void SetActiveModule(List<Modulo> menu)
        {
            string areaName = HttpContext.Current.Request.RequestContext.RouteData.DataTokens["area"].ToString();
            string controllerName = HttpContext.Current.Request.RequestContext.RouteData.Values["Controller"].ToString();
            string aciontionName = HttpContext.Current.Request.RequestContext.RouteData.Values["Action"].ToString();

            string url = areaName + "/" + controllerName;

            bool isCurrent = false;
            foreach (var modulo in menu)
            {
                modulo.EsActual = false;
                if (modulo.SubModulos != null)
                {
                    foreach (var submodulo in modulo.SubModulos)
                    {
                        submodulo.EsActual = false;
                        isCurrent = submodulo.Vistas.Any(v => v.URL.Contains(url));
                        if (isCurrent)
                        {
                            modulo.EsActual = true;
                            submodulo.EsActual = true;

                        }
                    }
                }
            }
        }

        public static List<Modulo> ObtenerMenuSGC(List<Modulo> modulos)
        {
            var urlPolitica = ConfigurationManager.AppSettings["URL_POLITICA"];
            var urlSGC = ConfigurationManager.AppSettings["URL_SGC"];
            string codigoSistema = ConfigurationManager.AppSettings["CODIGO_IDENTIFICADOR_SISTEMA"];

            List<Modulo> Modulos = new List<Modulo>(){
                                            new Modulo(){
                                    Codigo="mdlConfiguracion",
                                    CodigoSistema = codigoSistema,
                                    Nombre = "Configuración",
                                    Icono = "fa fa-cog",
                                   SubModulos = new List<Modulo>(){
                                                  new Modulo(){
                                                      Codigo="mnuParametro",
                                                      CodigoSistema = codigoSistema,
                                                      Nombre = "Parámetros Generales",
                                                      Vistas = new List<Vista>(){
                                                          new Vista(){
                                                            Nombre = "Index",
                                                            URL = urlPolitica+"General/Parametro/"
                                                          }
                                                      }
                                                  },
                                                  new Modulo(){
                                                      Codigo="mnuValorParametroFuncional",
                                                      CodigoSistema = codigoSistema,
                                                      Nombre = "Valores de Parámetros Generales",
                                                      Vistas = new List<Vista>(){
                                                          new Vista(){
                                                              Nombre="Index",
                                                              URL=urlPolitica+"General/ValorParametro?tipoParametro=F",
                                                              Controles = new List<Control>(){
                                                                  new Control(){
                                                                      Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/ValorParametro?tipoParametro=F") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/ValorParametro?tipoParametro=F").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                      Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/ValorParametro?tipoParametro=F") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/ValorParametro?tipoParametro=F").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                      ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/ValorParametro?tipoParametro=F") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/ValorParametro?tipoParametro=F").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                  }
                                                              }
                                                          }
                                                      }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuValorParametroSistema",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Valores de Parámetros de Sistema",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL=urlPolitica+"General/ValorParametro?tipoParametro=S",
                                                        Controles = new List<Control>(){
                                                                    new Control(){
                                                                        Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/ValorParametro?tipoParametro=S") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/ValorParametro?tipoParametro=S").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                        Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/ValorParametro?tipoParametro=S") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/ValorParametro?tipoParametro=S").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                        ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/ValorParametro?tipoParametro=S") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/ValorParametro?tipoParametro=S").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                    }
                                                        }
                                                        }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuTrabajador",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Trabajadores",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL=urlPolitica+"General/Trabajador/",
                                                        Controles = new List<Control>(){
                                                                    new Control(){
                                                                        Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/Trabajador/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/Trabajador/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                        Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/Trabajador/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/Trabajador/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                        ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/Trabajador/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/Trabajador/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                    }
                                                                }
                                                        }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuUnidadOperativa",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Unidad Operativa",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL=urlPolitica+"General/UnidadOperativa?tipo=REPDIR",
                                                        Controles = new List<Control>(){
                                                            new Control(){
                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/UnidadOperativa?tipo=REPDIR") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/UnidadOperativa?tipo=REPDIR").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/UnidadOperativa?tipo=REPDIR") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/UnidadOperativa?tipo=REPDIR").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/UnidadOperativa?tipo=REPDIR") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/UnidadOperativa?tipo=REPDIR").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                            }
                                                        }
                                                        }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuFlujoAprobacion",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Flujo de Aprobación",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/FlujoAprobacion",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/FlujoAprobacion") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/FlujoAprobacion").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/FlujoAprobacion") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/FlujoAprobacion").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/FlujoAprobacion") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/FlujoAprobacion").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuVariables",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Variables",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/VariablePlantilla/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/VariablePlantilla/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/VariablePlantilla/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/VariablePlantilla/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/VariablePlantilla/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/VariablePlantilla/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/VariablePlantilla/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuPlantillaNotificacion",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Notificaciones",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlPolitica+"General/PlantillaNotificacion/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/PlantillaNotificacion/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/PlantillaNotificacion/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/PlantillaNotificacion/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/PlantillaNotificacion/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "General/PlantillaNotificacion/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "General/PlantillaNotificacion/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                  }
                                   }
                                },
                                new Modulo(){
                                    Codigo="mdlContratos",
                                    CodigoSistema = codigoSistema,
                                    Nombre = "Contratos",
                                    Icono = "fa-file-text-o fa-lg",
                                    SubModulos = new List<Modulo>(){
                                                new Modulo(){
                                                    Codigo="mnuPlantilla",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Plantillas de Contratos",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/Plantilla/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/Plantilla/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/Plantilla/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/Plantilla/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/Plantilla/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/Plantilla/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/Plantilla/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuRegistroBienes",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Registro de Bienes",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/Bienes/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/Bienes/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/Bienes/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/Bienes/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/Bienes/").FirstOrDefault().Controles.FirstOrDefault().Escritura: false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/Bienes/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/Bienes/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuListadoContrato",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Listado de Contratos",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/ListadoContrato/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ListadoContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ListadoContrato/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ListadoContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ListadoContrato/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ListadoContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ListadoContrato/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuSolicitudModificacionContrato",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Solicitud de Modificación",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/SolicitudModificacionContrato/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/SolicitudModificacionContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/SolicitudModificacionContrato/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/SolicitudModificacionContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/SolicitudModificacionContrato/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/SolicitudModificacionContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/SolicitudModificacionContrato/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuBandejaContrato",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Bandeja de Contratos",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/BandejaContrato/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/BandejaContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/BandejaContrato/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/BandejaContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/BandejaContrato/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/BandejaContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/BandejaContrato/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuProcesoAuditoria",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Auditoría",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/ProcesoAuditoria/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ProcesoAuditoria/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ProcesoAuditoria/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ProcesoAuditoria/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ProcesoAuditoria/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ProcesoAuditoria/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ProcesoAuditoria/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuConsulta",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Consultas Generales",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/Consulta/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/Consulta/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/Consulta/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/Consulta/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/Consulta/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/Consulta/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/Consulta/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                    }
                                },
                                new Modulo(){
                                    Codigo="mdlConsultasReportes",
                                    CodigoSistema = codigoSistema,
                                    Nombre = "Consultas y Reportes",
                                    Icono = "fa fa-database",
                                    SubModulos = new List<Modulo>(){
                                                new Modulo(){
                                                    Codigo="mnuTiempoAtencion",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Tiempo de Atención",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/ReporteTiempoAtencion/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteTiempoAtencion/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteTiempoAtencion/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteTiempoAtencion/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteTiempoAtencion/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteTiempoAtencion/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteTiempoAtencion/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuHojaRuta",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Hoja de Ruta",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/ReporteHojaRuta/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteHojaRuta/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteHojaRuta/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteHojaRuta/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteHojaRuta/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteHojaRuta/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteHojaRuta/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuTiempoEjecucion",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Tiempo de Ejecución",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="TiempoEjecucion",
                                                                URL=urlSGC+"Contractual/ConsultasReportes/"
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuEstadioActualContratos",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Estadio Actual de Contratos",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/ReporteEstadioActualContrato/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteEstadioActualContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteEstadioActualContrato/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteEstadioActualContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteEstadioActualContrato/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteEstadioActualContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteEstadioActualContrato/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuContratosPendientesElaborar",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Contratos Pendientes de Elaborar",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/ReporteContratoPendienteElaborar/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteContratoPendienteElaborar/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteContratoPendienteElaborar/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteContratoPendienteElaborar/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteContratoPendienteElaborar/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteContratoPendienteElaborar/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteContratoPendienteElaborar/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuContratosPorVencer",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Contratos por Vencer",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/ReporteContratoPorVencer/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteContratoPorVencer/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteContratoPorVencer/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteContratoPorVencer/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteContratoPorVencer/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteContratoPorVencer/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteContratoPorVencer/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuContratosPorEstadio",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Contratos por Estadio",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/ReporteContratoPorEstadio/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteContratoPorEstadio/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteContratoPorEstadio/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteContratoPorEstadio/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteContratoPorEstadio/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteContratoPorEstadio/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteContratoPorEstadio/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuBienesContrato",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Bienes por Contrato",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/ReporteBienesContrato/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteBienesContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteBienesContrato/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteBienesContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteBienesContrato/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteBienesContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteBienesContrato/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuListadoContrato",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Listado de Contratos",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/ReporteListadoContrato/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteListadoContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteListadoContrato/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteListadoContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteListadoContrato/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteListadoContrato/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteListadoContrato/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuReporteContratoPorFinalizar",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Contratos por Finalizar",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/ReporteContratoPorFinalizar/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteContratoPorFinalizar/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteContratoPorFinalizar/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteContratoPorFinalizar/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteContratoPorFinalizar/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteContratoPorFinalizar/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteContratoPorFinalizar/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                },
                                                new Modulo(){
                                                    Codigo="mnuReporteConsulta",
                                                    CodigoSistema = codigoSistema,
                                                    Nombre = "Consultas",
                                                    Vistas = new List<Vista>(){
                                                            new Vista(){
                                                                Nombre="Index",
                                                                URL=urlSGC+"Contractual/ReporteConsulta/",
                                                                Controles = new List<Control>(){
                                                                            new Control(){
                                                                                Lectura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteConsulta/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteConsulta/").FirstOrDefault().Controles.FirstOrDefault().Lectura : false,
                                                                                Escritura = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteConsulta/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteConsulta/").FirstOrDefault().Controles.FirstOrDefault().Escritura : false,
                                                                                ControlTotal = modulos.FirstOrDefault().Vistas.Exists(x => x.URL == "Contractual/ReporteConsulta/") ? modulos.FirstOrDefault().Vistas.Where(x => x.URL == "Contractual/ReporteConsulta/").FirstOrDefault().Controles.FirstOrDefault().ControlTotal : false,
                                                                            }
                                                                        }
                                                            }
                                                    }
                                                }
                                    }
                                }
                            };

            return Modulos;
        }

        public static List<Modulo> ObtenerMenuSCC()
        {
            var urlPolitica = ConfigurationManager.AppSettings["URL_POLITICA"];

            List<Modulo> Modulos = new List<Modulo>(){
                                new Modulo(){
                                    Codigo="mdlConfiguracion",
                                    CodigoSistema = "SCC",
                                    Nombre = "Configuración",
                                    Icono = "fa fa-cog",
                                   SubModulos = new List<Modulo>(){
                                                  new Modulo(){
                                                    Codigo="mnuParametro",
                                                    CodigoSistema = "SCC",
                                                    Nombre = "Parámetros Generales",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL=urlPolitica+"General/Parametro/"
                                                        }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuValorParametroFuncional",
                                                    CodigoSistema = "SCC",
                                                    Nombre = "Valores de Parámetros Generales",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL=urlPolitica+"General/ValorParametro?tipoParametro=F"
                                                        }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuValorParametroSistema",
                                                    CodigoSistema = "SCC",
                                                    Nombre = "Valores de Parámetros de Sistema",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL=urlPolitica+"General/ValorParametro?tipoParametro=S"
                                                        }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuTrabajador",
                                                    CodigoSistema = "SCC",
                                                    Nombre = "Trabajadores",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL=urlPolitica+"General/Trabajador/"
                                                        }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuUnidadOperativa",
                                                    CodigoSistema = "SCC",
                                                    Nombre = "Unidad Operativa",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL=urlPolitica+"General/UnidadOperativa?tipo=RES"
                                                        }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuActividad",
                                                    CodigoSistema = "SCC",
                                                    Nombre = "Actividades de Cierre Contable",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL="Contable/ActividadesCierreContable/"
                                                        }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuActividadUnidadOperativa",
                                                    CodigoSistema = "SCC",
                                                    Nombre = "Actividades por Unidad Operativa",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL="Contable/ActividadUnidadOperativa/"
                                                        }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuParticipante",
                                                    CodigoSistema = "SCC",
                                                    Nombre = "Participantes del Cierre Contable",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL="Contable/ParticipanteCierreContable/"
                                                        }
                                                    }
                                                  }
                                   }
                                },
                                new Modulo(){
                                    Codigo="mdlEjecucion",
                                    CodigoSistema = "SCC",
                                    Nombre = "Ejecución",
                                    Icono = "fa fa-bolt",
                                   SubModulos = new List<Modulo>(){
                                                  new Modulo(){
                                                    Codigo="mnuCalendarizacion",
                                                    CodigoSistema = "SCC",
                                                    Nombre = "Calendarización",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL="Contable/Calendarizacion/"
                                                        }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuBandejaProceso",
                                                    CodigoSistema = "SCC",
                                                    Nombre = "Bandeja de Procesos",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL="Contable/BandejaProceso/"
                                                        }
                                                    }
                                                  }
                                   }
                                },
                                new Modulo(){
                                    Codigo="mdlReportes",
                                    CodigoSistema = "SCC",
                                    Nombre = "Consultas",
                                    Icono = "fa fa-database",
                                   SubModulos = new List<Modulo>(){
                                                  new Modulo(){
                                                    Codigo="mnuTableroControl",
                                                    CodigoSistema = "SCC",
                                                    Nombre = "Tablero de Control",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL="Contable/Reportes/TableroControl/"
                                                        }
                                                    }
                                                  },
                                                  new Modulo(){
                                                    Codigo="mnuReporteEficiencia",
                                                    CodigoSistema = "SCC",
                                                    Nombre = "Reporte de Eficiencia",
                                                    Vistas = new List<Vista>(){
                                                        new Vista(){
                                                        Nombre="Index",
                                                        URL="Contable/ReporteEficiencia/"
                                                        }
                                                    }
                                                  } 
                                   }
                                }
                            };

            return Modulos;
        }

        public static void AplicarMenu(CuentaUsuario usuario)
        {
            if (usuario.Modulos.FirstOrDefault().Codigo == null)
            {
                List<Modulo> menu = new List<Modulo>();
                if (ConfigurationManager.AppSettings["CODIGO_IDENTIFICADOR_SISTEMA"].ToString() == "SCC")
                {
                    menu = ObtenerMenuSCC();
                }
                else
                {
                    menu = ObtenerMenuSGC(usuario.Modulos);
                }
                var permisos = usuario.Modulos.FirstOrDefault().Vistas.Select(v => v.URL);
                usuario.Modulos = new List<Modulo>();
                foreach (Modulo modulo in menu)
                {
                    var newSubmodulo = new List<Modulo>();
                    foreach (var submodulo in modulo.SubModulos)
                    {
                        var hasAccess = submodulo.Vistas.Any(v => permisos.Any(p => v.URL.EndsWith(p)));

                        var url = HttpContext.Current.Request.Url;
                        var port = url.Port != 80 ? (":" + url.Port) : string.Empty;
                        UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
                        string urlRelative = string.Format("{0}://{1}{2}{3}", url.Scheme, url.Host, port, urlHelper.Content("~/"));

                        submodulo.Vistas.ForEach(v => v.URL = v.URL.ToLower().StartsWith("http") ? v.URL : (urlRelative + v.URL));

                        if (hasAccess)
                        {
                            newSubmodulo.Add(submodulo);
                        }
                    }
                    if (newSubmodulo.Any())
                    {
                        modulo.SubModulos = newSubmodulo;
                        usuario.Modulos.Add(modulo);
                    }
                }
            }
        }
    }
}

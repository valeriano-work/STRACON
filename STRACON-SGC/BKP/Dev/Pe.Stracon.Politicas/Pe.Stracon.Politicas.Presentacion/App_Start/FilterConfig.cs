using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion
{
    /// <summary>
    /// Controlador que muestra la configuración del filtro
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150430 <br />
    /// Modificación:       <br />
    /// </remarks>
    public class FilterConfig
    {
        /// <summary>
        /// Metodo para Registrar Filtros GLobales
        /// </summary>
        /// <param name="filters">Filtro de Colección</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
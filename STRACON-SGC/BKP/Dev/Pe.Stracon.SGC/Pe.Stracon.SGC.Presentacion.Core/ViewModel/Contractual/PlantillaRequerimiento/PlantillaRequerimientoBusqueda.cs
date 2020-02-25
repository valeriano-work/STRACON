using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.GyM.Security.Account.Model;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.PlantillaRequerimiento
{
    /// <summary>
    /// Modelo de vista para la bandeja de búsqueda
    /// </summary>
    /// <remarks>
    /// Creación:       
    /// Modificación:   
    /// </remarks>
    /// 
    public class PlantillaRequerimientoBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para la búsqueda de plantillas
        /// </summary>
       /// <param name="estadoVigencia">Lista de Estados de Vigencia</param>
        public PlantillaRequerimientoBusqueda(List<CodigoValorResponse> estadoVigencia)
        {           
            this.EstadoVigencia = this.GenerarListadoOpcioneGenericoFiltro(estadoVigencia, DatosConstantes.EstadoVigencia.Vigente);
            this.ControlPermisos = new Control();
        }

        #region Propiedades

        /// <summary>
        /// Lista de Estados de Vigencia
        /// </summary>
        public List<SelectListItem> EstadoVigencia { get; set; }

        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }
        #endregion
    }
}

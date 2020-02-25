using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Consulta
{
    /// <summary>
    /// Modelo de vista de Consulta
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150602 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ConsultaFormulario : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="listadoTipo">Lista de tipo de consulta</param>
        public ConsultaFormulario(List<SelectListItem> listadoTipo, List<SelectListItem> listadoUnidadOperativa, List<SelectListItem> listadoArea, List<SelectListItem> listaStaff = null)
        {
            this.ListadoTipo = listadoTipo;
            this.Consulta = new ConsultaResponse();
            this.Consulta.ListaDestinatario = new Dictionary<string, string>();
            this.ListaStaff = listaStaff;
            this.ListadoUnidadOperativa = listadoUnidadOperativa;
            this.ListaArea = listadoArea;
        }

        #region Propiedades
        /// <summary>
        /// Clase Response de Consulta
        /// </summary>
        public ConsultaResponse Consulta { get; set; }
        /// <summary>
        /// Listado de Tipo de consulta
        /// </summary>
        public List<SelectListItem> ListadoTipo { get; set; }
        /// <summary>
        /// Listado de staff
        /// </summary>
        public List<SelectListItem> ListaStaff { get; set; }
        /// <summary>
        /// Listado de unidad operativa
        /// </summary>
        public List<SelectListItem> ListadoUnidadOperativa { get; set; }
        /// <summary>
        /// Listado de área
        /// </summary>
        public List<SelectListItem> ListaArea { get; set; }
        /// <summary>
        /// Indica si el usuario logueado pertenece al staff
        /// </summary>
        public bool IndicadorStaff { get; set; }
        #endregion
    }
}

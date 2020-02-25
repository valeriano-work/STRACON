using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.UnidadOperativa
{
    public class UnidadOperativaStaffFormulario : GenericViewModel
    {
        #region Propiedades
        /// <summary>
        /// Lista de Sistemas
        /// </summary>
        public List<SelectListItem> ListaSistema { get; set; }

        public UnidadOperativaStaffFormulario(List<SelectListItem> listaSistema)
        {
            this.ListaSistema = listaSistema;
        }               

        #endregion

       
    }
}

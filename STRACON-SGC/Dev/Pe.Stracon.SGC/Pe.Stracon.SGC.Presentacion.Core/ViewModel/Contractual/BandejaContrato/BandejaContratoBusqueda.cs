using System.Collections.Generic;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using System.Web.Mvc;
using System.Linq;
using System;
using Pe.GyM.Security.Account.Model;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.BandejaContrato
{
    /// <summary>
    /// Modelo de vista para la Bandeja Contrato
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class BandejaContratoBusqueda : GenericViewModel
    {
        #region Propiedades
        /// <summary>
        /// Lista de Unidades Operativas
        /// </summary>
        public List<SelectListItem> UnidadesOperativas { get; set; }
        public List<SelectListItem> TipoServicio { get; set; }
        public List<SelectListItem> TipoRequerimiento { get; set; }
        public Guid CodigoResponsable { get; set; }

        /// <summary>
        /// Lista de Estadios
        /// </summary>
        public List<SelectListItem> ListaEstadio { get; set; }
        #endregion
        /// <summary>
        /// Constructor Bandeja Contrato Busqueda
        /// </summary>
        /// <param name="lstUnidadesOperativas">Lista Unidad Operativa</param>
        /// <param name="lstTipoServicio">Lista Tipo Servicio</param>
        /// <param name="lstTipoRequerimiento">Lista Tipo Requerimiento</param>
        public BandejaContratoBusqueda(List<UnidadOperativaResponse> lstUnidadesOperativas,
                                       List<CodigoValorResponse> lstTipoServicio,
                                       List<CodigoValorResponse> lstTipoRequerimiento)
        {
            this.UnidadesOperativas = new List<SelectListItem>();
            this.TipoServicio = new List<SelectListItem>();
            this.TipoRequerimiento = new List<SelectListItem>();
            this.ListaEstadio = new List<SelectListItem>();

            List<CodigoValorResponse> listaUO = lstUnidadesOperativas.Select(uo => new CodigoValorResponse() { Codigo = uo.CodigoUnidadOperativa, Valor = uo.Nombre }).ToList();

            this.UnidadesOperativas = this.GenerarListadoOpcioneGenericoFiltro(listaUO);
            this.TipoServicio = this.GenerarListadoOpcioneGenericoFiltro(lstTipoServicio);
            this.TipoRequerimiento = this.GenerarListadoOpcioneGenericoFiltro(lstTipoRequerimiento);
            this.ControlPermisos = new Control();
        }

        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }

    }
}

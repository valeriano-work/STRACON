using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteConsulta
{
    /// <summary>
    /// Modelo de vista para el Reporte de Consultas
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20160713 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ReporteConsultaBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para la búsqueda
        /// </summary>
        /// <param name="listaTipoConsulta">Lista de Tipos de Consultas</param>
        public ReporteConsultaBusqueda(ReporteConsultaResponse reporteConsulta, List<UnidadOperativaResponse> listaUnidadOperativa, List<CodigoValorResponse> listaTipoConsulta, List<CodigoValorResponse> listaAreaEmpresa, List<CodigoValorResponse> listaEstadoConsulta)
        {
            this.ListaUnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFiltro(listaUnidadOperativa, reporteConsulta.CodigoUnidadOperativa);
            this.ListaTipoConsulta = this.GenerarListadoOpcioneGenericoFiltro(listaTipoConsulta, reporteConsulta.CodigoTipoConsulta);
            this.ListaAreaEmpresa = this.GenerarListadoOpcioneGenericoFiltro(listaAreaEmpresa, reporteConsulta.CodigoAreaEmpresa);
            this.ListaEstadoConsulta = this.GenerarListadoOpcioneGenericoFiltro(listaEstadoConsulta, reporteConsulta.CodigoEstadoConsulta);
            this.ReporteConsulta = reporteConsulta;
        }

        #region Propiedades
        /// <summary>
        /// Lista de Unidades Operativas
        /// </summary>
        public List<SelectListItem> ListaUnidadOperativa { get; set; }
        /// <summary>
        /// Lista de Tipos de Consultas
        /// </summary>
        public List<SelectListItem> ListaTipoConsulta { get; set; }
        /// <summary>
        /// Lista de Áreas de Empresa
        /// </summary>
        public List<SelectListItem> ListaAreaEmpresa { get; set; }
        /// <summary>
        /// Lista de Estados de Consulta
        /// </summary>
        public List<SelectListItem> ListaEstadoConsulta { get; set; }
        /// <summary>
        /// Clase Response de Reporte de Consulta
        /// </summary>
        public ReporteConsultaResponse ReporteConsulta { get; set; }
        #endregion
    }
}

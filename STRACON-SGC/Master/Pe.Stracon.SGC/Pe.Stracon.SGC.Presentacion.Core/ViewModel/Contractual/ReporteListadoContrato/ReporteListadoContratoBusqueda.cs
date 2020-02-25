using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteListadoContrato
{
    /// <summary>
    /// Modelo de vista para el Reporte de Listado de Contrato
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ReporteListadoContratoBusqueda : GenericViewModel
    {
         /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="unidadOperativa">Lista items unidad operativa</param>
        /// <param name="reporteTiempoAtencion">Clase Response de Tiempo de Atención</param>
        public ReporteListadoContratoBusqueda(List<UnidadOperativaResponse> unidadOperativa, List<CodigoValorResponse> tipoServicio, List<CodigoValorResponse> tipoRequerimiento, List<CodigoValorResponse> tipoDocumento, List<CodigoValorResponse> estadoContrato, ReporteListadoContratoResponse reporteListadoContrato)
        {
            this.UnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFiltro(unidadOperativa, reporteListadoContrato.CodigoUnidadOperativa);
            this.TipoServicio = this.GenerarListadoOpcioneGenericoFiltro(tipoServicio);
            this.TipoRequerimiento = this.GenerarListadoOpcioneGenericoFiltro(tipoRequerimiento);
            this.TipoDocumento = this.GenerarListadoOpcioneGenericoFiltro(tipoDocumento);
            this.EstadoContrato = this.GenerarListadoOpcioneGenericoFiltro(estadoContrato);
            this.ReporteListadoContrato = reporteListadoContrato;
            this.ListaEstadio = new List<SelectListItem>();
            this.Moneda = new List<SelectListItem>();  
        }

        /// <summary>
        /// Lista de unidades operativas
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }
        /// <summary>
        /// Lista de tipo de servicio
        /// </summary>
        public List<SelectListItem> TipoServicio { get; set; }
        /// <summary>
        /// Lista de tipos de requerimiento
        /// </summary>
        public List<SelectListItem> TipoRequerimiento { get; set; }
        /// <summary>
        /// Lista de tipos de documento
        /// </summary>
        public List<SelectListItem> TipoDocumento { get; set; }
        /// <summary>
        /// Lista de estados de contrato
        /// </summary>
        public List<SelectListItem> EstadoContrato { get; set; }
        /// <summary>
        /// Lista de Estadios
        /// </summary>
        public List<SelectListItem> ListaEstadio { get; set; }

        public ReporteListadoContratoResponse ReporteListadoContrato { get; set; }

        /// <summary>
        /// Lista de Monedas
        /// </summary>
        public List<SelectListItem> Moneda { get; set; }
    }
}

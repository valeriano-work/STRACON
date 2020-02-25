using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Pe.Stracon.SGC.Cross.Core.Util;
using System;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteContratoPendienteElaborar
{
    /// <summary>
    /// Modelo de vista para el Reporte de Contrato Pendiente de Elaborar
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150630 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ReporteContratoPendienteElaborarBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para la búsqueda
        /// </summary>
        /// <param name="tipoOrden">Lista de Tipos de Orden</param>
        /// <param name="moneda">Lista de Monedas</param>
        public ReporteContratoPendienteElaborarBusqueda(List<CodigoValorResponse> tipoOrden, List<CodigoValorResponse> moneda)
        {
            this.Mes = Utilitario.ObtenerListaMeses().Select(m => new SelectListItem()
            {
                Value = m.Key.ToString(),
                Text = m.Value,
                Selected = (m.Key == DateTime.Today.Month)
            }).ToList();

            this.Mes = this.GenerarListadoOpcioneGenericoFiltro(this.Mes);

            this.TipoOrden = this.GenerarListadoOpcioneGenericoFiltro(tipoOrden);
            this.Moneda = this.GenerarListadoOpcioneGenericoFiltro(moneda);

            this.Year = DateTime.Now.Year;
        }

        #region Propiedades
        /// <summary>
        /// Meses del Periodo
        /// </summary>
        public List<SelectListItem> Mes { get; set; }
        /// <summary>
        /// Lista de Tipos de Orden
        /// </summary>
        public List<SelectListItem> TipoOrden { get; set; }
        /// <summary>
        /// Lista de Monedas
        /// </summary>
        public List<SelectListItem> Moneda { get; set; }
        /// <summary>
        /// Año del Periodo
        /// </summary>
        public int Year { get; set; }
        #endregion
    }
}

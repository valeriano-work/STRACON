using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteHojaRuta
{
    /// <summary>
    /// Modelo de vista para la configuración de Hoja de Ruta 
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public class ReporteHojaRutaBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="unidadOperativa">Lista de Unidades Operativas</param>
        /// <param name="tipoServicio">Lista de Tipos de Servicion</param>
        /// <param name="tipoRequerimiento">Lista de Tipos de Requerimientos</param>
        /// <param name="formaEdicion">Lista de Formas de Edición</param>
        /// <param name="reporteHojaRuta">Clase Response de Hoja de Ruta</param>
        public ReporteHojaRutaBusqueda(List<UnidadOperativaResponse> unidadOperativa, List<CodigoValorResponse> tipoServicio, List<CodigoValorResponse> tipoRequerimiento, ReporteHojaRutaResponse reporteHojaRuta)
        {
            this.UnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFiltro(unidadOperativa, reporteHojaRuta.CodigoUnidadOperativa);
            this.TipoServicio = this.GenerarListadoOpcioneGenericoFiltro(tipoServicio, reporteHojaRuta.CodigoTipoServicio);
            this.TipoRequerimiento = this.GenerarListadoOpcioneGenericoFiltro(tipoRequerimiento, reporteHojaRuta.CodigoTipoRequerimiento);
            this.IndicadorMontoMinimo = new List<SelectListItem>()
            {
                new SelectListItem() { Value = string.Empty, Text = GenericoResource.BotonSeleccionar },
                new SelectListItem() { Value = "1", Text = GenericoResource.EtiquetaSi, Selected = (reporteHojaRuta.IndicadorMontoMinimo == GenericoResource.EtiquetaSi) },
                new SelectListItem() { Value = "0", Text = GenericoResource.EtiquetaNo, Selected = (reporteHojaRuta.IndicadorMontoMinimo == GenericoResource.EtiquetaNo) }
            };

            this.ReporteHojaRuta = reporteHojaRuta;
        }

        #region Propiedades
        /// <summary>
        /// Lista de Unidades Operativas
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }
        /// <summary>
        /// Lista de Tipos de Servicios
        /// </summary>
        public List<SelectListItem> TipoServicio { get; set; }
        /// <summary>
        /// Lista de Tipos de Requerimientos
        /// </summary>
        public List<SelectListItem> TipoRequerimiento { get; set; }
        /// <summary>
        /// Lista de Formas de Edición de Contrato
        /// </summary>
        public List<SelectListItem> IndicadorMontoMinimo { get; set; }
        /// <summary>
        /// Clase Response de Reporte de Hoja de Ruta
        /// </summary>
        public ReporteHojaRutaResponse ReporteHojaRuta { get; set; }
        #endregion
    }
}

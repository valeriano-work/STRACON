using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using System;
using Pe.Stracon.SGC.Infraestructura.Core.Context;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteContratoPorEstadio
{
    /// <summary>
    /// Modelo de vista para el Reporte de Contrato Por Estadio
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150630 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ReporteContratoPorEstadioBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para la búsqueda
        /// </summary>
        /// <param name="unidadOperativa">Lista de Unidades Operativas</param>
        /// <param name="tipoServicio">Lista de Tipos de Servicios</param>
        /// <param name="tipoRequerimiento">Lista de Tipos de Requerimientos</param>
        /// <param name="formaEdicion">Lista de Formas de Edición</param>
        public ReporteContratoPorEstadioBusqueda(List<UnidadOperativaResponse> unidadOperativa, List<CodigoValorResponse> tipoServicio, List<CodigoValorResponse> tipoRequerimiento, List<CodigoValorResponse> formaEdicion)
        {
            DateTime fechaInicioMes;
            DateTime fechaFinMes;

            fechaInicioMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            int anioActual = DateTime.Today.Year;
            int mesActual = DateTime.Today.Month;

            if (mesActual == 12)
            {
                anioActual = anioActual + 1;
                mesActual = 1;
            }
            else
            {
                mesActual = mesActual + 1;
            }

            fechaFinMes = new DateTime(anioActual, mesActual, 1).AddDays(-1);

            this.FechaGeneracionDesdeString = fechaInicioMes.ToString(DatosConstantes.Formato.FormatoFecha);
            this.FechaGeneracionHastaString = fechaFinMes.ToString(DatosConstantes.Formato.FormatoFecha);

            this.UnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFiltro(unidadOperativa);
            this.TipoServicio = this.GenerarListadoOpcioneGenericoFiltro(tipoServicio);
            this.TipoRequerimiento = this.GenerarListadoOpcioneGenericoFiltro(tipoRequerimiento);
            this.FormaEdicion = this.GenerarListadoOpcioneGenericoFiltro(formaEdicion);

            this.Estadio = this.GenerarListadoOpcioneGenericoFiltro();
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
        /// Lista de Formas de Edición
        /// </summary>
        public List<SelectListItem> FormaEdicion { get; set; }
        /// <summary>
        /// Lista de Estadios
        /// </summary>
        public List<SelectListItem> Estadio { get; set; }
        /// <summary>
        /// Fecha de Generacion Desde en cadena de texto
        /// </summary>
        public string FechaGeneracionDesdeString { get; set; }
        /// <summary>
        /// Fecha de Generación Hasta en cadena de texto
        /// </summary>
        public string FechaGeneracionHastaString { get; set; }
        #endregion
    }
}

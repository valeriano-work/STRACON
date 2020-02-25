using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using System;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteEstadioActualContrato
{
    /// <summary>
    /// Modelo de vista para la bandeja Reporte de Estadio Actual de Contrato
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150624 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ReporteEstadioActualContratoBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="unidadOperativa">Lista de Unidades Operativas</param>
        /// <param name="reporteEstadioActualContrato">Clase Response de Reporte de Estadio Actual de Contrato</param>
        public ReporteEstadioActualContratoBusqueda(List<UnidadOperativaResponse> unidadOperativa, ReporteEstadioActualContratoResponse reporteEstadioActualContrato,string fecha_desde, string fecha_hasta)
        {
            DateTime fechaInicioMes;
            DateTime fechaFinMes;

            if (fecha_desde == null)
            {
                fechaFinMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                fechaInicioMes = fechaFinMes.AddDays(-90);
                this.FechaContratoDesdeString = fechaInicioMes.ToString(DatosConstantes.Formato.FormatoFecha);
                this.FechaContratoHastaString = fechaFinMes.ToString(DatosConstantes.Formato.FormatoFecha);
            }
            else
            {
                this.FechaContratoDesdeString = fecha_desde;
                this.FechaContratoHastaString = fecha_hasta;
            }

            this.UnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFiltro(unidadOperativa, reporteEstadioActualContrato.CodigoUnidadOperativa);
            this.ReporteEstadioActualContrato = reporteEstadioActualContrato;
        }

        #region Propiedades
        /// <summary>
        /// Lista de unidades operativas
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }
        /// <summary>
        /// Clase Response de Reporte de Estadio Actual de Contrato
        /// </summary>
        public ReporteEstadioActualContratoResponse ReporteEstadioActualContrato { get; set; }
        /// <summary>
        /// Fecha de Contrato Desde en cadena de texto
        /// </summary>
        public string FechaContratoDesdeString { get; set; }
        /// <summary>
        /// Fecha de Contrato Hasta en cadena de texto
        /// </summary>
        public string FechaContratoHastaString { get; set; }
        #endregion
    }
}

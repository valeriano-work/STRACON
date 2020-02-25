using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using System;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteContratoPorVencer
{
    /// <summary>
    /// Modelo de vista para el Reporte de Contrato Por Vencer
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150630 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ReporteContratoPorVencerBusqueda : GenericViewModel
    {
         /// <summary>
        /// Constructor usado para la búsqueda
        /// </summary>
        /// <param name="unidadOperativa">Lista de Unidades Operativas</param>
        /// <param name="estadoContrato">Lista de Estados de Contratos</param>
        /// <param name="fecha_desde"></param>
        /// <param name="fecha_hasta"></param>
        public ReporteContratoPorVencerBusqueda(List<UnidadOperativaResponse> unidadOperativa, List<CodigoValorResponse> estadoContrato, string fecha_desde, string fecha_hasta)
        {
            DateTime fechaInicioMes;
            DateTime fechaFinMes;

            if (fecha_desde == null)
            {
                fechaInicioMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
                fechaFinMes = fechaInicioMes.AddDays(30);
                this.FechaVencimientoDesdeString = fechaInicioMes.ToString(DatosConstantes.Formato.FormatoFecha);
                this.FechaVencimientoHastaString = fechaFinMes.ToString(DatosConstantes.Formato.FormatoFecha);
            }
            else {
                this.FechaVencimientoDesdeString = fecha_desde;
                this.FechaVencimientoHastaString = fecha_hasta;
            }
            //fechaInicioMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            //int anioActual = DateTime.Today.Year;
            //int mesActual = DateTime.Today.Month;

            //if (mesActual == 12)
            //{
            //    anioActual = anioActual + 1;
            //    mesActual = 1;
            //}
            //else
            //{
            //    mesActual = mesActual + 1;
            //}

            //fechaFinMes = new DateTime(anioActual, mesActual, 1).AddDays(-1);



            estadoContrato = estadoContrato.Where(x => x.Codigo.ToString() == DatosConstantes.EstadoContrato.Vigente || x.Codigo.ToString() == DatosConstantes.EstadoContrato.Vencido).ToList();

            this.UnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFiltro(unidadOperativa);
            this.EstadoContrato = this.GenerarListadoOpcioneGenericoFiltro(estadoContrato);
        }

        #region Propiedades
        /// <summary>
        /// Lista de Unidades Operativas
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }
        /// <summary>
        /// Lista de Estados de Contrato
        /// </summary>
        public List<SelectListItem> EstadoContrato { get; set; }
        /// <summary>
        /// Fecha de Vencimiento Desde en cadena de texto
        /// </summary>
        public string FechaVencimientoDesdeString { get; set; }
        /// <summary>
        /// Fecha de Vencimiento Hasta en cadena de texto
        /// </summary>
        public string FechaVencimientoHastaString { get; set; }
        #endregion
    }
}

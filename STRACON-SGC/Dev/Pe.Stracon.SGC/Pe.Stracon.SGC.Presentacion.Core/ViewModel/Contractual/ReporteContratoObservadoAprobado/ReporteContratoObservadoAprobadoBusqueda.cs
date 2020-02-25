using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteContratoObservadoAprobado
{
    /// <summary>
    /// 
    /// </summary>
    public class ReporteContratoObservadoAprobadoBusqueda : GenericViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unidadOperativa"></param>
        /// <param name="tipoAccion"></param>
        /// <param name="reporteContratoObservadoAprobado"></param>
        public ReporteContratoObservadoAprobadoBusqueda(List<UnidadOperativaResponse> unidadOperativa, List<SelectListItem> tipoAccion,ReporteContratoObservadoAprobadoResponse reporteContratoObservadoAprobado)
        {
            this.ListaUnidadOperativa             = this.GenerarListadoOpcionUnidadOperativaFiltro(unidadOperativa, reporteContratoObservadoAprobado.CodigoUnidadOperativa);
            this.ListaTipoAccion                  = tipoAccion;
            this.ReporteContratoObservadoAprobado = reporteContratoObservadoAprobado;

            int anioActual = DateTime.Today.Year;
            int mesActual  = DateTime.Today.Month;

            if (mesActual == 12)
            {
                anioActual = anioActual + 1;
                mesActual = 1;
            }
            else
            {
                mesActual = mesActual + 1;
            }

            this.ReporteContratoObservadoAprobado.FechaConsultaDesdeString = DateTime.Now.ToString("dd/MM/yyyy"); ;

            this.ReporteContratoObservadoAprobado.FechaConsultaHastaString = new DateTime(anioActual, mesActual, 1).AddDays(-1).ToString("dd/MM/yyyy");
        }

        #region Propiedades
        /// <summary>
        /// Lista de Unidades Operativas
        /// </summary>
        public List<SelectListItem> ListaUnidadOperativa { get; set; }
        /// <summary>
        /// Lista de Tipo de Acción
        /// </summary>
        public List<SelectListItem> ListaTipoAccion { get; set; }
       
        /// <summary>
        /// Clase Response de Reporte de Consulta
        /// </summary>
        public ReporteContratoObservadoAprobadoResponse ReporteContratoObservadoAprobado { get; set; }
        #endregion
    }
}

using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteBienesContrato
{
    /// Modelo de vista para la configuración de Bienes por Contrato
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150803 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteBienesContratoBusqueda : GenericViewModel
    {
        public ReporteBienesContratoBusqueda(List<UnidadOperativaResponse> unidadOperativa, List<CodigoValorResponse> tipoBien, ReporteBienesContratoResponse reporteBienesContrato)
        {
            this.UnidadOperativa = this.GenerarListadoOpcionUnidadOperativaFiltro(unidadOperativa, reporteBienesContrato.CodigoUnidadOperativa);
            this.TipoBien = this.GenerarListadoOpcioneGenericoFiltro(tipoBien, reporteBienesContrato.CodigoTipoBien);

            this.ReporteBienesContrato = reporteBienesContrato;


            //INICIO: Agregado por Julio Carrera - Norma Contable
            List<SelectListItem> sliMeses = new List<SelectListItem>();
            SelectListItem mes;
            for (int i = 1; i < 13; i++)
            {
                mes = new SelectListItem();
                mes.Text = i.ToString();
                mes.Value = i.ToString();
                sliMeses.Add(mes);
            }
            List<SelectListItem> sliAnos = new List<SelectListItem>();
            SelectListItem ano;
            for (int i = 2000; i < 2031; i++)
            {
                ano = new SelectListItem();
                ano.Text = i.ToString();
                ano.Value = i.ToString();
                sliAnos.Add(ano);
            }
            this.lstAnos = sliAnos;
            this.lstMeses = sliMeses;
            //FIN: Agregado por Julio Carrera - Norma Contable

        }

        #region Propiedades
        /// <summary>
        /// Lista de Unidades Operativas
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }
        /// <summary>
        /// Lista de Tipos de Bien
        /// </summary>
        public List<SelectListItem> TipoBien { get; set; }
        /// <summary>
        /// Clase Response de Reporte de Bienes
        /// </summary>
        public ReporteBienesContratoResponse ReporteBienesContrato { get; set; }
        //INICIO: Agregado por Julio Carrera - Norma Contable
        /// <summary>
        /// Listas de Meses
        /// </summary>
        public List<SelectListItem> lstMeses { get; set; }
        /// <summary>
        /// Listas de Años
        /// </summary>
        public List<SelectListItem> lstAnos { get; set; }
        /// <summary>
        /// Mes seleccionado
        /// </summary>
        public string Mes { get; set; }
        /// <summary>
        /// Año seleccionado
        /// </summary>
        public string Ano { get; set; }
        //FIN: Agregado por Julio Carrera - Norma Contable
        #endregion
    }
}

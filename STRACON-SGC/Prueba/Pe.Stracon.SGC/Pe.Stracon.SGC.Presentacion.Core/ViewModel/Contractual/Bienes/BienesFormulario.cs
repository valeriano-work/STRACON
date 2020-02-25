using System.Collections.Generic;
using System.Web.Mvc;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Bienes
{
    /// <summary>
    /// Modelo de vista Bienes Formulario
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150709
    /// Modificación:   
    /// </remarks>
    public class BienesFormulario : GenericViewModel
    {
        #region Propiedades
        /// <summary>
        /// Listas de Tipos de Bien
        /// </summary>
        public List<SelectListItem> lstTipoBien { get; set; }

        /// <summary>
        /// Listas de Tipos de Tarifa
        /// </summary>
        public List<SelectListItem> lstTipoTarifa { get; set; }

        /// <summary>
        /// Listas de Monedas
        /// </summary>
        public List<SelectListItem> lstMoneda { get; set; }

        /// <summary>
        /// Lista de Meses
        /// </summary>
        public List<SelectListItem> lstMesInicioAlquiler { get; set; }

        /// <summary>
        /// Listas de Periodos de Alquiler
        /// </summary>
        public List<SelectListItem> lstPeriodoAlquiler { get; set; }
        /// <summary>
        /// Lista de numeros de serie.
        /// </summary>
        public List<BienRegistroResponse> lstNumeroSerie { get; set; }
        /// <summary>
        /// Lista descripción de bienes.
        /// </summary>
        public List<BienRegistroResponse> lstDescripcion { get; set; }
        /// <summary>
        /// Lista de modelo de bienes.
        /// </summary>
        public List<BienRegistroResponse> lstModelo { get; set; }
        /// <summary>
        /// Lista de marca de bienes
        /// </summary>
        public List<BienRegistroResponse> lstMarca { get; set; }
        /// <summary>
        /// Clase response del Bien
        /// </summary>
        public BienResponse Bien { get; set; }
        #endregion

        /// <summary>
        /// Constructor Bienes Formulario
        /// </summary>
        /// <param name="plstTipoBien">Parametro Lista Tipo Bien</param>
        /// <param name="plstTipoTarifa">Parametro Lista Tipo Tarifa</param>
        /// <param name="plstMoneda">Parametro Lista Moneda</param>
        /// <param name="plsPeriodoAlquiler">Parametro Lista Periodo Alquiler</param>
        public BienesFormulario(List<CodigoValorResponse> plstTipoBien, List<CodigoValorResponse> plstTipoTarifa,
                                List<CodigoValorResponse> plstMoneda, List<CodigoValorResponse> plstMesInicioAlquiler,
                                List<CodigoValorResponse> plsPeriodoAlquiler = null)
        {
            this.lstTipoBien = new List<SelectListItem>();
            this.lstTipoTarifa = new List<SelectListItem>();
            this.lstMoneda = new List<SelectListItem>();
            this.lstMesInicioAlquiler = new List<SelectListItem>();
            this.lstPeriodoAlquiler = new List<SelectListItem>();
            this.lstNumeroSerie = new List<BienRegistroResponse>();
            this.lstModelo = new List<BienRegistroResponse>();
            this.lstMarca = new List<BienRegistroResponse>();
            this.lstDescripcion = new List<BienRegistroResponse>();
            this.lstTipoBien = this.GenerarListadoOpcioneGenericoFormulario(plstTipoBien);
            this.lstTipoTarifa = this.GenerarListadoOpcioneGenericoFormulario(plstTipoTarifa);
            this.lstMoneda = this.GenerarListadoOpcioneGenericoFormulario(plstMoneda);
            this.lstMesInicioAlquiler = this.GenerarListadoOpcioneGenericoFormulario(plstMesInicioAlquiler);
            this.lstPeriodoAlquiler = this.GenerarListadoOpcioneGenericoFormulario();

            this.Bien = new BienResponse();
            this.Bien.MesInicioAlquiler = Byte.Parse(DateTime.Now.Month.ToString());
            this.Bien.AnioInicioAlquiler = Int16.Parse(DateTime.Now.Year.ToString());
        }
    }
}

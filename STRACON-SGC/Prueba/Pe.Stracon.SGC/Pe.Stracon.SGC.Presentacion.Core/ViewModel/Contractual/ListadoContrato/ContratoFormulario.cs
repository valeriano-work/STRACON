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

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ListadoContrato
{
    /// <summary>
    /// Modelo de vista de Contrato
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150602 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ContratoFormulario : GenericViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ContratoFormulario()
        {
            this.TipoServicio = new List<SelectListItem>();
            this.TipoDocumento = new List<SelectListItem>();
            this.Moneda = new List<SelectListItem>();
            this.ListadoUnidadOperativa = new List<SelectListItem>();
        }
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="tipoServicio">Lista de Niveles de Jerarquía</param>
        /// <param name="tipoRequerimiento">Lista de Fuentes de Integración</param>
        /// <param name="unidadOperativa">Lista de Unidades Operativas</param>
        /// <param name="tipoDocumento">Lista de Formas de Generación</param>
        /// <param name="moneda">Lista de Monedas</param>
        public ContratoFormulario(List<CodigoValorResponse> tipoServicio, List<CodigoValorResponse> tipoDocumento, List<CodigoValorResponse> moneda, List<SelectListItem> ListadoUnidadOperativa)
        {
            this.TipoServicio = this.GenerarListadoOpcioneGenericoFormulario(tipoServicio);
            this.TipoDocumento = this.GenerarListadoOpcioneGenericoFormulario(tipoDocumento, DatosConstantes.TipoDocumento.Contrato);
            this.Moneda = this.GenerarListadoOpcioneGenericoFormulario(moneda, DatosConstantes.Moneda.Dolares);
            this.ListadoUnidadOperativa = ListadoUnidadOperativa;

            this.Contrato = new ContratoResponse();
        }

        public ContratoFormulario(ContratoResponse contrato, List<CodigoValorResponse> tipoServicio, List<CodigoValorResponse> tipoDocumento, List<CodigoValorResponse> moneda, List<SelectListItem> ListadoUnidadOperativa)
        {

            this.TipoServicio = this.GenerarListadoOpcioneGenericoFormulario(tipoServicio, contrato.CodigoTipoServicio);
            this.TipoDocumento = this.GenerarListadoOpcioneGenericoFormulario(tipoDocumento, contrato.CodigoTipoDocumento);//--DatosConstantes.TipoDocumento.Contrato);
            this.Moneda = this.GenerarListadoOpcioneGenericoFormulario(moneda, contrato.CodigoMoneda);//--DatosConstantes.Moneda.Dolares);
            this.ListadoUnidadOperativa = ListadoUnidadOperativa;

            this.Contrato = contrato;
        }

        #region Propiedades
        /// <summary>
        /// Lista de Tipos de Servicios
        /// </summary>
        public List<SelectListItem> TipoServicio { get; set; }
        /// <summary>
        /// Lista de Tipos de Documentos
        /// </summary>
        public List<SelectListItem> TipoDocumento { get; set; }
        /// <summary>
        /// Lista de Monedas
        /// </summary>
        public List<SelectListItem> Moneda { get; set; }
        /// <summary>
        /// Clase Response de Contrato
        /// </summary>
        public ContratoResponse Contrato { get; set; }
        /// <summary>
        /// Listado de Unidades Operativas
        /// </summary>
        public List<SelectListItem> ListadoUnidadOperativa { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool NuevoContrato { get; set; }
        public string ValorEdicion { get; set; }
        #endregion
    }
}

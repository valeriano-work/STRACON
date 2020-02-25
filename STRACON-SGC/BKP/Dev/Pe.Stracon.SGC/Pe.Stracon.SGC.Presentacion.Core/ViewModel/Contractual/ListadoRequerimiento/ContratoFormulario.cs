using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ListadoRequerimiento
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
            this.TipoDocAdj = new List<SelectListItem>();
            this.TipoDocumento = new List<SelectListItem>();
            this.Moneda = new List<SelectListItem>();
            this.ListadoUnidadOperativa = new List<SelectListItem>();
            this.TipoModCon = new List<SelectListItem>();
            //this.ListRequerido = new Dictionary<string, string>();
        }
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="TipoDocAdj">Lista de Niveles de Jerarquía</param>
        /// <param name="tipoRequerimiento">Lista de Fuentes de Integración</param>
        /// <param name="unidadOperativa">Lista de Unidades Operativas</param>
        /// <param name="tipoDocumento">Lista de Formas de Generación</param>
        /// <param name="moneda">Lista de Monedas</param>
        public ContratoFormulario(List<CodigoValorResponse> TipoDocAdj, List<CodigoValorResponse> tipoDocumento, List<CodigoValorResponse> moneda, List<SelectListItem> ListadoUnidadOperativa,
                                 List<CodigoValorResponse>  TipoModCon)
        {
            this.TipoDocAdj = this.GenerarListadoOpcioneGenericoFormulario(TipoDocAdj);
            this.TipoDocumento = this.GenerarListadoOpcioneGenericoFormulario(tipoDocumento, DatosConstantes.TipoDocumento.Contrato);
            this.Moneda = this.GenerarListadoOpcioneGenericoFormulario(moneda, DatosConstantes.Moneda.Dolares);
            this.ListadoUnidadOperativa = ListadoUnidadOperativa;
            this.TipoModCon = this.GenerarListadoOpcioneGenericoFormulario(TipoModCon);
            this.Contrato = new RequerimientoResponse();               
        }

        public ContratoFormulario(RequerimientoResponse contrato, List<CodigoValorResponse> TipoDocAdj, List<CodigoValorResponse> tipoDocumento, List<CodigoValorResponse> moneda, List<SelectListItem> ListadoUnidadOperativa,
                                  List<CodigoValorResponse> TipoModCon)
        {
            this.TipoDocAdj = this.GenerarListadoOpcioneGenericoFormulario(TipoDocAdj, contrato.CodigoDocAdj);
            this.TipoDocumento = this.GenerarListadoOpcioneGenericoFormulario(tipoDocumento, contrato.CodigoTipoDocumento);//--DatosConstantes.TipoDocumento.Contrato);
            this.Moneda = this.GenerarListadoOpcioneGenericoFormulario(moneda, contrato.CodigoMoneda);//--DatosConstantes.Moneda.Dolares);
            this.ListadoUnidadOperativa = ListadoUnidadOperativa;
            this.TipoModCon =   this.GenerarListadoOpcioneGenericoFormulario(TipoModCon, contrato.CodigoModCon);           
            this.Contrato = contrato;
        }

        #region Propiedades
        /// <summary>
        /// Lista de Documentos Adjuntos de Requerimiento
        /// </summary>
        public List<SelectListItem> TipoDocAdj{ get; set; }
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
        public RequerimientoResponse Contrato { get; set; }
        /// <summary>
        /// Listado de Unidades Operativas
        /// </summary>
        public List<SelectListItem> ListadoUnidadOperativa { get; set; }
        /// <summary>
        /// Lista de Modalidad de Contratación de Requerimiento
        /// </summary>
        public List<SelectListItem> TipoModCon { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool NuevoContrato { get; set; }

        public string ValorEdicion { get; set; }

        #endregion
    }
}

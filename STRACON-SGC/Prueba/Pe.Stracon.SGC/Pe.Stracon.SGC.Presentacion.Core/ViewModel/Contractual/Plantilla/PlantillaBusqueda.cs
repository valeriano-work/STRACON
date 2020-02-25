using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.GyM.Security.Account.Model;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Plantilla
{
    /// <summary>
    /// Modelo de vista para la bandeja de búsqueda
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150518
    /// Modificación:   
    /// </remarks>
    public class PlantillaBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para la búsqueda de plantillas
        /// </summary>
        /// <param name="tipoContrato">Lista de Tipos de Contrato</param>
        /// <param name="tipoDocumentoContrato">Lista de Tipos de Documentos de Contratos</param>
        /// <param name="estadoVigencia">Lista de Estados de Vigencia</param>
        public PlantillaBusqueda(List<CodigoValorResponse> tipoContrato, List<CodigoValorResponse> tipoDocumentoContrato, List<CodigoValorResponse> estadoVigencia)
        {
            this.TipoContrato = this.GenerarListadoOpcioneGenericoFiltro(tipoContrato);
            this.TipoDocumentoContrato = this.GenerarListadoOpcioneGenericoFiltro(tipoDocumentoContrato);
            this.EstadoVigencia = this.GenerarListadoOpcioneGenericoFiltro(estadoVigencia, DatosConstantes.EstadoVigencia.Vigente);
            this.ControlPermisos = new Control();
        }

        #region Propiedades
        /// <summary>
        /// Lista de Tipos de Servicios
        /// </summary>
        public List<SelectListItem> TipoContrato { get; set; }
        
        /// <summary>
        /// Lista de Tipos de Documentos de Contratos
        /// </summary>
        public List<SelectListItem> TipoDocumentoContrato { get; set; }

        /// <summary>
        /// Lista de Estados de Vigencia
        /// </summary>
        public List<SelectListItem> EstadoVigencia { get; set; }

        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }
        #endregion
    }
}

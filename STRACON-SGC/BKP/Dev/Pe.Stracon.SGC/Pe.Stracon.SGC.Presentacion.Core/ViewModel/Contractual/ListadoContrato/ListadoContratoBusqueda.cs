using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Web.Mvc;
using Pe.GyM.Security.Account.Model;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ListadoContrato
{
    /// <summary>
    /// Modelo de vista para la bandeja de búsqueda
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150601    </br>
    /// Modificación:                   </br>
    /// </remarks>
    public class ListadoContratoBusqueda : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para la búsqueda de listado de contratos
        /// </summary>
        /// <param name="tipoServicio">Lista de Tipos de Servicios</param>
        /// <param name="tipoRequerimiento">Lista de Tipos de Requerimientos</param>
        /// <param name="tipoDocumento">Lista de Tipos de Documentos</param>
        /// <param name="estadoContrato">Lista de Estados de Contrato</param>
        public ListadoContratoBusqueda(List<CodigoValorResponse> tipoServicio, List<CodigoValorResponse> tipoDocumento, List<CodigoValorResponse> estadoContrato, List<SelectListItem> listaUnidadOperativa, List<CodigoValorResponse> estadoEdicion)
        {
            this.TipoServicio = this.GenerarListadoOpcioneGenericoFiltro(tipoServicio);
            this.TipoDocumento = this.GenerarListadoOpcioneGenericoFiltro(tipoDocumento);
            this.EstadoContrato = this.GenerarListadoOpcioneGenericoFiltro(estadoContrato);
            this.ListadoUnidadOperativa = listaUnidadOperativa;
            this.EstadoEdicion = this.GenerarListadoOpcioneGenericoFiltro(estadoEdicion);
            this.ListaEstadio = new List<SelectListItem>();
            this.Moneda = new List<SelectListItem>();
            this.ControlPermisos = new Control();
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
        /// Lista de Estados de Contrato
        /// </summary>
        public List<SelectListItem> EstadoContrato { get; set; }

        /// <summary>
        /// Lista de Unidades Operativas
        /// </summary>
        public List<SelectListItem> ListadoUnidadOperativa { get; set; }

        /// <summary>
        /// Lista de Estadios
        /// </summary>
        public List<SelectListItem> ListaEstadio { get; set; }

        /// <summary>
        /// Lista de Estado de Edición
        /// </summary>
        public List<SelectListItem> EstadoEdicion { get; set; }

        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }

        /// <summary>
        /// Estado de Contrato Aprobado
        /// </summary>
        public string Aprobado { get; set; }

        /// <summary>
        /// Estado de Contrato No Aprobado
        /// </summary>
        public string NoAprobado { get; set; }

        /// <summary>
        /// Monto Acumulado Inicio
        /// </summary>
        public decimal? MontoAcumuladoInicio { get; set; }
        /// <summary>
        /// Monto Acumulado Fin
        /// </summary>
        public decimal? MontoAcumuladoFin { get; set; }

        /// <summary>
        /// Lista de Monedas
        /// </summary>
        public List<SelectListItem> Moneda { get; set; }
        #endregion
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.SolicitudModificacionContrato
{
    /// <summary>
    /// Modelo de vista  Solicitud Modificacion Contrato Busqueda
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150709
    /// Modificación:   
    /// </remarks>
    public class SolicitudModificacionContratoBusqueda : GenericViewModel
    {
        #region Propiedades
        /// <summary>
        /// Lista de Unidades Operativas
        /// </summary>
        public List<SelectListItem> UnidadesOperativas { get; set; }
        #endregion

        /// <summary>
        /// Constructor Solicitud Modificacion Contrato Busqueda
        /// </summary>
        /// <param name="lstUnidadesOperativas">Listas Unidades Operativas</param>
        public SolicitudModificacionContratoBusqueda(List<UnidadOperativaResponse> lstUnidadesOperativas)
        {
            this.UnidadesOperativas = new List<SelectListItem>();
            List<CodigoValorResponse> listaUO = lstUnidadesOperativas.Select(uo => new CodigoValorResponse() { Codigo = uo.CodigoUnidadOperativa, Valor = uo.Nombre }).ToList();
            this.UnidadesOperativas = this.GenerarListadoOpcioneGenericoFiltro(listaUO);
        }
    }
}

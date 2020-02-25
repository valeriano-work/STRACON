using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.SolicitudRevisionContrato
{
    /// <summary>
    /// Modelo de vista  Solicitud Revisión Contrato Busqueda
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20171113
    /// Modificación:   
    /// </remarks>
    public class SolicitudRevisionContratoBusqueda : GenericViewModel
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
        public SolicitudRevisionContratoBusqueda(List<UnidadOperativaResponse> lstUnidadesOperativas)
        {
            this.UnidadesOperativas = new List<SelectListItem>();
            List<CodigoValorResponse> listaUO = lstUnidadesOperativas.Select(uo => new CodigoValorResponse() { Codigo = uo.CodigoUnidadOperativa, Valor = uo.Nombre }).ToList();
            this.UnidadesOperativas = this.GenerarListadoOpcioneGenericoFiltro(listaUO);
        }
    }
}

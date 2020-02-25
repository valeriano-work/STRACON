using Pe.GyM.Security.Account.Model;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Web.Mvc;


namespace Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.Trabajador
{
    /// <summary>
    /// Modelo de vista para la bandeja de busqueda
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public class TrabajadorModel : GenericViewModel
    {
        /// <summary>
        /// Constructor del Modelo
        /// </summary>
        /// <param name="identificacion">Identificación</param>
        public TrabajadorModel(List<CodigoValorResponse> identificacion, bool filtro)
        {
            if (filtro)
                this.CodigoTipoDocumentoIdentidad = this.GenerarListadoOpcioneGenericoFiltro(identificacion);
            else
                this.CodigoTipoDocumentoIdentidad = this.GenerarListadoOpcioneGenericoFormulario(identificacion);
            this.Trabajador = new TrabajadorResponse();
        }

        /// <summary>
        /// Constructor del Modelo
        /// </summary>
        /// <param name="identificacion">Identificación</param>
        /// <param name="trabajador">Trabajador</param>
        public TrabajadorModel(List<CodigoValorResponse> identificacion, TrabajadorResponse trabajador)
        {
            this.CodigoTipoDocumentoIdentidad = this.GenerarListadoOpcioneGenericoFormulario(identificacion, trabajador.CodigoTipoDocumentoIdentidad);
            this.Trabajador = trabajador;
        }
        #region Propiedades
        /// <summary>
        /// Código de Tipo de documento de identidad
        /// </summary>
        public List<SelectListItem> CodigoTipoDocumentoIdentidad { get; set; }
       
        /// <summary>
        /// Trabajador
        /// </summary>
        public TrabajadorResponse Trabajador { get; set; }

        /// <summary>
        /// Lista de Unidades Operativas
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }

        /// <summary>
        /// Controles de Permiso
        /// </summary>
        public Control ControlPermisos { get; set; }
        
        #endregion


    }
}

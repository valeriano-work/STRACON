using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System.Collections.Generic;
using System.Web.Mvc;
namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Plantilla
{
    /// <summary>
    /// Modelo de vista de plantilla
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150519 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class PlantillaFormulario : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="tipoServicio">Lista de Tipos de Servicios</param>
        /// <param name="tipoRequerimiento">Lista de Tipos de Requerimientos</param>
        /// <param name="tipoDocumentoContrato">Lista de Tipos de Documentos</param>
        /// <param name="estadoVigencia">Lista de Estados de Vigencia</param>
        public PlantillaFormulario(List<CodigoValorResponse> tipoServicio, List<CodigoValorResponse> tipoRequerimiento, List<CodigoValorResponse> tipoDocumentoContrato, List<CodigoValorResponse> estadoVigencia, string indicadorCopia, bool? esmayormenor)
        {
            this.TipoServicio = this.GenerarListadoOpcioneGenericoFormulario(tipoServicio);
            this.TipoDocumentoContrato = this.GenerarListadoOpcioneGenericoFormulario(tipoDocumentoContrato);
            this.EstadoVigencia = this.GenerarListadoOpcioneGenericoFormulario(estadoVigencia);
            this.IndicadorCopia = indicadorCopia;
            this.Plantilla = new PlantillaResponse();
            //INICIO: Julio Carrera
            if (esmayormenor != null)
            {
                this.Plantilla.EsMayorMenor = (bool)esmayormenor;
            }
            //FIN: Julio Carrera

        }

        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="tipoServicio">Lista de Tipos de Servicios</param>
        /// <param name="tipoRequerimiento">Lista de Tipos de Requerimientos</param>
        /// <param name="tipoDocumentoContrato">Lista de Tipos de Documentos</param>
        /// <param name="estadoVigencia">Lista de Estados de Vigencia</param>
        /// <param name="plantilla">Clase Response de Plantilla</param>
        public PlantillaFormulario(List<CodigoValorResponse> tipoServicio, List<CodigoValorResponse> tipoRequerimiento, List<CodigoValorResponse> tipoDocumentoContrato, List<CodigoValorResponse> estadoVigencia, PlantillaResponse plantilla)
        {
            this.TipoServicio = this.GenerarListadoOpcioneGenericoFormulario(tipoServicio, plantilla.CodigoTipoContrato);
            this.TipoDocumentoContrato = this.GenerarListadoOpcioneGenericoFormulario(tipoDocumentoContrato, plantilla.CodigoTipoDocumentoContrato);
            this.EstadoVigencia = this.GenerarListadoOpcioneGenericoFormulario(estadoVigencia, plantilla.CodigoEstadoVigencia);
            //INICIO: Julio Carrera
            //this.EsMayorMenor = plantilla.EsMayorMenor;
            //FIN: Julio Carrera
            this.Plantilla = plantilla;
        }

        #region Propiedades
        /// <summary>
        /// Lista de Tipos de Servicios
        /// </summary>
        public List<SelectListItem> TipoServicio { get; set; }
        /// <summary>
        /// Lista de Tipos de Documentos de Contratos
        /// </summary>
        public List<SelectListItem> TipoDocumentoContrato { get; set; }
        /// <summary>
        /// Lista de Estados de Vigencia
        /// </summary>
        public List<SelectListItem> EstadoVigencia { get; set; }
        /// <summary>
        /// Clase Response de Plantilla
        /// </summary>
        public PlantillaResponse Plantilla { get; set; }
        /// <summary>
        /// Indica si el formulario nuevo es copia o no
        /// </summary>
        public string IndicadorCopia { get; set; }
        //INICIO: Julio Carrera
        /// <summary>
        /// Indica si el formulario nuevo es copia o no
        /// </summary>
        public bool EsMayorMenor { get; set; }
        //FIN: Julio Carrera
        #endregion
    }
}

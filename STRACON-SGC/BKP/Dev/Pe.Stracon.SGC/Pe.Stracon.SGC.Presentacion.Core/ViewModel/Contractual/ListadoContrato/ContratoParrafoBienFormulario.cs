using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ListadoContrato
{
    /// <summary>
    /// Modelo de vista de Contrato Párrafo Bien
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150803 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ContratoParrafoBienFormulario
    {
        /// <summary>
        /// Constructor usado para la búsqueda de datos
        /// </summary>
        public ContratoParrafoBienFormulario(List<BienResponse> bien)
        {
            this.Bien = bien;
        }

        #region Propiedades
        /// <summary>
        /// Lista de Bienes
        /// </summary>
        public List<BienResponse> Bien { get; set; }

        //INICIO: Agregado por Julio Carrera - Norma Contable
        /// <summary>
        /// Listas de Tipos de Tarifa
        /// </summary>
        public List<SelectListItem> lstTipoTarifa { get; set; }

        /// <summary>
        /// Listas de Periodos de Alquiler
        /// </summary>
        public List<SelectListItem> lstPeriodoAlquiler { get; set; }

        /// <summary>
        /// Código de Tipo de Tarifa
        /// </summary>
        public string CodigoTipoTarifa { get; set; }

        /// <summary>
        /// Código Periodo de Alquiler
        /// </summary>
        public string CodigoPeriodoAlquiler { get; set; }

        /// <summary>
        /// Código Periodo de Alquiler
        /// </summary>
        public string CodigoTipoServicio { get; set; }

        //FIN: Agregado por Julio Carrera - Norma Contable
        #endregion
    }
}

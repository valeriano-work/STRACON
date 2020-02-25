using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.Politicas.Presentacion.Recursos;
using Pe.Stracon.Politicas.Presentacion.Recursos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.Politicas.Presentacion.Core.ViewModel.General.Trabajador
{
    /// <summary>
    /// Modelo de vista para el formulario TrabajadorUnidadOperativa
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    public class TrabajadorUnidadOperativaModel : GenericViewModel
    {
        /// <summary>
        /// Constructor del Modelo
        /// </summary>
        /// <param name="trabajador">Trabajador</param>
        /// <param name="unidadOperativaMatriz">Unidad Operativa Matriz</param>
        public TrabajadorUnidadOperativaModel(TrabajadorResponse trabajador, List<UnidadOperativaResponse> unidadOperativaMatriz)        
        {
            this.UnidadOperativa = new List<SelectListItem>();
            this.UnidadOperativa.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });

            this.UnidadOperativaMatriz = new List<SelectListItem>();
            this.UnidadOperativaMatriz.Add(new SelectListItem() { Value = string.Empty, Text = GenericoResource.EtiquetaSeleccionar });
            this.UnidadOperativaMatriz.AddRange(unidadOperativaMatriz.Select(item => new SelectListItem()
            {
                Value = item.CodigoUnidadOperativa.ToString(),
                Text = item.Nombre,
                Selected = (trabajador.CodigoUnidadOperativaMatriz == item.CodigoUnidadOperativa.ToString())
            }).ToList());

            this.Trabajador = trabajador;
        }

        #region Propiedades
        /// <summary>
        /// Lista de Unidad Operativa Matriz
        /// </summary>
        public List<SelectListItem> UnidadOperativaMatriz { get; set; }
        /// <summary>
        /// Lista de Unidades Operativas
        /// </summary>
        public List<SelectListItem> UnidadOperativa { get; set; }
        /// <summary>
        /// Trabajador
        /// </summary>
        public TrabajadorResponse Trabajador { get; set; }
        #endregion
    }
}

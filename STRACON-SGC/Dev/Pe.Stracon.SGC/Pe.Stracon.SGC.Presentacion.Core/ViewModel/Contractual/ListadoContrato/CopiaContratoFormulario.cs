using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ListadoContrato
{
    /// <summary>
    /// Modelo de vista de Copia de Contrato
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20170630 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class CopiaContratoFormulario
    {
        #region Propiedades       
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
        /// Lista de Tipos de Servicios
        /// </summary>
        public List<SelectListItem> TipoServicio { get; set; }

        #endregion

         /// <summary>
        /// Constructor del modelo
        /// </summary>      
        /// <param name="moneda">Lista de Monedas</param>
        public CopiaContratoFormulario(List<CodigoValorResponse> moneda)
        {           
            this.Moneda = GenerarListadoOpcioneGenericoFormulario(moneda, DatosConstantes.Moneda.Dolares);         
            this.Contrato = new ContratoResponse();
        }

        /// <summary>
        /// Genera una lista de opciones con el item generico Seleccionar
        /// </summary>
        /// <param name="opciones">Opciones a agregar</param>
        /// <param name="seleccionado">Item seleccionado</param>
        /// <returns>Lista generada</returns>
        protected List<SelectListItem> GenerarListadoOpcioneGenericoFormulario(List<CodigoValorResponse> opciones, object seleccionado = null)
        {
            var opcionesCasteadas = CastearOpcioneGenerico(opciones, seleccionado);
            var noExiste = (opcionesCasteadas.Where(o => o.Selected == true).FirstOrDefault() == null);
            return GenerarListadoOpcioneGenericoFormulario(opcionesCasteadas, noExiste);
        }

        /// <summary>
        /// Convierta una lista de CodigoValorResponse a SelectListItem
        /// </summary>
        /// <param name="opciones">Opciones a convertir</param>
        /// <param name="seleccionado">Opción seleccionada</param>
        /// <returns>Lista generada</returns>
        private List<SelectListItem> CastearOpcioneGenerico(List<CodigoValorResponse> opciones, object seleccionado = null)
        {
            List<SelectListItem> resultado = opciones.Select(i => new SelectListItem()
            {
                Value = i.Codigo.ToString(),
                Text = i.Valor.ToString(),
                Selected = seleccionado != null ? (i.Codigo.Equals(seleccionado)) : false
            }).ToList();
            return resultado;
        }

        /// <summary>
        /// Genera una lista de opciones con el item generico Seleccionar
        /// </summary>
        /// <param name="opciones">Opciones a agregar</param>
        /// <returns>Lista generada</returns>
        protected List<SelectListItem> GenerarListadoOpcioneGenericoFormulario(List<SelectListItem> opciones = null, bool seleccionar = true)
        {
            return GenerarListadoOpcioneGenerico(GenericoResource.EtiquetaSeleccionar, opciones, seleccionar);
        }

        /// <summary>
        /// Genera una lista de opciones agregando la opción indicada
        /// </summary>
        /// <param name="opciones">Opciones a agregar</param>
        /// <returns>Lista generada</returns>
        protected List<SelectListItem> GenerarListadoOpcioneGenerico(string etiquetaPrimaria, List<SelectListItem> opciones = null, bool seleccionar = true)
        {
            List<SelectListItem> resultado = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(etiquetaPrimaria))
            {
                if (seleccionar)
                {
                    resultado.Add(new SelectListItem() { Value = "", Text = etiquetaPrimaria, Selected = true });
                }
                else
                {
                    resultado.Add(new SelectListItem() { Value = "", Text = etiquetaPrimaria });
                }
            }
            if (opciones != null)
            {
                resultado.AddRange(opciones);
            }

            return resultado;
        }
    }
}

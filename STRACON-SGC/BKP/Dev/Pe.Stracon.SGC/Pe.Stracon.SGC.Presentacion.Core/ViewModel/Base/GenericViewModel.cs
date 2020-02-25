using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base
{
    /// <summary>
    /// Modelo de vista genérico - base
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public abstract class GenericViewModel
    {
        /// <summary>
        /// Generar una lista de opciones con los valores de estado para las bandejas con filtro
        /// </summary>
        /// <returns>Lista generada</returns>
        protected List<SelectListItem> GenerarListadoOpcioneEstadoFiltro()
        {
            var opcionesEstado = GenerarListadoOpcioneEstado();
            return GenerarListadoOpcioneGenericoFiltro(opcionesEstado);
        }
        /// <summary>
        /// Generar una lista de opciones con los valores de estado para los furmularios
        /// </summary>
        /// <returns>Lista generada</returns>
        protected List<SelectListItem> GenerarListadoOpcioneEstadoFormulario()
        {
            var opcionesEstado = GenerarListadoOpcioneEstado();
            return GenerarListadoOpcioneGenericoFormulario(opcionesEstado);
        }
        /// <summary>
        /// Generar una lista de opciones con los valores de estado
        /// </summary>
        /// <returns>Lista generada</returns>
        private List<SelectListItem> GenerarListadoOpcioneEstado()
        {
            string etiquetaActiva = GenericoResource.EtiquetaActiva;
            string etiquetaInactiva = GenericoResource.EtiquetaInactiva;

            //Estado de Unidad Operativa
            List<SelectListItem> estados = new List<SelectListItem>();
            estados.Add(new SelectListItem() { Value = "1", Text = etiquetaActiva });
            estados.Add(new SelectListItem() { Value = "0", Text = etiquetaInactiva });

            return estados;
        }

        /// <summary>
        /// Generar una lista de opciones con los valores de estado para los furmularios
        /// </summary>
        /// <returns>Lista generada</returns>
        protected List<SelectListItem> GenerarListadoOpcionesSiNoFiltro()
        {
            var opcionesSiNo = GenerarListadoOpcionesSiNo();
            return GenerarListadoOpcioneGenericoFiltro(opcionesSiNo);
        }

        /// <summary>
        /// Generar una lista de opciones con los valores de estado
        /// </summary>
        /// <returns>Lista generada</returns>
        private List<SelectListItem> GenerarListadoOpcionesSiNo()
        {
            string etiquetaSi = GenericoResource.EtiquetaSi;
            string etiquetaNo = GenericoResource.EtiquetaNo;

            //Calendarización
            List<SelectListItem> opcionesSiNo = new List<SelectListItem>();
            opcionesSiNo.Add(new SelectListItem() { Value = "1", Text = etiquetaSi });
            opcionesSiNo.Add(new SelectListItem() { Value = "0", Text = etiquetaNo });

            return opcionesSiNo;
        }

        /// <summary>
        /// Genera una lista de opciones con el item generico Todos
        /// </summary>
        /// <param name="opciones">Opciones a agregar</param>
        /// <returns>Lista generada</returns>
        protected List<SelectListItem> GenerarListadoOpcioneGenericoFiltro(List<SelectListItem> opciones = null, bool seleccionar = true)
        {
            return GenerarListadoOpcioneGenerico(GenericoResource.EtiquetaTodos, opciones, seleccionar);
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

        /// <summary>
        /// Genera una lista de opciones con el item generico Todos
        /// </summary>
        /// <param name="opciones">Opciones a agregar</param>
        /// <param name="seleccionado">Item seleccionado</param>
        /// <returns>Lista generada</returns>
        protected List<SelectListItem>GenerarListadoOpcioneGenericoFiltro(List<CodigoValorResponse> opciones, object seleccionado = null)
        {
            var opcionesCasteadas = CastearOpcioneGenerico(opciones, seleccionado);
            var noExiste = (opcionesCasteadas.Where(o => o.Selected == true).FirstOrDefault() == null);
            return GenerarListadoOpcioneGenericoFiltro(opcionesCasteadas, noExiste);
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
        /// Genera una lista de opciones con el item generico Seleccionar
        /// </summary>
        /// <param name="opciones">Opciones a agregar</param>
        /// <param name="seleccionado">Item seleccionado</param>
        /// <returns>Lista generada</returns>
        protected List<SelectListItem> GenerarListadoOpcioneGenericoListaFormulario(List<CodigoValorResponse> opciones, List<string> seleccionado = null)
        {
            var opcionesCasteadas = CastearOpcioneGenericoLista(opciones, seleccionado);
            var noExiste = (opcionesCasteadas.Where(o => o.Selected == true).FirstOrDefault() == null);
            return GenerarListadoOpcioneGenerico(null, opcionesCasteadas, noExiste);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="opciones"></param>
        /// <param name="seleccionado"></param>
        /// <returns>Lista generada</returns>
        protected List<SelectListItem> GenerarListadoOpcionUnidadOperativaFiltro(List<UnidadOperativaResponse> opciones, object seleccionado = null)
        {
            var opcionesCasteadas = CastearOpcionUnidadOperativa(opciones, seleccionado);
            var noExiste = (opcionesCasteadas.Where(o => o.Selected == true).FirstOrDefault() == null);
            return GenerarListadoOpcioneGenericoFiltro(opcionesCasteadas, noExiste);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="opciones"></param>
        /// <param name="seleccionado"></param>
        /// <returns>Lista generada</returns>
        protected List<SelectListItem> GenerarListadoOpcionUnidadOperativaFormulario(List<UnidadOperativaResponse> opciones, object seleccionado = null)
        {
            var opcionesCasteadas = CastearOpcionUnidadOperativa(opciones, seleccionado);
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
        /// Convierta una lista de CodigoValorResponse a SelectListItem
        /// </summary>
        /// <param name="opciones">Opciones a convertir</param>
        /// <param name="seleccionado">Opción seleccionada</param>
        /// <returns>Lista generada</returns>
        private List<SelectListItem> CastearOpcioneGenericoLista(List<CodigoValorResponse> opciones, List<string> seleccionado = null)
        {
            List<SelectListItem> resultado = opciones.Select(i => new SelectListItem()
            {
                Value = i.Codigo.ToString(),
                Text = i.Valor.ToString(),
                Selected = seleccionado != null ? (seleccionado.Any(item => item == i.Codigo.ToString())) : false
            }).ToList();
            return resultado;
        }
        /// <summary>
        /// Castear Opcion Unidad Operativa
        /// </summary>
        /// <param name="opciones"></param>
        /// <param name="seleccionado"></param>
        /// <returns>Lista generada</returns>
        private List<SelectListItem> CastearOpcionUnidadOperativa(List<UnidadOperativaResponse> opciones, object seleccionado = null)
        {
            List<SelectListItem> resultado = opciones.Select(i => new SelectListItem()
            {
                Value = i.CodigoUnidadOperativa.ToString(),
                Text = i.Nombre.ToString(),
                Selected = seleccionado != null ? (i.CodigoUnidadOperativa.ToString().Equals(seleccionado)) : false
            }).ToList();
            return resultado;
        }
    }
}

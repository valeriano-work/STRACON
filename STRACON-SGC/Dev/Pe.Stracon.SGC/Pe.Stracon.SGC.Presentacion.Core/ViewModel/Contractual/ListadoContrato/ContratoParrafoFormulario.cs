using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ListadoContrato
{
    /// <summary>
    /// Modelo de vista de Contrato Párrafo
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150603 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ContratoParrafoFormulario : GenericViewModel
    {
        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        public ContratoParrafoFormulario()
        {
            this.ContratoParrafo = new ContratoResponse();
        }

        /// <summary>
        /// Constructor usado para el registro de datos
        /// </summary>
        /// <param name="plantillaParrafo">Lista de Plantilla Párrafo</param>
        /// <param name="plantillaParrafoVariable">Lista de Plantilla Párrafo Variable</param>
        /// <param name="indicadorUltimoParrafo">Indicador de Último Párrafo</param>
        /// <param name="listaVariablePorDefecto">Lista de Variables por Defecto</param>
        /// <param name="listaValoresVariableParrafo">Lista de Variables grabadas parcialmente</param>
        public ContratoParrafoFormulario(List<PlantillaParrafoResponse> plantillaParrafo, List<PlantillaParrafoVariableResponse> plantillaParrafoVariable, List<CodigoValorResponse> listaVariablePorDefecto, List<ContratoParrafoVariableResponse> listaValoresVariableParrafo, string intervaloTiempoAutoguardado)
        {
            this.ListaPlantillaParrafo = plantillaParrafo;
            this.ListaPlantillaParrafoVariable = plantillaParrafoVariable;
            this.IndicadorExistePlantilla = true;
            this.ListaVariablePorDefecto = listaVariablePorDefecto;
            this.ListaValoresVariableParrafo = listaValoresVariableParrafo;
            this.IntervaloTiempoAutoguardado = intervaloTiempoAutoguardado;
        }

        #region Propiedades
        /// <summary>
        /// Indicador de Existe Plantilla
        /// </summary>
        public bool IndicadorExistePlantilla { get; set; }
        /// <summary>
        /// Clase Response de Contrato Párrafo
        /// </summary>
        public ContratoResponse ContratoParrafo { get; set; }
        /// <summary>
        /// Clase Response de Plantilla Párrafo
        /// </summary>
        public List<PlantillaParrafoResponse> ListaPlantillaParrafo { get; set; }
        /// <summary>
        /// Lista de Plantilla Párrafo Variable
        /// </summary>
        public List<PlantillaParrafoVariableResponse> ListaPlantillaParrafoVariable { get; set; }
        /// <summary>
        /// Lista de Variables
        /// </summary>
        public List<CodigoValorResponse> ListaVariablePorDefecto { get; set; }
        /// <summary>
        /// Lista de Valores de las variables de los parrafos de un contrato
        /// </summary>
        public List<ContratoParrafoVariableResponse> ListaValoresVariableParrafo { get; set; }
        /// <summary>
        /// Intervalo de Tiempo de Autoguardado
        /// </summary>
        public string IntervaloTiempoAutoguardado { get; set; }

        /// <summary>
        /// Copia
        /// </summary>
        public bool EsCopia { get; set; }
        #endregion
    }
}

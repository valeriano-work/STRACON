using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using System;
namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Variable
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class VariableRequest : Filtro
    {
        /// <summary>
        /// Codigo Variable
        /// </summary>
        public string CodigoVariable { get; set; }
        /// <summary>
        /// Codigo Plantilla
        /// </summary>
        public string CodigoPlantilla { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private string IdentificadorP; 
        /// <summary>
        /// Identificador
        /// </summary>
        public string Identificador
        {
            get { return IdentificadorP; }
            set { IdentificadorP = value != null ? (DatosConstantes.IdentificadorVariable.Almohadilla + value) : value; } 
        }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Codigo Tipo
        /// </summary>
        public string CodigoTipo { get; set; }
        /// <summary>
        /// Indicador Global
        /// </summary>
        public bool? IndicadorGlobal { get; set; }
        /// <summary>
        /// Indicador Global
        /// </summary>
        public string IndicadorGlobalSelect { get; set; }        
        /// <summary>
        /// Indicador Sistema
        /// </summary>
        public bool? IndicadorSistema { get; set; }
        /// <summary>
        /// Indicador Variable Sistema
        /// </summary>
        public bool? IndicadorVariableSistema { get; set; }

    }
}

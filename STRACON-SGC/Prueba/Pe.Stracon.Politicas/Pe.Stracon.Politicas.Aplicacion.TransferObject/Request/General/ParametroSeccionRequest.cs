using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General
{
    /// <summary>
    /// Representa el objeto de filtro a aplicar a la busqueda de parametro sección
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroSeccionRequest : Filtro
    {
        /// <summary>
        /// Constructor Parametro Secccion Request
        /// </summary>
        public ParametroSeccionRequest()
        {
            EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;
        }
        /// <summary>
        /// Código del Parametro
        /// </summary>
        public int? CodigoParametro { get; set; }
        /// <summary>
        /// Código de Sección
        /// </summary>
        public int? CodigoSeccion { get; set; }
        /// <summary>
        /// Nombre de Sección
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Código de Tipo de Dato
        /// </summary>
        public string CodigoTipoDato { get; set; }
        /// <summary>
        /// Indicador de Permite Modificar
        /// </summary>
        public bool? IndicadorPermiteModificar { get; set; }
        /// <summary>
        /// Indicador de sección obligatorio
        /// </summary>
        public bool? IndicadorObligatorio { get; set; }
        /// <summary>
        /// Indicador de Sistema
        /// </summary>
        public bool? IndicadorSistema { get; set;}
        /// <summary>
        /// Código de Parametro Relacionado
        /// </summary>
        public int? CodigoParametroRelacionado { get; set; }
        /// <summary>
        /// Código de Sección Relacionada
        /// </summary>
        public int? CodigoSeccionRelacionado { get; set; }
        /// <summary>
        /// Código de Sección Relacionada a Mostrar
        /// </summary>
        public int? CodigoSeccionRelacionadoMostrar { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
    }

}

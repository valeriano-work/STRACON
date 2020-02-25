using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad parámetro sección
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroSeccionEntity : Entity
    {
        /// <summary>
        /// Código de parámetro
        /// </summary>
        public int CodigoParametro { get; set; }
        /// <summary>
        /// Código de Sección
        /// </summary>
        public int CodigoSeccion { get; set; }
        /// <summary>
        /// Nombre 
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Código de Tipo de Dato
        /// </summary>
        public string CodigoTipoDato { get; set; }
        /// <summary>
        /// Indicador que permite modificar
        /// </summary>
        public bool IndicadorPermiteModificar { get; set; }
        /// <summary>
        /// Indicador Obligatorio
        /// </summary>
        public bool IndicadorObligatorio { get; set; }
        /// <summary>
        /// Indicador de sistema
        /// </summary>
        public bool IndicadorSistema { get; set; }
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
    }
}

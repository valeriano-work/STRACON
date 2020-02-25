using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad parámetro valor
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroValorEntity : Entity
    {
        /// <summary>
        /// Código de parámetro
        /// </summary>
        public int CodigoParametro { get; set; }
        /// <summary>
        /// Código de sección
        /// </summary>
        public int CodigoSeccion { get; set; }
        /// <summary>
        /// Código de valor
        /// </summary>
        public int CodigoValor { get; set; }
        /// <summary>
        /// Valor
        /// </summary>
        public string Valor { get; set; }
    }
}

using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad tipo de dato
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TipoDatoEntity : Entity
    {
        /// <summary>
        /// Código de tipo de dato
        /// </summary>
        public int CodigoTipoDato { get; set; }
        /// <summary>
        /// Nombre 
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }

    }
}

using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad país
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PaisEntity : Entity
    {
        /// <summary>
        /// Código de país
        /// </summary>
        public int Codigo { get; set; }
        /// <summary>
        /// Nombre 
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Código Secundario
        /// </summary>
        public int CodigoSecundario { get; set; }

    }
}

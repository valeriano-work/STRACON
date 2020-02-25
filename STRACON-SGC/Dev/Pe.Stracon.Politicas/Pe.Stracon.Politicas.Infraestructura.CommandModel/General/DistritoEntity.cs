using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad distrito
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class DistritoEntity : Entity
    {
        /// <summary>
        /// Código de distrito
        /// </summary>
        public int Codigo { get; set; }
        /// <summary>
        /// Código de provincia
        /// </summary>
        public int CodigoPronvicia { get; set; }
        /// <summary>
        /// Código de ubigeo
        /// </summary>
        public string CodigoUbigeo { get; set; }
        /// <summary>
        /// Nombre 
        /// </summary>
        public string Nombre { get; set; }
    }
}

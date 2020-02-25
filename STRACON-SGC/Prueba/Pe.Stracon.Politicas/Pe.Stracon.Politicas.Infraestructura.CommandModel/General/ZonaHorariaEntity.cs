using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad de zona horaria
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ZonaHorariaEntity : Entity
    {
        /// <summary>
        /// Código de zona horaria
        /// </summary>
        public int Codigo { get; set; }
        /// <summary>
        /// Hora utc
        /// </summary>
        public short HoraUTC { get; set; }
        /// <summary>
        /// Minuto utc
        /// </summary>
        public short MinutoUTC { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }
    }
}

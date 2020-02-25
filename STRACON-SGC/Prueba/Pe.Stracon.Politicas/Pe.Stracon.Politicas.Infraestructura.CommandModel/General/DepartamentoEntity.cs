using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad departamento
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class DepartamentoEntity : Entity
    {
        /// <summary>
        /// Código de departamento
        /// </summary>
        public int Codigo { get; set; }
        /// <summary>
        /// Código de país
        /// </summary>
        public int CodigoPais { get; set; }
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

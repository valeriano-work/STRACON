
namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Base
{
    /// <summary>
    /// Campos de Paginacion
    /// </summary>
    public class Paginado
    {
        /// <summary>
        /// Filas totales
        /// </summary>
        public int? FilasTotal { get; set; }
        /// <summary>
        /// Numero de filas
        /// </summary>
        public long? NumeroFila { get; set; }
        /// <summary>
        /// Identificador de fila
        /// </summary>
        public string IdentificadorFila { get; set; }
    }
}

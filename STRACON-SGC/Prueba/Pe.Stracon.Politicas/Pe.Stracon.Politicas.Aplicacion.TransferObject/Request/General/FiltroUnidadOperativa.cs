using System.ComponentModel.DataAnnotations;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General
{
    /// <summary>
    /// Representa el objeto de filtro a aplicar a la busqueda de unidad operativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class FiltroUnidadOperativa: Filtro
    {
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Nombre a buscar
        /// </summary>
        [MaxLength(5)]        
        public string Nombre { get; set; }
        /// <summary>
        /// Nivel asociado
        /// </summary>
        public string Nivel { get; set; }
        /// <summary>
        /// Unidad operativa superior
        /// </summary>
        public string UnidadSuperior { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public string Indicador { get; set; }
    }
}


namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Base
{
    /// <summary>
    /// Base para los DTOS filtros
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class Filtro
    {
        public Filtro()
        {
            this.NumeroPagina = 1;
            this.RegistrosPagina = -1;
        }
        /// <summary>
        /// Pagina solicitada
        /// </summary>
        public int NumeroPagina { get; set; }
        /// <summary>
        /// Registros por Pagina
        /// </summary>
        public int RegistrosPagina { get; set; }
        /// <summary>
        /// 
        /// </summary>
       public string ColumnaOrden{ get; set; }
        /// <summary>
        /// 
        /// </summary>
       public string TipoOrden { get; set; }
    }
}

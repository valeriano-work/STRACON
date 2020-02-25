using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Base;

namespace Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual
{
    /// <summary>
    /// Definición del Repositorio de Requerimiento Estadio
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150529 <br />
    /// Modificación :               <br />
    /// </remarks> 
    public interface IRequerimientoEstadioEntityRepository : IComandRepository<RequerimientoEstadioEntity>
    {
        /// <summary>
        /// Realiza la inserción o actualización de Requerimiento Estadio
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int RegistrarRequerimientoEstadio(RequerimientoEstadioEntity data);
    }
}

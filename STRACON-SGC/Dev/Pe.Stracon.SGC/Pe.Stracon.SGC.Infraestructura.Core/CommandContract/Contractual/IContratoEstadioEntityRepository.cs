using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Base;

namespace Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual
{
    /// <summary>
    /// Definición del Repositorio de Contrato Estadio
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150529 <br />
    /// Modificación :               <br />
    /// </remarks> 
    public interface IContratoEstadioEntityRepository : IComandRepository<ContratoEstadioEntity>
    {
        /// <summary>
        /// Realiza la inserción o actualización de Contrato Estadio
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int RegistrarContratoEstadio(ContratoEstadioEntity data);
    }
}

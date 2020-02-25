using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Base;

namespace Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual
{
    /// <summary>
    /// Definición del Repositorio de Requerimientos
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150525 <br />
    /// Modificación :               <br />
    /// </remarks> 
    public interface IRequerimientoEntityRepository : IComandRepository<RequerimientoEntity>
    {
        /// <summary>
        /// Realiza la inserción de contratos
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int RegistrarRequerimiento(RequerimientoEntity data);

        /// <summary>
        /// Realiza la edición de un contrato
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int EditarRequerimiento(RequerimientoEntity data);

        /// <summary>
        /// Realiza consulta para validar numero de contrato
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int ConsultaNumeroRequerimiento(RequerimientoEntity data);

        int Actualizar_Flujo_Requerimiento_Estadio(RequerimientoEntity data);
    }
}

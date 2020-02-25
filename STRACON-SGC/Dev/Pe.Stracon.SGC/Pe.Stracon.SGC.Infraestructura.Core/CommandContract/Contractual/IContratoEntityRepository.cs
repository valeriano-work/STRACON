using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Base;

namespace Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual
{
    /// <summary>
    /// Definición del Repositorio de Contratos
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150525 <br />
    /// Modificación :               <br />
    /// </remarks> 
    public interface IContratoEntityRepository : IComandRepository<ContratoEntity>
    {
        /// <summary>
        /// Realiza la inserción de contratos
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int RegistrarContrato(ContratoEntity data);

        /// <summary>
        /// Realiza la edición de un contrato
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int EditarContrato(ContratoEntity data);

        /// <summary>
        /// Realiza consulta para validar numero de contrato
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        int ConsultaNumeroContrato(ContratoEntity data);

        int Actualizar_Flujo_Contrato_Estadio(ContratoEntity data);
    }
}

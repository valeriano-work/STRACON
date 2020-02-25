using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Base;

namespace Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual
{
    /// <summary>
    /// Definición del Repositorio de Plantilla
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150519 <br />
    /// Modificación :           <br />
    /// </remarks> 
    public interface IContratoDocumentoEntityRepository : IComandRepository<ContratoDocumentoEntity>
    {
        /// <summary>
        /// Realiza la inserción o actualización de Contrato Documento
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int RegistrarContratoDocumento(ContratoDocumentoEntity data);
    }
}

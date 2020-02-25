using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Base;
using System;

namespace Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual
{
    /// <summary>
    /// Definición del Repositorio de Plantilla
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150519 <br />
    /// Modificación :           <br />
    /// </remarks> 
    public interface IPlantillaRequerimientoEntityRepository : IComandRepository<PlantillaRequerimientoEntity>
    {
        /// <summary>
        /// Realiza la actualización del Estado de Vigencia de la Plantilla
        /// </summary>
        /// <returns>Indicador con el resultado de la operación</returns>
        int ActualizarPlantillaEstadoVigencia();

        /// <summary>
        /// Copia una plantilla
        /// </summary>
        /// <param name="codigoPlantillaCopiar">Código de la plantilla a copiar</param>
        /// <param name="descripcion">Descripción de la nueva plantilla</param>
        /// <param name="fechaInicioVigencia">Fecha de inicio de vigencia</param>
        /// <param name="usuarioCreacion">Usuario de creación</param>
        /// <param name="terminalCreacion">Terminal de creación</param>
        /// <returns></returns>
        int CopiarPlantilla(Guid codigoPlantillaCopiar, string descripcion, DateTime fechaInicioVigencia, string usuarioCreacion, string terminalCreacion);
       
    }
}

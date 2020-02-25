using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    /// <summary>
    /// Definición del Repositorio de Plantilla
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150518 <br />
    /// Modificación :           <br />
    /// </remarks>
    public interface IProcesoAuditoriaLogicRepository : IQueryRepository<ProcesoAuditoriaLogic>
    {
        /// <summary>
        /// Realiza la busqueda de Proceso Auditoria
        /// </summary>
        /// <param name="codigoAuditoria">Código de auditoria</param>
        /// <param name="codigoUnidadOperativa">Código de unidad operativa</param>
        /// <param name="fechaPlanificada">Fecha planificada</param>
        /// <param name="fechaEjecucion">Fecha de Ejecución</param>
        /// <param name="estadoRegistro">Estado de registro</param>
        /// <returns>Procesos de Auditoria</returns>
        List<ProcesoAuditoriaLogic> BuscarBandejaProcesoAuditoria(
                Guid? codigoAuditoria,
                Guid? codigoUnidadOperativa,
                DateTime? fechaPlanificada,
                DateTime?  fechaEjecucion,
                string estadoRegistro
        );

        /// <summary>
        /// Verifica si se repite un proceso de Auditoria
        /// </summary>
        /// <param name="codigoUnidadOperativa">Código de Unidad Operativa</param>
        /// <param name="fechaPlanificada">Fecha Planificada</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        List<ProcesoAuditoriaLogic> RepiteProcesoAuditoria(
            Guid codigoUnidadOperativa,
            DateTime fechaPlanificada
        );
    }
}

using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using System;
using System.Collections.Generic;

namespace Pe.Stracon.SGC.Application.Core.ServiceContract
{
    public interface IProcesoAuditoriaService : IGenericService
    {
        /// <summary>
        /// Busca Bandeja Proceso Auditoria
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns>Lista con el resultado de la operación</returns>
        ProcessResult<List<ProcesoAuditoriaResponse>> BuscarBandejaProcesoAuditoria(ProcesoAuditoriaRequest filtro);
        /// <summary>
        /// Registra o Actualiza un Proceso Auditoria
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<ProcesoAuditoriaRequest> RegistrarProcesoAuditoria(ProcesoAuditoriaRequest data);

        /// <summary>
        /// Eliminar una o muchos Procesos de Auditoria
        /// </summary>
        /// <param name="listaCodigoProcesoAuditoria"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<Object> EliminarProcesoAuditoria(List<Object> listaCodigosAuditoria);
        
    }
}

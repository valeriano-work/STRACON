using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementacion del adaptador de Flujo Aprobacion
    /// </summary>
    public sealed class ProcesoAuditoriaAdapter
    {
        
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public static ProcesoAuditoriaEntity RegistrarFlujoAuditoria(ProcesoAuditoriaRequest data)
        {
            ProcesoAuditoriaEntity procesoAuditoriaEntity = new ProcesoAuditoriaEntity();
            if (data.CodigoAuditoria != null)
            {
                procesoAuditoriaEntity.CodigoAuditoria = new Guid(data.CodigoAuditoria);
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                procesoAuditoriaEntity.CodigoAuditoria = code;
            }

            procesoAuditoriaEntity.CodigoUnidadOperativa = new Guid(data.CodigoUnidadOperativa);
            if (!string.IsNullOrWhiteSpace(data.FechaPlanificadaString))
            {
                procesoAuditoriaEntity.FechaPlanificada = DateTime.ParseExact(data.FechaPlanificadaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
            }
            if (!string.IsNullOrWhiteSpace(data.FechaEjecucionString))
            {
                procesoAuditoriaEntity.FechaEjecucion = DateTime.ParseExact(data.FechaEjecucionString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                procesoAuditoriaEntity.FechaEjecucion = null;
            }            
            procesoAuditoriaEntity.CantidadAuditadas = data.CantidadAuditadas;
            procesoAuditoriaEntity.CantidadObservadas = data.CantidadObservadas;
            procesoAuditoriaEntity.ResultadoAuditoria = data.ResultadoAuditoria;

            return procesoAuditoriaEntity;
        }

        /// <summary>
        /// Obtiene Proceso de Auditoria
        /// </summary>
        /// <param name="procesoAuditoriaLogic">Proceso Auditoria Logic</param>
        /// <param name="unidadOperativa">Unidad Operativa</param>
        /// <returns>Proceso de Auditoria</returns>
        public static ProcesoAuditoriaResponse ObtenerProcesoAuditoria(
            ProcesoAuditoriaLogic procesoAuditoriaLogic,
            List<UnidadOperativaResponse> unidadOperativa
        )
        {
            string sUnidadOperativa = null;
            if (unidadOperativa != null)
            {
                var uoperativa = unidadOperativa.Where(n => n.CodigoUnidadOperativa.ToString() == procesoAuditoriaLogic.CodigoUnidadOperativa.ToString()).FirstOrDefault();
                sUnidadOperativa = (uoperativa == null ? null : uoperativa.Nombre.ToString());
            }

            var procesoAuditoriaResponse = new ProcesoAuditoriaResponse();

            procesoAuditoriaResponse.CodigoAuditoria = procesoAuditoriaLogic.CodigoAuditoria.ToString();
            procesoAuditoriaResponse.CodigoUnidadOperativa = procesoAuditoriaLogic.CodigoUnidadOperativa.ToString();
            procesoAuditoriaResponse.DescripcionUnidadOperativa = sUnidadOperativa;
            procesoAuditoriaResponse.FechaPlanificada = procesoAuditoriaLogic.FechaPlanificada;
            procesoAuditoriaResponse.FechaPlanificadaString = procesoAuditoriaLogic.FechaPlanificada.ToString(DatosConstantes.Formato.FormatoFecha);
            procesoAuditoriaResponse.FechaEjecucion = procesoAuditoriaLogic.FechaEjecucion;
            procesoAuditoriaResponse.FechaEjecucionString = procesoAuditoriaLogic.FechaEjecucion.HasValue ? procesoAuditoriaLogic.FechaEjecucion.Value.ToString(DatosConstantes.Formato.FormatoFecha) : string.Empty;  
            procesoAuditoriaResponse.CantidadAuditadas = procesoAuditoriaLogic.CantidadAuditadas;
            procesoAuditoriaResponse.CantidadObservadas = procesoAuditoriaLogic.CantidadObservadas;
            procesoAuditoriaResponse.ResultadoAuditoria = procesoAuditoriaLogic.ResultadoAuditoria;
            
            return procesoAuditoriaResponse;
        }
    }
}

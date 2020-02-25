using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.Adapter.Contractual;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.Core.Message;
using Pe.Stracon.SGC.Aplicacion.Service.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Cross.Core.Exception;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Service.Contractual
{
    /// <summary>
    /// Servicio que representa las actividades de Flujo Aprobacion
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150507 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class ProcesoAuditoriaService : GenericService, IProcesoAuditoriaService
    {
        #region Propiedades
        /// <summary>
        /// Repositorio de manejo de Proceso de Auditoria Entity
        /// </summary>
        public IProcesoAuditoriaEntityRepository procesoAuditoriaEntityRepository { get; set; }
        /// <summary>
        /// Servicio de manejo de Unidad Operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }
        /// <summary>
        /// Servicio de manejo de Proceso Auditoria Logic
        /// </summary>
        public IProcesoAuditoriaLogicRepository procesoAuditoriaLogicRepository { get; set; }
        #endregion
        /// <summary>
        /// Busca Procesos de Auditoria
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns>Procesos de Auditoria</returns>
        public ProcessResult<List<ProcesoAuditoriaResponse>> BuscarBandejaProcesoAuditoria(ProcesoAuditoriaRequest filtro)
        {
            ProcessResult<List<ProcesoAuditoriaResponse>> resultado = new ProcessResult<List<ProcesoAuditoriaResponse>>();
            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = "03" });
            try
            {
                Guid? codigoAuditoria = (filtro.CodigoAuditoria != null && filtro.CodigoAuditoria != "") ? new Guid(filtro.CodigoAuditoria) : (Guid?)null;
                Guid? codigoUnidadOperativa = (filtro.CodigoUnidadOperativa != null && filtro.CodigoUnidadOperativa != "") ? new Guid(filtro.CodigoUnidadOperativa) : (Guid?)null;

                DateTime? fechaPlanificada = null;
                DateTime? fechaEjecucion = null;

                if (!string.IsNullOrWhiteSpace(filtro.FechaPlanificadaString))
                {
                    fechaPlanificada = DateTime.ParseExact(filtro.FechaPlanificadaString, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture); ;
                }
                else
                {
                    fechaPlanificada = filtro.FechaPlanificada;
                }

                if (!string.IsNullOrWhiteSpace(filtro.FechaEjecucionString))
                {
                    fechaEjecucion = DateTime.ParseExact(filtro.FechaEjecucionString, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture); ;
                }
                else
                {
                    fechaEjecucion = filtro.FechaEjecucion;
                }


                List<ProcesoAuditoriaLogic> listado = procesoAuditoriaLogicRepository.BuscarBandejaProcesoAuditoria(
                    codigoAuditoria,
                    codigoUnidadOperativa,
                    fechaPlanificada,
                    fechaEjecucion,
                    filtro.EstadoRegistro
                );

                resultado.Result = new List<ProcesoAuditoriaResponse>();

                foreach (var registro in listado)
                {
                    var procesoAuditoria = ProcesoAuditoriaAdapter.ObtenerProcesoAuditoria(registro, unidadOperativa.Result);
                    resultado.Result.Add(procesoAuditoria);
                }

            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ProcesoAuditoriaService>(e);
            }
            return resultado;
        }
        /// <summary>
        /// Registra o Actualiza un Proceso Auditoria
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Identificador de registro</returns>
        public ProcessResult<ProcesoAuditoriaRequest> RegistrarProcesoAuditoria(ProcesoAuditoriaRequest data)
        {
            ProcessResult<ProcesoAuditoriaRequest> resultado = new ProcessResult<ProcesoAuditoriaRequest>();
            try
            {

                ProcesoAuditoriaEntity entidad = ProcesoAuditoriaAdapter.RegistrarFlujoAuditoria(data);


                DateTime fechaPlanificada = entidad.FechaPlanificada;
                DateTime? fechaEjecucion = entidad.FechaEjecucion;


                if (fechaPlanificada > fechaEjecucion)
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<ProcesoAuditoriaService>("El campo Fecha Planificada debe ser menor a la Fecha Ejecución");
                }
                else
                {
                    Guid codigoUnidadOperativa = new Guid(data.CodigoUnidadOperativa);
                    var resultadoRepetido = procesoAuditoriaLogicRepository.RepiteProcesoAuditoria(
                        codigoUnidadOperativa,
                        entidad.FechaPlanificada
                    );
                    bool existeRepetido = resultadoRepetido.Any(e => e.CodigoAuditoria != entidad.CodigoAuditoria);
                    if (existeRepetido)
                    {
                        resultado.IsSuccess = false;
                        resultado.Exception = new ApplicationLayerException<ProcesoAuditoriaService>(MensajesSistema.ProcesoAuditoriaExiste);
                    }
                    else
                    {
                        if (data.CodigoAuditoria == null)
                        {
                            procesoAuditoriaEntityRepository.Insertar(entidad);
                        }
                        else
                        {
                            var entidadSincronizar = procesoAuditoriaEntityRepository.GetById(entidad.CodigoAuditoria);
                            entidadSincronizar.CodigoUnidadOperativa = entidad.CodigoUnidadOperativa;
                            entidadSincronizar.FechaPlanificada = entidad.FechaPlanificada;
                            entidadSincronizar.FechaEjecucion = entidad.FechaEjecucion;
                            entidadSincronizar.CantidadAuditadas = entidad.CantidadAuditadas;
                            entidadSincronizar.CantidadObservadas = entidad.CantidadObservadas;
                            entidadSincronizar.ResultadoAuditoria = entidad.ResultadoAuditoria;
                            procesoAuditoriaEntityRepository.Editar(entidadSincronizar);
                        }
                        procesoAuditoriaEntityRepository.GuardarCambios();
                    }
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ProcesoAuditoriaService>(e);
            }            
            return resultado;
        }
        /// <summary>
        /// Elimina Proceso Auditoria
        /// </summary>
        /// <param name="listaCodigosAuditoria">Lista a eliminar</param>
        /// <returns>Registro de proceso</returns>
        public ProcessResult<object> EliminarProcesoAuditoria(List<object> listaCodigosAuditoria)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {

                foreach (var codigo in listaCodigosAuditoria)
                {
                    var llaveEntidad = new Guid(codigo.ToString());
                    procesoAuditoriaEntityRepository.Eliminar(llaveEntidad);
                }


                resultado.Result = procesoAuditoriaEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ProcesoAuditoriaService>(e);
            }

            return resultado;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Aplicacion.Adapter.Contractual;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.Core.Message;
using Pe.Stracon.SGC.Aplicacion.Service.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Cross.Core.Exception;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using System.Transactions;
using Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;

namespace Pe.Stracon.SGC.Aplicacion.Service.Contractual
{
    /// <summary>
    /// Servicio que representa las actividades de Flujo Aprobacion
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150507 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class FlujoAprobacionService : GenericService, IFlujoAprobacionService
    {
        #region Propiedades
        /// <summary>
        /// Repositorio de manejo de Flujo Aprobacion Logic
        /// </summary>
        public IFlujoAprobacionLogicRepository flujoAprobacionLogicRepository { get; set; }
        /// <summary>
        /// Repositorio de manejo de Flujo Aprobacion Entity
        /// </summary>
        public IFlujoAprobacionEntityRepository flujoAprobacionEntityRepository { get; set; }

        /// <summary>
        /// Repositorio de manejo de Flujo Aprobacion Tipo de Servicio Entity
        /// </summary>
        public IFlujoAprobacionTipoServicioEntityRepository flujoAprobacionTipoServicioEntityRepository { get; set; }
        
        /// <summary>
        /// Repositorio de manejo de Flujo Aprobacion Tipo de Contrato Entity
        /// </summary>
        public IFlujoAprobacionTipoContratoEntityRepository flujoAprobacionTipoContratoEntityRepository { get; set; }


        /// <summary>
        /// Repositorio de manejo de Flujo Aprobacion Estadio Entity
        /// </summary>
        public IFlujoAprobacionEstadioEntityRepository flujoAprobacionEstadioEntityRepository { get; set; }

        /// <summary>
        /// Servicio de manejo de Unidad Operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary>
        public IPoliticaService politicaService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IFlujoAprobacionParticipanteEntityRepository flujoAprobacionParticipanteEntityRepository { get; set; }

        /// <summary>
        /// Servicio de trabajador
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }

        /// <summary>
        /// Interface para obtener el entorno de la aplicación.
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        #endregion
        /// <summary>
        /// Busca Bandeja Flujo Aprobacion
        /// </summary>
        /// <param name="filtro">Filtro de Flujo de Aprobación</param>
        /// <returns>Registros de flujo aprobacion</returns>
        public ProcessResult<List<FlujoAprobacionResponse>> BuscarBandejaFlujoAprobacion(FlujoAprobacionRequest filtro)
        {
            ProcessResult<List<FlujoAprobacionResponse>> resultado = new ProcessResult<List<FlujoAprobacionResponse>>();

            List<UnidadOperativaResponse> unidadOperativa = null;
            List<CodigoValorResponse> tipoContrato = null;
            List<CodigoValorResponse> formaContrato = null;

            var listaTrabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest()).Result;
            if (filtro.IndicadorObtenerDescripcion)
            {
                unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = "03" }).Result;
                tipoContrato = politicaService.ListarTipoContrato().Result.OrderBy(item => item.Valor.ToString()).ToList();
                formaContrato = politicaService.ListarFormaContrato().Result;
            }
            try
            {
                Guid? CodigoFlujoAprobacion = (filtro.CodigoFlujoAprobacion != null && filtro.CodigoFlujoAprobacion != "") ? new Guid(filtro.CodigoFlujoAprobacion) : (Guid?)null;
                Guid? CodigoUnidadOperativa = (filtro.CodigoUnidadOperativa != null && filtro.CodigoUnidadOperativa != "") ? new Guid(filtro.CodigoUnidadOperativa) : (Guid?)null;

                List<FlujoAprobacionLogic> listado = flujoAprobacionLogicRepository.BuscarBandejaFlujoAprobacion(
                    CodigoFlujoAprobacion,
                    CodigoUnidadOperativa,
                    filtro.IndicadorAplicaMontoMinimo,
                    filtro.EstadoRegistro
                );

                resultado.Result = new List<FlujoAprobacionResponse>();

                //Detalle Flujo Aprobación Tipo de Contrato
                List<FlujoAprobacionTipoContratoLogic> listadoFlujoAprobacionTipoServicio = flujoAprobacionLogicRepository.BuscarFlujoAprobacionTipoContrato(
                    null,
                    null,
                    null,//filtro.ListaTipoServicio == null ? null : filtro.ListaTipoServicio.Count == 1 ? filtro.ListaTipoServicio[0] : null,
                    filtro.EstadoRegistro
                );

                foreach (var registro in listado)
                {
                    var objlistadoFlujoAprobacionTipoServicio = listadoFlujoAprobacionTipoServicio.FindAll(p => p.CodigoFlujoAprobacion == registro.CodigoFlujoAprobacion);

                    if (filtro.ListaTipoServicio != null)
                    {
                        if (!filtro.ListaTipoServicio.Any(itemAny => objlistadoFlujoAprobacionTipoServicio.Any(itemWhere => itemWhere.CodigoTipoContrato == itemAny)))
                        {
                            continue;
                        }
                    }

                    var flujoAprobacion = FlujoAprobacionAdapter.ObtenerFlujoAprobacion(registro, objlistadoFlujoAprobacionTipoServicio, unidadOperativa, tipoContrato);

                    var primerFirmante = listaTrabajador.Find(p => p.CodigoTrabajador == registro.CodigoPrimerFirmante.Value.ToString());
                    if (primerFirmante != null)
                    {
                        flujoAprobacion.NombrePrimerFirmante = primerFirmante.NombreCompleto;
                    }

                    if (registro.CodigoSegundoFirmante != null)
                    {
                        var segundoFirmante = listaTrabajador.Find(p => p.CodigoTrabajador == registro.CodigoSegundoFirmante.Value.ToString());
                        if (segundoFirmante != null)
                        {
                            flujoAprobacion.NombreSegundoFirmante = segundoFirmante.NombreCompleto;
                        }
                    }

                    resultado.Result.Add(flujoAprobacion);
                }

                resultado.Result = (from item in resultado.Result
                                    orderby item.DescripcionUnidadOperativa, item.IndicadorAplicaMontoMinimo, item.DescripcionTipoContrato ascending
                                    select item).ToList();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Busca Bandeja Flujo Aprobacion participante
        /// </summary>
        /// <param name="filtro">filtro</param>
        /// <returns>Registros de flujo aprobacion participante</returns>
        public ProcessResult<List<FlujoAprobacionParticipanteResponse>> BuscarFlujoAprobacionParticipante(FlujoAprobacionRequest filtro)
        {
            ProcessResult<List<FlujoAprobacionParticipanteResponse>> resultado = new ProcessResult<List<FlujoAprobacionParticipanteResponse>>();

            try
            {
                resultado.Result = new List<FlujoAprobacionParticipanteResponse>();
                var lstUOs = flujoAprobacionLogicRepository.BuscarFlujoAprobacionParticipante(new Guid(filtro.CodigoFlujoAprobacion));
                foreach (var item in lstUOs)
                {
                    resultado.Result.Add(FlujoAprobacionParticipanteAdapter.ObtenerFlujoAprobacionParticipanteResponse(item));
                }
            }
            catch (Exception ex)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoService>(ex);
            }
            return resultado;
        }


        /// <summary>
        /// Registra / Edita Flujo Aprobacion
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<FlujoAprobacionRequest> RegistrarFlujoAprobacion(FlujoAprobacionRequest data)
        {
            ProcessResult<FlujoAprobacionRequest> resultado = new ProcessResult<FlujoAprobacionRequest>();
            try
            {
                FlujoAprobacionEntity entidad = FlujoAprobacionAdapter.RegistrarFlujoAprobacion(data);

                //var resultadoRepetido = flujoAprobacionLogicRepository.RepiteFlujoAprobacion(
                //    new Guid(data.CodigoUnidadOperativa),
                //    data.CodigoFormaEdicion,
                //    data.CodigoTipoServicio,
                //    data.CodigoTipoRequerimiento
                //);

                bool existeRepetido = false; //resultadoRepetido.Any(e => e.CodigoFlujoAprobacion != entidad.CodigoFlujoAprobacion);
                if (existeRepetido)
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(MensajesSistema.FlujoAprobacionExiste);
                }
                else
                {
                    if (data.CodigoFlujoAprobacion == null)
                    {
                        flujoAprobacionEntityRepository.Insertar(entidad);
                        flujoAprobacionEntityRepository.GuardarCambios();

                        foreach (var item in data.ListaTipoServicio)
                        {
                            //FlujoAprobacionTipoServicioEntity entidadFlujoAprobacionTipoServicio = new FlujoAprobacionTipoServicioEntity();
                            //entidadFlujoAprobacionTipoServicio.CodigoFlujoAprobacion = entidad.CodigoFlujoAprobacion;
                            //entidadFlujoAprobacionTipoServicio.CodigoFlujoAprobacionTipoServicio = Guid.NewGuid();
                            //entidadFlujoAprobacionTipoServicio.CodigoTipoServicio = item;
                            //flujoAprobacionTipoServicioEntityRepository.Insertar(entidadFlujoAprobacionTipoServicio);
                            //flujoAprobacionTipoServicioEntityRepository.GuardarCambios();

                            FlujoAprobacionTipoContratoEntity entidadFlujoAprobacionTipoContrato = new FlujoAprobacionTipoContratoEntity();
                            entidadFlujoAprobacionTipoContrato.CodigoFlujoAprobacion = entidad.CodigoFlujoAprobacion;
                            entidadFlujoAprobacionTipoContrato.CodigoFlujoAprobacionTipoContrato = Guid.NewGuid();
                            entidadFlujoAprobacionTipoContrato.CodigoTipoContrato = item;
                            flujoAprobacionTipoContratoEntityRepository.Insertar(entidadFlujoAprobacionTipoContrato);
                            flujoAprobacionTipoContratoEntityRepository.GuardarCambios();
                        }

                        var datosDefecto = new FlujoAprobacionEstadioEntity()
                        {
                            CodigoFlujoAprobacionEstadio = Guid.NewGuid(),
                            CodigoFlujoAprobacion = entidad.CodigoFlujoAprobacion,
                            Orden = 1,
                            Descripcion = "Edición",
                            TiempoAtencion = 1,
                            HorasAtencion = 0,
                            IndicadorVersionOficial = false,
                            IndicadorPermiteCarga = false,
                            IndicadorNumeroContrato = false,
                            EstadoRegistro = "1"
                        };

                        flujoAprobacionEstadioEntityRepository.Insertar(datosDefecto);
                        //flujoAprobacionEstadioEntityRepository.GuardarCambios();
                    }
                    else
                    {
                        var entidadSincronizar = flujoAprobacionEntityRepository.GetById(entidad.CodigoFlujoAprobacion);
                        entidadSincronizar.CodigoFlujoAprobacion = entidad.CodigoFlujoAprobacion;
                        entidadSincronizar.CodigoUnidadOperativa = entidad.CodigoUnidadOperativa;
                        entidadSincronizar.CodigoPrimerFirmante = entidad.CodigoPrimerFirmante;
                        entidadSincronizar.CodigoPrimerFirmanteOriginal = entidad.CodigoPrimerFirmante;                     
                        
                        if (entidad.CodigoSegundoFirmante != null)
                        {
                            entidadSincronizar.CodigoSegundoFirmante = entidad.CodigoSegundoFirmante;
                            entidadSincronizar.CodigoSegundoFirmanteOriginal = entidad.CodigoSegundoFirmante;                           
                        }

                        entidadSincronizar.CodigoPrimerFirmanteVinculada = entidad.CodigoPrimerFirmanteVinculada;
                        entidadSincronizar.CodigoSegundoFirmanteVinculada = entidad.CodigoSegundoFirmanteVinculada;

                        //Detalle Flujo Aprobación Tipo de Contrato
                        List<FlujoAprobacionTipoContratoLogic> listadoFlujoAprobacionTipoContrato = flujoAprobacionLogicRepository.BuscarFlujoAprobacionTipoContrato(
                            null,
                            entidad.CodigoFlujoAprobacion,
                            null,
                            null
                        );

                        //Eliminar los tipos de contrato
                        foreach (var item in listadoFlujoAprobacionTipoContrato.Where(item => item.EstadoRegistro == DatosConstantes.EstadoRegistro.Activo).ToList())
                        {
                            flujoAprobacionTipoContratoEntityRepository.Eliminar(item.CodigoFlujoAprobacionTipoContrato);
                            flujoAprobacionTipoContratoEntityRepository.GuardarCambios();
                        }
                        //Editar o registrar tipos de contrato
                        foreach (var item in data.ListaTipoServicio)
                        {
                            FlujoAprobacionTipoContratoEntity entidadFlujoAprobacionTipoContrato = new FlujoAprobacionTipoContratoEntity();
                            var flujoAprobacionTipoContratoEditar = listadoFlujoAprobacionTipoContrato.Where(itemWhere => itemWhere.CodigoTipoContrato == item).FirstOrDefault();

                            if (flujoAprobacionTipoContratoEditar != null)
                            {
                                entidadFlujoAprobacionTipoContrato = flujoAprobacionTipoContratoEntityRepository.GetById(flujoAprobacionTipoContratoEditar.CodigoFlujoAprobacionTipoContrato);
                                entidadFlujoAprobacionTipoContrato.EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;

                                flujoAprobacionTipoContratoEntityRepository.Editar(entidadFlujoAprobacionTipoContrato);
                            }
                            else
                            {
                                entidadFlujoAprobacionTipoContrato.CodigoFlujoAprobacion = entidad.CodigoFlujoAprobacion;
                                entidadFlujoAprobacionTipoContrato.CodigoFlujoAprobacionTipoContrato = Guid.NewGuid();
                                entidadFlujoAprobacionTipoContrato.CodigoTipoContrato = item;
                                flujoAprobacionTipoContratoEntityRepository.Insertar(entidadFlujoAprobacionTipoContrato);
                            }
                            flujoAprobacionTipoServicioEntityRepository.GuardarCambios();
                        }

                        entidadSincronizar.IndicadorAplicaMontoMinimo = entidad.IndicadorAplicaMontoMinimo;
                        entidadSincronizar.EstadoRegistro = entidad.EstadoRegistro;

                        flujoAprobacionEntityRepository.Editar(entidadSincronizar);
                    }

                    flujoAprobacionEstadioEntityRepository.GuardarCambios();
                }

                resultado.Result = data;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Elimina flujo de aprobacion
        /// </summary>
        /// <param name="listaCodigoFlujoAprobacion"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> EliminarFlujoAprobacion(List<Object> listaCodigoFlujoAprobacion)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {

                foreach (var codigo in listaCodigoFlujoAprobacion)
                {
                    var llaveEntidad = new Guid(codigo.ToString());
                    flujoAprobacionEntityRepository.Eliminar(llaveEntidad);
                }


                resultado.Result = flujoAprobacionEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Busca Bandeja Flujo Aprobacion Estadios
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns>Lista Flujo Aprobación Estadio</returns>
        public ProcessResult<List<FlujoAprobacionEstadioResponse>> BuscarBandejaFlujoAprobacionEstadio(string codigoFlujoAprobacionEstadio, string codigoFlujoAprobacion, bool obtenerInformacionRepresentante = false)
        {
            ProcessResult<List<FlujoAprobacionEstadioResponse>> resultado = new ProcessResult<List<FlujoAprobacionEstadioResponse>>();
            TrabajadorRequest trabajador = new TrabajadorRequest();
            try
            {
                Guid? CodigoFlujoAprobacionEstadio = (codigoFlujoAprobacionEstadio != null && codigoFlujoAprobacionEstadio.ToString() != "") ? new Guid(codigoFlujoAprobacionEstadio.ToString()) : (Guid?)null;
                Guid? CodigoFlujoAprobacion = (codigoFlujoAprobacion != null && codigoFlujoAprobacion.ToString() != "") ? new Guid(codigoFlujoAprobacion.ToString()) : (Guid?)null;

                List<FlujoAprobacionEstadioLogic> listado = flujoAprobacionLogicRepository.BuscarBandejaFlujoAprobacionEstadio(
                    CodigoFlujoAprobacionEstadio,
                    CodigoFlujoAprobacion
                );


                int li_indexTrb = -1;
                List<Guid?> lstRepresentantes = new List<Guid?>();
                List<Guid?> lstInformados = new List<Guid?>();
                List<Guid?> lstResponsableVinculadas = new List<Guid?>();

                string[] listaRepresentantes;
                string[] listaInformados;
                string[] listaResponsableVinculadas;

                foreach (var item in listado)
                {
                    if (obtenerInformacionRepresentante)
                    {
                        listaRepresentantes = item.CodigosRepresentante.Split('/');
                        if (item.CodigosRepresentante.Trim().Length > 1)
                        {
                            for (int li = 1; li < listaRepresentantes.Length; li++)
                            {
                                li_indexTrb = lstRepresentantes.FindIndex(x => x.Value.ToString().ToLower() == listaRepresentantes[li].ToLower());
                                if (li_indexTrb == -1)
                                {
                                    lstRepresentantes.Add(Guid.Parse(listaRepresentantes[li]));
                                }
                            }
                        }

                        listaInformados = item.CodigosInformado.Split('/');
                        if (item.CodigosInformado.Trim().Length > 1)
                        {
                            for (int li = 1; li < listaInformados.Length; li++)
                            {
                                li_indexTrb = lstInformados.FindIndex(x => x.Value.ToString().ToLower() == listaInformados[li].ToLower());
                                if (li_indexTrb == -1)
                                {
                                    lstInformados.Add(Guid.Parse(listaInformados[li]));
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(item.CodigosResponsableVinculadas))
                        {
                            listaResponsableVinculadas = item.CodigosResponsableVinculadas.Split('/');

                            for (int li = 1; li < listaResponsableVinculadas.Length; li++)
                            {
                                li_indexTrb = lstResponsableVinculadas.FindIndex(x => x.Value.ToString().ToLower() == listaResponsableVinculadas[li].ToLower());
                                if (li_indexTrb == -1)
                                {
                                    lstResponsableVinculadas.Add(Guid.Parse(listaResponsableVinculadas[li]));
                                }
                            }
                        }
                        
                    }
                }

                List<TrabajadorResponse> listaRepresentante = null;
                List<TrabajadorResponse> listaInformado = null;
                List<TrabajadorResponse> listaResponsablesVinculadas = null;

                if (obtenerInformacionRepresentante)
                {
                    listaRepresentante = trabajadorService.ListarTrabajadores(lstRepresentantes).Result;
                    listaInformado = trabajadorService.ListarTrabajadores(lstInformados).Result;
                    listaResponsablesVinculadas = trabajadorService.ListarTrabajadores(lstResponsableVinculadas).Result;
                }

                resultado.Result = new List<FlujoAprobacionEstadioResponse>();
                foreach (var registro in listado)
                {
                    var flujoAprobacionEstadio = FlujoAprobacionEstadioAdapter.ObtenerFlujoAprobacionEstadio(registro, listaRepresentante, listaInformado, listaResponsablesVinculadas);
                    resultado.Result.Add(flujoAprobacionEstadio);
                }

            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Registra / Edita Flujo Aprobacion Estadios
        /// </summary>
        /// <param name="data">Datos de estadio</param>
        /// <param name="responsable">Responsable de estadio</param>
        /// <param name="informados">Informados de estadio</param>
        /// <param name="responsableVinculadas">Responsable de vinculadas</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<FlujoAprobacionEstadioRequest> RegistrarFlujoAprobacionEstadio(FlujoAprobacionEstadioRequest data, List<FlujoAprobacionEstadioRequest> responsable, List<FlujoAprobacionEstadioRequest> informados, List<FlujoAprobacionEstadioRequest> responsableVinculadas)
        {
            ProcessResult<FlujoAprobacionEstadioRequest> resultado = new ProcessResult<FlujoAprobacionEstadioRequest>();
            string flagRegistrar = "I";
            try
            {

                string codigoResponsable = "";
                FlujoAprobacionEstadioEntity entidad = FlujoAprobacionEstadioAdapter.RegistrarFlujoAprobacionEstadio(data);

                var resultadoRepetidoOrden = flujoAprobacionLogicRepository.RepiteFlujoAprobacionEstadioOrden(
                    new Guid(data.CodigoFlujoAprobacion),
                    data.Orden
                );
                bool existeRepetidoOrden = resultadoRepetidoOrden.Any(e => e.CodigoFlujoAprobacionEstadio != entidad.CodigoFlujoAprobacionEstadio);
                var numeroOrden = resultadoRepetidoOrden.Select(e => e.Orden);


                var resultadoRepetidoDescripcion = flujoAprobacionLogicRepository.RepiteFlujoAprobacionEstadioDescripcion(
                    new Guid(data.CodigoFlujoAprobacion),
                    data.Descripcion
                );
                bool existeRepetidoDescripcion = resultadoRepetidoDescripcion.Any(e => e.CodigoFlujoAprobacionEstadio != entidad.CodigoFlujoAprobacionEstadio);


                if (data.IndicadorVersionOficial)
                {
                    flujoAprobacionEstadioEntityRepository.ActualizaIndicadorVersionOficial(
                        entidad.CodigoFlujoAprobacion
                    );
                }

                if (data.IndicadorNumeroContrato)
                {
                    flujoAprobacionEstadioEntityRepository.ActualizaIndicadorNumeroContrato(
                        entidad.CodigoFlujoAprobacion
                    );
                }


                if (existeRepetidoDescripcion)
                {
                    resultado.IsSuccess = false;
                    resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(MensajesSistema.FlujoAprobacionEstadioDescripcionExiste);
                    return resultado;
                }

                if (data.CodigoFlujoAprobacionEstadio == null)
                {
                    if (numeroOrden.FirstOrDefault() == 1)
                    {
                        resultado.IsSuccess = false;
                        resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(MensajesSistema.FlujoAprobacionOrdenIgualUno);
                        return resultado;
                    }

                    flujoAprobacionEstadioEntityRepository.DesplazarOrden(
                        entidad,
                        flagRegistrar
                    );

                    flujoAprobacionEstadioEntityRepository.Insertar(entidad);
                }
                else
                {
                    if (numeroOrden.FirstOrDefault() >= 1)
                    {
                        flagRegistrar = "U";
                        flujoAprobacionEstadioEntityRepository.DesplazarOrden(
                            entidad,
                            flagRegistrar
                        );
                        var entidadSincronizar = flujoAprobacionEstadioEntityRepository.GetById(entidad.CodigoFlujoAprobacionEstadio);
                        entidadSincronizar.CodigoFlujoAprobacion = entidad.CodigoFlujoAprobacion;
                        entidadSincronizar.Orden = entidad.Orden;
                        entidadSincronizar.Descripcion = entidad.Descripcion;
                        entidadSincronizar.TiempoAtencion = entidad.TiempoAtencion;
                        entidadSincronizar.HorasAtencion = entidad.HorasAtencion;
                        entidadSincronizar.IndicadorNumeroContrato = entidad.IndicadorNumeroContrato;
                        entidadSincronizar.IndicadorPermiteCarga = entidad.IndicadorPermiteCarga;
                        entidadSincronizar.IndicadorVersionOficial = entidad.IndicadorVersionOficial;
                        entidadSincronizar.EstadoRegistro = entidad.EstadoRegistro;
                        entidadSincronizar.IndicadorIncluirVisto = entidad.IndicadorIncluirVisto;
                        flujoAprobacionEstadioEntityRepository.Editar(entidadSincronizar);
                    }
                    if (existeRepetidoOrden)
                    {
                        resultado.IsSuccess = false;
                        resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(MensajesSistema.FlujoAprobacionOrdenIgualUno);
                        return resultado;
                    }
                }

                flujoAprobacionLogicRepository.EliminaParticipante(
                        entidad.CodigoFlujoAprobacionEstadio
                );

                //Registrar Participante Responsable (R)
                if (responsable.Count > 0)
                {
                    foreach (var item in responsable)
                    {
                        codigoResponsable = item.Responsable;
                    }

                    this.RegistrarFlujoAprobacionParticipante(new FlujoAprobacionParticipanteRequest()
                    {
                        CodigoFlujoAprobacionEstadio = entidad.CodigoFlujoAprobacionEstadio.ToString(),
                        CodigoTrabajador = codigoResponsable,
                        CodigoTipoParticipante = DatosConstantes.FlujoAprobacionTipoParticipante.Responsable

                    });
                }

                //Registrar Participante Informador (I)
                if (informados.Count > 0)
                {
                    foreach (var item in informados)
                    {
                        this.RegistrarFlujoAprobacionParticipante(new FlujoAprobacionParticipanteRequest()
                        {
                            CodigoFlujoAprobacionEstadio = entidad.CodigoFlujoAprobacionEstadio.ToString(),
                            CodigoTrabajador = item.Informados,
                            CodigoTipoParticipante = DatosConstantes.FlujoAprobacionTipoParticipante.Informado
                        });
                    }
                }

                //Registrar Participante Responsable de Vinculadas (V)
                if (responsableVinculadas != null)
                {
                    foreach (var item in responsableVinculadas)
                    {
                        this.RegistrarFlujoAprobacionParticipante(new FlujoAprobacionParticipanteRequest()
                        {
                            CodigoFlujoAprobacionEstadio = entidad.CodigoFlujoAprobacionEstadio.ToString(),
                            CodigoTrabajador = item.Responsable,
                            CodigoTipoParticipante = DatosConstantes.FlujoAprobacionTipoParticipante.ResponsableVinculadas
                        });
                    }
                }

                flujoAprobacionEstadioEntityRepository.GuardarCambios();

                resultado.Result = data;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(e);
            }
            return resultado;
        }
        /// <summary>
        /// Eliminar Flujo AprobacionEstadio
        /// </summary>
        /// <param name="listaCodigoFlujoAprobacionEstadio"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> EliminarFlujoAprobacionEstadio(List<Object> listaCodigoFlujoAprobacionEstadio)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                var flagRegistrar = "D";
                foreach (var codigo in listaCodigoFlujoAprobacionEstadio)
                {
                    var llaveEntidad = new Guid(codigo.ToString());

                    flujoAprobacionEstadioEntityRepository.DesplazarOrden(
                        new FlujoAprobacionEstadioEntity()
                        {
                            CodigoFlujoAprobacionEstadio = llaveEntidad
                        },
                        flagRegistrar
                    );
                    flujoAprobacionEstadioEntityRepository.Eliminar(llaveEntidad);
                }
                //EliminarFlujoAprobacionParticipante(listaCodigoFlujoAprobacionEstadio);
                var OrdenContinua = new Guid(listaCodigoFlujoAprobacionEstadio.FirstOrDefault().ToString());
                var totalEliminar = listaCodigoFlujoAprobacionEstadio.Count();


                resultado.Result = flujoAprobacionEstadioEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Registra / Edita Flujo Aprobacion Participante
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<FlujoAprobacionParticipanteRequest> RegistrarFlujoAprobacionParticipante(FlujoAprobacionParticipanteRequest data)
        {
            ProcessResult<FlujoAprobacionParticipanteRequest> resultado = new ProcessResult<FlujoAprobacionParticipanteRequest>();

            try
            {
                FlujoAprobacionParticipanteEntity entidad = FlujoAprobacionParticipanteAdapter.RegistrarFlujoAprobacionParticipante(data);

                flujoAprobacionParticipanteEntityRepository.Insertar(entidad);
                flujoAprobacionParticipanteEntityRepository.GuardarCambios();

                resultado.Result = data;
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(e);
            }
            return resultado;
        }

        /// <summary>
        /// Eliminar Flujo Aprobacion Participante
        /// </summary>
        /// <param name="listaCodigoFlujoAprobacionEstadio"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<Object> EliminarFlujoAprobacionParticipante(List<Object> listaCodigoFlujoAprobacionEstadio)
        {
            ProcessResult<Object> resultado = new ProcessResult<Object>();
            try
            {
                foreach (var codigo in listaCodigoFlujoAprobacionEstadio)
                {
                    var llaveEntidad = new Guid(codigo.ToString());
                    flujoAprobacionParticipanteEntityRepository.Eliminar(llaveEntidad);
                }
                resultado.Result = flujoAprobacionParticipanteEntityRepository.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(e);
            }

            return resultado;
        }

        ///// <summary>
        ///// Copia Estadio
        ///// </summary>
        ///// <param name="data">Datos a Copiar</param>
        ///// <returns>Indicador con el resultado de la operación</returns>
        //public ProcessResult<List<FlujoAprobacionEstadioResponse>> CopiarEstadio(FlujoAprobacionRequest data)
        //{
        //    ProcessResult<List<FlujoAprobacionEstadioResponse>> resultado = new ProcessResult<List<FlujoAprobacionEstadioResponse>>();

        //    try
        //    {
        //        var resultadoAcopiarEncontrado = flujoAprobacionLogicRepository.RepiteFlujoAprobacion(
        //            new Guid(data.CodigoUnidadOperativa),
        //            null,
        //            data.CodigoTipoContrato
        //        );

        //        bool existeEncontrado = resultadoAcopiarEncontrado.Any(e => e.CodigoFlujoAprobacion != new Guid(data.CodigoFlujoAprobacion));
        //        bool esIgual = resultadoAcopiarEncontrado.Any(e => e.CodigoFlujoAprobacion == new Guid(data.CodigoFlujoAprobacion));

        //        if (!existeEncontrado)
        //        {
        //            if (esIgual)
        //            {
        //                resultado.IsSuccess = false;
        //                resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(MensajesSistema.CopiarEstadioIgual);
        //            }
        //            else
        //            {
        //                resultado.IsSuccess = false;
        //                resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(MensajesSistema.CopiarEstadioNoExiste);
        //            }
        //        }
        //        else
        //        {

        //            var codigoFlujoAprobacionHasta = data.CodigoFlujoAprobacion;
        //            var codigoFlujoAprobacionADesde = resultadoAcopiarEncontrado.Select(e => e.CodigoFlujoAprobacion).FirstOrDefault().ToString();
        //            var resultadoCopiarEstadio = BuscarBandejaFlujoAprobacionEstadio(null, codigoFlujoAprobacionADesde);

        //            if (resultadoCopiarEstadio.Result.Count == 0)
        //            {
        //                resultado.IsSuccess = false;
        //                resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(MensajesSistema.CopiarEstadioNoTiene);
        //            }
        //            else
        //            {

        //                flujoAprobacionLogicRepository.CopiarEstadio(
        //                    new Guid(codigoFlujoAprobacionHasta),
        //                    new Guid(codigoFlujoAprobacionADesde),
        //                    entornoActualAplicacion.UsuarioSession,
        //                    entornoActualAplicacion.Terminal
        //               );

        //            }

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        resultado.IsSuccess = false;
        //        resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(e);
        //    }

        //    return resultado;
        //}

        /// <summary>
        /// Busca Estadios de Flujo de Aprobación de Estadio
        /// </summary>
        /// <param name="filtro">Filtro de Flujo de Aprobación</param>
        /// <returns>Lista de Estadios de Flujo de Aprobación</returns>
        public ProcessResult<List<FlujoAprobacionEstadioResponse>> BuscarFlujoAprobacionEstadioDescripcion(FlujoAprobacionEstadioRequest filtro)
        {
            ProcessResult<List<FlujoAprobacionEstadioResponse>> resultado = new ProcessResult<List<FlujoAprobacionEstadioResponse>>();

            try
            {
                List<FlujoAprobacionEstadioLogic> listado = flujoAprobacionLogicRepository.BuscarFlujoAprobacionEstadioDescripcion(
                    filtro.Descripcion,
                    DatosConstantes.EstadoRegistro.Activo
                );

                resultado.Result = new List<FlujoAprobacionEstadioResponse>();

                foreach (var registro in listado)
                {
                    var flujoAprobacion = FlujoAprobacionEstadioAdapter.ObtenerFlujoAprobacionEstadioDescripcion(registro);
                    resultado.Result.Add(flujoAprobacion);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<FlujoAprobacionService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Actualiza el reemplazo al trabajador original
        /// </summary>
        /// <param name="codigoTrabajador">Codigo de trabajador</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        public ProcessResult<string> ActualizarTrabajadorOriginalFlujo(Guid codigoTrabajador)
        {
            ProcessResult<string> resultado = new ProcessResult<string>();
            try
            {
                flujoAprobacionLogicRepository.ActualizarTrabajadorOriginalFlujo(codigoTrabajador);

                resultado.Result = "1";
            }
            catch (Exception e)
            {
                throw e;
            }

            return resultado;
        }
    }
}

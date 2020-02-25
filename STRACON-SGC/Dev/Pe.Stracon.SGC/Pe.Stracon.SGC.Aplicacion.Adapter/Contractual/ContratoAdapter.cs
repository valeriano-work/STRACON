using System;
using System.Collections.Generic;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementacion del adaptador de Contrato
    /// </summary>
    public sealed class ContratoAdapter
    {
        /// <summary>
        /// Obtiene la entidad ContratoResponse de la Entidad Logica ContratoLogic
        /// </summary>
        /// <param name="contrato">Entidad Logic</param>
        /// <param name="listaUnidadOperativa">Lista de Unidades Operativas</param>
        /// <param name="lstTipoRequerimiento">Lista de Tipo de Contrato</param>
        /// <param name="lstTipoServicio">Lista de Tipos de Servicio</param>
        /// <param name="lstEstadoEdicion"></param>
        /// <param name="lstTipoDocumento"></param>
        /// <returns>Entidad logica contratologic</returns>
        public static ContratoResponse ObtenerContratoResponseDeLogic(ContratoLogic contrato,
                                        List<UnidadOperativaResponse> listaUnidadOperativa = null,
                                        List<CodigoValorResponse> lstTipoRequerimiento = null,
                                        List<CodigoValorResponse> lstTipoServicio = null,
                                        List<CodigoValorResponse> lstEstadoEdicion = null,
                                        List<CodigoValorResponse> lstTipoDocumento = null)
        {
            ContratoResponse response = new ContratoResponse();
            response.CodigoContrato = contrato.CodigoContrato;
            response.CodigoUnidadOperativa = contrato.CodigoUnidadOperativa;
            response.CodigoProveedor = contrato.CodigoProveedor;
            response.NombreProveedor = contrato.NombreProveedor;
            response.NumeroContrato = contrato.NumeroContrato;
            response.Descripcion = contrato.Descripcion;
            response.CodigoTipoServicio = contrato.CodigoTipoServicio;
            response.CodigoFlujoAprobacion = contrato.CodigoFlujoAprobacion;
            response.CodigoTipoDocumento = contrato.CodigoTipoDocumento;
            response.FechaInicioVigencia = contrato.FechaInicioVigencia;
            response.FechaFinVigencia = contrato.FechaFinVigencia;
            response.CodigoMoneda = contrato.CodigoMoneda;
            response.MontoContrato = contrato.MontoContrato;
            response.MontoAcumulado = contrato.MontoAcumulado;
            response.CodigoEstado = contrato.CodigoEstado;
            response.CodigoPlantilla = contrato.CodigoPlantilla;
            response.CodigoContratoPrincipal = contrato.CodigoContratoPrincipal;
            response.CodigoEstadoEdicion = contrato.CodigoEstadoEdicion;
            response.ComentarioModificacion = contrato.ComentarioModificacion;
            response.RespuestaModificacion = contrato.RespuestaModificacion;
            response.IndicadorPermiteCarga = contrato.IndicadorPermiteCarga;
            response.CodigoEstadioActual = contrato.CodigoEstadioActual;
            response.NombreEstadioActual = contrato.DescripcionEstadioActual;
            response.DiasPendiente = contrato.DiasPendiente;
            response.CodigoContratoEstadio = contrato.CodigoContratoEstadio;
            response.EstadioPropioConsulta = contrato.EstadioPropioConsulta;
            response.DescripcionContrato = contrato.DescripcionContrato;
            response.CodigoFlujoAprobacionEstadio = contrato.CodigoFlujoAprobacionEstadio;
            response.FechaIngreso = contrato.FechaIngreso == null ? "" : ((DateTime?)contrato.FechaIngreso).Value.ToString(DatosConstantes.Formato.FormatoFecha);
            response.FechaUltimaNotificacion = contrato.FechaUltimaNotificacion == null ? "" : ((DateTime?)contrato.FechaUltimaNotificacion).Value.ToString(DatosConstantes.Formato.FormatoFecha);

            listaUnidadOperativa = listaUnidadOperativa ?? new List<UnidadOperativaResponse>();
            var unidadOperativa = listaUnidadOperativa.Where(item => item.CodigoUnidadOperativa == contrato.CodigoUnidadOperativa).FirstOrDefault();

            if (unidadOperativa != null)
            {
                response.NombreUnidadOperativa = unidadOperativa.Nombre;
            }

            lstTipoRequerimiento = lstTipoRequerimiento ?? new List<CodigoValorResponse>();
            var tipoRequerimiento = lstTipoRequerimiento.Where(item => Convert.ToString(item.Codigo) == contrato.CodigoTipoServicio).FirstOrDefault();

            if (tipoRequerimiento != null)
            {
                response.NombreTipoServicio = Convert.ToString(tipoRequerimiento.Valor);
            }

            lstTipoServicio = lstTipoServicio ?? new List<CodigoValorResponse>();
            var tipoServicio = lstTipoServicio.Where(item => Convert.ToString(item.Codigo) == contrato.CodigoTipoRequerimiento).FirstOrDefault();

            if (tipoServicio != null)
            {
                response.NombreTipoRequerimiento = Convert.ToString(tipoServicio.Valor);
            }

            lstEstadoEdicion = lstEstadoEdicion ?? new List<CodigoValorResponse>();
            var estadoEdicion = lstEstadoEdicion.Where(item => Convert.ToString(item.Codigo) == contrato.CodigoEstadoEdicion).FirstOrDefault();

            if (estadoEdicion != null)
            {
                response.NombreEstadoEdicion = Convert.ToString(estadoEdicion.Valor);
            }

            lstTipoDocumento = lstTipoDocumento ?? new List<CodigoValorResponse>();
            var tipoDocumento = lstTipoDocumento.Where(item => Convert.ToString(item.Codigo) == contrato.CodigoTipoDocumento).FirstOrDefault();

            if (tipoDocumento != null)
            {
                response.NombreTipoDocumento = Convert.ToString(tipoDocumento.Valor);
            }

            response.FechaModificacion = contrato.FechaModificacion == null ? string.Empty : contrato.FechaModificacion.Value.ToString(DatosConstantes.Formato.FormatoFecha);
            response.UsuarioCreacion = contrato.UsuarioCreacion;

            response.FilasTotal = contrato.TotalRegistro;
            response.NumeroFila = contrato.NumeroRegistro;
            return response;
        }

        /// <summary>
        /// Obtiene la entidad ContratoEstadioObservacionResponse de la Entidad Logica ContratoEstadioObservacionLogic
        /// </summary>
        /// <param name="objLogic">Objeto logic ContratoEstadioObservacionLogic</param>
        /// <param name="lstTrbajador">Listado de trabajadores</param>
        /// <param name="lstTipoRespuesta"></param>
        /// <returns>Entidad Logica de Contrato Estadio Observación Logic</returns>
        public static ContratoEstadioObservacionResponse ObtenerContratoEstadioResponseDeLogic(ContratoEstadioObservacionLogic objLogic,
                                        List<TrabajadorResponse> lstTrbajador = null,
                                        List<CodigoValorResponse> lstTipoRespuesta = null)
        {
            ContratoEstadioObservacionResponse rpta = new ContratoEstadioObservacionResponse();
            int li_index = -1;
            rpta.CodigoContratoEstadioObservacion = objLogic.CodigoContratoEstadioObservacion;
            rpta.CodigoContratoEstadio = objLogic.CodigoContratoEstadio;
            rpta.Descripcion = objLogic.Descripcion;
            rpta.FechaRegistro = objLogic.FechaRegistro == null ? "" : ((DateTime?)objLogic.FechaRegistro).Value.ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.CodigoContratoParrafo = objLogic.CodigoContratoParrafo;
            rpta.CodigoEstadioRetorno = objLogic.CodigoEstadioRetorno;
            rpta.Destinatario = objLogic.Destinatario;
            rpta.CodigoTipoRespuesta = objLogic.CodigoTipoRespuesta;
            rpta.Respuesta = objLogic.Respuesta;
            rpta.FechaRespuesta = objLogic.FechaRespuesta == null ? "" : ((DateTime?)objLogic.FechaRespuesta).Value.ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.Observador = objLogic.Observador;
            rpta.CodigoArchivo = objLogic.CodigoArchivo;
            rpta.RutaArchivoSharepoint = objLogic.RutaArchivoSharepoint;

            if (lstTrbajador != null && lstTrbajador.Count > 0)
            {
                if (objLogic.Destinatario != null)
                {
                    li_index = lstTrbajador.FindIndex(x => x.CodigoTrabajador.ToString().ToLower() == objLogic.Destinatario.ToString().ToLower());
                    if (li_index > -1)
                    {
                        rpta.NombreDestinatario = lstTrbajador[li_index].NombreCompleto;
                    }
                    else
                    {
                        rpta.NombreDestinatario = string.Empty;
                    }
                }
                else
                {
                    rpta.NombreDestinatario = string.Empty;
                }
                li_index = -1;
                if (objLogic.Observador != null)
                {
                    li_index = lstTrbajador.FindIndex(x => x.CodigoTrabajador.ToString().ToLower() == objLogic.Observador.ToString().ToLower());
                    if (li_index > -1)
                    {
                        rpta.NombreObservador = lstTrbajador[li_index].NombreCompleto;
                    }
                    else
                    {
                        rpta.NombreObservador = string.Empty;
                    }
                }
                else
                {
                    rpta.NombreObservador = string.Empty;
                }
            }
            else
            {
                rpta.NombreDestinatario = "";
                rpta.NombreObservador = "";
            }
            li_index = -1;
            if (lstTipoRespuesta != null && lstTipoRespuesta.Count > 0)
            {
                if (objLogic.CodigoTipoRespuesta != null)
                {
                    li_index = lstTipoRespuesta.FindIndex(x => x.Codigo.ToString() == objLogic.CodigoTipoRespuesta);
                    if (li_index > -1)
                    {
                        rpta.NombreTipoRespuesta = lstTipoRespuesta[li_index].Valor.ToString();
                    }
                    else
                    {
                        rpta.NombreTipoRespuesta = string.Empty;
                    }
                }
                else
                {
                    rpta.NombreTipoRespuesta = string.Empty;
                }
            }

            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad ContratoEstadioConsultaResponse de la Entidad Logica ContratoEstadioObservacionLogic
        /// </summary>
        /// <param name="objLogic">Objeto logic ContratoEstadioConsultaLogic</param>
        /// <param name="lstTrbajador">Listado de trabajadores</param>
        /// <returns>Entidad Logica de Contrato estadio observación logic</returns>
        public static ContratoEstadioConsultaResponse ObtenerContratoEstadioResponseDeLogic(ContratoEstadioConsultaLogic objLogic,
                                        List<TrabajadorResponse> lstTrbajador = null)
        {
            ContratoEstadioConsultaResponse rpta = new ContratoEstadioConsultaResponse();
            int li_index = -1;
            rpta.CodigoContratoEstadioConsulta = objLogic.CodigoContratoEstadioConsulta;
            rpta.CodigoContratoEstadio = objLogic.CodigoContratoEstadio;
            rpta.Descripcion = objLogic.Descripcion;
            rpta.FechaConsulta = objLogic.FechaRegistro.ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.CodigoContratoParrafo = objLogic.CodigoContratoParrafo;
            rpta.Destinatario = objLogic.Destinatario;
            rpta.Respuesta = objLogic.Respuesta;
            rpta.FechaRespuesta = objLogic.FechaRespuesta == null ? "" : ((DateTime)objLogic.FechaRespuesta).ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.Consultor = Guid.Parse(objLogic.Consultor);
            rpta.CodigoContrato = objLogic.CodigoContrato;

            if (lstTrbajador != null && lstTrbajador.Count > 0)
            {
                li_index = lstTrbajador.FindIndex(x => x.CodigoTrabajador.ToLower() == objLogic.Destinatario.ToString().ToLower());
                if (li_index > -1)
                {
                    rpta.NombreDestinatario = lstTrbajador[li_index].NombreCompleto;
                }
                else
                {
                    rpta.NombreDestinatario = string.Empty;
                }
                li_index = -1;
                li_index = lstTrbajador.FindIndex(x => x.CodigoTrabajador.ToLower() == objLogic.Consultor.ToString().ToLower());
                if (li_index > -1)
                {
                    rpta.NombreConsultor = lstTrbajador[li_index].NombreCompleto;
                }
                else
                {
                    rpta.NombreConsultor = string.Empty;
                }
            }
            else
            {
                rpta.NombreDestinatario = "";
                rpta.NombreConsultor = "";
            }
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad ContratoEstadioObservacionEntity de la Entidad ContratoEstadioObservacionRequest
        /// </summary>
        /// <param name="objRqst">Entidad ContratoEstadioObservacion</param>
        /// <returns>Entidad de Contrato Estadio Observacion Request</returns>
        public static ContratoEstadioObservacionEntity ObtenerContratoEstadioObservacionEntityDeRequest(ContratoEstadioObservacionRequest objRqst)
        {
            ContratoEstadioObservacionEntity rpta = new ContratoEstadioObservacionEntity();
            rpta.CodigoContratoEstadioObservacion = objRqst.CodigoContratoEstadioObservacion == null ? Guid.Empty : (Guid)objRqst.CodigoContratoEstadioObservacion;
            rpta.CodigoContratoEstadio = objRqst.CodigoContratoEstadio;
            rpta.Descripcion = objRqst.Descripcion;
            rpta.FechaRegistro = objRqst.FechaRegistro;
            rpta.CodigoContratoParrafo = objRqst.CodigoContratoParrafo;
            rpta.CodigoEstadioRetorno = objRqst.CodigoEstadioRetorno;
            rpta.Destinatario = objRqst.Destinatario;
            rpta.CodigoTipoRespuesta = objRqst.CodigoTipoRespuesta;
            rpta.Respuesta = objRqst.Respuesta;
            rpta.FechaRespuesta = objRqst.FechaRespuesta;
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad ContratoEstadioObservacionEntity de la Entidad ContratoEstadioObservacionRequest
        /// </summary>
        /// <param name="objRqst">Entidad ContratoEstadioObservacion</param>
        /// <returns>Entidad Contrato Estadio Observación request</returns>
        public static ContratoEstadioConsultaEntity ObtenerContratoEstadioConsultEntityDeRequest(ContratoEstadioConsultaRequest objRqst)
        {
            ContratoEstadioConsultaEntity rpta = new ContratoEstadioConsultaEntity();
            rpta.CodigoContratoEstadioConsulta = objRqst.CodigoContratoEstadioConsulta == null ? Guid.Empty : (Guid)objRqst.CodigoContratoEstadioConsulta;
            rpta.CodigoContratoEstadio = objRqst.CodigoContratoEstadio;
            rpta.Descripcion = objRqst.Descripcion;
            rpta.FechaRegistro = objRqst.FechaRegistro;
            rpta.CodigoContratoParrafo = objRqst.CodigoContratoParrafo;
            rpta.Destinatario = objRqst.Destinatario;
            rpta.Respuesta = objRqst.Respuesta;
            rpta.FechaRespuesta = objRqst.FechaRespuesta;
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad ContratoEstadioObservacionResponse de la Entidad ContratoEstadioObservacionLogic
        /// </summary>
        /// <param name="objEnt">Objeto entidad ContratoEstadioObservacionEntity</param>
        /// <returns>Entidad Contrato estadio observación Logic</returns>
        public static ContratoEstadioObservacionResponse ObtenerContratoEstadioObservacionResponseDeEntity(ContratoEstadioObservacionEntity objEnt)
        {
            ContratoEstadioObservacionResponse rpta = new ContratoEstadioObservacionResponse();
            rpta.CodigoContratoEstadioObservacion = objEnt.CodigoContratoEstadioObservacion;
            rpta.CodigoContratoEstadio = objEnt.CodigoContratoEstadio;
            rpta.Descripcion = objEnt.Descripcion;
            rpta.FechaRegistro = objEnt.FechaRegistro == null ? "" : ((DateTime)objEnt.FechaRegistro).ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.CodigoContratoParrafo = objEnt.CodigoContratoParrafo;
            rpta.CodigoEstadioRetorno = objEnt.CodigoEstadioRetorno;
            rpta.Destinatario = objEnt.Destinatario;
            rpta.CodigoTipoRespuesta = objEnt.CodigoTipoRespuesta;
            rpta.Respuesta = objEnt.Respuesta;
            rpta.CodigoArchivo = objEnt.CodigoArchivo;
            rpta.RutaArchivoSharepoint = objEnt.RutaArchivoSharepoint;
            rpta.FechaRespuesta = objEnt.FechaRespuesta == null ? "" : ((DateTime)objEnt.FechaRespuesta).ToString(DatosConstantes.Formato.FormatoFecha);
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad ContratoEstadioConsultaResponse de la Entidad ContratoEstadioEntityLogic
        /// </summary>
        /// <param name="objEnt">Objeto entidad ContratoEstadioConsultaEntity</param>
        /// <returns>Entidad Contrato estadio </returns>
        public static ContratoEstadioConsultaResponse ObtenerContratoEstadioConsultaResponseDeEntity(ContratoEstadioConsultaEntity objEnt)
        {
            ContratoEstadioConsultaResponse rpta = new ContratoEstadioConsultaResponse();
            rpta.CodigoContratoEstadioConsulta = objEnt.CodigoContratoEstadioConsulta;
            rpta.CodigoContratoEstadio = objEnt.CodigoContratoEstadio;
            rpta.Descripcion = objEnt.Descripcion;
            rpta.FechaConsulta = objEnt.FechaRegistro.ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.CodigoContratoParrafo = objEnt.CodigoContratoParrafo;
            rpta.Destinatario = objEnt.Destinatario;
            rpta.Respuesta = objEnt.Respuesta;
            rpta.FechaRespuesta = objEnt.FechaRespuesta == null ? "" : ((DateTime?)objEnt.FechaRespuesta).Value.ToString(DatosConstantes.Formato.FormatoFecha);
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad ContratoEstadioEntity de la Entidad ContratoEstadioRequest
        /// </summary>
        /// <param name="objRqst">Objeto request ContratoEstadioRequest</param>
        /// <returns>Entidad Contrato Estadio</returns>
        public static ContratoEstadioEntity ObtenerContratoEstadioEntityDeRequest(ContratoEstadioRequest objRqst)
        {
            ContratoEstadioEntity rpta = new ContratoEstadioEntity();
            rpta.CodigoContratoEstadio = objRqst.CodigoContratoEstadio == null ? Guid.Empty : (Guid)objRqst.CodigoContratoEstadio;
            rpta.CodigoContrato = objRqst.CodigoContrato == null ? Guid.Empty : (Guid)objRqst.CodigoContrato;
            rpta.CodigoFlujoAprobacionEstadio = objRqst.CodigoFlujoAprobacionEstadio == null ? Guid.Empty : (Guid)objRqst.CodigoFlujoAprobacionEstadio;
            rpta.FechaIngreso = objRqst.FechaIngreso;
            rpta.FechaFinalizacion = objRqst.FechaFinalizacion;
            rpta.CodigoResponsable = objRqst.CodigoResponsable;
            rpta.CodigoEstadoContratoEstadio = objRqst.CodigoEstadoContratoEstadio;
            rpta.FechaPrimeraNotificacion = objRqst.FechaPrimeraNotificacion;
            rpta.FechaUltimaNotificacion = objRqst.FechaUltimaNotificacion;
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad ContratoParrafoResponse de la Entidad ContratoParrafoLogic
        /// </summary>
        /// <param name="objLogic">Objeto logic de ContratoParrafoLogic</param>
        /// <returns>Objeto Response Contrato Parrafo</returns>
        public static ContratoParrafoResponse ObtenerContratoParrafoResponseDeLogic(ContratoParrafoLogic objLogic)
        {
            ContratoParrafoResponse rpta = new ContratoParrafoResponse();
            rpta.CodigoContrato = objLogic.CodigoContrato;
            rpta.CodigoContratoParrafo = objLogic.CodigoContratoParrafo;
            rpta.CodigoPlantillaParrafo = objLogic.CodigoPlantillaParrafo;
            rpta.Titulo = objLogic.Titulo;
            rpta.Contenido = objLogic.Contenido;
            rpta.Orden = objLogic.Orden;
            return rpta;
        }
        /// <summary>
        /// Obtiene la entidad FlujoAprobacionEstadioResponse de la Entidad FlujoAprobacionEstadioLogic
        /// </summary>
        /// <param name="objLogic">objeto logic de Flujo Aprobación Estadio</param>
        /// <param name="lstTrbajador">lista de trabajadores</param>
        /// <returns>Entidad Flujo Aprobacion Estadio</returns>
        public static FlujoAprobacionEstadioResponse ObtenerFlujoAprobacionEstadioResponseDeLogic(FlujoAprobacionEstadioLogic objLogic,
                       List<TrabajadorResponse> lstTrbajador = null)
        {
            int li_index = -1;
            
            FlujoAprobacionEstadioResponse rpta = new FlujoAprobacionEstadioResponse();
            rpta.CodigoFlujoAprobacionEstadio = objLogic.CodigoFlujoAprobacionEstadio.ToString();
            rpta.CodigoFlujoAprobacion = objLogic.CodigoFlujoAprobacion.ToString();
            rpta.Orden = objLogic.Orden;
            rpta.Descripcion = objLogic.Descripcion;
            rpta.CodigoResponsable = objLogic.CodigoResponsable;
            rpta.CorreoElectronico = objLogic.CorreoElectronico;
            if (lstTrbajador != null && lstTrbajador.Count > 0)
            {
                li_index = lstTrbajador.FindIndex(x => x.CodigoTrabajador.ToUpper().ToString() == objLogic.CodigoResponsable.ToUpper());
                if (li_index > -1)
                {
                    rpta.NombreRepresentante = lstTrbajador[li_index].NombreCompleto;
                }
                else
                {
                    rpta.NombreRepresentante = string.Empty;
                }
            }
            else
            {
                rpta.NombreRepresentante = string.Empty;
            }
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad response ContratoResponse de la Entidad ContratoEntity
        /// </summary>
        /// <param name="objEnt"></param>
        /// <param name="objProv"></param>
        /// <returns>Entidad Contrato</returns>            
        public static ContratoResponse ObtenerContratoResponseDeEntity(ContratoEntity objEnt, ProveedorEntity objProv = null)
        {
            ContratoResponse rpta = new ContratoResponse();
            rpta.CodigoContrato = objEnt.CodigoContrato;
            rpta.CodigoUnidadOperativa = objEnt.CodigoUnidadOperativa;
            rpta.CodigoProveedor = objEnt.CodigoProveedor;
            if (objProv != null)
                rpta.NombreProveedor = objProv.Nombre;
            rpta.NumeroContrato = (objEnt.NumeroContrato != null) ? objEnt.NumeroContrato : "";
            rpta.Descripcion = objEnt.Descripcion;
            rpta.CodigoTipoServicio = objEnt.CodigoTipoServicio;
            rpta.CodigoTipoRequerimiento = objEnt.CodigoTipoRequerimiento;
            rpta.CodigoTipoDocumento = objEnt.CodigoTipoDocumento;
            
            rpta.IndicadorVersionOficial = objEnt.IndicadorVersionOficial;
            rpta.FechaInicioVigencia = objEnt.FechaInicioVigencia;
            rpta.FechaFinVigencia = objEnt.FechaFinVigencia;
            rpta.FechaInicioVigenciaString = objEnt.FechaInicioVigencia.ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.FechaFinVigenciaString = objEnt.FechaFinVigencia.ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.CodigoMoneda = objEnt.CodigoMoneda;
            rpta.MontoContrato = objEnt.MontoContrato;
            rpta.MontoContratoString    = rpta.MontoContrato.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            rpta.MontoAcumulado         = objEnt.MontoAcumulado;
            rpta.MontoAcumuladoString   = rpta.MontoAcumulado.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            rpta.CodigoEstado = objEnt.CodigoEstado;
            rpta.CodigoPlantilla = objEnt.CodigoPlantilla;
            rpta.CodigoContratoPrincipal = objEnt.CodigoContratoPrincipal;
            rpta.CodigoEstadoEdicion = objEnt.CodigoEstadoEdicion;
            rpta.ComentarioModificacion = objEnt.ComentarioModificacion;
            rpta.RespuestaModificacion = objEnt.RespuestaModificacion;
            rpta.CodigoFlujoAprobacion = objEnt.CodigoFlujoAprobacion;
            rpta.CodigoEstadioActual = objEnt.CodigoEstadioActual;
            rpta.EstadoRegistro = objEnt.EstadoRegistro;
            rpta.CodigoEstado = objEnt.CodigoEstado;
            rpta.NumeroAdendaConcatenado = objEnt.NumeroAdendaConcatenado;
            rpta.CodigoContratoOriginal = objEnt.CodigoContratoOriginal;
            rpta.EsFlexible = objEnt.EsFlexible == null ? false : (bool)objEnt.EsFlexible;
            rpta.EsCorporativo= objEnt.EsCorporativo== null ? false : (bool)objEnt.EsCorporativo;
            rpta.CodigoRequerido = objEnt.CodigoRequerido.ToString();
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad response ContratoDocumentoResponse de la Entidad ContratoDocumentoLogic
        /// </summary>
        /// <param name="objLogic">entidad logic ContratoDocumentoLogic</param>
        /// <returns>Objeto Response de Contrato Documento</returns>
        public static ContratoDocumentoResponse ObtenerContratoDocumentoResponseDeLogic(ContratoDocumentoLogic objLogic)
        {
            ContratoDocumentoResponse rpta = new ContratoDocumentoResponse();
            rpta.CodigoContratoDocumento = objLogic.CodigoContratoDocumento;
            rpta.CodigoContrato = objLogic.CodigoContrato;
            rpta.NumeroContrato = objLogic.NumeroContrato;
            rpta.CodigoArchivo = objLogic.CodigoArchivo;
            rpta.Contenido = objLogic.Contenido;
            rpta.RutaArchivoSharePoint = objLogic.RutaArchivoSharePoint;
            rpta.IndicadorActual = objLogic.IndicadorActual;
            rpta.Version = objLogic.Version;
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad response ContratoDocumentoAdjuntoResponse de la Entidad ContratoDocumentoAdjuntoLogic
        /// </summary>
        /// <param name="logic">entidad logic del Documento Adjunto al Contrato</param>
        /// <returns>Response de el Documento Adjunto al Contrato</returns>
        public static ContratoDocumentoAdjuntoResponse ObtenerContratoDocumentoAdjuntoResponseDeLogic(ContratoDocumentoAdjuntoLogic logic)
        {
            ContratoDocumentoAdjuntoResponse response = new ContratoDocumentoAdjuntoResponse();
            response.CodigoContratoDocumentoAdjunto = logic.CodigoContratoDocumentoAdjunto;
            response.CodigoContrato = logic.CodigoContrato;
            response.CodigoArchivo = logic.CodigoArchivo;
            response.NombreArchivo = logic.NombreArchivo;
            response.RutaArchivoSharePoint = logic.RutaArchivoSharePoint;
            response.UsuarioCreacion = logic.UsuarioCreacion;
            return response;
        }

        /// <summary>
        /// Transforma la info de logic a response para Documento Adjunto Resolución S09-SGC-01
        /// </summary>
        /// <param name="logic"></param>
        /// <param name="nombrecompleto"></param>
        /// <returns></returns>
        public static ContratoDocumentoAdjuntoResolucionResponse ObtenerContratoDocumentoAdjuntoResolucionResponseDeLogic(ContratoDocumentoAdjuntoResolucionLogic logic, string nombrecompleto)
        {
            ContratoDocumentoAdjuntoResolucionResponse response = new ContratoDocumentoAdjuntoResolucionResponse();
            response.CodigoContratoDocumentoAdjuntoResolucion = logic.CodigoContratoDocumentoAdjuntoResolucion;
            response.CodigoContrato = logic.CodigoContrato;
            response.CodigoArchivo = logic.CodigoArchivo;
            response.NombreArchivo = logic.NombreArchivo;
            response.RutaArchivoSharePoint = logic.RutaArchivoSharePoint;
            response.UsuarioCreacion = nombrecompleto;
            return response;
        }

        /// <summary>
        /// Obtiene la entidad response ContratoDocumentoAdjuntoEntity de la Entidad ContratoDocumentoAdjuntoRequest
        /// </summary>
        /// <param name="request">Request del Documento Adjunto al Contrato</param>
        /// <returns>Entity del Documento Adjunto al Contrato</returns>
        public static ContratoDocumentoAdjuntoEntity ObtenerContratoDocumentoAdjuntoEntityDeRequest(ContratoDocumentoAdjuntoRequest request)
        {
            ContratoDocumentoAdjuntoEntity response = new ContratoDocumentoAdjuntoEntity();
            response.CodigoContratoDocumentoAdjunto = request.CodigoContratoDocumentoAdjunto.Value;
            response.CodigoContrato = request.CodigoContrato.Value;
            response.CodigoArchivo = request.CodigoArchivo.Value;
            response.NombreArchivo = request.NombreArchivo;
            response.RutaArchivoSharePoint = request.RutaArchivoSharePoint;
            return response;
        }

        /// <summary>
        /// Obtiene el contrato dle documento. S09-SGC-01
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static ContratoDocumentoAdjuntoResolucionEntity ObtenerContratoDocumentoAdjuntoResolucionEntityDeRequest(ContratoDocumentoAdjuntoResolucionRequest request)
        {
            ContratoDocumentoAdjuntoResolucionEntity response = new ContratoDocumentoAdjuntoResolucionEntity();
            response.CodigoContratoDocumentoAdjuntoResolucion = request.CodigoContratoDocumentoAdjuntoResolucion.Value;
            response.CodigoContrato = request.CodigoContrato.Value;
            response.CodigoArchivo = request.CodigoArchivo.Value;
            response.NombreArchivo = request.NombreArchivo;
            response.RutaArchivoSharePoint = request.RutaArchivoSharePoint;
            return response;
        }

        /// <summary>
        /// Obtiene la entidad logic ContratoDocumentoLogic de la Entidad ContratoDocumentoResponse
        /// </summary>
        /// <param name="objRsp">entidad response ContratoDocumentoResponse</param>
        /// <returns>Entidad Contrato Documento</returns>
        public static ContratoDocumentoLogic ObtenerContratoDocumentoLogicDeResponse(ContratoDocumentoResponse objRsp)
        {
            ContratoDocumentoLogic rpta = new ContratoDocumentoLogic();
            rpta.CodigoContratoDocumento = objRsp.CodigoContratoDocumento;
            rpta.CodigoContrato = objRsp.CodigoContrato;
            rpta.NumeroContrato = objRsp.NumeroContrato;
            rpta.CodigoArchivo = objRsp.CodigoArchivo;
            rpta.RutaArchivoSharePoint = objRsp.RutaArchivoSharePoint;
            rpta.IndicadorActual = objRsp.IndicadorActual;
            rpta.Version = objRsp.Version;
            return rpta;
        }

        /// <summary>
        /// Obtiene un registro de Unidades Operativas
        /// </summary>
        /// <param name="objLogic">Objeto logic de Unidad Operativa</param>
        /// <returns>Objeto Response de Unidad Operativa</returns>
        public static UnidadOperativaResponse ObtenerUnidadOperativaResponseDeLogic(UnidadOperativaLogic objLogic)
        {
            UnidadOperativaResponse rpta = new UnidadOperativaResponse();
            rpta.CodigoUnidadOperativa = objLogic.CodigoUnidadOperativa;
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad response ContratoEstadioResponse de la Entidad ContratoEstadioLogic
        /// </summary>
        /// <param name="objLogic">entidad logic ContratoEstadioLogic</param>
        /// <returns>Entidad Contrato Estadio</returns>
        public static ContratoEstadioResponse ObtenerContratoEstadioResponsableResponseDeLogic(ContratoEstadioLogic objLogic)
        {
            ContratoEstadioResponse rpta = new ContratoEstadioResponse();
            rpta.CodigoContratoEstadio = objLogic.CodigoContratoEstadio;
            rpta.CodigoContrato = objLogic.CodigoContrato;
            rpta.CodigoFlujoAprobacionEstadio = objLogic.CodigoFlujoAprobacionEstadio;
            rpta.FechaIngreso = objLogic.FechaIngreso;
            rpta.FechaFinalizacion = objLogic.FechaFinalizacion;
            rpta.CodigoResponsable = objLogic.CodigoResponsable;
            rpta.CodigoEstadoContratoEstadio = objLogic.CodigoEstadoContratoEstadio;
            rpta.FechaPrimeraNotificacion = objLogic.FechaPrimeraNotificacion;
            rpta.FechaUltimaNotificacion = objLogic.FechaUltimaNotificacion;
            return rpta;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objRqst"></param>
        /// <returns></returns>
        public static ReporteContratoObservadoAprobadoResponse ObtenerNumeroContratoPaginado(ContratoLogic objRqst)
        {
            ReporteContratoObservadoAprobadoResponse rpta = new ReporteContratoObservadoAprobadoResponse();

            rpta.CodigoUnidadOperativa  = objRqst.CodigoUnidadOperativa == null ? Guid.Empty : (Guid)objRqst.CodigoUnidadOperativa;
            rpta.NumeroContrato         = objRqst.NumeroContrato;
            rpta.CodigoContrato = objRqst.CodigoContrato;

            return rpta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objRqst"></param>
        /// <returns></returns>
        public static ReporteContratoObservadoAprobadoResponse ObtenerContratoObservadoAprobadoPaginado(ContratoObservadoAprobadoLogic objRqst)
        {
            ReporteContratoObservadoAprobadoResponse rpta = new ReporteContratoObservadoAprobadoResponse();

            rpta.CodigoContrato         = objRqst.CodigoContrato;
            rpta.DescripcionContrato    = objRqst.DescripcionContrato;
            rpta.MontoContrato          = objRqst.MontoContrato;
            rpta.CodigoUnidadOperativa  = objRqst.CodigoUnidadOperativa;

            rpta.NombreUnidadOperativa  = objRqst.NombreUnidadOperativa;
            rpta.NumeroContrato         = objRqst.NumeroContrato;
            rpta.NumeroAdenda           = objRqst.NumeroAdenda;
            rpta.TipoAccion             = objRqst.TipoAccion;
            rpta.Comentario             = objRqst.Comentario;
            rpta.AccionPor              = objRqst.AccionPor;
            rpta.FechaAccion            = objRqst.FechaAccion.ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.Respuesta              = objRqst.Respuesta;
            rpta.FechaRespuesta         = objRqst.FechaRespuesta.ToString(DatosConstantes.Formato.FormatoFecha);

            if (rpta.FechaRespuesta == "01/01/1900")
            {
                rpta.FechaRespuesta = "";
            }

            if (rpta.FechaAccion == "01/01/1900")
            {
                rpta.FechaAccion = "";
            }

            rpta.UsuarioRespuesta       = objRqst.UsuarioRespuesta;

            rpta.FilasTotal = objRqst.TotalRegistro;
            rpta.NumeroFila = objRqst.NumeroRegistro;

            return rpta;
        }
    }
}
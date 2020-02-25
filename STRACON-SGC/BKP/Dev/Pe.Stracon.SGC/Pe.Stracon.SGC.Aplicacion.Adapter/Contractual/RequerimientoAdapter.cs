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
    /// Implementacion del adaptador de Requerimiento
    /// </summary>
    public sealed class RequerimientoAdapter
    {
        /// <summary>
        /// Obtiene la entidad RequerimientoResponse de la Entidad Logica RequerimientoLogic
        /// </summary>
        /// <param name="contrato">Entidad Logic</param>
        /// <param name="listaUnidadOperativa">Lista de Unidades Operativas</param>
        /// <param name="lstTipoRequerimiento">Lista de Tipo de Requerimiento</param>
        /// <param name="lstTipoServicio">Lista de Tipos de Servicio</param>
        /// <param name="lstEstadoEdicion"></param>
        /// <param name="lstTipoDocumento"></param>
        /// <returns>Entidad logica contratologic</returns>
        public static RequerimientoResponse ObtenerRequerimientoResponseDeLogic(RequerimientoLogic contrato,
                                        List<UnidadOperativaResponse> listaUnidadOperativa = null,
                                        List<CodigoValorResponse> lstTipoRequerimiento = null,
                                        List<CodigoValorResponse> lstTipoServicio = null,
                                        List<CodigoValorResponse> lstEstadoEdicion = null,
                                        List<CodigoValorResponse> lstTipoDocumento = null)
        {
            RequerimientoResponse response = new RequerimientoResponse();
            response.CodigoRequerimiento = contrato.CodigoRequerimiento;
            response.CodigoUnidadOperativa = contrato.CodigoUnidadOperativa;
            response.CodigoProveedor = contrato.CodigoProveedor;
            response.NombreProveedor = contrato.NombreProveedor;
            response.NumeroRequerimiento = contrato.NumeroRequerimiento;
            response.Descripcion = contrato.Descripcion;
            //response.CodigoTipoServicio = contrato.CodigoTipoServicio;
            response.CodigoFlujoAprobacion = contrato.CodigoFlujoAprobacion;
            response.CodigoTipoDocumento = contrato.CodigoTipoDocumento;
            response.FechaInicioVigencia = contrato.FechaInicioVigencia;
            response.FechaFinVigencia = contrato.FechaFinVigencia;
            response.CodigoMoneda = contrato.CodigoMoneda;
            response.MontoRequerimiento = contrato.MontoRequerimiento;
            response.MontoAcumulado = contrato.MontoAcumulado;
            response.CodigoEstado = contrato.CodigoEstado;
            response.CodigoPlantilla = contrato.CodigoPlantilla;
            response.CodigoRequerimientoPrincipal = contrato.CodigoRequerimientoPrincipal;
            response.CodigoEstadoEdicion = contrato.CodigoEstadoEdicion;
            response.ComentarioModificacion = contrato.ComentarioModificacion;
            response.RespuestaModificacion = contrato.RespuestaModificacion;
            response.IndicadorPermiteCarga = contrato.IndicadorPermiteCarga;
            response.CodigoEstadioActual = contrato.CodigoEstadioActual;
            response.NombreEstadioActual = contrato.DescripcionEstadioActual;
            response.DiasPendiente = contrato.DiasPendiente;
            response.CodigoRequerimientoEstadio = contrato.CodigoRequerimientoEstadio;
            response.EstadioPropioConsulta = contrato.EstadioPropioConsulta;
            response.DescripcionRequerimiento = contrato.DescripcionRequerimiento;
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
                //response.NombreTipoServicio = Convert.ToString(tipoRequerimiento.Valor);
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
        /// Obtiene la entidad RequerimientoEstadioObservacionResponse de la Entidad Logica RequerimientoEstadioObservacionLogic
        /// </summary>
        /// <param name="objLogic">Objeto logic RequerimientoEstadioObservacionLogic</param>
        /// <param name="lstTrbajador">Listado de trabajadores</param>
        /// <param name="lstTipoRespuesta"></param>
        /// <returns>Entidad Logica de Requerimiento Estadio Observación Logic</returns>
        public static RequerimientoEstadioObservacionResponse ObtenerRequerimientoEstadioResponseDeLogic(RequerimientoEstadioObservacionLogic objLogic,
                                        List<TrabajadorResponse> lstTrbajador = null,
                                        List<CodigoValorResponse> lstTipoRespuesta = null)
        {
            RequerimientoEstadioObservacionResponse rpta = new RequerimientoEstadioObservacionResponse();
            int li_index = -1;
            rpta.CodigoRequerimientoEstadioObservacion = objLogic.CodigoRequerimientoEstadioObservacion;
            rpta.CodigoRequerimientoEstadio = objLogic.CodigoRequerimientoEstadio;
            rpta.Descripcion = objLogic.Descripcion;
            rpta.FechaRegistro = objLogic.FechaRegistro == null ? "" : ((DateTime?)objLogic.FechaRegistro).Value.ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.CodigoRequerimientoParrafo = objLogic.CodigoRequerimientoParrafo;
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
        /// Obtiene la entidad RequerimientoEstadioConsultaResponse de la Entidad Logica RequerimientoEstadioObservacionLogic
        /// </summary>
        /// <param name="objLogic">Objeto logic RequerimientoEstadioConsultaLogic</param>
        /// <param name="lstTrbajador">Listado de trabajadores</param>
        /// <returns>Entidad Logica de Requerimiento estadio observación logic</returns>
        public static RequerimientoEstadioConsultaResponse ObtenerRequerimientoEstadioResponseDeLogic(RequerimientoEstadioConsultaLogic objLogic,
                                        List<TrabajadorResponse> lstTrbajador = null)
        {
            RequerimientoEstadioConsultaResponse rpta = new RequerimientoEstadioConsultaResponse();
            int li_index = -1;
            rpta.CodigoRequerimientoEstadioConsulta = objLogic.CodigoRequerimientoEstadioConsulta;
            rpta.CodigoRequerimientoEstadio = objLogic.CodigoRequerimientoEstadio;
            rpta.Descripcion = objLogic.Descripcion;
            rpta.FechaConsulta = objLogic.FechaRegistro.ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.CodigoRequerimientoParrafo = objLogic.CodigoRequerimientoParrafo;
            rpta.Destinatario = objLogic.Destinatario;
            rpta.Respuesta = objLogic.Respuesta;
            rpta.FechaRespuesta = objLogic.FechaRespuesta == null ? "" : ((DateTime)objLogic.FechaRespuesta).ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.Consultor = Guid.Parse(objLogic.Consultor);
            rpta.CodigoRequerimiento = objLogic.CodigoRequerimiento;

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
        /// Obtiene la entidad RequerimientoEstadioObservacionEntity de la Entidad RequerimientoEstadioObservacionRequest
        /// </summary>
        /// <param name="objRqst">Entidad RequerimientoEstadioObservacion</param>
        /// <returns>Entidad de Requerimiento Estadio Observacion Request</returns>
        public static RequerimientoEstadioObservacionEntity ObtenerRequerimientoEstadioObservacionEntityDeRequest(RequerimientoEstadioObservacionRequest objRqst)
        {
            RequerimientoEstadioObservacionEntity rpta = new RequerimientoEstadioObservacionEntity();
            rpta.CodigoRequerimientoEstadioObservacion = objRqst.CodigoRequerimientoEstadioObservacion == null ? Guid.Empty : (Guid)objRqst.CodigoRequerimientoEstadioObservacion;
            rpta.CodigoRequerimientoEstadio = objRqst.CodigoRequerimientoEstadio;
            rpta.Descripcion = objRqst.Descripcion;
            rpta.FechaRegistro = objRqst.FechaRegistro;
            rpta.CodigoRequerimientoParrafo = objRqst.CodigoRequerimientoParrafo;
            rpta.CodigoEstadioRetorno = objRqst.CodigoEstadioRetorno;
            rpta.Destinatario = objRqst.Destinatario;
            rpta.CodigoTipoRespuesta = objRqst.CodigoTipoRespuesta;
            rpta.Respuesta = objRqst.Respuesta;
            rpta.FechaRespuesta = objRqst.FechaRespuesta;
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad RequerimientoEstadioObservacionEntity de la Entidad RequerimientoEstadioObservacionRequest
        /// </summary>
        /// <param name="objRqst">Entidad RequerimientoEstadioObservacion</param>
        /// <returns>Entidad Requerimiento Estadio Observación request</returns>
        public static RequerimientoEstadioConsultaEntity ObtenerRequerimientoEstadioConsultEntityDeRequest(RequerimientoEstadioConsultaRequest objRqst)
        {
            RequerimientoEstadioConsultaEntity rpta = new RequerimientoEstadioConsultaEntity();
            rpta.CodigoRequerimientoEstadioConsulta = objRqst.CodigoRequerimientoEstadioConsulta == null ? Guid.Empty : (Guid)objRqst.CodigoRequerimientoEstadioConsulta;
            rpta.CodigoRequerimientoEstadio = objRqst.CodigoRequerimientoEstadio;
            rpta.Descripcion = objRqst.Descripcion;
            rpta.FechaRegistro = objRqst.FechaRegistro;
            rpta.CodigoRequerimientoParrafo = objRqst.CodigoRequerimientoParrafo;
            rpta.Destinatario = objRqst.Destinatario;
            rpta.Respuesta = objRqst.Respuesta;
            rpta.FechaRespuesta = objRqst.FechaRespuesta;
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad RequerimientoEstadioObservacionResponse de la Entidad RequerimientoEstadioObservacionLogic
        /// </summary>
        /// <param name="objEnt">Objeto entidad RequerimientoEstadioObservacionEntity</param>
        /// <returns>Entidad Requerimiento estadio observación Logic</returns>
        public static RequerimientoEstadioObservacionResponse ObtenerRequerimientoEstadioObservacionResponseDeEntity(RequerimientoEstadioObservacionEntity objEnt)
        {
            RequerimientoEstadioObservacionResponse rpta = new RequerimientoEstadioObservacionResponse();
            rpta.CodigoRequerimientoEstadioObservacion = objEnt.CodigoRequerimientoEstadioObservacion;
            rpta.CodigoRequerimientoEstadio = objEnt.CodigoRequerimientoEstadio;
            rpta.Descripcion = objEnt.Descripcion;
            rpta.FechaRegistro = objEnt.FechaRegistro == null ? "" : ((DateTime)objEnt.FechaRegistro).ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.CodigoRequerimientoParrafo = objEnt.CodigoRequerimientoParrafo;
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
        /// Obtiene la entidad RequerimientoEstadioConsultaResponse de la Entidad RequerimientoEstadioEntityLogic
        /// </summary>
        /// <param name="objEnt">Objeto entidad RequerimientoEstadioConsultaEntity</param>
        /// <returns>Entidad Requerimiento estadio </returns>
        public static RequerimientoEstadioConsultaResponse ObtenerRequerimientoEstadioConsultaResponseDeEntity(RequerimientoEstadioConsultaEntity objEnt)
        {
            RequerimientoEstadioConsultaResponse rpta = new RequerimientoEstadioConsultaResponse();
            rpta.CodigoRequerimientoEstadioConsulta = objEnt.CodigoRequerimientoEstadioConsulta;
            rpta.CodigoRequerimientoEstadio = objEnt.CodigoRequerimientoEstadio;
            rpta.Descripcion = objEnt.Descripcion;
            rpta.FechaConsulta = objEnt.FechaRegistro.ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.CodigoRequerimientoParrafo = objEnt.CodigoRequerimientoParrafo;
            rpta.Destinatario = objEnt.Destinatario;
            rpta.Respuesta = objEnt.Respuesta;
            rpta.FechaRespuesta = objEnt.FechaRespuesta == null ? "" : ((DateTime?)objEnt.FechaRespuesta).Value.ToString(DatosConstantes.Formato.FormatoFecha);
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad RequerimientoEstadioEntity de la Entidad RequerimientoEstadioRequest
        /// </summary>
        /// <param name="objRqst">Objeto request RequerimientoEstadioRequest</param>
        /// <returns>Entidad Requerimiento Estadio</returns>
        public static RequerimientoEstadioEntity ObtenerRequerimientoEstadioEntityDeRequest(RequerimientoEstadioRequest objRqst)
        {
            RequerimientoEstadioEntity rpta = new RequerimientoEstadioEntity();
            rpta.CodigoRequerimientoEstadio = objRqst.CodigoRequerimientoEstadio == null ? Guid.Empty : (Guid)objRqst.CodigoRequerimientoEstadio;
            rpta.CodigoRequerimiento = objRqst.CodigoRequerimiento == null ? Guid.Empty : (Guid)objRqst.CodigoRequerimiento;
            rpta.CodigoFlujoAprobacionEstadio = objRqst.CodigoFlujoAprobacionEstadio == null ? Guid.Empty : (Guid)objRqst.CodigoFlujoAprobacionEstadio;
            rpta.FechaIngreso = objRqst.FechaIngreso;
            rpta.FechaFinalizacion = objRqst.FechaFinalizacion;
            rpta.CodigoResponsable = objRqst.CodigoResponsable;
            rpta.CodigoEstadoRequerimientoEstadio = objRqst.CodigoEstadoRequerimientoEstadio;
            rpta.FechaPrimeraNotificacion = objRqst.FechaPrimeraNotificacion;
            rpta.FechaUltimaNotificacion = objRqst.FechaUltimaNotificacion;
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad RequerimientoParrafoResponse de la Entidad RequerimientoParrafoLogic
        /// </summary>
        /// <param name="objLogic">Objeto logic de RequerimientoParrafoLogic</param>
        /// <returns>Objeto Response Requerimiento Parrafo</returns>
        public static RequerimientoParrafoResponse ObtenerRequerimientoParrafoResponseDeLogic(RequerimientoParrafoLogic objLogic)
        {
            RequerimientoParrafoResponse rpta = new RequerimientoParrafoResponse();
            rpta.CodigoRequerimiento = objLogic.CodigoRequerimiento;
            rpta.CodigoRequerimientoParrafo = objLogic.CodigoRequerimientoParrafo;
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
        /// Obtiene la entidad response RequerimientoResponse de la Entidad RequerimientoEntity
        /// </summary>
        /// <param name="objEnt"></param>
        /// <param name="objProv"></param>
        /// <returns>Entidad Requerimiento</returns>            
        public static RequerimientoResponse ObtenerRequerimientoResponseDeEntity(RequerimientoEntity objEnt, ProveedorEntity objProv = null)
        {
            RequerimientoResponse rpta = new RequerimientoResponse();
            rpta.CodigoRequerimiento = objEnt.CodigoRequerimiento;
            rpta.CodigoUnidadOperativa = objEnt.CodigoUnidadOperativa;
            rpta.CodigoProveedor = objEnt.CodigoProveedor;
            if (objProv != null)
                rpta.NombreProveedor = objProv.Nombre;
            rpta.NumeroRequerimiento = (objEnt.NumeroRequerimiento != null) ? objEnt.NumeroRequerimiento : "";
            rpta.Descripcion = objEnt.Descripcion;
            //rpta.CodigoTipoServicio = objEnt.CodigoTipoServicio;
            rpta.CodigoTipoRequerimiento = objEnt.CodigoTipoRequerimiento;
            rpta.CodigoTipoDocumento = objEnt.CodigoTipoDocumento;
            
            rpta.IndicadorVersionOficial = objEnt.IndicadorVersionOficial;
            rpta.FechaInicioVigencia = objEnt.FechaInicioVigencia;
            rpta.FechaFinVigencia = objEnt.FechaFinVigencia;
            rpta.FechaInicioVigenciaString = objEnt.FechaInicioVigencia.ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.FechaFinVigenciaString = objEnt.FechaFinVigencia.ToString(DatosConstantes.Formato.FormatoFecha);
            rpta.CodigoMoneda = objEnt.CodigoMoneda;
            rpta.MontoRequerimiento = objEnt.MontoRequerimiento;
            rpta.MontoRequerimientoString    = rpta.MontoRequerimiento.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            rpta.MontoAcumulado         = objEnt.MontoAcumulado;
            rpta.MontoAcumuladoString   = rpta.MontoAcumulado.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            rpta.CodigoEstado = objEnt.CodigoEstado;
            rpta.CodigoPlantilla = objEnt.CodigoPlantilla;
            rpta.CodigoRequerimientoPrincipal = objEnt.CodigoRequerimientoPrincipal;
            rpta.CodigoEstadoEdicion = objEnt.CodigoEstadoEdicion;
            rpta.ComentarioModificacion = objEnt.ComentarioModificacion;
            rpta.RespuestaModificacion = objEnt.RespuestaModificacion;
            rpta.CodigoFlujoAprobacion = objEnt.CodigoFlujoAprobacion;
            rpta.CodigoEstadioActual = objEnt.CodigoEstadioActual;
            rpta.EstadoRegistro = objEnt.EstadoRegistro;
            rpta.CodigoEstado = objEnt.CodigoEstado;
            rpta.NumeroAdendaConcatenado = objEnt.NumeroAdendaConcatenado;
            rpta.CodigoRequerimientoOriginal = objEnt.CodigoRequerimientoOriginal;
            rpta.EsFlexible = objEnt.EsFlexible == null ? false : (bool)objEnt.EsFlexible;
            rpta.EsCorporativo= objEnt.EsCorporativo== null ? false : (bool)objEnt.EsCorporativo;
            rpta.CodigoRequerido = objEnt.CodigoRequerido.ToString();
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad response RequerimientoDocumentoResponse de la Entidad RequerimientoDocumentoLogic
        /// </summary>
        /// <param name="objLogic">entidad logic RequerimientoDocumentoLogic</param>
        /// <returns>Objeto Response de Requerimiento Documento</returns>
        public static RequerimientoDocumentoResponse ObtenerRequerimientoDocumentoResponseDeLogic(RequerimientoDocumentoLogic objLogic)
        {
            RequerimientoDocumentoResponse rpta = new RequerimientoDocumentoResponse();
            rpta.CodigoRequerimientoDocumento = objLogic.CodigoRequerimientoDocumento;
            rpta.CodigoRequerimiento = objLogic.CodigoRequerimiento;
            rpta.NumeroRequerimiento = objLogic.NumeroRequerimiento;
            rpta.CodigoArchivo = objLogic.CodigoArchivo;
            rpta.Contenido = objLogic.Contenido;
            rpta.RutaArchivoSharePoint = objLogic.RutaArchivoSharePoint;
            rpta.IndicadorActual = objLogic.IndicadorActual;
            rpta.Version = objLogic.Version;
            return rpta;
        }

        /// <summary>
        /// Obtiene la entidad response RequerimientoDocumentoAdjuntoResponse de la Entidad RequerimientoDocumentoAdjuntoLogic
        /// </summary>
        /// <param name="logic">entidad logic del Documento Adjunto al Requerimiento</param>
        /// <returns>Response de el Documento Adjunto al Requerimiento</returns>
        public static RequerimientoDocumentoAdjuntoResponse ObtenerRequerimientoDocumentoAdjuntoResponseDeLogic(RequerimientoDocumentoAdjuntoLogic logic)
        {
            RequerimientoDocumentoAdjuntoResponse response = new RequerimientoDocumentoAdjuntoResponse();
            response.CodigoRequerimientoDocumentoAdjunto = logic.CodigoRequerimientoDocumentoAdjunto;
            response.CodigoRequerimiento = logic.CodigoRequerimiento;
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
        public static RequerimientoDocumentoAdjuntoResolucionResponse ObtenerRequerimientoDocumentoAdjuntoResolucionResponseDeLogic(RequerimientoDocumentoAdjuntoResolucionLogic logic, string nombrecompleto)
        {
            RequerimientoDocumentoAdjuntoResolucionResponse response = new RequerimientoDocumentoAdjuntoResolucionResponse();
            response.CodigoRequerimientoDocumentoAdjuntoResolucion = logic.CodigoRequerimientoDocumentoAdjuntoResolucion;
            response.CodigoRequerimiento = logic.CodigoRequerimiento;
            response.CodigoArchivo = logic.CodigoArchivo;
            response.NombreArchivo = logic.NombreArchivo;
            response.RutaArchivoSharePoint = logic.RutaArchivoSharePoint;
            response.UsuarioCreacion = nombrecompleto;
            return response;
        }

        /// <summary>
        /// Obtiene la entidad response RequerimientoDocumentoAdjuntoEntity de la Entidad RequerimientoDocumentoAdjuntoRequest
        /// </summary>
        /// <param name="request">Request del Documento Adjunto al Requerimiento</param>
        /// <returns>Entity del Documento Adjunto al Requerimiento</returns>
        public static RequerimientoDocumentoAdjuntoEntity ObtenerRequerimientoDocumentoAdjuntoEntityDeRequest(RequerimientoDocumentoAdjuntoRequest request)
        {
            RequerimientoDocumentoAdjuntoEntity response = new RequerimientoDocumentoAdjuntoEntity();
            response.CodigoRequerimientoDocumentoAdjunto = request.CodigoRequerimientoDocumentoAdjunto.Value;
            response.CodigoRequerimiento = request.CodigoRequerimiento.Value;
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
        public static RequerimientoDocumentoAdjuntoResolucionEntity ObtenerRequerimientoDocumentoAdjuntoResolucionEntityDeRequest(RequerimientoDocumentoAdjuntoResolucionRequest request)
        {
            RequerimientoDocumentoAdjuntoResolucionEntity response = new RequerimientoDocumentoAdjuntoResolucionEntity();
            response.CodigoRequerimientoDocumentoAdjuntoResolucion = request.CodigoRequerimientoDocumentoAdjuntoResolucion.Value;
            response.CodigoRequerimiento = request.CodigoRequerimiento.Value;
            response.CodigoArchivo = request.CodigoArchivo.Value;
            response.NombreArchivo = request.NombreArchivo;
            response.RutaArchivoSharePoint = request.RutaArchivoSharePoint;
            return response;
        }

        /// <summary>
        /// Obtiene la entidad logic RequerimientoDocumentoLogic de la Entidad RequerimientoDocumentoResponse
        /// </summary>
        /// <param name="objRsp">entidad response RequerimientoDocumentoResponse</param>
        /// <returns>Entidad Requerimiento Documento</returns>
        public static RequerimientoDocumentoLogic ObtenerRequerimientoDocumentoLogicDeResponse(RequerimientoDocumentoResponse objRsp)
        {
            RequerimientoDocumentoLogic rpta = new RequerimientoDocumentoLogic();
            rpta.CodigoRequerimientoDocumento = objRsp.CodigoRequerimientoDocumento;
            rpta.CodigoRequerimiento = objRsp.CodigoRequerimiento;
            rpta.NumeroRequerimiento = objRsp.NumeroRequerimiento;
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
        /// Obtiene la entidad response RequerimientoEstadioResponse de la Entidad RequerimientoEstadioLogic
        /// </summary>
        /// <param name="objLogic">entidad logic RequerimientoEstadioLogic</param>
        /// <returns>Entidad Requerimiento Estadio</returns>
        public static RequerimientoEstadioResponse ObtenerRequerimientoEstadioResponsableResponseDeLogic(RequerimientoEstadioLogic objLogic)
        {
            RequerimientoEstadioResponse rpta = new RequerimientoEstadioResponse();
            rpta.CodigoRequerimientoEstadio = objLogic.CodigoRequerimientoEstadio;
            rpta.CodigoRequerimiento = objLogic.CodigoRequerimiento;
            rpta.CodigoFlujoAprobacionEstadio = objLogic.CodigoFlujoAprobacionEstadio;
            rpta.FechaIngreso = objLogic.FechaIngreso;
            rpta.FechaFinalizacion = objLogic.FechaFinalizacion;
            rpta.CodigoResponsable = objLogic.CodigoResponsable;
            rpta.CodigoEstadoRequerimientoEstadio = objLogic.CodigoEstadoRequerimientoEstadio;
            rpta.FechaPrimeraNotificacion = objLogic.FechaPrimeraNotificacion;
            rpta.FechaUltimaNotificacion = objLogic.FechaUltimaNotificacion;
            return rpta;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objRqst"></param>
        /// <returns></returns>
        public static ReporteRequerimientoObservadoAprobadoResponse ObtenerNumeroRequerimientoPaginado(RequerimientoLogic objRqst)
        {
            ReporteRequerimientoObservadoAprobadoResponse rpta = new ReporteRequerimientoObservadoAprobadoResponse();

            rpta.CodigoUnidadOperativa  = objRqst.CodigoUnidadOperativa == null ? Guid.Empty : (Guid)objRqst.CodigoUnidadOperativa;
            rpta.NumeroRequerimiento         = objRqst.NumeroRequerimiento;
            rpta.CodigoRequerimiento = objRqst.CodigoRequerimiento;

            return rpta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objRqst"></param>
        /// <returns></returns>
        public static ReporteRequerimientoObservadoAprobadoResponse ObtenerRequerimientoObservadoAprobadoPaginado(RequerimientoObservadoAprobadoLogic objRqst)
        {
            ReporteRequerimientoObservadoAprobadoResponse rpta = new ReporteRequerimientoObservadoAprobadoResponse();

            rpta.CodigoRequerimiento         = objRqst.CodigoRequerimiento;
            rpta.DescripcionRequerimiento    = objRqst.DescripcionRequerimiento;
            rpta.MontoRequerimiento          = objRqst.MontoRequerimiento;
            rpta.CodigoUnidadOperativa  = objRqst.CodigoUnidadOperativa;

            rpta.NombreUnidadOperativa  = objRqst.NombreUnidadOperativa;
            rpta.NumeroRequerimiento         = objRqst.NumeroRequerimiento;
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
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
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
    /// Implementación del Adaptador de Consulta
    /// </summary>
    public sealed class ConsultaAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="data">Datos a adaptar</param>
        /// <returns>Objeto ConsultaResponse</returns>
        public static ConsultaResponse ObtenerConsultaResponse(ConsultaLogic data, List<CodigoValorResponse> listaArea, List<CodigoValorResponse> listEstadoConsulta, List<CodigoValorResponse> listTipoConsulta, Guid codigoUsuarioSession, List<TrabajadorDatoMinimoResponse> listaTrabajador = null)
        {
            var consultaResponse = new ConsultaResponse();
            consultaResponse.Asunto = data.Asunto;
            consultaResponse.CodigoConsulta = data.CodigoConsulta;
            consultaResponse.CodigoDestinatario = data.CodigoDestinatario;
            consultaResponse.Contenido = data.Contenido;
            var estadoConsulta = listEstadoConsulta.Where(x => x.Codigo.ToString() == data.EstadoConsulta.ToString()).FirstOrDefault();
            consultaResponse.EstadoConsulta = data.EstadoConsulta;
            consultaResponse.DescripcionEstadoConsulta = (estadoConsulta != null ? estadoConsulta.Valor.ToString() : "");
            consultaResponse.FechaEnvio = data.FechaEnvio;
            consultaResponse.FechaEnvioString = (data.FechaEnvio.HasValue) ? data.FechaEnvio.Value.ToString("dd/MM/yyyy") : "";
            consultaResponse.FechaRespuesta = data.FechaRespuesta;
            consultaResponse.FechaRespuestaString = (data.FechaRespuesta.HasValue) ? data.FechaRespuesta.Value.ToString("dd/MM/yyyy") : ""; ;
            consultaResponse.Respuesta = data.Respuesta;
            var tipoConsulta = listTipoConsulta.Where(x => x.Codigo.ToString() == data.Tipo.ToString()).FirstOrDefault();
            consultaResponse.DescripcionTipo = (tipoConsulta != null ? tipoConsulta.Valor.ToString() : "");
            consultaResponse.Tipo = data.Tipo;
            consultaResponse.CodigoUnidadOperativa = (data.CodigoUnidadOperativa.HasValue ? data.CodigoUnidadOperativa.Value : (Guid?)null);
            consultaResponse.CodigoArea = (data.CodigoArea != null ? data.CodigoArea : string.Empty);
            consultaResponse.CodigoRemitente = data.CodigoRemitente;
            consultaResponse.CodigoConsultaRelacionado = data.CodigoConsultaRelacionado;
            consultaResponse.CodigoConsultaOriginal = data.CodigoConsultaOriginal;
            consultaResponse.VistoRemitenteOriginal = data.VistoRemitenteOriginal;
            var area = new CodigoValorResponse();
            if (data.CodigoArea != null)
            {
                area = listaArea.Where(x => x.Codigo.ToString() == data.CodigoArea.ToString()).FirstOrDefault();
            }
            else
            {
                area = null;
            }
            consultaResponse.DescripcionArea = (area != null ? area.Valor.ToString() : string.Empty);
            consultaResponse.DiaSinRespuesta = data.DiaSinRespuesta;

            if (consultaResponse.CodigoDestinatario == codigoUsuarioSession)
            {
                consultaResponse.TipoUsuario = DatosConstantes.TipoUsuario.Destinatario;
            }
            else if (consultaResponse.CodigoRemitente == codigoUsuarioSession)
            {
                consultaResponse.TipoUsuario = DatosConstantes.TipoUsuario.Remitente;
            }

            var trabajadorDestinatario = listaTrabajador.Where(item => item.CodigoTrabajador == consultaResponse.CodigoDestinatario).FirstOrDefault();
            consultaResponse.NombreDestinatario = (trabajadorDestinatario != null ? trabajadorDestinatario.NombreCompleto : "");

            //
            var trabajadorRemitente = listaTrabajador.Where(item => item.CodigoTrabajador == consultaResponse.CodigoRemitente).FirstOrDefault();
            consultaResponse.NombreRemitente = (trabajadorRemitente != null ? trabajadorRemitente.NombreCompleto : "");

            var trabajadorRemitenteOriginal = listaTrabajador.Where(item => item.CodigoTrabajador == data.CodigoRemitenteOriginal).FirstOrDefault();
            consultaResponse.NombreRemitenteOriginal = (trabajadorRemitenteOriginal != null ? trabajadorRemitenteOriginal.NombreCompleto : "");

            return consultaResponse;
        }

        /// <summary>
        /// Obtiene el responde Bien de una entidad Consulta
        /// </summary>
        /// <param name="objEnt">Objeti entidad</param>
        /// <returns>Entidad Response de objeto Bien</returns>
        public static ConsultaResponse ObtenerConsultaResponseDeEntity(ConsultaEntity data, List<TrabajadorDatoMinimoResponse> listaTrabajador = null)
        {
            ConsultaResponse consultaResponse = new ConsultaResponse();
            consultaResponse.Asunto = data.Asunto;
            consultaResponse.CodigoConsulta = data.CodigoConsulta;
            consultaResponse.CodigoDestinatario = data.CodigoDestinatario;

            if (listaTrabajador != null)
            {
                var trabajadorDestinatario = listaTrabajador.Where(item => item.CodigoTrabajador == data.CodigoDestinatario).FirstOrDefault();
                consultaResponse.NombreDestinatario = (trabajadorDestinatario != null ? trabajadorDestinatario.NombreCompleto : "");

                var trabajadorRemitente = listaTrabajador.Where(item => item.CodigoTrabajador == data.CodigoRemitente).FirstOrDefault();
                consultaResponse.NombreRemitente = (trabajadorRemitente != null ? trabajadorRemitente.NombreCompleto : "");
            }

            consultaResponse.CodigoRemitente = data.CodigoRemitente;
            consultaResponse.Contenido = data.Contenido;
            consultaResponse.EstadoConsulta = data.EstadoConsulta;
            consultaResponse.FechaEnvio = data.FechaEnvio;
            consultaResponse.FechaEnvioString = (data.FechaEnvio.HasValue) ? data.FechaEnvio.Value.ToString("dd/MM/yyyy") : "";
            consultaResponse.FechaRespuesta = data.FechaRespuesta;
            consultaResponse.FechaRespuestaString = (data.FechaRespuesta.HasValue) ? data.FechaRespuesta.Value.ToString("dd/MM/yyyy") : ""; ;
            consultaResponse.Respuesta = data.Respuesta;
            consultaResponse.Tipo = data.Tipo;
            return consultaResponse;
        }

        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Datos a registrar</returns>
        public static ConsultaEntity ObtenerConsultaEntity(ConsultaRequest data)
        {
            ConsultaEntity consultaEntity = new ConsultaEntity();
            if (data.CodigoConsulta != null)
            {
                consultaEntity.CodigoConsulta = new Guid(data.CodigoConsulta);
            }
            else
            {
                consultaEntity.CodigoConsulta = Guid.NewGuid();
            }

            consultaEntity.CodigoRemitente = (data.CodigoRemitente != null ? new Guid(data.CodigoRemitente) : new Guid());
            consultaEntity.CodigoDestinatario = (data.CodigoDestinatario != null ? new Guid(data.CodigoDestinatario) : new Guid());
            consultaEntity.Tipo = data.Tipo;
            consultaEntity.Asunto = data.Asunto;
            consultaEntity.Contenido = data.Contenido;
            consultaEntity.EstadoConsulta = data.EstadoConsulta;
            consultaEntity.FechaEnvio = data.FechaEnvio;
            consultaEntity.Respuesta = data.Respuesta;
            consultaEntity.FechaRespuesta = data.FechaRespuesta;
            consultaEntity.CodigoUnidadOperativa = (string.IsNullOrEmpty(data.CodigoUnidadOperativa) ? (Guid?)null : new Guid(data.CodigoUnidadOperativa));
            consultaEntity.CodigoArea = data.CodigoArea;
            consultaEntity.EsValido = data.EsValido;
            return consultaEntity;
        }

        /// <summary>
        /// Obtiene la entidad response ConsultaAdjuntoResponse de la Entidad ConsultaAdjuntoLogic
        /// </summary>
        /// <param name="logic">entidad logic del Documento Adjunto de la consulta</param>
        /// <returns>Response de el Documento Adjunto al Contrato</returns>
        public static ConsultaAdjuntoResponse ObtenerConsultaAdjuntoResponseDeLogic(ConsultaAdjuntoLogic logic, string usuarioSesion)
        {
            ConsultaAdjuntoResponse response = new ConsultaAdjuntoResponse();
            response.CodigoConsultaAdjunto = logic.CodigoConsultaAdjunto;
            response.CodigoConsulta = logic.CodigoConsulta;
            response.CodigoArchivo = logic.CodigoArchivo;
            response.NombreArchivo = logic.NombreArchivo;
            response.RutaArchivoSharePoint = logic.RutaArchivoSharePoint;
            response.UsuarioCreacion = logic.UsuarioCreacion;
            if (logic.UsuarioCreacion != null)
            {
                response.EsCreador = (logic.UsuarioCreacion.Trim().ToUpper() == usuarioSesion.Trim().ToUpper() ? true : false);
            }
            return response;
        }

        /// <summary>
        /// Obtiene la entidad response ConsultaAdjuntoEntity de la Entidad ConsultaAdjuntoRequest
        /// </summary>
        /// <param name="request">Request del Documento Adjunto al Contrato</param>
        /// <returns>Entity del Documento Adjunto al Contrato</returns>
        public static ConsultaAdjuntoEntity ObtenerConsultaAdjuntoEntityDeRequest(ConsultaAdjuntoRequest request)
        {
            ConsultaAdjuntoEntity response = new ConsultaAdjuntoEntity();
            response.CodigoConsultaAdjunto = request.CodigoConsultaAdjunto.Value;
            response.CodigoConsulta = request.CodigoConsulta.Value;
            response.CodigoArchivo = request.CodigoArchivo.Value;
            response.NombreArchivo = request.NombreArchivo;
            response.RutaArchivoSharePoint = request.RutaArchivoSharePoint;
            return response;
        }

        /// <summary>
        /// Obtiene la entidad response ConsultaAdjuntoEntity de la Entidad ConsultaAdjuntoRequest
        /// </summary>
        /// <param name="request">Request del Documento Adjunto al Contrato</param>
        /// <returns>Entity del Documento Adjunto al Contrato</returns>
        public static ConsultaAdjuntoEntity ObtenerConsultaAdjuntoEntityDeLogic(ConsultaAdjuntoLogic request)
        {
            ConsultaAdjuntoEntity response = new ConsultaAdjuntoEntity();
            response.CodigoConsultaAdjunto = request.CodigoConsultaAdjunto;
            response.CodigoConsulta = request.CodigoConsulta;
            response.CodigoArchivo = request.CodigoArchivo;
            response.NombreArchivo = request.NombreArchivo;
            response.RutaArchivoSharePoint = request.RutaArchivoSharePoint;
            return response;
        }

        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Datos a registrar</returns>
        public static ConsultaEntity ObtenerConsultaEntityDeLogic(ConsultaLogic data)
        {
            ConsultaEntity consultaEntity = new ConsultaEntity();
            if (data.CodigoConsulta != null)
            {
                consultaEntity.CodigoConsulta = data.CodigoConsulta;
            }
            else
            {
                consultaEntity.CodigoConsulta = Guid.NewGuid();
            }

            consultaEntity.CodigoRemitente = (data.CodigoRemitente != null ? data.CodigoRemitente : new Guid());
            consultaEntity.CodigoDestinatario = (data.CodigoDestinatario != null ? data.CodigoDestinatario : new Guid());
            consultaEntity.Tipo = data.Tipo;
            consultaEntity.Asunto = data.Asunto;
            consultaEntity.Contenido = data.Contenido;
            consultaEntity.EstadoConsulta = data.EstadoConsulta;
            consultaEntity.FechaEnvio = data.FechaEnvio;
            consultaEntity.Respuesta = data.Respuesta;
            consultaEntity.FechaRespuesta = data.FechaRespuesta;
            consultaEntity.CodigoUnidadOperativa = (data.CodigoUnidadOperativa.HasValue) ? data.CodigoUnidadOperativa : (Guid?)null;
            consultaEntity.CodigoArea = data.CodigoArea;
            return consultaEntity;
        }
    }
}

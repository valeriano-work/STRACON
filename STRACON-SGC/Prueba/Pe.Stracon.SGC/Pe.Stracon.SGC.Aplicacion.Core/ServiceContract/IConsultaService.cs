using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Core.ServiceContract
{
    /// <summary>
    /// Servicio que representa las consultas
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150710 <br />
    /// Modificación: <br />
    /// </remarks>
    public interface IConsultaService : IGenericService
    {
        /// <summary>
        /// Realiza la búsqueda de consultas
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de contratos</returns>
        ProcessResult<List<ConsultaResponse>> ListadoConsulta(ConsultaRequest filtro);
        /// <summary>
        /// Retorna información de la consulta.
        /// </summary>
        /// <param name="codigoBien">código de la consulta</param>
        /// <returns>Información de la consulta</returns>
        ProcessResult<ConsultaResponse> ConsultaPorId(Guid codigoConsulta);

        /// <summary>
        /// Registra / Edita Consulta
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<ConsultaRequest> RegistrarConsulta(ConsultaRequest data);

        /// <summary>
        /// Reenvia Consulta
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<ConsultaRequest> ReenviarConsulta(ConsultaRequest data);

        /// <summary>
        /// Eliminar Consulta
        /// </summary>
        /// <param name="listaCodigoContrato">Lista de Códigos de consultas a Eliminar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        ProcessResult<object> EliminarConsulta(List<object> listaCodigoConsulta);

        /// <summary>
        /// Método para retornar los documentos adjuntos por Contrato
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        ProcessResult<List<ConsultaAdjuntoResponse>> BuscarConsultaAdjunto(ConsultaAdjuntoRequest request);

        /// <summary>
        /// Método para registra los documentos adjuntos de la consulta
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        ProcessResult<string> RegistrarConsultaAdjunto(ConsultaAdjuntoRequest request);

        /// <summary>
        /// Método que elimina los documentos adjuntos al Contrato
        /// </summary>
        /// <param name="request">Filtro</param>
        /// <returns>Documentos adjuntos al contrato</returns>
        ProcessResult<string> EliminarConsultaAdjunto(ConsultaAdjuntoRequest request);

         /// <summary>
        /// Metodo que retorna los bytes para la generación del archivo PDF.
        /// </summary>
        /// <param name="codigoContrato">Código del Contrato</param>
        /// <param name="codigoContratoEstadio">código del Contrato - estadio.</param>
        /// <param name="NombreArchivoContrato">Nombre del archivo a descargar</param>
        /// <returns>Bytes para generar pdf</returns>
        ProcessResult<ConsultaAdjuntoResponse> ObtenerArchivoAdjunto(ConsultaAdjuntoRequest request);

       
    }
}

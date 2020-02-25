using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
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
    public sealed class FlujoAprobacionParticipanteAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Datos a registrar</returns>
        public static FlujoAprobacionParticipanteEntity RegistrarFlujoAprobacionParticipante(FlujoAprobacionParticipanteRequest data)
        {
            FlujoAprobacionParticipanteEntity flujoAprobacionParticipanteEntity = new FlujoAprobacionParticipanteEntity();
            if (data.CodigoFlujoAprobacionParticipante != null)
            {
                flujoAprobacionParticipanteEntity.CodigoFlujoAprobacionParticipante = new Guid(data.CodigoFlujoAprobacionParticipante);
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                flujoAprobacionParticipanteEntity.CodigoFlujoAprobacionParticipante = code;
            }

            flujoAprobacionParticipanteEntity.CodigoFlujoAprobacionEstadio = new Guid(data.CodigoFlujoAprobacionEstadio);
            flujoAprobacionParticipanteEntity.CodigoTrabajador = new Guid(data.CodigoTrabajador);
            flujoAprobacionParticipanteEntity.CodigoTipoParticipante = data.CodigoTipoParticipante;
            flujoAprobacionParticipanteEntity.EstadoRegistro = data.EstadoRegistro;
            flujoAprobacionParticipanteEntity.CodigoTrabajadorOriginal = flujoAprobacionParticipanteEntity.CodigoTrabajador;

            return flujoAprobacionParticipanteEntity;
        }

        /// <summary>
        /// Realiza la adaptación de campos para listar de logic a response
        /// </summary>
        /// <param name="data">Datos a listar</param>
        /// <returns>Entidad Datos a registrar</returns>
        public static FlujoAprobacionParticipanteResponse ObtenerFlujoAprobacionParticipanteResponse(FlujoAprobacionParticipanteLogic data)
        {
            FlujoAprobacionParticipanteResponse flujoAprobacionParticipanteResponse = new FlujoAprobacionParticipanteResponse();

            flujoAprobacionParticipanteResponse.CodigoFlujoAprobacionEstadio = data.CodigoFlujoAprobacionEstadio.ToString();
            flujoAprobacionParticipanteResponse.CodigoTrabajador = data.CodigoTrabajador;
            flujoAprobacionParticipanteResponse.CodigoTipoParticipante = data.CodigoTipoParticipante;
            flujoAprobacionParticipanteResponse.OrdenFirmante = data.OrdenFirmante;
            flujoAprobacionParticipanteResponse.IndicadorEsFirmante = data.IndicadorEsFirmante;
            return flujoAprobacionParticipanteResponse;
        }
    }
}

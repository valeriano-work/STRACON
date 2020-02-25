using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementación del Adaptador de Contrato Estadio
    /// </summary>
    public class ContratoEstadioAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Contrato Estadio con los datos a registrar</returns>
        public static ContratoEstadioEntity RegistrarContratoEstadio(ContratoEstadioRequest data)
        {
            var contratoEstadioEntity = new ContratoEstadioEntity();

            if (data.CodigoContratoEstadio != null)
            {
                contratoEstadioEntity.CodigoContratoEstadio = new Guid(data.CodigoContratoEstadio.ToString());
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                contratoEstadioEntity.CodigoContratoEstadio = code;
            }

            contratoEstadioEntity.CodigoContrato = (Guid)data.CodigoContrato;
            contratoEstadioEntity.CodigoFlujoAprobacionEstadio = (Guid)data.CodigoFlujoAprobacionEstadio;
            contratoEstadioEntity.FechaIngreso = data.FechaIngreso;
            contratoEstadioEntity.FechaFinalizacion = data.FechaFinalizacion;
            contratoEstadioEntity.CodigoResponsable = data.CodigoResponsable;
            contratoEstadioEntity.CodigoEstadoContratoEstadio = data.CodigoEstadoContratoEstadio;
            contratoEstadioEntity.FechaPrimeraNotificacion = data.FechaPrimeraNotificacion;
            contratoEstadioEntity.FechaUltimaNotificacion = data.FechaUltimaNotificacion;
            contratoEstadioEntity.FechaCreacion = DateTime.Now;

            return contratoEstadioEntity;
        }
    }
}

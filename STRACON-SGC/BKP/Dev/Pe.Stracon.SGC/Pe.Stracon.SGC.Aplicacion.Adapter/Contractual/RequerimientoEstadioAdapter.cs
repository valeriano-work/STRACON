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
    /// Implementación del Adaptador de Requerimiento Estadio
    /// </summary>
    public class RequerimientoEstadioAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Requerimiento Estadio con los datos a registrar</returns>
        public static RequerimientoEstadioEntity RegistrarRequerimientoEstadio(RequerimientoEstadioRequest data)
        {
            var contratoEstadioEntity = new RequerimientoEstadioEntity();

            if (data.CodigoRequerimientoEstadio != null)
            {
                contratoEstadioEntity.CodigoRequerimientoEstadio = new Guid(data.CodigoRequerimientoEstadio.ToString());
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                contratoEstadioEntity.CodigoRequerimientoEstadio = code;
            }

            contratoEstadioEntity.CodigoRequerimiento = (Guid)data.CodigoRequerimiento;
            contratoEstadioEntity.CodigoFlujoAprobacionEstadio = (Guid)data.CodigoFlujoAprobacionEstadio;
            contratoEstadioEntity.FechaIngreso = data.FechaIngreso;
            contratoEstadioEntity.FechaFinalizacion = data.FechaFinalizacion;
            contratoEstadioEntity.CodigoResponsable = data.CodigoResponsable;
            contratoEstadioEntity.CodigoEstadoRequerimientoEstadio = data.CodigoEstadoRequerimientoEstadio;
            contratoEstadioEntity.FechaPrimeraNotificacion = data.FechaPrimeraNotificacion;
            contratoEstadioEntity.FechaUltimaNotificacion = data.FechaUltimaNotificacion;
            contratoEstadioEntity.FechaCreacion = DateTime.Now;

            return contratoEstadioEntity;
        }
    }
}

using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementación del Adaptador de RequerimientoFirmante 
    /// </summary>
    public sealed class RequerimientoFirmanteAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Requerimiento Bien con los datos a registrar</returns>
        public static RequerimientoFirmanteEntity RegistrarRequerimientoFirmante(RequerimientoFirmanteRequest data)
        {
            var contratoFirmanteEntity = new RequerimientoFirmanteEntity();


            if (data.CodigoRequerimientoFirmante != null)
            {
                contratoFirmanteEntity.CodigoRequerimientoFirmante = new Guid(data.CodigoRequerimientoFirmante.ToString());
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                contratoFirmanteEntity.CodigoRequerimientoFirmante = code;
            }

            contratoFirmanteEntity.CodigoRequerimientoParrafoVariable = new Guid(data.CodigoRequerimientoParrafoVariable);
            contratoFirmanteEntity.NombreFirmante = data.NombreFirmante;
            contratoFirmanteEntity.DatoAdicional = data.DatoAdicional;
            contratoFirmanteEntity.FechaCreacion = DateTime.Now;

            return contratoFirmanteEntity;
        }
    }
}

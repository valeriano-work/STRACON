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
    /// Implementación del Adaptador de ContratoFirmante 
    /// </summary>
    public sealed class ContratoFirmanteAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Contrato Bien con los datos a registrar</returns>
        public static ContratoFirmanteEntity RegistrarContratoFirmante(ContratoFirmanteRequest data)
        {
            var contratoFirmanteEntity = new ContratoFirmanteEntity();


            if (data.CodigoContratoFirmante != null)
            {
                contratoFirmanteEntity.CodigoContratoFirmante = new Guid(data.CodigoContratoFirmante.ToString());
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                contratoFirmanteEntity.CodigoContratoFirmante = code;
            }

            contratoFirmanteEntity.CodigoContratoParrafoVariable = new Guid(data.CodigoContratoParrafoVariable);
            contratoFirmanteEntity.NombreFirmante = data.NombreFirmante;
            contratoFirmanteEntity.DatoAdicional = data.DatoAdicional;
            contratoFirmanteEntity.FechaCreacion = DateTime.Now;

            return contratoFirmanteEntity;
        }
    }
}

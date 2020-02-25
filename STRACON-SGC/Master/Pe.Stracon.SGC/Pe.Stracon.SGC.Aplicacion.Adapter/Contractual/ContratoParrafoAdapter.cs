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
    /// Implementación del Adaptador de Contrato Párrafo
    /// </summary>
    public class ContratoParrafoAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Contrato Párrafo con los datos a registrar</returns>
        public static ContratoParrafoEntity RegistrarContratoParrafo(ContratoParrafoRequest data)
        {
            var contratoParrafoEntity = new ContratoParrafoEntity();

            if (data.CodigoContratoParrafo != null)
            {
                contratoParrafoEntity.CodigoContratoParrafo = new Guid(data.CodigoContratoParrafo.ToString());
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                contratoParrafoEntity.CodigoContratoParrafo = code;
            }

            contratoParrafoEntity.CodigoContrato = new Guid(data.CodigoContrato);
            contratoParrafoEntity.CodigoPlantillaParrafo = new Guid(data.CodigoPlantillaParrafo);
            contratoParrafoEntity.FechaCreacion = DateTime.Now;
            contratoParrafoEntity.ContenidoParrafo = data.ContenidoParrafo;
            return contratoParrafoEntity;
        }
    }
}

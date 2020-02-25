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
    /// Implementación del Adaptador de Requerimiento Párrafo
    /// </summary>
    public class RequerimientoParrafoAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Requerimiento Párrafo con los datos a registrar</returns>
        public static RequerimientoParrafoEntity RegistrarRequerimientoParrafo(RequerimientoParrafoRequest data)
        {
            var contratoParrafoEntity = new RequerimientoParrafoEntity();

            if (data.CodigoRequerimientoParrafo != null)
            {
                contratoParrafoEntity.CodigoRequerimientoParrafo = new Guid(data.CodigoRequerimientoParrafo.ToString());
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                contratoParrafoEntity.CodigoRequerimientoParrafo = code;
            }

            contratoParrafoEntity.CodigoRequerimiento = new Guid(data.CodigoRequerimiento);
            contratoParrafoEntity.CodigoPlantillaParrafo = new Guid(data.CodigoPlantillaParrafo);
            contratoParrafoEntity.FechaCreacion = DateTime.Now;
            contratoParrafoEntity.ContenidoParrafo = data.ContenidoParrafo;
            return contratoParrafoEntity;
        }
    }
}

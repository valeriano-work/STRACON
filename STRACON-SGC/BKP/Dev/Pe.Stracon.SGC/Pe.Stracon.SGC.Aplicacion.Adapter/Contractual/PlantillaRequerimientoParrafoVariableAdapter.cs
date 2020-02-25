using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
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
    /// Implementacion del Adaptador de Plantilla Párrafo Variable
    /// </summary>
    public class PlantillaRequerimientoParrafoVariableAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="plantillaParrafoVariableLogic">Entidad lógica Plantilla Párrafo Variable para la búsqueda</param>
        /// <returns>Clase Plantilla Párrafo Variable Response con los datos de búsqueda</returns>
        public static PlantillaRequerimientoParrafoVariableResponse ObtenerPlantillaParrafoVariable(PlantillaRequerimientoParrafoVariableLogic plantillaParrafoVariableLogic)
        {
            var plantillaParrafoVariableResponse = new PlantillaRequerimientoParrafoVariableResponse();

            plantillaParrafoVariableResponse.CodigoPlantillaParrafoVariable = plantillaParrafoVariableLogic.CodigoPlantillaParrafoVariable;
            plantillaParrafoVariableResponse.CodigoPlantillaParrafo = plantillaParrafoVariableLogic.CodigoPlantillaParrafo;
            plantillaParrafoVariableResponse.CodigoVariable = plantillaParrafoVariableLogic.CodigoVariable;
            plantillaParrafoVariableResponse.Orden = plantillaParrafoVariableLogic.Orden;
            plantillaParrafoVariableResponse.CodigoTipoVariable = plantillaParrafoVariableLogic.CodigoTipoVariable;
            plantillaParrafoVariableResponse.NombreVariable = plantillaParrafoVariableLogic.NombreVariable;
            plantillaParrafoVariableResponse.IdentificadorVariable = plantillaParrafoVariableLogic.IdentificadorVariable;
            plantillaParrafoVariableResponse.DescripcionVariable = plantillaParrafoVariableLogic.DescripcionVariable;
            return plantillaParrafoVariableResponse;
        }

        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Plantilla Párrafo Variable con los datos a registrar</returns>
        public static PlantillaRequerimientoParrafoVariableEntity RegistrarPlantillaParrafoVariable(PlantillaRequerimientoParrafoVariableRequest data)
        {
            var plantillaParrafoVariableEntity = new PlantillaRequerimientoParrafoVariableEntity();

            if (data.CodigoPlantillaParrafoVariable != null)
            {
                plantillaParrafoVariableEntity.CodigoPlantillaParrafoVariable = new Guid(data.CodigoPlantillaParrafoVariable);
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                plantillaParrafoVariableEntity.CodigoPlantillaParrafoVariable = code;
            }


            plantillaParrafoVariableEntity.CodigoPlantillaParrafo = new Guid(data.CodigoPlantillaParrafo);
            plantillaParrafoVariableEntity.CodigoVariable = new Guid(data.CodigoVariable);
            plantillaParrafoVariableEntity.Orden = Convert.ToInt16(data.Orden);

            return plantillaParrafoVariableEntity;
        }
    }
}

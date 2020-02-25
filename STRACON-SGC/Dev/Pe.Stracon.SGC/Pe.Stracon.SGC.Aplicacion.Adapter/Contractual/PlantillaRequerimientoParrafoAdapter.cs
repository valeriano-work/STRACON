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
    /// Implementacion del Adaptador de Plantilla Párrafo
    /// </summary>
    public class PlantillaRequerimientoParrafoAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="plantillaParrafoLogic">Entidad Lógica Plantilla Párrafo</param>
        /// <returns>Clase Plantilla Párrafo Response con los datos de búsqueda</returns>
        public static PlantillaRequerimientoParrafoResponse ObtenerPlantillaParrafoPaginado(PlantillaRequerimientoParrafoLogic plantillaParrafoLogic)
        {
            var plantillaParrafoResponse = new PlantillaRequerimientoParrafoResponse();

            plantillaParrafoResponse.CodigoPlantillaParrafo = plantillaParrafoLogic.CodigoPlantillaParrafo;
            plantillaParrafoResponse.CodigoPlantilla = plantillaParrafoLogic.CodigoPlantilla;
            plantillaParrafoResponse.Orden = plantillaParrafoLogic.Orden;
            plantillaParrafoResponse.Titulo = plantillaParrafoLogic.Titulo;
            plantillaParrafoResponse.Contenido = plantillaParrafoLogic.Contenido;

            return plantillaParrafoResponse;
        }

        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Plantilla Párrafo con los datos a registrar</returns>
        public static PlantillaRequerimientoParrafoEntity RegistrarPlantillaParrafo(PlantillaRequerimientoParrafoRequest data)
        {
            var plantillaParrafoEntity = new PlantillaRequerimientoParrafoEntity();

            if (data.CodigoPlantillaParrafo != null)
            {
                plantillaParrafoEntity.CodigoPlantillaParrafo = new Guid(data.CodigoPlantillaParrafo);
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                plantillaParrafoEntity.CodigoPlantillaParrafo = code;
            }

            plantillaParrafoEntity.CodigoPlantilla = new Guid(data.CodigoPlantilla);
            plantillaParrafoEntity.Orden = Convert.ToByte(data.Orden);
            plantillaParrafoEntity.Titulo = data.Titulo;

            //Mejorar visibilidad de etiqueta sup
            if (data.Contenido.Contains("<sup>"))
            {
               data.Contenido = data.Contenido.Replace("<sup>", "<span style='font-size: 6px; vertical-align:super;'>");
               data.Contenido = data.Contenido.Replace("</sup>", "</span>");
            }

            plantillaParrafoEntity.Contenido = data.Contenido;

            return plantillaParrafoEntity;
        }
    }
}

using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementacion del Adaptador de Plantilla
    /// </summary>
    public sealed class PlantillaRequerimientoAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="plantillaLogic">Entidad Lógica Plantilla</param>  
        /// <param name="estadoVigencia">Lista de Estados de Vigencia</param>
        /// <returns>Clase Plantilla Response con los datos de búsqueda</returns>
        public static PlantillaRequerimientoResponse ObtenerPlantillaPaginado(PlantillaRequerimientoLogic plantillaLogic, List<CodigoValorResponse> estadoVigencia)
        {           
            string descripcionEstadoVigencia = null;
            if (estadoVigencia != null)
            {
                var eVigencia = estadoVigencia.Where(n => n.Codigo.ToString() == plantillaLogic.CodigoEstadoVigencia).FirstOrDefault();
                descripcionEstadoVigencia = (eVigencia == null ? null : eVigencia.Valor.ToString());
            }

            var plantillaResponse = new PlantillaRequerimientoResponse();

            plantillaResponse.CodigoPlantilla = plantillaLogic.CodigoPlantilla;
            plantillaResponse.Descripcion = plantillaLogic.Descripcion;
            plantillaResponse.CodigoEstadoVigencia = plantillaLogic.CodigoEstadoVigencia;
            plantillaResponse.DescripcionEstadoVigencia = descripcionEstadoVigencia;
            plantillaResponse.IndicadorAdhesion = plantillaLogic.IndicadorAdhesion;
            plantillaResponse.FechaInicioVigencia = plantillaLogic.FechaInicioVigenciaDate;
            plantillaResponse.FechaInicioVigenciaString = plantillaLogic.FechaInicioVigenciaDate.ToString(DatosConstantes.Formato.FormatoFecha);
            plantillaResponse.FechaFinVigencia = plantillaLogic.FechaFinVigenciaDate;
            plantillaResponse.FechaFinVigenciaString = plantillaLogic.FechaFinVigenciaDate.HasValue ? plantillaLogic.FechaFinVigenciaDate.Value.ToString(DatosConstantes.Formato.FormatoFecha) : string.Empty;
            return plantillaResponse;
        }

        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Plantilla con los datos a registrar</returns>
        public static PlantillaRequerimientoEntity RegistrarPlantilla(PlantillaRequerimientoRequest data)
        {
            var plantillaRequerimientoEntity = new PlantillaRequerimientoEntity();

            if (data.CodigoPlantilla != null)
            {
                plantillaRequerimientoEntity.CodigoPlantilla = new Guid(data.CodigoPlantilla);
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                plantillaRequerimientoEntity.CodigoPlantilla = code;
            }

            plantillaRequerimientoEntity.Descripcion = data.Descripcion;
            plantillaRequerimientoEntity.CodigoEstadoVigencia = data.CodigoEstadoVigencia;
            plantillaRequerimientoEntity.IndicadorAdhesion = Convert.ToBoolean(data.IndicadorAdhesion);
            plantillaRequerimientoEntity.FechaInicioVigencia = DateTime.ParseExact(data.FechaInicioVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
            return plantillaRequerimientoEntity;
        }
    }
}

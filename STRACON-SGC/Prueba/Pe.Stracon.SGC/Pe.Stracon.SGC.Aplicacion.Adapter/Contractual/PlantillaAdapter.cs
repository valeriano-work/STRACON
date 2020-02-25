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
    public sealed class PlantillaAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="plantillaLogic">Entidad Lógica Plantilla</param>
        /// <param name="tipoServicio">Lista de Tipos de Servicios</param>
        /// <param name="tipoDocumentoContrato">Lista de Documentos de Contratos</param>
        /// <param name="estadoVigencia">Lista de Estados de Vigencia</param>
        /// <returns>Clase Plantilla Response con los datos de búsqueda</returns>
        public static PlantillaResponse ObtenerPlantillaPaginado(PlantillaLogic plantillaLogic, List<CodigoValorResponse> tipoServicio, List<CodigoValorResponse> tipoDocumentoContrato, List<CodigoValorResponse> estadoVigencia)
        {
            string descripcionTipoContrato = null;
            string descripcionTipoDocumentoContrato = null;
            string descripcionEstadoVigencia = null;

            if (tipoServicio != null)
            {
                var tServicio = tipoServicio.Where(n => n.Codigo.ToString() == plantillaLogic.CodigoTipoContrato).FirstOrDefault();
                descripcionTipoContrato = (tServicio == null ? null : tServicio.Valor.ToString());
            }
            
            if (tipoDocumentoContrato != null)
            {
                var tDocumentoContrato = tipoDocumentoContrato.Where(n => n.Codigo.ToString() == plantillaLogic.CodigoTipoDocumentoContrato).FirstOrDefault();
                descripcionTipoDocumentoContrato = (tDocumentoContrato == null ? null : tDocumentoContrato.Valor.ToString());
            }

            if (estadoVigencia != null)
            {
                var eVigencia = estadoVigencia.Where(n => n.Codigo.ToString() == plantillaLogic.CodigoEstadoVigencia).FirstOrDefault();
                descripcionEstadoVigencia = (eVigencia == null ? null : eVigencia.Valor.ToString());
            }

            var plantillaResponse = new PlantillaResponse();

            plantillaResponse.CodigoPlantilla = plantillaLogic.CodigoPlantilla;
            plantillaResponse.Descripcion = plantillaLogic.Descripcion;
            plantillaResponse.CodigoTipoContrato = plantillaLogic.CodigoTipoContrato;
            plantillaResponse.DescripcionTipoContrato = descripcionTipoContrato;
            plantillaResponse.CodigoTipoDocumentoContrato = plantillaLogic.CodigoTipoDocumentoContrato;
            plantillaResponse.DescripcionTipoDocumentoContrato = descripcionTipoDocumentoContrato;
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
        public static PlantillaEntity RegistrarPlantilla(PlantillaRequest data)
        {
            var plantillaEntity = new PlantillaEntity();

            if (data.CodigoPlantilla != null)
            {
                plantillaEntity.CodigoPlantilla = new Guid(data.CodigoPlantilla);
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                plantillaEntity.CodigoPlantilla = code;
            }

            plantillaEntity.Descripcion = data.Descripcion;
            plantillaEntity.CodigoTipoContrato = data.CodigoTipoContrato;
            plantillaEntity.CodigoTipoDocumentoContrato = data.CodigoTipoDocumentoContrato;
            plantillaEntity.CodigoEstadoVigencia = data.CodigoEstadoVigencia;
            plantillaEntity.IndicadorAdhesion = Convert.ToBoolean(data.IndicadorAdhesion);
            plantillaEntity.FechaInicioVigencia = DateTime.ParseExact(data.FechaInicioVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);

            return plantillaEntity;
        }
    }
}

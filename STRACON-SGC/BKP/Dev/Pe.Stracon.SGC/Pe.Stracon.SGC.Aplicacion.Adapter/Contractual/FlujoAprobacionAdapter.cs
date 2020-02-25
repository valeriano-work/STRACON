using System;
using System.Collections.Generic;
using System.Linq;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;


namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementacion del adaptador de Flujo Aprobacion
    /// </summary>
    public sealed class FlujoAprobacionAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="flujoAprobacionLogic">Entidad Logica de flujo aprobacion</param>
        /// <param name="flujoAprobacionTipoServicioLogic">Entidad Logica de flujo aprobacion tipo de servicio</param>
        /// <param name="unidadOperativa">Lista Unidad Operativa</param>
        /// <param name="tipoServicio">Lista Tipo Servicio</param>
        /// <returns>Clase Flujo Aprobacion con los datos de búsqueda</returns>
        public static FlujoAprobacionResponse ObtenerFlujoAprobacion(
            FlujoAprobacionLogic flujoAprobacionLogic,
            List<FlujoAprobacionTipoContratoLogic> flujoAprobacionTipoContratoLogic,
            List<UnidadOperativaResponse> unidadOperativa,
            List<CodigoValorResponse> tipoContrato      
        )
        {
            string sUnidadOperativa = null;
           // string sTipoServicio = null;
            string sTipoContrato = null;

            if (unidadOperativa != null)
            {
                var uoperativa = unidadOperativa.Where(n => n.CodigoUnidadOperativa.ToString() == flujoAprobacionLogic.CodigoUnidadOperativa.ToString()).FirstOrDefault();
                sUnidadOperativa = (uoperativa == null ? null : uoperativa.Nombre.ToString());
            }

            var listaTipoContrato = new List<string>();
            foreach (var item in flujoAprobacionTipoContratoLogic)
            {
                if (tipoContrato != null)
                {
                    var servicio = tipoContrato.Where(n => n.Codigo.ToString() == item.CodigoTipoContrato).FirstOrDefault();
                    if (servicio != null)
                    {
                        listaTipoContrato.Add(servicio.Valor.ToString());
                    }
                    
                }
            }
            listaTipoContrato = listaTipoContrato.OrderBy(item => item).ToList();

            foreach (var contrato in listaTipoContrato)
            {
                sTipoContrato = sTipoContrato + (contrato == null ? null : contrato + ", ");
            }

            if (!string.IsNullOrEmpty(sTipoContrato))
            {
                sTipoContrato = sTipoContrato.Substring(0, sTipoContrato.Length - 2);
            }
            

            var flujoAprobacionResponse = new FlujoAprobacionResponse();

            flujoAprobacionResponse.CodigoFlujoAprobacion = flujoAprobacionLogic.CodigoFlujoAprobacion.ToString();
            flujoAprobacionResponse.CodigoUnidadOperativa = flujoAprobacionLogic.CodigoUnidadOperativa.ToString();
            flujoAprobacionResponse.DescripcionUnidadOperativa = sUnidadOperativa;
           // flujoAprobacionResponse.DescripcionTipoContrato = sTipoContrato;
            flujoAprobacionResponse.ListaTipoServicio = flujoAprobacionTipoContratoLogic.Select(item => item.CodigoTipoContrato).ToList();
            flujoAprobacionResponse.DescripcionTipoContrato = sTipoContrato;
            flujoAprobacionResponse.IndicadorAplicaMontoMinimo = flujoAprobacionLogic.IndicadorAplicaMontoMinimo;
            flujoAprobacionResponse.CodigoPrimerFirmante = flujoAprobacionLogic.CodigoPrimerFirmante.ToString();
            flujoAprobacionResponse.CodigoSegundoFirmante = flujoAprobacionLogic.CodigoSegundoFirmante.ToString();
            flujoAprobacionResponse.IndicadorAplicaMontoMinimo = flujoAprobacionLogic.IndicadorAplicaMontoMinimo;

            if (flujoAprobacionLogic.CodigoPrimerFirmanteVinculada != null)
            {
                flujoAprobacionResponse.CodigoPrimerFirmanteVinculada = flujoAprobacionLogic.CodigoPrimerFirmanteVinculada.ToString();
            }

            if (flujoAprobacionLogic.CodigoSegundoFirmanteVinculada != null)
            {
                flujoAprobacionResponse.CodigoSegundoFirmanteVinculada = flujoAprobacionLogic.CodigoSegundoFirmanteVinculada.ToString();
            }

            return flujoAprobacionResponse;
        }

        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Datos a registrar</returns>
        public static FlujoAprobacionEntity RegistrarFlujoAprobacion(FlujoAprobacionRequest data)
        {
            FlujoAprobacionEntity flujoAprobacionEntity = new FlujoAprobacionEntity();
            if (data.CodigoFlujoAprobacion != null)
            {
                flujoAprobacionEntity.CodigoFlujoAprobacion = new Guid(data.CodigoFlujoAprobacion);
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                flujoAprobacionEntity.CodigoFlujoAprobacion = code;
            }

            //flujoAprobacionEntity.CodigoFlujoAprobacion = data.CodigoFlujoAprobacion;
            flujoAprobacionEntity.CodigoUnidadOperativa = new Guid(data.CodigoUnidadOperativa);
            //flujoAprobacionEntity.CodigoTipoServicio = null;//data.CodigoTipoServicio;
            flujoAprobacionEntity.IndicadorAplicaMontoMinimo = data.IndicadorAplicaMontoMinimo.Value;
            flujoAprobacionEntity.EstadoRegistro = data.EstadoRegistro;
            flujoAprobacionEntity.CodigoPrimerFirmante = new Guid(data.CodigoPrimerFirmante);
            flujoAprobacionEntity.CodigoPrimerFirmanteOriginal = flujoAprobacionEntity.CodigoPrimerFirmante;

            if (data.CodigoSegundoFirmante != null)
            {
                flujoAprobacionEntity.CodigoSegundoFirmante = new Guid(data.CodigoSegundoFirmante);
                flujoAprobacionEntity.CodigoSegundoFirmanteOriginal = flujoAprobacionEntity.CodigoSegundoFirmante;
            }

            if (data.CodigoPrimerFirmanteVinculada != null)
            {
                flujoAprobacionEntity.CodigoPrimerFirmanteVinculada = new Guid(data.CodigoPrimerFirmanteVinculada);
            }

            if (data.CodigoSegundoFirmanteVinculada != null)
            {
                flujoAprobacionEntity.CodigoSegundoFirmanteVinculada = new Guid(data.CodigoSegundoFirmanteVinculada);
            }


            return flujoAprobacionEntity;
        }
    }
}

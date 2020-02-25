using Pe.Stracon.Politicas.Aplicacion.Core.Base;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
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
    /// Implementacion del adaptador de Flujo Aprobacion
    /// </summary>
    public sealed class FlujoAprobacionEstadioAdapter
    {
        /// <summary>
        /// Servicio de trabajador
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }

        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Datos a registrar</returns>
        public static FlujoAprobacionEstadioEntity RegistrarFlujoAprobacionEstadio(FlujoAprobacionEstadioRequest data)
        {
            FlujoAprobacionEstadioEntity flujoAprobacionEstadioEntity = new FlujoAprobacionEstadioEntity();
            if (data.CodigoFlujoAprobacionEstadio != null)
            {
                flujoAprobacionEstadioEntity.CodigoFlujoAprobacionEstadio = new Guid(data.CodigoFlujoAprobacionEstadio);
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                flujoAprobacionEstadioEntity.CodigoFlujoAprobacionEstadio = code;
            }
            flujoAprobacionEstadioEntity.CodigoFlujoAprobacion = new Guid(data.CodigoFlujoAprobacion);
            flujoAprobacionEstadioEntity.Orden = data.Orden;
            flujoAprobacionEstadioEntity.Descripcion = data.Descripcion;
            flujoAprobacionEstadioEntity.TiempoAtencion = data.TiempoAtencion;
            flujoAprobacionEstadioEntity.HorasAtencion = data.HorasAtencion;
            flujoAprobacionEstadioEntity.IndicadorVersionOficial = data.IndicadorVersionOficial;
            flujoAprobacionEstadioEntity.IndicadorPermiteCarga = data.IndicadorPermiteCarga;
            flujoAprobacionEstadioEntity.IndicadorNumeroContrato = data.IndicadorNumeroContrato;
            flujoAprobacionEstadioEntity.EstadoRegistro = data.EstadoRegistro;
            flujoAprobacionEstadioEntity.IndicadorIncluirVisto = data.IndicadorIncluirVisto;
            
            return flujoAprobacionEstadioEntity;
        }

        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="flujoAprobacionEstadioLogic">Entidad Logica de flujo aprobacion</param>
        /// <param name="listaRepresentantes">Lista representantes</param>
        /// <param name="listaInformados">Lista Informados</param>
        /// <param name="listaResponsablesVinculadas">Responsables vinculadas</param>
        /// <returns>Clase Flujo Aprobacion con los datos de búsqueda</returns>
        public static FlujoAprobacionEstadioResponse ObtenerFlujoAprobacionEstadio(FlujoAprobacionEstadioLogic flujoAprobacionEstadioLogic, List<TrabajadorResponse> listaRepresentantes, List<TrabajadorResponse> listaInformados, List<TrabajadorResponse> listaResponsablesVinculadas)
        {
            var flujoAprobacionEstadioResponse = new FlujoAprobacionEstadioResponse();
            

            if (listaRepresentantes != null)
            {
                flujoAprobacionEstadioResponse.ListaNombreRepresentante = listaRepresentantes.ToDictionary(x => x.CodigoTrabajador, y => y.NombreCompleto);
                
                string[] as_trab = flujoAprobacionEstadioLogic.CodigosRepresentante.Split('/');
                string nomTrab = string.Empty;
                int li_find = -1;
                if (flujoAprobacionEstadioLogic.CodigosRepresentante.Trim().Length > 1)
                {
                    for (int li = 1; li < as_trab.Length; li++)
                    {
                        li_find = listaRepresentantes.FindIndex(x => x.CodigoTrabajador.ToString().ToLower().Equals(as_trab[li].ToLower()));
                        
                        if (li_find != -1)
                        {
                            nomTrab = listaRepresentantes[li_find].NombreCompleto;
                            flujoAprobacionEstadioResponse.NombreRepresentante += "<span>" + nomTrab + "</span><br/>";
                        }
                    }
                }
                else
                {
                    flujoAprobacionEstadioResponse.NombreRepresentante = "";
                }
            }

            if (listaInformados != null)
            {
                flujoAprobacionEstadioResponse.ListaNombreInformado = listaInformados.ToDictionary(x => x.CodigoTrabajador, y => y.NombreCompleto);

                string[] as_trab = flujoAprobacionEstadioLogic.CodigosInformado.Split('/');
                string nomTrab = string.Empty;
                int li_find = -1;
                if (flujoAprobacionEstadioLogic.CodigosInformado.Trim().Length > 1)
                {
                    for (int li = 1; li < as_trab.Length; li++)
                    {
                        li_find = listaInformados.FindIndex(x => x.CodigoTrabajador.ToString().ToLower().Equals(as_trab[li].ToLower()));
                        
                        if (li_find != -1)
                        {
                            nomTrab = listaInformados[li_find].NombreCompleto;
                            flujoAprobacionEstadioResponse.NombreInformado += "<span>" + nomTrab + "</span><br/>";
                        }
                    }
                }
                else
                {
                    flujoAprobacionEstadioResponse.NombreInformado = "";
                }
            }


            if (listaResponsablesVinculadas != null)
            {
                flujoAprobacionEstadioResponse.ListaNombreResponsableVinculadas = listaResponsablesVinculadas.ToDictionary(x => x.CodigoTrabajador, y => y.NombreCompleto);

                string[] as_trab = flujoAprobacionEstadioLogic.CodigosResponsableVinculadas.Split('/');
                string nomTrab = string.Empty;
                int li_find = -1;
                if (flujoAprobacionEstadioLogic.CodigosResponsableVinculadas.Trim().Length > 1)
                {
                    for (int li = 1; li < as_trab.Length; li++)
                    {
                        li_find = listaResponsablesVinculadas.FindIndex(x => x.CodigoTrabajador.ToString().ToLower().Equals(as_trab[li].ToLower()));

                        if (li_find != -1)
                        {
                            nomTrab = listaResponsablesVinculadas[li_find].NombreCompleto;
                            flujoAprobacionEstadioResponse.NombreResponsableVinculadas += "<span>" + nomTrab + "</span><br/>";
                        }
                    }
                }
                else
                {
                    flujoAprobacionEstadioResponse.NombreResponsableVinculadas = "";
                }
            }

            flujoAprobacionEstadioResponse.CodigoFlujoAprobacionEstadio = flujoAprobacionEstadioLogic.CodigoFlujoAprobacionEstadio.ToString();
            flujoAprobacionEstadioResponse.CodigoFlujoAprobacion = flujoAprobacionEstadioLogic.CodigoFlujoAprobacion.ToString();
            flujoAprobacionEstadioResponse.Orden = flujoAprobacionEstadioLogic.Orden;
            flujoAprobacionEstadioResponse.Descripcion = flujoAprobacionEstadioLogic.Descripcion;
            flujoAprobacionEstadioResponse.TiempoAtencion = flujoAprobacionEstadioLogic.TiempoAtencion;
            flujoAprobacionEstadioResponse.HorasAtencion = flujoAprobacionEstadioLogic.HorasAtencion;
            flujoAprobacionEstadioResponse.IndicadorVersionOficial = flujoAprobacionEstadioLogic.IndicadorVersionOficial;
            flujoAprobacionEstadioResponse.IndicadorPermiteCarga = flujoAprobacionEstadioLogic.IndicadorPermiteCarga;
            flujoAprobacionEstadioResponse.IndicadorNumeroContrato = flujoAprobacionEstadioLogic.IndicadorNumeroContrato;
            flujoAprobacionEstadioResponse.IndicadorIncluirVisto = flujoAprobacionEstadioLogic.IndicadorIncluirVisto;
            return flujoAprobacionEstadioResponse;
        }

        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="flujoAprobacionEstadioLogic">Entidad Lógica de Flujo de Aprobación</param>
        /// <returns>Clase Flujo Aprobación con los datos de búsqueda</returns>
        public static FlujoAprobacionEstadioResponse ObtenerFlujoAprobacionEstadioDescripcion(FlujoAprobacionEstadioLogic flujoAprobacionEstadioLogic)
        {
            FlujoAprobacionEstadioResponse flujoAprobacionEstadioResponse = new FlujoAprobacionEstadioResponse();

            flujoAprobacionEstadioResponse.Descripcion = flujoAprobacionEstadioLogic.Descripcion;

            return flujoAprobacionEstadioResponse;
        }
    }
}

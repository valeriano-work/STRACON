using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Transactions;
using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.Adapter.Contractual;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Aplicacion.Service.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Cross.Core.Exception;
using Pe.Stracon.SGC.Cross.Core.Util;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Application.Core.ServiceContract;

namespace Pe.Stracon.SGC.Aplicacion.Service.Contractual
{    
    /// <summary>
    /// Servicio que representa los Contratos corporativos
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20170623 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class ContratoCorporativoService : GenericService, IContratoCorporativoService
    {
        
        #region Parametros

        /// <summary>
        /// Servicio de manejo de política 
        /// </summary>
        public IPoliticaService politicaService { get; set; }

        /// <summary>
        /// Servicio de manejo de Unidad Operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }

        /// <summary>
        /// Repositorio de manejo de contrato corporativo logic
        /// </summary>
        public IContratoCorporativoLogicRepository contratoCorporativoLogicRepository { get; set; }

        #endregion

        /// <summary>
        /// Realiza la búsqueda de contratos corporativos
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de contratos</returns>
        public ProcessResult<List<ContratoCorporativoResponse>> BuscarContratoCorporativo(ContratoCorporativoRequest filtro)
        {
            ProcessResult<List<ContratoCorporativoResponse>> resultado = new ProcessResult<List<ContratoCorporativoResponse>>();
            List<CodigoValorResponse> resultadoTipoServicio = null;
            List<CodigoValorResponse> resultadoTipoRequerimiento = null;
            List<CodigoValorResponse> resultadoTipoDocumento = null;
            List<CodigoValorResponse> resultadoEstadoContrato = null;        
          //  List<UnidadOperativaResponse> resultadoUnidadOperativa = null;

            try
            {
                resultadoTipoServicio = politicaService.ListarTipoContrato().Result;
                resultadoTipoRequerimiento = politicaService.ListarTipoServicio().Result;
                resultadoTipoDocumento = politicaService.ListarTipoDocumentoContrato().Result;
                resultadoEstadoContrato = politicaService.ListarEstadoContrato().Result;              
               // resultadoUnidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa()).Result;
              
                Guid? codigoUnidadOperativa = filtro.CodigoUnidadOperativa != null ? new Guid(filtro.CodigoUnidadOperativa) : (Guid?)null;
        
                DateTime? fechaInicioVigencia = null;
                DateTime? fechaFinVigencia = null;          

                if (!string.IsNullOrWhiteSpace(filtro.FechaInicioVigenciaString))
                {
                    fechaInicioVigencia = DateTime.ParseExact(filtro.FechaInicioVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    fechaInicioVigencia = null;
                }

                if (!string.IsNullOrWhiteSpace(filtro.FechaFinVigenciaString))
                {
                    fechaFinVigencia = DateTime.ParseExact(filtro.FechaFinVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture); ;
                }
                else
                {
                    fechaFinVigencia = null;
                }


                List<ContratoCorporativoLogic> listado = contratoCorporativoLogicRepository.BuscarContratosCorporativos(codigoUnidadOperativa, filtro.CodigoTipoServicio,
                                                                                        filtro.CodigoTipoRequerimiento, filtro.CodigoTipoDocumento, filtro.CodigoEstado,
                                                                                        filtro.NumeroContrato, filtro.Descripcion, fechaInicioVigencia, fechaFinVigencia, filtro.NombreProveedor, filtro.NumeroPagina, filtro.RegistrosPagina);

                resultado.Result = new List<ContratoCorporativoResponse>();
                foreach (var registro in listado)
                {
                    ContratoCorporativoResponse objResponse = new ContratoCorporativoResponse();

                    if (resultadoTipoServicio != null)
                    {
                        var tServicio = resultadoTipoServicio.Where(n => n.Codigo.ToString() == registro.CodigoTipoServicio).FirstOrDefault();
                        objResponse.TipoServicio = (tServicio == null ? null : tServicio.Valor.ToString());
                    }

                    if (resultadoTipoRequerimiento != null)
                    {
                        var tRequerimiento = resultadoTipoRequerimiento.Where(n => n.Codigo.ToString() == registro.CodigoTipoRequerimiento).FirstOrDefault();
                        objResponse.TipoContrato = (tRequerimiento == null ? null : tRequerimiento.Valor.ToString());
                    }

                    if (resultadoTipoDocumento != null)
                    {
                        var tDocumentoContrato = resultadoTipoDocumento.Where(n => n.Codigo.ToString() == registro.CodigoTipoDocumento).FirstOrDefault();
                        objResponse.TipoDocumento = (tDocumentoContrato == null ? null : tDocumentoContrato.Valor.ToString());
                    }

                    if (resultadoEstadoContrato != null)
                    {
                        var eContrato = resultadoEstadoContrato.Where(n => n.Codigo.ToString() == registro.CodigoEstadoContrato).FirstOrDefault();
                        objResponse.EstadoContrato = (eContrato == null ? null : eContrato.Valor.ToString());
                    }

                    objResponse.CodigoContrato = registro.CodigoContrato;
                    objResponse.CodigoUnidadOperativa = registro.CodigoUnidadOperativa;

                    //var unidadEncontrada = resultadoUnidadOperativa.Where(item => item.CodigoUnidadOperativa == registro.CodigoUnidadOperativa).FirstOrDefault();
                    //if (unidadEncontrada != null)
                    //{
                    //    objResponse.NombreUnidadOperativa = unidadEncontrada.Nombre;
                    //}  
                   
                    objResponse.Proveedor = registro.NombreProveedor;
                    objResponse.NumeroContrato = registro.NumeroContrato;
                    //cambio
                    objResponse.NumeroAdenda = registro.NumeroAdendaConcatenado;
                    //cambio
                    objResponse.Descripcion = registro.Descripcion;
                    objResponse.FechaInicioVigencia = registro.FechaInicioVigencia;
                    objResponse.FechaInicioVigenciaString = registro.FechaInicioVigencia.ToString(DatosConstantes.Formato.FormatoFecha);
                    objResponse.FechaFinVigencia = registro.FechaFinVigencia;
                    objResponse.FechaFinVigenciaString = registro.FechaFinVigencia.ToString(DatosConstantes.Formato.FormatoFecha);
                    objResponse.CodigoEstadoEdicion = registro.CodigoEstadoEdicion;
                    objResponse.NombreUnidadOperativa = registro.NombreUnidadOperativa;
                    objResponse.UsuarioCreacion = registro.UsuarioCreacion;
                    objResponse.FechaCreacionString = registro.FechaCreacion.ToString(DatosConstantes.Formato.FormatoFecha);

                    resultado.Result.Add(objResponse);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ContratoCorporativoService>(e);
            }
            return resultado;
        }
    }
}

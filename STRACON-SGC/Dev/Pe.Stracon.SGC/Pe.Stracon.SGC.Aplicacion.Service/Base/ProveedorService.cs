using Pe.Stracon.SGC.Aplicacion.Adapter.Contractual;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Base;
using Pe.Stracon.SGC.Cross.Core.Exception;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.Proxy.Oracle;
using Pe.Stracon.SGC.Infraestructura.Proxy.SAP;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Pe.Stracon.SGC.Aplicacion.Service.Base
{
   

    /// <summary>
    /// Servicio que representa los Proveedores
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150602 <br />
    /// Modificación:                <br />
    /// </remarks>
    public class ProveedorService : GenericService, IProveedorService
    {
        #region Propiedades
        /// <summary>
        /// Interfaz de manejo de Proveedor
        /// </summary>
        public IProveedorLogicRepository proveedorLogicRepository { get; set; }

        /// <summary>
        /// Interfaz de manejo de repositorio Proveedor
        /// </summary>
        public IProveedorEntityRepository proveedorEntityRepository { get; set; }
        #endregion

        /// <summary>
        /// Realiza la búsqueda de Proveedores
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de Proveedores</returns>
        public ProcessResult<List<ProveedorResponse>> BuscarProveedor(ProveedorRequest filtro)
        {
            ProcessResult<List<ProveedorResponse>> resultado = new ProcessResult<List<ProveedorResponse>>();

            try
            {
                Guid? codigoProveedor = filtro.CodigoProveedor != null ? new Guid(filtro.CodigoProveedor) : (Guid?)null;

                List<ProveedorLogic> listado = proveedorLogicRepository.BuscarProveedor(codigoProveedor, filtro.CodigoIdentificacion,
                                                                                        filtro.Nombre, filtro.NombreComercial,
                                                                                        filtro.TipoDocumento,filtro.NumeroDocumento,
                                                                                        filtro.NumeroPagina, filtro.RegistrosPagina);

                resultado.Result = new List<ProveedorResponse>();
                foreach (var registro in listado)
                {
                    var proveedor = ProveedorAdapter.ObtenerProveedorPaginado(registro);
                    resultado.Result.Add(proveedor);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ProveedorService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la búsqueda de Proveedores del Servicio Web
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de Proveedores del Servicio Web</returns>
        public ProcessResult<List<ProveedorResponse>> BuscarProveedorOracle(ProveedorRequest filtro)
        {
            ProcessResult<List<ProveedorResponse>> resultado = new ProcessResult<List<ProveedorResponse>>();
            try
            {
                IOracleProxy oracleProxy = new OracleProxy();
                filtro.RucNombreProveedor = filtro.RucNombreProveedor ?? "";

                filtro.RucNombreProveedor = filtro.RucNombreProveedor.ToUpper();

                List<ProveedorOracleLogic> listado = oracleProxy.ObtenerProveedores(filtro.RucNombreProveedor);

                resultado.Result = new List<ProveedorResponse>();
                foreach (var registro in listado)
                {
                    var proveedorResponse = new ProveedorResponse();
                    proveedorResponse.Nombre = registro.Nombre;
                    proveedorResponse.NombreComercial = registro.Nombre;
                    proveedorResponse.TipoDocumento = DatosConstantes.TipoDocumentoIdentificacion.Ruc;
                    proveedorResponse.NumeroDocumento = registro.Ruc;

                    resultado.Result.Add(proveedorResponse);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ProveedorService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la búsqueda de Proveedores del Servicio Web -SAP
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de Proveedores del Servicio Web - SAP </returns>
        public ProcessResult<List<ProveedorResponse>> BuscarProveedorSAP(ProveedorRequest filtro)
        {
            ProcessResult<List<ProveedorResponse>> resultado = new ProcessResult<List<ProveedorResponse>>();
            try
            {
                ISAPProxy sapProxy = new SAPProxy();
                filtro.RucNombreProveedor = filtro.RucNombreProveedor ?? "";
                
                filtro.RucNombreProveedor = filtro.RucNombreProveedor.ToUpper();
                List<ProveedorSAPLogic> listado = sapProxy.ZSGC_OBTPROVEEDORES(filtro.RucNombreProveedor);

                resultado.Result = new List<ProveedorResponse>();
                foreach (var registro in listado)
                {
                    var proveedorResponse = new ProveedorResponse();
                    proveedorResponse.Nombre = registro.Nombre;
                    proveedorResponse.NombreComercial = registro.Nombre;
                    proveedorResponse.TipoDocumento = DatosConstantes.TipoDocumentoIdentificacion.Ruc;
                    proveedorResponse.NumeroDocumento = registro.Ruc;

                    resultado.Result.Add(proveedorResponse);
                }
            }
            catch (Exception e)

            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ProveedorService>(e);
            }

            return resultado;
        }

        /// <summary>
        /// Realiza la búsqueda de un Proveedor y si no lo encuentra lo registra
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Registro de Proveedor encontrado o registrado</returns>
        public ProcessResult<List<ProveedorResponse>> BuscarRegistrarProveedorContrato(ProveedorRequest filtro)
        {
            ProcessResult<List<ProveedorResponse>> resultado = new ProcessResult<List<ProveedorResponse>>();

            try
            {
                Guid? codigoProveedor = filtro.CodigoProveedor != null ? new Guid(filtro.CodigoProveedor) : (Guid?)null;

                resultado = BuscarProveedor(filtro);

                if (resultado.Result.Count == 0)
                {
                    ProveedorEntity entidad = ProveedorAdapter.RegistrarProveedor(filtro);
                    proveedorEntityRepository.Insertar(entidad);
                    proveedorEntityRepository.GuardarCambios();

                    resultado = BuscarProveedor(new ProveedorRequest { CodigoProveedor = entidad.CodigoProveedor.ToString() });
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ProveedorService>(e);
            }

            return resultado;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public ProcessResult<List<ProveedorResponse>> BuscarProveedorNombreRuc(ProveedorRequest filtro)
        {
            ProcessResult<List<ProveedorResponse>> resultado = new ProcessResult<List<ProveedorResponse>>();

            try
            {
                Guid? codigoProveedor = filtro.CodigoProveedor != null ? new Guid(filtro.CodigoProveedor) : (Guid?)null;

                List<ProveedorLogic> listado = proveedorLogicRepository.BuscarProveedorNombreRuc(
                                                                                                 codigoProveedor, 
                                                                                                 filtro.CodigoIdentificacion,
                                                                                                 filtro.Nombre, 
                                                                                                 filtro.NombreComercial,
                                                                                                 filtro.TipoDocumento, 
                                                                                                 filtro.NumeroDocumento,
                                                                                                 filtro.NumeroPagina, 
                                                                                                 filtro.RegistrosPagina
                                                                                                 );

                resultado.Result = new List<ProveedorResponse>();
                foreach (var registro in listado)
                {
                    var proveedor = ProveedorAdapter.ObtenerProveedorPaginado(registro);
                    resultado.Result.Add(proveedor);
                }
            }
            catch (Exception e)
            {
                resultado.IsSuccess = false;
                resultado.Exception = new ApplicationLayerException<ProveedorService>(e);
            }

            return resultado;
        }


    }
}

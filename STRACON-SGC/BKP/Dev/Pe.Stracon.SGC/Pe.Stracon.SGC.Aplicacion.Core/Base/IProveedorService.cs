using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Core.Base
{
    /// <summary>
    /// Servicio que representa los Proveedores
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150602 <br />
    /// Modificación:                <br />
    /// </remarks>
    public interface IProveedorService : IGenericService
    {
        /// <summary>
        /// Realiza la búsqueda de Proveedores del Servicio Web
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de Proveedores del Servicio Web</returns>
        ProcessResult<List<ProveedorResponse>> BuscarProveedorOracle(ProveedorRequest filtro);

        /// <summary>
        /// Realiza la búsqueda de Proveedores del Servicio Web -SAP
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de Proveedores del Servicio Web - SAP</returns>
        ProcessResult<List<ProveedorResponse>> BuscarProveedorSAP(ProveedorRequest filtro);

        /// <summary>
        /// Realiza la búsqueda de un Proveedor y si no existe lo registra
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Registro de Proveedor encontrado o registrado</returns>
        ProcessResult<List<ProveedorResponse>> BuscarRegistrarProveedorContrato(ProveedorRequest filtro);

        /// <summary>
        /// Realiza la búsqueda de Proveedores
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de Proveedores</returns>
        ProcessResult<List<ProveedorResponse>> BuscarProveedor(ProveedorRequest filtro);

        /// <summary>
        /// Realiza la búsqueda de Proveedores
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Lista de Proveedores</returns>
        ProcessResult<List<ProveedorResponse>> BuscarProveedorNombreRuc(ProveedorRequest filtro);

    }
}

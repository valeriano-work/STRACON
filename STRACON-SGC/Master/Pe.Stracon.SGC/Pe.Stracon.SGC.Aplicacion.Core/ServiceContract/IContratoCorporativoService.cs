using System;
using System.Collections.Generic;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;

namespace Pe.Stracon.SGC.Aplicacion.Core.ServiceContract
{
    /// <summary>
    /// Servicio que representa el contrato corporativo service
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20170623 <br />
    /// Modificación: <br />
    /// </remarks>
    public interface IContratoCorporativoService : IGenericService
    {
        /// <summary>
        /// Realiza la búsqueda de contratos corporativos
        /// </summary>
        /// <param name="filtro">Filtro de búsqueda</param>
        /// <returns>Listado de contratos</returns>
        ProcessResult<List<ContratoCorporativoResponse>> BuscarContratoCorporativo(ContratoCorporativoRequest filtro);
    }
}

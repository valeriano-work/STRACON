using System;
using System.Collections.Generic;
using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Query.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel;

namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    /// <summary>
    /// Definición del Repositorio Listado Contrato Logic
    /// </summary>
    public interface IContratoCorporativoLogicRepository : IQueryRepository<ContratoCorporativoLogic>
    {
        /// <summary>
        /// Realiza la búsqueda de Contratos corporativos
        /// </summary>       
        /// <param name="codigoUnidadOperativa">Código de unidad operativa</param>    
        /// <param name="codigoTipoServicio">Código de Tipo de Servicio</param>
        /// <param name="codigoTipoRequerimiento">Código de Tipo de Requerimiento</param>
        /// <param name="codigoTipoDocumento">Código de Tipo de Documento</param>
        /// <param name="codigoEstado">Código de Estado de contrato</param>
        /// <param name="numeroContrato">Número de Contrato</param>  
        /// <param name="descripcion">Descripción de Contrato</param>
        /// <param name="fechaInicioVigencia">Fecha inicio de vigencia</param>
        /// <param name="fechaFinVigencia">Fecah fin de vigencia</param>
        /// <param name="nombreProveedor">Proveedor</param>
        /// <param name="numeroPagina">Total de Páginas</param>
        /// <param name="registroPagina">Total de Registros por Página</param>
        /// <returns>Lista de contratos</returns>
        List<ContratoCorporativoLogic> BuscarContratosCorporativos(Guid? codigoUnidadOperativa,
              string codigoTipoServicio,
              string codigoTipoRequerimiento,
              string codigoTipoDocumento,
              string codigoEstado,
              string numeroContrato,
              string descripcion,
              DateTime? fechaInicioVigencia,
              DateTime? fechaFinVigencia,
              string nombreProveedor,
              int numeroPagina,
              int registroPagina);
    }
}

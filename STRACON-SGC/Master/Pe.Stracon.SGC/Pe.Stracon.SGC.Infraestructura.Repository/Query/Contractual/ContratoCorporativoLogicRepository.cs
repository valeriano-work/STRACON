using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Pe.Stracon.SGC.Cross.Core.Extension;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Query.Contractual
{
    public class ContratoCorporativoLogicRepository : QueryRepository<ContratoCorporativoLogic>, IContratoCorporativoLogicRepository
    {
        /// <summary>
        /// Realiza la búsqueda de Contratos
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
        public List<ContratoCorporativoLogic> BuscarContratosCorporativos(Guid? codigoUnidadOperativa, 
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
            int registroPagina)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_UNIDAD_OPERATIVA",SqlDbType.UniqueIdentifier) { Value = (object)codigoUnidadOperativa ?? DBNull.Value},
                new SqlParameter("NUMERO_CONTRATO",SqlDbType.NVarChar) { Value = (object)numeroContrato ?? DBNull.Value},   
                new SqlParameter("DESCRIPCION",SqlDbType.NVarChar) { Value = (object)descripcion ?? DBNull.Value},             
                             
                new SqlParameter("CODIGO_TIPO_SERVICIO",SqlDbType.NVarChar) { Value = (object)codigoTipoServicio ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_REQUERIMIENTO",SqlDbType.NVarChar) { Value = (object)codigoTipoRequerimiento ?? DBNull.Value},
                new SqlParameter("CODIGO_TIPO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)codigoTipoDocumento ?? DBNull.Value},
                new SqlParameter("CODIGO_ESTADO",SqlDbType.NVarChar) { Value = (object)codigoEstado ?? DBNull.Value},
                
                new SqlParameter("FECHA_INICIO_VIGENCIA",SqlDbType.DateTime) { Value = (object)fechaInicioVigencia ?? DBNull.Value},
                new SqlParameter("FECHA_FIN_VIGENCIA",SqlDbType.DateTime) { Value = (object)fechaFinVigencia ?? DBNull.Value},
                new SqlParameter("NAME_DATABASE",SqlDbType.NVarChar) { Value = (object)DatosConstantes.ConfiguracionNombreDataBasePoliticas.NombreBaseDatosPoliticas?? DBNull.Value},
                 new SqlParameter("RUC_NOMBRE",SqlDbType.NVarChar) { Value = (object)nombreProveedor ?? DBNull.Value},
                new SqlParameter("PageNo",SqlDbType.Int) { Value = (object)numeroPagina ?? DBNull.Value},
                new SqlParameter("PageSize",SqlDbType.BigInt) { Value = (object)registroPagina ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<ContratoCorporativoLogic>("CTR.USP_CONTRATO_CORPORATIVO_RPT", parametros).ToList();
            return result;
        }
    }
}

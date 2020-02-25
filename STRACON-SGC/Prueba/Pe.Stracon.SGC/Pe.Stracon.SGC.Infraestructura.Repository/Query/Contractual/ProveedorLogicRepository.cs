using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Base;

namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    /// <summary>
    /// Implementación del repositorio Proveedor
    /// </summary>
    public class ProveedorLogicRepository : QueryRepository<ProveedorLogic>, IProveedorLogicRepository
    {
        /// <summary>
        /// Realiza la búsqueda de Proveedores del Servicio Web
        /// </summary>
        /// <param name="codigoProveedor">Código de Proveedor</param>
        /// <param name="codigoIdentificacion">Código de Identificacion</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="nombreComercial">Nombre Comercial</param>
        /// <param name="tipoDocumento">Tipo de Documento</param>
        /// <param name="numeroDocumento">Número de Documento</param>
        /// <param name="numeroPagina">Número de Página</param>
        /// <param name="registroPagina">Registros por Página</param>
        /// <returns>Lista de Proveedores del Servicio Web</returns>
        public List<ProveedorLogic> BuscarProveedorOracle(
                                    Guid? codigoProveedor, string codigoIdentificacion,
                                    string nombre, string nombreComercial, 
                                    string tipoDocumento, string numeroDocumento,
                                    int numeroPagina, int registroPagina)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PROVEEDOR",SqlDbType.UniqueIdentifier) { Value = (object)codigoProveedor ?? DBNull.Value},
                new SqlParameter("CODIGO_IDENTIFICACION",SqlDbType.NVarChar) { Value = (object)codigoIdentificacion ?? DBNull.Value},
                new SqlParameter("NOMBRE",SqlDbType.NVarChar) { Value = (object)nombre ?? DBNull.Value},
                new SqlParameter("NOMBRE_COMERCIAL",SqlDbType.NVarChar) { Value = (object)nombreComercial ?? DBNull.Value},
                new SqlParameter("TIPO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)tipoDocumento ?? DBNull.Value},
                new SqlParameter("NUMERO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)numeroDocumento ?? DBNull.Value},
                new SqlParameter("PageNo",SqlDbType.Int) { Value = (object)numeroPagina ?? DBNull.Value},
                new SqlParameter("PageSize",SqlDbType.Int) { Value = (object)registroPagina ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<ProveedorLogic>("CTR.USP_PROVEEDOR_SEL", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Realiza el registro de proveedores
        /// </summary>        
        /// <param name="codigoIdentificacion">Código de Identificacion</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="nombreComercial">Nombre Comercial</param>
        /// <param name="tipoDocumento">Tipo de Documento</param>
        /// <param name="numeroDocumento">Número de Documento</param>
        /// <param name="numeroPagina">Número de Página</param>
        /// <param name="registroPagina">Registros por Página</param>
        /// <returns>Registro de Proveedor encontrado o registrado</returns>
        public List<ProveedorLogic> RegistrarProveedorContrato(string codigoIdentificacion,
                                    string nombre, string nombreComercial,
                                    string tipoDocumento, string numeroDocumento)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {                
                new SqlParameter("CODIGO_IDENTIFICACION",SqlDbType.NVarChar) { Value = (object)codigoIdentificacion ?? DBNull.Value},
                new SqlParameter("NOMBRE",SqlDbType.NVarChar) { Value = (object)nombre ?? DBNull.Value},
                new SqlParameter("NOMBRE_COMERCIAL",SqlDbType.NVarChar) { Value = (object)nombreComercial ?? DBNull.Value},
                new SqlParameter("TIPO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)tipoDocumento ?? DBNull.Value},
                new SqlParameter("NUMERO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)numeroDocumento ?? DBNull.Value},
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<ProveedorLogic>("CTR.USP_PROVEEDOR_INS", parametros).ToList();
            return result;
        }

        /// <summary>
        /// Realiza la búsqueda de Proveedores del Servicio Web
        /// </summary>
        /// <param name="codigoProveedor">Código de Proveedor</param>
        /// <param name="codigoIdentificacion">Código de Identificacion</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="nombreComercial">Nombre Comercial</param>
        /// <param name="tipoDocumento">Tipo de Documento</param>
        /// <param name="numeroDocumento">Número de Documento</param>
        /// <param name="numeroPagina">Número de Página</param>
        /// <param name="registroPagina">Registros por Página</param>
        /// <returns>Lista de Proveedores del Servicio Web</returns>
        public List<ProveedorLogic> BuscarProveedor(
                                            Guid? codigoProveedor, string codigoIdentificacion, string nombre, string nombreComercial, string tipoDocumento, string numeroDocumento, int numeroPagina, int registroPagina)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PROVEEDOR",SqlDbType.UniqueIdentifier) { Value = (object)codigoProveedor ?? DBNull.Value},
                new SqlParameter("CODIGO_IDENTIFICACION",SqlDbType.NVarChar) { Value = (object)codigoIdentificacion ?? DBNull.Value},
                new SqlParameter("NOMBRE",SqlDbType.NVarChar) { Value = (object)nombre ?? DBNull.Value},
                new SqlParameter("NOMBRE_COMERCIAL",SqlDbType.NVarChar) { Value = (object)nombreComercial ?? DBNull.Value},
                new SqlParameter("TIPO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)tipoDocumento ?? DBNull.Value},
                new SqlParameter("NUMERO_DOCUMENTO",SqlDbType.NVarChar) { Value = (object)numeroDocumento ?? DBNull.Value},
                new SqlParameter("PageNo",SqlDbType.Int) { Value = (object)numeroPagina ?? DBNull.Value},
                new SqlParameter("PageSize",SqlDbType.Int) { Value = (object)registroPagina ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<ProveedorLogic>("CTR.USP_PROVEEDOR_SEL", parametros).ToList();
            return result;
        }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="codigoProveedor"></param>
      /// <param name="codigoIdentificacion"></param>
      /// <param name="nombre"></param>
      /// <param name="nombreComercial"></param>
      /// <param name="tipoDocumento"></param>
      /// <param name="numeroDocumento"></param>
      /// <param name="numeroPagina"></param>
      /// <param name="registroPagina"></param>
      /// <returns></returns>
        public List<ProveedorLogic> BuscarProveedorNombreRuc(Guid? codigoProveedor,
                                                            string codigoIdentificacion,
                                                            string nombre,
                                                            string nombreComercial,
                                                            string tipoDocumento,
                                                            string numeroDocumento,
                                                            int numeroPagina,
                                                            int registroPagina)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("CODIGO_PROVEEDOR",SqlDbType.UniqueIdentifier)     { Value = (object)codigoProveedor ?? DBNull.Value},
                new SqlParameter("CODIGO_IDENTIFICACION",SqlDbType.NVarChar)        { Value = (object)codigoIdentificacion ?? DBNull.Value},
                new SqlParameter("NOMBRE",SqlDbType.NVarChar)                       { Value = (object)nombre ?? DBNull.Value},
                new SqlParameter("NOMBRE_COMERCIAL",SqlDbType.NVarChar)             { Value = (object)nombreComercial ?? DBNull.Value},
                new SqlParameter("TIPO_DOCUMENTO",SqlDbType.NVarChar)               { Value = (object)tipoDocumento ?? DBNull.Value},
                new SqlParameter("NUMERO_DOCUMENTO",SqlDbType.NVarChar)             { Value = (object)numeroDocumento ?? DBNull.Value},
                new SqlParameter("PageNo",SqlDbType.Int)                            { Value = (object)numeroPagina ?? DBNull.Value},
                new SqlParameter("PageSize",SqlDbType.Int)                          { Value = (object)registroPagina ?? DBNull.Value}
            };

            var result = this.dataBaseProvider.ExecuteStoreProcedure<ProveedorLogic>("CTR.USP_PROVEEDOR_NOMBRE_RUC_SEL", parametros).ToList();
            return result;
        }
    }
}

using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;

namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    public interface IProveedorLogicRepository : IQueryRepository<ProveedorLogic>
    {
        /// <summary>
        /// Realiza la búsqueda de Proveedores
        /// </summary>
        /// <param name="codigoProveedor">Código de proveedor</param>
        /// <param name="codigoIdentificacion">Código de identificacion</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="nombreComercial">Nombre de comercial</param>
        /// <param name="tipoDocumento">Tipo de documento</param>
        /// <param name="numeroDocumento">Numero de documento</param>
        /// <param name="numeroPagina">Total de Páginas</param>
        /// <param name="registroPagina">Total de Registros por Página</param>
        /// <returns>Lista de Proveedores</returns>
        List<ProveedorLogic> BuscarProveedor(
            Guid? codigoProveedor,
            string codigoIdentificacion,
            string nombre,
            string nombreComercial,
            string tipoDocumento,
            string numeroDocumento,
            int numeroPagina,
            int registroPagina
        );

        /// <summary>
        /// Realiza la búsqueda de Proveedores del Servicio Web
        /// </summary>
        /// <param name="codigoProveedor">Código de proveedor</param>
        /// <param name="codigoIdentificacion">Código de identificacion</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="nombreComercial">Nombre de comercial</param>
        /// <param name="tipoDocumento">Tipo de documento</param>
        /// <param name="numeroDocumento">Numero de documento</param>
        /// <param name="numeroPagina">Total de Páginas</param>
        /// <param name="registroPagina">Total de Registros por Página</param>
        /// <returns>Lista de Proveedores del Servicio Web</returns>
        List<ProveedorLogic> BuscarProveedorOracle(
            Guid? codigoProveedor,
            string codigoIdentificacion,
            string nombre,
            string nombreComercial,
            string tipoDocumento,
            string numeroDocumento,
            int numeroPagina, 
            int registroPagina
        );

        /// <summary>
        /// Realiza la búsqueda de Proveedores del Servicio Web
        /// </summary>
        /// <param name="codigoProveedor">Código de proveedor</param>
        /// <param name="codigoIdentificacion">Código de identificacion</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="nombreComercial">Nombre de comercial</param>
        /// <param name="tipoDocumento">Tipo de documento</param>
        /// <param name="numeroDocumento">Numero de documento</param>
        /// <param name="numeroPagina">Total de Páginas</param>
        /// <param name="registroPagina">Total de Registros por Página</param>
        /// <returns>Lista de Proveedores del Servicio Web</returns>
        List<ProveedorLogic> BuscarProveedorSAP(
            Guid? codigoProveedor,
            string codigoIdentificacion,
            string nombre,
            string nombreComercial,
            string tipoDocumento,
            string numeroDocumento,
            int numeroPagina,
            int registroPagina
        );

        /// <summary>
        /// Realiza el registro de proveedores
        /// </summary>
        /// <param name="codigoIdentificacion">Código de identificacion</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="nombreComercial">Nombre de comercial</param>
        /// <param name="tipoDocumento">Tipo de documento</param>
        /// <param name="numeroDocumento">Numero de documento</param>
        /// <returns>Registro de Proveedor encontrado o registrado</returns>
        List<ProveedorLogic> RegistrarProveedorContrato(string codigoIdentificacion,
                                    string nombre, string nombreComercial,
                                    string tipoDocumento, string numeroDocumento
        );

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
        List<ProveedorLogic> BuscarProveedorNombreRuc(Guid? codigoProveedor,
            string codigoIdentificacion,
            string nombre,
            string nombreComercial,
            string tipoDocumento,
            string numeroDocumento,
            int numeroPagina,
            int registroPagina);
    }
}

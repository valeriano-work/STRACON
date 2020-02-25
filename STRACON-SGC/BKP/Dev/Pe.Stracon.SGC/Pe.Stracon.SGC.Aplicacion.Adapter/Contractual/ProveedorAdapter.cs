using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Base;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementacion del Adaptador de Proveedor
    /// </summary>
    public sealed class ProveedorAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="listadoContratoLogic">Entidad Lógica Proveedor</param>
        /// <returns>Clase Proveedor Response con los datos de búsqueda</returns>
        public static ProveedorResponse ObtenerProveedorPaginado(ProveedorLogic proveedorLogic)
        {
            var proveedorResponse = new ProveedorResponse();

            proveedorResponse.CodigoProveedor       = proveedorLogic.CodigoProveedor;
            proveedorResponse.CodigoIdentificacion  = proveedorLogic.CodigoIdentificacion;
            proveedorResponse.Nombre                = proveedorLogic.Nombre;
            proveedorResponse.NombreComercial       = proveedorLogic.NombreComercial;
            proveedorResponse.TipoDocumento         = proveedorLogic.TipoDocumento;
            proveedorResponse.NumeroDocumento       = proveedorLogic.NumeroDocumento;

            return proveedorResponse;
        }

        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="plantillaLogic">Entidad Lógica Proveedor</param>
        /// <returns>Clase Proveedor Response con los datos de búsqueda</returns>
        public static ProveedorResponse ObtenerProveedor(ProveedorLogic proveedorLogic)
        {
            var proveedorResponse = new ProveedorResponse();

            proveedorResponse.CodigoProveedor = proveedorLogic.CodigoProveedor;
            proveedorResponse.CodigoIdentificacion = proveedorLogic.CodigoIdentificacion;
            proveedorResponse.Nombre = proveedorLogic.Nombre;
            proveedorResponse.NombreComercial = proveedorLogic.NombreComercial;
            proveedorResponse.TipoDocumento = proveedorLogic.TipoDocumento;
            proveedorResponse.NumeroDocumento = proveedorLogic.NumeroDocumento;

            return proveedorResponse;
        }

        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Proveedor con los datos a registrar</returns>
        public static ProveedorEntity RegistrarProveedor(ProveedorRequest data)
        {
            var proveedorEntity = new ProveedorEntity();

            if (data.CodigoProveedor != null)
            {
                proveedorEntity.CodigoProveedor = new Guid(data.CodigoProveedor.ToString());
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                proveedorEntity.CodigoProveedor = code;
            }

            proveedorEntity.CodigoIdentificacion = data.CodigoIdentificacion;
            proveedorEntity.Nombre = data.Nombre;
            proveedorEntity.NombreComercial = data.Nombre;
            proveedorEntity.TipoDocumento = data.TipoDocumento;
            proveedorEntity.NumeroDocumento = data.NumeroDocumento;

            return proveedorEntity;
        }
    }
}

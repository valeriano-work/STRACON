using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using System;

namespace Pe.Stracon.Politicas.Aplicacion.Adapter.General
{    
    /// <summary>
    /// Adaptador de Parámetro
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public sealed class ParametroAdapter
    {
        /// <summary>
        /// Obtiene un response de Parámetro apartir de su logic
        /// </summary>
        /// <param name="parametroLogic">Entidad de Parámetro</param>
        /// <returns>Response de Parámetro</returns>
        public static ParametroResponse ObtenerParametroResponse(ParametroLogic parametroLogic)
        {
            var parametro = new ParametroResponse();
            parametro.CodigoIdentificador = parametroLogic.CodigoIdentificador;
            parametro.TipoParametro = parametroLogic.TipoParametro;

            switch(parametro.TipoParametro)
            {
                case DatosConstantes.TipoParametro.Comun:
                    parametro.DescripcionTipoParametro = "Común";
                    break;
                case DatosConstantes.TipoParametro.Sistema:
                    parametro.DescripcionTipoParametro = "Sistema";
                    break;
                case DatosConstantes.TipoParametro.Funcional:
                    parametro.DescripcionTipoParametro = "Funcional";
                    break;
                default:
                    parametro.DescripcionTipoParametro = string.Empty;
                    break;
            }
            parametro.CodigoParametro = parametroLogic.CodigoParametro;
            parametro.CodigoEmpresa = parametroLogic.CodigoEmpresa.ToString();
            parametro.CodigoEmpresaIdentificador = parametroLogic.CodigoEmpresaIdentificador;
            parametro.NombreEmpresa = parametroLogic.NombreEmpresa;
            parametro.CodigoSistema = parametroLogic.CodigoSistema.HasValue ? parametroLogic.CodigoSistema.ToString() : null;
            parametro.CodigoSistemaIdentificador = parametroLogic.CodigoSistemaIdentificador;
            parametro.NombreSistema = parametroLogic.NombreSistema;            
            parametro.Descripcion = parametroLogic.Descripcion;
            parametro.EstadoRegistro = parametroLogic.EstadoRegistro;
            parametro.IndicadorEmpresa = parametroLogic.IndicadorEmpresa;
            parametro.DescripcionIndicadorEmpresa = parametroLogic.IndicadorEmpresa ? "Si" : "No";
            parametro.IndicadorPermiteAgregar = parametroLogic.IndicadorPermiteAgregar;
            parametro.IndicadorPermiteEliminar = parametroLogic.IndicadorPermiteEliminar;
            parametro.IndicadorPermiteModificar = parametroLogic.IndicadorPermiteModificar;
            parametro.Nombre = parametroLogic.Nombre;
            return parametro;
        }

        /// <summary>
        /// Obtiene un entity de Parámetro apartir de su request
        /// </summary>
        /// <param name="parametroRequest">Request de Parámetro</param>
        /// <returns>Entity del Parámetro</returns>
        public static ParametroEntity ObtenerParametroEntity(ParametroRequest parametroRequest)
        {
            var entity = new ParametroEntity();
            entity.CodigoParametro              = Convert.ToInt32(parametroRequest.CodigoParametro);
            entity.CodigoEmpresa                = new Guid(parametroRequest.CodigoEmpresa);
            entity.CodigoSistema                = parametroRequest.CodigoSistema != null ? new Guid(parametroRequest.CodigoSistema) : (Guid?) null;
            entity.CodigoIdentificador          = parametroRequest.CodigoIdentificador;
            entity.Nombre                       = parametroRequest.Nombre;
            entity.Descripcion                  = parametroRequest.Descripcion;
            entity.IndicadorPermiteAgregar      = Convert.ToBoolean(parametroRequest.IndicadorPermiteAgregar);
            entity.IndicadorPermiteModificar    = Convert.ToBoolean(parametroRequest.IndicadorPermiteModificar);
            entity.IndicadorPermiteEliminar     = Convert.ToBoolean(parametroRequest.IndicadorPermiteEliminar);
            entity.TipoParametro                = parametroRequest.TipoParametro;
            entity.IndicadorEmpresa             = parametroRequest.IndicadorEmpresa;

            return entity;
        }
    }
}

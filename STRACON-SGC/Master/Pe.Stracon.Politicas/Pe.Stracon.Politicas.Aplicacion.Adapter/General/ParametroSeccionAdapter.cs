using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using System;

namespace Pe.Stracon.Politicas.Aplicacion.Adapter.General
{    
    /// <summary>
    /// Adaptador de Parámetro Sección
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public sealed class ParametroSeccionAdapter
    {
        /// <summary>
        /// Obtiene un response de Sección Parámetro apartir de su logic
        /// </summary>
        /// <param name="parametroLogic">Entidad de Sección Parámetro</param>
        /// <returns>Response de Sección Parámetro</returns>
        public static ParametroSeccionResponse ObtenerParametroSeccionResponse(ParametroSeccionLogic parametroLogic)
        {
            var seccion = new ParametroSeccionResponse();
            seccion.CodigoParametro                 = parametroLogic.CodigoParametro;
            seccion.CodigoSeccion                   = parametroLogic.CodigoSeccion;
            seccion.IndicadorSistema                = parametroLogic.IndicadorSistema;
            seccion.CodigoTipoDato                  = parametroLogic.CodigoTipoDato;
            seccion.DescripcionTipoDato             = parametroLogic.DescripcionTipoDato;
            seccion.IndicadorObligatorio            = parametroLogic.IndicadorObligatorio;
            seccion.IndicadorPermiteModificar       = parametroLogic.IndicadorPermiteModificar;
            seccion.Nombre                          = parametroLogic.Nombre;
            seccion.CodigoParametroRelacionado      = parametroLogic.CodigoParametroRelacionado;
            seccion.NombreParametroRelacionado      = parametroLogic.NombreParametroRelacionado;
            seccion.CodigoSeccionRelacionado        = parametroLogic.CodigoSeccionRelacionado;
            seccion.NombreSeccionRelacionado        = parametroLogic.NombreSeccionRelacionado;
            seccion.CodigoSeccionRelacionadoMostrar = parametroLogic.CodigoSeccionRelacionadoMostrar;
            seccion.NombreSeccionRelacionadoMostrar = parametroLogic.NombreSeccionRelacionadoMostrar;
            seccion.EstadoRegistro                  = parametroLogic.EstadoRegistro;
            return seccion;
        }

        /// <summary>
        /// Obtiene un entity de Parámetro Sección apartir de su request
        /// </summary>
        /// <param name="parametroSeccionRequest">Request de Parámetro Sección</param>
        /// <returns>Entity del Parámetro Sección</returns>
        public static ParametroSeccionEntity ObtenerParametroSeccionEntity(ParametroSeccionRequest parametroSeccionRequest)
        {
            var entity = new ParametroSeccionEntity();
            entity.CodigoParametro                  = Convert.ToInt32(parametroSeccionRequest.CodigoParametro);
            entity.CodigoSeccion                    = Convert.ToInt32(parametroSeccionRequest.CodigoSeccion);
            entity.CodigoTipoDato                   = parametroSeccionRequest.CodigoTipoDato;
            entity.IndicadorObligatorio             = Convert.ToBoolean(parametroSeccionRequest.IndicadorObligatorio);
            entity.IndicadorPermiteModificar        = Convert.ToBoolean(parametroSeccionRequest.IndicadorPermiteModificar);
            entity.Nombre                           = parametroSeccionRequest.Nombre;
            entity.CodigoParametroRelacionado       = parametroSeccionRequest.CodigoParametroRelacionado;
            entity.CodigoSeccionRelacionado         = parametroSeccionRequest.CodigoSeccionRelacionado;
            entity.CodigoSeccionRelacionadoMostrar  = parametroSeccionRequest.CodigoSeccionRelacionadoMostrar;
            entity.EstadoRegistro                   = parametroSeccionRequest.EstadoRegistro;
            return entity;
        }
    }
}

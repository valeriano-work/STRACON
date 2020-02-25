using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pe.Stracon.Politicas.Aplicacion.Adapter.General
{
    /// <summary>
    /// Adaptador de Unidad Operativa
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public sealed class UnidadOperativaAdapter
    {
        /// <summary>
        /// Obtiene un response de Unidad Operativa
        /// </summary>
        /// <param name="unidadOperativaLogic"></param>
        /// <param name="niveles"></param>
        /// <param name="tipos"></param>
        /// <returns>Lista con el resultado de la operación</returns>
        public static UnidadOperativaResponse ObtenerUnidadOperativaResponse(UnidadOperativaLogic unidadOperativaLogic, List<dynamic> niveles, List<dynamic> tipos)
        {
            string sNivel = null;
            string sTipo = null;

            if (niveles != null)
            {
                var nivel = niveles.Where(n => n.Atributo1 == unidadOperativaLogic.CodigoNivelJerarquia).FirstOrDefault();
                sNivel = (nivel == null ? null : nivel.Atributo2);
            }
            if (tipos != null)
            {
                var tipo = tipos.Where(t => t.Atributo1 == unidadOperativaLogic.CodigoTipoUnidadOperativa).FirstOrDefault();
                sTipo = (tipo == null ? null : tipo.Atributo2);
            }

            var unidadOperativa = new UnidadOperativaResponse()
            {
                CodigoUnidadOperativa = unidadOperativaLogic.CodigoUnidadOperativa,
                CodigoIdentificacion = unidadOperativaLogic.CodigoIdentificacion,
                Nombre = unidadOperativaLogic.Nombre,
                CodigoNivelJerarquia = unidadOperativaLogic.CodigoNivelJerarquia,
                DescripcionNivelJerarquia = unidadOperativaLogic.DescripcionNivelJerarquia ?? sNivel,
                NivelJerarquia = unidadOperativaLogic.NivelJerarquia,
                CodigoUnidadOperativaPadre = unidadOperativaLogic.CodigoUnidadOperativaPadre,
                NombreUnidadOperativaPadre = unidadOperativaLogic.NombreUnidadOperativaPadre,
                CodigoTipoUnidadOperativa = unidadOperativaLogic.CodigoTipoUnidadOperativa,
                DescripcionTipoUnidadOperativa = sTipo,
                IndicadorActiva = unidadOperativaLogic.IndicadorActiva,
                CodigoResponsable = unidadOperativaLogic.CodigoResponsable,
                NombreResponsable = unidadOperativaLogic.NombreResponsable,
                CodigoPrimerRepresentante = unidadOperativaLogic.CodigoPrimerRepresentante,
                NombrePrimerRepresentante = unidadOperativaLogic.NombrePrimerRepresentante,
                CodigoSegundoRepresentante = unidadOperativaLogic.CodigoSegundoRepresentante,
                NombreSegundoRepresentante = unidadOperativaLogic.NombreSegundoRepresentante,
                CodigoTercerRepresentante = unidadOperativaLogic.CodigoTercerRepresentante,
                NombreTercerRepresentante = unidadOperativaLogic.NombreTercerRepresentante,
                NombreCuartoRepresentante = unidadOperativaLogic.NombreCuartoRepresentante,
                CodigoCuartoRepresentante = unidadOperativaLogic.CodigoCuartoRepresentante,
                Direccion = unidadOperativaLogic.Direccion,
                LogoUnidadOperativa = unidadOperativaLogic.LogoUnidadOperativa
            };

            return unidadOperativa;
        }

        /// <summary>
        /// Obtiene una entidad de Unidad Operativa
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Entity de Unidad Operativa</returns>
        public static UnidadOperativaEntity ObtenerUnidadOperativaEntity(DataUnidadOperativaRequest data)
        {
            var unidadOperativaEntity = new UnidadOperativaEntity();
            if (data.CodigoUnidadOperativa != null)
            {
                unidadOperativaEntity.Codigo = new Guid(data.CodigoUnidadOperativa);
            }
            else {
                Guid code;
                code = Guid.NewGuid();
                unidadOperativaEntity.Codigo = code;
            }
            unidadOperativaEntity.Nombre = data.Nombre;
            unidadOperativaEntity.CodigoIdentificacion = data.CodigoIdentificacion;
            unidadOperativaEntity.CodigoNivelJerarquia = data.CodigoNivelJerarquia;
            unidadOperativaEntity.CodigoUnidadOperativaPadre = data.CodigoUnidadOperativaPadre != null ? new Guid(data.CodigoUnidadOperativaPadre) : (Guid?)null;
            unidadOperativaEntity.CodigoTipoUnidadOperativa = data.CodigoTipoUnidadOperativa;
            unidadOperativaEntity.IndicadorActiva = data.IndicadorActiva;
            unidadOperativaEntity.CodigoResponsable = data.CodigoResponsable != null ? new Guid(data.CodigoResponsable) : (Guid?)null;
            unidadOperativaEntity.CodigoPrimerRepresentante = data.CodigoPrimerRepresentante != null ? new Guid(data.CodigoPrimerRepresentante) : (Guid?)null;
            unidadOperativaEntity.CodigoSegundoRepresentante = data.CodigoSegundoRepresentante != null ? new Guid(data.CodigoSegundoRepresentante) : (Guid?)null;
            unidadOperativaEntity.CodigoTercerRepresentante = data.CodigoTercerRepresentante != null ? new Guid(data.CodigoTercerRepresentante) : (Guid?)null;
            unidadOperativaEntity.CodigoCuartoRepresentante = data.CodigoCuartoRepresentante != null ? new Guid(data.CodigoCuartoRepresentante) : (Guid?)null;
            unidadOperativaEntity.Direccion = data.Direccion;
            unidadOperativaEntity.CodigoZonaHoraria = data.CodigoZonaHoraria != null ? new Guid(data.CodigoZonaHoraria) : (Guid?)null;

            return unidadOperativaEntity;
        }

        /// <summary>
        /// Obtiene un response de Unidad Operativa staff
        /// </summary>
        /// <param name="unidadOperativaLogic"></param>
        /// <param name="niveles"></param>
        /// <param name="tipos"></param>
        /// <returns>Lista con el resultado de la operación</returns>
        public static UnidadOperativaStaffResponse ObtenerUnidadOperativaStaffResponse(UnidadOperativaStaffLogic unidadOperativaStaffLogic)
        {
            var unidadOperativaStaff = new UnidadOperativaStaffResponse()
            {
                CodigoUnidadOperativa = unidadOperativaStaffLogic.CodigoUnidadOperativa,
                CodigoUnidadOperativaStaff = unidadOperativaStaffLogic.CodigoUnidadOperativaStaff,
                CodigoSistema = unidadOperativaStaffLogic.CodigoSistema,
                CodigoTrabajador = unidadOperativaStaffLogic.CodigoTrabajador,
                EstadoRegistro = unidadOperativaStaffLogic.EstadoRegistro,
                NombreCompleto= unidadOperativaStaffLogic.NombreCompleto,
                NombreSistema = unidadOperativaStaffLogic.NombreSistema
            };

            return unidadOperativaStaff;
        }

        /// <summary>
        /// Obtiene una entidad de Unidad Operativa
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Entity de Unidad Operativa</returns>
        public static UnidadOperativaStaffEntity ObtenerUnidadOperativaStaffEntity(DataUnidadOperativaStaffRequest data)
        {
            var unidadOperativaStaffEntity = new UnidadOperativaStaffEntity();
            if (data.CodigoUnidadOperativaStaff != null)
            {
                unidadOperativaStaffEntity.CodigoUnidadOperativaStaff = new Guid(data.CodigoUnidadOperativaStaff);
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                unidadOperativaStaffEntity.CodigoUnidadOperativaStaff = code;
            }
            unidadOperativaStaffEntity.CodigoUnidadOperativa = data.CodigoUnidadOperativa != null ? new Guid(data.CodigoUnidadOperativa) : (Guid?)null;
            unidadOperativaStaffEntity.CodigoSistema = data.CodigoSistema != null ? new Guid(data.CodigoSistema) : (Guid?)null;
            unidadOperativaStaffEntity.CodigoTrabajador = data.CodigoTrabajador != null ? new Guid(data.CodigoTrabajador) : (Guid?)null;

            return unidadOperativaStaffEntity;
        }

        /// <summary>
        /// Obtiene una entidad de Unidad Operativa Usuario Consulta
        /// </summary>
        /// <param name="data">Data Unidad Operativa Usuario Consulta</param>
        /// <returns>Entity de Unidad Operativa Usuario Consulta</returns>
        public static UnidadOperativaUsuarioConsultaEntity ObtenerUnidadOperativaUsuarioConsultaEntity(DataUnidadOperativaUsuarioConsultaRequest data)
        {
            var unidadOperativaUsuarioConsultaEntity = new UnidadOperativaUsuarioConsultaEntity();

            unidadOperativaUsuarioConsultaEntity.CodigoUnidadUsuarioConsulta = data.CodigoUnidadUsuarioConsulta != null ? new Guid(data.CodigoUnidadUsuarioConsulta) : Guid.NewGuid();
            unidadOperativaUsuarioConsultaEntity.CodigoUnidadOperativa = data.CodigoUnidadOperativa != null ? new Guid(data.CodigoUnidadOperativa) : (Guid?)null;
            unidadOperativaUsuarioConsultaEntity.CodigoTrabajador = data.CodigoTrabajador != null ? new Guid(data.CodigoTrabajador) : (Guid?)null;

            return unidadOperativaUsuarioConsultaEntity;
        }

        /// <summary>
        /// Obtiene un response de Unidad Operativa Usuario Consulta
        /// </summary>
        /// <param name="unidadOperativaUsuarioConsultaLogic">Logic unidad operativa usuario consulta</param>       
        /// <returns>Lista con el resultado</returns>
        public static UnidadOperativaUsuarioConsultaResponse ObtenerUnidadOperativaUsuarioConsultaResponse(UnidadOperativaUsuarioConsultaLogic unidadOperativaUsuarioConsultaLogic)
        {
            var unidadOperativaUsuarioConsulta = new UnidadOperativaUsuarioConsultaResponse()
            {
                CodigoUnidadUsuarioConsulta = unidadOperativaUsuarioConsultaLogic.CodigoUnidadUsuarioConsulta,
                CodigoUnidadOperativa = unidadOperativaUsuarioConsultaLogic.CodigoUnidadOperativa,
                CodigoTrabajador = unidadOperativaUsuarioConsultaLogic.CodigoTrabajador,
                EstadoRegistro = unidadOperativaUsuarioConsultaLogic.EstadoRegistro,
                NombreCompleto = unidadOperativaUsuarioConsultaLogic.NombreCompleto,
                NombreUnidadOperativa = unidadOperativaUsuarioConsultaLogic.NombreUnidadOperativa
            };

            return unidadOperativaUsuarioConsulta;
        }

        /// <summary>
        /// Obtiene un response de Unidad Operativa Nivel
        /// </summary>
        /// <param name="unidadNivelLogic">Unidad Operativa Nivel Logic</param>       
        /// <returns>Unidad operativa nivel response</returns>
        public static UnidadOperativaNivelResponse ObtenerUnidadOperativaNivelResponse(UnidadOperativaNivelLogic unidadNivelLogic)
        {
            var unidadOperativaNivel = new UnidadOperativaNivelResponse()
            {
                CodigoNivelJerarquia = unidadNivelLogic.CodigoNivelJerarquia,
                CodigoUnidadOperativaNivel1 = unidadNivelLogic.CodigoUnidadOperativaNivel1,
                CodigoUnidadOperativaNivel2 = unidadNivelLogic.CodigoUnidadOperativaNivel2,
                CodigoUnidadOperativaNivel3 = unidadNivelLogic.CodigoUnidadOperativaNivel3,
                CodigoResponsableNivel1 = unidadNivelLogic.CodigoResponsableNivel1,
                CodigoResponsableNivel2 = unidadNivelLogic.CodigoResponsableNivel2,
                CodigoResponsableNivel3 = unidadNivelLogic.CodigoResponsableNivel3
            };

            return unidadOperativaNivel;
        }
    }
}

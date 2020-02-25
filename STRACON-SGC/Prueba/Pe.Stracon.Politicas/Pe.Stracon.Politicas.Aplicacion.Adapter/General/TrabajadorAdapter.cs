using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using Pe.Stracon.SGC.Presentacion.Core.LogError;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pe.Stracon.Politicas.Aplicacion.Adapter.General
{
    /// <summary>
    /// Adaptador de Trabajador
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public sealed class TrabajadorAdapter
    {
        /// <summary>
        /// Obtiene un response de trabajador páginado
        /// </summary>
        /// <param name="trabajadorLogic">Trabajador</param>
        /// <param name="listaTipoDocumento">Tipo de documento</param>
        /// <returns>REsponse de trabajador</returns>
        public static TrabajadorResponse ObtenerTrabajadorPaginado(TrabajadorLogic trabajadorLogic, List<CodigoValorResponse> listaTipoDocumento)
        {
            var trabajadorResponse = new TrabajadorResponse()
            {
                CodigoTrabajador = trabajadorLogic.CodigoTrabajador.ToString(),
                CodigoIdentificacion = trabajadorLogic.CodigoIdentificacion,
                CodigoTipoDocumentoIdentidad = trabajadorLogic.CodigoTipoDocumentoIdentidad,
                NumeroDocumentoIdentidad = trabajadorLogic.NumeroDocumentoIdentidad,
                ApellidoPaterno = trabajadorLogic.ApellidoPaterno,
                ApellidoMaterno = trabajadorLogic.ApellidoMaterno,
                Nombres = trabajadorLogic.Nombres,
                NombreCompleto = trabajadorLogic.NombreCompleto,
                Organizacion = trabajadorLogic.Organizacion,
                Departamento = trabajadorLogic.Departamento,
                Cargo = trabajadorLogic.Cargo,
                TelefonoTrabajo = trabajadorLogic.TelefonoTrabajo,
                Anexo = trabajadorLogic.Anexo,
                TelefonoMovil = trabajadorLogic.TelefonoMovil,
                TelefonoPersonal = trabajadorLogic.TelefonoPersonal,
                CorreoElectronico = trabajadorLogic.CorreoElectronico,
                Dominio = trabajadorLogic.Dominio,
                DominioCorto = !string.IsNullOrEmpty(trabajadorLogic.Dominio) ? trabajadorLogic.Dominio.Split('.').FirstOrDefault() : null,
                LinkFoto = trabajadorLogic.IndicadorTieneFoto ? DatosConstantes.ConfiguracionFileServer.UbicacionFotoColaborador + trabajadorLogic.CodigoTrabajador.ToString() + ".jpg" : null,
                CodigoFirma = trabajadorLogic.CodigoFirma.ToString(),
                Firma = trabajadorLogic.FirmaTrabajador,
                IndicadorTodaUnidadOperativa = trabajadorLogic.IndicadorTodaUnidadOperativa,
                CodigoUnidadOperativaMatriz = (trabajadorLogic.CodigoUnidadOperativaMatriz.HasValue ? trabajadorLogic.CodigoUnidadOperativaMatriz.Value.ToString() : "")
            };

            if (listaTipoDocumento != null)
            {
                var tipoDocumento = listaTipoDocumento.Where(td => ((string)td.Codigo) == trabajadorResponse.CodigoTipoDocumentoIdentidad).FirstOrDefault();
                if (tipoDocumento != null)
                {
                    trabajadorResponse.DescripcionTipoDocumentoIdentidad = (string)tipoDocumento.Valor;
                }
            }
            return trabajadorResponse;
        }

        /// <summary>
        /// Obtiene una entidad de tipo trabajador
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Entity de Trabajador</returns>
        public static TrabajadorEntity ObtenerTrabajadorEntity(TrabajadorRequest data)
        {
            var trabajadorEntity = new TrabajadorEntity();
            if (data.CodigoTrabajador != null)
            {
                trabajadorEntity.Codigo = data.CodigoTrabajador;
            }
            else
            {
                trabajadorEntity.Codigo = Guid.NewGuid();
            }
            trabajadorEntity.CodigoIdentificacion = data.CodigoIdentificacion;
            trabajadorEntity.CodigoTipoDocumentoIdentidad = data.CodigoTipoDocumentoIdentidad;
            trabajadorEntity.NumeroDocumentoIdentidad = data.NumeroDocumentoIdentidad;
            trabajadorEntity.ApellidoPaterno = data.ApellidoPaterno;
            trabajadorEntity.ApellidoMaterno = data.ApellidoMaterno;
            trabajadorEntity.Nombres = data.Nombres;
            trabajadorEntity.NombreCompleto = data.Nombres + ' ' + data.ApellidoPaterno + ' ' + data.ApellidoMaterno;
            trabajadorEntity.Organizacion = data.Organizacion;
            trabajadorEntity.Cargo = data.Cargo;
            trabajadorEntity.Departamento = data.Departamento;
            trabajadorEntity.TelefonoTrabajo = data.TelefonoTrabajo;
            trabajadorEntity.Anexo = data.Anexo;
            trabajadorEntity.TelefonoMovil = data.TelefonoMovil;
            trabajadorEntity.TelefonoPersonal = data.TelefonoPersonal;
            trabajadorEntity.CorreoElectronico = data.CorreoElectronico;
            trabajadorEntity.Dominio = data.Dominio;    
            trabajadorEntity.EstadoRegistro = trabajadorEntity.EstadoRegistro;
            return trabajadorEntity;
        }

        /// <summary>
        /// Obtiene una entidad de tipo trabajador
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Entity de Trabajador</returns>
        public static TrabajadorSuplenteEntity ObtenerTrabajadorSuplenteEntity(TrabajadorSuplenteRequest data)
        {
            var trabajadorSuplenteEntity = new TrabajadorSuplenteEntity();

            try
            {
                if (data.CodigoSuplente != null)
                {
                    trabajadorSuplenteEntity.CodigoTrabajador = data.CodigoTrabajador;
                }
                else
                {
                    trabajadorSuplenteEntity.CodigoTrabajador = Guid.NewGuid();
                }

                trabajadorSuplenteEntity.CodigoSuplente = data.CodigoSuplente;
                trabajadorSuplenteEntity.FechaInicio = Convert.ToDateTime(data.FechaInicio);
                trabajadorSuplenteEntity.FechaFin = Convert.ToDateTime(data.FechaFin);
                trabajadorSuplenteEntity.Activo = data.Activo;
                trabajadorSuplenteEntity.Ejecutado = data.Ejecutado;
                trabajadorSuplenteEntity.EstadoRegistro = data.EstadoRegistro;
                trabajadorSuplenteEntity.PerfilesAgregados = data.PerfilesAgregados;

                
            }
            catch (Exception ex)
            {
                //throw ex;
                LogEN.grabarLogError(ex, data.FechaInicio + data.FechaFin);
            }

            return trabajadorSuplenteEntity;

        }

        /// <summary>
        /// Obtiene una entidad de tipo trabajador
        /// </summary>
        /// <param name="data">Data</param>
        /// <returns>Entity de Trabajador</returns>
        public static TrabajadorUnidadOperativaEntity ObtenerTrabajadorUnidadOperativaEntity(TrabajadorUnidadOperativaRequest data)
        {
            var trabajadorUnidadOperativaEntity = new TrabajadorUnidadOperativaEntity();
            if (data.CodigoTrabajadorUnidadOperativa != null)
            {
                trabajadorUnidadOperativaEntity.CodigoTrabajadorUnidadOperativa = data.CodigoTrabajadorUnidadOperativa;
            }
            else
            {
                trabajadorUnidadOperativaEntity.CodigoTrabajadorUnidadOperativa = Guid.NewGuid();
            }
            trabajadorUnidadOperativaEntity.CodigoUnidadOperativaMatriz = data.CodigoUnidadOperativaMatriz.Value;
            trabajadorUnidadOperativaEntity.CodigoTrabajador = data.CodigoTrabajador;
            trabajadorUnidadOperativaEntity.CodigoUnidadOperativa = data.CodigoUnidadOperativa;
            trabajadorUnidadOperativaEntity.EstadoRegistro = data.EstadoRegistro;
            return trabajadorUnidadOperativaEntity;
        }

        /// <summary>
        /// Obtiene el trabajador de dato minímo
        /// </summary>
        /// <param name="trabajadorLogic">Trabajador</param>
        /// <returns>Response de dato minímo</returns>
        public static TrabajadorDatoMinimoResponse ObtenerTrabajadorDatoMinimo(TrabajadorLogic trabajadorLogic)
        {
            TrabajadorDatoMinimoResponse trabajadorDMResponse = new TrabajadorDatoMinimoResponse();
            trabajadorDMResponse.CodigoTrabajador = (Guid)trabajadorLogic.CodigoTrabajador;
            trabajadorDMResponse.Dominio = trabajadorLogic.Dominio;
            trabajadorDMResponse.DominioCorto = !string.IsNullOrEmpty(trabajadorLogic.Dominio) ? trabajadorLogic.Dominio.Split('.').FirstOrDefault() : null;
            trabajadorDMResponse.CodigoIdentificacion = trabajadorLogic.CodigoIdentificacion;
            trabajadorDMResponse.NombreCompleto = trabajadorLogic.NombreCompleto;
            trabajadorDMResponse.LinkFoto = trabajadorLogic.IndicadorTieneFoto ? DatosConstantes.ConfiguracionFileServer.UbicacionFotoColaborador + trabajadorLogic.CodigoTrabajador.ToString() + ".jpg" : null;
            trabajadorDMResponse.CorreoElectronico = trabajadorLogic.CorreoElectronico;
            trabajadorDMResponse.Departamento = trabajadorLogic.Departamento;
            trabajadorDMResponse.Cargo = trabajadorLogic.Cargo;
            return trabajadorDMResponse;
        }

        /// <summary>
        /// Obtiene el trabajador de dato minímo
        /// </summary>
        /// <param name="trabajadorUnidadOperativaLogic">Trabajador</param>
        /// <returns>Response de dato minímo</returns>
        public static TrabajadorUnidadOperativaResponse ObtenerTrabajadorUnidadOperativaResponse(TrabajadorUnidadOperativaLogic trabajadorUnidadOperativaLogic)
        {
            TrabajadorUnidadOperativaResponse trabajadorUnidadOperativa = new TrabajadorUnidadOperativaResponse();
            trabajadorUnidadOperativa.CodigoTrabajadorUnidadOperativa = trabajadorUnidadOperativaLogic.CodigoTrabajadorUnidadOperativa;
            trabajadorUnidadOperativa.CodigoUnidadOperativaMatriz = trabajadorUnidadOperativaLogic.CodigoUnidadOperativaMatriz;
            trabajadorUnidadOperativa.CodigoTrabajador = trabajadorUnidadOperativaLogic.CodigoTrabajador;
            trabajadorUnidadOperativa.CodigoUnidadOperativa = trabajadorUnidadOperativaLogic.CodigoUnidadOperativa;
            trabajadorUnidadOperativa.NombreUnidadOperativa = trabajadorUnidadOperativaLogic.NombreUnidadOperativa;
            trabajadorUnidadOperativa.EstadoRegistro = trabajadorUnidadOperativaLogic.EstadoRegistro;
            trabajadorUnidadOperativa.FechaCreacion = trabajadorUnidadOperativaLogic.FechaCreacion;

            return trabajadorUnidadOperativa;
        }

        /// <summary>
        /// Obtiene el trabajador suplente
        /// </summary>
        /// <param name="trabajadorSuplenteLogic">TrabajadorSuplenteLogic</param>
        /// <returns>Response de trabajador suplente</returns>
        public static TrabajadorSuplenteResponse ObtenerTrabajadorSuplenteResponse(TrabajadorSuplenteLogic trabajadorSuplenteLogic)
        {
            TrabajadorSuplenteResponse trabajadorSuplente = new TrabajadorSuplenteResponse();
            trabajadorSuplente.CodigoTrabajador = trabajadorSuplenteLogic.CodigoTrabajador;
            trabajadorSuplente.CodigoSuplente = trabajadorSuplenteLogic.CodigoSuplente;
            trabajadorSuplente.FechaInicio = trabajadorSuplenteLogic.FechaInicio;
            trabajadorSuplente.FechaFin = trabajadorSuplenteLogic.FechaFin;
            trabajadorSuplente.FechaInicioString = trabajadorSuplenteLogic.FechaInicio.ToString(DatosConstantes.Formato.FormatoFecha);
            trabajadorSuplente.FechaFinString = trabajadorSuplenteLogic.FechaFin.ToString(DatosConstantes.Formato.FormatoFecha);
            trabajadorSuplente.Activo = trabajadorSuplenteLogic.Activo;
            trabajadorSuplente.Ejecutado = trabajadorSuplenteLogic.Ejecutado;
            trabajadorSuplente.PerfilAgregados = trabajadorSuplenteLogic.PerfilAgregados;
            return trabajadorSuplente;
        }
    }
}
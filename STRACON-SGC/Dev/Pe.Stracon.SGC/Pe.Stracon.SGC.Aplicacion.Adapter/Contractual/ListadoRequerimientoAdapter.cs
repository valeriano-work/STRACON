
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Infraestructura.QueryModel;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Query.Contractual;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.Adapter.Contractual
{
    /// <summary>
    /// Implementación del Adaptador de Listado Requerimiento
    /// </summary>
    public sealed class ListadoRequerimientoAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="listadoRequerimientoLogic">Entidad Lógica Listado Requerimiento</param>
        /// <param name="tipoServicio">Lista de Tipos de Servicios</param>
        /// <param name="tipoRequerimiento">Lista de Tipos de Requerimientos</param>
        /// <param name="tipoDocumentoRequerimiento">Lista de Documentos de Requerimientos</param>
        /// <param name="estadoRequerimiento">Lista de Estados de Requerimientos</param>
        /// <param name="listaTrabajador">Lista de Trabajador</param>
        /// <param name="listaUnidadOperativa">Lista de Unidad Operativa</param>
        /// <returns>Clase Listado Requerimiento Response con los datos de búsqueda</returns>
        public static ListadoRequerimientoResponse ObtenerListadoRequerimientoPaginado(ListadoRequerimientoLogic listadoRequerimientoLogic, List<CodigoValorResponse> tipoServicio = null, List<CodigoValorResponse> tipoRequerimiento = null, List<CodigoValorResponse> tipoDocumento = null, List<CodigoValorResponse> estadoRequerimiento = null, List<CodigoValorResponse> estadoEdicion = null, List<TrabajadorDatoMinimoResponse> listaTrabajador = null, List<UnidadOperativaResponse> listaUnidadOperativa = null)
        {
            string descripcionTipoServicio = null;
            string descripcionTipoRequerimiento = null;
            string descripcionTipoDocumento = null;
            string descripcionEstadoRequerimiento = null;
            string descripcionEstadoEdicion = null;

            if (tipoServicio != null)
            {
                var tServicio = tipoServicio.Where(n => n.Codigo.ToString() == listadoRequerimientoLogic.CodigoTipoServicio).FirstOrDefault();
                descripcionTipoServicio = (tServicio == null ? null : tServicio.Valor.ToString());
            }

            if (tipoRequerimiento != null)
            {
                var tRequerimiento = tipoRequerimiento.Where(n => n.Codigo.ToString() == listadoRequerimientoLogic.CodigoTipoRequerimiento).FirstOrDefault();
                descripcionTipoRequerimiento = (tRequerimiento == null ? null : tRequerimiento.Valor.ToString());
            }

            if (tipoDocumento != null)
            {
                var tDocumentoRequerimiento = tipoDocumento.Where(n => n.Codigo.ToString() == listadoRequerimientoLogic.CodigoTipoDocumento).FirstOrDefault();
                descripcionTipoDocumento = (tDocumentoRequerimiento == null ? null : tDocumentoRequerimiento.Valor.ToString());
            }

            if (estadoRequerimiento != null)
            {
                var eRequerimiento = estadoRequerimiento.Where(n => n.Codigo.ToString() == listadoRequerimientoLogic.CodigoEstadoRequerimiento).FirstOrDefault();
                descripcionEstadoRequerimiento = (eRequerimiento == null ? null : eRequerimiento.Valor.ToString());
            }

            if (estadoEdicion != null)
            {
                if (listadoRequerimientoLogic.CodigoEstadoRequerimiento == DatosConstantes.EstadoRequerimiento.Edicion || listadoRequerimientoLogic.CodigoEstadoRequerimiento == DatosConstantes.EstadoRequerimiento.Revision)
                {
                    var eEdicion = estadoEdicion.Where(n => n.Codigo.ToString() == listadoRequerimientoLogic.CodigoEstadoEdicion).FirstOrDefault();
                    descripcionEstadoEdicion = (eEdicion == null ? null : eEdicion.Valor.ToString());
                }
            }

            var listadoRequerimientoResponse = new ListadoRequerimientoResponse();

            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = ",";

            listadoRequerimientoResponse.CodigoRequerimiento = listadoRequerimientoLogic.CodigoRequerimiento;
            listadoRequerimientoResponse.CodigoUnidadOperativa = listadoRequerimientoLogic.CodigoUnidadOperativa;

            string strGuid = listadoRequerimientoResponse.CodigoUnidadOperativa.ToString();
            var nombreUnidad = string.Empty;
            if (strGuid != "00000000-0000-0000-0000-000000000000")
            {
                var unidadEncontrada = listaUnidadOperativa.Where(item => item.CodigoUnidadOperativa == listadoRequerimientoLogic.CodigoUnidadOperativa);
                if (unidadEncontrada != null && unidadEncontrada.FirstOrDefault() != null)
                {
                    nombreUnidad = unidadEncontrada.FirstOrDefault().Nombre;
                }
            }
            else
            {

            }

            listadoRequerimientoResponse.NombreUnidadOperativa = nombreUnidad;
            listadoRequerimientoResponse.CodigoProveedor = listadoRequerimientoLogic.CodigoProveedor;
            listadoRequerimientoResponse.NumeroDocumentoProveedor = listadoRequerimientoLogic.NumeroDocumentoProveedor;
            listadoRequerimientoResponse.NombreProveedor = listadoRequerimientoLogic.NombreProveedor;
            listadoRequerimientoResponse.NumeroRequerimiento = listadoRequerimientoLogic.NumeroRequerimiento;
            listadoRequerimientoResponse.Descripcion = listadoRequerimientoLogic.Descripcion;
            //listadoRequerimientoResponse.CodigoTipoServicio = listadoRequerimientoLogic.CodigoTipoServicio;
            //listadoRequerimientoResponse.DescripcionTipoServicio = descripcionTipoServicio;
            listadoRequerimientoResponse.CodigoTipoRequerimiento = listadoRequerimientoLogic.CodigoTipoRequerimiento;
            listadoRequerimientoResponse.DescripcionTipoRequerimiento = descripcionTipoRequerimiento;
            listadoRequerimientoResponse.CodigoTipoDocumento = listadoRequerimientoLogic.CodigoTipoDocumento;
            listadoRequerimientoResponse.DescripcionTipoDocumento = descripcionTipoDocumento;
            listadoRequerimientoResponse.CodigoEstadoRequerimiento = listadoRequerimientoLogic.CodigoEstadoRequerimiento;
            listadoRequerimientoResponse.DescripcionEstadoRequerimiento = descripcionEstadoRequerimiento;
            listadoRequerimientoResponse.FechaInicioVigencia = listadoRequerimientoLogic.FechaInicioVigencia;
            listadoRequerimientoResponse.FechaInicioVigenciaString = listadoRequerimientoLogic.FechaInicioVigencia.ToString(DatosConstantes.Formato.FormatoFecha);
            listadoRequerimientoResponse.FechaFinVigencia = listadoRequerimientoLogic.FechaFinVigencia;
            listadoRequerimientoResponse.FechaFinVigenciaString = listadoRequerimientoLogic.FechaFinVigencia.ToString(DatosConstantes.Formato.FormatoFecha);
            listadoRequerimientoResponse.FechaResolucion = listadoRequerimientoLogic.FechaResolucion;
            listadoRequerimientoResponse.ValidacionResolucion = listadoRequerimientoLogic.ValidacionResolucion;

            if (listadoRequerimientoResponse.FechaResolucion == new DateTime(3100, 12, 30))
            {
                listadoRequerimientoResponse.FechaResolucionString = string.Empty;
            }
            else
            {
                listadoRequerimientoResponse.FechaResolucionString = listadoRequerimientoLogic.FechaResolucion.ToString(DatosConstantes.Formato.FormatoFecha);
            }

            if (listadoRequerimientoResponse.FechaInicioVigencia > listadoRequerimientoResponse.FechaFinVigencia)
            {
                listadoRequerimientoResponse.DiasVencimiento = 0;
            }
            else
            {
                listadoRequerimientoResponse.DiasVencimiento = (listadoRequerimientoResponse.FechaFinVigencia - DateTime.Today).Days;
            }

            listadoRequerimientoResponse.CodigoMoneda = listadoRequerimientoLogic.CodigoMoneda;

            listadoRequerimientoResponse.MontoRequerimiento = listadoRequerimientoLogic.MontoRequerimiento;
            listadoRequerimientoResponse.MontoRequerimientoString = listadoRequerimientoLogic.MontoRequerimiento.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            listadoRequerimientoResponse.MontoAcumulado = listadoRequerimientoLogic.MontoAcumulado;
            listadoRequerimientoResponse.MontoAcumuladoString = listadoRequerimientoLogic.MontoAcumulado.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);

            listadoRequerimientoResponse.CodigoEstadoEdicion = listadoRequerimientoLogic.CodigoEstadoEdicion;
            listadoRequerimientoResponse.DescripcionEstadoEdicion = descripcionEstadoEdicion;
            listadoRequerimientoResponse.CodigoPlantilla = listadoRequerimientoLogic.CodigoPlantilla;
            listadoRequerimientoResponse.CodigoRequerimientoPrincipal = listadoRequerimientoLogic.CodigoRequerimientoPrincipal;
            listadoRequerimientoResponse.CodigoTrabajadorResponsable = listadoRequerimientoLogic.CodigoTrabajadorResponsable;

            var trabajadorResponsable = listadoRequerimientoLogic.CodigoTrabajadorResponsable.HasValue ? listaTrabajador.Where(item => item.CodigoTrabajador == listadoRequerimientoLogic.CodigoTrabajadorResponsable.Value).FirstOrDefault() : null;

            listadoRequerimientoResponse.NombreTrajadorResponsable = trabajadorResponsable != null ? trabajadorResponsable.NombreCompleto : null;
            listadoRequerimientoResponse.CantidadAdenda = listadoRequerimientoLogic.CantidadAdenda;
            listadoRequerimientoResponse.NumeroAdendaConcatenado = listadoRequerimientoLogic.NumeroAdendaConcatenado;
            listadoRequerimientoResponse.IndicadorAdhesion = listadoRequerimientoLogic.IndicadorAdhesion;
            listadoRequerimientoResponse.ComentarioModificacion = listadoRequerimientoLogic.ComentarioModificacion;
            listadoRequerimientoResponse.FechaCreacionString = listadoRequerimientoLogic.FechaCreacion.ToString(DatosConstantes.Formato.FormatoFecha);
            listadoRequerimientoResponse.UsuarioCreacion = listadoRequerimientoLogic.UsuarioCreacion;
            listadoRequerimientoResponse.EsFlexible = listadoRequerimientoLogic.EsFlexible;

            if (listadoRequerimientoLogic.FechaCreacionEstadioActual.HasValue)
            {
                TimeSpan ts = DateTime.Now.Date - listadoRequerimientoLogic.FechaCreacionEstadioActual.Value.Date;
                if (ts.Days < 0)
                {
                    listadoRequerimientoResponse.DiasEnBandeja = 0;
                }
                else
                {
                    listadoRequerimientoResponse.DiasEnBandeja = ts.Days;
                }
            }

            listadoRequerimientoResponse.FilasTotal = listadoRequerimientoLogic.TotalRegistro;
            listadoRequerimientoResponse.NumeroFila = listadoRequerimientoLogic.NumeroRegistro;
          listadoRequerimientoResponse.NombreEstadioActual = listadoRequerimientoLogic.NombreEstadioActual;

            return listadoRequerimientoResponse;
        }


        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="listadoRequerimientoLogic">Entidad Lógica Listado Requerimiento</param>     
        /// <returns>Clase Listado Requerimiento Response con los datos de búsqueda</returns>
        public static ListadoRequerimientoResponse ObtenerBusquedaRequerimiento(ListadoRequerimientoLogic listadoRequerimientoLogic)
        {
            string descripcionTipoServicio = null;
            string descripcionTipoRequerimiento = null;
            string descripcionTipoDocumento = null;
            string descripcionEstadoRequerimiento = null;
            string descripcionEstadoEdicion = null;


            var listadoRequerimientoResponse = new ListadoRequerimientoResponse();

            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = ",";

            listadoRequerimientoResponse.CodigoRequerimiento = listadoRequerimientoLogic.CodigoRequerimiento;
            listadoRequerimientoResponse.CodigoUnidadOperativa = listadoRequerimientoLogic.CodigoUnidadOperativa;
            listadoRequerimientoResponse.CodigoProveedor = listadoRequerimientoLogic.CodigoProveedor;
            listadoRequerimientoResponse.NumeroDocumentoProveedor = listadoRequerimientoLogic.NumeroDocumentoProveedor;
            listadoRequerimientoResponse.NombreProveedor = listadoRequerimientoLogic.NombreProveedor;
            listadoRequerimientoResponse.NumeroRequerimiento = listadoRequerimientoLogic.NumeroRequerimiento;
            listadoRequerimientoResponse.Descripcion = listadoRequerimientoLogic.Descripcion;
            //listadoRequerimientoResponse.CodigoTipoServicio = listadoRequerimientoLogic.CodigoTipoServicio;
            //listadoRequerimientoResponse.DescripcionTipoServicio = descripcionTipoServicio;
            listadoRequerimientoResponse.CodigoTipoRequerimiento = listadoRequerimientoLogic.CodigoTipoRequerimiento;
            listadoRequerimientoResponse.DescripcionTipoRequerimiento = descripcionTipoRequerimiento;
            listadoRequerimientoResponse.CodigoTipoDocumento = listadoRequerimientoLogic.CodigoTipoDocumento;
            listadoRequerimientoResponse.DescripcionTipoDocumento = descripcionTipoDocumento;
            listadoRequerimientoResponse.CodigoEstadoRequerimiento = listadoRequerimientoLogic.CodigoEstadoRequerimiento;
            listadoRequerimientoResponse.DescripcionEstadoRequerimiento = descripcionEstadoRequerimiento;
            listadoRequerimientoResponse.FechaInicioVigencia = listadoRequerimientoLogic.FechaInicioVigencia;
            listadoRequerimientoResponse.FechaInicioVigenciaString = listadoRequerimientoLogic.FechaInicioVigencia.ToString(DatosConstantes.Formato.FormatoFecha);
            listadoRequerimientoResponse.FechaFinVigencia = listadoRequerimientoLogic.FechaFinVigencia;
            listadoRequerimientoResponse.FechaFinVigenciaString = listadoRequerimientoLogic.FechaFinVigencia.ToString(DatosConstantes.Formato.FormatoFecha);

            if (listadoRequerimientoResponse.FechaInicioVigencia > listadoRequerimientoResponse.FechaFinVigencia)
            {
                listadoRequerimientoResponse.DiasVencimiento = 0;
            }
            else
            {
                listadoRequerimientoResponse.DiasVencimiento = (listadoRequerimientoResponse.FechaFinVigencia - DateTime.Today).Days;
            }

            listadoRequerimientoResponse.CodigoMoneda = listadoRequerimientoLogic.CodigoMoneda;
            listadoRequerimientoResponse.MontoRequerimiento = listadoRequerimientoLogic.MontoRequerimiento;
            listadoRequerimientoResponse.MontoRequerimientoString = listadoRequerimientoLogic.MontoRequerimiento.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            listadoRequerimientoResponse.CodigoEstadoEdicion = listadoRequerimientoLogic.CodigoEstadoEdicion;
            listadoRequerimientoResponse.DescripcionEstadoEdicion = descripcionEstadoEdicion;
            listadoRequerimientoResponse.CodigoPlantilla = listadoRequerimientoLogic.CodigoPlantilla;
            listadoRequerimientoResponse.CodigoRequerimientoPrincipal = listadoRequerimientoLogic.CodigoRequerimientoPrincipal;
            listadoRequerimientoResponse.CodigoTrabajadorResponsable = listadoRequerimientoLogic.CodigoTrabajadorResponsable;

            listadoRequerimientoResponse.CantidadAdenda = listadoRequerimientoLogic.CantidadAdenda;
            listadoRequerimientoResponse.NumeroAdendaConcatenado = listadoRequerimientoLogic.NumeroAdendaConcatenado;
            listadoRequerimientoResponse.IndicadorAdhesion = listadoRequerimientoLogic.IndicadorAdhesion;
            listadoRequerimientoResponse.ComentarioModificacion = listadoRequerimientoLogic.ComentarioModificacion;
            listadoRequerimientoResponse.FechaCreacionString = listadoRequerimientoLogic.FechaCreacion.ToString(DatosConstantes.Formato.FormatoFecha);
            listadoRequerimientoResponse.UsuarioCreacion = listadoRequerimientoLogic.UsuarioCreacion;
            listadoRequerimientoResponse.EsFlexible = listadoRequerimientoLogic.EsFlexible;
            listadoRequerimientoResponse.NombreEstadioActual = listadoRequerimientoLogic.NombreEstadioActual;

            return listadoRequerimientoResponse;
        }


        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Requerimiento con los datos a registrar</returns>
        public static RequerimientoEntity RegistrarRequerimiento(RequerimientoRequest data)
        {
            var contratoEntity = new RequerimientoEntity();
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = ",";

            if (data.CodigoRequerimiento != null)
            {
                contratoEntity.CodigoRequerimiento = new Guid(data.CodigoRequerimiento.ToString());
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                contratoEntity.CodigoRequerimiento = code;
            }

            contratoEntity.CodigoUnidadOperativa = new Guid(data.CodigoUnidadOperativa.ToString());
            contratoEntity.CodigoProveedor = data.CodigoProveedor;
            contratoEntity.NumeroRequerimiento = data.NumeroRequerimiento;
            contratoEntity.Descripcion = data.Descripcion;
            contratoEntity.CodigoTipoServicio = data.CodigoTipoServicio;
            contratoEntity.CodigoTipoRequerimiento = data.CodigoTipoRequerimiento;
            contratoEntity.CodigoTipoDocumento = data.CodigoTipoDocumento;
            contratoEntity.FechaInicioVigencia = DateTime.ParseExact(data.FechaInicioVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
            contratoEntity.FechaFinVigencia = DateTime.ParseExact(data.FechaFinVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
            contratoEntity.CodigoMoneda = data.CodigoMoneda;
            contratoEntity.MontoRequerimiento = Decimal.Parse(data.MontoRequerimientoString, numberFormatInfo);
            contratoEntity.MontoAcumulado = (data.MontoAcumuladoString != null) ? Decimal.Parse(data.MontoAcumuladoString, numberFormatInfo) : 0;
            contratoEntity.CodigoEstado = data.CodigoEstado;
            contratoEntity.CodigoPlantilla = data.CodigoPlantilla;
            contratoEntity.CodigoFlujoAprobacion = new Guid(data.CodigoFlujoAprobacion);
            contratoEntity.CodigoEstadoEdicion = data.CodigoEstadoEdicion;
            contratoEntity.ComentarioModificacion = data.ComentarioModificacion;
            contratoEntity.CodigoRequerimientoPrincipal = data.CodigoRequerimientoPrincipal;
            contratoEntity.FechaCreacion = DateTime.Now;
            contratoEntity.NumeroAdenda = data.NumeroAdenda;
            contratoEntity.NumeroAdendaConcatenado = data.NumeroAdendaConcatenado;
            contratoEntity.EsFlexible = false;
            contratoEntity.EsCorporativo = data.EsCorporativo;
            contratoEntity.CodigoRequerido = new Guid(data.CodigoRequerido);

            return contratoEntity;
        }

        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Requerimiento con los datos a registrar</returns>
        public static RequerimientoEntity RegistrarCopiaRequerimiento(RequerimientoRequest data)
        {
            try
            {
                var contratoEntity = new RequerimientoEntity();

                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";
                numberFormatInfo.NumberGroupSeparator = ",";

                contratoEntity.CodigoRequerimiento = Guid.NewGuid();
                contratoEntity.CodigoUnidadOperativa = new Guid(data.CodigoUnidadOperativa.ToString());
                contratoEntity.CodigoProveedor = data.CodigoProveedor;
                contratoEntity.NumeroRequerimiento = data.NumeroRequerimiento;
                contratoEntity.Descripcion = data.Descripcion;
                contratoEntity.CodigoTipoServicio = data.CodigoTipoServicio;
                contratoEntity.CodigoTipoRequerimiento = data.CodigoTipoRequerimiento;
                contratoEntity.CodigoTipoDocumento = data.CodigoTipoDocumento;
                contratoEntity.FechaInicioVigencia = DateTime.ParseExact(data.FechaInicioVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
                contratoEntity.FechaFinVigencia = DateTime.ParseExact(data.FechaFinVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
                contratoEntity.CodigoMoneda = data.CodigoMoneda;
                contratoEntity.MontoRequerimiento = Decimal.Parse(data.MontoRequerimientoString, numberFormatInfo);
                contratoEntity.MontoAcumulado = (data.MontoAcumuladoString != null) ? Decimal.Parse(data.MontoAcumuladoString, numberFormatInfo) : 0;
                contratoEntity.CodigoEstado = data.CodigoEstado;
                contratoEntity.CodigoPlantilla = data.CodigoPlantilla;
                contratoEntity.CodigoFlujoAprobacion = new Guid(data.CodigoFlujoAprobacion);
                contratoEntity.CodigoEstadoEdicion = data.CodigoEstadoEdicion;
                contratoEntity.ComentarioModificacion = data.ComentarioModificacion;
                contratoEntity.CodigoRequerimientoPrincipal = data.CodigoRequerimientoPrincipal;
                contratoEntity.FechaCreacion = DateTime.Now;
                contratoEntity.NumeroAdenda = data.NumeroAdenda;
                contratoEntity.NumeroAdendaConcatenado = data.NumeroAdendaConcatenado;
                contratoEntity.EsFlexible = data.EsFlexible;
                contratoEntity.EsCorporativo = data.EsCorporativo;
                contratoEntity.CodigoRequerimientoOriginal = new Guid(data.CodigoRequerimiento);

                return contratoEntity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="data">Datos a adaptar</param>
        /// <returns>Objeto RequerimientoParafoResponse</returns>
        public static RequerimientoParrafoVariableResponse ObtenerRequerimientoParrafoVariable(RequerimientoParrafoVariableLogic data)
        {
            var contratoParrafoVariableResponse = new RequerimientoParrafoVariableResponse();
            contratoParrafoVariableResponse.CodigoRequerimientoParrafoVariable = data.CodigoRequerimientoParrafoVariable;
            contratoParrafoVariableResponse.CodigoRequerimientoParrafo = data.CodigoRequerimientoParrafo;
            contratoParrafoVariableResponse.CodigoPlantillaParrafo = data.CodigoPlantillaParrafo;
            contratoParrafoVariableResponse.CodigoVariable = data.CodigoVariable;
            contratoParrafoVariableResponse.ValorTexto = data.ValorTexto;
            contratoParrafoVariableResponse.ValorNumero = data.ValorNumero;
            contratoParrafoVariableResponse.ValorFechaString = (data.ValorFecha.HasValue) ? data.ValorFecha.Value.ToString("dd/MM/yyyy") : "";
            contratoParrafoVariableResponse.ValorImagen = data.ValorImagen;
            contratoParrafoVariableResponse.CodigoTipo = data.CodigoTipo;
            contratoParrafoVariableResponse.ValorTabla = data.ValorTabla;
            contratoParrafoVariableResponse.ValorTablaEditable = data.ValorTablaEditable;
            contratoParrafoVariableResponse.ValorBien = data.ValorBien;
            contratoParrafoVariableResponse.ValorBienEditable = data.ValorBienEditable;
            contratoParrafoVariableResponse.ValorFirmante = data.ValorFirmante;
            contratoParrafoVariableResponse.ValorFirmanteEditable = data.ValorFirmanteEditable;
            contratoParrafoVariableResponse.Identificador = data.Identificador;
            contratoParrafoVariableResponse.ValorLista = data.ValorLista;
            return contratoParrafoVariableResponse;
        }

        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="data">Datos a adaptar</param>
        /// <returns>Objeto RequerimientoParrafoVariableResponse</returns>
        public static RequerimientoBienResponse ObtenerRequerimientoBienResponse(RequerimientoBienLogic data)
        {
            var contratoBienResponse = new RequerimientoBienResponse();
            contratoBienResponse.CodigoRequerimientoBien = data.CodigoRequerimientoBien;
            contratoBienResponse.CodigoRequerimiento = data.CodigoRequerimiento;
            contratoBienResponse.CodigoBien = data.CodigoBien;
            contratoBienResponse.EstadoRegistro = data.EstadoRegistro;

            return contratoBienResponse;
        }

        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="data">Datos a adaptar</param>
        /// <returns>Objeto RequerimientoParrafoFirmanteResponse</returns>
        public static RequerimientoFirmanteResponse ObtenerRequerimientoFirmanteResponse(RequerimientoFirmanteLogic data)
        {
            var contratoFirmanteResponse = new RequerimientoFirmanteResponse();
            contratoFirmanteResponse.CodigoRequerimientoFirmante = data.CodigoRequerimientoFirmante.ToString();
            contratoFirmanteResponse.CodigoRequerimientoParrafoVariable = data.CodigoRequerimientoParrafoVariable.ToString();
            contratoFirmanteResponse.NombreFirmante = data.NombreFirmante;
            contratoFirmanteResponse.DatoAdicional = data.DatoAdicional;

            return contratoFirmanteResponse;
        }

    }
}

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
    /// Implementación del Adaptador de Listado Contrato
    /// </summary>
    public sealed class ListadoContratoAdapter
    {
        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="listadoContratoLogic">Entidad Lógica Listado Contrato</param>
        /// <param name="tipoServicio">Lista de Tipos de Servicios</param>
        /// <param name="tipoRequerimiento">Lista de Tipos de Requerimientos</param>
        /// <param name="tipoDocumentoContrato">Lista de Documentos de Contratos</param>
        /// <param name="estadoContrato">Lista de Estados de Contratos</param>
        /// <param name="listaTrabajador">Lista de Trabajador</param>
        /// <param name="listaUnidadOperativa">Lista de Unidad Operativa</param>
        /// <returns>Clase Listado Contrato Response con los datos de búsqueda</returns>
        public static ListadoContratoResponse ObtenerListadoContratoPaginado(ListadoContratoLogic listadoContratoLogic, List<CodigoValorResponse> tipoServicio = null, List<CodigoValorResponse> tipoRequerimiento = null, List<CodigoValorResponse> tipoDocumento = null, List<CodigoValorResponse> estadoContrato = null, List<CodigoValorResponse> estadoEdicion = null, List<TrabajadorDatoMinimoResponse> listaTrabajador = null, List<UnidadOperativaResponse> listaUnidadOperativa = null)
        {
            string descripcionTipoServicio = null;
            string descripcionTipoRequerimiento = null;
            string descripcionTipoDocumento = null;
            string descripcionEstadoContrato = null;
            string descripcionEstadoEdicion = null;

            if (tipoServicio != null)
            {
                var tServicio = tipoServicio.Where(n => n.Codigo.ToString() == listadoContratoLogic.CodigoTipoServicio).FirstOrDefault();
                descripcionTipoServicio = (tServicio == null ? null : tServicio.Valor.ToString());
            }

            if (tipoRequerimiento != null)
            {
                var tRequerimiento = tipoRequerimiento.Where(n => n.Codigo.ToString() == listadoContratoLogic.CodigoTipoRequerimiento).FirstOrDefault();
                descripcionTipoRequerimiento = (tRequerimiento == null ? null : tRequerimiento.Valor.ToString());
            }

            if (tipoDocumento != null)
            {
                var tDocumentoContrato = tipoDocumento.Where(n => n.Codigo.ToString() == listadoContratoLogic.CodigoTipoDocumento).FirstOrDefault();
                descripcionTipoDocumento = (tDocumentoContrato == null ? null : tDocumentoContrato.Valor.ToString());
            }

            if (estadoContrato != null)
            {
                var eContrato = estadoContrato.Where(n => n.Codigo.ToString() == listadoContratoLogic.CodigoEstadoContrato).FirstOrDefault();
                descripcionEstadoContrato = (eContrato == null ? null : eContrato.Valor.ToString());
            }

            if (estadoEdicion != null)
            {
                if (listadoContratoLogic.CodigoEstadoContrato == DatosConstantes.EstadoContrato.Edicion || listadoContratoLogic.CodigoEstadoContrato == DatosConstantes.EstadoContrato.Revision)
                {
                    var eEdicion = estadoEdicion.Where(n => n.Codigo.ToString() == listadoContratoLogic.CodigoEstadoEdicion).FirstOrDefault();
                    descripcionEstadoEdicion = (eEdicion == null ? null : eEdicion.Valor.ToString());
                }
            }

            var listadoContratoResponse = new ListadoContratoResponse();

            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = ",";

            listadoContratoResponse.CodigoContrato = listadoContratoLogic.CodigoContrato;
            listadoContratoResponse.CodigoUnidadOperativa = listadoContratoLogic.CodigoUnidadOperativa;

            string strGuid = listadoContratoResponse.CodigoUnidadOperativa.ToString();
            var nombreUnidad = string.Empty;
            if (strGuid != "00000000-0000-0000-0000-000000000000")
            {
                var unidadEncontrada = listaUnidadOperativa.Where(item => item.CodigoUnidadOperativa == listadoContratoLogic.CodigoUnidadOperativa);
                if (unidadEncontrada != null && unidadEncontrada.FirstOrDefault() != null)
                {
                    nombreUnidad = unidadEncontrada.FirstOrDefault().Nombre;
                }
            }
            else
            {

            }

            listadoContratoResponse.NombreUnidadOperativa = nombreUnidad;
            listadoContratoResponse.CodigoProveedor = listadoContratoLogic.CodigoProveedor;
            listadoContratoResponse.NumeroDocumentoProveedor = listadoContratoLogic.NumeroDocumentoProveedor;
            listadoContratoResponse.NombreProveedor = listadoContratoLogic.NombreProveedor;
            listadoContratoResponse.NumeroContrato = listadoContratoLogic.NumeroContrato;
            listadoContratoResponse.Descripcion = listadoContratoLogic.Descripcion;
            listadoContratoResponse.CodigoTipoServicio = listadoContratoLogic.CodigoTipoServicio;
            listadoContratoResponse.DescripcionTipoServicio = descripcionTipoServicio;
            listadoContratoResponse.CodigoTipoRequerimiento = listadoContratoLogic.CodigoTipoRequerimiento;
            listadoContratoResponse.DescripcionTipoRequerimiento = descripcionTipoRequerimiento;
            listadoContratoResponse.CodigoTipoDocumento = listadoContratoLogic.CodigoTipoDocumento;
            listadoContratoResponse.DescripcionTipoDocumento = descripcionTipoDocumento;
            listadoContratoResponse.CodigoEstadoContrato = listadoContratoLogic.CodigoEstadoContrato;
            listadoContratoResponse.DescripcionEstadoContrato = descripcionEstadoContrato;
            listadoContratoResponse.FechaInicioVigencia = listadoContratoLogic.FechaInicioVigencia;
            listadoContratoResponse.FechaInicioVigenciaString = listadoContratoLogic.FechaInicioVigencia.ToString(DatosConstantes.Formato.FormatoFecha);
            listadoContratoResponse.FechaFinVigencia = listadoContratoLogic.FechaFinVigencia;
            listadoContratoResponse.FechaFinVigenciaString = listadoContratoLogic.FechaFinVigencia.ToString(DatosConstantes.Formato.FormatoFecha);
            listadoContratoResponse.FechaResolucion = listadoContratoLogic.FechaResolucion;
            listadoContratoResponse.ValidacionResolucion = listadoContratoLogic.ValidacionResolucion;

            if (listadoContratoResponse.FechaResolucion == new DateTime(3100, 12, 30))
            {
                listadoContratoResponse.FechaResolucionString = string.Empty;
            }
            else
            {
                listadoContratoResponse.FechaResolucionString = listadoContratoLogic.FechaResolucion.ToString(DatosConstantes.Formato.FormatoFecha);
            }

            if (listadoContratoResponse.FechaInicioVigencia > listadoContratoResponse.FechaFinVigencia)
            {
                listadoContratoResponse.DiasVencimiento = 0;
            }
            else
            {
                listadoContratoResponse.DiasVencimiento = (listadoContratoResponse.FechaFinVigencia - DateTime.Today).Days;
            }

            listadoContratoResponse.CodigoMoneda = listadoContratoLogic.CodigoMoneda;

            listadoContratoResponse.MontoContrato = listadoContratoLogic.MontoContrato;
            listadoContratoResponse.MontoContratoString = listadoContratoLogic.MontoContrato.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            listadoContratoResponse.MontoAcumulado = listadoContratoLogic.MontoAcumulado;
            listadoContratoResponse.MontoAcumuladoString = listadoContratoLogic.MontoAcumulado.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);

            listadoContratoResponse.CodigoEstadoEdicion = listadoContratoLogic.CodigoEstadoEdicion;
            listadoContratoResponse.DescripcionEstadoEdicion = descripcionEstadoEdicion;
            listadoContratoResponse.CodigoPlantilla = listadoContratoLogic.CodigoPlantilla;
            listadoContratoResponse.CodigoContratoPrincipal = listadoContratoLogic.CodigoContratoPrincipal;
            listadoContratoResponse.CodigoTrabajadorResponsable = listadoContratoLogic.CodigoTrabajadorResponsable;

            var trabajadorResponsable = listadoContratoLogic.CodigoTrabajadorResponsable.HasValue ? listaTrabajador.Where(item => item.CodigoTrabajador == listadoContratoLogic.CodigoTrabajadorResponsable.Value).FirstOrDefault() : null;

            listadoContratoResponse.NombreTrajadorResponsable = trabajadorResponsable != null ? trabajadorResponsable.NombreCompleto : null;
            listadoContratoResponse.CantidadAdenda = listadoContratoLogic.CantidadAdenda;
            listadoContratoResponse.NumeroAdendaConcatenado = listadoContratoLogic.NumeroAdendaConcatenado;
            listadoContratoResponse.IndicadorAdhesion = listadoContratoLogic.IndicadorAdhesion;
            listadoContratoResponse.ComentarioModificacion = listadoContratoLogic.ComentarioModificacion;
            listadoContratoResponse.FechaCreacionString = listadoContratoLogic.FechaCreacion.ToString(DatosConstantes.Formato.FormatoFecha);
            listadoContratoResponse.UsuarioCreacion = listadoContratoLogic.UsuarioCreacion;
            listadoContratoResponse.EsFlexible = listadoContratoLogic.EsFlexible;

            if (listadoContratoLogic.FechaCreacionEstadioActual.HasValue)
            {
                TimeSpan ts = DateTime.Now.Date - listadoContratoLogic.FechaCreacionEstadioActual.Value.Date;
                if (ts.Days < 0)
                {
                    listadoContratoResponse.DiasEnBandeja = 0;
                }
                else
                {
                    listadoContratoResponse.DiasEnBandeja = ts.Days;
                }
            }

            listadoContratoResponse.FilasTotal = listadoContratoLogic.TotalRegistro;
            listadoContratoResponse.NumeroFila = listadoContratoLogic.NumeroRegistro;
          listadoContratoResponse.NombreEstadioActual = listadoContratoLogic.NombreEstadioActual;

            return listadoContratoResponse;
        }


        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="listadoContratoLogic">Entidad Lógica Listado Contrato</param>     
        /// <returns>Clase Listado Contrato Response con los datos de búsqueda</returns>
        public static ListadoContratoResponse ObtenerBusquedaContrato(ListadoContratoLogic listadoContratoLogic)
        {
            string descripcionTipoServicio = null;
            string descripcionTipoRequerimiento = null;
            string descripcionTipoDocumento = null;
            string descripcionEstadoContrato = null;
            string descripcionEstadoEdicion = null;


            var listadoContratoResponse = new ListadoContratoResponse();

            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = ",";

            listadoContratoResponse.CodigoContrato = listadoContratoLogic.CodigoContrato;
            listadoContratoResponse.CodigoUnidadOperativa = listadoContratoLogic.CodigoUnidadOperativa;
            listadoContratoResponse.CodigoProveedor = listadoContratoLogic.CodigoProveedor;
            listadoContratoResponse.NumeroDocumentoProveedor = listadoContratoLogic.NumeroDocumentoProveedor;
            listadoContratoResponse.NombreProveedor = listadoContratoLogic.NombreProveedor;
            listadoContratoResponse.NumeroContrato = listadoContratoLogic.NumeroContrato;
            listadoContratoResponse.Descripcion = listadoContratoLogic.Descripcion;
            listadoContratoResponse.CodigoTipoServicio = listadoContratoLogic.CodigoTipoServicio;
            listadoContratoResponse.DescripcionTipoServicio = descripcionTipoServicio;
            listadoContratoResponse.CodigoTipoRequerimiento = listadoContratoLogic.CodigoTipoRequerimiento;
            listadoContratoResponse.DescripcionTipoRequerimiento = descripcionTipoRequerimiento;
            listadoContratoResponse.CodigoTipoDocumento = listadoContratoLogic.CodigoTipoDocumento;
            listadoContratoResponse.DescripcionTipoDocumento = descripcionTipoDocumento;
            listadoContratoResponse.CodigoEstadoContrato = listadoContratoLogic.CodigoEstadoContrato;
            listadoContratoResponse.DescripcionEstadoContrato = descripcionEstadoContrato;
            listadoContratoResponse.FechaInicioVigencia = listadoContratoLogic.FechaInicioVigencia;
            listadoContratoResponse.FechaInicioVigenciaString = listadoContratoLogic.FechaInicioVigencia.ToString(DatosConstantes.Formato.FormatoFecha);
            listadoContratoResponse.FechaFinVigencia = listadoContratoLogic.FechaFinVigencia;
            listadoContratoResponse.FechaFinVigenciaString = listadoContratoLogic.FechaFinVigencia.ToString(DatosConstantes.Formato.FormatoFecha);

            if (listadoContratoResponse.FechaInicioVigencia > listadoContratoResponse.FechaFinVigencia)
            {
                listadoContratoResponse.DiasVencimiento = 0;
            }
            else
            {
                listadoContratoResponse.DiasVencimiento = (listadoContratoResponse.FechaFinVigencia - DateTime.Today).Days;
            }

            listadoContratoResponse.CodigoMoneda = listadoContratoLogic.CodigoMoneda;
            listadoContratoResponse.MontoContrato = listadoContratoLogic.MontoContrato;
            listadoContratoResponse.MontoContratoString = listadoContratoLogic.MontoContrato.ToString(DatosConstantes.Formato.FormatoNumeroDecimal);
            listadoContratoResponse.CodigoEstadoEdicion = listadoContratoLogic.CodigoEstadoEdicion;
            listadoContratoResponse.DescripcionEstadoEdicion = descripcionEstadoEdicion;
            listadoContratoResponse.CodigoPlantilla = listadoContratoLogic.CodigoPlantilla;
            listadoContratoResponse.CodigoContratoPrincipal = listadoContratoLogic.CodigoContratoPrincipal;
            listadoContratoResponse.CodigoTrabajadorResponsable = listadoContratoLogic.CodigoTrabajadorResponsable;

            listadoContratoResponse.CantidadAdenda = listadoContratoLogic.CantidadAdenda;
            listadoContratoResponse.NumeroAdendaConcatenado = listadoContratoLogic.NumeroAdendaConcatenado;
            listadoContratoResponse.IndicadorAdhesion = listadoContratoLogic.IndicadorAdhesion;
            listadoContratoResponse.ComentarioModificacion = listadoContratoLogic.ComentarioModificacion;
            listadoContratoResponse.FechaCreacionString = listadoContratoLogic.FechaCreacion.ToString(DatosConstantes.Formato.FormatoFecha);
            listadoContratoResponse.UsuarioCreacion = listadoContratoLogic.UsuarioCreacion;
            listadoContratoResponse.EsFlexible = listadoContratoLogic.EsFlexible;
            listadoContratoResponse.NombreEstadioActual = listadoContratoLogic.NombreEstadioActual;

            return listadoContratoResponse;
        }


        /// <summary>
        /// Realiza la adaptación de campos para registrar o actualizar
        /// </summary>
        /// <param name="data">Datos a registrar o actualizar</param>
        /// <returns>Entidad Contrato con los datos a registrar</returns>
        public static ContratoEntity RegistrarContrato(ContratoRequest data)
        {
            var contratoEntity = new ContratoEntity();
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalSeparator = ".";
            numberFormatInfo.NumberGroupSeparator = ",";

            if (data.CodigoContrato != null)
            {
                contratoEntity.CodigoContrato = new Guid(data.CodigoContrato.ToString());
            }
            else
            {
                Guid code;
                code = Guid.NewGuid();
                contratoEntity.CodigoContrato = code;
            }

            contratoEntity.CodigoUnidadOperativa = new Guid(data.CodigoUnidadOperativa.ToString());
            contratoEntity.CodigoProveedor = data.CodigoProveedor;
            contratoEntity.NumeroContrato = data.NumeroContrato;
            contratoEntity.Descripcion = data.Descripcion;
            contratoEntity.CodigoTipoServicio = data.CodigoTipoServicio;
            contratoEntity.CodigoTipoRequerimiento = data.CodigoTipoRequerimiento;
            contratoEntity.CodigoTipoDocumento = data.CodigoTipoDocumento;
            contratoEntity.FechaInicioVigencia = DateTime.ParseExact(data.FechaInicioVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
            contratoEntity.FechaFinVigencia = DateTime.ParseExact(data.FechaFinVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
            contratoEntity.CodigoMoneda = data.CodigoMoneda;
            contratoEntity.MontoContrato = Decimal.Parse(data.MontoContratoString, numberFormatInfo);
            contratoEntity.MontoAcumulado = (data.MontoAcumuladoString != null) ? Decimal.Parse(data.MontoAcumuladoString, numberFormatInfo) : 0;
            contratoEntity.CodigoEstado = data.CodigoEstado;
            contratoEntity.CodigoPlantilla = data.CodigoPlantilla;
            contratoEntity.CodigoFlujoAprobacion = new Guid(data.CodigoFlujoAprobacion);
            contratoEntity.CodigoEstadoEdicion = data.CodigoEstadoEdicion;
            contratoEntity.ComentarioModificacion = data.ComentarioModificacion;
            contratoEntity.CodigoContratoPrincipal = data.CodigoContratoPrincipal;
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
        /// <returns>Entidad Contrato con los datos a registrar</returns>
        public static ContratoEntity RegistrarCopiaContrato(ContratoRequest data)
        {
            try
            {
                var contratoEntity = new ContratoEntity();

                NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
                numberFormatInfo.NumberDecimalSeparator = ".";
                numberFormatInfo.NumberGroupSeparator = ",";

                contratoEntity.CodigoContrato = Guid.NewGuid();
                contratoEntity.CodigoUnidadOperativa = new Guid(data.CodigoUnidadOperativa.ToString());
                contratoEntity.CodigoProveedor = data.CodigoProveedor;
                contratoEntity.NumeroContrato = data.NumeroContrato;
                contratoEntity.Descripcion = data.Descripcion;
                contratoEntity.CodigoTipoServicio = data.CodigoTipoServicio;
                contratoEntity.CodigoTipoRequerimiento = data.CodigoTipoRequerimiento;
                contratoEntity.CodigoTipoDocumento = data.CodigoTipoDocumento;
                contratoEntity.FechaInicioVigencia = DateTime.ParseExact(data.FechaInicioVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
                contratoEntity.FechaFinVigencia = DateTime.ParseExact(data.FechaFinVigenciaString, DatosConstantes.Formato.FormatoFecha, System.Globalization.CultureInfo.InvariantCulture);
                contratoEntity.CodigoMoneda = data.CodigoMoneda;
                contratoEntity.MontoContrato = Decimal.Parse(data.MontoContratoString, numberFormatInfo);
                contratoEntity.MontoAcumulado = (data.MontoAcumuladoString != null) ? Decimal.Parse(data.MontoAcumuladoString, numberFormatInfo) : 0;
                contratoEntity.CodigoEstado = data.CodigoEstado;
                contratoEntity.CodigoPlantilla = data.CodigoPlantilla;
                contratoEntity.CodigoFlujoAprobacion = new Guid(data.CodigoFlujoAprobacion);
                contratoEntity.CodigoEstadoEdicion = data.CodigoEstadoEdicion;
                contratoEntity.ComentarioModificacion = data.ComentarioModificacion;
                contratoEntity.CodigoContratoPrincipal = data.CodigoContratoPrincipal;
                contratoEntity.FechaCreacion = DateTime.Now;
                contratoEntity.NumeroAdenda = data.NumeroAdenda;
                contratoEntity.NumeroAdendaConcatenado = data.NumeroAdendaConcatenado;
                contratoEntity.EsFlexible = data.EsFlexible;
                contratoEntity.EsCorporativo = data.EsCorporativo;
                contratoEntity.CodigoContratoOriginal = new Guid(data.CodigoContrato);

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
        /// <returns>Objeto ContratoParafoResponse</returns>
        public static ContratoParrafoVariableResponse ObtenerContratoParrafoVariable(ContratoParrafoVariableLogic data)
        {
            var contratoParrafoVariableResponse = new ContratoParrafoVariableResponse();
            contratoParrafoVariableResponse.CodigoContratoParrafoVariable = data.CodigoContratoParrafoVariable;
            contratoParrafoVariableResponse.CodigoContratoParrafo = data.CodigoContratoParrafo;
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
        /// <returns>Objeto ContratoParrafoVariableResponse</returns>
        public static ContratoBienResponse ObtenerContratoBienResponse(ContratoBienLogic data)
        {
            var contratoBienResponse = new ContratoBienResponse();
            contratoBienResponse.CodigoContratoBien = data.CodigoContratoBien;
            contratoBienResponse.CodigoContrato = data.CodigoContrato;
            contratoBienResponse.CodigoBien = data.CodigoBien;
            contratoBienResponse.EstadoRegistro = data.EstadoRegistro;

            return contratoBienResponse;
        }

        /// <summary>
        /// Realiza la adaptación de campos para la búsqueda
        /// </summary>
        /// <param name="data">Datos a adaptar</param>
        /// <returns>Objeto ContratoParrafoFirmanteResponse</returns>
        public static ContratoFirmanteResponse ObtenerContratoFirmanteResponse(ContratoFirmanteLogic data)
        {
            var contratoFirmanteResponse = new ContratoFirmanteResponse();
            contratoFirmanteResponse.CodigoContratoFirmante = data.CodigoContratoFirmante.ToString();
            contratoFirmanteResponse.CodigoContratoParrafoVariable = data.CodigoContratoParrafoVariable.ToString();
            contratoFirmanteResponse.NombreFirmante = data.NombreFirmante;
            contratoFirmanteResponse.DatoAdicional = data.DatoAdicional;

            return contratoFirmanteResponse;
        }

    }
}
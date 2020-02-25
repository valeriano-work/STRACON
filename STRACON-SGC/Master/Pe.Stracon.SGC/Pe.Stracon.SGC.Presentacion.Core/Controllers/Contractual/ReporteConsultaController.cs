using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteConsulta;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Reporte de Consulta
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20160713    </br>
    /// Modificación:                   </br>
    /// </remarks>
    public class ReporteConsultaController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de Políticas
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Servicio de manejo de Unidad Operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }
        /// <summary>
        /// Servicio de manejo de Trabajador
        /// </summary>
        public ITrabajadorService trabajadorService { get; set; }
        /// <summary>
        /// Interfaz para el manejo de Auditoría
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }
        #endregion

        #region Vistas
        /// <summary>
        /// Muestra la vista Index
        /// </summary>
        /// <returns>Vista Index</returns>
        public ActionResult Index(ReporteConsultaRequest filtro)
        {
            if (filtro != null)
            {
                TempData["DataReport"] = CrearModelo(filtro);
            }

            ReporteConsultaResponse reporteConsulta = new ReporteConsultaResponse();
            reporteConsulta.CodigoRemitente = filtro.CodigoRemitente;
            reporteConsulta.NombreRemitente = filtro.NombreRemitente;
            reporteConsulta.CodigoDestinatario = filtro.CodigoDestinatario;
            reporteConsulta.NombreDestinatario = filtro.NombreDestinatario;
            reporteConsulta.CodigoUnidadOperativa = filtro.CodigoUnidadOperativa;
            reporteConsulta.CodigoTipoConsulta = filtro.CodigoTipoConsulta;
            reporteConsulta.DescripcionTipoConsulta = filtro.DescripcionTipoConsulta;
            reporteConsulta.CodigoUnidadOperativa = filtro.CodigoUnidadOperativa;
            reporteConsulta.NombreUnidadOperativa = filtro.NombreUnidadOperativa;
            reporteConsulta.CodigoAreaEmpresa = filtro.CodigoAreaEmpresa;
            reporteConsulta.DescripcionAreaEmpresa = filtro.DescripcionAreaEmpresa;
            reporteConsulta.CodigoEstadoConsulta = filtro.CodigoEstadoConsulta;
            reporteConsulta.DescripcionEstadoConsulta = filtro.DescripcionEstadoConsulta;

            TrabajadorResponse resultadoTrabajador = trabajadorService.BuscarTrabajador(new TrabajadorRequest() {
                CodigoIdentificacion = entornoActualAplicacion.UsuarioSession
            }).Result.FirstOrDefault();

            List<UnidadOperativaResponse> unidadOperativa = new List<UnidadOperativaResponse>();

            if(!string.IsNullOrEmpty(resultadoTrabajador.CodigoUnidadOperativaMatriz))
            {
                unidadOperativa = unidadOperativaService.BuscarUnidadOperativaProyectoPorEmpresaMatriz(new FiltroUnidadOperativa() { CodigoUnidadOperativa =  resultadoTrabajador.CodigoUnidadOperativaMatriz}).Result;
            }

            var listaTipoConsulta = politicaService.ListarTipoConsulta();
            var listaAreaEmpresa = politicaService.ListarArea();
            var listaEstadoConsulta = politicaService.ListarEstadoConsulta();

            var modelo = new ReporteConsultaBusqueda(reporteConsulta, unidadOperativa, listaTipoConsulta.Result, listaAreaEmpresa.Result, listaEstadoConsulta.Result);

            return View(modelo);
        }

        /// <summary>
        /// Asigna los parámetros necesarios para el reporte
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda para el reporte</param>
        /// <returns>Modelo con parámetros para el reporte</returns>
        private ReporteViewModel CrearModelo(ReporteConsultaRequest filtro)
        {
            var reporteModel = new ReporteViewModel();
            reporteModel.RutaReporte += DatosConstantes.ReporteNombreArchivo.ReporteConsulta;

            reporteModel.AgregarParametro("CODIGO_LENGUAJE", DatosConstantes.Iternacionalizacion.ES_PE);
            reporteModel.AgregarParametro("USUARIO", entornoActualAplicacion.UsuarioSession);
            reporteModel.AgregarParametro("NOMBRE_REPORTE", ReporteConsultaResource.EtiquetaTitulo.ToUpper());
            reporteModel.AgregarParametro("FORMATO_FECHA_CORTA", DatosConstantes.Formato.FormatoFecha);
            reporteModel.AgregarParametro("FORMATO_HORA_CORTA", DatosConstantes.Formato.FormatoHora);
            reporteModel.AgregarParametro("FORMATO_NUMERO_ENTERO", DatosConstantes.Formato.FormatoNumeroEntero);
            reporteModel.AgregarParametro("FORMATO_NUMERO_DECIMAL", DatosConstantes.Formato.FormatoNumeroDecimal);
            reporteModel.AgregarParametro("PIE_REPORTE", string.Format(GenericoResource.EtiquetaFinReporte, ReporteConsultaResource.EtiquetaTitulo.ToUpper()));
            reporteModel.AgregarParametro("CODIGO_REMITENTE", filtro.CodigoRemitente);
            reporteModel.AgregarParametro("NOMBRE_REMITENTE", filtro.NombreRemitente);
            reporteModel.AgregarParametro("CODIGO_DESTINATARIO", filtro.CodigoDestinatario);
            reporteModel.AgregarParametro("NOMBRE_DESTINATARIO", filtro.NombreDestinatario);
            reporteModel.AgregarParametro("CODIGO_TIPO_CONSULTA", filtro.CodigoTipoConsulta);
            reporteModel.AgregarParametro("DESCRIPCION_TIPO_CONSULTA", filtro.DescripcionTipoConsulta);
            reporteModel.AgregarParametro("CODIGO_UNIDAD_OPERATIVA", filtro.CodigoUnidadOperativa);
            reporteModel.AgregarParametro("CODIGO_AREA_EMPRESA", filtro.CodigoAreaEmpresa);
            reporteModel.AgregarParametro("DESCRIPCION_AREA_EMPRESA", filtro.DescripcionAreaEmpresa);
            reporteModel.AgregarParametro("CODIGO_ESTADO_CONSULTA", filtro.CodigoEstadoConsulta);
            reporteModel.AgregarParametro("DESCRIPCION_ESTADO_CONSULTA", filtro.DescripcionEstadoConsulta);

            return reporteModel;
        }
        #endregion

        #region Json
        /// <summary>
        /// Permite la búsqueda de Trabajadores
        /// </summary>
        /// <param name="nombreTrabajador">Nombre de Trabajador</param>
        /// <returns>Lista con el resultado de la operación</returns>
        public JsonResult BuscarTrabajador(string nombreTrabajador)
        {
            TrabajadorRequest filtro = new TrabajadorRequest();
            filtro.NombreCompleto = nombreTrabajador;
            Pe.Stracon.Politicas.Aplicacion.Core.Base.ProcessResult<List<TrabajadorDatoMinimoResponse>> resultado = trabajadorService.BuscarTrabajadorDatoMinimo(filtro);
            return Json(resultado.Result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}

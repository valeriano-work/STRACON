using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteBienesContrato;
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
    /// Controladora de Reporte de Bienes
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150803    </br>
    /// Modificación:                   </br>
    /// </remarks>
    public class ReporteBienesContratoController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary>
        public IPoliticaService politicaService { get; set; }
        /// <summary>
        /// Servicio de manejo de Unidad Operativa
        /// </summary>
        public IUnidadOperativaService unidadOperativaService { get; set; }
        /// <summary>
        /// Interfaz para el manejo de auditoría
        /// </summary>
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }
        #endregion

        #region Vistas
        /// <summary>
        /// Muestra la vista Index
        /// </summary>
        /// <returns>Vista Index</returns>
        public ActionResult Index(ReporteBienesContratoRequest filtro)
        {
            if (filtro != null)
            {
                TempData["DataReport"] = CrearModelo(filtro);
            }

            var reporteBienesContrato = new ReporteBienesContratoResponse();
            reporteBienesContrato.CodigoUnidadOperativa = filtro.CodigoUnidadOperativa;
            reporteBienesContrato.CodigoTipoBien = filtro.CodigoTipoBien;
            reporteBienesContrato.RucProveedor = filtro.RucProveedor;
            reporteBienesContrato.NombreProveedor = filtro.NombreProveedor;
            reporteBienesContrato.NumeroContrato = filtro.NumeroContrato;
            reporteBienesContrato.NumeroSerie = filtro.NumeroSerie;
            reporteBienesContrato.Ano = filtro.Ano;

            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto });
            var tipoBien = politicaService.ListaTipoBien();

            var modelo = new ReporteBienesContratoBusqueda(unidadOperativa.Result, tipoBien.Result, reporteBienesContrato);

            return View(modelo);
        }
        #endregion

        /// <summary>
        /// Asigna los parámetros necesarios para el reporte
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda para el reporte</param>
        /// <returns>Modelo con parámetros para el reporte</returns>
        private ReporteViewModel CrearModelo(ReporteBienesContratoRequest filtro)
        {
            var reporteModel = new ReporteViewModel();
            reporteModel.RutaReporte += DatosConstantes.ReporteNombreArchivo.ReporteBienesContrato;

            reporteModel.AgregarParametro("CODIGO_LENGUAJE", DatosConstantes.Iternacionalizacion.ES_PE);
            reporteModel.AgregarParametro("USUARIO", entornoActualAplicacion.UsuarioSession);
            reporteModel.AgregarParametro("NOMBRE_REPORTE", ReporteBienesContratoResource.EtiquetaTitulo.ToUpper());
            reporteModel.AgregarParametro("FORMATO_FECHA_CORTA", DatosConstantes.Formato.FormatoFecha);
            reporteModel.AgregarParametro("FORMATO_HORA_CORTA", DatosConstantes.Formato.FormatoHora);
            reporteModel.AgregarParametro("FORMATO_NUMERO_ENTERO", DatosConstantes.Formato.FormatoNumeroEntero);
            reporteModel.AgregarParametro("FORMATO_NUMERO_DECIMAL", DatosConstantes.Formato.FormatoNumeroDecimal);
            reporteModel.AgregarParametro("PIE_REPORTE", string.Format(GenericoResource.EtiquetaFinReporte, ReporteBienesContratoResource.EtiquetaTitulo.ToUpper()));
            reporteModel.AgregarParametro("CODIGO_UNIDAD_OPERATIVA", filtro.CodigoUnidadOperativa);
            reporteModel.AgregarParametro("NOMBRE_UNIDAD_OPERATIVA", filtro.NombreUnidadOperativa);
            reporteModel.AgregarParametro("CODIGO_TIPO_BIEN", filtro.CodigoTipoBien);
            reporteModel.AgregarParametro("DESCRIPCION_TIPO_BIEN", filtro.DescripcionTipoBien);
            reporteModel.AgregarParametro("RUC_PROVEEDOR", filtro.RucProveedor);
            reporteModel.AgregarParametro("NOMBRE_PROVEEDOR", filtro.NombreProveedor);
            reporteModel.AgregarParametro("NUMERO_CONTRATO", filtro.NumeroContrato);
            reporteModel.AgregarParametro("NUMERO_SERIE", filtro.NumeroSerie);
            reporteModel.AgregarParametro("ANO", filtro.Ano);

            return reporteModel;
        }
    }
}

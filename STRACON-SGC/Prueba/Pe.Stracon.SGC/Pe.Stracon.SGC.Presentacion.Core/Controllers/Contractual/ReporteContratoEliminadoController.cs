using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Cross.Core.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteContratoEliminado;
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
    /// Controladora de Reporte de Contratos Eliminados
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20170627    </br>
    /// Modificación:                   </br>
    /// </remarks>
    public class ReporteContratoEliminadoController : GenericController
    {
        #region Parámetros
        /// <summary>
        /// Servicio de manejo de parametro valor
        /// </summary> 
        public IPoliticaService politicaService { get; set; }

        /// <summary>
        /// Servicio de manejo de unidad operativa
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
        public ActionResult Index(ReporteContratoEliminadoRequest filtro)
        {
            if (filtro != null)
            {
                if(filtro.Descripcion != null)
                    filtro.Descripcion = filtro.Descripcion.Trim();

                if (filtro.NumeroContrato != null)
                    filtro.NumeroContrato = filtro.NumeroContrato.Trim();

                TempData["DataReport"] = CrearModelo(filtro);
            }

            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto });
            var reporteListadoContrato = new ReporteListadoContratoResponse();
            reporteListadoContrato.CodigoUnidadOperativa = filtro.CodigoUnidadOperativa;
            reporteListadoContrato.NumeroContrato = filtro.NumeroContrato;
            reporteListadoContrato.Descripcion = filtro.Descripcion;
            reporteListadoContrato.TipoServicio = filtro.CodigoTipoServicio;
            reporteListadoContrato.TipoRequerimiento = filtro.CodigoTipoRequerimiento;
            reporteListadoContrato.TipoDocumento = filtro.CodigoTipoDocumento;
            reporteListadoContrato.EstadoContrato = filtro.CodigoEstadoContrato;          
            reporteListadoContrato.FechaConsultaDesdeString = filtro.FechaConsultaDesdeString;
            reporteListadoContrato.FechaConsultaHastaString = filtro.FechaConsultaHastaString;
            
            var tipoServicio = politicaService.ListarTipoContrato().Result.OrderBy(x => x.Valor).ToList();
            var tipoRequerimiento = politicaService.ListarTipoServicio().Result.OrderBy(x => x.Valor).ToList();
            var tipoDocumento = politicaService.ListarTipoDocumentoContrato().Result.OrderBy(x => x.Valor).ToList();
            var estadoContrato = politicaService.ListarEstadoContrato().Result.OrderBy(x => x.Valor).ToList();

            var modelo = new ReporteContratoEliminadoBusqueda(unidadOperativa.Result, tipoServicio, tipoRequerimiento, tipoDocumento, estadoContrato, reporteListadoContrato);

            return View(modelo);
        }       

        #endregion

        /// <summary>
        /// Asigna los parámetros necesarios para el reporte
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda para el reporte</param>
        /// <returns>Modelo con parámetros para el reporte</returns>
        private ReporteViewModel CrearModelo(ReporteContratoEliminadoRequest filtro)
        {
            var reporteModel = new ReporteViewModel();
            reporteModel.RutaReporte += DatosConstantes.ReporteNombreArchivo.ReporteContratosEliminados;         
            reporteModel.AgregarParametro("USUARIO", entornoActualAplicacion.UsuarioSession);
            reporteModel.AgregarParametro("NOMBRE_REPORTE", ReporteContratoEliminadoResource.EtiquetaTitulo.ToUpper());          
            reporteModel.AgregarParametro("DESCRIPCION", filtro.Descripcion);
            reporteModel.AgregarParametro("CODIGO_UNIDAD_OPERATIVA", filtro.CodigoUnidadOperativa);
            reporteModel.AgregarParametro("NOMBRE_UNIDAD_OPERATIVA", filtro.NombreUnidadOperativa);
            reporteModel.AgregarParametro("CODIGO_TIPO_SERVICIO", filtro.CodigoTipoServicio);
            reporteModel.AgregarParametro("NOMBRE_TIPO_SERVICIO", filtro.NombreTipoServicio);
            reporteModel.AgregarParametro("CODIGO_TIPO_REQUERIMIENTO", filtro.CodigoTipoRequerimiento);
            reporteModel.AgregarParametro("NOMBRE_TIPO_REQUERIMIENTO", filtro.NombreTipoRequerimiento);
            reporteModel.AgregarParametro("CODIGO_TIPO_DOCUMENTO", filtro.CodigoTipoDocumento);
            reporteModel.AgregarParametro("NOMBRE_TIPO_DOCUMENTO", filtro.NombreTipoDocumento);
            reporteModel.AgregarParametro("CODIGO_ESTADO", filtro.CodigoEstadoContrato);
            reporteModel.AgregarParametro("NOMBRE_ESTADO", filtro.NombreEstadoContrato);
            reporteModel.AgregarParametro("NUMERO_CONTRATO", filtro.NumeroContrato);         
            reporteModel.AgregarParametro("FECHA_INICIO_VIGENCIA", filtro.FechaConsultaDesdeString);
            reporteModel.AgregarParametro("FECHA_FIN_VIGENCIA", filtro.FechaConsultaHastaString);          

            return reporteModel;
        }

    }
}

using Pe.Stracon.Politicas.Aplicacion.Core.ServiceContract;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Aplicacion.Core.Base;
using Pe.Stracon.SGC.Aplicacion.Core.ServiceContract;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.Controllers.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ReporteContratoCorporativo;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ArchivoAdjuntoContrato;
using Pe.Stracon.SGC.Presentacion.Recursos.Base;
using Pe.Stracon.SGC.Presentacion.Recursos.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.IO;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Base;

namespace Pe.Stracon.SGC.Presentacion.Core.Controllers.Contractual
{
    /// <summary>
    /// Controladora de Reporte de Contratos corporativos
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20170623    </br>
    /// Modificación:                   </br>
    /// </remarks>
    public class ReporteContratoCorporativoController : GenericController
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
        /// Servicio de contrato corporativo
        /// </summary>
        public IContratoCorporativoService contratoCorporativoService { get; set; }

        /// <summary>
        /// Servicio de manejo de contrato
        /// </summary>
        public IContratoService contratoService { get; set; }
        /// <summary>
        /// servicio de manejo de Contrato
        /// </summary>
        public IProveedorService proveedorService { get; set; }

        #endregion

        #region Vistas
        /// <summary>
        /// Muestra la vista Index
        /// </summary> 
        /// <returns>Vista Index</returns>
        public ActionResult Index()
        {     
            var unidadOperativa = unidadOperativaService.BuscarUnidadOperativa(new FiltroUnidadOperativa() { Nivel = DatosConstantes.Nivel.Proyecto });
            var reporteListadoContrato = new ReporteListadoContratoResponse();
           
            var tipoServicio = politicaService.ListarTipoContrato().Result.OrderBy(x => x.Valor).ToList();
            var tipoRequerimiento = politicaService.ListarTipoServicio().Result.OrderBy(x => x.Valor).ToList();
            var tipoDocumento = politicaService.ListarTipoDocumentoContrato().Result.OrderBy(x => x.Valor).ToList();
            var estadoContrato = politicaService.ListarEstadoContrato().Result.OrderBy(x => x.Valor).ToList();

            var modelo = new ReporteContratoCorporativoBusqueda(unidadOperativa.Result, tipoServicio, tipoRequerimiento, tipoDocumento, estadoContrato, reporteListadoContrato);          

            return View(modelo);
        }

        /// <summary>
        /// Muestra la vista de carga de documentos adjuntos
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Vista de Formulario de carga de adjuntos</returns>
        public ActionResult FormularioContratoAdjuntos(ListadoContratoRequest request)
        {
            ArchivoAdjuntoContratoFormulario modelo = new ArchivoAdjuntoContratoFormulario();
            modelo.Contrato = contratoService.BuscarListadoContrato(request).Result.FirstOrDefault();         
            return PartialView(modelo);
        }

        #endregion

        #region Json

        /// <summary>
        /// Busca Contratos corporativos
        /// </summary>
        /// <param name="filtro">Filtro de Búsqueda</param>
        /// <returns>Lista de Contratos</returns>
        public JsonResult BuscarContratosCorporativos(ContratoCorporativoRequest filtro)
        {
            var resultado = contratoCorporativoService.BuscarContratoCorporativo(filtro);       
            return Json(resultado);
        }
      
        /// <summary>
        /// Permite buscar archivos adjuntos al contrato
        /// </summary>
        /// <returns>Vista de Formulario de carga</returns>
        public JsonResult BuscarArchivoAdjunto(ContratoDocumentoAdjuntoRequest request)
        {
            var resultado = contratoService.BuscarContratoDocumentoAdjunto(request);
            return Json(resultado);
        }
        /// <summary>
        /// Muestra el contenido del Contrato, dependiendo de su versión.
        /// </summary>
        /// <param name="request">Datos del Contrato</param>
        /// <returns>Contenido del Contrato</returns>
        public ActionResult DescargarArchivoAdjunto(ContratoDocumentoAdjuntoRequest request)
        {
            //string NombreFile = string.Empty;
            var FileContrato = contratoService.ObtenerArchivoAdjunto(request);
            MemoryStream memorySt = null;
            if (FileContrato.Result != null)
            {
                memorySt = new MemoryStream((byte[])FileContrato.Result.ContenidoArchivo);
            }

            if (memorySt != null)
            {
                byte[] byteArchivo = memorySt.ToArray();
                Response.Clear();
                Response.AddHeader("Content-Disposition", string.Format("attachement; filename={0}", FileContrato.Result.NombreArchivo));
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(byteArchivo);
                Response.End();
            }
            else
            {
                return null;
            }
            return RedirectToAction("Reporte");
        }

        /// <summary>
        /// Método para buscar los proveedores que tienen contrato y que se guardan en la tabla [CTR].[PROVEEDOR]
        /// </summary>
        /// <param name="rucNombreProveedor">Filtro de búsqueda</param>
        /// <returns>Lista de proveedores</returns>
        public JsonResult BuscarProveedor(string rucNombreProveedor)//ProveedorRequest filtro)
        {
            ProveedorRequest filtro = new ProveedorRequest();

            filtro.NombreComercial   = rucNombreProveedor;

            var resultado = proveedorService.BuscarProveedorNombreRuc(filtro);
            return Json(resultado.Result, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}

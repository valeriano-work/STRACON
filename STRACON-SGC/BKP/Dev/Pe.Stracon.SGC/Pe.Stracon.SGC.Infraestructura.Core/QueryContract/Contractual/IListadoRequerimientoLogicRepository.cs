using System;
using System.Collections.Generic;
using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Repository.Query.Contractual;
using Pe.Stracon.SGC.Infraestructura.QueryModel;

namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    /// <summary>
    /// Definición del Repositorio Listado Requerimiento Logic
    /// </summary>
    public interface IListadoRequerimientoLogicRepository : IQueryRepository<ListadoRequerimientoLogic>
    {
        /// <summary>
        /// Realiza la búsqueda de Requerimientos
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento</param>
        /// <param name="codigoUnidadOperativa">Código de unidad operativa</param>
        /// <param name="codigoPlantilla">Código de plantilla</param>
        /// <param name="codigoTipoServicio">Código de Tipo de Servicio</param>
        /// <param name="codigoTipoRequerimiento">Código de Tipo de Requerimiento</param>
        /// <param name="codigoTipoDocumento">Código de Tipo de Documento</param>
        /// <param name="codigoEstadoVigencia">Código de Estado de Vigencia</param>
        /// <param name="numeroRequerimiento">Número de Requerimiento</param>
        /// <param name="numeroAdendaConcatenado">Número de adenda concatenado</param>
        /// <param name="numeroDocumento">Número de Documento</param>
        /// <param name="nombreProveedor">Nombre de Proveedor</param>
        /// <param name="descripcion">Descripción de Requerimiento</param>
        /// <param name="indicadorTodaUnidadOperativa">Indicador toda unidad operativa</param>
        /// <param name="listaUnidadOperativaAcceso">Lista de unidades operativas en acceso</param>
        /// <param name="codigoEstadoEdicion">Estado de Edición</param>
        /// <param name="descripcionRequerimiento">Descripción del Requerimiento</param>
        /// <param name="codigoTrabajadorResponsable">Código de Trabajador Responsable</param>
        /// <param name="nombreEstadio">Nombre de Estadio</param>
        /// <param name="indicadorFinalizarAprobacion">Indicador de Finalizar Aprobación</param>
        /// <param name="numeroPagina">Total de Páginas</param>
        /// <param name="registroPagina">Total de Registros por Página</param>
        /// <returns>Lista de contratos</returns>
        List<ListadoRequerimientoLogic> BuscarListadoRequerimiento(
            Guid? codigoRequerimiento,
            Guid? codigoUnidadOperativa,
            Guid? codigoPlantilla,
            string codigoTipoServicio,
            string codigoTipoRequerimiento,
            string codigoTipoDocumento,
            string codigoEstadoVigencia,
            string numeroRequerimiento,
            string numeroAdendaConcatenado,
            string numeroDocumento,
            string nombreProveedor,
            string descripcion,
            bool? indicadorTodaUnidadOperativa,
            List<Guid?> listaUnidadOperativaAcceso,
            string codigoEstadoEdicion,
            string descripcionRequerimiento,
            Guid? codigoTrabajadorResponsable,
            string nombreEstadio,
            string indicadorFinalizarAprobacion,
            int numeroPagina,
            int registroPagina);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoRequerimiento"></param>
        /// <param name="codigoUnidadOperativa"></param>
        /// <param name="codigoPlantilla"></param>
        /// <param name="codigoTipoServicio"></param>
        /// <param name="codigoTipoRequerimiento"></param>
        /// <param name="codigoTipoDocumento"></param>
        /// <param name="codigoEstadoVigencia"></param>
        /// <param name="numeroRequerimiento"></param>
        /// <param name="numeroAdendaConcatenado"></param>
        /// <param name="numeroDocumento"></param>
        /// <param name="nombreProveedor"></param>
        /// <param name="descripcion"></param>
        /// <param name="indicadorTodaUnidadOperativa"></param>
        /// <param name="listaUnidadOperativaAcceso"></param>
        /// <param name="codigoEstadoEdicion"></param>
        /// <param name="descripcionRequerimiento"></param>
        /// <param name="codigoTrabajadorResponsable"></param>
        /// <param name="nombreEstadio"></param>
        /// <param name="indicadorFinalizarAprobacion"></param>
        /// <param name="montoAcumuladoInicio"></param>
        /// <param name="montoAcumuladoFin"></param>
        /// <param name="codigoMoneda"></param>
        /// <param name="usuarioCreacion"></param>
        /// <param name="columnaOrden"></param>
        /// <param name="tipoOrden"></param>
        /// <param name="numeroPagina"></param>
        /// <param name="registroPagina"></param>
        /// <returns></returns>
        List<ListadoRequerimientoLogic> BuscarListadoRequerimientoOrden(
          Guid? codigoRequerimiento,
          Guid? codigoUnidadOperativa,
          Guid? codigoPlantilla,
          //string codigoTipoServicio,
          //string codigoTipoRequerimiento,
          string codigoTipoDocumento,
          string codigoEstadoVigencia,
          string numeroRequerimiento,
          //string numeroAdendaConcatenado,
          //string numeroDocumento,
          //string nombreProveedor,
          string descripcion,
          bool? indicadorTodaUnidadOperativa,
          List<Guid?> listaUnidadOperativaAcceso,
          string codigoEstadoEdicion,
          string descripcionRequerimiento,
          Guid? codigoTrabajadorResponsable,
          string nombreEstadio,
          string indicadorFinalizarAprobacion,
          decimal? montoAcumuladoInicio,
          decimal? montoAcumuladoFin,
          string codigoMoneda,
          string usuarioCreacion,
          string columnaOrden,
          string tipoOrden,
          int numeroPagina,
          int registroPagina);

        /// <summary>
        /// Realiza la búsqueda de Requerimientos principales
        /// </summary>
        /// <param name="numeroRequerimiento">Número de Requerimiento</param>
        /// <param name="descripcion">Descripción de Requerimiento</param>
        /// <returns>Lista de Requerimientos</returns>
        List<ListadoRequerimientoLogic> ListadoRequerimientoPrincipal(string numeroRequerimiento, string descripcion, string TipoServicioLC);

        /// <summary>
        /// Obtiene el Monto Acumulado del Requerimiento Principal más sus Adendas
        /// </summary>
        /// <param name="codigoRequerimientoPrincipal">Código de Requerimiento Principal</param>
        /// <returns>Registro con el Monto Acumulado del Requerimiento Principal más sus Adendas</returns>
        List<ListadoRequerimientoLogic> ObtenerMontoAcumuladoRequerimiento(Guid codigoRequerimientoPrincipal);

        /// <summary>
        /// Obtiene las variables del parrafo
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Lista de variables de los parrafos de un Requerimiento</returns>
        List<RequerimientoParrafoVariableLogic> ObtenerVariablesRequerimientoParrafo(Guid codigoRequerimiento);

        /// <summary>
        /// Obtiene los bienes de un Requerimiento
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Lista de variables de los parrafos de un Requerimiento</returns>
        List<RequerimientoBienLogic> ObtenerBienesRequerimiento(Guid codigoRequerimiento);

        /// <summary>
        /// Obtiene los firmantes de un Requerimiento
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento</param>
        /// <returns>Lista de firmantes de los parrafos de un Requerimiento</returns>
        List<RequerimientoFirmanteLogic> ObtenerFirmantesRequerimiento(Guid codigoRequerimiento);

        /// <summary>
        /// Realiza la búsqueda de Requerimientos sin paginación
        /// </summary>
        /// <param name="codigoRequerimiento">Código de Requerimiento</param>
        /// <param name="codigoTipoServicio">Código de Tipo de Servicio</param>
        /// <param name="codigoTipoRequerimiento">Código de Tipo de Requerimiento</param>
        /// <param name="codigoTipoDocumento">Código de Tipo de Documento</param>
        /// <param name="codigoEstadoVigencia">Código de Estado de Vigencia</param>
        /// <param name="numeroRequerimiento">Número de Requerimiento</param>
        /// <param name="numeroDocumento">Número de Documento</param>
        /// <param name="nombreProveedor">Nombre de Proveedor</param>
        /// <param name="descripcion">Descripción de Requerimiento</param>
        /// <returns>Lista de contratos</returns>
        List<ListadoRequerimientoLogic> BuscarRequerimiento(
            Guid? codigoRequerimiento,
            Guid? codigoRequerimientoPrincipal,
            string codigoTipoServicio,
            string codigoTipoRequerimiento,
            string codigoTipoDocumento,
            string codigoEstadoVigencia,
            string numeroRequerimiento,
            string numeroDocumento,
            string nombreProveedor,
            string descripcion);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoUnidadOperativa"></param>
        /// <param name="codigoTipoRequerimiento"></param>
        /// <param name="codigoTipoDocumento"></param>
        /// <returns></returns>
        List<ListadoRequerimientoLogic> BuscarCorrelativoRequerimiento(Guid? codigoUnidadOperativa, string codigoTipoRequerimiento, string codigoTipoDocumento);

        List<string> Listar_Requerimiento_Segun_Unidad_Operativa(Guid? codigoUnidadOperativa);
        
         /// <summary>
         /// Eliminar un contrato
         /// </summary>
         /// <param name="codigoRequerimiento">Código de contrato</param>     
         /// <param name="motivoEliminacion">Motivo de eliminación</param>
         /// <param name="usuarioSesion">Nombre de usuario</param>
         /// <param name="terminal">Terminal de usuario</param>
         /// <returns>Indicador con el resultado de la operación</returns>
        int EliminarRequerimiento(Guid codigoRequerimiento, string motivoEliminacion, string usuarioSesion, string terminal);
    }

}

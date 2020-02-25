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
    /// Definición del Repositorio Listado Contrato Logic
    /// </summary>
    public interface IListadoContratoLogicRepository : IQueryRepository<ListadoContratoLogic>
    {
        /// <summary>
        /// Realiza la búsqueda de Contratos
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato</param>
        /// <param name="codigoUnidadOperativa">Código de unidad operativa</param>
        /// <param name="codigoPlantilla">Código de plantilla</param>
        /// <param name="codigoTipoServicio">Código de Tipo de Servicio</param>
        /// <param name="codigoTipoRequerimiento">Código de Tipo de Requerimiento</param>
        /// <param name="codigoTipoDocumento">Código de Tipo de Documento</param>
        /// <param name="codigoEstadoVigencia">Código de Estado de Vigencia</param>
        /// <param name="numeroContrato">Número de Contrato</param>
        /// <param name="numeroAdendaConcatenado">Número de adenda concatenado</param>
        /// <param name="numeroDocumento">Número de Documento</param>
        /// <param name="nombreProveedor">Nombre de Proveedor</param>
        /// <param name="descripcion">Descripción de Contrato</param>
        /// <param name="indicadorTodaUnidadOperativa">Indicador toda unidad operativa</param>
        /// <param name="listaUnidadOperativaAcceso">Lista de unidades operativas en acceso</param>
        /// <param name="codigoEstadoEdicion">Estado de Edición</param>
        /// <param name="descripcionContrato">Descripción del Contrato</param>
        /// <param name="codigoTrabajadorResponsable">Código de Trabajador Responsable</param>
        /// <param name="nombreEstadio">Nombre de Estadio</param>
        /// <param name="indicadorFinalizarAprobacion">Indicador de Finalizar Aprobación</param>
        /// <param name="numeroPagina">Total de Páginas</param>
        /// <param name="registroPagina">Total de Registros por Página</param>
        /// <returns>Lista de contratos</returns>
        List<ListadoContratoLogic> BuscarListadoContrato(
            Guid? codigoContrato,
            Guid? codigoUnidadOperativa,
            Guid? codigoPlantilla,
            string codigoTipoServicio,
            string codigoTipoRequerimiento,
            string codigoTipoDocumento,
            string codigoEstadoVigencia,
            string numeroContrato,
            string numeroAdendaConcatenado,
            string numeroDocumento,
            string nombreProveedor,
            string descripcion,
            bool? indicadorTodaUnidadOperativa,
            List<Guid?> listaUnidadOperativaAcceso,
            string codigoEstadoEdicion,
            string descripcionContrato,
            Guid? codigoTrabajadorResponsable,
            string nombreEstadio,
            string indicadorFinalizarAprobacion,
            int numeroPagina,
            int registroPagina);

           /// <summary>
           /// 
           /// </summary>
           /// <param name="codigoContrato"></param>
           /// <param name="codigoUnidadOperativa"></param>
           /// <param name="codigoPlantilla"></param>
           /// <param name="codigoTipoServicio"></param>
           /// <param name="codigoTipoRequerimiento"></param>
           /// <param name="codigoTipoDocumento"></param>
           /// <param name="codigoEstadoVigencia"></param>
           /// <param name="numeroContrato"></param>
           /// <param name="numeroAdendaConcatenado"></param>
           /// <param name="numeroDocumento"></param>
           /// <param name="nombreProveedor"></param>
           /// <param name="descripcion"></param>
           /// <param name="indicadorTodaUnidadOperativa"></param>
           /// <param name="listaUnidadOperativaAcceso"></param>
           /// <param name="codigoEstadoEdicion"></param>
           /// <param name="descripcionContrato"></param>
           /// <param name="codigoTrabajadorResponsable"></param>
           /// <param name="nombreEstadio"></param>
           /// <param name="indicadorFinalizarAprobacion"></param>
           /// <param name="MontoAcumuladoInicio"></param>
           /// <param name="MontoAcumuladoFin"></param>
           /// <param name="usuarioCreacion"></param>
           /// <param name="columnaOrden"></param>
           /// <param name="tipoOrden"></param>
           /// <param name="numeroPagina"></param>
           /// <param name="registroPagina"></param>
           /// <returns></returns>
        List<ListadoContratoLogic> BuscarListadoContratoOrden(
          Guid? codigoContrato,
          Guid? codigoUnidadOperativa,
          Guid? codigoPlantilla,
          string codigoTipoServicio,
          string codigoTipoRequerimiento,
          string codigoTipoDocumento,
          string codigoEstadoVigencia,
          string numeroContrato,
          string numeroAdendaConcatenado,
          string numeroDocumento,
          string nombreProveedor,
          string descripcion,
          bool? indicadorTodaUnidadOperativa,
          List<Guid?> listaUnidadOperativaAcceso,
          string codigoEstadoEdicion,
          string descripcionContrato,
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
        /// Realiza la búsqueda de Contratos principales
        /// </summary>
        /// <param name="numeroContrato">Número de Contrato</param>
        /// <param name="descripcion">Descripción de Contrato</param>
        /// <returns>Lista de Contratos</returns>
        List<ListadoContratoLogic> ListadoContratoPrincipal(string numeroContrato, string descripcion, string TipoServicioLC);

        /// <summary>
        /// Obtiene el Monto Acumulado del Contrato Principal más sus Adendas
        /// </summary>
        /// <param name="codigoContratoPrincipal">Código de Contrato Principal</param>
        /// <returns>Registro con el Monto Acumulado del Contrato Principal más sus Adendas</returns>
        List<ListadoContratoLogic> ObtenerMontoAcumuladoContrato(Guid codigoContratoPrincipal);

        /// <summary>
        /// Obtiene las variables del parrafo
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato</param>
        /// <returns>Lista de variables de los parrafos de un contrato</returns>
        List<ContratoParrafoVariableLogic> ObtenerVariablesContratoParrafo(Guid codigoContrato);

        /// <summary>
        /// Obtiene los bienes de un contrato
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato</param>
        /// <returns>Lista de variables de los parrafos de un contrato</returns>
        List<ContratoBienLogic> ObtenerBienesContrato(Guid codigoContrato);

        /// <summary>
        /// Obtiene los firmantes de un contrato
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato</param>
        /// <returns>Lista de firmantes de los parrafos de un contrato</returns>
        List<ContratoFirmanteLogic> ObtenerFirmantesContrato(Guid codigoContrato);

        /// <summary>
        /// Realiza la búsqueda de Contratos sin paginación
        /// </summary>
        /// <param name="codigoContrato">Código de Contrato</param>
        /// <param name="codigoTipoServicio">Código de Tipo de Servicio</param>
        /// <param name="codigoTipoRequerimiento">Código de Tipo de Requerimiento</param>
        /// <param name="codigoTipoDocumento">Código de Tipo de Documento</param>
        /// <param name="codigoEstadoVigencia">Código de Estado de Vigencia</param>
        /// <param name="numeroContrato">Número de Contrato</param>
        /// <param name="numeroDocumento">Número de Documento</param>
        /// <param name="nombreProveedor">Nombre de Proveedor</param>
        /// <param name="descripcion">Descripción de Contrato</param>
        /// <returns>Lista de contratos</returns>
        List<ListadoContratoLogic> BuscarContrato(
            Guid? codigoContrato,
            Guid? codigoContratoPrincipal,
            string codigoTipoServicio,
            string codigoTipoRequerimiento,
            string codigoTipoDocumento,
            string codigoEstadoVigencia,
            string numeroContrato,
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
        List<ListadoContratoLogic> BuscarCorrelativoContrato(Guid? codigoUnidadOperativa, string codigoTipoRequerimiento, string codigoTipoDocumento);

        List<string> Listar_Contrato_Segun_Unidad_Operativa(Guid? codigoUnidadOperativa);
        
         /// <summary>
         /// Eliminar un contrato
         /// </summary>
         /// <param name="codigoContrato">Código de contrato</param>     
         /// <param name="motivoEliminacion">Motivo de eliminación</param>
         /// <param name="usuarioSesion">Nombre de usuario</param>
         /// <param name="terminal">Terminal de usuario</param>
         /// <returns>Indicador con el resultado de la operación</returns>
        int EliminarContrato(Guid codigoContrato, string motivoEliminacion, string usuarioSesion, string terminal);
    }

}

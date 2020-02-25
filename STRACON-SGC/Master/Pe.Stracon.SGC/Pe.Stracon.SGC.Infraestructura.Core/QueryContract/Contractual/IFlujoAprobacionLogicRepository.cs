using System;
using System.Collections.Generic;
using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;


namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    /// <summary>
    /// Definicion del Repositorio Flujo Aprobacion Logic
    /// </summary>
    public interface IFlujoAprobacionLogicRepository : IQueryRepository<FlujoAprobacionLogic>
    {
        /// <summary>
        /// Realiza la búsqueda de Flujo Aprobacion
        /// </summary>
        /// <param name="codigoFlujoAprobacion">codigo Flujo Aprobacion</param>
        /// <param name="codigoUnidadOperativa">codigo Unidad Operativa</param>
        /// <param name="estadoRegistro">estado Registro</param>
        /// <returns>registros Flujo aprobacion con los datos de busqueda</returns>
        List<FlujoAprobacionLogic> BuscarBandejaFlujoAprobacion(
            Guid? codigoFlujoAprobacion,
            Guid? codigoUnidadOperativa,
            bool? indicadorAplicaMontoMinimo,
            string estadoRegistro
        );

        /// <summary>
        /// Realiza la búsqueda de Flujo Aprobacion Estadio
        /// </summary>
        /// <param name="CodigoFlujoAprobacionEstadio">Codigo Flujo Aprobacion Estadio</param>
        /// <param name="CodigoFlujoAprobacion">Codigo Flujo Aprobacion</param>
        /// <returns>registros Flujo aprobacion con los datos de busqueda</returns>
        List<FlujoAprobacionEstadioLogic> BuscarBandejaFlujoAprobacionEstadio(
            Guid? CodigoFlujoAprobacionEstadio,
            Guid? CodigoFlujoAprobacion
        );

        /// <summary>
        /// Elimina Participante 
        /// </summary>
        /// <param name="codigoFlujoAprobacionEstadio">codigo Flujo Aprobacion Estadio</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int EliminaParticipante(
            Guid codigoFlujoAprobacionEstadio
        );

        /// <summary>
        /// Valida Registro o edicion de campo Orden
        /// </summary>
        /// <param name="CodigoFlujoAprobacion">Codigo Flujo Aprobacion</param>
        /// <param name="orden">orden</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        List<FlujoAprobacionEstadioLogic> RepiteFlujoAprobacionEstadioOrden(
            Guid CodigoFlujoAprobacion,
            byte orden
        );

        /// <summary>
        /// Valida Registro o edicion de campo Descripcion
        /// </summary>
        /// <param name="CodigoFlujoAprobacion">Codigo Flujo Aprobacion</param>
        /// <param name="descripcion">descripcion</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        List<FlujoAprobacionEstadioLogic> RepiteFlujoAprobacionEstadioDescripcion(
            Guid CodigoFlujoAprobacion,
            string descripcion
        );

        /// <summary>
        /// Copia estadios
        /// </summary>
        /// <param name="codigoFlujoAprobacionHasta">codigo Flujo Aprobacion Hasta</param>
        /// <param name="codigoFlujoAprobacionADesde">codigo Flujo AprobacionA Desde</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int CopiarEstadio(
            Guid codigoFlujoAprobacionHasta,
            Guid codigoFlujoAprobacionADesde,
            string usuario,
            string terminal
        );

        /// <summary>
        /// Realiza la búsqueda de Flujo Aprobación Tipo de Servicio
        /// </summary>
        /// <param name="codigoFlujoAprobacionTipoServicio">Código Flujo Aprobación Tipo de Servicio</param>
        /// <param name="codigoFlujoAprobacion">Código de Flujo de Aprobación</param>
        /// <param name="codigoTipoServicio">Código de Tipo de Servicio</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>registros Flujo aprobacion con los datos de busqueda</returns>
        List<FlujoAprobacionTipoServicioLogic> BuscarFlujoAprobacionTipoServicio(
            Guid? codigoFlujoAprobacionTipoServicio,
            Guid? codigoFlujoAprobacion,
            string codigoTipoServicio,
            string estadoRegistro
        );

        /// <summary>
        /// Realiza la búsqueda de Flujo Aprobacion Participante
        /// </summary>
        /// <param name="CodigoFlujoAprobacion">Codigo Flujo Aprobacion</param>
        /// <returns>registros Flujo aprobacion con los datos de busqueda</returns>
        List<FlujoAprobacionParticipanteLogic> BuscarFlujoAprobacionParticipante(
            Guid? codigoFlujoAprobacion
        );

        /// <summary>
        /// Realiza la búsqueda de Estadios de Flujo de Aprobación Estadio
        /// </summary>
        /// <param name="descripcion">Descripción de Estadio</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista de Estadios de Flujo de Aprobación Estadio</returns>
        List<FlujoAprobacionEstadioLogic> BuscarFlujoAprobacionEstadioDescripcion(
            string descripcion,
            string estadoRegistro
        );

        /// <summary>
        /// Actualiza el reemplazo al trabajador original
        /// </summary>
        /// <param name="codigoTrabajador">Codigo de trabajador</param>
        /// <returns>Lista de consultas</returns>
        void ActualizarTrabajadorOriginalFlujo(Guid codigoTrabajador);

         /// <summary>
        /// Realiza la búsqueda de Flujo Aprobación Tipo de Contrato
        /// </summary>
        /// <param name="codigoFlujoAprobacionTipoContrato">Código Flujo Aprobación Tipo de contrato</param>
        /// <param name="codigoFlujoAprobacion">Código de Flujo de Aprobación</param>
        /// <param name="codigoTipoContrato">Código de Tipo de Contrato</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista de Flujo Aprobación Tipo de Contrato</returns>
        List<FlujoAprobacionTipoContratoLogic> BuscarFlujoAprobacionTipoContrato(
            Guid? codigoFlujoAprobacionTipoContrato,
            Guid? codigoFlujoAprobacion,
            string codigoTipoContrato,
            string estadoRegistro
        );

        /// <summary>
        /// Obtener el responsable del siguiente estadio de flujo de aprobación
        /// </summary>
        /// <param name="codigoFlujoAprobacion">Codigo Flujo Aprobacion</param>
        /// <param name="orden">orden</param>        
        /// <param name="codigoFlujoAprobacionEstadio">Código flujo de aprobación estadio</param>
        /// <param name="codigoContratoEstadio">Código contrato estadio</param>
        /// <returns>Código de responsable</returns>
        Guid ObtenerResponsableSiguienteEstadioFlujoAprobacion(
            Guid codigoFlujoAprobacion,
            byte orden,
            Guid codigoFlujoAprobacionEstadio,
            Guid codigoContratoEstadio
        );
    }
}

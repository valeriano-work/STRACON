using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.CommandModel;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using System;
using System.Collections.Generic;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Definición del Repositorio de Flujo Aprobacion Estadio
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150511 <br />
    /// Modificación :           <br />
    /// </remarks>    
    public interface IFlujoAprobacionEstadioEntityRepository : IComandRepository<FlujoAprobacionEstadioEntity>
    {
        /// <summary>
        /// Actualiza indicador version oficial
        /// </summary>
        /// <param name="codigoFlujoAprobacion"></param>
        /// <returns>lista con registros</returns>
        int ActualizaIndicadorVersionOficial(
            Guid codigoFlujoAprobacion
        );

        /// <summary>
        /// Actualiza indicador número contrato
        /// </summary>
        /// <param name="codigoFlujoAprobacion"></param>
        /// <returns>lista con registros</returns>
        int ActualizaIndicadorNumeroContrato(
            Guid CodigoFlujoAprobacion
        );

        /// <summary>
        /// registrar el Flujo Ap
        /// </summary>
        /// <param name="entidad"></param>
        /// <param name="flagRegistrarregistrar"></param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int DesplazarOrden(
            FlujoAprobacionEstadioEntity entidad,
            string flagRegistrar 
        );
        
    }
}

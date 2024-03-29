﻿using Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Base;

namespace Pe.Stracon.SGC.Infraestructura.Core.CommandContract.Contractual
{
    /// <summary>
    /// Definición del Repositorio de Requerimiento Bien
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150803 <br />
    /// Modificación :               <br />
    /// </remarks> 
    public interface IRequerimientoBienEntityRepository : IComandRepository<RequerimientoBienEntity>
    {
        /// <summary>
        /// Realiza la inserción de contrato bien
        /// </summary>
        /// <param name="data">Datos a registrar</param>
        /// <returns>Indicador con el resultado de la operación</returns>
        int RegistrarRequerimientoBien(RequerimientoBienEntity data);
    }
}

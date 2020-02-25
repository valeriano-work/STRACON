using System.Collections.Generic;
using Pe.Stracon.Politicas.Infraestructura.Core.Base;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;

namespace Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General
{
    /// <summary>
    /// Interface de Parametro de Valor Repository
    /// </summary>
    /// <remarks>
    /// Creación:   GMD <br />
    /// Modificación:            <br />
    /// </remarks>
    public interface IParametroSeccionLogicRepository : IQueryRepository<ParametroSeccionLogic>
    {
        /// <summary>
        /// Realiza la busqueda de Parametro Seccion
        /// </summary>
        /// <param name="codigoParametro">Código de Parametro</param>
        /// <param name="codigoSeccion">Código de Sección</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="codigoTipoDato">Código de Tipo de Dato</param>
        /// <param name="indicadorPermiteModificar">Identificador de Permite Modificar</param>
        /// <param name="indicadorObligatorio">Indicador de Sección Obligatorio</param>
        /// <param name="indicadorSistema">Indicador de Sistema</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista de secciones de parametro</returns>
        List<ParametroSeccionLogic> BuscarParametroSeccion(int? codigoParametro, int? codigoSeccion, string nombre, string codigoTipoDato, bool? indicadorPermiteModificar, bool? indicadorObligatorio, bool? indicadorSistema, string estadoRegistro);
    }
}

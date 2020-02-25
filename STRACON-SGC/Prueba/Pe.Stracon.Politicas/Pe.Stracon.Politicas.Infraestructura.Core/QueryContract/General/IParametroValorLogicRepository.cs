using System.Collections.Generic;
using Pe.Stracon.Politicas.Infraestructura.Core.Base;
using Pe.Stracon.Politicas.Infraestructura.QueryModel.General;
using System;
using System.Data;

namespace Pe.Stracon.Politicas.Infraestructura.Core.QueryContract.General
{
    /// <summary>
    /// Interface de Parametro de Valor Repository
    /// </summary>
    /// <remarks>
    /// Creación:   GMD <br />
    /// Modificación:            <br />
    /// </remarks>
    public interface IParametroValorLogicRepository : IQueryRepository<ParametroValorLogic>
    {
        /// <summary>
        /// Realiza la busqueda de Parametro Valor
        /// </summary>
        /// <param name="codigoParametro">Código de Parametro</param>
        /// <param name="indicadorGlobal">Indicador de Global</param>
        /// <param name="codigoEmpresa">Código de Empresa</param>
        /// <param name="codigoSistema">Código de Sistema</param>
        /// <param name="codigoIdentificador">Código Identificador</param>
        /// <param name="tipoParametro">Tipo de Parámetro</param>
        /// <param name="codigoSeccion">Código de Sección</param>
        /// <param name="codigoValor">Código de Valor</param>
        /// <param name="valor">Valor</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista de valores de parametro</returns>
        List<ParametroValorLogic> BuscarParametroValor(int? codigoParametro, bool? indicadorGlobal, Guid? codigoEmpresa, Guid? codigoSistema, string codigoIdentificador, string tipoParametro, int? codigoSeccion, int? codigoValor, string valor, string estadoRegistro);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoParametro"></param>
        /// <param name="indicadorGlobal"></param>
        /// <param name="codigoEmpresa"></param>
        /// <param name="codigoSistema"></param>
        /// <param name="codigoIdentificador"></param>
        /// <param name="tipoParametro"></param>
        /// <param name="codigoSeccion"></param>
        /// <param name="codigoValor"></param>
        /// <param name="valor"></param>
        /// <param name="estadoRegistro"></param>
        /// <returns></returns>
        DataTable BuscarParametroValorMejorado(int? codigoParametro, bool? indicadorGlobal, Guid? codigoEmpresa, Guid? codigoSistema, string codigoIdentificador, string tipoParametro, int? codigoSeccion, int? codigoValor, string valor, string estadoRegistro);
        /// <summary>
        /// Realiza el registro de un parametro valor
        /// </summary>
        /// <param name="parametroValorLogic">Entidad logica de parametro valor</param>
        /// <returns>Cantidad de registros registrados</returns>
        int RegistrarParametroValor(ParametroValorLogic parametroValorLogic);

        /// <summary>
        /// Realiza la modificación de un parametro valor
        /// </summary>
        /// <param name="parametroValorLogic">Entidad logica de parametro valor</param>
        /// <returns>Cantidad de registros modificados</returns>
        int ModificarParametroValor(ParametroValorLogic parametroValorLogic);
    }
}

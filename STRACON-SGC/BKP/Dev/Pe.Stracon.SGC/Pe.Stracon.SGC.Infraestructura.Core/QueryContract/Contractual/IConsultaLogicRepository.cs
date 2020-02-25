using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    public interface IConsultaLogicRepository : IQueryRepository<ConsultaLogic>
    {
        /// <summary>
        /// Retorna la lista de consulta.
        /// </summary>
        /// <param name="codigoRemitente">Codigo de Remitente</param>
        /// <param name="codigoDestinatario">Código de destinatario</param>
        /// <param name="CodigoTipoConsulta">Código de tipo de consulta</param>
        /// <param name="codigoUnidadOperativa">Código de unidad operativa</param>
        /// <param name="codigoArea">Código de área</param>
        /// <param name="codigoConsulta">Código de consulta</param>
        /// <param name="codigoUsuarioSesion">Código de usuario de sesion</param>
        /// <returns>Lista de consultas</returns>
        List<ConsultaLogic> ListaConsulta(Guid? codigoRemitente, Guid? codigoDestinatario, string CodigoTipoConsulta, Guid? codigoUnidadOperativa, string codigoArea, Guid? codigoConsulta, Guid? codigoUsuarioSesion, string estadoConsulta, int numeroPagina, int registroPagina);

        /// <summary>
        /// Envia correo de consulta
        /// </summary>
        /// <param name="asunto">Asunto</param>
        /// <param name="textoNotificar">Texto a notificar</param>
        /// <param name="cuentaNotificar">Cuenta a notificar</param>
        /// <param name="cuentasCopias">Cuentas a copiar en el correo</param>
        /// <param name="profileCorreo">Perfil del correo</param>
        int NotificarConsulta(string asunto, string textoNotificar, string cuentaNotificar, string cuentasCopias, string profileCorreo);

        /// <summary>
        /// Retorna la lista de consulta.
        /// </summary>
        /// <param name="codigoRemitente">Codigo de Remitente</param>
        /// <param name="codigoDestinatario">Código de destinatario</param>
        /// <param name="CodigoTipoConsulta">Código de tipo de consulta</param>
        /// <param name="codigoUnidadOperativa">Código de unidad operativa</param>
        /// <param name="codigoArea">Código de área</param>
        /// <param name="codigoConsulta">Código de consulta</param>
        /// <param name="codigoUsuarioSesion">Código de usuario de sesion</param>
        /// <returns>Lista de consultas</returns>
        List<ConsultaLogic> ListaConsultaSimple(Guid? codigoRemitente, Guid? codigoDestinatario, string CodigoTipoConsulta, Guid? codigoUnidadOperativa, string codigoArea, Guid? codigoConsulta, string estadoConsulta);
    }
}

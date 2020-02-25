using Pe.Stracon.Politicas.Infraestructura.CommandModel.General;
using Pe.Stracon.Politicas.Infraestructura.Core.CommandContract.General;
using Pe.Stracon.Politicas.Infraestructura.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Infraestructura.Repository.Command.General
{
    /// <summary>
    /// Implementación del Repositorio de Parametro Valor
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150617 <br />
    /// </remarks>
    public class ParametroValorEntityRepository : ComandRepository<ParametroValorEntity>, IParametroValorEntityRepository
    {
    }
}

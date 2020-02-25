using Pe.Stracon.SGC.Infraestructura.Core.Base;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Core.QueryContract.Contractual
{
    /// <summary>
    /// Definición del Repositorio de Requerimiento Documento Adjunto
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150611 <br />
    /// Modificación :               <br />
    /// </remarks>
    public interface IRequerimientoDocumentoAdjuntoLogicRepository : IQueryRepository<RequerimientoDocumentoAdjuntoLogic>
    {
        /// <summary>
        /// Permite buscar los documentos adjuntos de un contrato
        /// </summary>
        /// <param name="codigoRequerimientoDocumentoAdjunto">Código del Documento adjunto al contrato</param>
        /// <param name="codigoRequerimiento">Código del Requerimiento</param>
        /// <param name="codigoArchivo">Código de Archivo</param>
        /// <param name="nombreArchivo">Nombre de Archivo</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista documentos adjuntos del contrato</returns>
        List<RequerimientoDocumentoAdjuntoLogic> BuscarRequerimientoDocumentoAdjunto(Guid? codigoRequerimientoDocumentoAdjunto, Guid? codigoRequerimiento, int? codigoArchivo, string nombreArchivo, string estadoRegistro);
    }
}

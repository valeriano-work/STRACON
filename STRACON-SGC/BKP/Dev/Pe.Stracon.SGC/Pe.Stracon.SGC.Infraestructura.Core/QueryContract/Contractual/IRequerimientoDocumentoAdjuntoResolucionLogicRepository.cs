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
    public interface IRequerimientoDocumentoAdjuntoResolucionLogicRepository : IQueryRepository<RequerimientoDocumentoAdjuntoResolucionLogic>
    {
        /// <summary>
        /// Permite buscar los documentos adjuntos de un contrato
        /// </summary>
        /// <param name="codigoRequerimientoDocumentoAdjuntoResolucion">Código del Documento adjunto al contrato</param>
        /// <param name="codigoRequerimiento">Código del Requerimiento</param>
        /// <param name="codigoArchivo">Código de Archivo</param>
        /// <param name="nombreArchivo">Nombre de Archivo</param>
        /// <param name="estadoRegistro">Estado de Registro</param>
        /// <returns>Lista documentos adjuntos del contrato</returns>
        List<RequerimientoDocumentoAdjuntoResolucionLogic> BuscarRequerimientoDocumentoAdjuntoResolucion(Guid? codigoRequerimientoDocumentoAdjuntoResolucion, Guid? codigoRequerimiento, int? codigoArchivo, string nombreArchivo, string estadoRegistro);

        int Insertar_Documento_Adjunto_Resolucion(Guid? codigoRequerimiento, int? codigoArchivo, string nombreArchivo, string rutaArchivoSharepoint, string usuarioCreacion, string terminalCreacion, DateTime fechaResolucion);

    }
}
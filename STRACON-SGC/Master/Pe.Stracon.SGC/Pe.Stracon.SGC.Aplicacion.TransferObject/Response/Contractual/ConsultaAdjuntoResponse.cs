using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response adjuntos de la consulta
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150528 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ConsultaAdjuntoResponse
    {
        /// <summary>
        /// Código de consulta adjunto
        /// </summary>
        public Guid CodigoConsultaAdjunto { get; set; }
        /// <summary>
        /// Codigo de Consulta
        /// </summary>
        public Guid CodigoConsulta { get; set; }
        /// <summary>
        /// Código del Archivo
        /// </summary>
        public int? CodigoArchivo { get; set; }
        /// <summary>
        /// Ruta de Archivo en el SharePoint
        /// </summary>
        public string RutaArchivoSharePoint { get; set; }
        /// <summary>
        /// Nombre del Archivo
        /// </summary>
        public string NombreArchivo { get; set; }
        /// <summary>
        /// Usuario de Creacion
        /// </summary>
        public string UsuarioCreacion { get; set; }
        /// <summary>
        /// Contenido del archivo
        /// </summary>
        public Object ContenidoArchivo { get; set; }
        /// <summary>
        /// Valor que indica si el usuario en sesión es el creador del adjunto
        /// </summary>
        public bool EsCreador { get; set; }
    }
}

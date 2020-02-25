using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Consulta Adjunto
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ConsultaAdjuntoLogic : Logic
    {
        /// <summary>
        /// Codigo de Consulta Adjunto
        /// </summary>
        public Guid CodigoConsultaAdjunto { get; set; }
        /// <summary>
        /// Codigo de Consulta
        /// </summary>
        public Guid CodigoConsulta { get; set; }
        /// <summary>
        /// Codigo de Archivo
        /// </summary>
        public int CodigoArchivo { get; set; }
        /// <summary>
        /// Nombre de Archivo
        /// </summary>
        public string NombreArchivo { get; set; }
        /// <summary>
        /// Ruta de Archivo en el SharePoint
        /// </summary>
        public string RutaArchivoSharePoint { get; set; }
        /// <summary>
        /// Usuario de Creación
        /// </summary>
        public string UsuarioCreacion { get; set; }
        /// <summary>
        /// Fecha de Creación
        /// </summary>
        public DateTime FechaCreacion { get; set; }
        /// <summary>
        /// Terminal de Creación
        /// </summary>
        public string TerminalCreacion { get; set; }
    }
}

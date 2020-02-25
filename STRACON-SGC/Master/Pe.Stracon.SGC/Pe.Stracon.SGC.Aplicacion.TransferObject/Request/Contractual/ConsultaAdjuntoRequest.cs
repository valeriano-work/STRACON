using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Consulta Adjunto
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150608 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ConsultaAdjuntoRequest
    {
        /// <summary>
        /// Código de consulta adjunto
        /// </summary>
        public Guid? CodigoConsultaAdjunto { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid? CodigoConsulta { get; set; }
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
        /// Periodo
        /// </summary>
        private string extencionArchivo;
        /// <summary>
        /// Extención del archivo
        /// </summary>
        public string ExtencionArchivo
        {
            get
            {
                if (!string.IsNullOrEmpty(this.NombreArchivo))
                {
                    var splitNombreArchivo = NombreArchivo.Split('.');
                    if (splitNombreArchivo.Count() >= 2)
                    {
                        this.extencionArchivo = splitNombreArchivo.LastOrDefault();
                    }
                }
                return extencionArchivo;
            }
            set
            {
                extencionArchivo = value;
            }
        }
        /// <summary>
        /// Arreglo de byte del documento adjunto
        /// </summary>
        public byte[] ArchivoAdjunto { get; set; }

        /// <summary>
        /// Arreglo de byte del documento adjunto
        /// </summary>
        public string ArchivoAdjuntoBase64 { get; set; }
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Usuario en Sesión
        /// </summary>
        public string UsuarioSession { get; set; }
        /// <summary>
        /// Código de consulta relacionado
        /// </summary>
        public Guid? CodigoConsultaRelacionado { get; set; }
        /// <summary>
        /// Número de archivo
        /// </summary>
        public int NumeroArchivo { get; set; }
    }
}

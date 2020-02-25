using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Requerimiento Documento
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150608 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class RequerimientoDocumentoAdjuntoResolucionRequest
    {

        /// <summary>
        /// Código del Documento adjunto al Requerimiento
        /// </summary>
        public Guid? CodigoRequerimientoDocumentoAdjuntoResolucion { get; set; }
        /// <summary>
        /// Codigo de Requerimiento
        /// </summary>
        public Guid? CodigoRequerimiento { get; set; }
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
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
        /// La validacion que se obtiene del query. Relacionado al dato constante TipoValidacionRequerimientoResolucion
        /// </summary>
        public int ValidacionResolucion { get; set; }

        public DateTime FechaResolucion { get; set; }

        public string FechaResolucionString { get; set; }

        public string UsuarioCreacion { get; set; }

        public string FechaFinVigenciaString { get; set; }
    }
}
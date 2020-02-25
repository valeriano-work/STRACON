using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Contrato Documento
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150608 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ContratoDocumentoRequest : Filtro
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ContratoDocumentoRequest()
        {
            ListaContratoParrafo = new List<ContratoParrafoRequest>();
        }
        /// <summary>
        /// Código de Contrato Documento
        /// </summary>
        public string CodigoContratoDocumento { get; set; }
        /// <summary>
        /// Código de Contrato
        /// </summary>
        public string CodigoContrato { get; set; }
        /// <summary>
        /// Código de Archivo
        /// </summary>
        public int? CodigoArchivo { get; set; }
        /// <summary>
        /// Ruta de Archivo SharePoint
        /// </summary>
        public string RutaArchivoSharePoint { get; set; }
        /// <summary>
        /// Contenido
        /// </summary>
        public string Contenido { get; set; }
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
        /// Arreglo de Bytes del Documento
        /// </summary>
        public byte[] Documento { get; set; }
        /// <summary>
        /// Indicador Actual
        /// </summary>
        public bool? IndicadorActual { get; set; }
        /// <summary>
        /// Versión
        /// </summary>
        public Int16? Version { get; set; }
        /// <summary>
        /// Lista de Párrafo Contrato
        /// </summary>
        public List<ContratoParrafoRequest> ListaContratoParrafo { get; set; }
    }
}

using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Linq;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request del contrato
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150528 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class RequerimientoEstadioObservacionRequest : Filtro
    {
        /// <summary>
        /// Codigo Requerimiento Estadio de Observacion
        /// </summary>
        public Guid? CodigoRequerimientoEstadioObservacion { get; set; }
        /// <summary>
        /// Codigo Requerimiento de Estadio
        /// </summary>
        public Guid CodigoRequerimientoEstadio { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Fecha de Registro
        /// </summary>
        public DateTime? FechaRegistro { get; set; }
        /// <summary>
        /// Codigo de Parrafo
        /// </summary>
        public Guid? CodigoRequerimientoParrafo { get; set; }
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
        /// Documento de Requerimiento
        /// </summary>
        public byte[] DocumentoRequerimiento { get; set; }
        /// <summary>
        /// Indicador de Adhesion
        /// </summary>
        public bool IndicadorAdhesion { get; set; }
        /// <summary>
        /// Codigo Estadio de Retorno
        /// </summary>
        public Guid? CodigoEstadioRetorno { get; set; }
        /// <summary>
        /// Destinatario
        /// </summary>
        public Guid? Destinatario { get; set; }
        /// <summary>
        /// Codigo Tipo Respuesta
        /// </summary>
        public string CodigoTipoRespuesta { get; set; }
        /// <summary>
        /// Respuesta
        /// </summary>
        public string Respuesta { get; set; }
        /// <summary>
        /// Fecha de Respuesta
        /// </summary>
        public DateTime? FechaRespuesta { get; set; }
        /// <summary>
        /// Observador
        /// </summary>
        public Guid? Observador { get; set; }
        /// <summary>
        /// Código de Requerimiento
        /// </summary>
        public Guid? CodigoRequerimiento { get; set; }

        /// <summary>
        /// Los CC elegidos en el módulo de Requerimiento Observado. S10-SGC-04
        /// </summary>
        public string NotificacionObservadoCC { get; set; }
    }
}


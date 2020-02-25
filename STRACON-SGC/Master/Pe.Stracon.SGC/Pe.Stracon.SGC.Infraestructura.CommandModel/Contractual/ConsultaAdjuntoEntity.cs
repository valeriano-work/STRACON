using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Consulta Adjunto
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150525 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ConsultaAdjuntoEntity : Entity
    {
        /// <summary>
        /// Codigo Contrato Documento Adjunto
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
        /// Nombre del Archivo
        /// </summary>
        public string NombreArchivo { get; set; }
        /// <summary>
        /// ruta del archivo sharepoint
        /// </summary>
        public string RutaArchivoSharePoint { get; set; }
    }
}

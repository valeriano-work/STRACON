using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Requerimiento
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class RequerimientoObservadoAprobadoLogic : Logic
    {

        /// <summary>
        /// CodigoUnidadNegocio
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Nombre de Unidad Operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }
        /// <summary>
        /// CodigoRequerimiento
        /// </summary>
        public Guid? CodigoRequerimiento { get; set; }
        /// <summary>
        /// NumeroRequerimiento
        /// </summary>
        public string NumeroRequerimiento { get; set; }
        /// <summary>
        /// DescripcionRequerimiento
        /// </summary>
        public string DescripcionRequerimiento { get; set; }
        /// <summary>
        /// NumeroAdenda
        /// </summary>
        public string NumeroAdenda { get; set; }
        /// <summary>
        /// FechaInicioVigencia
        /// </summary>
        public DateTime FechaInicioVigencia { get; set; }
        /// <summary>
        /// FechaFinVigencia
        /// </summary>
        public DateTime FechaFinVigencia { get; set; }
        /// <summary>
        /// MontoRequerimiento
        /// </summary>
        public decimal MontoRequerimiento { get; set; }
        /// <summary>
        /// Tipo de Acción
        /// </summary>
        public string TipoAccion { get; set; }
        /// <summary>
        /// ComentarioObservacion
        /// </summary>
        public string Comentario { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AccionPor { get; set; }
        /// <summary>
        /// FechaObservacion
        /// </summary>
        public DateTime FechaAccion { get; set; }

        /// <summary>
        /// Respuesta
        /// </summary>
        public string Respuesta { get; set; }
        /// <summary>
        /// FechaRespuesta
        /// </summary>
        public DateTime FechaRespuesta { get; set; }
        /// <summary>
        /// UsuarioRespuesta
        /// </summary>
        public string UsuarioRespuesta { get; set; }
    }
}

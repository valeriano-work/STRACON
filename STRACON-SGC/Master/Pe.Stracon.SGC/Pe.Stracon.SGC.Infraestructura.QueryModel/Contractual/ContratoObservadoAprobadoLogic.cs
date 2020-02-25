using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Contrato
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ContratoObservadoAprobadoLogic : Logic
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
        /// CodigoContrato
        /// </summary>
        public Guid? CodigoContrato { get; set; }
        /// <summary>
        /// NumeroContrato
        /// </summary>
        public string NumeroContrato { get; set; }
        /// <summary>
        /// DescripcionContrato
        /// </summary>
        public string DescripcionContrato { get; set; }
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
        /// MontoContrato
        /// </summary>
        public decimal MontoContrato { get; set; }
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

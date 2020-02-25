using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Flujo Aprobacion Estadio
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class FlujoAprobacionEstadioLogic : Logic
    {
        /// <summary>
        /// Codigo Flujo Aprobacion Estadio
        /// </summary>
        public Guid CodigoFlujoAprobacionEstadio { get; set; }
        /// <summary>
        /// Codigo Flujo Aprobacion
        /// </summary>
        public Guid CodigoFlujoAprobacion { get; set; }
        /// <summary>
        /// Orden
        /// </summary>
        public byte Orden { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Tiempo Atencion
        /// </summary>
        public decimal TiempoAtencion { get; set; }
        /// <summary>
        /// Horas Atencion
        /// </summary>
        public decimal HorasAtencion { get; set; }
        /// <summary>
        /// Indicador Version Oficial
        /// </summary>
        public bool IndicadorVersionOficial { get; set; }
        /// <summary>
        /// Indicador Permite Carga
        /// </summary>
        public bool IndicadorPermiteCarga { get; set; }
        /// <summary>
        /// Indicador Numero Contrato
        /// </summary>
        public bool IndicadorNumeroContrato { get; set; }
        /// <summary>
        /// Codigos Representante
        /// </summary>
        public string CodigosRepresentante { get; set; }
        /// <summary>
        /// Codigo Responsable
        /// </summary>
        public string CodigoResponsable { get; set; }
        /// <summary>
        /// Codigos Informado
        /// </summary>
        public string CodigosInformado { get; set; }
        /// <summary>
        /// Indicador incluir visto
        /// </summary>
        public bool? IndicadorIncluirVisto { get; set; }
        /// <summary>
        /// Códigos Responsable de Vinculadas
        /// </summary>
        public string CodigosResponsableVinculadas { get; set; }

        /// <summary>
        /// Usuario de creación
        /// </summary>
        public string UsuarioCreacion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CorreoElectronico { get; set; }
    }
}

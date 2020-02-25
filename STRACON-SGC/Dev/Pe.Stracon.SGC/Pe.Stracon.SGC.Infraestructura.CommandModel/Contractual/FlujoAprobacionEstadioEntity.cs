using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Flujo Aprobacion Estadio
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150508 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class FlujoAprobacionEstadioEntity : Entity
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
        /// Incluir visto
        /// </summary>
        public bool IndicadorIncluirVisto { get; set; }
    }
}

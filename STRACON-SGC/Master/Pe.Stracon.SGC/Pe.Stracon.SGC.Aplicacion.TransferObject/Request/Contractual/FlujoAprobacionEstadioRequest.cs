using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Flujo Aprobacion Estadio
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class FlujoAprobacionEstadioRequest : Filtro
    {
        /// <summary>
        /// Constructor de clase
        /// </summary>
        public FlujoAprobacionEstadioRequest()
        {
            EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;
        }

        /// <summary>
        /// Codigo Flujo AprobacionEstadio
        /// </summary>
        public string CodigoFlujoAprobacionEstadio { get; set; }
        /// <summary>
        /// Codigo Flujo Aprobacion
        /// </summary>
        public string CodigoFlujoAprobacion { get; set; }
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
        /// Responsable
        /// </summary>
        public string Responsable { get; set; }
        /// <summary>
        /// Informados
        /// </summary>
        public string Informados { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
        /// <summary>
        /// Incluir visto
        /// </summary>
        public bool IndicadorIncluirVisto { get; set; }
        /// <summary>
        /// Responsable de Vinculadas
        /// </summary>
        public string ResponsableVinculadas { get; set; }
    }
}

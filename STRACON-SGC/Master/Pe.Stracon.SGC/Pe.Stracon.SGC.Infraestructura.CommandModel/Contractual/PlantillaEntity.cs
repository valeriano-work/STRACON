using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Implementación de la entidad para plantilla
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150519 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class PlantillaEntity : Entity
    {
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public Guid CodigoPlantilla { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Código de Tipo de Contrato
        /// </summary>
        public string CodigoTipoContrato { get; set; }
        /// <summary>
        /// Código de Tipo de Documento de Contrato
        /// </summary>
        public string CodigoTipoDocumentoContrato { get; set; }
        /// <summary>
        /// Código de Estado de Vigencia
        /// </summary>
        public string CodigoEstadoVigencia { get; set; }
        /// <summary>
        /// Indicador Adhesión
        /// </summary>
        public bool IndicadorAdhesion { get; set; }
        /// <summary>
        /// Fecha de Inicio de Vigencia
        /// </summary>
        public DateTime FechaInicioVigencia { get; set; }
        /// <summary>
        /// Fecha de Fin de Vigencia
        /// </summary>
        public DateTime? FechaFinVigencia { get; set; }
    }
}

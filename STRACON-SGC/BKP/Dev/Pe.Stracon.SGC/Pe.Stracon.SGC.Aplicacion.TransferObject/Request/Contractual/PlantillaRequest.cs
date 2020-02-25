using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de plantilla
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150518 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class PlantillaRequest : Filtro
    {
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public Guid CodigoContrato { get; set; }
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public string CodigoPlantilla { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Código de Tipo de Contrato
        /// </summary>
        public string CodigoTipoContrato { get; set; }
        /// <summary>
        /// Código de Tipo de Requerimiento
        /// </summary>
        public string CodigoTipoRequerimiento { get; set; }

        /// <summary>
        /// Código de Tipo de Documento de Contrato
        /// </summary>
        public string CodigoTipoDocumentoContrato { get; set; }

        /// <summary>
        /// Código de Tipo de Documento de Requerimiento
        /// </summary>
        public string CodigoTipoDocumentoRequerimiento { get; set; }

        /// <summary>
        /// Código de Estado de Vigencia
        /// </summary>
        public string CodigoEstadoVigencia { get; set; }
        /// <summary>
        /// Indicador Adhesión
        /// </summary>
        public bool? IndicadorAdhesion { get; set; }
        /// <summary>
        /// Fecha de Inicio de Vigencia en cadena de texto
        /// </summary>
        public string FechaInicioVigenciaString { get; set; }
        /// <summary>
        /// Fecha de Fin de Vigencia en cadena de texto
        /// </summary>
        public string FechaFinVigenciaString { get; set; }
        /// <summary>
        /// Indicador de copia
        /// </summary>
        public string IndicadorCopia { get; set; }
        /// <summary>
        /// Código de la plantilla a copiar
        /// </summary>
        public string CodigoPlantillaCopiar { get; set; }
        //INICIO: Agregado por Julio Carrera -Norma Contable
        /// <summary>
        /// Indica si un contrato es de tipo arrendamiento de equipo mayor o menor
        /// </summary>
        public bool EsMayorMenor { get; set; }
        //FIN: Agregado por Julio Carrera -Norma Contable
    }
}

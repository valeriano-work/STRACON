using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System.Collections.Generic;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto response de Flujo Aprobacion
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class FlujoAprobacionResponse : Paginado
    {
        /// <summary>
        /// Codigo Flujo Aprobacion
        /// </summary>
        public string CodigoFlujoAprobacion { get; set; }
        /// <summary>
        /// Descripcion Flujo Aprobacion
        /// </summary>
        public string DescripcionFlujoAprobacion { get; set; }
        /// <summary>
        /// Codigo Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Descripcion Unidad Operativa
        /// </summary>
        public string DescripcionUnidadOperativa { get; set; }

        /// <summary>
        /// Indicador de Aplica Monto Mínimo
        /// </summary>
        public bool IndicadorAplicaMontoMinimo { get; set; }
        /// <summary>
        /// Lista de Tipo Servicio
        /// </summary>
        public List<string> ListaTipoServicio { get; set; }
        /// <summary>
        /// Descripcion Tipo Servicio
        /// </summary>
        public string DescripcionTipoServicio { get; set; }
        /// <summary>
        /// Codigo Tipo Contrato
        /// </summary>
        public string CodigoTipoContrato { get; set; }
        /// <summary>
        /// Descripcion Tipo Contrato
        /// </summary>
        public string DescripcionTipoContrato { get; set; }
        /// <summary>
        /// Lista primer firmante
        /// </summary>
        public Dictionary<string, string> ListaPrimerFirmante { get; set; }
        /// <summary>
        /// Lista segundo firmante
        /// </summary>
        public Dictionary<string, string> ListaSegundoFirmante { get; set; }
        /// <summary>
        /// Código del primer firmante
        /// </summary>
        public string CodigoPrimerFirmante { get; set; }
        /// <summary>
        /// Código del Segundo Firmante
        /// </summary>
        public string CodigoSegundoFirmante { get; set; }
        /// <summary>
        /// Nombre del primer firmante
        /// </summary>
        public string NombrePrimerFirmante { get; set; }
        /// <summary>
        /// Nombre del Segundo Firmante
        /// </summary>
        public string NombreSegundoFirmante { get; set; }


        /// <summary>
        /// Lista primer firmante Vinculada
        /// </summary>
        public Dictionary<string, string> ListaPrimerFirmanteVinculada { get; set; }
        /// <summary>
        /// Lista segundo firmante
        /// </summary>
        public Dictionary<string, string> ListaSegundoFirmanteVinculada { get; set; }
        /// <summary>
        /// Código del primer firmante
        /// </summary>
        public string CodigoPrimerFirmanteVinculada { get; set; }
        /// <summary>
        /// Código del Segundo Firmante
        /// </summary>
        public string CodigoSegundoFirmanteVinculada { get; set; }
        /// <summary>
        /// Nombre del primer firmante
        /// </summary>
        public string NombrePrimerFirmanteVinculada { get; set; }
        /// <summary>
        /// Nombre del Segundo Firmante
        /// </summary>
        public string NombreSegundoFirmanteVinculada { get; set; }
      
    }
}

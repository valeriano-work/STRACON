using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto response de Flujo Aprobacion Estadio
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class FlujoAprobacionEstadioResponse : Paginado
    {
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
        /// Codigos Representante
        /// </summary>
        public string[] CodigosRepresentante { get; set; }
        /// <summary>
        /// CodigoResponsable
        /// </summary>
        public string CodigoResponsable { get; set; }
        /// <summary>
        /// Codigos Informado
        /// </summary>
        public string[] CodigosInformado { get; set; }
        /// <summary>
        /// Nombre Representante
        /// </summary>
        public string NombreRepresentante { get; set; }
        /// <summary>
        /// Nombre Informado
        /// </summary>
        public string NombreInformado { get; set; }
        /// <summary>
        /// Nombre Responsable Vinculadas
        /// </summary>
        public string NombreResponsableVinculadas { get; set; }

        /// <summary>
        /// Lista Nombre Representante
        /// </summary>
        public Dictionary<string, string> ListaNombreRepresentante { get; set; }
        /// <summary>
        /// Lista Nombre Informado
        /// </summary>
        public Dictionary<string, string> ListaNombreInformado { get; set; }

        /// <summary>
        /// Lista Responsable de Vinculadas
        /// </summary>
        public Dictionary<string, string> ListaNombreResponsableVinculadas { get; set; }
        
        /// <summary>
        /// Incluir visto
        /// </summary>
        public bool? IndicadorIncluirVisto { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CorreoElectronico { get; set; }

    }
}

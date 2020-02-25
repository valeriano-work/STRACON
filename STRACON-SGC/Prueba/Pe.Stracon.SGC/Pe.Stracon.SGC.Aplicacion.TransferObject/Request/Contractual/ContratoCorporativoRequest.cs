using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request del contrato corporativo
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20170623 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ContratoCorporativoRequest : Filtro
    {
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Número de Contrato
        /// </summary>
        public string NumeroContrato { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Código de Tipo de Servicio
        /// </summary>
        public string CodigoTipoServicio { get; set; }
        /// <summary>
        /// Código de Tipo de Requerimiento
        /// </summary>
        public string CodigoTipoRequerimiento { get; set; }
        /// <summary>
        /// Código de Tipo de Documento
        /// </summary>
        public string CodigoTipoDocumento { get; set; }       
        /// <summary>
        /// Fecha de Inicio de Vigencia
        /// </summary>
        public DateTime? FechaInicioVigencia { get; set; }
        /// <summary>
        /// Fecha de Fin de Vigencia
        /// </summary>
        public DateTime? FechaFinVigencia { get; set; }

        /// <summary>
        /// Fecha de Inicio de Vigencia
        /// </summary>
        public string FechaInicioVigenciaString { get; set; }
        /// <summary>
        /// Fecha de Fin de Vigencia
        /// </summary>
        public string FechaFinVigenciaString { get; set; }  

        /// <summary>
        /// Código de Estado de Contrato
        /// </summary>
        public string CodigoEstado { get; set; }
        
        /// <summary>
        /// Nombre Proveedor
        /// </summary>
        public string NombreProveedor { get; set; }
    }
}

using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Listado de Contratos corporativos
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20170623 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ContratoCorporativoLogic : Logic 
    {
        /// <summary>
        /// Código de Contrato
        /// </summary>
        public Guid CodigoContrato { get; set; }
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public Guid CodigoUnidadOperativa { get; set; }    
        /// <summary>
        /// Nombre de Proveedor
        /// </summary>
        public string NombreProveedor { get; set; }
        /// <summary>
        /// Número de Contrato
        /// </summary>
        public string NumeroContrato { get; set; }
        /// <summary>
        /// Número de adenda
        /// </summary>
        public string NumeroAdendaConcatenado { get; set; }
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
        public DateTime FechaInicioVigencia { get; set; }       
        /// <summary>
        /// Fecha de Fin de Vigencia
        /// </summary>
        public DateTime FechaFinVigencia { get; set; }      
        /// <summary>
        /// Código de Estado de Contrato
        /// </summary>
        public string CodigoEstadoContrato { get; set; }  
        /// <summary>
        /// Código de Estado de Edición
        /// </summary>
        public string CodigoEstadoEdicion { get; set; }

        /// <summary>
        /// Nombre Unidad Operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }

        /// <summary>
        /// Usuario de creación de contrato
        /// </summary>
        public string UsuarioCreacion { get; set; }

        /// <summary>
        /// Fecha de Creación
        /// </summary>
        public DateTime FechaCreacion { get; set; }       
       
    }
}

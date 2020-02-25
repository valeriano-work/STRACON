using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Contratos corporativos
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20170626 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ContratoCorporativoResponse
    {
        /// <summary>
        /// Código de contrato
        /// </summary>
        public Guid CodigoContrato { get; set; }

        /// <summary>
        /// Código Unidad Operativa
        /// </summary>
        public Guid CodigoUnidadOperativa { get; set; }

        /// <summary>
        /// Nombre unidad operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }
        /// <summary>
        /// Descrpción de contrato
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Número de contrato
        /// </summary>
        public string NumeroContrato { get; set; }
        /// <summary>
        /// Número de adenda
        /// </summary>
        public string NumeroAdenda { get; set; }
        /// <summary>
        /// Nombre de proveedor
        /// </summary>
        public string Proveedor { get; set; }
        /// <summary>
        /// Fecha de inicio de contrato
        /// </summary>
        public DateTime FechaInicioVigencia { get; set; }
        /// <summary>
        /// Fecha fin de contrato
        /// </summary>
        public DateTime FechaFinVigencia { get; set; }
        /// <summary>
        /// Tipo de contrato
        /// </summary>
        public string TipoContrato { get; set; }
        /// <summary>
        /// Tipo de servicio
        /// </summary>
        public string TipoServicio { get; set; }
        /// <summary>
        /// Tipo de documento
        /// </summary>
        public string TipoDocumento { get; set; }
        /// <summary>
        /// Estado de contrato
        /// </summary>
        public string EstadoContrato { get; set; }

        /// <summary>
        /// Fecha de Inicio de Vigencia
        /// </summary>
        public string FechaInicioVigenciaString { get; set; }
        /// <summary>
        /// Fecha de Fin de Vigencia
        /// </summary>
        public string FechaFinVigenciaString { get; set; }

        /// <summary>
        /// Código estado de edición
        /// </summary>
        public string CodigoEstadoEdicion { get; set; }

        /// <summary>
        /// Usuario de creación de contrato
        /// </summary>
        public string UsuarioCreacion { get; set; }

        /// <summary>
        /// Fecha de creación
        /// </summary>
        public string FechaCreacionString { get; set; }
       

    }
}
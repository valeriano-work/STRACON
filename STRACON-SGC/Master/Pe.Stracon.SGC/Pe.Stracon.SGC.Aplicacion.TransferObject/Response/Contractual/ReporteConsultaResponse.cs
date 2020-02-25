using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Reporte de Consulta
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20160712 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ReporteConsultaResponse
    {
        /// <summary>
        /// Código de Remitente
        /// </summary>
        public string CodigoRemitente { get; set; }
        /// <summary>
        /// Nombre de Remitente
        /// </summary>
        public string NombreRemitente { get; set; }
        /// <summary>
        /// Código de Destinatario
        /// </summary>
        public string CodigoDestinatario { get; set; }
        /// <summary>
        /// Nombre de Destinatario
        /// </summary>
        public string NombreDestinatario { get; set; }
        /// <summary>
        /// Código de Tipo de Consulta
        /// </summary>
        public string CodigoTipoConsulta { get; set; }
        /// <summary>
        /// Descripción de Tipo de Consulta
        /// </summary>
        public string DescripcionTipoConsulta { get; set; }
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Nombre de Unidad Operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Área de Empresa
        /// </summary>
        public string CodigoAreaEmpresa { get; set; }
        /// <summary>
        /// Descripción de Área de Empresa
        /// </summary>
        public string DescripcionAreaEmpresa { get; set; }
        /// <summary>
        /// Código de Estado de Consulta
        /// </summary>
        public string CodigoEstadoConsulta { get; set; }
        /// <summary>
        /// Descripción de Estado de Consulta
        /// </summary>
        public string DescripcionEstadoConsulta { get; set; }
    }
}

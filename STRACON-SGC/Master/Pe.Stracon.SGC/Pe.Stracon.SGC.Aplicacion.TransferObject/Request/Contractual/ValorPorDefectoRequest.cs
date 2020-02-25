using System;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Valor Por Defecto
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class ValorPorDefectoRequest : Filtro
    {
        /// <summary>
        /// Código de la Variable
        /// </summary>
        public string CodigoVariable { get; set; }
        /// <summary>
        /// Identificador Variable
        /// </summary>
        public string IdentificadorVariable { get; set; }
        /// <summary>
        /// Código Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Nombre Unidad Operativa
        /// </summary>
        public string NombreUnidadOperativa { get; set; }
        /// <summary>
        /// Código Tipo de servicio
        /// </summary>
        public string CodigoTipoServicio { get; set; }
        /// <summary>
        /// Descripción Tipo de Servicio
        /// </summary>
        public string DescripcionTipoServicio { get; set; }
        /// <summary>
        /// Código Tipo de requerimiento
        /// </summary>
        public string CodigoTipoRequerimiento { get; set; }
        /// <summary>
        /// Descripción de Tipo de Requerimiento
        /// </summary>
        public string DescripcionTipoRequerimiento { get; set; }
        /// <summary>
        /// Ruc de proveedor
        /// </summary>
        public string RucProveedor { get; set; }
        /// <summary>
        /// Nombre de proveedor
        /// </summary>
        public string NombreProveedor { get; set; }
        /// <summary>
        /// Código tipo de documento
        /// </summary>
        public string CodigoTipoDocumento { get; set; }
        /// <summary>
        /// Descripción tipo de documento
        /// </summary>
        public string DescripcionTipoDocumento { get; set; }
        /// <summary>
        /// Código contrato principal
        /// </summary>
        public string CodigoContratoPrincipal { get; set; }
        /// <summary>
        /// Número Contrato principal
        /// </summary>
        public string NumeroContratoPrincipal { get; set; }
        /// <summary>
        /// Código de Moneda
        /// </summary>
        public string CodigoMoneda { get; set; }
        /// <summary>
        /// Descripción de moneda
        /// </summary>
        public string DescripcionMoneda { get; set; }
        /// <summary>
        /// Monto de contrato
        /// </summary>
        public Decimal MontoContrato { get; set; }
        /// <summary>
        /// Monto de contrato string
        /// </summary>
        public string MontoContratoString { get; set; }
        /// <summary>
        /// Fecha inicio de contrato
        /// </summary>
        public DateTime FechaInicioContrato { get; set; }
        /// <summary>
        /// Fecha inicio de contrato string
        /// </summary>
        public string FechaInicioContratoString { get; set; }
        /// <summary>
        /// Fecha fin de contrato
        /// </summary>
        public DateTime FechaFinContrato { get; set; }
        /// <summary>
        /// Fecha fin de contrato string
        /// </summary>
        public string FechaFinContratoString { get; set; }
        /// <summary>
        /// Descripción de contrato
        /// </summary>
        public string DescripcionContrato { get; set; }

        ///// <summary>
        ///// Primer representante
        ///// </summary>
        //public string PrimerRepresentante { get; set; }
        ///// <summary>
        ///// Segundo representante
        ///// </summary>
        //public string SegundoRepresentante { get; set; }
        ///// <summary>
        ///// Tipo de documento del Primer representante
        ///// </summary>
        //public string TipoDocIdentidadPrimerRepresentante { get; set; }
        ///// <summary>
        ///// Tipo de documento del Segundo representante
        ///// </summary>
        //public string TipoDocIdentidadSegundoRepresentante { get; set; }
        ///// <summary>
        ///// DNI primer representante
        ///// </summary>
        //public string DNIPrimerRepresentante { get; set; }
        ///// <summary>
        ///// DNI segundo representante
        ///// </summary>
        //public string DNISegundoRepresentante { get; set; }
    }
}

using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Empresa Vinculada
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20171009 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class EmpresaVinculadaResponse
    {
        /// <summary>
        /// Codigo de Empresa Vinculada
        /// </summary>
        public Guid CodigoEmpresaVinculada { get; set; }
        /// <summary>
        /// Nombre de Empresa
        /// </summary>
        public string NombreEmpresa { get; set; }
        /// <summary>
        /// Número de RUC
        /// </summary>
        public string NumeroRuc { get; set; }
    }
}

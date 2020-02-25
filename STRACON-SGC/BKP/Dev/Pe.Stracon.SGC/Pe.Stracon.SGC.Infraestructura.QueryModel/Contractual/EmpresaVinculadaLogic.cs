using System;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Empresa Vinculada
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20171009 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class EmpresaVinculadaLogic
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

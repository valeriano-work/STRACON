using System;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Entidad que retorna el código y valor de un parámetro.
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 14042015 <br />
    /// Modificación:            <br />
    /// </remarks>
    /// 
    [Serializable]
    public class CodigoValorResponse
    {
        /// <summary>
        /// Código de parámetro
        /// </summary>
        public object Codigo { get; set; }
        /// <summary>
        /// Valor de parámetro
        /// </summary>
        public object Valor { get; set; }
    }
}

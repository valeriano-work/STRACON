using System;
namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    [Serializable]
    public class BienRegistroResponse
    {
        /// <summary>
        /// Tipo de contenido
        /// </summary>
        public string Tipo { get; set; }
        /// <summary>
        /// Valor del contenido
        /// </summary>
        public string Valor { get; set; }
    }
}

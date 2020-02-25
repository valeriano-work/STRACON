using System;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Bien Alquiler
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150527 <br />
    /// Modificación :           <br />
    /// </remarks>
    [Serializable]
    public class RequerimientoParrafoResponse
    {
        /// <summary>
        /// Codigo de Contrato Parrafo
        /// </summary>
        public Guid CodigoRequerimientoParrafo { get; set; }
        /// <summary>
        /// Codigo de Contrato
        /// </summary>
        public Guid CodigoRequerimiento { get; set; }
        /// <summary>
        /// Codigo de Plantilla Parrafo
        /// </summary>
        public Guid CodigoPlantillaParrafo { get; set; }
        /// <summary>
        /// Título del Párrafo
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// Contenido del párrafo
        /// </summary>
        public string Contenido { get; set; }
        /// <summary>
        /// Orden del párrafo
        /// </summary>
        public byte Orden { get; set; } 
    }
}

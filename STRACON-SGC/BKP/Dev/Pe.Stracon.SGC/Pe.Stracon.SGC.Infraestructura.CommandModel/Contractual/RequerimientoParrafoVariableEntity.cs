using System;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Requerimiento Parrafo Variable
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150511 <br />
    /// Modificación :           <br />
    /// </remarks> 
    public class RequerimientoParrafoVariableEntity : Entity
    {
        /// <summary>
        /// Codigo Requerimiento de Parrafo Variable
        /// </summary>
        public Guid CodigoRequerimientoParrafoVariable { get; set; }
        /// <summary>
        /// Codigo Requerimiento de Parrafo
        /// </summary>
        public Guid CodigoRequerimientoParrafo { get; set; }
        /// <summary>
        /// Codigo de Variable
        /// </summary>
        public Guid CodigoVariable { get; set; }
        /// <summary>
        /// Valor de Texto
        /// </summary>
        public string ValorTexto { get; set; }
        /// <summary>
        /// Valor de Numero
        /// </summary>
        public decimal? ValorNumero { get; set; }
        /// <summary>
        /// Valor de Fecha
        /// </summary>
        public DateTime? ValorFecha { get; set; }
        /// <summary>
        /// ValorImagen
        /// </summary>
        public byte[] ValorImagen { get; set; }
        /// <summary>
        /// Valor de Tabla
        /// </summary>
        public string ValorTabla { get; set; }
        /// <summary>
        /// Valor de Tabla Editable
        /// </summary>
        public string ValorTablaEditable { get; set; }
        /// <summary>
        /// Valor de Bien
        /// </summary>
        public string ValorBien { get; set; }
        /// <summary>
        /// Valor de Bien Editable
        /// </summary>
        public string ValorBienEditable { get; set; }
        /// <summary>
        /// Valor de Firmante
        /// </summary>
        public string ValorFirmante { get; set; }
        /// <summary>
        /// Valor de Firmante Editable
        /// </summary>
        public string ValorFirmanteEditable { get; set; }
        /// <summary>
        /// Codigo de valor de la variable tipo lista
        /// </summary>
        public Guid? ValorLista { get; set; }
    }
}

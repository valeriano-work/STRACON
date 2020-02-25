using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Infraestructura.Repository.Query.Contractual
{
    /// <summary>
    /// Representa los datos de parrafo variable
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20151015 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ContratoParrafoVariableLogic : Logic
    {
        /// <summary>
        /// Codigo Contrato de Parrafo Variable
        /// </summary>
        public Guid CodigoContratoParrafoVariable { get; set; }
        /// <summary>
        /// Codigo Contrato de Parrafo
        /// </summary>
        public Guid CodigoContratoParrafo { get; set; }
        /// <summary>
        /// Codigo de Plantilla Párrafo
        /// </summary>
        public Guid CodigoPlantillaParrafo { get; set; }
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
        /// Valor Firmante
        /// </summary>
        public string ValorFirmante { get; set; }
        /// <summary>
        /// Valor Firmante Editable
        /// </summary>
        public string ValorFirmanteEditable { get; set; }
        /// <summary>
        /// Codigo de tipo de Variable
        /// </summary>
        public string CodigoTipo { get; set; }
        /// <summary>
        /// Identificador de Variable
        /// </summary>
        public string Identificador { get; set; }
        /// <summary>
        /// Codigo de variable tipo lista
        /// </summary>
        public Guid? ValorLista { get; set; }
    }
}

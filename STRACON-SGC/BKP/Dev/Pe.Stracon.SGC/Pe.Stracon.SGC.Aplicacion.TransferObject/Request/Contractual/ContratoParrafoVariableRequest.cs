using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Contrato Párrafo Variable
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150609 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ContratoParrafoVariableRequest : Filtro
    {
        /// <summary>
        /// Código de Contrato Párrafo Variable
        /// </summary>
        public string CodigoContratoParrafoVariable { get; set; }
        /// <summary>
        /// Código de Contrato Párrafo
        /// </summary>
        public string CodigoContratoParrafo { get; set; }
        /// <summary>
        /// Código de Variable
        /// </summary>
        public string CodigoVariable { get; set; }
        /// <summary>
        /// Valor de Variable Texto
        /// </summary>
        public string ValorTexto { get; set; }
        /// <summary>
        /// Valor de Variable Número
        /// </summary>
        public string ValorNumeroString { get; set; }
        /// <summary>
        /// Valor de Variable Fecha
        /// </summary>
        public string ValorFechaString { get; set; }
        /// <summary>
        /// Valor de Variable Imagen
        /// </summary>
        public byte[] ValorImagen { get; set; }
        /// <summary>
        /// Valor de Variable Tabla
        /// </summary>
        public string ValorTabla { get; set; }
        /// <summary>
        /// Valor de Variable Tabla Editable
        /// </summary>
        public string ValorTablaEditable { get; set; }
        /// <summary>
        /// Valor de Variable Bien
        /// </summary>
        public string ValorBien { get; set; }
        /// <summary>
        /// Valor de Variable Bien Editable
        /// </summary>
        public string ValorBienEditable { get; set; }
        /// <summary>
        /// Valor de Variable Firmante
        /// </summary>
        public string ValorFirmante { get; set; }
        /// <summary>
        /// Valor de Variable Firmante Editable
        /// </summary>
        public string ValorFirmanteEditable { get; set; }
        /// <summary>
        /// Código de Tipo de Variable
        /// </summary>
        public string CodigoTipoVariable { get; set; }
        /// <summary>
        /// Valor de Variable
        /// </summary>
        public string Valor { get; set; }
        /// <summary>
        /// Valor de Variable Editable
        /// </summary>
        public string ValorEditable { get; set; }
        /// <summary>
        /// Código de Plantilla Párrafo
        /// </summary>
        public string CodigoPlantillaParrafo { get; set; }
        /// <summary>
        /// Valor de Variable Lista
        /// </summary>
        public string ValorLista { get; set; }
    }
}

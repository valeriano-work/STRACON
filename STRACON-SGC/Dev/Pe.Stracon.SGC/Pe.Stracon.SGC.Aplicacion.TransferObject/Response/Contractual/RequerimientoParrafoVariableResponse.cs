using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual
{
    /// <summary>
    /// Representa el objeto response de Requerimiento Párrafo Variable
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150609 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class RequerimientoParrafoVariableResponse
    {
        /// <summary>
        /// Código de Requerimiento Párrafo Variable
        /// </summary>
        public Guid? CodigoRequerimientoParrafoVariable { get; set; }
        /// <summary>
        /// Código de Requerimiento Párrafo
        /// </summary>
        public Guid CodigoRequerimientoParrafo { get; set; }
        /// <summary>
        /// Codigo de Plantilla Párrafo
        /// </summary>
        public Guid CodigoPlantillaParrafo { get; set; }
        /// <summary>
        /// Código de Variable
        /// </summary>
        public Guid CodigoVariable { get; set; }
        /// <summary>
        /// Valor de Variable Texto
        /// </summary>
        public string ValorTexto { get; set; }
        /// <summary>
        /// Valor Decimal de Variable Número
        /// </summary>
        public decimal? ValorNumero { get; set; }
        /// <summary>
        /// Valor de Variable Número
        /// </summary>
        public string ValorNumeroString { get; set; }
        /// <summary>
        /// Valor Fecha de Variable Fecha
        /// </summary>
        public string ValorFecha { get; set; }
        /// <summary>
        /// Valor de Variable Fecha
        /// </summary>
        public string ValorFechaString { get; set; }
        /// <summary>
        /// Valor de Variable Imagen
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
        /// Lista de Requerimiento bienes
        /// </summary>
        public List<RequerimientoBienResponse> ListaRequerimientoBien { get; set; }
        /// <summary>
        /// Lista de firmantes de Requerimiento
        /// </summary>
        public List<RequerimientoFirmanteResponse> ListaRequerimientoFirmante { get; set; }
        /// <summary>
        /// Identificador
        /// </summary>
        public string Identificador { get; set; }
        /// <summary>
        /// Código del valor de Variable tipo lista
        /// </summary>
        public Guid? ValorLista { get; set; }
    }
}

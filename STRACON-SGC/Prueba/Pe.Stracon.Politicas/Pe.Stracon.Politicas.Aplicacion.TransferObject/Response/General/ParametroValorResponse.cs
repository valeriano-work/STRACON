using System.Collections.Generic;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Datos generales de parametro valor
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroValorResponse
    {
        /// <summary>
        /// Código de Parámetro
        /// </summary>
        public int CodigoParametro { get; set; }
        /// <summary>
        /// Código Identificador
        /// </summary>
        public string CodigoIdentificador { get; set; }
        /// <summary>
        /// Código de Valor
        /// </summary>
        public int CodigoValor { get; set; }
        /// <summary>
        /// Registro de Párametro en tipo Object
        /// </summary>
        public Dictionary<string, object> RegistroObjeto { get; set; }
        /// <summary>
        /// Registro de Párametro en tipo String
        /// </summary>
        public Dictionary<string, string> RegistroCadena { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }

        /// <summary>
        /// Valor de parametro
        /// </summary>
        public string Valor { get; set; }

        /// <summary>
        /// Código Sección
        /// </summary>
        public int CodigoSeccion { get; set; }

    }
}

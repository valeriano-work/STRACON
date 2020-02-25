using System.Collections.Generic;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General
{
    /// <summary>
    /// Representa el objeto de filtro a aplicar a la busqueda de parametro valor
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroValorRequest : Filtro
    {
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public ParametroValorRequest()
        {
            EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;
        }
        /// <summary>
        /// Código del Parametro
        /// </summary>
        public int? CodigoParametro { get; set; }
        /// <summary>
        /// Código Identificador
        /// </summary>
        public string CodigoIdentificador { get; set; }        
        /// <summary>
        /// Código de Empresa
        /// </summary>
        public string CodigoEmpresa { get; set; }
        /// <summary>
        /// Código de Sistema
        /// </summary>
        public string CodigoSistema { get; set; }
        /// <summary>
        /// Identificador Empresa
        /// </summary>
        public bool? IndicadorEmpresa { get; set; }
        /// <summary>
        /// Tipo de Parámetro
        /// </summary>
        public string TipoParametro { get; set; }
        /// <summary>
        /// Código de Sección
        /// </summary>
        public int? CodigoSeccion { get; set; }
        /// <summary>
        /// Código del Valor
        /// </summary>
        public int? CodigoValor { get; set; }
        /// <summary>
        /// Valor
        /// </summary>
        public string Valor { get; set; }
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
        /// Usuario
        /// </summary>
        public string Usuario { get; set; }
        /// <summary>
        /// Terminal
        /// </summary>
        public string Terminal { get; set; }
        /// <summary>
        /// Tipo de accion a realizar.
        /// </summary>
        public string Accion { get; set; }
    }

}

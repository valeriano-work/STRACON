using Pe.Stracon.Politicas.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Infraestructura.QueryModel.General
{
    /// <summary>
    /// Representa los datos de Parametro de Valor
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 27032015 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroValorLogic : Logic
    {
        /// <summary>
        /// Código de parametro
        /// </summary>
        public int CodigoParametro { get; set; }
        /// <summary>
        /// Código Identificador 
        /// </summary>
        public string CodigoIdentificador { get; set; }
        /// <summary>
        /// Identificador Empresa 
        /// </summary>
        public bool IndicadorEmpresa { get; set; }
        /// <summary>
        /// Código de Empresa
        /// </summary>
        public Guid CodigoEmpresa { get; set; }
        /// <summary>
        /// Código Sistema 
        /// </summary>
        public Guid? CodigoSistema { get; set; }
        /// <summary>
        /// Tipo de Parámetro
        /// </summary>
        public string TipoParametro { get; set; }
        /// <summary>
        /// Código de Sección 
        /// </summary>
        public int CodigoSeccion { get; set; }       
        /// <summary>
        /// Código de Valor
        /// </summary>
        public int CodigoValor { get; set; }
        /// <summary>
        /// Código de Tipo de Dato
        /// </summary>
        public string CodigoTipoDato { get; set; }
        /// <summary>
        /// Valor
        /// </summary>
        public string Valor { get; set; }
        /// <summary>
        /// Estadro de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
    }
}

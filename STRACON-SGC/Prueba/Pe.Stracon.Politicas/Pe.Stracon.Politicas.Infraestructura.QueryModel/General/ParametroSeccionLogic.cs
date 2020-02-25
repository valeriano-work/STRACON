using Pe.Stracon.Politicas.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Infraestructura.QueryModel.General
{
    /// <summary>
    /// Representa los datos de Parametro de Sección
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 27032015 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroSeccionLogic : Logic
    {
        /// <summary>
        /// Código de Parametro
        /// </summary>
        public int CodigoParametro { get; set; }
        /// <summary>
        /// Código de Sección
        /// </summary>
        public int CodigoSeccion { get; set; }
        /// <summary>
        /// Indicador de sistema
        /// </summary>
        public bool IndicadorSistema { get; set; }
        /// <summary>
        /// Nombre de Sección
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Código de Tipo de Dato
        /// </summary>
        public string CodigoTipoDato { get; set; }
        /// <summary>
        /// Descripción de Tipo de Dato
        /// </summary>
        public string DescripcionTipoDato { get; set; }
        /// <summary>
        /// Indicador de Permite Modificar
        /// </summary>
        public bool IndicadorPermiteModificar { get; set; }
        /// <summary>
        /// Indicador de Sección Obligatorio
        /// </summary>
        public bool IndicadorObligatorio { get; set; }
        /// <summary>
        /// Código de Parametro Relacionado
        /// </summary>
        public int? CodigoParametroRelacionado { get; set; }
        /// <summary>
        /// Nombre de Parámetro Relacionado
        /// </summary>
        public string NombreParametroRelacionado { get; set; }
        /// <summary>
        /// Código de Sección Relacionada
        /// </summary>
        public int? CodigoSeccionRelacionado { get; set; }
        /// <summary>
        /// Nombre de Sección Relacionada
        /// </summary>
        public string NombreSeccionRelacionado { get; set; }
        /// <summary>
        /// Código de Sección Relacionada a Mostrar
        /// </summary>
        public int? CodigoSeccionRelacionadoMostrar { get; set; }
        /// <summary>
        /// Nombre de Sección Relacionada a Mostrar
        /// </summary>
        public string NombreSeccionRelacionadoMostrar { get; set; }
        /// <summary>
        /// Estadro de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
    }
}

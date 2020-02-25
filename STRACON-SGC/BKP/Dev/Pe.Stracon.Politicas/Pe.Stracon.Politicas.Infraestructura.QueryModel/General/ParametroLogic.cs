using Pe.Stracon.Politicas.Infraestructura.QueryModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.Politicas.Infraestructura.QueryModel.General
{
    /// <summary>
    /// Representa los datos de Parametro
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 27032015 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroLogic : Logic
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
        /// Código Empresa
        /// </summary>
        public Guid CodigoEmpresa { get; set; }
        /// <summary>
        /// Código Identificador de Empresa
        /// </summary>
        public string CodigoEmpresaIdentificador { get; set; }
        /// <summary>
        /// Nombre de Empresa
        /// </summary>
        public string NombreEmpresa { get; set; }
        /// <summary>
        /// Código Sistema 
        /// </summary>
        public Guid? CodigoSistema { get; set; }
        /// <summary>
        /// Código Identificador de Sistema
        /// </summary>
        public string CodigoSistemaIdentificador { get; set; }
        /// <summary>
        /// Nombre de Sistema
        /// </summary>
        public string NombreSistema { get; set; }
        /// <summary>
        /// Tipo de Parámetro 
        /// </summary>
        public string TipoParametro { get; set; }
        /// <summary>
        /// Nombre del Parametro
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Descripción del Parametro
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Indicador Permite Agregar 
        /// </summary>
        public bool IndicadorPermiteAgregar { get; set; }
        /// <summary>
        /// Indicador Permite Modificar 
        /// </summary>
        public bool IndicadorPermiteModificar { get; set; }
        /// <summary>
        /// Indicador Permite Eliminar 
        /// </summary>
        public bool IndicadorPermiteEliminar { get; set; }        
        /// <summary>
        /// Estadro de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
    }
}

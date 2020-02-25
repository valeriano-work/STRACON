
namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Datos generales de parametro
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22122014 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroResponse
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
        /// Descripción de Identificador de Empresa 
        /// </summary>
        public string DescripcionIndicadorEmpresa { get; set; }
        /// <summary>
        /// Código Empresa 
        /// </summary>
        public string CodigoEmpresa { get; set; }
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
        public string CodigoSistema { get; set; }
        /// <summary>
        /// Código Identificador del Sistema 
        /// </summary>
        public string CodigoSistemaIdentificador { get; set; }
        /// <summary>
        /// Nombre del Sistema
        /// </summary>
        public string NombreSistema { get; set; }        
        /// <summary>
        /// Tipo de Parámetro
        /// </summary>
        public string TipoParametro { get; set; }
        /// <summary>
        /// Descripción de Tipo de Parámetro
        /// </summary>
        public string DescripcionTipoParametro { get; set; }
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

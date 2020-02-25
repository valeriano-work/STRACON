using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;
using Pe.Stracon.Politicas.Infraestructura.Core.Context;
using System;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General
{
    /// <summary>
    /// Representa el objeto de filtro a aplicar a la busqueda de parametro
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150327 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroRequest : Filtro
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ParametroRequest()
        {
            EstadoRegistro = DatosConstantes.EstadoRegistro.Activo;
        }
        /// <summary>
        /// Código del Parametro
        /// </summary>
        public int? CodigoParametro { get; set; }
        /// <summary>
        /// Indicador Empresa
        /// </summary>
        public bool? IndicadorEmpresa { get; set; }
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
        /// Tipo de Parámetro
        /// </summary>
        public string TipoParametro { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Indicador Permite Agregar
        /// </summary>
        public bool? IndicadorPermiteAgregar { get; set; }
        /// <summary>
        /// Indicador Permite Modificar
        /// </summary>
        public bool? IndicadorPermiteModificar { get; set; }
        /// <summary>
        /// Indicador Permite Eliminar
        /// </summary>
        public bool? IndicadorPermiteEliminar { get; set; }        
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
    }

}

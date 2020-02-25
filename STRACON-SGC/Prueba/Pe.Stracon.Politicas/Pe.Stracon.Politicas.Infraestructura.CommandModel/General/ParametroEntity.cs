using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using System;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad parámetro
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class ParametroEntity : Entity
    {
        /// <summary>
        /// Código de parámetro
        /// </summary>
        public int CodigoParametro { get; set; }
        /// <summary>
        /// Código de Empresa
        /// </summary>
        public Guid CodigoEmpresa { get; set; }
        /// <summary>
        /// Código de sistema
        /// </summary>
        public Guid? CodigoSistema { get; set; }
        /// <summary>
        /// Código de identificador
        /// </summary>
        public string CodigoIdentificador { get; set; }
        /// <summary>
        /// Nombre 
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Indicador que permite agregar
        /// </summary>
        public bool IndicadorPermiteAgregar { get; set; }
        /// <summary>
        /// Indicador que permite modificar
        /// </summary>
        public bool IndicadorPermiteModificar { get; set; }
        /// <summary>
        /// Indicador que permite eliminar
        /// </summary>
        public bool IndicadorPermiteEliminar { get; set; }
        /// <summary>
        /// Tipo de Parámetro
        /// </summary>
        public string TipoParametro { get; set; }
        /// <summary>
        /// Indicador empresa
        /// </summary>
        public bool? IndicadorEmpresa { get; set; }

    }
}

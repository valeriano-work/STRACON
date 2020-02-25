using System;
using Pe.Stracon.SGC.Infraestructura.CommandModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.CommandModel.Contractual
{
    /// <summary>
    /// Clase que representa la entidad Bien Registro
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150511 <br />
    /// Modificación :           <br />
    /// </remarks>  
    public class BienRegistroEntity : Entity
    {
        /// <summary>
        /// Codigo del Bien de Registro
        /// </summary>
        public Guid CodigoBienRegistro { get; set; } 
        /// <summary>
        /// Codigo del Tipo de Contenido
        /// </summary>
        public string CodigoTipoContenido { get; set; } 
        /// <summary>
        /// Contenido
        /// </summary>
        public string Contenido { get; set; }         
    }
}

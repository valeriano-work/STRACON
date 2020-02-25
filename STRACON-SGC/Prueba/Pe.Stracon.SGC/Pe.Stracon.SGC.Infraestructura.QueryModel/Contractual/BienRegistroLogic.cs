using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    public class BienRegistroLogic
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

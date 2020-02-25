using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad de unidad operativa responsable
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20161121 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaUsuarioConsultaEntity : Entity
    {
        /// <summary>
        /// Código de Identificación de la unidad operativa usuario consulta
        /// </summary>
        public Guid? CodigoUnidadUsuarioConsulta { get; set; }
        /// <summary>
        /// Código de unidad operativa
        /// </summary>
        public Guid? CodigoUnidadOperativa { get; set; } 
        /// <summary>
        /// CodigoTrabajador
        /// </summary>
        public Guid? CodigoTrabajador { get; set; }

    }
}

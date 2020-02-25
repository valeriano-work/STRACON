using System;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Datos generales de la unidad operativa nivel
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20161129 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class UnidadOperativaNivelResponse
    {
        /// <summary>
        /// Código de Nivel de Jerarquía
        /// </summary>
        public string CodigoNivelJerarquia { get; set; }
        /// <summary>
        /// Código Unidad Operativa Matriz
        /// </summary>
        public Guid? CodigoUnidadOperativaNivel1 { get; set; }
        /// <summary>
        /// Código responsable Matriz
        /// </summary>
        public Guid? CodigoResponsableNivel1 { get; set; }
        /// <summary>
        /// Código Unidad Operativa Nivel Empresa
        /// </summary>
        public Guid? CodigoUnidadOperativaNivel2 { get; set; }
        /// <summary>
        /// Código responsable Nivel Empresa
        /// </summary>
        public Guid? CodigoResponsableNivel2 { get; set; }
        /// <summary>
        /// Código Unidad Operativa Nivel Proyecto
        /// </summary>
        public Guid? CodigoUnidadOperativaNivel3 { get; set; }
        /// <summary>
        /// Código responsable Nivel Proyecto
        /// </summary>
        public Guid? CodigoResponsableNivel3 { get; set; }
    }
}

using System;
namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{
    /// <summary>
    /// Representa el objeto response de Trabajador Datos Minimos
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150617 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorDatoMinimoResponse
    {
        /// <summary>
        /// Código Trabajador
        /// </summary>
        public Guid CodigoTrabajador { get; set; }
        /// <summary>
        /// Dominio
        /// </summary>
        public string Dominio { get; set; }
        /// <summary>
        /// Dominio
        /// </summary>
        public string DominioCorto { get; set; }
        /// <summary>
        /// Código Identificación
        /// </summary>
        public string CodigoIdentificacion { get; set; }
        /// <summary>
        /// Nombre Completo
        /// </summary>
        public string NombreCompleto { get; set; }
        /// <summary>
        /// Link de la foto
        /// </summary>
        public string LinkFoto { get; set; }
        /// <summary>
        /// Correo Eléctronico
        /// </summary>
        public string CorreoElectronico { get; set; }
        /// <summary>
        /// Departamento
        /// </summary>
        public string Departamento { get; set; }
        /// <summary>
        /// Cargo
        /// </summary>
        public string Cargo { get; set; }
    }
}

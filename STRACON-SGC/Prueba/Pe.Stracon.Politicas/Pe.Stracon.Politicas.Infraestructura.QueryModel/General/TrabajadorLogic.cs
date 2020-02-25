using Pe.Stracon.Politicas.Infraestructura.QueryModel.Base;
using System;

namespace Pe.Stracon.Politicas.Infraestructura.QueryModel.General
{
    /// <summary>
    /// Representa los datos de Trabajador
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 22150326 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorLogic : Logic
    {
        /// <summary>
        /// Código Trabajador
        /// </summary>
        public Guid? CodigoTrabajador { get; set; }
        /// <summary>
        /// Código Identificación
        /// </summary>
        public string CodigoIdentificacion { get; set; }
        /// <summary>
        /// Código Tipo Documento Identidad
        /// </summary>
        public string CodigoTipoDocumentoIdentidad { get; set; }
        /// <summary>
        /// Número Documento IDentidad
        /// </summary>
        public string NumeroDocumentoIdentidad { get; set; }
        /// <summary>
        /// Apelllido Paterno
        /// </summary>
        public string ApellidoPaterno { get; set; }
        /// <summary>
        /// Apellido Materno
        /// </summary>
        public string ApellidoMaterno { get; set; }
        /// <summary>
        /// Nombres
        /// </summary>
        public string Nombres { get; set; }
        /// <summary>
        /// Nombre Completo
        /// </summary>
        public string NombreCompleto { get; set; }
        /// <summary>
        /// Organización
        /// </summary>
        public string Organizacion { get; set; }
        /// <summary>
        /// Departamento
        /// </summary>
        public string Departamento { get; set; }
        /// <summary>
        /// Cargo
        /// </summary>
        public string Cargo { get; set; }
        /// <summary>
        /// Télefono Trabajo
        /// </summary>
        public string TelefonoTrabajo { get; set; }
        /// <summary>
        /// Anexo
        /// </summary>
        public string Anexo { get; set; }
        /// <summary>
        /// Teléfono Móvil
        /// </summary>
        public string TelefonoMovil { get; set; }
        /// <summary>
        /// Télefono Personal
        /// </summary>
        public string TelefonoPersonal { get; set; }
        /// <summary>
        /// Correo Eléctronico
        /// </summary>
        public string CorreoElectronico { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
        /// <summary>
        /// Dominio de trabajador.
        /// </summary>
        public string Dominio { get; set; }
        /// <summary>
        /// Firma de trabajador
        /// </summary>
        public Byte[] FirmaTrabajador { get; set; }
        /// <summary>
        /// Código de Firma de Trabajador
        /// </summary>
        public Guid? CodigoFirma { get; set; }
        /// <summary>
        /// Indica si el trabajador esta asociado a todas las unidad operativas o solo a algunas
        /// </summary>
        public bool IndicadorTodaUnidadOperativa { get; set; }
        /// <summary>
        /// Indicador si el usuario tiene Foto
        /// </summary>
        public bool IndicadorTieneFoto { get; set; }
        /// <summary>
        /// Código de unidad operativa matriz
        /// </summary>
        public Guid? CodigoUnidadOperativaMatriz { get; set; }
    }
}
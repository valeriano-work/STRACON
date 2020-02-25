using Pe.Stracon.Politicas.Infraestructura.CommandModel.Base;
using System;

namespace Pe.Stracon.Politicas.Infraestructura.CommandModel.General
{
    /// <summary>
    /// Clase que representa la entidad trabajador
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150107 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorEntity : Entity
    {
        /// <summary>
        /// Código de Trabajador
        /// </summary>
        public Guid? Codigo { get; set; }
        /// <summary>
        /// Código de Trabajador
        /// </summary>
        public string CodigoIdentificacion { get; set; }
        /// <summary>
        /// Código de tipo de documento de identidad
        /// </summary>
        public string CodigoTipoDocumentoIdentidad { get; set; }
        /// <summary>
        /// Número de documento de identidad
        /// </summary>
        public string NumeroDocumentoIdentidad { get; set; }
        /// <summary>
        /// Apellido paterno
        /// </summary>
        public string ApellidoPaterno { get; set; }
        /// <summary>
        /// Apellido materno
        /// </summary>
        public string ApellidoMaterno { get; set; }
        /// <summary>
        /// Nombres
        /// </summary>
        public string Nombres { get; set; }
        /// <summary>
        /// Nombre completo
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
        /// Teléfono de trabajo
        /// </summary>
        public string TelefonoTrabajo { get; set; }
        /// <summary>
        /// Anexo
        /// </summary>
        public string Anexo { get; set; }
        /// <summary>
        /// Teléfono móvil
        /// </summary>
        public string TelefonoMovil { get; set; }
        /// <summary>
        /// Teléfono personal
        /// </summary>
        public string TelefonoPersonal { get; set; }
        /// <summary>
        /// Correo electronico
        /// </summary>
        public string CorreoElectronico { get; set; }
        /// <sumary>
        /// Dominio del trabajador.
        /// </sumary>
        public string Dominio { get; set; }     
        /// <summary>
        /// Indicador si el usuario tiene Foto
        /// </summary>
        public bool IndicadorTieneFoto{ get; set; }
        /// <summary>
        /// Indica si el trabajador esta asignado a todas las unidades operativas
        /// </summary>
        public bool IndicadorTodaUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Unidad Operativa Matriz
        /// </summary>
        public Guid? CodigoUnidadOperativaMatriz { get; set; }
    }
}

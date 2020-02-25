using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General
{

    /// <summary>
    /// Representa el objeto response de Trabajador
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150401 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorResponse : Paginado
    {
        /// <summary>
        /// Código Trabajador
        /// </summary>
        public string CodigoTrabajador { get; set; }
        /// <summary>
        /// Código Identificación
        /// </summary>
        public string CodigoIdentificacion { get; set; }
        /// <summary>
        /// Código Tipo Documento de Identidad
        /// </summary>
        public string CodigoTipoDocumentoIdentidad { get; set; }
        /// <summary>
        /// Descripción del Tipo Documento de Identidad
        /// </summary>
        public string DescripcionTipoDocumentoIdentidad { get; set; }
        /// <summary>
        /// Número de Documento Identidad
        /// </summary>
        public string NumeroDocumentoIdentidad { get; set; }
        /// <summary>
        /// Apellido Paterno
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
        /// Cargo
        /// </summary>
        public string Cargo { get; set; }
        /// <summary>
        /// Departamento
        /// </summary>
        public string Departamento { get; set; }
        /// <summary>
        /// Teléfono Trabajo
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
        /// Teléfono Personal
        /// </summary>
        public string TelefonoPersonal { get; set; }
        /// <summary>
        /// Correo Eléctronico
        /// </summary>
        public string CorreoElectronico { get; set; }
        /// <summary>
        /// Codigo de Firma de trabajador.
        /// </summary>
        public string CodigoFirma { get; set; }
        /// <summary>
        /// Firma
        /// </summary>
        public byte[] Firma { get; set; }
        /// <summary>
        /// Dominio de trabajador.
        /// </summary>
        public string Dominio { get; set; }
        /// <summary>
        /// Dominio de trabajador.
        /// </summary>
        public string DominioCorto { get; set; }
        /// <summary>
        /// Foto de trabajador.
        /// </summary>
        public string LinkFoto { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
       /// <summary>
       /// Indica si el trabajador esta asociado a todas las unidad operativas o solo a algunas
       /// </summary>
        public bool IndicadorTodaUnidadOperativa { get; set; }
        /// <summary>
        /// Código de unidad operativa matriz
        /// </summary>
        public string CodigoUnidadOperativaMatriz { get; set; }

        /// <summary>
        /// Objeto creado para obtener la lógica de Consulta
        /// </summary>
        public string UsuarioCreacion { get; set; }
    }
}

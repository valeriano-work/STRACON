using Pe.Stracon.Politicas.Aplicacion.TransferObject.Base;
using System;

namespace Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General
{
    /// <summary>
    /// Representa el objeto request de Trabajador
    /// </summary>
    /// <remarks>
    /// Creación:   GMD 20150401 <br />
    /// Modificación:            <br />
    /// </remarks>
    public class TrabajadorRequest : Filtro
    {
        /// <summary>
        /// Código de Trabajador
        /// </summary>
        public Guid? CodigoTrabajador { get; set; }
        /// <summary>
        /// Código de Identificación
        /// </summary>
        public string CodigoIdentificacion { get; set; }
        /// <summary>
        /// Código de Identificación
        /// </summary>
        public string CodigoTipoDocumentoIdentidad { get; set; }
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
        /// Nombre
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
        public Guid? CodigoFirma { get; set; }
        /// <summary>
        /// Firma de trabajador.
        /// </summary>
        public byte[] Firma { get; set; }
        /// <summary>
        /// Dominio de trabajador.
        /// </summary>
        public string Dominio { get; set; }
        /// <summary>
        /// Estado de Registro
        /// </summary>
        public string EstadoRegistro { get; set; }
        /// <summary>
        /// Nivel de Alerta para la Calendarizacion
        /// </summary>
        public byte NivelAlerta { get; set; }
        /// <summary>
        /// Indica si el trabajador esta asignado a todas las unidades operativas
        /// </summary>
        public bool IndicadorTodaUnidadOperativa { get; set; }
        /// <summary>
        /// Código Unidad Operativa Matriz
        /// </summary>
        public string CodigoUnidadOperativaMatriz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TrabajadorUnidadOperativaRequest trabajadorUnidadOperativaRequest { get; set; }
    }
}

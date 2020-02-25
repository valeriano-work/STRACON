using System;
using System.Collections.Generic;

namespace Pe.GyM.Security.Account.Model
{
    /// <summary>
    /// Objecto que representa una cuenta de usuario
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319
    /// Modificación:   
    /// </remarks>
    [Serializable]
    public class CuentaUsuario
    {
        /// <summary>
        /// Código
        /// </summary>
        public int Codigo { get; set; }
        /// <summary>
        /// Alias de logueo
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// Dominio del AD
        /// </summary>
        public string Dominio { get; set; }
        /// <summary>
        /// Clave de logueo
        /// </summary>
        public string Clave { get; set; }
        /// <summary>
        /// Nombres
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// Apellido paterno
        /// </summary>
        public string ApellidoPaterno { get; set; }
        /// <summary>
        /// Apellido Materno
        /// </summary>
        public string ApellidoMaterno { get; set; }
        /// <summary>
        /// Nombre Completo
        /// </summary>
        public string NombreCompleto
        {
            get
            {
                return string.Format("{0} {1} {2}", this.Nombre, this.ApellidoPaterno, this.ApellidoMaterno);
            }
        }
        /// <summary>
        /// Organización
        /// </summary>
        public string Organizacion { get; set; }
        /// <summary>
        /// Departamento de la organización
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// Cargo ocupado
        /// </summary>
        public string Cargo { get; set; }
        /// <summary>
        /// Número de teléfeno del trabajo
        /// </summary>
        public string TelefonoTrabajo { get; set; }
        /// <summary>
        /// Número de Anexo
        /// </summary>
        public string Anexo { get; set; }
        /// <summary>
        /// Número de celular
        /// </summary>
        public string TelefonoMovil { get; set; }
        /// <summary>
        /// Número del teléfono personal
        /// </summary>
        public string TelefonoParticular { get; set; }
        /// <summary>
        /// Correo electrónico
        /// </summary>
        public string CorreoElectronico { get; set; }
        /// <summary>
        /// Foto del usuario
        /// </summary>
        public byte[] Imagen { get; set; }
        /// <summary>
        /// Perfil del cuenta
        /// </summary>
        public string Perfil { get; set; }
        /// <summary>
        /// Zona ubigeo
        /// </summary>
        public string Ubigeo { get; set; }
        /// <summary>
        /// País
        /// </summary>
        public string Pais { get; set; }
        /// <summary>
        /// Código de la empresa
        /// </summary>
        public string CodigoEmpresa { get; set; }
        /// <summary>
        /// Codigo del sistema
        /// </summary>
        public string CodigoSistema { get; set; }
        /// <summary>
        /// Código de sistema según el SRA
        /// </summary>
        public int CodigoSistemaSra { get; set; }
        /// <summary>
        /// Modulos asignados en la consulta de acceso a sistema
        /// </summary>
        public List<Modulo> Modulos { get; set; }
        /// <summary>
        /// LIstado Empresa
        /// </summary>
        public List<Empresa> ListEmpresa { get; set; }

        /// <summary>
        /// Número de Documento
        /// </summary>
        public string NumeroDocumento { get; set; }
        /// <summary>
        /// codigo Empresa
        /// </summary>
        public Guid? IdEmpresa { get; set; }
        /// <summary>
        /// Número de Documento
        /// </summary>
        public string NombrePuestaIngreso { get; set; }
        /// <summary>
        /// Código de Trabajador
        /// </summary>
        public string CodigoTrabajador { get; set; }
        /// <summary>
        /// Código de Unidad Operativa Matriz
        /// </summary>
        public string CodigoUnidadOperativaMatriz { get; set; }

    }
}

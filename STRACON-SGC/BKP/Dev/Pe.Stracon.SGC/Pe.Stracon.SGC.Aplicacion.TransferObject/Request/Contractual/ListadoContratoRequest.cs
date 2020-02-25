using Pe.Stracon.Politicas.Aplicacion.TransferObject.Request.General;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pe.Stracon.SGC.Aplicacion.TransferObject.Request.Contractual
{
    /// <summary>
    /// Representa el objeto request de Listado Contrato
    /// </summary>
    /// <remarks>
    /// Creación :      GMD 20150601 <br />
    /// Modificación :               <br />
    /// </remarks>
    public class ListadoContratoRequest : Filtro
    {
        /// <summary>
        /// Código de Contrato
        /// </summary>
        public string CodigoContrato { get; set; }
        /// <summary>
        /// Código de Unidad Operativa
        /// </summary>
        public string CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// Código de Proveedor
        /// </summary>
        public string CodigoProveedor { get; set; }
        /// <summary>
        /// Número de Documento de Proveedor
        /// </summary>
        public string NumeroDocumentoProveedor { get; set; }
        /// <summary>
        /// Nombre de Proveedor
        /// </summary>
        public string NombreProveedor { get; set; }
        /// <summary>
        /// Número de Contrato
        /// </summary>
        public string NumeroContrato { get; set; }
        /// <summary>
        /// Número de adenda concatenado
        /// </summary>
        public string NumeroAdendaConcatenado { get; set; }
        /// <summary>
        /// Descripción
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// Código de Tipo de Servicio
        /// </summary>
        public string CodigoTipoServicio { get; set; }
        /// <summary>
        /// Código de Tipo de Requerimiento
        /// </summary>
        public string CodigoTipoRequerimiento { get; set; }
        /// <summary>
        /// Código de Tipo de Documento
        /// </summary>
        public string CodigoTipoDocumento { get; set; }
        /// <summary>
        /// Código de Estado de Contrato
        /// </summary>
        public string CodigoEstadoContrato { get; set; }
        /// <summary>
        /// Fecha de Inicio de Vigencia en cadena de texto
        /// </summary>
        public string FechaInicioVigenciaString { get; set; }
        /// <summary>
        /// Fecha de Fin de Vigencia en cadena de texto
        /// </summary>
        public string FechaFinVigenciaString { get; set; }
        /// <summary>
        /// Código de Moneda
        /// </summary>
        public string CodigoMoneda { get; set; }
        /// <summary>
        /// Monto de Contrato en cadena de texto
        /// </summary>
        public string MontoContratoString { get; set; }
        /// <summary>
        /// Código de Plantilla
        /// </summary>
        public string CodigoPlantilla { get; set; }
        /// <summary>
        /// Código de Contrato Principal
        /// </summary>
        public string CodigoContratoPrincipal { get; set; }
        /// <summary>
        /// Código de Estado de Edición
        /// </summary>
        public string CodigoEstadoEdicion { get; set; }
        /// <summary>
        /// Comentario de Modificación
        /// </summary>
        public string ComentarioModificacion { get; set; }
        /// <summary>
        /// Respuesta de Modificación
        /// </summary>
        public string RespuestaModificacion { get; set; }
        /// <summary>
        /// Código de Estadio Actual
        /// </summary>
        public string CodigoEstadioActual { get; set; }
        /// <summary>
        /// Trabajador
        /// </summary>
        public TrabajadorResponse Trabajador { get; set; }
        /// <summary>
        /// Descripción del contrato
        /// </summary>
        public string DescripcionContrato { get; set; }

        /// <summary>
        /// Código de Trabajador Responsable
        /// </summary>
        public string CodigoTrabajadorResponsable { get; set; }

        /// <summary>
        /// Nombre de Estadio
        /// </summary>
        public string NombreEstadio { get; set; }

        /// <summary>
        /// Indicador de Finalizar Aprobación
        /// </summary>
        public string IndicadorFinalizarAprobacion { get; set; }

        /// <summary>
        /// Nombre de Estadio
        /// </summary>
        public string TipoServicioLC { get; set; }
        public string UsuarioCreacion { get; set; }
        /// <summary>
        /// Monto Acumulado Inicio
        /// </summary>
        public string MontoAcumuladoInicio { get; set; }
        /// <summary>
        /// Monto Acumulado Fin
        /// </summary>
        public string MontoAcumuladoFin { get; set; }

        public DateTime FechaResolucion { get; set; }

        public string FechaResolucionString { get; set; }

        public int ValidacionResolucion { get; set; }

        /// <summary>
        /// Codigo Requerido
        /// </summary>
        public string CodigoRequerido { get; set; }
        /// <summary>
        /// Nombre de Requerido
        /// </summary>
        public string NombreRequerido { get; set; }
    }
}

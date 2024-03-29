﻿using System;
using Pe.Stracon.SGC.Infraestructura.QueryModel.Base;

namespace Pe.Stracon.SGC.Infraestructura.QueryModel.Contractual
{
    /// <summary>
    /// Representa el objeto Logic de Requerimiento
    /// </summary>
    /// <remarks>
    /// Creación :  GMD 20150515 <br />
    /// Modificación :           <br />
    /// </remarks>
    public class RequerimientoLogic : Logic
    {
        /// <summary>
        /// CodigoRequerimiento
        /// </summary>
        public Guid CodigoRequerimiento { get; set; }
        /// <summary>
        /// CodigoUnidadOperativa
        /// </summary>
        public Guid CodigoUnidadOperativa { get; set; }
        /// <summary>
        /// CodigoProveedor
        /// </summary>
        public Guid CodigoProveedor { get; set; }
        /// <summary>
        /// CodigoProveedor
        /// </summary>
        public string NombreProveedor { get; set; }
        /// <summary>
        /// NumeroRequerimiento
        /// </summary>
        public string NumeroRequerimiento { get; set; }
        /// <summary>
        /// Descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// CodigoTipoServicio
        /// </summary>
        public string CodigoTipoServicio { get; set; }
        /// <summary>
        /// CodigoTipoRequerimiento
        /// </summary>
        public string CodigoTipoRequerimiento { get; set; }
        /// <summary>
        /// Indicador de si Carga del Estadio 
        /// </summary>
        public bool IndicadorPermiteCarga { get; set; }
        /// <summary>
        /// CodigoTipoDocumento
        /// </summary>
        public string CodigoTipoDocumento { get; set; }
        /// <summary>
        /// FechaInicioVigencia
        /// </summary>
        public DateTime FechaInicioVigencia { get; set; }
        /// <summary>
        /// FechaFinVigencia
        /// </summary>
        public DateTime FechaFinVigencia { get; set; }
        /// <summary>
        /// CodigoMoneda
        /// </summary>
        public string CodigoMoneda { get; set; }
        /// <summary>
        /// MontoRequerimiento
        /// </summary>
        public decimal MontoRequerimiento { get; set; }
        /// <summary>
        /// MontoRequerimiento
        /// </summary>
        public decimal MontoAcumulado { get; set; }
        /// <summary>
        /// CodigoEstado
        /// </summary>
        public string CodigoEstado { get; set; }
        /// <summary>
        /// CodigoPlantilla
        /// </summary>
        public Guid CodigoPlantilla { get; set; }
        /// <summary>
        /// CodigoRequerimientoPrincipal
        /// </summary>
        public Guid CodigoRequerimientoPrincipal { get; set; }
        /// <summary>
        /// CodigoEstadoEdicion
        /// </summary>
        public string CodigoEstadoEdicion { get; set; }
        /// <summary>
        /// ComentarioModificacion
        /// </summary>
        public string ComentarioModificacion { get; set; }
        /// <summary>
        /// RespuestaModificacion
        /// </summary>
        public string RespuestaModificacion { get; set; }
        /// <summary>
        /// CodigoEstadioActual
        /// </summary>
        public Guid CodigoEstadioActual { get; set; }
        /// <summary>
        /// Descripción del estadio actual
        /// </summary>
        public string DescripcionEstadioActual { get; set; }
        /// <summary>
        /// Código de Estadio de Requerimiento
        /// </summary>
        public Guid CodigoRequerimientoEstadio { get; set; }

        /// <summary>
        /// Código de Flujo Aprobacion Estadio
        /// </summary>
        public Guid CodigoFlujoAprobacionEstadio { get; set; }

        /// <summary>
        /// Código de Flujo Aprobacion
        /// </summary>
        public Guid CodigoFlujoAprobacion { get; set; }
        /// <summary>
        /// Fecha de ingreso a proceso del Requerimiento
        /// </summary>
        public DateTime? FechaIngreso { get; set; }

        /// <summary>
        /// Dias pendiente de revision del contrto
        /// </summary>
        public int DiasPendiente { get; set; }

        /// <summary>
        /// Fecha de ultima notificación del contrato
        /// </summary>
        public DateTime? FechaUltimaNotificacion { get; set; }

        /// <summary>
        /// Flag que indica si el contrato es por Consulta o para aprobación
        /// </summary>
        public string EstadioPropioConsulta { get; set; }

        /// <summary>
        /// Descripción del contrato
        /// </summary>
        public string DescripcionRequerimiento { get; set; }

        /// <summary>
        /// Fecha de modificación del contrato
        /// </summary>
        public DateTime? FechaModificacion { get; set; }

        /// <summary>
        /// Usuario de creación
        /// </summary>
        public string UsuarioCreacion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.Bienes
{
    /// <summary>
    /// Modelo de vista para Formulario Bien Alquiler
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20150319 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class BienAlquilerFormulario
    {
        #region Propiedades
        /// <summary>
        /// Clase responde del BienAlquiler
        /// </summary>
        public BienAlquilerResponse BienAlquiler { get; set; }
        #endregion
        /// <summary>
        /// Constructor Formulario Bien Alquiler
        /// </summary>
        public BienAlquilerFormulario()
        {
            this.BienAlquiler = new BienAlquilerResponse();
        }
    }
}
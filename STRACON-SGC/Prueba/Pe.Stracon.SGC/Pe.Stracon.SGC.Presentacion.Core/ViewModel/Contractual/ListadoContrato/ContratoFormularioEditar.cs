using Pe.Stracon.Politicas.Aplicacion.TransferObject.Response.General;
using Pe.Stracon.SGC.Aplicacion.TransferObject.Response.Contractual;
using Pe.Stracon.SGC.Infraestructura.Core.Context;
using Pe.Stracon.SGC.Presentacion.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pe.Stracon.SGC.Presentacion.Core.ViewModel.Contractual.ListadoContrato
{
    /// <summary>
    /// Modelo de vista de Contrato Formulario Editar
    /// </summary>
    /// <remarks>
    /// Creación:       GMD 20171115 </br>
    /// Modificación:                </br>
    /// </remarks>
    public class ContratoFormularioEditar: GenericViewModel
    {
        #region Propiedades

        public string CodigoContrato { get; set; }

        public string Contenido { get; set; }

        public string RespuestaAuto { get; set; }

        public string CodigoEstadoEdicion { get; set; }

        #endregion

        public ContratoFormularioEditar()
        {

        }
    }
}

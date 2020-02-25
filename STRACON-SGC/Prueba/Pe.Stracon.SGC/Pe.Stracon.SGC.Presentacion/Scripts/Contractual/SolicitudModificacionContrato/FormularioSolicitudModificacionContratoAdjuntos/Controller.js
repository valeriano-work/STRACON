ns('Pe.Stracon.SGC.Presentacion.Contractual.FormularioSolicitudModificacionContratoAdjuntos');

Pe.Stracon.SGC.Presentacion.Contractual.FormularioSolicitudModificacionContratoAdjuntos.Controller = function (opts) {
    var base = this;
    base.Ini = function () {

        base.Control.Modelo = Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Adjuntos.Models.FormularioCargaAdjuntoContrato;
        base.Function.CrearGrid();
        base.Event.BtnBuscarClick();
        base.Control.BtnCerrarCargaArchivoAdjunto().on("click", base.Event.BtnCancelarClick);
     
    };
    base.Control = {
        Controles: null,
        DialogFormularioCarga: null,
        Mensaje: new Pe.GMD.UI.Web.Components.Message(),
        BtnCerrarCargaArchivoAdjunto: function () { return $('#btnCerrarCargaArchivoAdjunto'); },
        GrdResultado: null,
        Modelo: null
      
    };
    base.Show = function (data) {
        base.Control.DialogFormularioCarga = new Pe.GMD.UI.Web.Components.Dialog({
            title: data.request.NumeroContrato,
            width: '60%',
            close: function () {
                base.Control.DialogFormularioCarga.destroy();
            }
        });

        base.Control.DialogFormularioCarga.getAjaxContent({
            action: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Actions.FormularioCargaAdjunto,
            data: {
                request: data.request,
                controles: data.controles
            },
            onSuccess: function () {
                base.Ini();
            }
        });
    };
    base.Event = {
        BtnBuscarClick: function () {
            'use strict'
          
            var filtro = {
                CodigoContrato: base.Control.Modelo.Contrato.CodigoContrato
            }
            base.Control.GrdResultado.Load(filtro);
        },
        BtnCancelarClick: function () {
            base.Control.DialogFormularioCarga.close();
        },

        BtnGridDescargarClick: function (row, data) {
            'use strict'
            var vrParam = {
                CodigoContratoDocumentoAdjunto: data.CodigoContratoDocumentoAdjunto,
            };

            Pe.GMD.UI.Web.Components.Util.RedirectPost(Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Actions.DescargarArchivoAdjunto, vrParam);
        },       

    };
    base.Ajax = {

    };
    base.Function = {
        CrearGrid: function () {
            var columns = new Array();
            columns.push({
                data: 'NombreArchivo',
                title: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Adjuntos.Resources.GridNombreArchivo,
                width: "90%"
            });
            columns.push({
                "data": "", "title": Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Adjuntos.Resources.GridAcciones,
                "class": "controls",
                width: "10%",
                actionButtons: [
                    { type: Pe.GMD.UI.Web.Components.GridAction.DescargarAdjunto, event: { on: 'click', callBack: base.Event.BtnGridDescargarClick } }
                ]
            });

            base.Control.GrdResultado = new Pe.GMD.UI.Web.Components.Grid({
                renderTo: 'divGrdResultAdjuntos',
                columns: columns,
                hasSelectionRows: false,
                proxy: {
                    url: Pe.Stracon.SGC.Presentacion.Contractual.SolicitudModificacionContrato.Adjuntos.Actions.BuscarArchivoAdjunto,
                    source: 'Result'
                }
            });
        }
    };
}